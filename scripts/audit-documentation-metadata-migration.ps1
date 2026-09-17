[CmdletBinding()]
param(
    [string]$RepositoryRoot = (Join-Path $PSScriptRoot ".."),
    [string]$ReportPath = (Join-Path $PSScriptRoot "..\d2-2-metadata-migration-report.json")
)

Set-StrictMode -Version 2.0
$ErrorActionPreference = "Stop"

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

    return [PSCustomObject]@{
        FrontMatter = $match.Groups["front"].Value
        Body = $Text.Substring($match.Length)
    }
}

function Get-FrontMatterValue {
    param(
        [Parameter(Mandatory = $true)][string]$FrontMatter,
        [Parameter(Mandatory = $true)][string]$Name
    )

    $match = [Regex]::Match(
        (Normalize-Text $FrontMatter),
        "(?m)^" + [Regex]::Escape($Name) + ":\s*(?<value>.*)$"
    )
    if (-not $match.Success) {
        return ""
    }

    $value = $match.Groups["value"].Value.Trim()
    if ($value.StartsWith('"') -and $value.EndsWith('"') -and $value.Length -ge 2) {
        return $value.Substring(1, $value.Length - 2).Replace('\"', '"').Replace("\\", "\")
    }
    return $value
}

function Get-GitText {
    param(
        [Parameter(Mandatory = $true)][string]$RepositoryRoot,
        [Parameter(Mandatory = $true)][string]$RelativePath
    )

    $spec = "HEAD:" + $RelativePath
    $resolve = New-Object Diagnostics.Process
    $resolve.StartInfo = New-Object Diagnostics.ProcessStartInfo
    $resolve.StartInfo.FileName = "git"
    $resolve.StartInfo.Arguments = "-C `"$RepositoryRoot`" rev-parse `"$spec`""
    $resolve.StartInfo.UseShellExecute = $false
    $resolve.StartInfo.CreateNoWindow = $true
    $resolve.StartInfo.RedirectStandardOutput = $true
    $resolve.StartInfo.RedirectStandardError = $true
    [void]$resolve.Start()
    $sha = $resolve.StandardOutput.ReadToEnd().Trim()
    [void]$resolve.StandardError.ReadToEnd()
    $resolve.WaitForExit()
    $resolveExitCode = $resolve.ExitCode
    $resolve.Dispose()
    if ($resolveExitCode -ne 0 -or $sha -notmatch "^[0-9a-f]{40}$") {
        return $null
    }

    $read = New-Object Diagnostics.Process
    $read.StartInfo = New-Object Diagnostics.ProcessStartInfo
    $read.StartInfo.FileName = "git"
    $read.StartInfo.Arguments = "-C `"$RepositoryRoot`" cat-file -p `"$sha`""
    $read.StartInfo.UseShellExecute = $false
    $read.StartInfo.CreateNoWindow = $true
    $read.StartInfo.RedirectStandardOutput = $true
    $read.StartInfo.RedirectStandardError = $true
    [void]$read.Start()
    $output = $read.StandardOutput.ReadToEnd()
    [void]$read.StandardError.ReadToEnd()
    $read.WaitForExit()
    $readExitCode = $read.ExitCode
    $read.Dispose()
    if ($readExitCode -ne 0) {
        return $null
    }

    return $output
}

$script:RepositoryRoot = ConvertTo-FullPath $RepositoryRoot
$ReportPath = ConvertTo-FullPath $ReportPath
if (-not (Test-Path -LiteralPath $script:RepositoryRoot -PathType Container)) {
    throw "Repository root '$script:RepositoryRoot' does not exist."
}
if (-not (Test-Path -LiteralPath $ReportPath -PathType Leaf)) {
    throw "Migration report '$ReportPath' does not exist."
}

$report = Get-Content -LiteralPath $ReportPath -Raw | ConvertFrom-Json
if ($report.schemaVersion -ne 1 -or $report.migration -ne "D2.2") {
    throw "Migration report '$ReportPath' is not a D2.2 version 1 report."
}

$targetPaths = New-Object "System.Collections.Generic.List[string]"
foreach ($scope in @($report.scopes)) {
    $scopePath = Join-Path $script:RepositoryRoot ($scope.relativeRoot.Replace("/", "\"))
    foreach ($file in Get-ChildItem -LiteralPath $scopePath -Recurse -File -Filter "*.md") {
        $targetPaths.Add((ConvertTo-RepositoryRelativePath -Path $file.FullName -Root $script:RepositoryRoot))
    }
}
$currentPaths = @($targetPaths | Sort-Object -Unique)
$reportPages = @($report.pages | Sort-Object -Property path)
$reportPaths = @($reportPages | ForEach-Object { [string]$_.path })
if ($currentPaths.Count -ne $reportPaths.Count) {
    throw "The current target page count ($($currentPaths.Count)) differs from the migration report count ($($reportPaths.Count))."
}
for ($index = 0; $index -lt $currentPaths.Count; $index++) {
    if ($currentPaths[$index] -ne $reportPaths[$index]) {
        throw "Target URL/path inventory changed at index ${index}: '$($reportPaths[$index])' vs '$($currentPaths[$index])'."
    }
}

$additionSet = @{}
foreach ($addition in @($report.baseline.unicodeNormalizedAdditions)) {
    $additionSet[[string]$addition] = $true
}

$uidStableCount = 0
$bodyStableCount = 0
$headComparableCount = 0
$currentByPath = @{}
foreach ($path in $currentPaths) {
    $currentByPath[$path] = Join-Path $script:RepositoryRoot $path.Replace("/", "\")
}

foreach ($page in $reportPages) {
    $path = [string]$page.path
    $currentPath = $currentByPath[$path]
    $currentText = [IO.File]::ReadAllText($currentPath)
    $currentParts = Get-FrontMatterParts $currentText
    $currentUid = Get-FrontMatterValue -FrontMatter $currentParts.FrontMatter -Name "uid"
    $metadataVersion = Get-FrontMatterValue -FrontMatter $currentParts.FrontMatter -Name "metadata_version"
    if ($metadataVersion -ne "1") {
        throw "Target page '$path' is not opted in to metadata version 1."
    }
    if ($currentUid -ne [string]$page.uid) {
        throw "UID changed for '$path': report '$($page.uid)', current '$currentUid'."
    }
    if ((Get-TextSha256 $currentParts.Body) -ne [string]$page.bodySha256) {
        throw "Prose/body hash changed after migration for '$path'."
    }
    $uidStableCount++
    $bodyStableCount++

    $headText = Get-GitText -RepositoryRoot $script:RepositoryRoot -RelativePath $path
    if ($null -eq $headText) {
        if (-not $additionSet.ContainsKey($path)) {
            throw "The target page '$path' is absent from HEAD but is not recorded as a D0.2 delta."
        }
        continue
    }

    $headParts = Get-FrontMatterParts $headText
    $headUid = Get-FrontMatterValue -FrontMatter $headParts.FrontMatter -Name "uid"
    if ($headUid -ne $currentUid) {
        throw "UID changed for '$path' relative to HEAD: '$headUid' vs '$currentUid'."
    }
    if ((Get-TextSha256 $headParts.Body) -ne (Get-TextSha256 $currentParts.Body)) {
        throw "Prose/body changed for '$path'; metadata migration must not rewrite page meaning."
    }
    $headComparableCount++
}

$tocPath = Join-Path $script:RepositoryRoot "develop\toc.yml"
$currentTocHash = Get-TextSha256 ([IO.File]::ReadAllText($tocPath))
if ($currentTocHash -ne [string]$report.toc.sha256) {
    throw "TOC hash changed after the migration."
}

& git -C $script:RepositoryRoot diff --quiet -- develop/toc.yml
if ($LASTEXITCODE -ne 0) {
    throw "develop/toc.yml has a Git diff; metadata migration must not change navigation."
}

Write-Output "D2.2 identity audit passed."
Write-Output "Stable target paths/UIDs: $uidStableCount."
Write-Output "Stable page bodies: $bodyStableCount."
Write-Output "HEAD-comparable pages: $headComparableCount."
Write-Output "Recorded D0.2 additions: $($additionSet.Count)."
