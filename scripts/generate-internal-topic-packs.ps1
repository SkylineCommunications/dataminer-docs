[CmdletBinding()]
param(
    [string]$RepositoryRoot = (Join-Path $PSScriptRoot ".."),
    [string]$ManifestPath = (Join-Path $PSScriptRoot "..\_artifacts\ai-content-manifest.json"),
    [string]$OutputPath = (Join-Path $PSScriptRoot "..\_artifacts\internal-only-topic-packs"),
    [string]$SchemaPath = (Join-Path $PSScriptRoot "..\contributing\metadata\internal-topic-pack-v1.schema.json"),
    [string]$ValidatorPath = (Join-Path $PSScriptRoot "validate-internal-topic-packs.ps1"),
    [string]$GenerationDate = "",
    [string]$SourceRevision = ""
)

Set-StrictMode -Version 2.0
$ErrorActionPreference = "Stop"

$script:GeneratorVersion = "1.0.0"
$script:SchemaVersion = 1
$script:SchemaName = "contributing/metadata/internal-topic-pack-v1.schema.json"
$script:Repository = "SkylineCommunications/dataminer-docs"
$script:LicenseIdentifier = "CC BY-NC-ND 4.0"
$script:LicenseName = "Creative Commons Attribution-NonCommercial-NoDerivatives 4.0 International"
$script:LicenseUrl = "https://creativecommons.org/licenses/by-nc-nd/4.0/"
$script:Attribution = "Skyline Communications"
$script:PolicyId = "D0.3"
$script:PolicySource = "contributing/CTB_Documentation_Corpus_Policy.md"
$script:PackRootName = "internal-only-topic-packs"

