[CmdletBinding()]
param(
    [string]$RepositoryRoot = (Join-Path $PSScriptRoot ".."),
    [string]$DocFxConfigPath = (Join-Path $PSScriptRoot "..\docfx.json"),
    [string]$ApiOutputPath = (Join-Path $PSScriptRoot "..\develop\api\types"),
    [string]$SchemaOutputPath = (Join-Path $PSScriptRoot "..\develop\schemadoc"),
    [string]$OutputPath = (Join-Path $PSScriptRoot "..\_artifacts\generated-metadata-provenance.json"),
    [string]$ValidatorPath = (Join-Path $PSScriptRoot "validate-generated-metadata-provenance.ps1"),
    [string]$SchemaSourcePath = "",
    [string]$SourceRevision = "",
    [string]$GenerationDate = "",
    [switch]$RequireGeneratedOutputs
)

Set-StrictMode -Version 2.0
$ErrorActionPreference = "Stop"

$script:GeneratorVersion = "1.0.0"
$script:Root = $null
$script:GapCounts = @{}
$script:Artifacts = New-Object "System.Collections.Generic.List[object]"
$script:ArtifactKeys = @{}
$script:ArtifactById = @{}
$script:AssemblyArtifactsByName = @{}
$script:AssemblyDocumentationById = @{}
$script:XmlDocumentationByAssembly = @{}
$script:ProjectRecords = New-Object "System.Collections.Generic.List[object]"
$script:PackageArtifacts = New-Object "System.Collections.Generic.List[string]"
$script:PackageArtifactsByAssemblyName = @{}
$script:SchemaArtifactsByIdentity = @{}
$script:OverwriteArtifactsByStem = @{}
$script:OverwriteManualByStem = @{}
$script:OverwriteArtifactsByUid = @{}
$script:OverwriteManualByUid = @{}
$script:ConfiguredSchemaArtifactsByIdentity = @{}
$script:BaseUrl = ""

function ConvertTo-FullPath {
    param([Parameter(Mandatory = $true)][string]$Path)

    if ([IO.Path]::IsPathRooted($Path)) {
        return [IO.Path]::GetFullPath($Path)
    }

    return [IO.Path]::GetFullPath((Join-Path (Get-Location).Path $Path))
}

function ConvertTo-RepositoryPath {
    param([Parameter(Mandatory = $true)][string]$Path)

    if ([IO.Path]::IsPathRooted($Path)) {
        return [IO.Path]::GetFullPath($Path)
    }
    return [IO.Path]::GetFullPath((Join-Path $script:Root $Path))
}

