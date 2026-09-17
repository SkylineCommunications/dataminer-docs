[CmdletBinding()]
param(
    [string]$RepositoryRoot = (Join-Path $PSScriptRoot ".."),
    [string]$Path = (Join-Path $PSScriptRoot "..\_artifacts\ai-content-manifest.json"),
    [string]$SchemaPath = (Join-Path $PSScriptRoot "..\contributing\metadata\ai-content-manifest-v1.schema.json")
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

function Get-StringArray {
    param([AllowNull()][AllowEmptyString()][AllowEmptyCollection()]$Value)

    if ($null -eq $Value) {
        return @()
    }
    if ($Value -is [string]) {
        return @([string]$Value)
    }
    return @($Value | ForEach-Object { [string]$_ })
}

function Assert-UniqueSortedStrings {
    param(
        [Parameter(Mandatory = $true)][AllowNull()][AllowEmptyString()][AllowEmptyCollection()]$Value,
        [Parameter(Mandatory = $true)][string]$Context
    )

    $items = @(Get-StringArray $Value)
    Assert-Condition (@($items | Sort-Object -Unique).Count -eq $items.Count) "$Context contains duplicate values."
    Assert-Condition (($items -join "`n") -eq (@($items | Sort-Object) -join "`n")) "$Context is not sorted deterministically."
}

function Get-NormalizedTextSha256 {
    param([Parameter(Mandatory = $true)][string]$Path)

    $text = [IO.File]::ReadAllText($Path)
    $normalized = [Regex]::Replace($text, "`r`n?", "`n")
    $bytes = [Text.Encoding]::UTF8.GetBytes($normalized)
    $hash = [Security.Cryptography.SHA256]::Create()
    try {
        return ([BitConverter]::ToString($hash.ComputeHash($bytes))).Replace("-", "").ToLowerInvariant()
    }
    finally {
        $hash.Dispose()
    }
}

function Assert-Previous {
    param(
        [Parameter(Mandatory = $true)]$Previous,
        [Parameter(Mandatory = $true)][string]$Context
    )

    Assert-Properties `
        -Object $Previous `
        -Required @("sourcePath", "url", "sourceCommit", "sourceBlob", "contentHash") `
        -Allowed @("sourcePath", "url", "sourceCommit", "sourceBlob", "contentHash") `
        -Context $Context
    Assert-Condition (-not [IO.Path]::IsPathRooted([string]$Previous.sourcePath)) "$Context has an absolute source path."
    Assert-Condition ([string]$Previous.sourcePath -notmatch "\\") "$Context has a Windows path."
    Assert-Condition ([string]$Previous.sourceCommit -match "^[0-9a-f]{40}$") "$Context has an invalid source commit."
    Assert-Condition ([string]$Previous.contentHash -match "^[0-9a-f]{64}$") "$Context has an invalid content hash."
    Assert-Condition ([string]$Previous.sourceBlob -notmatch "\\") "$Context has a Windows source URL."
}

$root = ConvertTo-FullPath $RepositoryRoot
$manifestPath = ConvertTo-FullPath $Path
$schemaFile = ConvertTo-FullPath $SchemaPath
Assert-Condition (Test-Path -LiteralPath $root -PathType Container) "Repository root '$root' does not exist."
Assert-Condition (Test-Path -LiteralPath $manifestPath -PathType Leaf) "AI content manifest '$manifestPath' does not exist."
Assert-Condition (Test-Path -LiteralPath $schemaFile -PathType Leaf) "AI content manifest schema '$schemaFile' does not exist."

try {
    $schema = Get-Content -LiteralPath $schemaFile -Raw | ConvertFrom-Json
}
catch {
    throw "AI content manifest schema '$schemaFile' is not valid JSON."
}
Assert-Condition ([string]$schema.title -eq "DataMiner AI content manifest") "Unexpected AI content manifest schema."

try {
    $manifestJson = Get-Content -LiteralPath $manifestPath -Raw
    $manifest = $manifestJson | ConvertFrom-Json
}
catch {
    throw "AI content manifest '$manifestPath' is not valid JSON."
}

if ($null -ne (Get-Command Test-Json -ErrorAction SilentlyContinue)) {
    try {
        if (-not (Test-Json -Json $manifestJson -SchemaFile $schemaFile)) {
            throw "The AI content manifest does not conform to the committed JSON Schema."
        }
    }
    catch {
        throw "AI content manifest JSON Schema validation failed: $($_.Exception.Message)"
    }
}

Assert-Properties `
    -Object $manifest `
    -Required @("schemaVersion", "format", "visibility", "generator", "schema", "source", "scope", "license", "counts", "entries", "gaps") `
    -Allowed @("schemaVersion", "format", "visibility", "generator", "schema", "source", "scope", "license", "counts", "entries", "gaps") `
    -Context "manifest"
Assert-Condition ([int]$manifest.schemaVersion -eq 1) "Unsupported AI content manifest schema version."
Assert-Condition ([string]$manifest.format -eq "json") "The AI content manifest format is not JSON."
Assert-Condition ([string]$manifest.visibility -eq "metadata-only") "The AI content manifest is not metadata-only."

Assert-Properties `
    -Object $manifest.generator `
    -Required @("name", "version") `
    -Allowed @("name", "version") `
    -Context "manifest.generator"
Assert-Condition ([string]$manifest.generator.name -eq "scripts/generate-ai-content-manifest.ps1") "Unexpected AI content manifest generator."
Assert-Condition (-not [String]::IsNullOrWhiteSpace([string]$manifest.generator.version)) "AI content manifest generator version is empty."

Assert-Properties `
    -Object $manifest.schema `
    -Required @("name", "version") `
    -Allowed @("name", "version") `
    -Context "manifest.schema"
Assert-Condition ([string]$manifest.schema.name -eq "contributing/metadata/ai-content-manifest-v1.schema.json") "Unexpected AI content manifest schema name."
Assert-Condition ([int]$manifest.schema.version -eq 1) "Unexpected AI content manifest schema version."

Assert-Properties `
    -Object $manifest.source `
    -Required @("repository", "revision", "revisionSource", "configuration", "baseUrl") `
    -Allowed @("repository", "revision", "revisionSource", "configuration", "baseUrl") `
    -Context "manifest.source"
Assert-Condition ([string]$manifest.source.repository -eq "SkylineCommunications/dataminer-docs") "Unexpected source repository."
Assert-Condition ([string]$manifest.source.revision -match "^[0-9a-f]{40}$") "Source revision is not an immutable full commit."
Assert-Condition ([string]$manifest.source.revisionSource -in @("argument", "git")) "Invalid source revision source."
Assert-Condition ([string]$manifest.source.baseUrl -match "^https?://") "Source base URL is not absolute."
Assert-Condition ([string]$manifest.source.baseUrl -notmatch "\\") "Source base URL contains a Windows path."
Assert-Properties `
    -Object $manifest.source.configuration `
    -Required @("path", "sha256") `
    -Allowed @("path", "sha256") `
    -Context "manifest.source.configuration"
Assert-Condition ([string]$manifest.source.configuration.path -eq "docfx.json") "Unexpected configuration path."
Assert-Condition ([string]$manifest.source.configuration.sha256 -match "^[0-9a-f]{64}$") "Invalid configuration hash."
$configurationPath = Join-Path $root ([string]$manifest.source.configuration.path)
if (Test-Path -LiteralPath $configurationPath -PathType Leaf) {
    Assert-Condition ((Get-FileHash -LiteralPath $configurationPath -Algorithm SHA256).Hash.ToLowerInvariant() -eq [string]$manifest.source.configuration.sha256) "Configuration hash does not match docfx.json."
}

Assert-Properties `
    -Object $manifest.scope `
    -Required @("sourcePaths", "domains") `
    -Allowed @("sourcePaths", "domains") `
    -Context "manifest.scope"
Assert-UniqueSortedStrings -Value $manifest.scope.sourcePaths -Context "manifest.scope.sourcePaths"
Assert-UniqueSortedStrings -Value $manifest.scope.domains -Context "manifest.scope.domains"

Assert-Properties `
    -Object $manifest.license `
    -Required @("identifier", "name", "url", "attribution", "source") `
    -Allowed @("identifier", "name", "url", "attribution", "source") `
    -Context "manifest.license"
Assert-Condition ([string]$manifest.license.identifier -eq "CC BY-NC-ND 4.0") "The D0 license identifier is missing."
Assert-Condition ([string]$manifest.license.name -eq "Creative Commons Attribution-NonCommercial-NoDerivatives 4.0 International") "The D0 license name is missing."
Assert-Condition ([string]$manifest.license.url -eq "https://creativecommons.org/licenses/by-nc-nd/4.0/") "The D0 license URL is missing."
Assert-Condition ([string]$manifest.license.attribution -eq "Skyline Communications") "The D0 attribution is missing."
Assert-Condition ([string]$manifest.license.source -eq "contributing/CTB_Documentation_Corpus_Policy.md") "The D0 policy source is missing."

Assert-Properties `
    -Object $manifest.counts `
    -Required @("current", "added", "changed", "moved", "unchanged", "removed", "tombstones", "total") `
    -Allowed @("current", "added", "changed", "moved", "unchanged", "removed", "tombstones", "total") `
    -Context "manifest.counts"
foreach ($countName in @("current", "added", "changed", "moved", "unchanged", "removed", "tombstones", "total")) {
    Assert-Condition ([int]$manifest.counts.$countName -ge 0) "manifest.counts.$countName is negative."
}

$entries = @($manifest.entries)
$identitySet = @{}
$currentEntries = @()
$removedEntries = @()
$expectedOrder = @($entries | Sort-Object uid, tombstone, sourcePath)
for ($index = 0; $index -lt $entries.Count; $index++) {
    Assert-Condition ([string]$entries[$index].uid -eq [string]$expectedOrder[$index].uid -and
        [bool]$entries[$index].tombstone -eq [bool]$expectedOrder[$index].tombstone -and
        [string]$entries[$index].sourcePath -eq [string]$expectedOrder[$index].sourcePath) "Manifest entries are not sorted by UID and source path."
}

foreach ($entry in $entries) {
    $context = "manifest.entries '$($entry.uid)'"
    Assert-Properties `
        -Object $entry `
        -Required @("uid", "url", "sourcePath", "sourceCommit", "sourceBlob", "contentHash", "type", "area", "domain", "authority", "authoritySource", "lifecycle", "appliesTo", "version", "compatibility", "license", "attribution", "xrefs", "dependencies", "changeType", "tombstone", "moved") `
        -Allowed @("uid", "url", "sourcePath", "sourceCommit", "sourceBlob", "contentHash", "type", "area", "domain", "authority", "authoritySource", "lifecycle", "appliesTo", "version", "compatibility", "license", "attribution", "xrefs", "dependencies", "changeType", "tombstone", "moved", "removedInCommit", "previous") `
        -Context $context
    Assert-Condition (-not [String]::IsNullOrWhiteSpace([string]$entry.uid)) "$context has no UID."
    $identityKey = [string]$entry.uid + "|" + [string]$entry.sourcePath
    Assert-Condition (-not $identitySet.ContainsKey($identityKey)) "Duplicate manifest page identity '$identityKey'."
    $identitySet[$identityKey] = $true
    Assert-Condition ([string]$entry.sourcePath -notmatch "\\") "$context has a Windows source path."
    Assert-Condition (-not [IO.Path]::IsPathRooted([string]$entry.sourcePath)) "$context has an absolute source path."
    Assert-Condition ([string]$entry.sourceCommit -match "^[0-9a-f]{40}$") "$context has an invalid source commit."
    Assert-Condition ([string]$entry.contentHash -match "^[0-9a-f]{64}$") "$context has an invalid content hash."
    Assert-Condition ([string]$entry.sourceBlob -notmatch "\\") "$context has a Windows source URL."
    Assert-Condition ([string]$entry.url -notmatch "\\") "$context has a Windows URL."
    Assert-Condition ([string]$entry.type -in @("conceptual", "schema", "api", "example", "release-note", "legacy")) "$context has an invalid content type."
    Assert-Condition ([string]$entry.area -in @("root", "dataminer", "develop", "solutions", "tutorials", "connectors", "release-notes", "contributing", "unknown")) "$context has an invalid area."
    Assert-Condition (-not [String]::IsNullOrWhiteSpace([string]$entry.domain)) "$context has no domain value."
    Assert-Condition ([string]$entry.authority -in @("canonical", "reference", "illustrative", "historical", "unknown", "not_applicable")) "$context has an invalid authority."
    Assert-Condition (-not [String]::IsNullOrWhiteSpace([string]$entry.authoritySource)) "$context has no authority source sentinel."
    Assert-Condition ([string]$entry.lifecycle -in @("draft", "active", "deprecated", "archived", "unknown")) "$context has an invalid lifecycle."
    Assert-Condition (-not [String]::IsNullOrWhiteSpace([string]$entry.version)) "$context has no version sentinel."
    Assert-UniqueSortedStrings -Value $entry.appliesTo -Context "$context.appliesTo"
    Assert-UniqueSortedStrings -Value $entry.xrefs -Context "$context.xrefs"
    Assert-UniqueSortedStrings -Value $entry.dependencies -Context "$context.dependencies"
    Assert-Condition ([string]$entry.license -eq "CC BY-NC-ND 4.0") "$context has an invalid license."
    Assert-Condition ([string]$entry.attribution -eq "Skyline Communications") "$context has an invalid attribution."

    Assert-Properties `
        -Object $entry.compatibility `
        -Required @("uid", "url") `
        -Allowed @("uid", "url", "urlAliases") `
        -Context "$context.compatibility"
    Assert-Condition ([string]$entry.compatibility.uid -in @("stable", "unknown", "not_applicable")) "$context has an invalid UID compatibility value."
    Assert-Condition ([string]$entry.compatibility.url -in @("stable", "unknown", "redirect_required", "not_applicable")) "$context has an invalid URL compatibility value."
    if (@($entry.compatibility.PSObject.Properties.Name) -contains "urlAliases") {
        Assert-UniqueSortedStrings -Value $entry.compatibility.urlAliases -Context "$context.compatibility.urlAliases"
    }

    $changeType = [string]$entry.changeType
    Assert-Condition ($changeType -in @("added", "changed", "moved", "unchanged", "removed")) "$context has an invalid change type."
    if ($entry.tombstone) {
        $removedEntries += $entry
        Assert-Condition ($changeType -eq "removed") "$context tombstones must have changeType 'removed'."
        Assert-Condition (@($entry.PSObject.Properties.Name) -contains "removedInCommit") "$context tombstone has no removal commit."
        Assert-Condition ([string]$entry.removedInCommit -match "^[0-9a-f]{40}$") "$context has an invalid removal commit."
        Assert-Condition (-not $entry.moved) "$context tombstone cannot be marked moved."
        Assert-Condition (@($entry.PSObject.Properties.Name) -notcontains "previous") "$context tombstone cannot contain a previous record."
    }
    else {
        $currentEntries += $entry
        Assert-Condition ($changeType -ne "removed") "$context current entries cannot be removed."
        Assert-Condition (@($entry.PSObject.Properties.Name) -notcontains "removedInCommit") "$context current entry has a removal commit."
        if ($changeType -eq "moved") {
            Assert-Condition $entry.moved "$context moved entries must set moved=true."
        }
        if ($changeType -eq "added" -or $changeType -eq "unchanged") {
            Assert-Condition (-not $entry.moved) "$context $changeType entry cannot be moved."
            Assert-Condition (@($entry.PSObject.Properties.Name) -notcontains "previous") "$context $changeType entry cannot contain a previous record."
        }
    }

    if ($entry.moved) {
        Assert-Condition (@($entry.PSObject.Properties.Name) -contains "previous") "$context moved entry has no previous identity."
    }
    if (@($entry.PSObject.Properties.Name) -contains "previous") {
        Assert-Previous -Previous $entry.previous -Context "$context.previous"
    }

    if (-not $entry.tombstone) {
        $sourceFile = Join-Path $root ([string]$entry.sourcePath).Replace("/", "\")
        Assert-Condition (Test-Path -LiteralPath $sourceFile -PathType Leaf) "$context source file '$($entry.sourcePath)' does not exist."
        Assert-Condition ((Get-NormalizedTextSha256 -Path $sourceFile) -eq [string]$entry.contentHash) "$context content hash does not match its source file."
    }
}

$gapCodes = @{}
foreach ($gap in @($manifest.gaps)) {
    Assert-Properties -Object $gap -Required @("code", "count") -Allowed @("code", "count") -Context "manifest.gap"
    Assert-Condition (-not [String]::IsNullOrWhiteSpace([string]$gap.code)) "A manifest gap has no code."
    Assert-Condition ([int]$gap.count -gt 0) "Manifest gap '$($gap.code)' has an invalid count."
    Assert-Condition (-not $gapCodes.ContainsKey([string]$gap.code)) "Duplicate manifest gap '$($gap.code)'."
    $gapCodes[[string]$gap.code] = $true
}

$expectedCounts = @{
    current = $currentEntries.Count
    added = @($currentEntries | Where-Object { $_.changeType -eq "added" }).Count
    changed = @($currentEntries | Where-Object { $_.changeType -eq "changed" }).Count
    moved = @($currentEntries | Where-Object { $_.moved }).Count
    unchanged = @($currentEntries | Where-Object { $_.changeType -eq "unchanged" }).Count
    removed = $removedEntries.Count
    tombstones = $removedEntries.Count
    total = $entries.Count
}
foreach ($name in $expectedCounts.Keys) {
    Assert-Condition ([int]$manifest.counts.$name -eq [int]$expectedCounts[$name]) "manifest.counts.$name does not match the entries."
}

Write-Output "AI content manifest validation passed."
Write-Output "Current entries: $($currentEntries.Count)."
Write-Output "Tombstones: $($removedEntries.Count)."
