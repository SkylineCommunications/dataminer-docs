[CmdletBinding()]
param(
    [string]$RepositoryRoot = (Join-Path $PSScriptRoot "..")
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
    param([Parameter(Mandatory = $true)][string]$Value)

    if ([IO.Path]::IsPathRooted($Value)) {
        return [IO.Path]::GetFullPath($Value)
    }
    return [IO.Path]::GetFullPath((Join-Path (Get-Location).Path $Value))
}

$root = ConvertTo-FullPath $RepositoryRoot
$discoveryPath = Join-Path $root "llms.txt"
$configurationPath = Join-Path $root "docfx.json"
$policyPath = Join-Path $root "contributing\CTB_Documentation_Corpus_Policy.md"
$searchPath = Join-Path $root "templates\skyline\public\search.js"

Assert-Condition (Test-Path -LiteralPath $discoveryPath -PathType Leaf) "Discovery file '$discoveryPath' does not exist."
Assert-Condition (Test-Path -LiteralPath $configurationPath -PathType Leaf) "DocFX configuration '$configurationPath' does not exist."
Assert-Condition (Test-Path -LiteralPath $policyPath -PathType Leaf) "Public endpoint policy '$policyPath' does not exist."
Assert-Condition (Test-Path -LiteralPath $searchPath -PathType Leaf) "Browser search script '$searchPath' does not exist."

$content = Get-Content -LiteralPath $discoveryPath -Raw
$policy = Get-Content -LiteralPath $policyPath -Raw
$search = Get-Content -LiteralPath $searchPath -Raw
$requiredLinks = @(
    "https://docs.dataminer.services/",
    "https://docs.dataminer.services/sitemap.xml",
    "https://docs.dataminer.services/manifest.json",
    "https://docs.dataminer.services/xrefmap.yml",
    "https://docs.dataminer.services/ai-content-manifest.json",
    "https://raw.githubusercontent.com/SkylineCommunications/dataminer-docs/main/contributing/metadata/ai-content-manifest-v1.schema.json"
)

Assert-Condition ($content.Length -le 2000) "The discovery file is not concise."
Assert-Condition ($content -match "(?im)^# DataMiner Docs\s*$") "The discovery file has no DataMiner Docs heading."
Assert-Condition ($content -match "(?i)DataMiner platform") "The discovery file does not describe the documentation scope."
Assert-Condition ($content -match "(?i)metadata-only") "The discovery file does not identify the manifest as metadata-only."
Assert-Condition ($content -match "(?i)discovery-only") "The discovery file does not identify itself as discovery-only."
Assert-Condition ($content -match "(?i)immutable source revisions") "The discovery file does not identify immutable source revisions as authoritative."
$forbiddenContentPattern = '(?i)(?:_artifacts|topic[-_ ]?packs?|normalized|chunks?|embeddings?|<html|```)'
Assert-Condition ($content -notmatch $forbiddenContentPattern) "The discovery file references internal or corpus content."
Assert-Condition ($content -notmatch "(?i)(?:^|[\s(])[^)\s]+\.md(?:$|[\s)])") "The discovery file contains a source Markdown link."

foreach ($link in $requiredLinks) {
    Assert-Condition ($content.Contains($link)) "The discovery file is missing required link '$link'."
}

$policyLinks = @(
    "https://docs.dataminer.services/manifest.json",
    "https://docs.dataminer.services/xrefmap.yml",
    "https://docs.dataminer.services/ai-content-manifest.json"
)
foreach ($link in $policyLinks) {
    Assert-Condition ($policy.Contains($link)) "The public endpoint policy is missing stable link '$link'."
}
Assert-Condition ($policy -match "(?i)metadata-only") "The public endpoint policy does not define the metadata-only contract."
Assert-Condition ($policy -match "(?i)browser search JavaScript internals are not a public API") "The public endpoint policy does not define the browser search API boundary."
Assert-Condition ($policy -match "(?i)CC BY-NC-ND 4\.0") "The public endpoint policy does not preserve the D0.3 license."
Assert-Condition ($search -match "(?i)BASE_DOCS_URL") "The browser search implementation was not found."

$urls = @([regex]::Matches($content, "https://[^\s)>]+") | ForEach-Object { $_.Value.TrimEnd(".", ",", ";") })
foreach ($url in $urls) {
    Assert-Condition ($requiredLinks -contains $url) "The discovery file contains an unapproved URL '$url'."
}

try {
    $configuration = Get-Content -LiteralPath $configurationPath -Raw | ConvertFrom-Json
}
catch {
    throw "DocFX configuration '$configurationPath' is not valid JSON."
}

$resourceFiles = @($configuration.build.resource | ForEach-Object { @($_.files) })
Assert-Condition ($resourceFiles -contains "llms.txt") "DocFX resources do not include llms.txt."
Assert-Condition ($resourceFiles -contains "ai-content-manifest.json") "DocFX resources do not include the public AI content manifest."

Write-Output "LLM discovery validation passed."