function Assert-Condition {
    param(
        [Parameter(Mandatory = $true)][bool]$Condition,
        [Parameter(Mandatory = $true)][string]$Message
    )

    if (-not $Condition) {
        throw $Message
    }
}

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
    $rootPath = [IO.Path]::GetFullPath($Root).TrimEnd("\")
    $prefix = $rootPath + "\"
    if ($fullPath.StartsWith($prefix, [StringComparison]::OrdinalIgnoreCase)) {
        return $fullPath.Substring($prefix.Length).Replace("\", "/")
    }

    if ($fullPath.Equals($rootPath, [StringComparison]::OrdinalIgnoreCase)) {
        return ""
    }

    return $null
}

function ConvertTo-PortablePath {
    param([Parameter(Mandatory = $true)][string]$Path)

    return $Path.Replace("\", "/")
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

function Get-FileSha256 {
    param([Parameter(Mandatory = $true)][string]$Path)

    return (Get-FileHash -LiteralPath $Path -Algorithm SHA256).Hash.ToLowerInvariant()
}

function Get-StringProperty {
    param(
        [Parameter(Mandatory = $true)]$Object,
        [Parameter(Mandatory = $true)][string]$Name,
        [AllowEmptyString()][string]$Default = ""
    )

    if ($null -eq $Object) {
        return $Default
    }

    if ($Object -is [System.Collections.IDictionary]) {
        if (-not $Object.Contains($Name) -or $null -eq $Object[$Name]) {
            return $Default
        }
        return [string]$Object[$Name]
    }

    if (@($Object.PSObject.Properties.Name) -contains $Name) {
        if ($null -eq $Object.$Name) {
            return $Default
        }
        return [string]$Object.$Name
    }

    return $Default
}

function Get-StringArray {
    param([AllowNull()]$Value)

    if ($null -eq $Value) {
        return @()
    }
    if ($Value -is [string]) {
        if ([String]::IsNullOrWhiteSpace([string]$Value)) {
            return @()
        }
        return @([string]$Value)
    }

    return @(
        $Value |
            ForEach-Object { [string]$_ } |
            Where-Object { -not [String]::IsNullOrWhiteSpace($_) }
    )
}

function Assert-Properties {
    param(
        [Parameter(Mandatory = $true)]$Object,
        [Parameter(Mandatory = $true)][string[]]$Required,
        [Parameter(Mandatory = $true)][string[]]$Allowed,
        [Parameter(Mandatory = $true)][string]$Context
    )

    Assert-Condition ($null -ne $Object) "$Context is missing."
    $properties = @($Object.PSObject.Properties.Name)
    foreach ($name in $Required) {
        Assert-Condition ($properties -contains $name) "$Context is missing '$name'."
    }
    foreach ($name in $properties) {
        Assert-Condition ($Allowed -contains $name) "$Context contains undocumented property '$name'."
    }
}

function Get-MarkdownParts {
    param([Parameter(Mandatory = $true)][string]$Text)

    $normalized = Normalize-Text $Text
    $frontMatter = ""
    $body = $normalized
    $bodyStartLine = 1
    $match = [Regex]::Match(
        $normalized,
        "\A---\n(?<front>.*?)\n---(?:\n|\z)",
        [Text.RegularExpressions.RegexOptions]::Singleline
    )
    if ($match.Success) {
        $frontMatter = $match.Groups["front"].Value
        $body = $normalized.Substring($match.Length)
        $bodyStartLine = 1 + [Regex]::Matches($normalized.Substring(0, $match.Length), "`n").Count
    }

    return [PSCustomObject]@{
        FrontMatter = $frontMatter
        Body = $body
        BodyStartLine = $bodyStartLine
    }
}

function Get-HeadingText {
    param([Parameter(Mandatory = $true)][string]$Value)

    $text = $Value.Trim()
    $text = [Regex]::Replace($text, "\s+#+\s*$", "")
    return $text.Trim()
}

function Get-HeadingAnchor {
    param([Parameter(Mandatory = $true)][string]$Value)

    $text = Get-HeadingText $Value
    $text = $text.Replace(([char]96).ToString(), "").Replace("*", "").Replace("_", "")
    $text = $text.ToLowerInvariant()
    $text = [Regex]::Replace($text, "[^a-z0-9\s-]", "")
    $text = [Regex]::Replace($text, "\s+", "-")
    $text = [Regex]::Replace($text, "-+", "-").Trim("-")
    if ([String]::IsNullOrWhiteSpace($text)) {
        return "section"
    }
    return $text
}

function Get-Headings {
    param([AllowEmptyString()][AllowEmptyCollection()][string[]]$Lines)

    $headings = New-Object "System.Collections.Generic.List[object]"
    $inFence = $false
    $fenceMarker = ""
    for ($index = 0; $index -lt $Lines.Count; $index++) {
        $line = $Lines[$index]
        $fenceMatch = [Regex]::Match($line, ("^\s*(?<marker>" + [char]96 + "{3,}|~{3,})"))
        if ($fenceMatch.Success) {
            $marker = $fenceMatch.Groups["marker"].Value.Substring(0, 3)
            if (-not $inFence) {
                $inFence = $true
                $fenceMarker = $marker
            }
            elseif ($marker[0] -eq $fenceMarker[0]) {
                $inFence = $false
                $fenceMarker = ""
            }
            continue
        }
        if ($inFence) {
            continue
        }

        $headingMatch = [Regex]::Match($line, "^\s{0,3}(?<hashes>#{1,6})[ \t]+(?<text>.+?)\s*$")
        if ($headingMatch.Success) {
            $headingText = Get-HeadingText $headingMatch.Groups["text"].Value
            [void]$headings.Add([PSCustomObject]@{
                    Index = $index
                    Level = $headingMatch.Groups["hashes"].Value.Length
                    Text = $headingText
                    Anchor = Get-HeadingAnchor $headingText
                })
        }
    }

    return @($headings.ToArray())
}

function Test-RootSectionContent {
    param([AllowEmptyString()][AllowEmptyCollection()][string[]]$Lines)

    foreach ($line in $Lines) {
        if ([String]::IsNullOrWhiteSpace($line)) {
            continue
        }
        if ($line -match "^\s{0,3}#{1,6}[ \t]+") {
            continue
        }
        return $true
    }
    return $false
}

function Get-SourceSections {
    param(
        [Parameter(Mandatory = $true)][string]$Body,
        [Parameter(Mandatory = $true)][string]$Uid,
        [Parameter(Mandatory = $true)][string]$SourceTitle,
        [Parameter(Mandatory = $true)][int]$BodyStartLine
    )

    $lines = @((Normalize-Text $Body) -split "`n")
    $headings = @()
    if ($lines.Count -gt 0 -and -not ($lines.Count -eq 1 -and [String]::IsNullOrEmpty([string]$lines[0]))) {
        $headings = @(Get-Headings -Lines $lines)
    }
    $headingAnchors = @{}
    $usedHeadingAnchors = @{}
    foreach ($heading in $headings) {
        $anchor = [string]$heading.Anchor
        if ($usedHeadingAnchors.ContainsKey($anchor)) {
            $usedHeadingAnchors[$anchor]++
            $anchor = "$anchor-$($usedHeadingAnchors[$anchor])"
        }
        else {
            $usedHeadingAnchors[$anchor] = 1
        }
        $headingAnchors[[int]$heading.Index] = $anchor
    }
    $h2Headings = @($headings | Where-Object { $_.Level -eq 2 })
    $sections = New-Object "System.Collections.Generic.List[object]"

    if ($h2Headings.Count -eq 0) {
        [void]$sections.Add([PSCustomObject]@{
                Index = 0
                StartLine = 0
                EndLine = $lines.Count
                Title = $SourceTitle
                Anchor = "page"
                Identity = "$Uid#page"
                Body = ($lines -join "`n")
            })
    }

    if ($h2Headings.Count -gt 0) {
        $firstH2Index = [int]$h2Headings[0].Index
        if ($firstH2Index -gt 0) {
            $rootLines = @($lines | Select-Object -First $firstH2Index)
            if (Test-RootSectionContent -Lines $rootLines) {
                [void]$sections.Add([PSCustomObject]@{
                        Index = $sections.Count
                        StartLine = 0
                        EndLine = $firstH2Index
                        Title = $SourceTitle
                        Anchor = "page"
                        Identity = "$Uid#page"
                        Body = ($rootLines -join "`n")
                    })
            }
        }

        for ($index = 0; $index -lt $h2Headings.Count; $index++) {
            $heading = $h2Headings[$index]
            $endLine = if ($index + 1 -lt $h2Headings.Count) {
                [int]$h2Headings[$index + 1].Index
            }
            else {
                $lines.Count
            }
            $anchor = [string]$headingAnchors[[int]$heading.Index]
            $sectionLines = @($lines | Select-Object -Skip $heading.Index -First ($endLine - $heading.Index))
            [void]$sections.Add([PSCustomObject]@{
                    Index = $sections.Count
                    StartLine = [int]$heading.Index
                    EndLine = $endLine
                    Title = [string]$heading.Text
                    Anchor = $anchor
                    Identity = "$Uid#$anchor"
                    Body = ($sectionLines -join "`n")
                })
        }
    }

    if ($sections.Count -eq 0) {
        [void]$sections.Add([PSCustomObject]@{
                Index = 0
                StartLine = 0
                EndLine = $lines.Count
                Title = $SourceTitle
                Anchor = "page"
                Identity = "$Uid#page"
                Body = ($lines -join "`n")
            })
    }

    foreach ($section in $sections) {
        $sectionAnchors = New-Object "System.Collections.Generic.List[string]"
        if ($section.Anchor -eq "page") {
            [void]$sectionAnchors.Add("page")
        }
        foreach ($heading in $headings) {
            if ([int]$heading.Index -ge [int]$section.StartLine -and [int]$heading.Index -lt [int]$section.EndLine) {
                $anchor = [string]$headingAnchors[[int]$heading.Index]
                if (-not [String]::IsNullOrWhiteSpace($anchor) -and -not $sectionAnchors.Contains($anchor)) {
                    [void]$sectionAnchors.Add($anchor)
                }
            }
        }
        [void]($section | Add-Member -NotePropertyName Anchors -NotePropertyValue @($sectionAnchors.ToArray()))
        [void]($section | Add-Member -NotePropertyName SourceStartLine -NotePropertyValue ($BodyStartLine + $section.StartLine))
        [void]($section | Add-Member -NotePropertyName SourceEndLine -NotePropertyValue ($BodyStartLine + [Math]::Max($section.StartLine, $section.EndLine - 1)))
    }

    return @($sections.ToArray())
}

function Get-SafeFileSegment {
    param([Parameter(Mandatory = $true)][string]$Value)

    $safe = $Value.ToLowerInvariant()
    $safe = [Regex]::Replace($safe, "[^a-z0-9._-]+", "-")
    $safe = [Regex]::Replace($safe, "-+", "-")
    $safe = [Regex]::Replace($safe, "^[.-]+|[.-]+$", "")
    if ([String]::IsNullOrWhiteSpace($safe)) {
        $safe = "page"
    }
    if ($safe.Length -gt 56) {
        $safe = $safe.Substring(0, 56).Trim("-", ".")
    }
    if ([String]::IsNullOrWhiteSpace($safe)) {
        return "page"
    }
    return $safe
}

function Get-RelativeUrl {
    param(
        [Parameter(Mandatory = $true)][string]$FromPath,
        [Parameter(Mandatory = $true)][string]$ToPath
    )

    $fromPortable = ConvertTo-PortablePath $FromPath
    $toPortable = ConvertTo-PortablePath $ToPath
    $fromDirectory = ""
    $lastSlash = $fromPortable.LastIndexOf("/")
    if ($lastSlash -ge 0) {
        $fromDirectory = $fromPortable.Substring(0, $lastSlash)
    }
    $fromParts = @($fromDirectory -split "/" | Where-Object { $_ -ne "" })
    $toParts = @($toPortable -split "/" | Where-Object { $_ -ne "" })
    $common = 0
    while ($common -lt $fromParts.Count -and $common -lt $toParts.Count -and
        $fromParts[$common].Equals($toParts[$common], [StringComparison]::OrdinalIgnoreCase)) {
        [void]($common++)
    }
    $parts = New-Object "System.Collections.Generic.List[string]"
    for ($index = $common; $index -lt $fromParts.Count; $index++) {
            [void]$parts.Add("..")
    }
    for ($index = $common; $index -lt $toParts.Count; $index++) {
        [void]$parts.Add($toParts[$index])
    }
    if ($parts.Count -eq 0) {
        return "."
    }
    return ($parts.ToArray() -join "/")
}

function Get-GenerationDateInfo {
    param(
        [Parameter(Mandatory = $true)][string]$Root,
        [Parameter(Mandatory = $true)][string]$Revision,
        [AllowEmptyString()][string]$RequestedDate
    )

    if (-not [String]::IsNullOrWhiteSpace($RequestedDate)) {
        $date = $RequestedDate.Trim()
        Assert-Condition ($date -match "^\d{4}-\d{2}-\d{2}$") "Generation date '$date' is not an ISO date."
        return [ordered]@{
            generatedAt = $date
            generatedAtSource = "argument"
        }
    }

    $epoch = [Environment]::GetEnvironmentVariable("SOURCE_DATE_EPOCH")
    if (-not [String]::IsNullOrWhiteSpace($epoch)) {
        $seconds = 0L
        if ([Int64]::TryParse($epoch, [Globalization.NumberStyles]::Integer, [Globalization.CultureInfo]::InvariantCulture, [ref]$seconds)) {
            try {
                $date = [DateTimeOffset]::FromUnixTimeSeconds($seconds).UtcDateTime.ToString("yyyy-MM-dd", [Globalization.CultureInfo]::InvariantCulture)
                return [ordered]@{
                    generatedAt = $date
                    generatedAtSource = "source_date_epoch"
                }
            }
            catch {
                # Fall through to the immutable commit date.
            }
        }
    }

    try {
        $gitDate = & git -C $Root show -s --format=%cs $Revision 2>$null
        if ($LASTEXITCODE -eq 0 -and -not [String]::IsNullOrWhiteSpace(($gitDate -join ""))) {
            $date = (($gitDate -join "`n").Trim())
            if ($date -match "^\d{4}-\d{2}-\d{2}$") {
                return [ordered]@{
                    generatedAt = $date
                    generatedAtSource = "git_commit"
                }
            }
        }
    }
    catch {
        # A fixture may intentionally use a revision that is not in a Git checkout.
    }

    return [ordered]@{
        generatedAt = "unknown"
        generatedAtSource = "unknown"
    }
}

function Quote-YamlScalar {
    param([AllowEmptyString()][string]$Value)

    if ($null -eq $Value) {
        $Value = ""
    }
    $escaped = $Value.Replace("\", "\\").Replace('"', '\"').Replace("`r", "\r").Replace("`n", "\n")
    return '"' + $escaped + '"'
}

function Write-Text {
    param(
        [Parameter(Mandatory = $true)][string]$Path,
        [Parameter(Mandatory = $true)][string]$Text
    )

    $directory = Split-Path -Parent $Path
    if (-not (Test-Path -LiteralPath $directory -PathType Container)) {
        New-Item -ItemType Directory -Path $directory -Force | Out-Null
    }
    $utf8NoBom = New-Object Text.UTF8Encoding($false)
    [IO.File]::WriteAllText($Path, $Text, $utf8NoBom)
}

function Write-Json {
    param(
        [Parameter(Mandatory = $true)][string]$Path,
        [Parameter(Mandatory = $true)]$Value
    )

    Write-Text -Path $Path -Text (($Value | ConvertTo-Json -Depth 30) + [Environment]::NewLine)
}

function New-ChunkFrontMatter {
    param(
        [Parameter(Mandatory = $true)]$Chunk,
        [Parameter(Mandatory = $true)][string]$ManifestRelativePath,
        [Parameter(Mandatory = $true)][string]$ChunkContentHash,
        [Parameter(Mandatory = $true)][int]$ResolvedLinkCount,
        [Parameter(Mandatory = $true)][int]$UnresolvedLinkCount
    )

    $lines = New-Object "System.Collections.Generic.List[string]"
    [void]$lines.Add("---")
    [void]$lines.Add("topic_pack_schema_version: 1")
    [void]$lines.Add("visibility: internal-only")
    [void]$lines.Add("policy: " + (Quote-YamlScalar $script:PolicyId))
    [void]$lines.Add("policy_source: " + (Quote-YamlScalar $script:PolicySource))
    [void]$lines.Add("source_manifest: " + (Quote-YamlScalar $ManifestRelativePath))
    [void]$lines.Add("domain: " + (Quote-YamlScalar $Chunk.Domain))
    [void]$lines.Add("source_uid: " + (Quote-YamlScalar $Chunk.SourceUid))
    [void]$lines.Add("source_url: " + (Quote-YamlScalar $Chunk.SourceUrl))
    [void]$lines.Add("source_path: " + (Quote-YamlScalar $Chunk.SourcePath))
    [void]$lines.Add("source_commit: " + (Quote-YamlScalar $Chunk.SourceCommit))
    [void]$lines.Add("source_blob: " + (Quote-YamlScalar $Chunk.SourceBlob))
    [void]$lines.Add("source_content_hash: " + (Quote-YamlScalar $Chunk.SourceContentHash))
    [void]$lines.Add("source_section_hash: " + (Quote-YamlScalar $Chunk.SourceSectionHash))
    [void]$lines.Add("source_section_identity: " + (Quote-YamlScalar $Chunk.SourceSectionIdentity))
    [void]$lines.Add("source_section_title: " + (Quote-YamlScalar $Chunk.SourceSectionTitle))
    [void]$lines.Add("chunk_id: " + (Quote-YamlScalar $Chunk.Id))
    [void]$lines.Add("content_identity: " + (Quote-YamlScalar $Chunk.IdentityHash))
    [void]$lines.Add("chunk_index: $($Chunk.Index)")
    [void]$lines.Add("chunk_count: $($Chunk.Count)")
    [void]$lines.Add("chunk_content_hash: " + (Quote-YamlScalar $ChunkContentHash))
    [void]$lines.Add("content_type: " + (Quote-YamlScalar $Chunk.ContentType))
    [void]$lines.Add("authority: " + (Quote-YamlScalar $Chunk.Authority))
    [void]$lines.Add("lifecycle: " + (Quote-YamlScalar $Chunk.Lifecycle))
    [void]$lines.Add("license: " + (Quote-YamlScalar $script:LicenseIdentifier))
    [void]$lines.Add("attribution: " + (Quote-YamlScalar $script:Attribution))
    [void]$lines.Add("resolved_link_count: $ResolvedLinkCount")
    [void]$lines.Add("unresolved_link_count: $UnresolvedLinkCount")
    [void]$lines.Add("---")
    return ($lines.ToArray() -join "`n")
}

function Add-UnresolvedLink {
    param(
        [Parameter(Mandatory = $true)]$State,
        [Parameter(Mandatory = $true)]$Chunk,
        [Parameter(Mandatory = $true)][string]$Kind,
        [Parameter(Mandatory = $true)][string]$Target,
        [Parameter(Mandatory = $true)][string]$Reason,
        [Parameter(Mandatory = $true)][int]$SourceLine,
        [Parameter(Mandatory = $true)][int]$Ordinal
    )

    $idInput = "$($Chunk.Id)|$Kind|$Target|$Reason|$SourceLine|$Ordinal"
    $id = "unresolved-" + (Get-TextSha256 $idInput).Substring(0, 20)
    $record = [ordered]@{
        id = $id
        chunkId = $Chunk.Id
        sourceUid = $Chunk.SourceUid
        sourcePath = $Chunk.SourcePath
        sourceSectionIdentity = $Chunk.SourceSectionIdentity
        sourceLine = $SourceLine
        kind = $Kind
        target = $Target
        reason = $Reason
    }
    [void]$State.Unresolved.Add([PSCustomObject]$record)
    return [PSCustomObject]$record
}

function Get-LinkTarget {
    param(
        [Parameter(Mandatory = $true)][string]$Target,
        [Parameter(Mandatory = $true)]$Page,
        [Parameter(Mandatory = $true)]$Chunk,
        [Parameter(Mandatory = $true)]$PagesByPath,
        [Parameter(Mandatory = $true)]$PagesByUid,
        [Parameter(Mandatory = $true)]$State,
        [Parameter(Mandatory = $true)][int]$SourceLine,
        [Parameter(Mandatory = $true)][int]$Ordinal
    )

    $value = $Target.Trim()
    if ($value.StartsWith("<") -and $value.EndsWith(">")) {
        $value = $value.Substring(1, $value.Length - 2)
    }
    try {
        $value = [Uri]::UnescapeDataString($value)
    }
    catch {
        # Preserve and report malformed percent-encoded destinations.
    }

    $fragment = ""
    $base = $value
    $fragmentIndex = $value.IndexOf("#")
    if ($fragmentIndex -ge 0) {
        $base = $value.Substring(0, $fragmentIndex)
        $fragment = $value.Substring($fragmentIndex + 1)
    }

    $targetPage = $null
    $kind = "local"
    if ($base -match "^xref:(?<uid>[^#]+)$") {
        $kind = "xref"
        $targetUid = $Matches["uid"]
        $candidates = @()
        if ($PagesByUid.ContainsKey($targetUid)) {
            $candidates = @($PagesByUid[$targetUid].ToArray())
        }
        if ($candidates.Count -eq 0) {
            return [PSCustomObject]@{
                Resolved = $false
                Value = $Target
                Unresolved = Add-UnresolvedLink -State $State -Chunk $Chunk -Kind $kind -Target $Target -Reason "target-not-in-pack" -SourceLine $SourceLine -Ordinal $Ordinal
            }
        }
        if ($candidates.Count -ne 1) {
            return [PSCustomObject]@{
                Resolved = $false
                Value = $Target
                Unresolved = Add-UnresolvedLink -State $State -Chunk $Chunk -Kind $kind -Target $Target -Reason "ambiguous-target-uid" -SourceLine $SourceLine -Ordinal $Ordinal
            }
        }
        $targetPage = $candidates[0]
    }
    elseif ([String]::IsNullOrWhiteSpace($base) -and -not [String]::IsNullOrWhiteSpace($fragment)) {
        $kind = "anchor"
        $targetPage = $Page
    }
    elseif ($base -match "(?i)^(?:https?|mailto|ftp|data):") {
        return [PSCustomObject]@{
            Resolved = $false
            Value = $Target
            External = $true
        }
    }
    elseif ([String]::IsNullOrWhiteSpace($base)) {
        return [PSCustomObject]@{
            Resolved = $false
            Value = $Target
            External = $true
        }
    }
    elseif ($base -match "(?i)\.(?:md|markdown|html?)$" -or $base.StartsWith("/") -or $base.StartsWith("./") -or $base.StartsWith("../")) {
        $candidatePath = $base.Replace("\", "/")
        if ($candidatePath.StartsWith("/")) {
            $candidatePath = $candidatePath.TrimStart("/")
        }
        elseif (-not $candidatePath.Contains("/") -or $candidatePath.StartsWith("./") -or $candidatePath.StartsWith("../")) {
            $sourceDirectory = [IO.Path]::GetDirectoryName($Page.SourcePath).Replace("\", "/")
            if (-not [String]::IsNullOrWhiteSpace($sourceDirectory)) {
                $candidatePath = "$sourceDirectory/$candidatePath"
            }
        }
        $segments = New-Object "System.Collections.Generic.List[string]"
        $escapedRoot = $false
        foreach ($segment in @($candidatePath -split "/")) {
            if ([String]::IsNullOrWhiteSpace($segment) -or $segment -eq ".") {
                continue
            }
            if ($segment -eq "..") {
                if ($segments.Count -eq 0) {
                    $escapedRoot = $true
                    break
                }
                $segments.RemoveAt($segments.Count - 1)
                continue
            }
            [void]$segments.Add($segment)
        }
        if ($escapedRoot) {
            return [PSCustomObject]@{
                Resolved = $false
                Value = $Target
                Unresolved = Add-UnresolvedLink -State $State -Chunk $Chunk -Kind "local" -Target $Target -Reason "target-outside-repository" -SourceLine $SourceLine -Ordinal $Ordinal
            }
        }
        $candidatePath = $segments.ToArray() -join "/"
        if ($candidatePath -match "(?i)\.html?$") {
            $candidatePath = [Regex]::Replace($candidatePath, "(?i)\.html?$", ".md")
        }
        if (-not $PagesByPath.ContainsKey($candidatePath)) {
            return [PSCustomObject]@{
                Resolved = $false
                Value = $Target
                Unresolved = Add-UnresolvedLink -State $State -Chunk $Chunk -Kind "local" -Target $Target -Reason "target-not-in-pack" -SourceLine $SourceLine -Ordinal $Ordinal
            }
        }
        $targetPage = $PagesByPath[$candidatePath]
    }
    else {
        if ($base -notmatch "[:?]" -and -not $base.StartsWith("//")) {
            return [PSCustomObject]@{
                Resolved = $false
                Value = $Target
                Unresolved = Add-UnresolvedLink -State $State -Chunk $Chunk -Kind "local" -Target $Target -Reason "target-not-in-pack" -SourceLine $SourceLine -Ordinal $Ordinal
            }
        }
        return [PSCustomObject]@{
            Resolved = $false
            Value = $Target
            External = $true
        }
    }

    $targetChunk = $targetPage.RootChunk
    if (-not [String]::IsNullOrWhiteSpace($fragment)) {
        $fragmentValues = @(
            $fragment.TrimStart("#").ToLowerInvariant()
            Get-HeadingAnchor $fragment
        ) | Sort-Object -Unique
        $sectionCandidates = @($targetPage.Chunks | Where-Object {
                @($_.SectionAnchors | Where-Object { $fragmentValues -contains ([string]$_).ToLowerInvariant() }).Count -gt 0
            })
        if ($null -eq $sectionCandidates) {
            $sectionCandidates = @()
        }
        if ($sectionCandidates.Count -ne 1) {
            return [PSCustomObject]@{
                Resolved = $false
                Value = $Target
                Unresolved = Add-UnresolvedLink -State $State -Chunk $Chunk -Kind $kind -Target $Target -Reason "target-section-not-in-pack" -SourceLine $SourceLine -Ordinal $Ordinal
            }
        }
        $targetChunk = $sectionCandidates[0]
    }

    $relative = Get-RelativeUrl -FromPath $Chunk.RelativePath -ToPath $targetChunk.RelativePath
    if (-not [String]::IsNullOrWhiteSpace($fragment)) {
        $resolvedFragment = @($targetChunk.SectionAnchors | Where-Object {
                $fragmentValues -contains ([string]$_).ToLowerInvariant()
            } | Select-Object -First 1)
        if ($resolvedFragment.Count -eq 0) {
            $resolvedFragment = @((Get-HeadingAnchor $fragment))
        }
        $relative += "#" + [string]$resolvedFragment[0]
    }
    return [PSCustomObject]@{
        Resolved = $true
        Value = $relative
        Link = [ordered]@{
            kind = $kind
            original = $Target
            target = $relative
            sourceLine = $SourceLine
        }
    }
}

function Resolve-Links {
    param(
        [Parameter(Mandatory = $true)][string]$Body,
        [Parameter(Mandatory = $true)]$Page,
        [Parameter(Mandatory = $true)]$Chunk,
        [Parameter(Mandatory = $true)]$PagesByPath,
        [Parameter(Mandatory = $true)]$PagesByUid,
        [Parameter(Mandatory = $true)]$State
    )

    $lines = @((Normalize-Text $Body) -split "`n")
    $resolved = New-Object "System.Collections.Generic.List[object]"
    $unresolved = New-Object "System.Collections.Generic.List[object]"
    $ordinal = 0
    $inFence = $false
    $fenceMarker = ""

    for ($index = 0; $index -lt $lines.Count; $index++) {
        $line = $lines[$index]
        $fenceMatch = [Regex]::Match($line, ("^\s*(?<marker>" + [char]96 + "{3,}|~{3,})"))
        if ($fenceMatch.Success) {
            $marker = $fenceMatch.Groups["marker"].Value.Substring(0, 3)
            if (-not $inFence) {
                $inFence = $true
                $fenceMarker = $marker
            }
            elseif ($marker[0] -eq $fenceMarker[0]) {
                $inFence = $false
                $fenceMarker = ""
            }
            continue
        }
        if ($inFence) {
            continue
        }

        $sourceLine = $Chunk.SourceStartLine + $index
        $rewritten = $line
        $markdownMatches = @([Regex]::Matches($rewritten, "\]\((?<inside><[^>]*>|[^)]*)\)"))
        for ($matchIndex = $markdownMatches.Count - 1; $matchIndex -ge 0; $matchIndex--) {
            $match = $markdownMatches[$matchIndex]
            $inside = $match.Groups["inside"].Value
            $destination = $inside
            $tail = ""
            if ($inside.StartsWith("<")) {
                $close = $inside.IndexOf(">")
                if ($close -ge 0) {
                    $destination = $inside.Substring(1, $close - 1)
                    $tail = $inside.Substring($close + 1)
                }
            }
            else {
                $space = [Regex]::Match($inside, "^\S+")
                if ($space.Success) {
                    $destination = $space.Value
                    $tail = $inside.Substring($space.Length)
                }
            }
            if ([String]::IsNullOrWhiteSpace($destination)) {
                continue
            }
            $result = Get-LinkTarget -Target $destination -Page $Page -Chunk $Chunk -PagesByPath $PagesByPath -PagesByUid $PagesByUid -State $State -SourceLine $sourceLine -Ordinal $ordinal
            [void]($ordinal++)
            if (@($result.PSObject.Properties.Name) -contains "Unresolved" -and $null -ne $result.Unresolved) {
                [void]$unresolved.Add($result.Unresolved)
            }
            if ($result.Resolved) {
                [void]$resolved.Add($result.Link)
                $replacement = "](" + $result.Value + $tail + ")"
                $rewritten = $rewritten.Remove($match.Index, $match.Length).Insert($match.Index, $replacement)
            }
        }

        $htmlPattern = "(?i)(?<prefix>\bhref\s*=\s*[""'])(?<destination>[^""']+)(?<suffix>[""'])"
        $htmlMatches = @([Regex]::Matches($rewritten, $htmlPattern))
        for ($matchIndex = $htmlMatches.Count - 1; $matchIndex -ge 0; $matchIndex--) {
            $match = $htmlMatches[$matchIndex]
            $destination = $match.Groups["destination"].Value
            $result = Get-LinkTarget -Target $destination -Page $Page -Chunk $Chunk -PagesByPath $PagesByPath -PagesByUid $PagesByUid -State $State -SourceLine $sourceLine -Ordinal $ordinal
            [void]($ordinal++)
            if (@($result.PSObject.Properties.Name) -contains "Unresolved" -and $null -ne $result.Unresolved) {
                [void]$unresolved.Add($result.Unresolved)
            }
            if ($result.Resolved) {
                [void]$resolved.Add($result.Link)
                $replacement = $match.Groups["prefix"].Value + $result.Value + $match.Groups["suffix"].Value
                $rewritten = $rewritten.Remove($match.Index, $match.Length).Insert($match.Index, $replacement)
            }
        }
        $lines[$index] = $rewritten
    }

    return [PSCustomObject]@{
        Body = ($lines -join "`n")
        Resolved = @($resolved.ToArray())
        Unresolved = @($unresolved.ToArray())
    }
}

function Get-SourceTitle {
    param(
        [Parameter(Mandatory = $true)][string]$Body,
        [Parameter(Mandatory = $true)][string]$Fallback
    )

    $lines = @((Normalize-Text $Body) -split "`n")
    foreach ($line in $lines) {
        if ($line -match "^\s{0,3}#\s+(?<title>.+?)\s*$") {
            return Get-HeadingText $Matches["title"]
        }
    }
    return $Fallback
}

function New-ChunkFileName {
    param(
        [Parameter(Mandatory = $true)][string]$Uid,
        [Parameter(Mandatory = $true)][string]$SourcePath,
        [Parameter(Mandatory = $true)][int]$SectionIndex,
        [Parameter(Mandatory = $true)][string]$IdentityHash
    )

    $safeUid = Get-SafeFileSegment $Uid
    $pathHash = (Get-TextSha256 $SourcePath).Substring(0, 12)
    return "internal-only-$safeUid-$pathHash-s{0:D4}-{1}.md" -f $SectionIndex, $IdentityHash.Substring(0, 12)
}

function New-ManifestEntry {
    param([Parameter(Mandatory = $true)]$Entry)

    Assert-Condition (-not [String]::IsNullOrWhiteSpace([string]$Entry.uid)) "A pack source entry has no stable UID."
    Assert-Condition (-not [String]::IsNullOrWhiteSpace([string]$Entry.sourcePath)) "Pack entry '$($Entry.uid)' has no source path."
    $sourcePath = ConvertTo-PortablePath ([string]$Entry.sourcePath)
    Assert-Condition (-not [IO.Path]::IsPathRooted($sourcePath)) "Pack source path '$sourcePath' is absolute."
    Assert-Condition ($sourcePath -notmatch "(^|/)\.\.(?:/|$)") "Pack source path '$sourcePath' escapes the repository."
    Assert-Condition ($sourcePath -match "(?i)\.md$") "Pack source path '$sourcePath' is not Markdown."
    Assert-Condition ([string]$Entry.sourceCommit -match "^[0-9a-f]{40}$") "Pack source '$sourcePath' has no immutable full commit."
    Assert-Condition ([string]$Entry.contentHash -match "^[0-9a-f]{64}$") "Pack source '$sourcePath' has no valid content hash."
    Assert-Condition ([string]$Entry.sourceBlob -match "^https://github\.com/SkylineCommunications/dataminer-docs/blob/[0-9a-f]{40}/.+$") "Pack source '$sourcePath' has no immutable source blob."
    Assert-Condition ([string]$Entry.license -eq $script:LicenseIdentifier) "Pack source '$sourcePath' has an invalid license."
    Assert-Condition ([string]$Entry.attribution -eq $script:Attribution) "Pack source '$sourcePath' has invalid attribution."

    return [PSCustomObject]@{
        Domain = [string]$Entry.domain
        SourceUid = [string]$Entry.uid
        SourcePath = $sourcePath
        SourceUrl = [string]$Entry.url
        SourceCommit = [string]$Entry.sourceCommit
        SourceBlob = [string]$Entry.sourceBlob
        SourceContentHash = [string]$Entry.contentHash
        ContentType = Get-StringProperty -Object $Entry -Name "type" -Default "legacy"
        Authority = Get-StringProperty -Object $Entry -Name "authority" -Default "unknown"
        Lifecycle = Get-StringProperty -Object $Entry -Name "lifecycle" -Default "unknown"
    }
}

function Read-Manifest {
    param(
        [Parameter(Mandatory = $true)][string]$Path,
        [Parameter(Mandatory = $true)][string]$Root
    )

    Assert-Condition (Test-Path -LiteralPath $Path -PathType Leaf) "D3.1 AI content manifest '$Path' does not exist."
    try {
        $manifest = Get-Content -LiteralPath $Path -Raw | ConvertFrom-Json
    }
    catch {
        throw "D3.1 AI content manifest '$Path' is not valid JSON."
    }
    Assert-Properties -Object $manifest `
        -Required @("schemaVersion", "format", "visibility", "generator", "schema", "source", "scope", "license", "counts", "entries", "gaps") `
        -Allowed @("schemaVersion", "format", "visibility", "generator", "schema", "source", "scope", "license", "counts", "entries", "gaps") `
        -Context "D3.1 manifest"
    Assert-Condition ([int]$manifest.schemaVersion -eq 1) "Unsupported D3.1 manifest schema version."
    Assert-Condition ([string]$manifest.format -eq "json" -and [string]$manifest.visibility -eq "metadata-only") "The source manifest is not the metadata-only D3.1 manifest."
    Assert-Condition ([string]$manifest.source.repository -eq $script:Repository) "The D3.1 manifest source repository is not dataminer-docs."
    Assert-Condition ([string]$manifest.source.revision -match "^[0-9a-f]{40}$") "The D3.1 manifest source revision is not an immutable full commit."
    Assert-Condition ([string]$manifest.license.identifier -eq $script:LicenseIdentifier) "The D3.1 manifest has an unexpected license."
    Assert-Condition ([string]$manifest.license.attribution -eq $script:Attribution) "The D3.1 manifest has unexpected attribution."

    $entries = New-Object "System.Collections.Generic.List[object]"
    foreach ($entry in @($manifest.entries)) {
        if ([bool]$entry.tombstone) {
            continue
        }
        if ([string]$entry.domain -notin @("Connector", "Automation")) {
            continue
        }
        $record = New-ManifestEntry -Entry $entry
        $sourcePath = Join-Path $Root $record.SourcePath.Replace("/", "\")
        Assert-Condition (Test-Path -LiteralPath $sourcePath -PathType Leaf) "Pack source '$($record.SourcePath)' does not exist."
        Assert-Condition ((Get-TextSha256 (Get-Content -LiteralPath $sourcePath -Raw)) -eq $record.SourceContentHash) "Pack source '$($record.SourcePath)' changed since the D3.1 manifest was generated."
        [void]($record | Add-Member -NotePropertyName OriginalEntry -NotePropertyValue $entry)
        [void]($record | Add-Member -NotePropertyName FullPath -NotePropertyValue $sourcePath)
        [void]$entries.Add($record)
    }

    return [PSCustomObject]@{
        Manifest = $manifest
        Entries = @($entries.ToArray() | Sort-Object Domain, SourceUid, SourcePath)
        Revision = [string]$manifest.source.revision
    }
}

$root = ConvertTo-FullPath $RepositoryRoot
Assert-Condition (Test-Path -LiteralPath $root -PathType Container) "Repository root '$root' does not exist."
$manifest = ConvertTo-FullPath $ManifestPath
$output = ConvertTo-FullPath $OutputPath
$schema = ConvertTo-FullPath $SchemaPath
Assert-Condition (Test-Path -LiteralPath $schema -PathType Leaf) "Topic pack schema '$schema' does not exist."
Assert-Condition (Test-Path -LiteralPath $ValidatorPath -PathType Leaf) "Topic pack validator '$ValidatorPath' does not exist."

$manifestInfo = Read-Manifest -Path $manifest -Root $root
if (-not [String]::IsNullOrWhiteSpace($SourceRevision)) {
    $requestedRevision = $SourceRevision.Trim().ToLowerInvariant()
    Assert-Condition ($requestedRevision -match "^[0-9a-f]{40}$") "Source revision '$SourceRevision' is not a full immutable commit."
    Assert-Condition ($requestedRevision -eq $manifestInfo.Revision) "Requested source revision '$requestedRevision' does not match the D3.1 manifest revision '$($manifestInfo.Revision)'."
}
$manifestRelativePath = ConvertTo-RepositoryRelativePath -Path $manifest -Root $root
if ([String]::IsNullOrWhiteSpace($manifestRelativePath)) {
    $manifestRelativePath = [IO.Path]::GetFileName($manifest)
}
$generation = Get-GenerationDateInfo -Root $root -Revision $manifestInfo.Revision -RequestedDate $GenerationDate

if (Test-Path -LiteralPath $output -PathType Leaf) {
    throw "Topic pack output path '$output' is a file."
}
$outputRelativePath = ConvertTo-RepositoryRelativePath -Path $output -Root $root
if ($null -ne $outputRelativePath) {
    Assert-Condition ($outputRelativePath.Equals("_artifacts", [StringComparison]::OrdinalIgnoreCase) -or $outputRelativePath.StartsWith("_artifacts/", [StringComparison]::OrdinalIgnoreCase)) "Topic pack output inside the repository must remain under '_artifacts'."
}
if (-not (Test-Path -LiteralPath $output -PathType Container)) {
    New-Item -ItemType Directory -Path $output -Force | Out-Null
}
foreach ($domainDirectory in @("connector", "automation")) {
    $directory = Join-Path $output $domainDirectory
    if (Test-Path -LiteralPath $directory -PathType Container) {
        Remove-Item -LiteralPath $directory -Recurse -Force
    }
}
$manifestOutputPath = Join-Path $output "internal-only-topic-pack-manifest.json"
if (Test-Path -LiteralPath $manifestOutputPath -PathType Leaf) {
    Remove-Item -LiteralPath $manifestOutputPath -Force
}
$noticePath = Join-Path $output "internal-only-notice.txt"
if (Test-Path -LiteralPath $noticePath -PathType Leaf) {
    Remove-Item -LiteralPath $noticePath -Force
}

$pagesByPath = @{}
$pagesByUid = @{}
$allPages = New-Object "System.Collections.Generic.List[object]"
$allChunks = New-Object "System.Collections.Generic.List[object]"
$seenPageKeys = @{}

foreach ($entry in @($manifestInfo.Entries)) {
    $pageKey = "$($entry.Domain)|$($entry.SourceUid)|$($entry.SourcePath)"
    Assert-Condition (-not $seenPageKeys.ContainsKey($pageKey)) "Duplicate D3.1 page identity '$pageKey'."
    $seenPageKeys[$pageKey] = $true
    Assert-Condition (-not $pagesByPath.ContainsKey($entry.SourcePath)) "A source path belongs to more than one pack page: '$($entry.SourcePath)'."

    $parts = Get-MarkdownParts -Text (Get-Content -LiteralPath $entry.FullPath -Raw)
    $fallbackTitle = [IO.Path]::GetFileNameWithoutExtension($entry.SourcePath)
    $sourceTitle = Get-SourceTitle -Body $parts.Body -Fallback $fallbackTitle
    $sections = @(Get-SourceSections -Body $parts.Body -Uid $entry.SourceUid -SourceTitle $sourceTitle -BodyStartLine $parts.BodyStartLine)
    $page = [PSCustomObject]@{
        Domain = $entry.Domain
        SourceUid = $entry.SourceUid
        SourcePath = $entry.SourcePath
        SourceUrl = $entry.SourceUrl
        SourceCommit = $entry.SourceCommit
        SourceBlob = $entry.SourceBlob
        SourceContentHash = $entry.SourceContentHash
        ContentType = $entry.ContentType
        Authority = $entry.Authority
        Lifecycle = $entry.Lifecycle
        SourceTitle = $sourceTitle
        FullPath = $entry.FullPath
        Chunks = New-Object "System.Collections.Generic.List[object]"
        RootChunk = $null
    }

    foreach ($section in $sections) {
        $identityInput = @(
            "internal-topic-pack-v1",
            $entry.Domain,
            $entry.SourceUid,
            $entry.SourcePath,
            $entry.SourceCommit,
            $entry.SourceContentHash,
            $section.Identity
        ) -join "`n"
        $identityHash = Get-TextSha256 $identityInput
        $directoryName = $entry.Domain.ToLowerInvariant()
        $fileName = New-ChunkFileName -Uid $entry.SourceUid -SourcePath $entry.SourcePath -SectionIndex $section.Index -IdentityHash $identityHash
        $relativePath = "$directoryName/$fileName"
        $chunk = [PSCustomObject]@{
            Id = "chunk-" + $identityHash.Substring(0, 24)
            Domain = $entry.Domain
            SourceUid = $entry.SourceUid
            SourcePath = $entry.SourcePath
            SourceUrl = $entry.SourceUrl
            SourceCommit = $entry.SourceCommit
            SourceBlob = $entry.SourceBlob
            SourceContentHash = $entry.SourceContentHash
            SourceSectionHash = Get-TextSha256 $section.Body
            SourceSectionIdentity = $section.Identity
            SourceSectionTitle = $section.Title
            SectionAnchor = $section.Anchor
            SourceStartLine = $section.SourceStartLine
            SourceEndLine = $section.SourceEndLine
            SectionAnchors = @($section.Anchors)
            ContentType = $entry.ContentType
            Authority = $entry.Authority
            Lifecycle = $entry.Lifecycle
            Index = [int]$section.Index
            Count = [int]$sections.Count
            RelativePath = $relativePath
            FullPath = Join-Path $output $relativePath.Replace("/", "\")
            IdentityHash = $identityHash
            OriginalBody = (Normalize-Text $section.Body)
        }
        [void]$page.Chunks.Add($chunk)
        [void]$allChunks.Add($chunk)
    }
    $page.RootChunk = $page.Chunks[0]
    $pagesByPath[$page.SourcePath] = $page
    if (-not $pagesByUid.ContainsKey($page.SourceUid)) {
        $pagesByUid[$page.SourceUid] = New-Object "System.Collections.Generic.List[object]"
    }
    [void]$pagesByUid[$page.SourceUid].Add($page)
    [void]$allPages.Add($page)
}

Assert-Condition ($allPages.Count -gt 0) "The D3.1 manifest contains no current Connector or Automation Markdown pages."

$linkState = [PSCustomObject]@{
    Unresolved = New-Object "System.Collections.Generic.List[object]"
}
$chunkRecords = New-Object "System.Collections.Generic.List[object]"
$resolvedLinkCount = 0

foreach ($chunk in @($allChunks.ToArray() | Sort-Object Domain, SourceUid, SourcePath, Index)) {
    $page = $pagesByPath[$chunk.SourcePath]
    $result = Resolve-Links -Body $chunk.OriginalBody -Page $page -Chunk $chunk -PagesByPath $pagesByPath -PagesByUid $pagesByUid -State $linkState
    $resolvedLinkCount += @($result.Resolved).Count
    $outputBody = Normalize-Text $result.Body
    if (-not $outputBody.EndsWith("`n")) {
        $outputBody += "`n"
    }
    $chunkContentHash = Get-TextSha256 $outputBody
    $frontMatter = New-ChunkFrontMatter -Chunk $chunk -ManifestRelativePath $manifestRelativePath -ChunkContentHash $chunkContentHash -ResolvedLinkCount @($result.Resolved).Count -UnresolvedLinkCount @($result.Unresolved).Count
    $fileContent = $frontMatter + "`n`n" + $outputBody
    Write-Text -Path $chunk.FullPath -Text $fileContent
    $record = [ordered]@{
        id = $chunk.Id
        path = $chunk.RelativePath
        domain = $chunk.Domain
        sourceUid = $chunk.SourceUid
        sourceUrl = $chunk.SourceUrl
        sourcePath = $chunk.SourcePath
        sourceCommit = $chunk.SourceCommit
        sourceBlob = $chunk.SourceBlob
        contentHash = $chunk.SourceContentHash
        sourceSectionHash = $chunk.SourceSectionHash
        sourceSectionIdentity = $chunk.SourceSectionIdentity
        sourceSectionTitle = $chunk.SourceSectionTitle
        contentIdentity = $chunk.IdentityHash
        sourceStartLine = $chunk.SourceStartLine
        sourceEndLine = $chunk.SourceEndLine
        chunkIndex = $chunk.Index
        chunkCount = $chunk.Count
        chunkContentHash = $chunkContentHash
        fileSha256 = Get-FileSha256 -Path $chunk.FullPath
        contentType = $chunk.ContentType
        authority = $chunk.Authority
        lifecycle = $chunk.Lifecycle
        license = $script:LicenseIdentifier
        attribution = $script:Attribution
        links = [ordered]@{
            resolved = @($result.Resolved | Sort-Object sourceLine, original, target)
            unresolved = @($result.Unresolved | Sort-Object sourceLine, target, reason, id)
        }
    }
    [void]($chunk | Add-Member -NotePropertyName ResolvedLinks -NotePropertyValue @($result.Resolved))
    [void]($chunk | Add-Member -NotePropertyName UnresolvedLinks -NotePropertyValue @($result.Unresolved))
    [void]($chunk | Add-Member -NotePropertyName ChunkContentHash -NotePropertyValue $chunkContentHash)
    [void]($chunk | Add-Member -NotePropertyName FileSha256 -NotePropertyValue (Get-FileSha256 -Path $chunk.FullPath))
    [void]$chunkRecords.Add([PSCustomObject]$record)
}

$sortedChunks = @($chunkRecords.ToArray() | Sort-Object domain, sourceUid, sourcePath, chunkIndex)
$sortedUnresolved = @($linkState.Unresolved.ToArray() | Sort-Object chunkId, sourceLine, target, reason, id)
$packs = New-Object "System.Collections.Generic.List[object]"
foreach ($domain in @("Automation", "Connector")) {
    $domainPages = @($allPages.ToArray() | Where-Object { $_.Domain -eq $domain } | Sort-Object SourceUid, SourcePath)
    $domainChunks = @($sortedChunks | Where-Object { $_.domain -eq $domain })
    $domainResolved = 0
    $domainUnresolved = 0
    foreach ($record in $domainChunks) {
        $domainResolved += @($record.links.resolved).Count
        $domainUnresolved += @($record.links.unresolved).Count
    }
    [void]$packs.Add([ordered]@{
            domain = $domain
            directory = $domain.ToLowerInvariant()
            sourcePages = $domainPages.Count
            chunks = $domainChunks.Count
            resolvedLinks = $domainResolved
            unresolvedLinks = $domainUnresolved
        })
}

$noticeText = @"
INTERNAL-ONLY TRANSFORMED DOCUMENTATION

This directory contains normalized/transformed Markdown topic packs generated from DataMiner Docs.
It is permitted for internal-only use under policy $script:PolicyId.
Public redistribution is not authorized.
Model training and fine-tuning are not authorized.
Do not place this directory in a public release or deployed documentation artifact.
Operational copies must be retained for no more than 14 days unless a stricter internal policy applies.
Policy source: $script:PolicySource
"@
if (-not $noticeText.EndsWith("`n")) {
    $noticeText += "`n"
}
Write-Text -Path $noticePath -Text $noticeText

$manifestOutputRelativePath = "internal-only-topic-pack-manifest.json"
$packManifest = [ordered]@{
    schemaVersion = $script:SchemaVersion
    format = "markdown-topic-packs"
    visibility = "internal-only"
    distribution = [ordered]@{
        use = "normalized-transformed-content-internal-only"
        publicRedistributionAllowed = $false
        modelTrainingAllowed = $false
        fineTuningAllowed = $false
        retentionDays = 14
        policy = [ordered]@{
            id = $script:PolicyId
            source = $script:PolicySource
        }
    }
    generator = [ordered]@{
        name = "scripts/generate-internal-topic-packs.ps1"
        version = $script:GeneratorVersion
    }
    schema = [ordered]@{
        name = $script:SchemaName
        version = $script:SchemaVersion
    }
    source = [ordered]@{
        repository = $script:Repository
        revision = $manifestInfo.Revision
        revisionSource = "manifest"
        manifest = [ordered]@{
            path = $manifestRelativePath
            sha256 = Get-FileSha256 -Path $manifest
            schema = [ordered]@{
                name = [string]$manifestInfo.Manifest.schema.name
                version = [int]$manifestInfo.Manifest.schema.version
            }
        }
    }
    scope = [ordered]@{
        domains = @("Automation", "Connector")
        sourcePaths = @($allPages.ToArray() | Sort-Object SourcePath | ForEach-Object { $_.SourcePath } | Select-Object -Unique)
    }
    generation = [ordered]@{
        generatedAt = $generation.generatedAt
        generatedAtSource = $generation.generatedAtSource
        deterministic = $true
        contentIdentityAlgorithm = "sha256"
        contentIdentityFields = @("sourceCommit", "sourcePath", "sourceUid", "sourceContentHash", "sourceSectionIdentity")
        contentIdentityExcludes = @("generatedAt")
    }
    license = [ordered]@{
        identifier = $script:LicenseIdentifier
        name = $script:LicenseName
        url = $script:LicenseUrl
        attribution = $script:Attribution
        source = $script:PolicySource
    }
    notice = [ordered]@{
        path = "internal-only-notice.txt"
        sha256 = Get-FileSha256 -Path $noticePath
    }
    counts = [ordered]@{
        sourcePages = $allPages.Count
        chunks = $sortedChunks.Count
        resolvedLinks = $resolvedLinkCount
        unresolvedLinks = $sortedUnresolved.Count
        byDomain = @($packs.ToArray())
    }
    packs = @($packs.ToArray())
    chunks = $sortedChunks
    unresolvedLinks = $sortedUnresolved
}

Write-Json -Path $manifestOutputPath -Value $packManifest
& $ValidatorPath -RepositoryRoot $root -Path $manifestOutputPath -SchemaPath $schema | Out-Null

Write-Output "Wrote $manifestOutputPath."
Write-Output "Topic pack source pages: $($allPages.Count); chunks: $($sortedChunks.Count)."
Write-Output "Resolved links: $resolvedLinkCount; unresolved links: $($sortedUnresolved.Count)."
