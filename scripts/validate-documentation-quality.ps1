[CmdletBinding()]
param(
    [string]$RepositoryRoot = (Join-Path $PSScriptRoot ".."),
    [string]$BaselinePath = (Join-Path $PSScriptRoot "..\docs-corpus-baseline.json"),
    [string]$CurrentBaselinePath = (Join-Path $PSScriptRoot "..\docs-corpus-baseline.generated.json"),
    [string]$ReportPath = (Join-Path $PSScriptRoot "..\_artifacts\d4-1-quality-report.json"),
    [string]$BaseRevision,
    [string[]]$Path,
    [string]$MarkdownLintCommand = "markdownlint",
    [string]$MarkdownLintConfigPath,
    [switch]$SkipMarkdownLint,
    [switch]$SkipIdentityChecks
)

Set-StrictMode -Version 2.0
$ErrorActionPreference = "Stop"

function ConvertTo-FullPath {
    param([Parameter(Mandatory = $true)][string]$Value)

    if ([IO.Path]::IsPathRooted($Value)) {
        return [IO.Path]::GetFullPath($Value)
    }

    return [IO.Path]::GetFullPath((Join-Path (Get-Location).Path $Value))
}

function ConvertTo-RepositoryRelativePath {
    param([Parameter(Mandatory = $true)][string]$Value)

    $fullPath = [IO.Path]::GetFullPath($Value)
    $prefix = $script:RepositoryRoot.TrimEnd("\") + "\"
    if (-not $fullPath.StartsWith($prefix, [StringComparison]::OrdinalIgnoreCase)) {
        throw "Path '$Value' is outside the repository root '$script:RepositoryRoot'."
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

function Get-MarkdownPaths {
    param([string[]]$RequestedPaths)

    if ($null -ne $RequestedPaths -and $RequestedPaths.Count -gt 0) {
        $paths = @()
        foreach ($requestedPath in $RequestedPaths) {
            $candidate = if ([IO.Path]::IsPathRooted($requestedPath)) {
                [IO.Path]::GetFullPath($requestedPath)
            }
            else {
                [IO.Path]::GetFullPath((Join-Path $script:RepositoryRoot $requestedPath))
            }

            if (-not (Test-Path -LiteralPath $candidate -PathType Leaf)) {
                throw "Markdown path '$requestedPath' does not exist."
            }
            if ([IO.Path]::GetExtension($candidate) -ine ".md") {
                throw "Quality gate path '$requestedPath' is not a Markdown file."
            }
            if (-not $candidate.StartsWith($script:RepositoryRoot.TrimEnd("\") + "\", [StringComparison]::OrdinalIgnoreCase)) {
                throw "Markdown path '$requestedPath' is outside the repository root."
            }

            $paths += $candidate
        }

        return @($paths | Sort-Object -Unique)
    }

    $paths = @()
    foreach ($file in Get-ChildItem -LiteralPath $script:RepositoryRoot -File -Filter "*.md") {
        $paths += $file.FullName
    }

    foreach ($directoryName in @("contributing", "dataminer", "develop", "release-notes", "solutions", "tutorials")) {
        $directoryPath = Join-Path $script:RepositoryRoot $directoryName
        if (-not (Test-Path -LiteralPath $directoryPath -PathType Container)) {
            continue
        }

        $paths += @(Get-ChildItem -LiteralPath $directoryPath -Recurse -File -Filter "*.md" | ForEach-Object { $_.FullName })
    }

    return @($paths | Sort-Object -Unique)
}

function Get-ChangedMarkdownPaths {
    param(
        [string[]]$RequestedPaths,
        [AllowEmptyString()][string]$Revision
    )

    if ($null -ne $RequestedPaths -and $RequestedPaths.Count -gt 0) {
        return @(Get-MarkdownPaths -RequestedPaths $RequestedPaths)
    }

    $diffRevision = $Revision
    if ([String]::IsNullOrWhiteSpace($diffRevision)) {
        $diffRevision = "HEAD^"
    }

    $diffPaths = @(& git -C $script:RepositoryRoot diff --name-only --diff-filter=ACMR "$diffRevision" HEAD -- "*.md" 2>$null)
    if ($LASTEXITCODE -ne 0) {
        throw "Unable to determine changed Markdown files relative to '$diffRevision'."
    }

    $available = @{}
    foreach ($path in @(Get-MarkdownPaths)) {
        $available[(ConvertTo-RepositoryRelativePath $path).ToLowerInvariant()] = $path
    }

    $changed = @()
    foreach ($diffPath in $diffPaths) {
        $relativePath = ([string]$diffPath).Replace("\", "/").Trim()
        $key = $relativePath.ToLowerInvariant()
        if ($available.ContainsKey($key)) {
            $changed += $available[$key]
        }
    }

    return @($changed | Sort-Object -Unique)
}

function Get-GitText {
    param(
        [Parameter(Mandatory = $true)][string]$Revision,
        [Parameter(Mandatory = $true)][string]$RelativePath
    )

    $output = @(& git -C $script:RepositoryRoot show "$Revision`:$RelativePath" 2>$null)
    if ($LASTEXITCODE -ne 0) {
        return $null
    }

    return ($output -join "`n")
}

function Get-FrontMatter {
    param([Parameter(Mandatory = $true)][string]$Text)

    $normalized = Normalize-Text $Text
    $match = [Regex]::Match(
        $normalized,
        "\A---\n(?<front>.*?)\n---(?:\n|\z)",
        [Text.RegularExpressions.RegexOptions]::Singleline
    )
    if (-not $match.Success) {
        return [PSCustomObject]@{
            Found = $false
            Text = ""
            StartLine = 1
        }
    }

    return [PSCustomObject]@{
        Found = $true
        Text = $match.Groups["front"].Value
        StartLine = 1
    }
}

function ConvertFrom-YamlScalar {
    param([AllowEmptyString()][string]$Value)

    if ($null -eq $Value) {
        return ""
    }

    $trimmed = $Value.Trim()
    if ($trimmed -match "^(?<value>.*?)(?<!\\)\s+#") {
        $trimmed = $Matches["value"].Trim()
    }
    if ($trimmed.Length -ge 2 -and $trimmed.StartsWith('"') -and $trimmed.EndsWith('"')) {
        return $trimmed.Substring(1, $trimmed.Length - 2).Replace('\"', '"').Replace("\\", "\")
    }
    if ($trimmed.Length -ge 2 -and $trimmed.StartsWith("'") -and $trimmed.EndsWith("'")) {
        return $trimmed.Substring(1, $trimmed.Length - 2).Replace("''", "'")
    }

    return $trimmed
}

function Get-FrontMatterValue {
    param(
        [Parameter(Mandatory = $true)][string]$FrontMatter,
        [Parameter(Mandatory = $true)][string]$Name
    )

    $match = [Regex]::Match(
        (Normalize-Text $FrontMatter),
        "(?m)^" + [Regex]::Escape($Name) + "\s*:\s*(?<value>.*)$"
    )
    if (-not $match.Success) {
        return ""
    }

    return ConvertFrom-YamlScalar $match.Groups["value"].Value
}

function New-Finding {
    param(
        [Parameter(Mandatory = $true)][string]$Kind,
        [Parameter(Mandatory = $true)][AllowEmptyString()][string]$RelativePath,
        [Parameter(Mandatory = $true)][int]$Line,
        [Parameter(Mandatory = $true)][string]$Value,
        [Parameter(Mandatory = $true)][string]$Details
    )

    return [PSCustomObject][ordered]@{
        kind = $Kind
        path = $RelativePath
        line = $Line
        value = $Value
        details = $Details
        identity = "$RelativePath|$Kind|$Value".ToLowerInvariant()
    }
}

function ConvertTo-CanonicalPageUrl {
    param([Parameter(Mandatory = $true)][string]$Value)

    $url = $Value.Trim().Replace("\", "/")
    if ($url -match "^(?i)https?://docs\.dataminer\.services/") {
        $url = $url.Substring($url.IndexOf("/", 8) + 1)
    }
    return $url.TrimStart("/")
}

function Test-VersionValue {
    param([Parameter(Mandatory = $true)][string]$Value)

    return $Value -match "^(?i:unknown|unversioned|not_applicable)$" -or
        $Value -match "^\d+(?:\.\d+){1,3}$" -or
        $Value -match "^[Dd]\d+\.\d+(?:\.\d+)?$"
}

function Test-CanonicalInternalTarget {
    param([Parameter(Mandatory = $true)][string]$Target)

    if ($Target -match "^(?i)(?:https?|mailto|tel):") {
        return $true
    }
    if ($Target.StartsWith("#") -or $Target.StartsWith("xref:", [StringComparison]::OrdinalIgnoreCase)) {
        return $true
    }
    if ($Target -match "(?i)\.(?:md|html)(?:[#?].*)?$") {
        return $false
    }
    if ($Target.StartsWith("~/") -and $Target -notmatch "(?i)(^|/)images/") {
        return $false
    }
    if ($Target.StartsWith("../") -or $Target.StartsWith("./")) {
        return $false
    }

    return $true
}

function Get-MarkdownQualityFindings {
    param(
        [Parameter(Mandatory = $true)][string]$Text,
        [Parameter(Mandatory = $true)][string]$RelativePath
    )

    $normalized = Normalize-Text $Text
    $frontMatter = Get-FrontMatter $normalized
    $lines = @($normalized -split "`n")
    $findings = New-Object "System.Collections.Generic.List[object]"
    $inFence = $false
    $fence = ""

    for ($index = 0; $index -lt $lines.Count; $index++) {
        $line = $lines[$index]
        $fenceMatch = [Regex]::Match($line, '^\s*(?<fence>`{3,}|~{3,})')
        if ($fenceMatch.Success) {
            $fenceText = $fenceMatch.Groups["fence"].Value
            if (-not $inFence) {
                $inFence = $true
                $fence = $fenceText.Substring(0, 1)
            }
            elseif ($fence -eq $fenceText.Substring(0, 1)) {
                $inFence = $false
                $fence = ""
            }
            continue
        }
        if ($inFence) {
            continue
        }

        $visibleLine = [Regex]::Replace($line, "<!--.*?-->", "")
        foreach ($imageMatch in [Regex]::Matches($visibleLine, "!\[(?<alt>[^\]]*)\]\((?<target><[^>]+>|[^)\s]+)(?:\s+[^)]*)?\)")) {
            $alt = $imageMatch.Groups["alt"].Value.Trim()
            $target = $imageMatch.Groups["target"].Value.Trim()
            if ($target.StartsWith("<") -and $target.EndsWith(">")) {
                $target = $target.Substring(1, $target.Length - 2)
            }
            if ([String]::IsNullOrWhiteSpace($alt)) {
                $findings.Add((New-Finding `
                        -Kind "image_alt_text_missing" `
                        -RelativePath $RelativePath `
                        -Line ($index + 1) `
                        -Value $target `
                        -Details "Image '$target' has no descriptive alt text.")) | Out-Null
            }
        }

        foreach ($linkMatch in [Regex]::Matches($visibleLine, "(?<!\!)\[(?<label>[^\]]*)\]\((?<target><[^>]+>|[^)\s]+)(?:\s+[^)]*)?\)")) {
            $target = $linkMatch.Groups["target"].Value.Trim()
            if ($target.StartsWith("<") -and $target.EndsWith(">")) {
                $target = $target.Substring(1, $target.Length - 2)
            }
            if (-not (Test-CanonicalInternalTarget $target)) {
                $findings.Add((New-Finding `
                        -Kind "noncanonical_internal_link" `
                        -RelativePath $RelativePath `
                        -Line ($index + 1) `
                        -Value $target `
                        -Details "Internal page link '$target' must use a canonical xref link.")) | Out-Null
            }
        }
    }

    if ($frontMatter.Found) {
        $versionMatch = [Regex]::Match(
            (Normalize-Text $frontMatter.Text),
            "(?m)^version\s*:\s*(?<value>.*)$"
        )
        if ($versionMatch.Success) {
            $version = ConvertFrom-YamlScalar $versionMatch.Groups["value"].Value
            if (-not (Test-VersionValue $version)) {
                $versionLine = 1
                $frontLines = @((Normalize-Text $frontMatter.Text) -split "`n")
                for ($frontIndex = 0; $frontIndex -lt $frontLines.Count; $frontIndex++) {
                    if ($frontLines[$frontIndex] -match "^version\s*:") {
                        $versionLine = $frontIndex + 2
                        break
                    }
                }
                $findings.Add((New-Finding `
                        -Kind "invalid_version_range" `
                        -RelativePath $RelativePath `
                        -Line $versionLine `
                        -Value $version `
                        -Details "Metadata version '$version' is not a single version or an allowed sentinel.")) | Out-Null
            }
        }
    }

    return @($findings.ToArray())
}

function Get-FindingKeysAtRevision {
    param(
        [Parameter(Mandatory = $true)][string]$Revision,
        [Parameter(Mandatory = $true)][string]$RelativePath
    )

    $text = Get-GitText -Revision $Revision -RelativePath $RelativePath
    if ($null -eq $text) {
        return @{}
    }

    $keys = @{}
    foreach ($finding in @(Get-MarkdownQualityFindings -Text $text -RelativePath $RelativePath)) {
        $keys[$finding.identity] = $true
    }

    return $keys
}

function Get-IdentityFindings {
    param(
        [Parameter(Mandatory = $true)]$Baseline,
        [Parameter(Mandatory = $true)]$Current
    )

    $findings = New-Object "System.Collections.Generic.List[object]"
    $baselineDuplicateUids = @{}
    foreach ($duplicate in @($Baseline.source.uid.duplicateUids)) {
        $baselineDuplicateUids[[string]$duplicate.uid] = $true
    }
    foreach ($duplicate in @($Current.source.uid.duplicateUids)) {
        $uid = [string]$duplicate.uid
        $status = if ($baselineDuplicateUids.ContainsKey($uid)) { "legacy_exception" } else { "new" }
        $finding = New-Finding `
            -Kind "duplicate_uid" `
            -RelativePath ((@($duplicate.paths) -join ",") ) `
            -Line 0 `
            -Value $uid `
            -Details "UID '$uid' is used by multiple Markdown pages: $(@($duplicate.paths) -join ', ')."
        $finding | Add-Member -NotePropertyName status -NotePropertyValue $status
        $findings.Add($finding) | Out-Null
    }

    $baselineMissingPaths = @{}
    foreach ($path in @($Baseline.source.uid.missingUidPaths)) {
        $baselineMissingPaths[[string]$path] = $true
    }
    foreach ($path in @($Current.source.uid.missingUidPaths)) {
        $relativePath = [string]$path
        $status = if ($baselineMissingPaths.ContainsKey($relativePath)) { "legacy_exception" } else { "new" }
        $finding = New-Finding `
            -Kind "missing_uid" `
            -RelativePath $relativePath `
            -Line 0 `
            -Value $relativePath `
            -Details "Markdown page '$relativePath' has no UID."
        $finding | Add-Member -NotePropertyName status -NotePropertyValue $status
        $findings.Add($finding) | Out-Null
    }

    $currentEntries = @()
    if ($Current.PSObject.Properties.Name -contains "metadataManifest") {
        $currentEntries = @($Current.metadataManifest.entries)
    }
    $baselineEntries = @()
    if ($Baseline.PSObject.Properties.Name -contains "metadataManifest") {
        $baselineEntries = @($Baseline.metadataManifest.entries)
    }

    $currentPageUids = @{}
    foreach ($entry in $currentEntries) {
        $currentPageUids[[string]$entry.uid] = $true
    }

    $baselineCompatibility = @{}
    foreach ($entry in $baselineEntries) {
        $baselineCompatibility[[string]$entry.uid] = ConvertTo-CanonicalPageUrl ([string]$entry.url)
    }
    if ($baselineCompatibility.Count -eq 0) {
        foreach ($entry in @($Baseline.compatibility)) {
            if ($currentPageUids.ContainsKey([string]$entry.uid)) {
                $baselineCompatibility[[string]$entry.uid] = ConvertTo-CanonicalPageUrl ([string]$entry.href)
            }
        }
    }
    $currentCompatibility = @{}
    foreach ($entry in $currentEntries) {
        $currentCompatibility[[string]$entry.uid] = ConvertTo-CanonicalPageUrl ([string]$entry.url)
    }

    if ($baselineCompatibility.Count -eq 0 -or $currentCompatibility.Count -eq 0) {
        throw "The D0.2 metadata-only page inventory is empty; URL preservation cannot be evaluated."
    }

    foreach ($uid in @($baselineCompatibility.Keys | Sort-Object)) {
        if (-not $currentCompatibility.ContainsKey($uid)) {
            $finding = New-Finding `
                -Kind "uid_removed" `
                -RelativePath "" `
                -Line 0 `
                -Value $uid `
                -Details "Baseline UID '$uid' is missing from the current DocFX compatibility inventory."
            $finding | Add-Member -NotePropertyName status -NotePropertyValue "new"
            $findings.Add($finding) | Out-Null
            continue
        }

        if ($baselineCompatibility[$uid] -ne $currentCompatibility[$uid]) {
            $finding = New-Finding `
                -Kind "url_changed" `
                -RelativePath "" `
                -Line 0 `
                -Value $uid `
                -Details "UID '$uid' changed URL from '$($baselineCompatibility[$uid])' to '$($currentCompatibility[$uid])'. Add an explicit redirect and URL alias before changing a published URL."
            $finding | Add-Member -NotePropertyName status -NotePropertyValue "new"
            $findings.Add($finding) | Out-Null
        }
    }

    return @($findings.ToArray())
}

function Invoke-MarkdownLint {
    param(
        [Parameter(Mandatory = $true)][string[]]$MarkdownPaths
    )

    if ($SkipMarkdownLint) {
        return [PSCustomObject]@{
            status = "skipped"
            details = "Markdownlint was skipped by request."
        }
    }
    if ($MarkdownPaths.Count -eq 0) {
        return [PSCustomObject]@{
            status = "skipped"
            details = "No changed Markdown files were selected."
        }
    }
    if (-not (Test-Path -LiteralPath $MarkdownLintConfigPath -PathType Leaf)) {
        throw "Markdownlint configuration '$MarkdownLintConfigPath' does not exist."
    }

    $command = Get-Command $MarkdownLintCommand -ErrorAction SilentlyContinue
    if ($null -eq $command) {
        throw "Markdownlint command '$MarkdownLintCommand' was not found. Install the pinned markdownlint-cli version before running this gate."
    }

    $arguments = @("--config", $MarkdownLintConfigPath)
    $arguments += @($MarkdownPaths | ForEach-Object { [IO.Path]::GetFullPath($_) })
    & $command.Source @arguments
    if ($LASTEXITCODE -ne 0) {
        throw "Markdownlint reported errors for changed Markdown files."
    }

    return [PSCustomObject]@{
        status = "passed"
        details = "Markdownlint passed for $($MarkdownPaths.Count) changed Markdown file(s)."
    }
}

function Write-QualityReport {
    param(
        [Parameter(Mandatory = $true)]$Report,
        [Parameter(Mandatory = $true)][string]$Path
    )

    $directory = Split-Path -Parent $Path
    if (-not (Test-Path -LiteralPath $directory -PathType Container)) {
        New-Item -ItemType Directory -Path $directory -Force | Out-Null
    }

    $json = $Report | ConvertTo-Json -Depth 12
    $utf8NoBom = New-Object Text.UTF8Encoding($false)
    [IO.File]::WriteAllText($Path, $json, $utf8NoBom)
}

$script:RepositoryRoot = ConvertTo-FullPath $RepositoryRoot
$BaselinePath = ConvertTo-FullPath $BaselinePath
$CurrentBaselinePath = ConvertTo-FullPath $CurrentBaselinePath
$ReportPath = ConvertTo-FullPath $ReportPath
if ([String]::IsNullOrWhiteSpace($MarkdownLintConfigPath)) {
    $MarkdownLintConfigPath = Join-Path $script:RepositoryRoot ".markdownlint.json"
}
else {
    $MarkdownLintConfigPath = ConvertTo-FullPath $MarkdownLintConfigPath
}
if (-not (Test-Path -LiteralPath $script:RepositoryRoot -PathType Container)) {
    throw "Repository root '$script:RepositoryRoot' does not exist."
}

$qualityPaths = @(Get-ChangedMarkdownPaths -RequestedPaths $Path -Revision $BaseRevision)
$qualityFindings = New-Object "System.Collections.Generic.List[object]"
foreach ($markdownPath in $qualityPaths) {
    $relativePath = ConvertTo-RepositoryRelativePath $markdownPath
    $text = [IO.File]::ReadAllText($markdownPath)
    $baseFindingKeys = @{}
    if (-not [String]::IsNullOrWhiteSpace($BaseRevision)) {
        $baseFindingKeys = Get-FindingKeysAtRevision -Revision $BaseRevision -RelativePath $relativePath
    }

    foreach ($finding in @(Get-MarkdownQualityFindings -Text $text -RelativePath $relativePath)) {
        $status = if ($baseFindingKeys.ContainsKey($finding.identity)) { "legacy_exception" } else { "new" }
        $finding | Add-Member -NotePropertyName status -NotePropertyValue $status
        $qualityFindings.Add($finding) | Out-Null
    }
}

$identityFindings = New-Object "System.Collections.Generic.List[object]"
if (-not $SkipIdentityChecks) {
    if (-not (Test-Path -LiteralPath $BaselinePath -PathType Leaf)) {
        throw "D0.2 baseline '$BaselinePath' does not exist."
    }
    if (-not (Test-Path -LiteralPath $CurrentBaselinePath -PathType Leaf)) {
        throw "Current D0.2 baseline '$CurrentBaselinePath' does not exist. Run scripts/audit-docs-baseline.ps1 after the DocFX build."
    }

    $baseline = Get-Content -LiteralPath $BaselinePath -Raw | ConvertFrom-Json
    $current = Get-Content -LiteralPath $CurrentBaselinePath -Raw | ConvertFrom-Json
    foreach ($finding in @(Get-IdentityFindings -Baseline $baseline -Current $current)) {
        $identityFindings.Add($finding) | Out-Null
    }
}

$markdownLintStatus = [PSCustomObject]@{
    status = "skipped"
    details = "Markdownlint was not run."
}
$checkFailure = $null
try {
    $markdownLintStatus = Invoke-MarkdownLint -MarkdownPaths $qualityPaths
}
catch {
    $checkFailure = $_.Exception.Message
    $markdownLintStatus = [PSCustomObject]@{
        status = "failed"
        details = $checkFailure
    }
}

$findings = @($identityFindings.ToArray() + $qualityFindings.ToArray())
$failedFindings = @($findings | Where-Object { $_.status -eq "new" })
if ($null -ne $checkFailure) {
    $failedFindings += [PSCustomObject][ordered]@{
        kind = "markdown_quality"
        path = ""
        line = 0
        value = ""
        details = $checkFailure
        identity = "markdown_quality"
        status = "new"
    }
}

$report = [ordered]@{
    schemaVersion = 1
    gate = "D4.1"
    repository = "SkylineCommunications/dataminer-docs"
    baseline = [ordered]@{
        id = "D0.2"
        path = (ConvertTo-RepositoryRelativePath $BaselinePath)
        currentPath = (ConvertTo-RepositoryRelativePath $CurrentBaselinePath)
        baseRevision = if ([String]::IsNullOrWhiteSpace($BaseRevision)) { "working-tree" } else { $BaseRevision }
    }
    checks = [ordered]@{
        markdownlint = $markdownLintStatus
        identityInventory = if ($SkipIdentityChecks) { "skipped" } else { "validated by scripts/audit-docs-baseline.ps1 output" }
        legacyPolicy = "Findings present in the D0.2 baseline or unchanged from the comparison revision are reported as legacy_exception and do not block the gate."
    }
    paths = @($qualityPaths | ForEach-Object { ConvertTo-RepositoryRelativePath $_ })
    summary = [ordered]@{
        changedMarkdownFiles = $qualityPaths.Count
        findings = $findings.Count
        newFindings = $failedFindings.Count
        legacyExceptions = @($findings | Where-Object { $_.status -eq "legacy_exception" }).Count
    }
    findings = @($findings | Sort-Object kind, path, line, value)
}
Write-QualityReport -Report $report -Path $ReportPath

if ($failedFindings.Count -gt 0) {
    $messages = @($failedFindings | ForEach-Object {
            if ([string]::IsNullOrWhiteSpace($_.path)) {
                $_.details
            }
            else {
                "$($_.path):$($_.line) $($_.details)"
            }
        })
    throw ("D4.1 documentation quality gates failed with {0} finding(s):`n - {1}" -f $failedFindings.Count, ($messages -join "`n - "))
}

Write-Output ("D4.1 documentation quality gates passed. Checked {0} changed Markdown file(s), retained {1} legacy exception(s), and wrote {2}." -f $qualityPaths.Count, @($findings | Where-Object { $_.status -eq "legacy_exception" }).Count, $ReportPath)
