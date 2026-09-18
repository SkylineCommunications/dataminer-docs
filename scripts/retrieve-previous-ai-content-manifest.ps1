[CmdletBinding()]
param(
    [Parameter(Mandatory = $true)][string]$Repository,
    [Parameter(Mandatory = $true)][string]$CurrentRunId,
    [string]$OutputPath = (Join-Path $PSScriptRoot "..\_artifacts\previous-ai-content-manifest.json"),
    [string]$ArtifactNamePrefix = "ai-content-manifest-"
)

Set-StrictMode -Version 2.0
$ErrorActionPreference = "Stop"

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

function Invoke-GhApi {
    param([Parameter(Mandatory = $true)][string]$Endpoint)

    $result = & gh api --paginate --slurp $Endpoint 2>&1
    if ($LASTEXITCODE -ne 0) {
        throw "GitHub artifact lookup failed."
    }
    return (($result -join "`n").Trim() | ConvertFrom-Json)
}

Assert-Condition ($Repository -match "^[^/]+/[^/]+$") "Repository '$Repository' is not in owner/name form."
Assert-Condition ($CurrentRunId -match "^\d+$") "Current workflow run ID is invalid."
Assert-Condition (-not [String]::IsNullOrWhiteSpace($env:GH_TOKEN)) "GH_TOKEN is required for protected-main artifact retrieval."

$output = ConvertTo-FullPath $OutputPath
$endpoint = "repos/$Repository/actions/artifacts?per_page=100"
$pages = @(Invoke-GhApi -Endpoint $endpoint)
$artifacts = @(
    $pages |
        ForEach-Object { @($_.artifacts) } |
        Where-Object {
            [string]$_.name -like "$ArtifactNamePrefix*" -and
            [string]$_.expired -ne "True" -and
            $null -ne $_.workflow_run -and
            [string]$_.workflow_run.id -ne $CurrentRunId
        } |
        Sort-Object `
            @{ Expression = { [DateTimeOffset]$_.created_at }; Descending = $true }, `
            @{ Expression = { [long]$_.id }; Descending = $true }
)

if ($artifacts.Count -eq 0) {
    Write-Output "No prior AI content manifest artifact was found; the deployment delta will use first-run semantics."
    exit 0
}

$artifact = $artifacts[0]
$temporaryRoot = Join-Path ([IO.Path]::GetTempPath()) ("dataminer-docs-previous-manifest-" + [Guid]::NewGuid().ToString("N"))
$zipPath = Join-Path $temporaryRoot "artifact.zip"
$extractPath = Join-Path $temporaryRoot "extracted"
try {
    New-Item -ItemType Directory -Path $temporaryRoot -Force | Out-Null
    $downloadEndpoint = "repos/$Repository/actions/artifacts/$($artifact.id)/zip"
    & gh api -H "Accept: application/vnd.github+json" $downloadEndpoint --output $zipPath 2>$null
    if ($LASTEXITCODE -ne 0) {
        throw "The prior AI content manifest artifact could not be downloaded."
    }

    Expand-Archive -LiteralPath $zipPath -DestinationPath $extractPath -Force
    $manifestFiles = @(Get-ChildItem -LiteralPath $extractPath -Recurse -File -Filter "ai-content-manifest.json")
    Assert-Condition ($manifestFiles.Count -eq 1) "The prior artifact does not contain exactly one ai-content-manifest.json."
    $outputDirectory = Split-Path -Parent $output
    if (-not (Test-Path -LiteralPath $outputDirectory -PathType Container)) {
        New-Item -ItemType Directory -Path $outputDirectory -Force | Out-Null
    }
    Copy-Item -LiteralPath $manifestFiles[0].FullName -Destination $output -Force
    Write-Output "Retrieved prior AI content manifest artifact $($artifact.name)."
}
finally {
    if (Test-Path -LiteralPath $temporaryRoot) {
        Remove-Item -LiteralPath $temporaryRoot -Recurse -Force
    }
}
