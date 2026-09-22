[CmdletBinding()]
param(
    [string]$RepositoryRoot = (Join-Path $PSScriptRoot ".."),
    [string]$ScopeManifestPath = (Join-Path $PSScriptRoot "..\contributing\metadata\d2-2-migration-scope.json"),
    [string]$ReportPath = (Join-Path $PSScriptRoot "..\d2-2-metadata-migration-report.json"),
    [string]$SchemaPath = (Join-Path $PSScriptRoot "..\contributing\metadata\documentation-metadata-v1.schema.json"),
    [string]$ValidatorPath = (Join-Path $PSScriptRoot "validate-documentation-metadata.ps1"),
    [switch]$CheckOnly
)

Set-StrictMode -Version 2.0
$ErrorActionPreference = "Stop"

$script:GeneratorVersion = "1.0.0"
$script:ReportSchemaVersion = 1

function ConvertTo-FullPath {
    param([Parameter(Mandatory = $true)][string]$Path)

    if ([IO.Path]::IsPathRooted($Path)) {
        return [IO.Path]::GetFullPath($Path)
    }

    return [IO.Path]::GetFullPath((Join-Path (Get-Location).Path $Path))
}

function ConvertTo-RepositoryRelativePath {
    param(
        [Parameter(Mandatory = $true)][string]$Path,
        [Parameter(Mandatory = $true)][string]$Root
    )

    $fullPath = [IO.Path]::GetFullPath($Path)
    $prefix = $Root.TrimEnd("\") + "\"
    if (-not $fullPath.StartsWith($prefix, [StringComparison]::OrdinalIgnoreCase)) {
        throw "Path '$Path' is outside the repository root '$Root'."
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

function Get-FrontMatterParts {
    param([Parameter(Mandatory = $true)][string]$Text)

    $match = [Regex]::Match(
        $Text,
        "\A---\r?\n(?<front>.*?)\r?\n---(?<separator>\r?\n|\z)",
        [Text.RegularExpressions.RegexOptions]::Singleline
    )
    if (-not $match.Success) {
        throw "The page does not have a YAML front matter block."
    }

    $lineEnding = if ($Text.Contains("`r`n")) { "`r`n" } else { "`n" }
    return [PSCustomObject]@{
        FrontMatter = $match.Groups["front"].Value
        Body = $Text.Substring($match.Length)
        LineEnding = $lineEnding
    }
}

function ConvertFrom-YamlScalar {
    param([AllowEmptyString()][string]$Text)

    $value = if ($null -eq $Text) { "" } else { $Text.Trim() }
    if ($value -eq "") {
        return ""
    }

    if ($value.StartsWith('"') -and $value.EndsWith('"') -and $value.Length -ge 2) {
        return $value.Substring(1, $value.Length - 2).Replace('\"', '"').Replace("\\", "\")
    }

    if ($value.StartsWith("'") -and $value.EndsWith("'") -and $value.Length -ge 2) {
        return $value.Substring(1, $value.Length - 2).Replace("''", "'")
    }

    return ([Regex]::Replace($value, "\s+#.*$", "")).Trim()
}

function Get-TopLevelMetadata {
    param([Parameter(Mandatory = $true)][string]$FrontMatter)

    $metadata = New-Object "System.Collections.Specialized.OrderedDictionary"
    foreach ($line in (Normalize-Text $FrontMatter) -split "`n") {
        $match = [Regex]::Match($line, "^(?<key>[A-Za-z_][A-Za-z0-9_-]*):(?:[ \t]*(?<value>.*))?$")
        if (-not $match.Success) {
            continue
        }

        $key = $match.Groups["key"].Value
        if ($metadata.Contains($key)) {
            throw "Duplicate top-level front matter key '$key'."
        }

        $metadata.Add($key, (ConvertFrom-YamlScalar $match.Groups["value"].Value))
    }

    return $metadata
}

function ConvertTo-YamlScalar {
    param([Parameter(Mandatory = $true)][string]$Value)

    return '"' + $Value.Replace("\", "\\").Replace('"', '\"') + '"'
}

function Get-MarkdownTitle {
    param(
        [Parameter(Mandatory = $true)][string]$Body,
        [Parameter(Mandatory = $true)][string]$RelativePath
    )

    $match = [Regex]::Match($Body, "(?m)^\s*#\s+(?<title>.+?)\s*$")
    if ($match.Success) {
        $title = $match.Groups["title"].Value.Trim()
    }
    else {
        $title = [IO.Path]::GetFileNameWithoutExtension($RelativePath)
    }

    $title = [Regex]::Replace($title, "\[([^\]]+)\]\([^)]+\)", '$1')
    $title = $title.Replace('`', '').Replace("*", "").Replace("_", " ")
    $title = [Regex]::Replace($title, "\s+", " ").Trim()
    if ($title.Length -gt 72) {
        $title = $title.Substring(0, 72).TrimEnd()
    }
    if ($title -eq "") {
        return "this documentation topic"
    }

    return $title
}

function Fit-Description {
    param([Parameter(Mandatory = $true)][string]$Description)

    $description = [Regex]::Replace($Description, "\s+", " ").Trim()
    if ($description.Length -gt 155) {
        $description = $description.Substring(0, 154).TrimEnd(" ", ".", ",", ";", ":") + "."
    }
    if ($description.Length -lt 100) {
        $description = ($description.TrimEnd(".") + " for DataMiner development documentation.").Trim()
    }
    if ($description.Length -gt 155) {
        $description = $description.Substring(0, 154).TrimEnd(" ", ".", ",", ";", ":") + "."
    }
    if ($description.Length -lt 100) {
        throw "Generated description '$description' is shorter than 100 characters."
    }

    return $description
}

function New-Description {
    param(
        [Parameter(Mandatory = $true)][string]$Domain,
        [Parameter(Mandatory = $true)][bool]$IsSchema,
        [Parameter(Mandatory = $true)][string]$Title
    )

    if ($IsSchema -and $Domain -eq "Connector") {
        return Fit-Description "Reference the DataMiner connector protocol schema entry for $Title, including its documented structure, attributes, values, and constraints."
    }
    if ($IsSchema) {
        return Fit-Description "Reference the DataMiner Automation script schema entry for $Title, including its documented structure, attributes, values, and constraints."
    }
    if ($Domain -eq "Connector") {
        return Fit-Description "Describe the DataMiner connector development topic $Title, including its purpose, behavior, implementation guidance, and relevant constraints."
    }

    return Fit-Description "Describe the DataMiner Automation development topic $Title, including its purpose, behavior, implementation guidance, and relevant constraints."
}

function Get-AuthoritativeSource {
    param([Parameter(Mandatory = $true)][string]$Body)

    $heading = [Regex]::Match(
        $Body,
        '(?is)^\s*##\s+Authoritative references\s*$([\s\S]*?)(?=^\s*##\s+|\z)',
        [Text.RegularExpressions.RegexOptions]::Multiline
    )
    if (-not $heading.Success) {
        return ""
    }

    $xref = [Regex]::Match($heading.Groups[1].Value, "(?i)xref:([A-Za-z0-9_.-]+)")
    if ($xref.Success) {
        return $xref.Groups[1].Value
    }

    return ""
}

function Get-VersionEvidence {
    param([Parameter(Mandatory = $true)][string]$Body)

    $strong = New-Object "System.Collections.Generic.List[string]"
    $strongEvidence = New-Object "System.Collections.Generic.List[string]"
    $strongPatterns = @(
        "(?i)(?:schema\s+package|schema\s+version|package\s+version|aligned\s+with[^.\r\n]{0,80}schema)[^0-9\r\n]{0,30}(?<version>\d+(?:\.\d+){1,3})",
        "(?i)(?:introduced|available|supported|requires|minimum\s+required|starting\s+with|since|as\s+of)[^.\r\n]{0,80}(?:DataMiner\s+)?v?(?<version>10\.\d+(?:\.\d+){0,2})"
    )
    foreach ($pattern in $strongPatterns) {
        foreach ($match in [Regex]::Matches($Body, $pattern)) {
            $version = $match.Groups["version"].Value
            if (-not $strong.Contains($version)) {
                $strong.Add($version)
            }
            $evidenceText = [Regex]::Replace($match.Value.Trim(), "\s+", " ")
            if (-not $strongEvidence.Contains($evidenceText)) {
                $strongEvidence.Add($evidenceText)
            }
        }
    }

    $all = New-Object "System.Collections.Generic.List[string]"
    foreach ($match in [Regex]::Matches($Body, "(?i)(?<![A-Za-z0-9])(?:DataMiner\s+)?v?(?<version>10\.\d+(?:\.\d+){0,2})(?![A-Za-z0-9])")) {
        $version = $match.Groups["version"].Value
        if (-not $all.Contains($version)) {
            $all.Add($version)
        }
    }
    foreach ($match in [Regex]::Matches($Body, "(?i)(?:schema\s+package|schema\s+version|package\s+version)[^0-9\r\n]{0,30}(?<version>\d+(?:\.\d+){1,3})")) {
        $version = $match.Groups["version"].Value
        if (-not $all.Contains($version)) {
            $all.Add($version)
        }
    }

    $evidence = @()
    foreach ($match in [Regex]::Matches($Body, "(?i)[^\r\n]{0,45}(?:DataMiner\s+)?v?(?:10\.\d+(?:\.\d+){0,2})[^\r\n]{0,45}")) {
        $evidence += [Regex]::Replace($match.Value.Trim(), "\s+", " ")
        if ($evidence.Count -ge 3) {
            break
        }
    }

    if ($strong.Count -eq 1) {
        return [PSCustomObject]@{
            Version = $strong[0]
            Finding = ""
            Evidence = @($strongEvidence.ToArray())
        }
    }
    if ($strong.Count -gt 1) {
        return [PSCustomObject]@{
            Version = "unknown"
            Finding = "conflicting_version_evidence"
            Evidence = @($strongEvidence.ToArray())
        }
    }
    if ($all.Count -gt 0) {
        return [PSCustomObject]@{
            Version = "unknown"
            Finding = "ambiguous_version_evidence"
            Evidence = $evidence
        }
    }

    return [PSCustomObject]@{
        Version = "unknown"
        Finding = "version_not_confirmed"
        Evidence = @()
    }
}

function New-GeneratedMetadata {
    param(
        [Parameter(Mandatory = $true)]$Scope,
        [Parameter(Mandatory = $true)][string]$Uid,
        [Parameter(Mandatory = $true)][string]$Description,
        [Parameter(Mandatory = $true)][string]$Body,
        [AllowEmptyString()][string]$Keywords
    )

    $isSchema = $Scope.contentType -eq "schema"
    $authoritySource = ""
    $authority = "unknown"
    if ($isSchema) {
        $authority = "reference"
        $authoritySource = if ($Scope.domain -eq "Connector") { "SchemaProtocol" } else { "SchemaAutomationScript" }
    }
    else {
        $authoritySource = Get-AuthoritativeSource $Body
        if ($authoritySource -ne "") {
            $authority = "reference"
        }
    }

    $versionEvidence = Get-VersionEvidence $Body
    $lines = New-Object "System.Collections.Generic.List[string]"
    $lines.Add("metadata_version: 1")
    $lines.Add("uid: $Uid")
    $lines.Add("description: $(ConvertTo-YamlScalar $Description)")
    $lines.Add("area: develop")
    $lines.Add("content_type: $($Scope.contentType)")
    $lines.Add("authority: $authority")
    if ($authoritySource -eq "") {
        $authoritySource = "unknown"
    }
    $lines.Add("authority_source: $authoritySource")
    $lines.Add("applies_to:")
    $lines.Add("  - DataMiner")
    $lines.Add("version: $($versionEvidence.Version)")
    $lines.Add("owner: unknown")
    if (-not [String]::IsNullOrWhiteSpace($Keywords)) {
        $lines.Add("keywords: $(ConvertTo-YamlScalar $Keywords)")
    }

    return [PSCustomObject]@{
        Text = ($lines -join "`n")
        Version = $versionEvidence.Version
        VersionFinding = $versionEvidence.Finding
        VersionEvidence = $versionEvidence.Evidence
        Authority = $authority
        AuthoritySource = $authoritySource
    }
}

function Get-TargetFiles {
    param(
        [Parameter(Mandatory = $true)][string]$Root,
        [Parameter(Mandatory = $true)]$Scopes
    )

    $files = New-Object "System.Collections.Generic.List[object]"
    foreach ($scope in @($Scopes)) {
        $scopePath = Join-Path $Root ($scope.relativeRoot.Replace("/", "\"))
        if (-not (Test-Path -LiteralPath $scopePath -PathType Container)) {
            throw "Migration scope '$($scope.relativeRoot)' does not exist."
        }

        foreach ($file in Get-ChildItem -LiteralPath $scopePath -Recurse -File -Filter "*.md") {
            $relativePath = ConvertTo-RepositoryRelativePath -Path $file.FullName -Root $Root
            $files.Add([PSCustomObject]@{
                File = $file
                RelativePath = $relativePath
                Scope = $scope
            })
        }
    }

    return @($files | Sort-Object RelativePath)
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
    [IO.File]::WriteAllText($Path, $Text, $utf8NoBom)
    return $true
}

$script:RepositoryRoot = ConvertTo-FullPath $RepositoryRoot
$ScopeManifestPath = ConvertTo-FullPath $ScopeManifestPath
$ReportPath = ConvertTo-FullPath $ReportPath
$SchemaPath = ConvertTo-FullPath $SchemaPath
$ValidatorPath = ConvertTo-FullPath $ValidatorPath
if (-not (Test-Path -LiteralPath $script:RepositoryRoot -PathType Container)) {
    throw "Repository root '$script:RepositoryRoot' does not exist."
}
if (-not (Test-Path -LiteralPath $ScopeManifestPath -PathType Leaf)) {
    throw "Scope manifest '$ScopeManifestPath' does not exist."
}
if (-not (Test-Path -LiteralPath $SchemaPath -PathType Leaf)) {
    throw "Metadata schema '$SchemaPath' does not exist."
}
if (-not (Test-Path -LiteralPath $ValidatorPath -PathType Leaf)) {
    throw "Metadata validator '$ValidatorPath' does not exist."
}

$manifest = Get-Content -LiteralPath $ScopeManifestPath -Raw | ConvertFrom-Json
if ($manifest.schemaVersion -ne 1 -or $manifest.migration -ne "D2.2") {
    throw "Scope manifest '$ScopeManifestPath' is not a D2.2 version 1 manifest."
}

$targetFiles = @(Get-TargetFiles -Root $script:RepositoryRoot -Scopes $manifest.scopes)
if ($targetFiles.Count -eq 0) {
    throw "The D2.2 scope contains no Markdown pages."
}
$manifestBaselineCount = 0
foreach ($scope in @($manifest.scopes)) {
    $manifestBaselineCount += [int]$scope.baselineCount
}
if ($manifestBaselineCount -ne [int]$manifest.baseline.sourcePageCount) {
    throw "Scope baseline counts total $manifestBaselineCount, but the manifest records $($manifest.baseline.sourcePageCount)."
}
if ($manifest.baseline.PSObject.Properties.Name -contains "currentExpectedPageCount" -and
    $targetFiles.Count -ne [int]$manifest.baseline.currentExpectedPageCount) {
    throw "The current D2.2 scope contains $($targetFiles.Count) pages, but the manifest expects $($manifest.baseline.currentExpectedPageCount)."
}

$tocPath = Join-Path $script:RepositoryRoot "develop\toc.yml"
$tocHash = if (Test-Path -LiteralPath $tocPath -PathType Leaf) {
    Get-TextSha256 ([IO.File]::ReadAllText($tocPath))
}
else {
    "not_applicable"
}

$seenUids = @{}
$records = New-Object "System.Collections.Generic.List[object]"
$changedCount = 0

foreach ($target in $targetFiles) {
    $path = $target.File.FullName
    $text = [IO.File]::ReadAllText($path)
    $parts = Get-FrontMatterParts $text
    $metadata = Get-TopLevelMetadata $parts.FrontMatter
    if (-not $metadata.Contains("uid") -or [String]::IsNullOrWhiteSpace([string]$metadata["uid"])) {
        throw "Target page '$($target.RelativePath)' has no UID."
    }

    $uid = [string]$metadata["uid"]
    if ($uid -notmatch "^[A-Za-z0-9][A-Za-z0-9_.-]*$") {
        throw "Target page '$($target.RelativePath)' has invalid UID '$uid'."
    }
    if ($seenUids.ContainsKey($uid) -and $seenUids[$uid] -ne $target.RelativePath) {
        throw "UID '$uid' is used by both '$($seenUids[$uid])' and '$($target.RelativePath)'."
    }
    $seenUids[$uid] = $target.RelativePath

    $existingVersion1 = $metadata.Contains("metadata_version") -and [string]$metadata["metadata_version"] -eq "1"
    if (-not $existingVersion1) {
        if ($CheckOnly) {
            throw "Target page '$($target.RelativePath)' is missing metadata_version: 1."
        }

        $title = Get-MarkdownTitle -Body $parts.Body -RelativePath $target.RelativePath
        $existingDescription = if ($metadata.Contains("description")) { [string]$metadata["description"] } else { "" }
        $description = if ($existingDescription.Length -ge 100 -and $existingDescription.Length -le 155) {
            $existingDescription
        }
        else {
            New-Description -Domain $target.Scope.domain -IsSchema ($target.Scope.contentType -eq "schema") -Title $title
        }
        $keywords = if ($metadata.Contains("keywords")) { [string]$metadata["keywords"] } else { "" }
        $generated = New-GeneratedMetadata `
            -Scope $target.Scope `
            -Uid $uid `
            -Description $description `
            -Body $parts.Body `
            -Keywords $keywords
        $generatedFrontMatter = $generated.Text.Replace("`n", $parts.LineEnding)
        $newText = "---$($parts.LineEnding)$generatedFrontMatter$($parts.LineEnding)---$($parts.LineEnding)$($parts.Body)"
        if (Write-TextIfChanged -Path $path -Text $newText) {
            $changedCount++
        }
        $text = $newText
        $parts = Get-FrontMatterParts $text
        $metadata = Get-TopLevelMetadata $parts.FrontMatter
    }
    else {
        $normalizedFrontMatter = Normalize-Text $parts.FrontMatter
        $desiredFrontMatter = $normalizedFrontMatter.Replace("`n", $parts.LineEnding)
        if ($parts.FrontMatter -ne $desiredFrontMatter) {
            $newText = "---$($parts.LineEnding)$desiredFrontMatter$($parts.LineEnding)---$($parts.LineEnding)$($parts.Body)"
            if (-not $CheckOnly -and (Write-TextIfChanged -Path $path -Text $newText)) {
                $changedCount++
            }
            if (-not $CheckOnly) {
                $text = $newText
                $parts = Get-FrontMatterParts $text
                $metadata = Get-TopLevelMetadata $parts.FrontMatter
            }
        }
    }

    $contentType = if ($metadata.Contains("content_type")) { [string]$metadata["content_type"] } else { [string]$target.Scope.contentType }
    $authority = if ($metadata.Contains("authority")) { [string]$metadata["authority"] } else { "unknown" }
    $version = if ($metadata.Contains("version")) { [string]$metadata["version"] } else { "unknown" }
    $authoritySource = if ($metadata.Contains("authority_source")) { [string]$metadata["authority_source"] } else { "unknown" }
    $body = (Get-FrontMatterParts $text).Body
    $findings = New-Object "System.Collections.Generic.List[string]"
    $evidence = @()
    $versionEvidence = Get-VersionEvidence $body
    if ($version -eq "unknown") {
        if ($versionEvidence.Finding -ne "") {
            $findings.Add($versionEvidence.Finding)
        }
        $evidence = @($versionEvidence.Evidence)
    }
    elseif ($version -ne "unversioned") {
        $evidence = @($versionEvidence.Evidence)
    }
    if ($authority -eq "unknown") {
        $findings.Add("authority_requires_follow_up")
    }

    $records.Add([ordered]@{
        path = $target.RelativePath
        domain = [string]$target.Scope.domain
        uid = $uid
        contentType = $contentType
        authority = $authority
        authoritySource = $authoritySource
        version = $version
        bodySha256 = Get-TextSha256 $body
        findings = @($findings | Sort-Object -Unique)
        versionEvidence = @($evidence)
    })
}

function Get-RecordCount {
    param(
        [Parameter(Mandatory = $true)]$Records,
        [Parameter(Mandatory = $true)][string]$Property,
        [Parameter(Mandatory = $true)][string]$Value
    )

    $count = 0
    foreach ($record in $Records) {
        if ([string]$record[$Property] -eq $Value) {
            $count++
        }
    }
    return $count
}

$recordArray = [object[]]$records.ToArray()
$scopeSummary = New-Object "System.Collections.Generic.List[object]"
foreach ($scope in @($manifest.scopes)) {
    $scopeRecords = @($recordArray | Where-Object { $_.path.StartsWith($scope.relativeRoot.TrimEnd("/") + "/", [StringComparison]::OrdinalIgnoreCase) })
    $scopeSummary.Add([ordered]@{
        domain = [string]$scope.domain
        relativeRoot = [string]$scope.relativeRoot
        baselineCount = [int]$scope.baselineCount
        currentCount = $scopeRecords.Count
        contentTypes = [ordered]@{
            conceptual = Get-RecordCount -Records $scopeRecords -Property "contentType" -Value "conceptual"
            schema = Get-RecordCount -Records $scopeRecords -Property "contentType" -Value "schema"
            api = Get-RecordCount -Records $scopeRecords -Property "contentType" -Value "api"
            example = Get-RecordCount -Records $scopeRecords -Property "contentType" -Value "example"
            legacy = Get-RecordCount -Records $scopeRecords -Property "contentType" -Value "legacy"
        }
    })
}

$connectorCount = Get-RecordCount -Records $recordArray -Property "domain" -Value "Connector"
$automationCount = Get-RecordCount -Records $recordArray -Property "domain" -Value "Automation"
$conceptualCount = Get-RecordCount -Records $recordArray -Property "contentType" -Value "conceptual"
$schemaCount = Get-RecordCount -Records $recordArray -Property "contentType" -Value "schema"
$apiCount = Get-RecordCount -Records $recordArray -Property "contentType" -Value "api"
$exampleCount = Get-RecordCount -Records $recordArray -Property "contentType" -Value "example"
$legacyCount = Get-RecordCount -Records $recordArray -Property "contentType" -Value "legacy"
$unknownVersionCount = Get-RecordCount -Records $recordArray -Property "version" -Value "unknown"
$unknownAuthorityCount = Get-RecordCount -Records $recordArray -Property "authority" -Value "unknown"
$scopeSummaryArray = [object[]]$scopeSummary.ToArray()
$unicodeNormalizedAdditions = @()
foreach ($addition in @($manifest.baseline.unicodeNormalizedAdditions)) {
    $unicodeNormalizedAdditions += [string]$addition
}

$report = [ordered]@{
    schemaVersion = $script:ReportSchemaVersion
    generator = [ordered]@{
        name = "scripts/migrate-documentation-metadata.ps1"
        version = $script:GeneratorVersion
    }
    migration = "D2.2"
    migrationDate = [string]$manifest.migrationDate
    baseline = [ordered]@{
        id = [string]$manifest.baseline.id
        sourceRevision = [string]$manifest.baseline.sourceRevision
        sourcePageCount = [int]$manifest.baseline.sourcePageCount
        currentPageCount = $targetFiles.Count
        delta = $targetFiles.Count - [int]$manifest.baseline.sourcePageCount
        staleTrackerCount = [int]$manifest.baseline.staleTrackerCount
        staleTrackerDiscrepancy = $targetFiles.Count - [int]$manifest.baseline.staleTrackerCount
        unicodeNormalizedAdditions = $unicodeNormalizedAdditions
    }
    coverage = [ordered]@{
        totalPages = $recordArray.Count
        domains = [ordered]@{
            Connector = $connectorCount
            Automation = $automationCount
        }
        contentTypes = [ordered]@{
            conceptual = $conceptualCount
            schema = $schemaCount
            api = $apiCount
            example = $exampleCount
            legacy = $legacyCount
        }
        metadataVersion1 = $recordArray.Count
        unknownVersions = $unknownVersionCount
        unknownAuthorities = $unknownAuthorityCount
    }
    toc = [ordered]@{
        path = "develop/toc.yml"
        sha256 = $tocHash
        changedByMigration = $false
    }
    scopes = $scopeSummaryArray
    pages = $recordArray
}

$validatorArguments = @{
    RepositoryRoot = $script:RepositoryRoot
    SchemaPath = $SchemaPath
    Path = @($targetFiles | ForEach-Object { $_.File.FullName })
    RequireVersion1 = $true
}
& $ValidatorPath @validatorArguments | Out-Null

$json = $report | ConvertTo-Json -Depth 8
if (-not $CheckOnly) {
    [void](Write-TextIfChanged -Path $ReportPath -Text ($json + "`n"))
}

Write-Output "D2.2 metadata migration scope: $($targetFiles.Count) pages."
Write-Output "Version 1 pages: $($records.Count)."
Write-Output "Changed pages: $changedCount."
Write-Output "Unknown versions requiring follow-up: $($report.coverage.unknownVersions)."
