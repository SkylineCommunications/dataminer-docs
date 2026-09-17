[CmdletBinding()]
param(
    [string]$RepositoryRoot = (Join-Path $PSScriptRoot ".."),
    [string]$DocFxConfigPath = (Join-Path $PSScriptRoot "..\docfx.json"),
    [string]$OutputPath = (Join-Path $PSScriptRoot "..\_artifacts\html-source-metadata.json"),
    [string]$SourceRevision = "",
    [string]$SourceRepository = "https://github.com/SkylineCommunications/dataminer-docs",
    [string]$EditBranch = ""
)

Set-StrictMode -Version 2.0
$ErrorActionPreference = "Stop"

$script:RepoRoot = $null

function ConvertTo-FullPath {
    param([Parameter(Mandatory = $true)][string]$Path)

    if ([IO.Path]::IsPathRooted($Path)) {
        return [IO.Path]::GetFullPath($Path)
    }

    return [IO.Path]::GetFullPath((Join-Path (Get-Location).Path $Path))
}

function ConvertTo-RepositoryRelativePath {
    param([Parameter(Mandatory = $true)][string]$Path)

    $fullPath = [IO.Path]::GetFullPath($Path)
    $prefix = $script:RepoRoot.TrimEnd("\") + "\"
    if (-not $fullPath.StartsWith($prefix, [StringComparison]::OrdinalIgnoreCase)) {
        throw "Path '$Path' is outside the repository root '$script:RepoRoot'."
    }

    return $fullPath.Substring($prefix.Length).Replace("\", "/")
}

function Normalize-RelativePath {
    param([AllowEmptyString()][string]$Path)

    if ([String]::IsNullOrWhiteSpace($Path)) {
        return ""
    }

    $normalized = $Path.Replace("\", "/").Trim()
    while ($normalized.StartsWith("./", [StringComparison]::Ordinal)) {
        $normalized = $normalized.Substring(2)
    }
    return $normalized.Trim("/")
}

function Get-ObjectProperty {
    param(
        [AllowNull()]$Object,
        [Parameter(Mandatory = $true)][string]$Name
    )

    if ($null -eq $Object) {
        return $null
    }

    $property = $Object.PSObject.Properties[$Name]
    if ($null -eq $property) {
        return $null
    }

    return $property.Value
}

function Invoke-Git {
    param([Parameter(Mandatory = $true)][string[]]$Arguments)

    try {
        $output = @(& git -C $script:RepoRoot @Arguments 2>$null)
        if ($LASTEXITCODE -ne 0) {
            return ""
        }

        return (($output | ForEach-Object { [string]$_ }) -join "`n").Trim()
    }
    catch {
        return ""
    }
}

function Get-SourceRevision {
    param([AllowEmptyString()][string]$RequestedRevision)

    if ([string]::Equals($RequestedRevision.Trim(), "working-tree", [StringComparison]::OrdinalIgnoreCase)) {
        return $null
    }

    $revisionSpec = if ([String]::IsNullOrWhiteSpace($RequestedRevision)) {
        "HEAD^{commit}"
    }
    else {
        $RequestedRevision.Trim() + "^{commit}"
    }

    $revision = Invoke-Git @("rev-parse", "--verify", $revisionSpec)
    if ($revision -notmatch "^[0-9a-fA-F]{40}$") {
        return $null
    }

    return $revision.ToLowerInvariant()
}

function Get-GitPathSet {
    param(
        [Parameter(Mandatory = $true)][string[]]$Arguments,
        [switch]$ParseStatus
    )

    $paths = New-Object "System.Collections.Generic.HashSet[string]" ([StringComparer]::OrdinalIgnoreCase)
    $output = Invoke-Git $Arguments
    foreach ($line in @($output -split "`n")) {
        $path = [string]$line
        if ($ParseStatus) {
            if ($path.Length -lt 4) {
                continue
            }
            $path = $path.Substring(3).Trim()
            if ($path.Contains(" -> ", [StringComparison]::Ordinal)) {
                $path = $path.Substring($path.LastIndexOf(" -> ", [StringComparison]::Ordinal) + 4)
            }
        }
        $path = Normalize-RelativePath -Path $path
        if (-not [String]::IsNullOrWhiteSpace($path)) {
            $paths.Add($path) | Out-Null
        }
    }

    return ,$paths
}

function Get-SourceDates {
    param([Parameter(Mandatory = $true)][string]$Revision)

    $dates = @{}
    $currentDate = $null
    $output = Invoke-Git -Arguments @("log", "--format=__COMMIT__%H|%cs", "--name-only", $Revision, "--")
    foreach ($line in @($output -split "`n")) {
        $trimmedLine = ([string]$line).Trim()
        if ($trimmedLine -match "^__COMMIT__[0-9a-fA-F]{40}\|(?<date>\d{4}-\d{2}-\d{2})$") {
            $currentDate = $Matches["date"]
            continue
        }
        if ($null -eq $currentDate -or [String]::IsNullOrWhiteSpace($trimmedLine)) {
            continue
        }

        $path = Normalize-RelativePath -Path $trimmedLine
        if (-not $dates.ContainsKey($path)) {
            $dates[$path] = $currentDate
        }
    }

    return $dates
}

function Get-EditableBranch {
    param([AllowEmptyString()][string]$RequestedBranch)

    if (-not [String]::IsNullOrWhiteSpace($RequestedBranch)) {
        return $RequestedBranch.Trim()
    }

    $remoteHead = Invoke-Git @("symbolic-ref", "--quiet", "--short", "refs/remotes/origin/HEAD")
    if ($remoteHead -match "^origin/(?<branch>.+)$") {
        return $Matches["branch"]
    }

    return $null
}

function Test-SourceFileIsCommittedAtRevision {
    param(
        [Parameter(Mandatory = $true)][string]$RelativePath,
        [Parameter(Mandatory = $true)]$TrackedPaths,
        [Parameter(Mandatory = $true)]$ChangedPaths
    )

    return $TrackedPaths.Contains($RelativePath) -and -not $ChangedPaths.Contains($RelativePath)
}

function Expand-GlobPattern {
    param([Parameter(Mandatory = $true)][string]$Pattern)

    $open = $Pattern.IndexOf("{", [StringComparison]::Ordinal)
    if ($open -lt 0) {
        return @($Pattern)
    }

    $close = $Pattern.IndexOf("}", $open + 1, [StringComparison]::Ordinal)
    if ($close -lt 0) {
        return @($Pattern)
    }

    $prefix = $Pattern.Substring(0, $open)
    $suffix = $Pattern.Substring($close + 1)
    $alternatives = $Pattern.Substring($open + 1, $close - $open - 1).Split(",")
    $expanded = New-Object "System.Collections.Generic.List[string]"
    foreach ($alternative in $alternatives) {
        foreach ($result in @(Expand-GlobPattern -Pattern ($prefix + $alternative + $suffix))) {
            $expanded.Add($result)
        }
    }

    return @($expanded)
}

function ConvertTo-GlobRegex {
    param([Parameter(Mandatory = $true)][string]$Pattern)

    $normalized = Normalize-RelativePath $Pattern
    $escaped = [Regex]::Escape($normalized)
    $escaped = $escaped.Replace("\*\*/", "(?:.*/)?")
    $escaped = $escaped.Replace("\*\*", ".*")
    $escaped = $escaped.Replace("\*", "[^/]*")
    $escaped = $escaped.Replace("\?", "[^/]")
    return "^{0}$" -f $escaped
}

function Test-GlobMatch {
    param(
        [Parameter(Mandatory = $true)][string]$Path,
        [Parameter(Mandatory = $true)][string]$Pattern
    )

    foreach ($expandedPattern in @(Expand-GlobPattern -Pattern $Pattern)) {
        $regex = ConvertTo-GlobRegex -Pattern $expandedPattern
        if ([Regex]::IsMatch($Path, $regex, [Text.RegularExpressions.RegexOptions]::IgnoreCase)) {
            return $true
        }
    }

    return $false
}

function Get-RepositoryFiles {
    $files = New-Object "System.Collections.Generic.List[object]"
    $pendingDirectories = New-Object "System.Collections.Generic.Queue[string]"
    $pendingDirectories.Enqueue($script:RepoRoot)
    while ($pendingDirectories.Count -gt 0) {
        $currentDirectory = $pendingDirectories.Dequeue()
        foreach ($entry in @(Get-ChildItem -LiteralPath $currentDirectory -Force)) {
            if ($entry.PSIsContainer) {
                if ($entry.Name -in @(".git", "_site", "_artifacts")) {
                    continue
                }
                $pendingDirectories.Enqueue($entry.FullName)
                continue
            }

            $relativePath = ConvertTo-RepositoryRelativePath -Path $entry.FullName
            $files.Add([PSCustomObject]@{
                    RelativePath = $relativePath
                    FullPath = $entry.FullName
                })
        }
    }

    return $files.ToArray()
}

function Get-ContentSpecs {
    param([Parameter(Mandatory = $true)]$Configuration)

    $build = Get-ObjectProperty -Object $Configuration -Name "build"
    $content = Get-ObjectProperty -Object $build -Name "content"
    $specs = New-Object "System.Collections.Generic.List[object]"
    foreach ($entry in @($content)) {
        if ($null -eq $entry) {
            continue
        }

        $files = Get-ObjectProperty -Object $entry -Name "files"
        if ($null -eq $files) {
            continue
        }

        $excludes = @()
        $excludeValue = Get-ObjectProperty -Object $entry -Name "exclude"
        if ($null -ne $excludeValue) {
            $excludes = @($excludeValue)
        }

        $src = Normalize-RelativePath ([string](Get-ObjectProperty -Object $entry -Name "src"))
        $dest = Normalize-RelativePath ([string](Get-ObjectProperty -Object $entry -Name "dest"))
        foreach ($pattern in @($files)) {
            if ([String]::IsNullOrWhiteSpace([string]$pattern)) {
                continue
            }

            $specs.Add([PSCustomObject]@{
                    Pattern = [string]$pattern
                    Excludes = $excludes
                    SourceRoot = $src
                    DestinationRoot = $dest
                })
        }
    }

    return $specs.ToArray()
}

function Get-OutputRelativePath {
    param(
        [Parameter(Mandatory = $true)][string]$SourcePath,
        [AllowEmptyString()][string]$SourceRoot,
        [AllowEmptyString()][string]$DestinationRoot
    )

    $relativePath = $SourcePath
    if (-not [String]::IsNullOrWhiteSpace($SourceRoot)) {
        $sourcePrefix = $SourceRoot.TrimEnd("/") + "/"
        if ($SourcePath.StartsWith($sourcePrefix, [StringComparison]::OrdinalIgnoreCase)) {
            $relativePath = $SourcePath.Substring($sourcePrefix.Length)
        }
        elseif ([string]::Equals($SourcePath, $SourceRoot, [StringComparison]::OrdinalIgnoreCase)) {
            $relativePath = [IO.Path]::GetFileName($SourcePath)
        }
    }

    if (-not [String]::IsNullOrWhiteSpace($DestinationRoot)) {
        $relativePath = $DestinationRoot.TrimEnd("/") + "/" + $relativePath
    }

    return [Regex]::Replace($relativePath, "\.(?:md|yml|yaml)$", ".html", [Text.RegularExpressions.RegexOptions]::IgnoreCase)
}

function Get-ContentRecords {
    param([Parameter(Mandatory = $true)]$Configuration)

    $files = @(Get-RepositoryFiles)
    $specs = @(Get-ContentSpecs -Configuration $Configuration)
    $records = @{}
    foreach ($spec in $specs) {
        foreach ($file in $files) {
            $matchPath = $file.RelativePath
            if (-not [String]::IsNullOrWhiteSpace($spec.SourceRoot)) {
                $sourcePrefix = $spec.SourceRoot.TrimEnd("/") + "/"
                if (-not $file.RelativePath.StartsWith($sourcePrefix, [StringComparison]::OrdinalIgnoreCase)) {
                    continue
                }
                $matchPath = $file.RelativePath.Substring($sourcePrefix.Length)
            }

            if (-not (Test-GlobMatch -Path $matchPath -Pattern $spec.Pattern)) {
                continue
            }

            $excluded = $false
            foreach ($exclude in @($spec.Excludes)) {
                if (Test-GlobMatch -Path $matchPath -Pattern ([string]$exclude)) {
                    $excluded = $true
                    break
                }
            }
            if ($excluded) {
                continue
            }

            $records[$file.RelativePath] = [PSCustomObject]@{
                SourcePath = $file.RelativePath
                OutputPath = Get-OutputRelativePath `
                    -SourcePath $file.RelativePath `
                    -SourceRoot $spec.SourceRoot `
                    -DestinationRoot $spec.DestinationRoot
            }
        }
    }

    return @($records.Values | Sort-Object SourcePath)
}

function Get-ConfiguredBaseUrl {
    param(
        [Parameter(Mandatory = $true)]$Configuration,
        [AllowEmptyString()][string]$Override
    )

    $configured = $Override
    if ([String]::IsNullOrWhiteSpace($configured)) {
        $build = Get-ObjectProperty -Object $Configuration -Name "build"
        $sitemap = Get-ObjectProperty -Object $build -Name "sitemap"
        $configured = [string](Get-ObjectProperty -Object $sitemap -Name "baseUrl")
    }
    if ([String]::IsNullOrWhiteSpace($configured) -or $configured -notmatch "^https?://") {
        return ""
    }

    return $configured.TrimEnd("/") + "/"
}

function ConvertTo-UrlPath {
    param([Parameter(Mandatory = $true)][string]$Path)

    return (($Path.Replace("\", "/").Trim("/") -split "/") | ForEach-Object {
            [Uri]::EscapeDataString($_)
        }) -join "/"
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
        return
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
}

$script:RepoRoot = ConvertTo-FullPath -Path $RepositoryRoot
$docFxConfigFullPath = ConvertTo-FullPath -Path $DocFxConfigPath
$outputFullPath = ConvertTo-FullPath -Path $OutputPath
if (-not (Test-Path -LiteralPath $docFxConfigFullPath -PathType Leaf)) {
    throw "DocFX configuration '$docFxConfigFullPath' does not exist."
}

$configuration = Get-Content -LiteralPath $docFxConfigFullPath -Raw | ConvertFrom-Json
$baseUrl = Get-ConfiguredBaseUrl -Configuration $configuration -Override ""
$revision = Get-SourceRevision -RequestedRevision $SourceRevision
$sourceRepository = $SourceRepository.TrimEnd("/")
if ($sourceRepository -notmatch "^https?://") {
    throw "SourceRepository must be an HTTP or HTTPS URL."
}

$canonicalUrls = [ordered]@{}
$sourceEditUrls = [ordered]@{}
$sourceCommits = [ordered]@{}
$sourceDates = [ordered]@{}
$sourceDateYears = [ordered]@{}
$sourceDateMonths = [ordered]@{}
$sourceDateDays = [ordered]@{}
$sourceBlobs = [ordered]@{}
$records = @(Get-ContentRecords -Configuration $configuration)
$editableBranch = Get-EditableBranch -RequestedBranch $EditBranch
$trackedPaths = $null
$changedPaths = $null
$sourceDatesByPath = @{}
if ($null -ne $revision) {
    $trackedPaths = Get-GitPathSet -Arguments @("ls-tree", "-r", "--name-only", $revision)
    $changedPaths = Get-GitPathSet -Arguments @("status", "--porcelain=v1", "--untracked-files=all") -ParseStatus
    foreach ($path in (Get-GitPathSet -Arguments @("diff", "--name-only", $revision, "--"))) {
        $changedPaths.Add($path) | Out-Null
    }
    foreach ($path in (Get-GitPathSet -Arguments @("diff", "--name-only", "--cached", $revision, "--"))) {
        $changedPaths.Add($path) | Out-Null
    }
    $sourceDatesByPath = Get-SourceDates -Revision $revision
}

foreach ($record in $records) {
    if (-not [String]::IsNullOrWhiteSpace($baseUrl)) {
        $canonicalUrls[$record.SourcePath] = $baseUrl + (ConvertTo-UrlPath -Path $record.OutputPath)
    }
    if (-not [String]::IsNullOrWhiteSpace($editableBranch)) {
        $sourceEditUrls[$record.SourcePath] = "{0}/edit/{1}/{2}" -f `
            $sourceRepository, `
            (ConvertTo-UrlPath -Path $editableBranch), `
            (ConvertTo-UrlPath -Path $record.SourcePath)
    }

    if ($null -eq $revision -or -not (Test-SourceFileIsCommittedAtRevision -RelativePath $record.SourcePath -TrackedPaths $trackedPaths -ChangedPaths $changedPaths)) {
        continue
    }

    $sourceCommits[$record.SourcePath] = $revision
    $sourceBlobs[$record.SourcePath] = "{0}/blob/{1}/{2}" -f `
        $sourceRepository, `
        $revision, `
        (ConvertTo-UrlPath -Path $record.SourcePath)
    $sourceDate = if ($sourceDatesByPath.ContainsKey($record.SourcePath)) {
        $sourceDatesByPath[$record.SourcePath]
    }
    else {
        $null
    }
    if (-not [String]::IsNullOrWhiteSpace($sourceDate)) {
        $sourceDates[$record.SourcePath] = $sourceDate
        $dateParts = $sourceDate.Split("-")
        $sourceDateYears[$record.SourcePath] = $dateParts[0]
        $sourceDateMonths[$record.SourcePath] = $dateParts[1]
        $sourceDateDays[$record.SourcePath] = $dateParts[2]
    }
}

$metadata = [ordered]@{}
if ($canonicalUrls.Count -gt 0) {
    $metadata["canonicalUrl"] = $canonicalUrls
}
if ($sourceEditUrls.Count -gt 0) {
    $metadata["sourceurl"] = $sourceEditUrls
}
if ($sourceDates.Count -gt 0) {
    $metadata["dateModified"] = $sourceDates
    $metadata["_sourceDateYear"] = $sourceDateYears
    $metadata["_sourceDateMonth"] = $sourceDateMonths
    $metadata["_sourceDateDay"] = $sourceDateDays
}
if ($sourceCommits.Count -gt 0) {
    $metadata["sourceCommit"] = $sourceCommits
}
if ($sourceBlobs.Count -gt 0) {
    $metadata["sourceBlob"] = $sourceBlobs
}

$json = ($metadata | ConvertTo-Json -Depth 10) + "`n"
Write-TextIfChanged -Path $outputFullPath -Text $json

Write-Output ("Generated HTML source metadata for {0} content file(s)." -f $records.Count)
if ($null -eq $revision) {
    Write-Output "Immutable source metadata is unavailable because no commit revision could be resolved."
}
else {
    Write-Output ("Source revision: {0}" -f $revision)
}
$global:LASTEXITCODE = 0
