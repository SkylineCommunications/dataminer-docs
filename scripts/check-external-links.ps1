[CmdletBinding()]
param(
    [string]$RepositoryRoot = (Join-Path $PSScriptRoot ".."),
    [string]$ReportPath = (Join-Path $PSScriptRoot "..\_artifacts\external-link-report.json"),
    [string]$BaseRevision,
    [string[]]$Path,
    [ValidateRange(1, 120)][int]$TimeoutSeconds = 10,
    [ValidateRange(0, 5)][int]$Retries = 2,
    [switch]$FailOnError
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
    param(
        [string[]]$RequestedPaths,
        [AllowEmptyString()][string]$Revision
    )

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
                throw "External-link path '$requestedPath' is not a Markdown file."
            }
            $paths += $candidate
        }
        return @($paths | Sort-Object -Unique)
    }

    $diffRevision = $Revision
    if ([String]::IsNullOrWhiteSpace($diffRevision)) {
        $diffRevision = ""
    }
    if (-not [String]::IsNullOrWhiteSpace($diffRevision)) {
        $diffPaths = @(& git -C $script:RepositoryRoot diff --name-only --diff-filter=ACMR "$diffRevision" HEAD -- "*.md" 2>$null)
        if ($LASTEXITCODE -ne 0) {
            throw "Unable to determine changed Markdown files relative to '$diffRevision'."
        }

        $available = @{}
        foreach ($file in @(Get-MarkdownPaths -RequestedPaths @() -Revision "")) {
            $available[(ConvertTo-RepositoryRelativePath $file).ToLowerInvariant()] = $file
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

    $paths = @()
    foreach ($file in Get-ChildItem -LiteralPath $script:RepositoryRoot -File -Filter "*.md") {
        $paths += $file.FullName
    }
    foreach ($directoryName in @("contributing", "dataminer", "develop", "release-notes", "solutions", "tutorials")) {
        $directoryPath = Join-Path $script:RepositoryRoot $directoryName
        if (Test-Path -LiteralPath $directoryPath -PathType Container) {
            $paths += @(Get-ChildItem -LiteralPath $directoryPath -Recurse -File -Filter "*.md" | ForEach-Object { $_.FullName })
        }
    }
    return @($paths | Sort-Object -Unique)
}

function Get-ExternalLinks {
    param(
        [Parameter(Mandatory = $true)][string]$Text,
        [Parameter(Mandatory = $true)][string]$RelativePath
    )

    $lines = @((Normalize-Text $Text) -split "`n")
    $links = New-Object "System.Collections.Generic.List[object]"
    $inFence = $false
    $fence = ""
    $seen = @{}
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

        foreach ($match in [Regex]::Matches($line, '(?<target>https?://[^\s\)>"]+)')) {
            $target = $match.Groups["target"].Value.TrimEnd(".", ",", ";", ":")
            $targetKey = $target.ToLowerInvariant()
            $identity = "$RelativePath|$targetKey"
            if ($seen.ContainsKey($identity)) {
                continue
            }
            $seen[$identity] = $true
            $links.Add([PSCustomObject][ordered]@{
                    path = $RelativePath
                    line = $index + 1
                    url = $target
                }) | Out-Null
        }
    }

    return @($links.ToArray())
}

function Test-ExternalLink {
    param(
        [Parameter(Mandatory = $true)][string]$Url,
        [Parameter(Mandatory = $true)][System.Net.Http.HttpClient]$Client
    )

    $requestUrl = $Url.Split("#")[0]
    $lastError = ""
    $lastStatus = $null
    for ($attempt = 1; $attempt -le ($Retries + 1); $attempt++) {
        $cancellation = New-Object Threading.CancellationTokenSource
        $cancellation.CancelAfter($TimeoutSeconds * 1000)
        $response = $null
        try {
            $request = New-Object System.Net.Http.HttpRequestMessage([System.Net.Http.HttpMethod]::Head, $requestUrl)
            try {
                $response = $Client.SendAsync($request, [System.Net.Http.HttpCompletionOption]::ResponseHeadersRead, $cancellation.Token).GetAwaiter().GetResult()
            }
            finally {
                $request.Dispose()
            }
            $lastStatus = [int]$response.StatusCode
            if ($lastStatus -ge 200 -and $lastStatus -lt 400) {
                return [PSCustomObject][ordered]@{
                    status = "passed"
                    httpStatus = $lastStatus
                    attempts = $attempt
                    error = ""
                }
            }
            $lastError = "HTTP $lastStatus"
        }
        catch {
            $lastError = $_.Exception.Message
        }
        finally {
            if ($null -ne $response) {
                $response.Dispose()
            }
            $cancellation.Dispose()
        }

        if ($attempt -le $Retries) {
            Start-Sleep -Milliseconds 200
        }
    }

    return [PSCustomObject][ordered]@{
        status = "failed"
        httpStatus = $lastStatus
        attempts = $Retries + 1
        error = $lastError
    }
}