function ConvertTo-RepositoryRelativePath {
    param(
        [Parameter(Mandatory = $true)][string]$Path,
        [string]$Root = $script:Root
    )

    $fullPath = [IO.Path]::GetFullPath($Path)
    $prefix = $Root.TrimEnd("\") + "\"
    if (-not $fullPath.StartsWith($prefix, [StringComparison]::OrdinalIgnoreCase)) {
        return $null
    }

    return $fullPath.Substring($prefix.Length).Replace("\", "/")
}

function Normalize-Text {
    param([AllowEmptyString()][string]$Text)

    if ($null -eq $Text) {
        return ""
    }

    return [Regex]::Replace($Text, "`r`n?", "`n")
}

function Get-FileSha256 {
    param([Parameter(Mandatory = $true)][string]$Path)

    $hash = [Security.Cryptography.SHA256]::Create()
    try {
        return ([BitConverter]::ToString($hash.ComputeHash([IO.File]::ReadAllBytes($Path)))).Replace("-", "").ToLowerInvariant()
    }
    finally {
        $hash.Dispose()
    }
}

function Get-TextSha256 {
    param([AllowEmptyString()][string]$Text)

    $bytes = [Text.Encoding]::UTF8.GetBytes((Normalize-Text $Text))
    $hash = [Security.Cryptography.SHA256]::Create()
    try {
        return ([BitConverter]::ToString($hash.ComputeHash($bytes))).Replace("-", "").ToLowerInvariant()
    }
    finally {
        $hash.Dispose()
    }
}

function Get-CanonicalOutputText {
    param([AllowEmptyString()][string]$Text)

    $canonical = Normalize-Text $Text
    $rootWithBackslashes = $script:Root.TrimEnd("\")
    $rootWithSlashes = $rootWithBackslashes.Replace("\", "/")
    $canonical = [Regex]::Replace($canonical, [Regex]::Escape($rootWithBackslashes), "<repository>", [Text.RegularExpressions.RegexOptions]::IgnoreCase)
    $canonical = [Regex]::Replace($canonical, [Regex]::Escape($rootWithSlashes), "<repository>", [Text.RegularExpressions.RegexOptions]::IgnoreCase)
    return $canonical
}

function Get-OutputUrl {
    param([Parameter(Mandatory = $true)][string]$RelativePath)

    $htmlPath = [Regex]::Replace($RelativePath, "\.(?:yml|md)$", ".html", [Text.RegularExpressions.RegexOptions]::IgnoreCase)
    if ([String]::IsNullOrWhiteSpace($script:BaseUrl)) {
        return $htmlPath
    }
    return $script:BaseUrl.TrimEnd("/") + "/" + [Uri]::EscapeUriString($htmlPath)
}

function Write-TextIfChanged {
    param(
        [Parameter(Mandatory = $true)][string]$Path,
        [Parameter(Mandatory = $true)][string]$Text
    )

    $existing = if (Test-Path -LiteralPath $Path -PathType Leaf) {
        [IO.File]::ReadAllText($Path)
    }
    else {
        $null
    }
    if ($existing -eq $Text) {
        return $false
    }

    $directory = Split-Path -Parent $Path
    if (-not (Test-Path -LiteralPath $directory -PathType Container)) {
        New-Item -ItemType Directory -Path $directory -Force | Out-Null
    }
    $utf8NoBom = New-Object Text.UTF8Encoding($false)
    $temporaryPath = "$Path.$([Guid]::NewGuid().ToString('N')).tmp"
    try {
        [IO.File]::WriteAllText($temporaryPath, $Text, $utf8NoBom)
        Move-Item -LiteralPath $temporaryPath -Destination $Path -Force
    }
    finally {
        if (Test-Path -LiteralPath $temporaryPath -PathType Leaf) {
            Remove-Item -LiteralPath $temporaryPath -Force
        }
    }
    return $true
}

function Add-Gap {
    param([Parameter(Mandatory = $true)][string]$Code)

    if (-not $script:GapCounts.ContainsKey($Code)) {
        $script:GapCounts[$Code] = 0
    }
    $script:GapCounts[$Code]++
}

function Get-PortableExternalPath {
    param([Parameter(Mandatory = $true)][string]$Path)

    $normalized = $Path.Replace("\", "/")
    $marker = "/.nuget/packages/"
    $index = $normalized.IndexOf($marker, [StringComparison]::OrdinalIgnoreCase)
    if ($index -ge 0) {
        return "~/.nuget/packages/" + $normalized.Substring($index + $marker.Length)
    }

    return $null
}

function New-FileReference {
    param(
        [AllowNull()][AllowEmptyString()][string]$Path,
        [AllowNull()][AllowEmptyString()][string]$MissingReason = $null,
        [AllowNull()][AllowEmptyString()][string]$DisplayPath = $null,
        [AllowNull()][AllowEmptyString()][string]$CanonicalText = $null
    )

    $exists = -not [String]::IsNullOrWhiteSpace($Path) -and (Test-Path -LiteralPath $Path -PathType Leaf)
    $portablePath = $null
    if (-not [String]::IsNullOrWhiteSpace($Path)) {
        $portablePath = ConvertTo-RepositoryRelativePath -Path $Path
        if ($null -eq $portablePath) {
            $portablePath = if (-not [String]::IsNullOrWhiteSpace($DisplayPath)) {
                $DisplayPath.Replace("\", "/")
            }
            else {
                Get-PortableExternalPath -Path $Path
            }
            if ([String]::IsNullOrWhiteSpace($portablePath)) {
                $portablePath = "external/" + [IO.Path]::GetFileName($Path)
            }
        }
    }

    $reason = $null
    if (-not $exists) {
        $reason = if (-not [String]::IsNullOrWhiteSpace($MissingReason)) {
            $MissingReason
        }
        elseif ($null -eq $Path) {
            "path-not-provided"
        }
        else {
            "file-not-found"
        }
    }

    return [ordered]@{
        path = $portablePath
        sha256 = if ($exists) { Get-FileSha256 -Path $Path } else { $null }
        canonicalSha256 = if ($exists -and $null -ne $CanonicalText) { Get-TextSha256 -Text $CanonicalText } else { $null }
        available = $exists
        reason = $reason
    }
}

function Get-YamlScalar {
    param([AllowEmptyString()][string]$Value)

    if ($null -eq $Value) {
        return ""
    }

    $value = $Value.Trim()
    if ($value -eq "" -or $value -eq "~" -or $value -ieq "null") {
        return ""
    }
    if ($value.Length -ge 2 -and $value.StartsWith('"') -and $value.EndsWith('"')) {
        return $value.Substring(1, $value.Length - 2).Replace('\"', '"').Replace("\\", "\")
    }
    if ($value.Length -ge 2 -and $value.StartsWith("'") -and $value.EndsWith("'")) {
        return $value.Substring(1, $value.Length - 2).Replace("''", "'")
    }

    return ([Regex]::Replace($value, "\s+#.*$", "")).Trim()
}

function Get-FrontMatterParts {
    param([Parameter(Mandatory = $true)][string]$Text)

    $normalized = Normalize-Text $Text
    $match = [Regex]::Match(
        $normalized,
        "\A---\n(?<front>.*?)\n---(?:\n|\z)",
        [Text.RegularExpressions.RegexOptions]::Singleline
    )
    if (-not $match.Success) {
        return [PSCustomObject]@{
            FrontMatter = ""
            Body = $normalized
        }
    }

    return [PSCustomObject]@{
        FrontMatter = $match.Groups["front"].Value
        Body = $normalized.Substring($match.Length)
    }
}

function Get-FrontMatterValue {
    param(
        [AllowEmptyString()][string]$FrontMatter,
        [Parameter(Mandatory = $true)][string]$Name
    )

    $match = [Regex]::Match($FrontMatter, "(?im)^\s*" + [Regex]::Escape($Name) + "\s*:\s*(?<value>.*)$")
    if (-not $match.Success) {
        return ""
    }

    return Get-YamlScalar $match.Groups["value"].Value
}

function Get-GitValue {
    param(
        [Parameter(Mandatory = $true)][string[]]$Arguments
    )

    try {
        $result = & git -C $script:Root @Arguments 2>$null
        if ($LASTEXITCODE -eq 0) {
            $value = (($result -join "`n").Trim())
            if ($value -ne "") {
                return $value
            }
        }
    }
    catch {
        return $null
    }

    return $null
}

function Get-GenerationInfo {
    param([AllowNull()][string]$RequestedDate)

    if (-not [String]::IsNullOrWhiteSpace($RequestedDate)) {
        $parsed = [DateTime]::MinValue
        if (-not [DateTime]::TryParseExact(
                $RequestedDate,
                "yyyy-MM-dd",
                [Globalization.CultureInfo]::InvariantCulture,
                [Globalization.DateTimeStyles]::None,
                [ref]$parsed)) {
            throw "GenerationDate '$RequestedDate' must use YYYY-MM-DD."
        }
        return [PSCustomObject]@{
            Date = $parsed.ToString("yyyy-MM-dd", [Globalization.CultureInfo]::InvariantCulture)
            Source = "argument"
        }
    }

    if (-not [String]::IsNullOrWhiteSpace($env:SOURCE_DATE_EPOCH)) {
        $epoch = [Int64]0
        if ([Int64]::TryParse($env:SOURCE_DATE_EPOCH, [Globalization.NumberStyles]::Integer, [Globalization.CultureInfo]::InvariantCulture, [ref]$epoch)) {
            $date = [DateTimeOffset]::new(1970, 1, 1, 0, 0, 0, [TimeSpan]::Zero).AddSeconds($epoch).UtcDateTime
            return [PSCustomObject]@{
                Date = $date.ToString("yyyy-MM-dd", [Globalization.CultureInfo]::InvariantCulture)
                Source = "source_date_epoch"
            }
        }
        Add-Gap "generation-date-invalid-source-date-epoch"
    }

    $commitDate = Get-GitValue -Arguments @("show", "-s", "--format=%cI", "HEAD")
    $commitDateValue = [DateTimeOffset]::MinValue
    if (-not [String]::IsNullOrWhiteSpace($commitDate) -and
        [DateTimeOffset]::TryParse($commitDate, [Globalization.CultureInfo]::InvariantCulture, [Globalization.DateTimeStyles]::RoundtripKind, [ref]$commitDateValue)) {
        return [PSCustomObject]@{
            Date = $commitDateValue.UtcDateTime.ToString("yyyy-MM-dd", [Globalization.CultureInfo]::InvariantCulture)
            Source = "git_commit"
        }
    }

    Add-Gap "generation-date-unavailable"
    return [PSCustomObject]@{
        Date = "unknown"
        Source = "unknown"
    }
}

function ConvertTo-GlobRegex {
    param([Parameter(Mandatory = $true)][string]$Pattern)

    $escaped = [Regex]::Escape($Pattern.Replace("\", "/"))
    $escaped = $escaped.Replace("\*\*", ".*").Replace("\*", "[^/]*").Replace("\?", ".")
    return "^" + $escaped + "$"
}

function Resolve-Pattern {
    param([Parameter(Mandatory = $true)][string]$Pattern)

    $normalized = $Pattern.Replace("\", "/").TrimStart("/")
    $wildcardIndex = $normalized.IndexOfAny([char[]]@("*", "?"))
    if ($wildcardIndex -lt 0) {
        $candidate = Join-Path $script:Root $normalized.Replace("/", "\")
        if (Test-Path -LiteralPath $candidate -PathType Leaf) {
            return @((Get-Item -LiteralPath $candidate))
        }
        Add-Gap ("configured-input-missing:" + $normalized)
        return @()
    }

    $prefix = $normalized.Substring(0, $wildcardIndex)
    $separatorIndex = $prefix.LastIndexOf("/")
    $searchRelative = if ($separatorIndex -ge 0) { $prefix.Substring(0, $separatorIndex) } else { "" }
    $searchRoot = Join-Path $script:Root $searchRelative.Replace("/", "\")
    if (-not (Test-Path -LiteralPath $searchRoot -PathType Container)) {
        Add-Gap ("configured-input-root-missing:" + $searchRelative)
        return @()
    }

    $regex = [Regex]::new((ConvertTo-GlobRegex $normalized), [Text.RegularExpressions.RegexOptions]::IgnoreCase)
    return @(
        Get-ChildItem -LiteralPath $searchRoot -Recurse -File |
            Where-Object {
                $relative = ConvertTo-RepositoryRelativePath -Path $_.FullName
                $regex.IsMatch($relative)
            } |
            Sort-Object FullName
    )
}

function Resolve-ConfiguredMetadataInputs {
    param([Parameter(Mandatory = $true)]$Config)

    $files = New-Object "System.Collections.Generic.List[object]"
    foreach ($metadata in @($Config.metadata)) {
        foreach ($source in @($metadata.src)) {
            $patterns = @($source.files)
            $excludes = @($source.exclude)
            $excludeRegexes = @(
                foreach ($exclude in $excludes) {
                    [Regex]::new((ConvertTo-GlobRegex ([string]$exclude)), [Text.RegularExpressions.RegexOptions]::IgnoreCase)
                }
            )

            foreach ($pattern in $patterns) {
                foreach ($file in @(Resolve-Pattern -Pattern ([string]$pattern))) {
                    $relative = ConvertTo-RepositoryRelativePath -Path $file.FullName
                    $excluded = $false
                    foreach ($excludeRegex in $excludeRegexes) {
                        if ($excludeRegex.IsMatch($relative)) {
                            $excluded = $true
                            break
                        }
                    }
                    if (-not $excluded) {
                        $files.Add($file)
                    }
                }
            }
        }
    }

    return @($files | Sort-Object FullName -Unique)
}

function New-EmptyFacts {
    return [ordered]@{
        required = @()
        defaults = @()
        ranges = @()
        enums = @()
        structural = @()
        introduced = @()
        deprecated = @()
        removed = @()
    }
}

function Add-Constraint {
    param(
        [Parameter(Mandatory = $true)]$Facts,
        [Parameter(Mandatory = $true)][ValidateSet("required", "defaults", "ranges", "enums", "structural")][string]$Category,
        [Parameter(Mandatory = $true)][string]$Target,
        [AllowNull()]$Value,
        [AllowNull()][Nullable[int]]$SourceLine = $null
    )

    $record = [ordered]@{
        target = $Target
        value = $Value
        sourceLine = $SourceLine
    }
    $key = (($record | ConvertTo-Json -Compress -Depth 4))
    foreach ($existing in @($Facts[$Category])) {
        if ((($existing | ConvertTo-Json -Compress -Depth 4)) -eq $key) {
            return
        }
    }
    $Facts[$Category] += ,$record
}

function Add-LifecycleConstraint {
    param(
        [Parameter(Mandatory = $true)]$Facts,
        [Parameter(Mandatory = $true)][ValidateSet("introduced", "deprecated", "removed")][string]$Category,
        [AllowNull()][string]$Version = $null,
        [AllowNull()][Nullable[int]]$SourceLine = $null
    )

    $normalizedVersion = if ([String]::IsNullOrWhiteSpace($Version)) { $null } else { $Version }
    $record = [ordered]@{
        kind = $Category
        version = $normalizedVersion
        sourceLine = $SourceLine
    }
    $key = (($record | ConvertTo-Json -Compress -Depth 4))
    foreach ($existing in @($Facts[$Category])) {
        if ((($existing | ConvertTo-Json -Compress -Depth 4)) -eq $key) {
            return
        }
    }
    $Facts[$Category] += ,$record
}

function Add-LifecycleFactsFromLine {
    param(
        [Parameter(Mandatory = $true)]$Facts,
        [Parameter(Mandatory = $true)][AllowEmptyString()][string]$Text,
        [AllowNull()][Nullable[int]]$SourceLine = $null
    )

    $patterns = @(
        @{ Category = "introduced"; Pattern = "(?i)\bintroduced\b[^0-9\r\n]{0,50}(?<version>\d+(?:\.\d+){1,3})" },
        @{ Category = "introduced"; Pattern = "(?i)\bavailable\s+in\b[^0-9\r\n]{0,30}(?<version>\d+(?:\.\d+){1,3})" },
        @{ Category = "introduced"; Pattern = "(?i)\bsince\b[^0-9\r\n]{0,30}(?<version>\d+(?:\.\d+){1,3})" },
        @{ Category = "deprecated"; Pattern = "(?i)\bdeprecated\b[^0-9\r\n]{0,50}(?<version>\d+(?:\.\d+){1,3})" },
        @{ Category = "removed"; Pattern = "(?i)\bremoved\b[^0-9\r\n]{0,50}(?<version>\d+(?:\.\d+){1,3})" }
    )
    $matchedCategories = @{}
    foreach ($entry in $patterns) {
        $match = [Regex]::Match($Text, $entry.Pattern)
        if ($match.Success) {
            $matchedCategories[$entry.Category] = $true
            Add-LifecycleConstraint -Facts $Facts -Category $entry.Category -Version $match.Groups["version"].Value -SourceLine $SourceLine
        }
    }

    if ($Text -match "(?i)\bdeprecated\b" -and -not $matchedCategories.ContainsKey("deprecated")) {
        Add-LifecycleConstraint -Facts $Facts -Category "deprecated" -Version $null -SourceLine $SourceLine
    }
    if ($Text -match "(?i)\bremoved\b" -and -not $matchedCategories.ContainsKey("removed")) {
        Add-LifecycleConstraint -Facts $Facts -Category "removed" -Version $null -SourceLine $SourceLine
    }
}

function Get-PlainMarkdownCell {
    param([AllowEmptyString()][string]$Cell)

    if ($null -eq $Cell) {
        return ""
    }

    $value = $Cell.Trim()
    $value = [Regex]::Replace($value, "\[([^\]]+)\]\([^)]+\)", '$1')
    $value = $value.Replace([string][char]96, "").Replace("&nbsp;", " ")
    $value = [Regex]::Replace($value, "<[^>]+>", "")
    return [Regex]::Replace($value, "\s+", " ").Trim()
}

function Split-MarkdownTableRow {
    param([Parameter(Mandatory = $true)][AllowEmptyString()][string]$Line)

    $value = $Line.Trim()
    if ($value.StartsWith("|")) {
        $value = $value.Substring(1)
    }
    if ($value.EndsWith("|")) {
        $value = $value.Substring(0, $value.Length - 1)
    }
    return @($value.Split("|") | ForEach-Object { Get-PlainMarkdownCell $_ })
}

function Test-MarkdownSeparator {
    param([Parameter(Mandatory = $true)][AllowEmptyString()][string]$Line)

    $cells = @(Split-MarkdownTableRow -Line $Line)
    if ($cells.Count -eq 0) {
        return $false
    }
    foreach ($cell in $cells) {
        if ($cell -notmatch "^:?-{3,}:?$") {
            return $false
        }
    }
    return $true
}

function Get-MarkdownSections {
    param([Parameter(Mandatory = $true)][string]$Body)

    $normalizedBody = Normalize-Text $Body
    $matches = @([Regex]::Matches((Normalize-Text $Body), "(?m)^(?<level>#{1,6})\s+(?<title>.+?)\s*$"))
    $sections = New-Object "System.Collections.Generic.List[object]"
    for ($index = 0; $index -lt $matches.Count; $index++) {
        $match = $matches[$index]
        $startOffset = $match.Index + $match.Length
        $endOffset = if ($index + 1 -lt $matches.Count) { $matches[$index + 1].Index } else { $normalizedBody.Length }
        $sectionText = $normalizedBody.Substring($startOffset, $endOffset - $startOffset).Trim()
        $sections.Add([ordered]@{
            level = $match.Groups["level"].Value.Length
            name = (Get-PlainMarkdownCell $match.Groups["title"].Value)
            text = $sectionText
        })
    }
    return @($sections.ToArray())
}

function Get-ManualInfo {
    param([Parameter(Mandatory = $true)][string]$Body)

    $names = New-Object "System.Collections.Generic.List[string]"
    $remarks = 0
    $examples = 0
    foreach ($section in @(Get-MarkdownSections -Body $Body)) {
        $name = [string]$section.name
        if ($name -match "(?i)\bremarks?\b|\bnotes?\b") {
            $remarks++
        }
        if ($name -match "(?i)\bexamples?\b") {
            $examples++
        }
        if ($name -match "(?i)\bremarks?\b|\bnotes?\b|\bexamples?\b") {
            if (-not $names.Contains($name)) {
                $names.Add($name)
            }
        }
    }

    return [ordered]@{
        remarksCount = $remarks
        examplesCount = $examples
        overwriteCount = 0
        sectionNames = @($names.ToArray() | Sort-Object)
    }
}

function Get-MarkdownFacts {
    param([Parameter(Mandatory = $true)][string]$Body)

    $facts = New-EmptyFacts
    $lines = @( (Normalize-Text $Body) -split "`n")
    $section = ""
    $generatedSections = New-Object "System.Collections.Generic.List[string]"

    for ($index = 0; $index -lt $lines.Count; $index++) {
        $line = $lines[$index]
        $heading = [Regex]::Match($line, "^\s*#{1,6}\s+(?<title>.+?)\s*$")
        if ($heading.Success) {
            $section = Get-PlainMarkdownCell $heading.Groups["title"].Value
            continue
        }
        if ($index + 1 -ge $lines.Count -or
            $line.Trim() -notmatch "^\|.*\|$" -or
            -not (Test-MarkdownSeparator -Line $lines[$index + 1])) {
            continue
        }

        $headers = @(Split-MarkdownTableRow -Line $line)
        $headerKeys = @($headers | ForEach-Object { $_.ToLowerInvariant() })
        if ($section -ne "" -and -not $generatedSections.Contains($section)) {
            $generatedSections.Add($section)
        }
        $rowIndex = $index + 2
        while ($rowIndex -lt $lines.Count -and $lines[$rowIndex].Trim() -match "^\|.*\|$") {
            $cells = @(Split-MarkdownTableRow -Line $lines[$rowIndex])
            if ($cells.Count -gt 0) {
                $target = $cells[0]
                $requiredIndex = -1
                $defaultIndex = -1
                $rangeIndex = -1
                $enumIndex = -1
                for ($column = 0; $column -lt $headerKeys.Count; $column++) {
                    if ($headerKeys[$column] -match "(?i)required|mandatory") { $requiredIndex = $column }
                    if ($headerKeys[$column] -match "(?i)default") { $defaultIndex = $column }
                    if ($headerKeys[$column] -match "(?i)range|occurrence|cardinality") { $rangeIndex = $column }
                    if ($headerKeys[$column] -match "(?i)enum|allowed|value") { $enumIndex = $column }
                }
                if ($requiredIndex -ge 0 -and $requiredIndex -lt $cells.Count -and $cells[$requiredIndex] -ne "") {
                    Add-Constraint -Facts $facts -Category "required" -Target $target -Value $cells[$requiredIndex] -SourceLine ($rowIndex + 1)
                }
                if ($defaultIndex -ge 0 -and $defaultIndex -lt $cells.Count -and $cells[$defaultIndex] -ne "") {
                    Add-Constraint -Facts $facts -Category "defaults" -Target $target -Value $cells[$defaultIndex] -SourceLine ($rowIndex + 1)
                }
                if ($rangeIndex -ge 0 -and $rangeIndex -lt $cells.Count -and $cells[$rangeIndex] -ne "") {
                    Add-Constraint -Facts $facts -Category "ranges" -Target $target -Value $cells[$rangeIndex] -SourceLine ($rowIndex + 1)
                }
                if ($section -notmatch "(?i)\blifecycle\b" -and $enumIndex -ge 0 -and $enumIndex -lt $cells.Count -and $cells[$enumIndex] -ne "") {
                    Add-Constraint -Facts $facts -Category "enums" -Target $target -Value $cells[$enumIndex] -SourceLine ($rowIndex + 1)
                }
                if ($section -match "(?i)\bconstraints?\b") {
                    $typeIndex = -1
                    $selectorIndex = -1
                    for ($column = 0; $column -lt $headerKeys.Count; $column++) {
                        if ($headerKeys[$column] -match "(?i)^type$|constraint") { $typeIndex = $column }
                        if ($headerKeys[$column] -match "(?i)selector|path|target") { $selectorIndex = $column }
                    }
                    $structuralTarget = if ($selectorIndex -ge 0 -and $selectorIndex -lt $cells.Count -and $cells[$selectorIndex] -ne "") {
                        $cells[$selectorIndex]
                    }
                    else {
                        $target
                    }
                    $structuralValue = if ($typeIndex -ge 0 -and $typeIndex -lt $cells.Count -and $cells[$typeIndex] -ne "") {
                        $cells[$typeIndex]
                    }
                    else {
                        $null
                    }
                    Add-Constraint -Facts $facts -Category "structural" -Target $structuralTarget -Value $structuralValue -SourceLine ($rowIndex + 1)
                }
                if ($section -notmatch "(?i)\bremarks?\b|\bnotes?\b|\bexamples?\b") {
                    Add-LifecycleFactsFromLine -Facts $facts -Text ($cells -join " ") -SourceLine ($rowIndex + 1)
                }
            }
            $rowIndex++
        }
        $index = $rowIndex - 1
    }

    return [PSCustomObject]@{
        Facts = $facts
        GeneratedSections = @($generatedSections.ToArray() | Sort-Object)
    }
}

function Get-XmlText {
    param([AllowNull()]$Node)

    if ($null -eq $Node) {
        return ""
    }

    return [Regex]::Replace(([string]$Node.InnerText), "\s+", " ").Trim()
}

function Add-TextConstraintFacts {
    param(
        [Parameter(Mandatory = $true)]$Facts,
        [Parameter(Mandatory = $true)][string]$Target,
        [Parameter(Mandatory = $true)][AllowEmptyString()][string]$Text
    )

    if ($Text -match "(?i)\b(required|must be provided|cannot be null|may not be null)\b") {
        Add-Constraint -Facts $Facts -Category "required" -Target $Target -Value $true
    }
    $defaultMatch = [Regex]::Match($Text, "(?i)\bdefault(?:\s+value|\s+is|s\s+to)?\s*(?:is|:|=)?\s*(?<value>[^.;\r\n]{1,120})")
    if ($defaultMatch.Success) {
        Add-Constraint -Facts $Facts -Category "defaults" -Target $Target -Value $defaultMatch.Groups["value"].Value.Trim()
    }
    $rangeMatch = [Regex]::Match($Text, "(?i)\b(?:range|between)\b[^.;\r\n]{0,120}")
    if ($rangeMatch.Success) {
        Add-Constraint -Facts $Facts -Category "ranges" -Target $Target -Value ([Regex]::Replace($rangeMatch.Value.Trim(), "\s+", " "))
    }
    $enumMatch = [Regex]::Match($Text, "(?i)\b(?:one of|values?\s+(?:are|include)|must be one of)\b[^.;\r\n]{0,120}")
    if ($enumMatch.Success) {
        Add-Constraint -Facts $Facts -Category "enums" -Target $Target -Value ([Regex]::Replace($enumMatch.Value.Trim(), "\s+", " "))
    }
    Add-LifecycleFactsFromLine -Facts $Facts -Text $Text
}

function Get-XmlMemberFacts {
    param(
        [Parameter(Mandatory = $true)]$XmlMembers,
        [Parameter(Mandatory = $true)][string]$CommentId
    )

    if ($null -eq $XmlMembers -or -not $XmlMembers.ContainsKey($CommentId)) {
        return $null
    }

    $member = $XmlMembers[$CommentId]
    $facts = New-EmptyFacts
    $remarksCount = 0
    $examplesCount = 0
    $summary = Get-XmlText $member.SelectSingleNode("summary")
    Add-TextConstraintFacts -Facts $facts -Target $CommentId -Text $summary
    foreach ($param in @($member.SelectNodes("param"))) {
        $target = $CommentId + ":param:" + [string]$param.GetAttribute("name")
        Add-TextConstraintFacts -Facts $facts -Target $target -Text (Get-XmlText $param)
    }
    foreach ($returns in @($member.SelectNodes("returns"))) {
        Add-TextConstraintFacts -Facts $facts -Target ($CommentId + ":returns") -Text (Get-XmlText $returns)
    }
    foreach ($exception in @($member.SelectNodes("exception"))) {
        Add-TextConstraintFacts -Facts $facts -Target ($CommentId + ":exception:" + [string]$exception.GetAttribute("cref")) -Text (Get-XmlText $exception)
    }
    foreach ($remarks in @($member.SelectNodes("remarks"))) {
        if ((Get-XmlText $remarks) -ne "") { $remarksCount++ }
    }
    foreach ($example in @($member.SelectNodes("example"))) {
        if ((Get-XmlText $example) -ne "") { $examplesCount++ }
    }

    return [PSCustomObject]@{
        Facts = $facts
        Manual = [ordered]@{
            remarksCount = $remarksCount
            examplesCount = $examplesCount
            overwriteCount = 0
            sectionNames = @()
        }
    }
}

function Get-ApiYamlFacts {
    param([Parameter(Mandatory = $true)][AllowEmptyString()][string]$Text)

    $lines = @( (Normalize-Text $Text) -split "`n")
    $referenceIndex = $lines.Count
    for ($index = 0; $index -lt $lines.Count; $index++) {
        if ($lines[$index] -match "^references:\s*$") {
            $referenceIndex = $index
            break
        }
    }
    $itemLines = @($lines[0..([Math]::Max(0, $referenceIndex - 1))])
    $itemText = $itemLines -join "`n"
    $uidValues = New-Object "System.Collections.Generic.List[string]"
    foreach ($match in [Regex]::Matches($itemText, "(?m)^- uid:\s*(?<value>.+?)\s*$")) {
        $value = Get-YamlScalar $match.Groups["value"].Value
        if ($value -ne "" -and -not $uidValues.Contains($value)) {
            $uidValues.Add($value)
        }
    }
    $commentValues = New-Object "System.Collections.Generic.List[string]"
    foreach ($match in [Regex]::Matches($itemText, "(?m)^\s{2}commentId:\s*(?<value>.+?)\s*$")) {
        $value = Get-YamlScalar $match.Groups["value"].Value
        if ($value -ne "" -and -not $commentValues.Contains($value)) {
            $commentValues.Add($value)
        }
    }
    $sourceMatch = [Regex]::Match($itemText, "(?m)^\s{4}path:\s*(?<value>.+?)\s*$")
    $typeMatch = [Regex]::Match($itemText, "(?m)^\s{2}type:\s*(?<value>.+?)\s*$")
    $assemblyNames = New-Object "System.Collections.Generic.List[string]"
    for ($index = 0; $index -lt $itemLines.Count; $index++) {
        if ($itemLines[$index] -match "^\s{2}assemblies:\s*$") {
            for ($next = $index + 1; $next -lt $itemLines.Count; $next++) {
                if ($itemLines[$next] -match "^\s{2}-\s*(?<value>.+?)\s*$") {
                    $assembly = Get-YamlScalar $Matches["value"]
                    if ($assembly -ne "" -and -not $assemblyNames.Contains($assembly)) {
                        $assemblyNames.Add($assembly)
                    }
                }
                else {
                    break
                }
            }
        }
    }

    $remarksCount = @([Regex]::Matches(($itemLines -join "`n"), "(?m)^\s{2}remarks:\s*(?<value>.*)$") | Where-Object { (Get-YamlScalar $_.Groups["value"].Value) -ne "" }).Count
    $examples = @([Regex]::Matches(($itemLines -join "`n"), "(?m)^\s{2}example:\s*(?<value>.*)$") | Where-Object { (Get-YamlScalar $_.Groups["value"].Value) -ne "" -and (Get-YamlScalar $_.Groups["value"].Value) -ne "[]" }).Count
    $memberCount = @([Regex]::Matches(($itemLines -join "`n"), "(?m)^- uid:\s*")).Count
    $parameterCount = @([Regex]::Matches(($itemLines -join "`n"), "(?m)^\s{4}- id:\s*")).Count
    $facts = New-EmptyFacts

    return [PSCustomObject]@{
        Uid = if ($uidValues.Count -gt 0) { $uidValues[0] } else { $null }
        Uids = @($uidValues.ToArray())
        CommentId = if ($commentValues.Count -gt 0) { $commentValues[0] } else { $null }
        CommentIds = @($commentValues.ToArray())
        SourcePath = if ($sourceMatch.Success) { Get-YamlScalar $sourceMatch.Groups["value"].Value } else { $null }
        Type = if ($typeMatch.Success) { Get-YamlScalar $typeMatch.Groups["value"].Value } else { $null }
        AssemblyNames = @($assemblyNames.ToArray() | Sort-Object)
        MemberCount = $memberCount
        ParameterCount = $parameterCount
        Facts = $facts
        Manual = [ordered]@{
            remarksCount = $remarksCount
            examplesCount = $examples
            overwriteCount = 0
            sectionNames = @()
        }
    }
}

function Get-ProjectProperty {
    param(
        [Parameter(Mandatory = $true)]$ProjectXml,
        [Parameter(Mandatory = $true)][string]$Name
    )

    $node = $ProjectXml.SelectSingleNode("/*[local-name()='Project']/*[local-name()='PropertyGroup']/*[local-name()='$Name']")
    if ($null -eq $node) {
        return ""
    }
    return ([string]$node.InnerText).Trim()
}

function Get-NuGetPackageRoot {
    if (-not [String]::IsNullOrWhiteSpace($env:NUGET_PACKAGES)) {
        return [IO.Path]::GetFullPath($env:NUGET_PACKAGES)
    }
    return Join-Path $env:USERPROFILE ".nuget\packages"
}

function Get-PackageMetadata {
    param(
        [Parameter(Mandatory = $true)][string]$PackageId,
        [Parameter(Mandatory = $true)][string]$Version
    )

    $packageRoot = Join-Path (Get-NuGetPackageRoot) ($PackageId.ToLowerInvariant() + "\" + $Version)
    if (-not (Test-Path -LiteralPath $packageRoot -PathType Container)) {
        return [PSCustomObject]@{
            Path = Join-Path $packageRoot ($PackageId + "." + $Version + ".nupkg")
            Root = $packageRoot
            License = $null
            Attribution = $null
        }
    }
    $packageFile = Get-ChildItem -LiteralPath $packageRoot -File -Filter "*.nupkg" | Select-Object -First 1
    $license = $null
    $attribution = $null
    $nuspec = Get-ChildItem -LiteralPath $packageRoot -File -Filter "*.nuspec" | Select-Object -First 1
    if ($null -ne $nuspec) {
        try {
            [xml]$nuspecXml = [IO.File]::ReadAllText($nuspec.FullName)
            $licenseNode = $nuspecXml.SelectSingleNode("//*[local-name()='license']")
            if ($null -ne $licenseNode) {
                $license = if ($licenseNode.type -eq "expression") { [string]$licenseNode.InnerText } else { [string]$licenseNode.InnerText }
            }
            if ([String]::IsNullOrWhiteSpace($license)) {
                $licenseUrlNode = $nuspecXml.SelectSingleNode("//*[local-name()='licenseUrl']")
                if ($null -ne $licenseUrlNode) { $license = ([string]$licenseUrlNode.InnerText).Trim() }
            }
            $authorsNode = $nuspecXml.SelectSingleNode("//*[local-name()='authors']")
            if ($null -ne $authorsNode) { $attribution = ([string]$authorsNode.InnerText).Trim() }
        }
        catch {
            Add-Gap ("package-metadata-invalid:" + $PackageId + "@" + $Version)
        }
    }

    return [PSCustomObject]@{
        Path = if ($null -ne $packageFile) { $packageFile.FullName } else { Join-Path $packageRoot ($PackageId + "." + $Version + ".nupkg") }
        Root = $packageRoot
        License = $license
        Attribution = $attribution
    }
}

function Index-PackageAssemblies {
    param(
        [Parameter(Mandatory = $true)][string]$PackageArtifactId,
        [Parameter(Mandatory = $true)][string]$PackageRoot
    )

    if (-not (Test-Path -LiteralPath $PackageRoot -PathType Container)) {
        return
    }
    foreach ($assemblyFile in @(Get-ChildItem -LiteralPath $PackageRoot -Recurse -File -Filter "*.dll" | Sort-Object FullName)) {
        $assemblyName = [IO.Path]::GetFileNameWithoutExtension($assemblyFile.Name)
        try {
            $assemblyNameValue = [Reflection.AssemblyName]::GetAssemblyName($assemblyFile.FullName).Name
            if (-not [String]::IsNullOrWhiteSpace($assemblyNameValue)) {
                $assemblyName = $assemblyNameValue
            }
        }
        catch {
            Add-Gap ("package-assembly-identity-unavailable:" + $PackageArtifactId)
        }
        if (-not $script:PackageArtifactsByAssemblyName.ContainsKey($assemblyName)) {
            $script:PackageArtifactsByAssemblyName[$assemblyName] = New-Object "System.Collections.Generic.List[string]"
        }
        if (-not $script:PackageArtifactsByAssemblyName[$assemblyName].Contains($PackageArtifactId)) {
            $script:PackageArtifactsByAssemblyName[$assemblyName].Add($PackageArtifactId)
        }
    }
}

function Add-Artifact {
    param(
        [Parameter(Mandatory = $true)][ValidateSet("project", "source", "assembly", "xml-documentation", "package", "schema", "overwrite")][string]$Kind,
        [Parameter(Mandatory = $true)][string]$Identity,
        [AllowNull()][AllowEmptyString()][string]$Version = $null,
        [AllowNull()][AllowEmptyString()][string]$Path = $null,
        [ValidateSet("repository", "build-output", "nuget-cache", "documentation-identity", "external")][string]$SourceType = "repository",
        [AllowNull()][AllowEmptyString()][string]$Reason = $null,
        [AllowNull()][AllowEmptyString()][string]$AssemblyFullName = $null,
        [AllowNull()][AllowEmptyString()][string]$AssemblyName = $null,
        [AllowNull()][AllowEmptyString()][string]$TargetFramework = $null,
        [AllowNull()][AllowEmptyString()][string]$SourceProject = $null,
        [AllowNull()][Nullable[bool]]$Direct = $null,
        [AllowNull()][AllowEmptyString()][string]$License = $null,
        [AllowNull()][AllowEmptyString()][string]$Attribution = $null,
        [AllowNull()][AllowEmptyString()][string]$DisplayPath = $null
    )

    $normalizedVersion = if ([String]::IsNullOrWhiteSpace($Version)) { $null } else { $Version }
    $normalizedAssemblyFullName = if ([String]::IsNullOrWhiteSpace($AssemblyFullName)) { $null } else { $AssemblyFullName }
    $normalizedAssemblyName = if ([String]::IsNullOrWhiteSpace($AssemblyName)) { $null } else { $AssemblyName }
    $normalizedTargetFramework = if ([String]::IsNullOrWhiteSpace($TargetFramework)) { $null } else { $TargetFramework }
    $normalizedSourceProject = if ([String]::IsNullOrWhiteSpace($SourceProject)) { $null } else { $SourceProject }
    $normalizedLicense = if ([String]::IsNullOrWhiteSpace($License)) { $null } else { $License }
    $normalizedAttribution = if ([String]::IsNullOrWhiteSpace($Attribution)) { $null } else { $Attribution }
    $pathKey = if ([String]::IsNullOrWhiteSpace($Path)) { "" } else { [IO.Path]::GetFullPath($Path).ToLowerInvariant() }
    $key = "$Kind|$Identity|$normalizedVersion|$pathKey"
    if ($script:ArtifactKeys.ContainsKey($key)) {
        return $script:ArtifactKeys[$key]
    }

    $idPath = if ($pathKey -eq "") {
        "missing"
    }
    else {
        $portableIdPath = ConvertTo-RepositoryRelativePath -Path $Path
        if ($null -eq $portableIdPath) {
            $portableIdPath = Get-PortableExternalPath -Path $Path
        }
        if ([String]::IsNullOrWhiteSpace($portableIdPath)) {
            $portableIdPath = [IO.Path]::GetFileName($Path)
        }
        $portableIdPath
    }
    $id = ($Kind + ":" + $Identity + ":" + $idPath).Replace("\", "/")
    $available = -not [String]::IsNullOrWhiteSpace($Path) -and (Test-Path -LiteralPath $Path -PathType Leaf)
    $fileReason = if ($available) { $null } elseif ($null -ne $Reason) { $Reason } else { "file-not-found" }
    $artifact = [ordered]@{
        id = $id
        kind = $Kind
        identity = $Identity
        version = $normalizedVersion
        file = New-FileReference -Path $Path -MissingReason $fileReason -DisplayPath $DisplayPath
        available = $available
        sourceType = $SourceType
        assemblyFullName = $normalizedAssemblyFullName
        assemblyName = $normalizedAssemblyName
        targetFramework = $normalizedTargetFramework
        sourceProject = $normalizedSourceProject
        direct = $Direct
        license = $normalizedLicense
        attribution = $normalizedAttribution
        reason = $fileReason
    }
    $script:ArtifactKeys[$key] = $id
    $script:ArtifactById[$id] = $artifact
    $script:Artifacts.Add($artifact)
    return $id
}

function Read-XmlDocumentation {
    param(
        [Parameter(Mandatory = $true)][string]$Path,
        [Parameter(Mandatory = $true)][string]$ArtifactId
    )

    try {
        [xml]$document = [IO.File]::ReadAllText($Path)
        $assemblyNameNode = $document.SelectSingleNode("//*[local-name()='assembly']/*[local-name()='name']")
        $assemblyName = if ($null -ne $assemblyNameNode) { ([string]$assemblyNameNode.InnerText).Trim() } else { [IO.Path]::GetFileNameWithoutExtension($Path) }
        $members = @{}
        foreach ($member in @($document.SelectNodes("//*[local-name()='members']/*[local-name()='member']"))) {
            $name = [string]$member.GetAttribute("name")
            if (-not [String]::IsNullOrWhiteSpace($name)) {
                $members[$name] = $member
            }
        }
        if (-not $script:XmlDocumentationByAssembly.ContainsKey($assemblyName)) {
            $script:XmlDocumentationByAssembly[$assemblyName] = New-Object "System.Collections.Generic.List[object]"
        }
        $script:XmlDocumentationByAssembly[$assemblyName].Add([PSCustomObject]@{
            ArtifactId = $ArtifactId
            Members = $members
        })
        return $assemblyName
    }
    catch {
        Add-Gap ("xml-documentation-invalid:" + (ConvertTo-RepositoryRelativePath -Path $Path))
        return $null
    }
}

function Add-ProjectArtifacts {
    param([Parameter(Mandatory = $true)][IO.FileInfo]$ProjectFile)

    $projectRelative = ConvertTo-RepositoryRelativePath -Path $ProjectFile.FullName
    $assemblyName = [IO.Path]::GetFileNameWithoutExtension($ProjectFile.Name)
    $targetFramework = $null
    $directPackages = @{}
    try {
        [xml]$projectXml = [IO.File]::ReadAllText($ProjectFile.FullName)
        $projectAssemblyName = Get-ProjectProperty -ProjectXml $projectXml -Name "AssemblyName"
        if ($projectAssemblyName -ne "") { $assemblyName = $projectAssemblyName }
        $targetFramework = Get-ProjectProperty -ProjectXml $projectXml -Name "TargetFramework"
        if ($targetFramework -eq "") { $targetFramework = Get-ProjectProperty -ProjectXml $projectXml -Name "TargetFrameworks" }
        foreach ($reference in @($projectXml.SelectNodes("//*[local-name()='PackageReference']"))) {
            $id = [string]$reference.Include
            if ([String]::IsNullOrWhiteSpace($id)) { continue }
            $version = [string]$reference.Version
            if ([String]::IsNullOrWhiteSpace($version)) {
                $versionNode = $reference.SelectSingleNode("*[local-name()='Version']")
                if ($null -ne $versionNode) { $version = ([string]$versionNode.InnerText).Trim() }
            }
            $directPackages[$id.ToLowerInvariant()] = $version
        }
    }
    catch {
        Add-Gap ("project-invalid:" + $projectRelative)
    }

    $projectId = Add-Artifact -Kind "project" -Identity $assemblyName -Path $ProjectFile.FullName -SourceType "repository" -TargetFramework $targetFramework
    $assetsPath = Join-Path $ProjectFile.DirectoryName "obj\project.assets.json"
    $packageIds = New-Object "System.Collections.Generic.List[string]"
    if (Test-Path -LiteralPath $assetsPath -PathType Leaf) {
        try {
            $assets = Get-Content -LiteralPath $assetsPath -Raw | ConvertFrom-Json
            foreach ($property in @($assets.libraries.PSObject.Properties | Sort-Object Name)) {
                if ($property.Value.type -ne "package") { continue }
                $parts = ([string]$property.Name).Split("/", 2)
                if ($parts.Count -ne 2) { continue }
                $packageId = $parts[0]
                $version = $parts[1]
                $packageMetadata = Get-PackageMetadata -PackageId $packageId -Version $version
                $isDirect = $null
                if ($directPackages.ContainsKey($packageId.ToLowerInvariant())) { $isDirect = $true }
                $packageArtifactId = Add-Artifact `
                    -Kind "package" `
                    -Identity $packageId `
                    -Version $version `
                    -Path $packageMetadata.Path `
                    -SourceType "nuget-cache" `
                    -Reason "package-artifact-not-restored" `
                    -SourceProject $projectRelative `
                    -Direct $isDirect `
                    -License $packageMetadata.License `
                    -Attribution $packageMetadata.Attribution `
                    -DisplayPath ("~/.nuget/packages/" + $packageId.ToLowerInvariant() + "/" + $version + "/" + $packageId + "." + $version + ".nupkg")
                if (-not $packageIds.Contains($packageArtifactId)) { $packageIds.Add($packageArtifactId) }
                if (-not $script:PackageArtifacts.Contains($packageArtifactId)) { $script:PackageArtifacts.Add($packageArtifactId) }
                Index-PackageAssemblies -PackageArtifactId $packageArtifactId -PackageRoot $packageMetadata.Root
            }
        }
        catch {
            Add-Gap ("project-assets-invalid:" + $projectRelative)
        }
    }
    else {
        Add-Gap ("project-assets-not-found:" + $projectRelative)
    }

    $script:ProjectRecords.Add([PSCustomObject]@{
        Id = $projectId
        Path = $ProjectFile.FullName
        RelativePath = $projectRelative
        AssemblyName = $assemblyName
        TargetFramework = $targetFramework
        PackageIds = @($packageIds.ToArray())
    })
}

function Add-AssemblyArtifact {
    param([Parameter(Mandatory = $true)][IO.FileInfo]$AssemblyFile)

    $simpleName = [IO.Path]::GetFileNameWithoutExtension($AssemblyFile.Name)
    $fullName = $null
    $version = $null
    $reason = $null
    try {
        $assemblyName = [Reflection.AssemblyName]::GetAssemblyName($AssemblyFile.FullName)
        $simpleName = $assemblyName.Name
        $fullName = $assemblyName.FullName
        $version = $assemblyName.Version.ToString()
    }
    catch {
        $reason = "assembly-identity-unavailable"
        Add-Gap ("assembly-identity-unavailable:" + (ConvertTo-RepositoryRelativePath -Path $AssemblyFile.FullName))
    }

    $sourceType = if ((ConvertTo-RepositoryRelativePath -Path $AssemblyFile.FullName) -like "assemblies/*") { "repository" } else { "build-output" }
    $sourceProject = $null
    foreach ($project in @($script:ProjectRecords.ToArray())) {
        if ($AssemblyFile.FullName.StartsWith(([IO.Path]::GetDirectoryName($project.Path) + "\"), [StringComparison]::OrdinalIgnoreCase)) {
            $sourceProject = $project.RelativePath
            break
        }
    }
    $artifactId = Add-Artifact `
        -Kind "assembly" `
        -Identity $simpleName `
        -Version $version `
        -Path $AssemblyFile.FullName `
        -SourceType $sourceType `
        -Reason $reason `
        -AssemblyFullName $fullName `
        -AssemblyName $simpleName `
        -SourceProject $sourceProject
    if (-not $script:AssemblyArtifactsByName.ContainsKey($simpleName)) {
        $script:AssemblyArtifactsByName[$simpleName] = New-Object "System.Collections.Generic.List[string]"
    }
    if (-not $script:AssemblyArtifactsByName[$simpleName].Contains($artifactId)) {
        $script:AssemblyArtifactsByName[$simpleName].Add($artifactId)
    }

    $xmlPath = Join-Path $AssemblyFile.DirectoryName ($AssemblyFile.BaseName + ".xml")
    if (Test-Path -LiteralPath $xmlPath -PathType Leaf) {
        $xmlArtifactId = Add-Artifact `
            -Kind "xml-documentation" `
            -Identity $simpleName `
            -Path $xmlPath `
            -SourceType $sourceType `
            -Reason "xml-documentation-not-found" `
            -AssemblyName $simpleName `
            -SourceProject $sourceProject
        $xmlAssemblyName = Read-XmlDocumentation -Path $xmlPath -ArtifactId $xmlArtifactId
        $script:AssemblyDocumentationById[$artifactId] = $xmlArtifactId
        if ($null -ne $xmlAssemblyName -and $xmlAssemblyName -ne $simpleName) {
            Add-Gap ("xml-assembly-name-mismatch:" + $simpleName)
        }
    }
    else {
        Add-Gap ("xml-documentation-not-found:" + $simpleName)
    }
}

function Add-SourceArtifact {
    param([Parameter(Mandatory = $true)][string]$Path)

    if (Test-Path -LiteralPath $Path -PathType Leaf) {
        $relative = ConvertTo-RepositoryRelativePath -Path $Path
        $identity = if ($null -ne $relative) { $relative } else { Get-PortableExternalPath -Path $Path }
        if ([String]::IsNullOrWhiteSpace($identity)) { $identity = [IO.Path]::GetFileName($Path) }
        $sourceType = if ($null -ne $relative) { "repository" } else { "external" }
        return Add-Artifact -Kind "source" -Identity $identity -Path $Path -SourceType $sourceType
    }

    Add-Gap ("api-source-not-found:" + $Path)
    return Add-Artifact -Kind "source" -Identity $Path -Path $null -SourceType "repository" -Reason "source-file-not-found"
}

function Get-XmlFactsForApi {
    param(
        [Parameter(Mandatory = $true)][AllowEmptyCollection()][string[]]$AssemblyNames,
        [Parameter(Mandatory = $true)][AllowEmptyCollection()][string[]]$CommentIds,
        [Parameter(Mandatory = $true)][AllowEmptyCollection()][string[]]$DocumentationArtifactIds
    )

    if ($CommentIds.Count -eq 0 -or $DocumentationArtifactIds.Count -eq 0) {
        return $null
    }
    $aggregateFacts = New-EmptyFacts
    $aggregateManual = [ordered]@{
        remarksCount = 0
        examplesCount = 0
        overwriteCount = 0
        sectionNames = @()
    }
    $found = $false
    foreach ($assemblyName in $AssemblyNames) {
        if (-not $script:XmlDocumentationByAssembly.ContainsKey($assemblyName)) { continue }
        foreach ($documentation in @($script:XmlDocumentationByAssembly[$assemblyName].ToArray())) {
            if ($DocumentationArtifactIds.Count -gt 0 -and -not $DocumentationArtifactIds.Contains($documentation.ArtifactId)) {
                continue
            }
            foreach ($commentId in $CommentIds) {
                $memberFacts = Get-XmlMemberFacts -XmlMembers $documentation.Members -CommentId $commentId
                if ($null -ne $memberFacts) {
                    $found = $true
                    Merge-Facts -Target $aggregateFacts -Source $memberFacts.Facts
                    Merge-ManualInfo -Target $aggregateManual -Source $memberFacts.Manual
                }
            }
        }
    }
    if (-not $found) {
        return $null
    }
    return [PSCustomObject]@{
        Facts = $aggregateFacts
        Manual = $aggregateManual
    }
}

function Merge-Facts {
    param(
        [Parameter(Mandatory = $true)]$Target,
        [AllowNull()]$Source
    )

    if ($null -eq $Source) { return }
    foreach ($category in @("required", "defaults", "ranges", "enums", "structural")) {
        foreach ($record in @($Source[$category])) {
            Add-Constraint -Facts $Target -Category $category -Target ([string]$record.target) -Value $record.value -SourceLine $record.sourceLine
        }
    }
    foreach ($category in @("introduced", "deprecated", "removed")) {
        foreach ($record in @($Source[$category])) {
            Add-LifecycleConstraint -Facts $Target -Category $category -Version $record.version -SourceLine $record.sourceLine
        }
    }
}

function Merge-ManualInfo {
    param(
        [Parameter(Mandatory = $true)]$Target,
        [AllowNull()]$Source
    )

    if ($null -eq $Source) { return }
    $Target.remarksCount = [int]$Target.remarksCount + [int]$Source.remarksCount
    $Target.examplesCount = [int]$Target.examplesCount + [int]$Source.examplesCount
    $names = New-Object "System.Collections.Generic.List[string]"
    foreach ($name in @($Target.sectionNames) + @($Source.sectionNames)) {
        if (-not [String]::IsNullOrWhiteSpace([string]$name) -and -not $names.Contains([string]$name)) {
            $names.Add([string]$name)
        }
    }
    $Target.sectionNames = @($names.ToArray() | Sort-Object)
}

function Get-OutputArtifactIdsForAssemblies {
    param(
        [Parameter(Mandatory = $true)][AllowEmptyCollection()][string[]]$AssemblyNames,
        [AllowNull()][AllowEmptyString()][string]$SourcePath = $null
    )

    $ids = New-Object "System.Collections.Generic.List[string]"
    $sourceProject = $null
    if (-not [String]::IsNullOrWhiteSpace($SourcePath)) {
        $sourceProject = @(
            $script:ProjectRecords.ToArray() |
                Where-Object {
                    $SourcePath.StartsWith(([IO.Path]::GetDirectoryName($_.Path) + "\"), [StringComparison]::OrdinalIgnoreCase)
                } |
                Select-Object -First 1
        )
    }
    foreach ($assemblyName in $AssemblyNames) {
        if (-not $script:AssemblyArtifactsByName.ContainsKey($assemblyName)) {
            Add-Gap ("assembly-output-source-not-found:" + $assemblyName)
            continue
        }
        $candidates = @($script:AssemblyArtifactsByName[$assemblyName].ToArray())
        if ($null -ne $sourceProject -and $sourceProject.Count -gt 0) {
            $projectCandidates = @(
                $candidates |
                    Where-Object {
                        $script:ArtifactById[$_].sourceProject -eq $sourceProject[0].RelativePath
                    }
            )
            if ($projectCandidates.Count -eq 0) {
                Add-Gap ("assembly-output-source-not-found:" + $assemblyName)
                continue
            }
            $candidates = $projectCandidates
        }
        $selected = @(
            $candidates |
                ForEach-Object { $script:ArtifactById[$_] } |
                Sort-Object `
                    @{ Expression = { if ($_.file.path -like "src/NuGetPackages/bin/Release/*") { 0 } else { 1 } } }, `
                    @{ Expression = { if ($_.sourceType -eq "build-output") { 0 } else { 1 } } }, `
                    id |
                Select-Object -First 1
        )
        if ($selected.Count -eq 0) {
            Add-Gap ("assembly-output-source-not-found:" + $assemblyName)
            continue
        }
        $selectedId = [string]$selected[0].id
        if (-not $ids.Contains($selectedId)) {
            $ids.Add($selectedId)
        }
        if ($script:PackageArtifactsByAssemblyName.ContainsKey($assemblyName)) {
            foreach ($packageId in @($script:PackageArtifactsByAssemblyName[$assemblyName].ToArray())) {
                if (-not $ids.Contains($packageId)) {
                    $ids.Add($packageId)
                }
            }
        }
        if ($null -ne $sourceProject -and $sourceProject.Count -gt 0 -and $selected[0].file.path -notlike "src/NuGetPackages/bin/*") {
            foreach ($packageId in @($sourceProject[0].PackageIds)) {
                if (-not $ids.Contains($packageId)) {
                    $ids.Add($packageId)
                }
            }
        }
        if ($script:AssemblyDocumentationById.ContainsKey($selectedId)) {
            $documentationId = $script:AssemblyDocumentationById[$selectedId]
            if (-not $ids.Contains($documentationId)) {
                $ids.Add($documentationId)
            }
        }
    }
    return @($ids.ToArray() | Sort-Object)
}

function Get-ApiOutputs {
    param([Parameter(Mandatory = $true)][string]$OutputRoot)

    $outputs = New-Object "System.Collections.Generic.List[object]"
    if (-not (Test-Path -LiteralPath $OutputRoot -PathType Container)) {
        Add-Gap "api-output-not-generated"
        return @()
    }

    foreach ($file in @(Get-ChildItem -LiteralPath $OutputRoot -File -Filter "*.yml" | Sort-Object FullName)) {
        $relative = ConvertTo-RepositoryRelativePath -Path $file.FullName
        $text = [IO.File]::ReadAllText($file.FullName)
        if ($text -notmatch "(?m)^###\s+YamlMime:ManagedReference\s*$") {
            continue
        }
        $parsed = Get-ApiYamlFacts -Text $text
        $artifactIds = New-Object "System.Collections.Generic.List[string]"
        $sourcePath = $null
        if (-not [String]::IsNullOrWhiteSpace($parsed.SourcePath)) {
            $sourcePath = $parsed.SourcePath
            if (-not [IO.Path]::IsPathRooted($sourcePath)) {
                $sourcePath = Join-Path $script:Root $sourcePath.Replace("/", "\")
            }
            $artifactIds.Add((Add-SourceArtifact -Path $sourcePath))
            foreach ($project in @($script:ProjectRecords.ToArray())) {
                if ($sourcePath.StartsWith(([IO.Path]::GetDirectoryName($project.Path) + "\"), [StringComparison]::OrdinalIgnoreCase)) {
                    if (-not $artifactIds.Contains($project.Id)) {
                        $artifactIds.Add($project.Id)
                    }
                    break
                }
            }
        }
        foreach ($id in @(Get-OutputArtifactIdsForAssemblies -AssemblyNames $parsed.AssemblyNames -SourcePath $sourcePath)) {
            if (-not $artifactIds.Contains($id)) { $artifactIds.Add($id) }
        }
        $facts = New-EmptyFacts
        Merge-Facts -Target $facts -Source $parsed.Facts
        $documentationArtifactIds = @(
            $artifactIds.ToArray() |
                Where-Object { $script:ArtifactById.ContainsKey($_) -and $script:ArtifactById[$_].kind -eq "xml-documentation" }
        )
        $xmlFacts = Get-XmlFactsForApi `
            -AssemblyNames $parsed.AssemblyNames `
            -CommentIds $parsed.CommentIds `
            -DocumentationArtifactIds $documentationArtifactIds
        $manual = [ordered]@{
            remarksCount = [int]$parsed.Manual.remarksCount
            examplesCount = [int]$parsed.Manual.examplesCount
            overwriteCount = 0
            sectionNames = @()
        }
        if ($null -ne $xmlFacts) {
            Merge-Facts -Target $facts -Source $xmlFacts.Facts
            $manual.remarksCount = [Math]::Max([int]$manual.remarksCount, [int]$xmlFacts.Manual.remarksCount)
            $manual.examplesCount = [Math]::Max([int]$manual.examplesCount, [int]$xmlFacts.Manual.examplesCount)
        }
        $matchedOverwriteIds = New-Object "System.Collections.Generic.List[string]"
        foreach ($uid in @($parsed.Uids)) {
            if (-not $script:OverwriteArtifactsByUid.ContainsKey($uid)) { continue }
            foreach ($id in @($script:OverwriteArtifactsByUid[$uid].ToArray())) {
                if (-not $artifactIds.Contains($id)) { $artifactIds.Add($id) }
                if (-not $matchedOverwriteIds.Contains($id)) { $matchedOverwriteIds.Add($id) }
            }
            if ($script:OverwriteManualByUid.ContainsKey($uid)) {
                Merge-ManualInfo -Target $manual -Source $script:OverwriteManualByUid[$uid]
            }
        }
        $stem = [IO.Path]::GetFileNameWithoutExtension($file.Name)
        if ($script:OverwriteArtifactsByStem.ContainsKey($stem)) {
            $addedStemOverwrite = $false
            foreach ($id in @($script:OverwriteArtifactsByStem[$stem].ToArray())) {
                if (-not $artifactIds.Contains($id)) { $artifactIds.Add($id) }
                if (-not $matchedOverwriteIds.Contains($id)) {
                    $matchedOverwriteIds.Add($id)
                    $addedStemOverwrite = $true
                }
            }
            if ($addedStemOverwrite -and $script:OverwriteManualByStem.ContainsKey($stem)) {
                Merge-ManualInfo -Target $manual -Source $script:OverwriteManualByStem[$stem]
            }
        }
        $manual.overwriteCount = $matchedOverwriteIds.Count
        $outputs.Add([ordered]@{
            path = $relative
            uid = $parsed.Uid
            url = Get-OutputUrl -RelativePath $relative
            file = New-FileReference -Path $file.FullName -CanonicalText (Get-CanonicalOutputText -Text $text)
            artifactIds = @($artifactIds.ToArray() | Sort-Object)
            pipeline = "docfx metadata"
            compatibility = [ordered]@{
                uid = if ($null -ne $parsed.Uid) { "stable" } else { "unknown" }
                url = "stable"
            }
            generated = [ordered]@{
                sections = @("ManagedReference")
                type = $parsed.Type
                memberCount = $parsed.MemberCount
                parameterCount = $parsed.ParameterCount
                assemblies = @($parsed.AssemblyNames)
            }
            facts = $facts
            manual = $manual
        })
    }
    return @($outputs.ToArray())
}

function Get-SchemaVersion {
    param([Parameter(Mandatory = $true)][string]$Text)

    $parts = Get-FrontMatterParts -Text $Text
    $frontMatterVersion = Get-FrontMatterValue -FrontMatter $parts.FrontMatter -Name "version"
    if ($frontMatterVersion -ne "" -and $frontMatterVersion -notin @("unknown", "unversioned", "not_applicable")) {
        return $frontMatterVersion
    }
    $matches = @(
        [Regex]::Matches(
            $parts.Body,
            "(?i)(?:schema|package)\s+(?:package\s+)?(?:version|)\s*(?:is|:|v)?\s*(?<version>\d+(?:\.\d+){1,3})"
        ) | ForEach-Object { $_.Groups["version"].Value }
    )
    $distinct = @($matches | Sort-Object -Unique)
    if ($distinct.Count -eq 1) {
        return [string]$distinct[0]
    }
    return $null
}

function Get-SchemaIdentity {
    param([Parameter(Mandatory = $true)][string]$Folder)

    $knownNames = @{
        Automation = "SchemaAutomationScript"
        SNMPManagersSchema = "SchemaSNMPManagers"
    }
    if ($knownNames.ContainsKey($Folder)) {
        return $knownNames[$Folder]
    }
    return "Schema" + $Folder
}

function Add-SchemaSourceArtifact {
    param(
        [Parameter(Mandatory = $true)][string]$Identity,
        [Parameter(Mandatory = $true)][string]$Folder
    )

    if ($script:ConfiguredSchemaArtifactsByIdentity.ContainsKey($Identity)) {
        return $script:ConfiguredSchemaArtifactsByIdentity[$Identity]
    }
    if ($script:SchemaArtifactsByIdentity.ContainsKey($Identity)) {
        return $script:SchemaArtifactsByIdentity[$Identity]
    }
    $identityPageName = Get-SchemaIdentity -Folder $Folder
    $identityPage = Join-Path $script:Root ("develop\schemadoc\" + $identityPageName + ".md")
    $version = $null
    if (Test-Path -LiteralPath $identityPage -PathType Leaf) {
        $version = Get-SchemaVersion -Text ([IO.File]::ReadAllText($identityPage))
    }
    else {
        Add-Gap ("schema-identity-page-not-found:" + $Identity)
    }
    Add-Gap ("schema-source-artifact-not-present:" + $Identity)
    $artifactId = Add-Artifact `
        -Kind "schema" `
        -Identity $Identity `
        -Version $version `
        -Path $(if (Test-Path -LiteralPath $identityPage -PathType Leaf) { $identityPage } else { $null }) `
        -SourceType "documentation-identity" `
        -Reason "schema-package-source-not-present" `
        -DisplayPath ("develop/schemadoc/" + $identityPageName + ".md")
    $script:SchemaArtifactsByIdentity[$Identity] = $artifactId
    return $artifactId
}

function Add-ConfiguredSchemaSources {
    if ([String]::IsNullOrWhiteSpace($SchemaSourcePath)) {
        return
    }
    $fullPath = ConvertTo-RepositoryPath $SchemaSourcePath
    $files = if (Test-Path -LiteralPath $fullPath -PathType Leaf) {
        @((Get-Item -LiteralPath $fullPath))
    }
    elseif (Test-Path -LiteralPath $fullPath -PathType Container) {
        @(Get-ChildItem -LiteralPath $fullPath -Recurse -File | Where-Object { $_.Extension -in @(".xsd", ".json", ".xml") } | Sort-Object FullName)
    }
    else {
        Add-Gap "configured-schema-source-not-found"
        @()
    }
    foreach ($file in $files) {
        $identity = ConvertTo-RepositoryRelativePath -Path $file.FullName
        if ($null -eq $identity) { $identity = $file.Name }
        $baseName = $file.BaseName
        $logicalIdentity = if ($baseName -match "(?i)automation") {
            "SchemaAutomationScript"
        }
        elseif ($baseName -match "(?i)protocol") {
            "SchemaProtocol"
        }
        elseif ($baseName -match "(?i)^Schema") {
            $baseName
        }
        else {
            "Schema" + $baseName
        }
        $sourceType = if ($null -eq (ConvertTo-RepositoryRelativePath -Path $file.FullName)) { "external" } else { "repository" }
        $sourceVersion = $null
        try {
            if ($file.Extension -in @(".xsd", ".xml")) {
                [xml]$schemaXml = [IO.File]::ReadAllText($file.FullName)
                $versionAttribute = $schemaXml.DocumentElement.GetAttribute("version")
                if (-not [String]::IsNullOrWhiteSpace($versionAttribute)) {
                    $sourceVersion = $versionAttribute.Trim()
                }
            }
            elseif ($file.Extension -ieq ".json") {
                $schemaJson = Get-Content -LiteralPath $file.FullName -Raw | ConvertFrom-Json
                $versionProperty = $schemaJson.PSObject.Properties | Where-Object { $_.Name -ieq "version" } | Select-Object -First 1
                if ($null -ne $versionProperty -and -not [String]::IsNullOrWhiteSpace([string]$versionProperty.Value)) {
                    $sourceVersion = [string]$versionProperty.Value
                }
            }
        }
        catch {
            Add-Gap ("schema-source-invalid:" + $identity)
        }
        $artifactId = Add-Artifact -Kind "schema" -Identity $logicalIdentity -Version $sourceVersion -Path $file.FullName -SourceType $sourceType -Reason "schema-source-not-found"
        $script:ConfiguredSchemaArtifactsByIdentity[$logicalIdentity] = $artifactId
    }
}

function Get-SchemaOutputs {
    param([Parameter(Mandatory = $true)][string]$OutputRoot)

    $outputs = New-Object "System.Collections.Generic.List[object]"
    if (-not (Test-Path -LiteralPath $OutputRoot -PathType Container)) {
        Add-Gap "schema-output-not-generated"
        return @()
    }

    foreach ($file in @(Get-ChildItem -LiteralPath $OutputRoot -Recurse -File -Filter "*.md" | Sort-Object FullName)) {
        $relative = ConvertTo-RepositoryRelativePath -Path $file.FullName
        $relativeParts = $relative.Split("/")
        if ($relativeParts.Count -lt 4 -or $relativeParts[0] -ne "develop" -or $relativeParts[1] -ne "schemadoc") {
            continue
        }
        $folder = $relativeParts[2]
        $identity = Get-SchemaIdentity -Folder $folder
        $schemaArtifactId = Add-SchemaSourceArtifact -Identity $identity -Folder $folder
        $text = [IO.File]::ReadAllText($file.FullName)
        $parts = Get-FrontMatterParts -Text $text
        $parsed = Get-MarkdownFacts -Body $parts.Body
        $manual = Get-ManualInfo -Body $parts.Body
        $outputs.Add([ordered]@{
            path = $relative
            uid = if ($parts.FrontMatter -ne "") { Get-FrontMatterValue -FrontMatter $parts.FrontMatter -Name "uid" } else { $null }
            url = Get-OutputUrl -RelativePath $relative
            file = New-FileReference -Path $file.FullName -CanonicalText (Get-CanonicalOutputText -Text $text)
            artifactIds = @($schemaArtifactId)
            pipeline = "schema documentation"
            compatibility = [ordered]@{
                uid = if ($parts.FrontMatter -ne "" -and -not [String]::IsNullOrWhiteSpace((Get-FrontMatterValue -FrontMatter $parts.FrontMatter -Name "uid"))) { "stable" } else { "unknown" }
                url = "stable"
            }
            generated = [ordered]@{
                sections = @($parsed.GeneratedSections)
                type = $null
                memberCount = $null
                parameterCount = $null
                assemblies = @()
            }
            facts = $parsed.Facts
            manual = $manual
        })
    }
    return @($outputs.ToArray())
}

$script:Root = ConvertTo-FullPath $RepositoryRoot
$DocFxConfigPath = ConvertTo-RepositoryPath $DocFxConfigPath
$ApiOutputPath = ConvertTo-RepositoryPath $ApiOutputPath
$SchemaOutputPath = ConvertTo-RepositoryPath $SchemaOutputPath
$OutputPath = ConvertTo-RepositoryPath $OutputPath
$ValidatorPath = ConvertTo-RepositoryPath $ValidatorPath
if (-not (Test-Path -LiteralPath $script:Root -PathType Container)) {
    throw "Repository root '$script:Root' does not exist."
}
if (-not (Test-Path -LiteralPath $DocFxConfigPath -PathType Leaf)) {
    throw "DocFX configuration '$DocFxConfigPath' does not exist."
}

$generation = Get-GenerationInfo -RequestedDate $GenerationDate
$revision = if (-not [String]::IsNullOrWhiteSpace($SourceRevision)) {
    $SourceRevision
}
else {
    Get-GitValue -Arguments @("rev-parse", "HEAD")
}
$revisionSource = if (-not [String]::IsNullOrWhiteSpace($SourceRevision)) { "argument" } elseif (-not [String]::IsNullOrWhiteSpace($revision)) { "git" } else { "working-tree" }
if ([String]::IsNullOrWhiteSpace($revision)) {
    $revision = "working-tree"
}
if ([String]::IsNullOrWhiteSpace($SourceRevision) -and $revisionSource -eq "git") {
    $workingTreeStatus = Get-GitValue -Arguments @("status", "--porcelain", "--untracked-files=all")
    if (-not [String]::IsNullOrWhiteSpace($workingTreeStatus)) {
        $revision = "working-tree"
        $revisionSource = "working-tree"
        Add-Gap "source-working-tree-dirty"
    }
}

$docFxText = [IO.File]::ReadAllText($DocFxConfigPath)
try {
    $docFxConfig = $docFxText | ConvertFrom-Json
}
catch {
    throw "DocFX configuration '$DocFxConfigPath' is not valid JSON."
}
$sitemapProperty = $docFxConfig.build.PSObject.Properties | Where-Object { $_.Name -eq "sitemap" } | Select-Object -First 1
$script:BaseUrl = if ($null -ne $sitemapProperty -and $null -ne $sitemapProperty.Value -and -not [String]::IsNullOrWhiteSpace([string]$sitemapProperty.Value.baseUrl)) {
    [string]$sitemapProperty.Value.baseUrl
}
else {
    ""
}

$configuredFiles = @(Resolve-ConfiguredMetadataInputs -Config $docFxConfig)
$projectFiles = @($configuredFiles | Where-Object { $_.Extension -ieq ".csproj" } | Sort-Object FullName -Unique)
$dllFiles = @($configuredFiles | Where-Object { $_.Extension -ieq ".dll" } | Sort-Object FullName -Unique)
foreach ($projectFile in $projectFiles) {
    Add-ProjectArtifacts -ProjectFile $projectFile
}
foreach ($dllFile in $dllFiles) {
    Add-AssemblyArtifact -AssemblyFile $dllFile
}
foreach ($project in @($script:ProjectRecords.ToArray())) {
    $binRoot = Join-Path ([IO.Path]::GetDirectoryName($project.Path)) "bin"
    if (-not (Test-Path -LiteralPath $binRoot -PathType Container)) {
        Add-Gap ("project-output-not-found:" + $project.RelativePath)
        continue
    }
    $candidates = @(
        Get-ChildItem -LiteralPath $binRoot -Recurse -File -Filter ($project.AssemblyName + ".dll") |
            Sort-Object @{ Expression = { if ($_.FullName -match "\\Release\\") { 0 } else { 1 } } }, FullName
    )
    if ($candidates.Count -eq 0) {
        Add-Gap ("project-output-not-found:" + $project.RelativePath)
        continue
    }
    Add-AssemblyArtifact -AssemblyFile $candidates[0]
}

Add-ConfiguredSchemaSources

$overwritePatterns = @($docFxConfig.build.overwrite)
foreach ($pattern in $overwritePatterns) {
    foreach ($file in @(Resolve-Pattern -Pattern ([string]$pattern))) {
        $relative = ConvertTo-RepositoryRelativePath -Path $file.FullName
        $artifactId = Add-Artifact -Kind "overwrite" -Identity $relative -Path $file.FullName -SourceType "repository"
        $stem = [IO.Path]::GetFileNameWithoutExtension($file.Name)
        $overwriteParts = Get-FrontMatterParts -Text ([IO.File]::ReadAllText($file.FullName))
        $overwriteUid = Get-FrontMatterValue -FrontMatter $overwriteParts.FrontMatter -Name "uid"
        if (-not $script:OverwriteArtifactsByStem.ContainsKey($stem)) {
            $script:OverwriteArtifactsByStem[$stem] = New-Object "System.Collections.Generic.List[string]"
        }
        $script:OverwriteArtifactsByStem[$stem].Add($artifactId)
        if (-not $script:OverwriteManualByStem.ContainsKey($stem)) {
            $script:OverwriteManualByStem[$stem] = [ordered]@{
                remarksCount = 0
                examplesCount = 0
                overwriteCount = 0
                sectionNames = @()
            }
        }
        $overwriteManual = Get-ManualInfo -Body $overwriteParts.Body
        Merge-ManualInfo -Target $script:OverwriteManualByStem[$stem] -Source $overwriteManual
        if (-not [String]::IsNullOrWhiteSpace($overwriteUid)) {
            if (-not $script:OverwriteArtifactsByUid.ContainsKey($overwriteUid)) {
                $script:OverwriteArtifactsByUid[$overwriteUid] = New-Object "System.Collections.Generic.List[string]"
            }
            $script:OverwriteArtifactsByUid[$overwriteUid].Add($artifactId)
            if (-not $script:OverwriteManualByUid.ContainsKey($overwriteUid)) {
                $script:OverwriteManualByUid[$overwriteUid] = [ordered]@{
                    remarksCount = 0
                    examplesCount = 0
                    overwriteCount = 0
                    sectionNames = @()
                }
            }
            Merge-ManualInfo -Target $script:OverwriteManualByUid[$overwriteUid] -Source $overwriteManual
        }
    }
}

$apiOutputs = @(Get-ApiOutputs -OutputRoot $ApiOutputPath)
$schemaOutputs = @(Get-SchemaOutputs -OutputRoot $SchemaOutputPath)
if ($RequireGeneratedOutputs) {
    if ($apiOutputs.Count -eq 0) {
        throw "No generated API outputs were found in '$ApiOutputPath'."
    }
    if ($schemaOutputs.Count -eq 0) {
        throw "No generated schema outputs were found in '$SchemaOutputPath'."
    }
}
$configRelative = ConvertTo-RepositoryRelativePath -Path $DocFxConfigPath
$source = [ordered]@{
    repository = "SkylineCommunications/dataminer-docs"
    revision = $revision
    revisionSource = $revisionSource
    configuration = [ordered]@{
        path = $configRelative
        sha256 = Get-FileSha256 -Path $DocFxConfigPath
        available = $true
        reason = $null
    }
}
$gaps = @(
    $script:GapCounts.Keys |
        Sort-Object |
        ForEach-Object {
            [ordered]@{
                code = [string]$_
                count = [int]$script:GapCounts[$_]
            }
        }
)
$manifest = [ordered]@{
    schemaVersion = 1
    generator = [ordered]@{
        name = "scripts/generate-generated-metadata-provenance.ps1"
        version = $script:GeneratorVersion
    }
    generatedAt = $generation.Date
    generatedAtSource = $generation.Source
    source = $source
    license = [ordered]@{
        identifier = "CC BY-NC-ND 4.0"
        name = "Creative Commons Attribution-NonCommercial-NoDerivatives 4.0 International"
        url = "https://creativecommons.org/licenses/by-nc-nd/4.0/"
        attribution = "Skyline Communications"
        source = "contributing/CTB_Documentation_Corpus_Policy.md"
    }
    artifacts = @($script:Artifacts | Sort-Object kind, identity, version, id)
    outputs = [ordered]@{
        api = @($apiOutputs | Sort-Object path)
        schema = @($schemaOutputs | Sort-Object path)
    }
    gaps = $gaps
}

$json = $manifest | ConvertTo-Json -Depth 20
[void](Write-TextIfChanged -Path $OutputPath -Text ($json + "`n"))
if (Test-Path -LiteralPath $ValidatorPath -PathType Leaf) {
    & $ValidatorPath -RepositoryRoot $script:Root -Path $OutputPath
}
else {
    throw "Generated provenance validator '$ValidatorPath' does not exist."
}

Write-Output "Generated metadata provenance: $($apiOutputs.Count) API outputs, $($schemaOutputs.Count) schema outputs, $($script:Artifacts.Count) source artifacts."
Write-Output "Source gaps: $($gaps.Count)."