function Write-Report {
    param(
        [Parameter(Mandatory = $true)]$Report,
        [Parameter(Mandatory = $true)][string]$Path
    )

    $directory = Split-Path -Parent $Path
    if (-not (Test-Path -LiteralPath $directory -PathType Container)) {
        New-Item -ItemType Directory -Path $directory -Force | Out-Null
    }
    $utf8NoBom = New-Object Text.UTF8Encoding($false)
    [IO.File]::WriteAllText($Path, ($Report | ConvertTo-Json -Depth 10), $utf8NoBom)
}

$script:RepositoryRoot = ConvertTo-FullPath $RepositoryRoot
$ReportPath = ConvertTo-FullPath $ReportPath
if (-not (Test-Path -LiteralPath $script:RepositoryRoot -PathType Container)) {
    throw "Repository root '$script:RepositoryRoot' does not exist."
}

$markdownPaths = @(Get-MarkdownPaths -RequestedPaths $Path -Revision $BaseRevision)
$links = New-Object "System.Collections.Generic.List[object]"
foreach ($markdownPath in $markdownPaths) {
    $relativePath = ConvertTo-RepositoryRelativePath $markdownPath
    foreach ($link in @(Get-ExternalLinks -Text ([IO.File]::ReadAllText($markdownPath)) -RelativePath $relativePath)) {
        $links.Add($link) | Out-Null
    }
}

$handler = New-Object System.Net.Http.HttpClientHandler
$handler.AllowAutoRedirect = $true
$client = New-Object System.Net.Http.HttpClient($handler)
$client.Timeout = [TimeSpan]::FromSeconds($TimeoutSeconds)
$client.DefaultRequestHeaders.UserAgent.ParseAdd("SkylineCommunications/dataminer-docs external-link-check")
$results = New-Object "System.Collections.Generic.List[object]"
try {
    foreach ($link in @($links | Sort-Object url, path, line)) {
        $check = Test-ExternalLink -Url $link.url -Client $client
        $results.Add([PSCustomObject][ordered]@{
                path = $link.path
                line = $link.line
                url = $link.url
                status = $check.status
                httpStatus = $check.httpStatus
                attempts = $check.attempts
                error = $check.error
            }) | Out-Null
    }
}
finally {
    $client.Dispose()
    $handler.Dispose()
}

$resultArray = @($results.ToArray())
$failures = @($resultArray | Where-Object { $_.status -eq "failed" })
$report = [ordered]@{
    schemaVersion = 1
    gate = "D4.1-external-links"
    policy = [ordered]@{
        timeoutSeconds = $TimeoutSeconds
        retries = $Retries
        attemptsPerUrl = $Retries + 1
        ordinaryPullRequestsBlockOnExternalFailure = $false
        protectedMainOrScheduledRunsMayFail = $true
    }
    baseRevision = if ([String]::IsNullOrWhiteSpace($BaseRevision)) { "full-corpus" } else { $BaseRevision }
    scope = [ordered]@{
        markdownFiles = $markdownPaths.Count
        externalUrls = $resultArray.Count
    }
    summary = [ordered]@{
        passed = @($resultArray | Where-Object { $_.status -eq "passed" }).Count
        failed = $failures.Count
    }
    results = $resultArray
}
Write-Report -Report $report -Path $ReportPath

if ($FailOnError -and $failures.Count -gt 0) {
    throw ("External link check failed for {0} URL(s) after {1} attempt(s) each. See {2}." -f $failures.Count, ($Retries + 1), $ReportPath)
}

if ($failures.Count -gt 0) {
    Write-Warning ("External link check reported {0} failure(s); this non-blocking report does not fail the run." -f $failures.Count)
}
Write-Output ("External link check completed for {0} URL(s); {1} failed. Report: {2}" -f $results.Count, $failures.Count, $ReportPath)
