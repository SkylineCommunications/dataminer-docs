[CmdletBinding()]
param(
    [string]$RepositoryRoot = (Join-Path $PSScriptRoot ".."),
    [string]$OutputPath = (Join-Path $PSScriptRoot "..\_artifacts\ai-content-manifest.json"),
    [string]$PriorManifestPath = "",
    [string]$BaseUrl = "https://docs.dataminer.services/",
    [string]$SourceRevision = "",
    [string]$ValidatorPath = (Join-Path $PSScriptRoot "validate-ai-content-manifest.ps1")
)

Set-StrictMode -Version 2.0
$ErrorActionPreference = "Stop"

$script:GeneratorVersion = "1.0.0"
$script:Repository = "SkylineCommunications/dataminer-docs"
$script:LicenseIdentifier = "CC BY-NC-ND 4.0"
$script:LicenseName = "Creative Commons Attribution-NonCommercial-NoDerivatives 4.0 International"
$script:LicenseUrl = "https://creativecommons.org/licenses/by-nc-nd/4.0/"
$script:Attribution = "Skyline Communications"
$script:SchemaName = "contributing/metadata/ai-content-manifest-v1.schema.json"
$script:SchemaVersion = 1
$script:SourcePaths = @(
    "*.md",
    "contributing/**.md",
    "dataminer/**.md",
    "develop/**.md",
    "release-notes/**.md",
    "solutions/**.md",
    "tutorials/**.md"
)

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

function Get-FileSha256 {
    param([Parameter(Mandatory = $true)][string]$Path)

    return (Get-FileHash -LiteralPath $Path -Algorithm SHA256).Hash.ToLowerInvariant()
}

function Get-GitValue {
    param(
        [Parameter(Mandatory = $true)][string]$Root,
        [Parameter(Mandatory = $true)][string[]]$Arguments
    )

    try {
        $result = & git -C $Root @Arguments 2>$null
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

function Get-SourceRevisionInfo {
    param(
        [Parameter(Mandatory = $true)][string]$Root,
        [AllowEmptyString()][string]$RequestedRevision
    )

    $revision = $RequestedRevision
    $source = "argument"
    if ([String]::IsNullOrWhiteSpace($revision) -or $revision -eq "working-tree") {
        $revision = Get-GitValue -Root $Root -Arguments @("rev-parse", "HEAD")
        $source = "git"
    }

    if ([String]::IsNullOrWhiteSpace($revision)) {
        throw "An immutable source commit is required. Pass -SourceRevision or run inside a Git checkout."
    }

    $revision = $revision.Trim().ToLowerInvariant()
    Assert-Condition ($revision -match "^[0-9a-f]{40}$") "Source revision '$revision' is not a full 40-character commit."
    return [PSCustomObject]@{
        Revision = $revision
        Source = $source
    }
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
            Where-Object { -not [String]::IsNullOrWhiteSpace($_) } |
            Sort-Object -Unique
    )
}

function Get-SourceBlobUrl {
    param(
        [Parameter(Mandatory = $true)][string]$Revision,
        [Parameter(Mandatory = $true)][string]$SourcePath
    )

    return "https://github.com/SkylineCommunications/dataminer-docs/blob/{0}/{1}" -f $Revision, $SourcePath
}

function Get-PreviousIdentity {
    param([Parameter(Mandatory = $true)]$Entry)

    $sourcePath = Get-StringProperty -Object $Entry -Name "sourcePath"
    if ($sourcePath -eq "") {
        $sourcePath = Get-StringProperty -Object $Entry -Name "path"
    }

    $identity = [ordered]@{
        sourcePath = $sourcePath
        url = Get-StringProperty -Object $Entry -Name "url"
        sourceCommit = Get-StringProperty -Object $Entry -Name "sourceCommit"
        sourceBlob = Get-StringProperty -Object $Entry -Name "sourceBlob"
        contentHash = Get-StringProperty -Object $Entry -Name "contentHash"
    }
    foreach ($property in $identity.Keys) {
        Assert-Condition (-not [String]::IsNullOrWhiteSpace([string]$identity[$property])) "Prior manifest entry '$($Entry.uid)' is missing '$property'."
    }
    return $identity
}

function Get-EntryIdentityKey {
    param([Parameter(Mandatory = $true)]$Entry)

    return (Get-StringProperty -Object $Entry -Name "uid") + "|" + (Get-StringProperty -Object $Entry -Name "sourcePath")
}

function Select-PreviousEntry {
    param(
        [Parameter(Mandatory = $true)]$Candidates,
        [Parameter(Mandatory = $true)]$CurrentEntry,
        [Parameter(Mandatory = $true)]$MatchedEntries
    )

    $available = @($Candidates | Where-Object { -not $MatchedEntries.Contains($_) })
    if ($available.Count -eq 0) {
        return $null
    }

    $samePath = @(
        $available |
            Where-Object {
                (Get-StringProperty -Object $_ -Name "sourcePath") -eq [string]$CurrentEntry.sourcePath
            }
    )
    if ($samePath.Count -eq 1) {
        return $samePath[0]
    }
    if ($available.Count -eq 1) {
        return $available[0]
    }

    $sameHash = @(
        $available |
            Where-Object {
                (Get-StringProperty -Object $_ -Name "contentHash") -eq [string]$CurrentEntry.contentHash
            }
    )
    if ($sameHash.Count -eq 1) {
        return $sameHash[0]
    }

    return $null
}

function Get-ManifestEntries {
    param([Parameter(Mandatory = $true)][string]$Path)

    $text = [IO.File]::ReadAllText($Path).Trim()
    if ($text -eq "") {
        throw "Prior manifest '$Path' is empty."
    }

    if ($text.StartsWith("{")) {
        try {
            $manifest = $text | ConvertFrom-Json
        }
        catch {
            throw "Prior manifest '$Path' is not valid JSON."
        }

        if (@($manifest.PSObject.Properties.Name) -contains "entries") {
            return @($manifest.entries)
        }
        if (@($manifest.PSObject.Properties.Name) -contains "metadataManifest" -and $null -ne $manifest.metadataManifest) {
            return @($manifest.metadataManifest.entries)
        }
        throw "Prior manifest '$Path' does not contain an entries array."
    }

    $entries = New-Object "System.Collections.Generic.List[object]"
    foreach ($line in ($text -split "`r?`n")) {
        if ([String]::IsNullOrWhiteSpace($line)) {
            continue
        }
        try {
            $value = $line | ConvertFrom-Json
        }
        catch {
            throw "Prior manifest '$Path' contains an invalid JSONL record."
        }
        if (@($value.PSObject.Properties.Name) -contains "entries") {
            continue
        }
        $entries.Add($value)
    }
    return @($entries.ToArray())
}

function New-PreviousRecord {
    param([Parameter(Mandatory = $true)]$Entry)

    return [ordered]@{
        sourcePath = Get-StringProperty -Object $Entry -Name "sourcePath"
        url = Get-StringProperty -Object $Entry -Name "url"
        sourceCommit = Get-StringProperty -Object $Entry -Name "sourceCommit"
        sourceBlob = Get-StringProperty -Object $Entry -Name "sourceBlob"
        contentHash = Get-StringProperty -Object $Entry -Name "contentHash"
    }
}

function Get-Inventory {
    param(
        [Parameter(Mandatory = $true)][string]$Root,
        [Parameter(Mandatory = $true)][string]$Revision,
        [Parameter(Mandatory = $true)][string]$ManifestBaseUrl,
        [Parameter(Mandatory = $true)][string]$AuditScript
    )

    $temporaryRoot = Join-Path ([IO.Path]::GetTempPath()) ("dataminer-docs-ai-manifest-" + [Guid]::NewGuid().ToString("N"))
    $inventoryPath = Join-Path $temporaryRoot "baseline.json"
    $unusedSitePath = Join-Path $temporaryRoot "no-site"
    New-Item -ItemType Directory -Path $temporaryRoot -Force | Out-Null

    try {
        & $AuditScript `
            -RepositoryRoot $Root `
            -OutputPath $inventoryPath `
            -SitePath $unusedSitePath `
            -ManifestPath "" `
            -XrefMapPath "" `
            -SitemapPath "" `
            -BaseUrl $ManifestBaseUrl `
            -SourceRevision $Revision | Out-Null
        $baseline = Get-Content -LiteralPath $inventoryPath -Raw | ConvertFrom-Json
        Assert-Condition ($null -ne $baseline.metadataManifest) "The D0.3 audit did not produce a metadata manifest."
        return $baseline
    }
    finally {
        if (Test-Path -LiteralPath $temporaryRoot) {
            Remove-Item -LiteralPath $temporaryRoot -Recurse -Force
        }
    }
}

function New-CurrentEntry {
    param(
        [Parameter(Mandatory = $true)]$InventoryEntry,
        [Parameter(Mandatory = $true)][string]$Revision
    )

    $sourcePath = Get-StringProperty -Object $InventoryEntry -Name "sourcePath"
    $uid = Get-StringProperty -Object $InventoryEntry -Name "uid"
    Assert-Condition (-not [String]::IsNullOrWhiteSpace($uid)) "A manifest entry has no stable UID."
    Assert-Condition (-not [String]::IsNullOrWhiteSpace($sourcePath)) "Manifest entry '$uid' has no source path."

    $compatibility = $InventoryEntry.compatibility
    $entry = [ordered]@{
        uid = $uid
        url = Get-StringProperty -Object $InventoryEntry -Name "url"
        sourcePath = $sourcePath.Replace("\", "/")
        sourceCommit = $Revision
        sourceBlob = Get-SourceBlobUrl -Revision $Revision -SourcePath $sourcePath.Replace("\", "/")
        contentHash = Get-StringProperty -Object $InventoryEntry -Name "contentHash"
        type = Get-StringProperty -Object $InventoryEntry -Name "type" -Default "legacy"
        area = Get-StringProperty -Object $InventoryEntry -Name "area" -Default "unknown"
        domain = Get-StringProperty -Object $InventoryEntry -Name "domain" -Default "unknown"
        authority = Get-StringProperty -Object $InventoryEntry -Name "authority" -Default "unknown"
        authoritySource = Get-StringProperty -Object $InventoryEntry -Name "authoritySource" -Default "unknown"
        lifecycle = Get-StringProperty -Object $InventoryEntry -Name "lifecycle" -Default "unknown"
        appliesTo = @(Get-StringArray $InventoryEntry.appliesTo)
        version = Get-StringProperty -Object $InventoryEntry -Name "version" -Default "unknown"
        compatibility = [ordered]@{
            uid = Get-StringProperty -Object $compatibility -Name "uid" -Default "unknown"
            url = Get-StringProperty -Object $compatibility -Name "url" -Default "unknown"
        }
        license = $script:LicenseIdentifier
        attribution = $script:Attribution
        xrefs = @(Get-StringArray $InventoryEntry.xrefs)
        dependencies = @(Get-StringArray $InventoryEntry.dependencies)
        changeType = "added"
        tombstone = $false
        moved = $false
    }
    return $entry
}

function Add-PreviousComparison {
    param(
        [Parameter(Mandatory = $true)]$Entry,
        [AllowNull()]$Previous
    )

    if ($null -eq $Previous) {
        return
    }

    $previousIdentity = Get-PreviousIdentity -Entry $Previous
    $contentChanged = $Entry.contentHash -ne $previousIdentity.contentHash
    $moved = $Entry.sourcePath -ne $previousIdentity.sourcePath -or $Entry.url -ne $previousIdentity.url
    $Entry.moved = $moved
    if ($contentChanged) {
        $Entry.changeType = "changed"
    }
    elseif ($moved) {
        $Entry.changeType = "moved"
    }
    else {
        $Entry.changeType = "unchanged"
    }

    if ($contentChanged -or $moved) {
        $Entry.previous = $previousIdentity
    }
}

function New-TombstoneEntry {
    param(
        [Parameter(Mandatory = $true)]$Previous,
        [Parameter(Mandatory = $true)][string]$RemovalRevision
    )

    $previousIdentity = Get-PreviousIdentity -Entry $Previous
    $compatibility = $Previous.compatibility
    return [ordered]@{
        uid = Get-StringProperty -Object $Previous -Name "uid"
        url = $previousIdentity.url
        sourcePath = $previousIdentity.sourcePath
        sourceCommit = $previousIdentity.sourceCommit
        sourceBlob = $previousIdentity.sourceBlob
        contentHash = $previousIdentity.contentHash
        type = Get-StringProperty -Object $Previous -Name "type" -Default "legacy"
        area = Get-StringProperty -Object $Previous -Name "area" -Default "unknown"
        domain = Get-StringProperty -Object $Previous -Name "domain" -Default "unknown"
        authority = Get-StringProperty -Object $Previous -Name "authority" -Default "unknown"
        authoritySource = Get-StringProperty -Object $Previous -Name "authoritySource" -Default "unknown"
        lifecycle = Get-StringProperty -Object $Previous -Name "lifecycle" -Default "unknown"
        appliesTo = @(Get-StringArray $Previous.appliesTo)
        version = Get-StringProperty -Object $Previous -Name "version" -Default "unknown"
        compatibility = [ordered]@{
            uid = Get-StringProperty -Object $compatibility -Name "uid" -Default "unknown"
            url = Get-StringProperty -Object $compatibility -Name "url" -Default "unknown"
        }
        license = $script:LicenseIdentifier
        attribution = $script:Attribution
        xrefs = @(Get-StringArray $Previous.xrefs)
        dependencies = @(Get-StringArray $Previous.dependencies)
        changeType = "removed"
        tombstone = $true
        moved = $false
        removedInCommit = $RemovalRevision
    }
}

function Get-Configuration {
    param([Parameter(Mandatory = $true)][string]$Root)

    $path = Join-Path $Root "docfx.json"
    Assert-Condition (Test-Path -LiteralPath $path -PathType Leaf) "DocFX configuration '$path' does not exist."
    return [ordered]@{
        path = "docfx.json"
        sha256 = Get-FileSha256 -Path $path
    }
}

function Write-Manifest {
    param(
        [Parameter(Mandatory = $true)][string]$Path,
        [Parameter(Mandatory = $true)]$Manifest
    )

    $directory = Split-Path -Parent $Path
    if (-not (Test-Path -LiteralPath $directory -PathType Container)) {
        New-Item -ItemType Directory -Path $directory -Force | Out-Null
    }
    $json = $Manifest | ConvertTo-Json -Depth 20
    $utf8NoBom = New-Object Text.UTF8Encoding($false)
    [IO.File]::WriteAllText($Path, $json + [Environment]::NewLine, $utf8NoBom)
}

$root = ConvertTo-FullPath $RepositoryRoot
Assert-Condition (Test-Path -LiteralPath $root -PathType Container) "Repository root '$root' does not exist."
$output = ConvertTo-FullPath $OutputPath
$auditScript = Join-Path $PSScriptRoot "audit-docs-baseline.ps1"
$validatorRoot = [IO.Path]::GetFullPath((Join-Path (Split-Path -Parent (ConvertTo-FullPath $ValidatorPath)) ".."))
$schemaPath = Join-Path $validatorRoot $script:SchemaName.Replace("/", "\")
Assert-Condition (Test-Path -LiteralPath $auditScript -PathType Leaf) "Baseline audit generator '$auditScript' does not exist."
Assert-Condition (Test-Path -LiteralPath $schemaPath -PathType Leaf) "Manifest schema '$schemaPath' does not exist."
Assert-Condition (Test-Path -LiteralPath $ValidatorPath -PathType Leaf) "Manifest validator '$ValidatorPath' does not exist."

$revisionInfo = Get-SourceRevisionInfo -Root $root -RequestedRevision $SourceRevision
$manifestBaseUrl = $BaseUrl.TrimEnd("/") + "/"
$inventory = Get-Inventory -Root $root -Revision $revisionInfo.Revision -ManifestBaseUrl $manifestBaseUrl -AuditScript $auditScript
$inventoryEntries = @($inventory.metadataManifest.entries)

$priorByUid = @{}
$priorEntries = New-Object "System.Collections.Generic.List[object]"
$matchedPriorEntries = New-Object "System.Collections.Generic.HashSet[object]"
$hasPrior = -not [String]::IsNullOrWhiteSpace($PriorManifestPath)
if ($hasPrior) {
    $priorPath = ConvertTo-FullPath $PriorManifestPath
    Assert-Condition (Test-Path -LiteralPath $priorPath -PathType Leaf) "Prior manifest '$priorPath' does not exist."
    foreach ($priorEntry in @(Get-ManifestEntries -Path $priorPath)) {
        $uid = Get-StringProperty -Object $priorEntry -Name "uid"
        if ([String]::IsNullOrWhiteSpace($uid)) {
            throw "Prior manifest '$priorPath' contains an entry without a UID."
        }
        if ((Get-StringProperty -Object $priorEntry -Name "tombstone" -Default "false") -ieq "true") {
            continue
        }
        if (-not $priorByUid.ContainsKey($uid)) {
            $priorByUid[$uid] = @()
        }
        $priorByUid[$uid] = @($priorByUid[$uid]) + $priorEntry
        $priorEntries.Add($priorEntry)
    }
}

$entries = New-Object "System.Collections.Generic.List[object]"
$currentIdentityKeys = @{}
foreach ($inventoryEntry in @($inventoryEntries | Sort-Object uid, sourcePath)) {
    $entry = New-CurrentEntry -InventoryEntry $inventoryEntry -Revision $revisionInfo.Revision
    $identityKey = Get-EntryIdentityKey -Entry $entry
    if ($currentIdentityKeys.ContainsKey($identityKey)) {
        throw "The current source inventory contains duplicate page identity '$identityKey'."
    }
    $currentIdentityKeys[$identityKey] = $true
    $previous = if ($hasPrior -and $priorByUid.ContainsKey($entry.uid)) {
        Select-PreviousEntry -Candidates $priorByUid[$entry.uid] -CurrentEntry $entry -MatchedEntries $matchedPriorEntries
    }
    else {
        $null
    }
    if ($null -ne $previous) {
        [void]$matchedPriorEntries.Add($previous)
    }
    Add-PreviousComparison -Entry $entry -Previous $previous
    $entries.Add($entry)
}

if ($hasPrior) {
    foreach ($priorEntry in @($priorEntries.ToArray() | Sort-Object uid, sourcePath)) {
        if (-not $matchedPriorEntries.Contains($priorEntry)) {
            $entries.Add((New-TombstoneEntry -Previous $priorEntry -RemovalRevision $revisionInfo.Revision))
        }
    }
}

$orderedEntries = @(
    $entries.ToArray() |
        Sort-Object `
            @{ Expression = { Get-StringProperty -Object $_ -Name "uid" } }, `
            @{ Expression = { [int]([bool]($_.tombstone)) } }, `
            @{ Expression = { Get-StringProperty -Object $_ -Name "sourcePath" } }
)
$currentEntries = @($orderedEntries | Where-Object { -not $_.tombstone })
$removedEntries = @($orderedEntries | Where-Object { $_.tombstone })
$counts = [ordered]@{
    current = $currentEntries.Count
    added = @($currentEntries | Where-Object { $_.changeType -eq "added" }).Count
    changed = @($currentEntries | Where-Object { $_.changeType -eq "changed" }).Count
    moved = @($currentEntries | Where-Object { $_.moved }).Count
    unchanged = @($currentEntries | Where-Object { $_.changeType -eq "unchanged" }).Count
    removed = $removedEntries.Count
    tombstones = $removedEntries.Count
    total = $orderedEntries.Count
}

$gaps = New-Object "System.Collections.Generic.List[object]"
$missingUidCount = [int]$inventory.source.uid.pagesWithoutUid
if ($missingUidCount -gt 0) {
    $gaps.Add([ordered]@{
            code = "page-without-stable-uid"
            count = $missingUidCount
        })
}
$duplicateUidCount = [int]$inventory.source.uid.duplicateUidCount
if ($duplicateUidCount -gt 0) {
    $gaps.Add([ordered]@{
            code = "duplicate-stable-uid"
            count = $duplicateUidCount
        })
}

$manifest = [ordered]@{
    schemaVersion = $script:SchemaVersion
    format = "json"
    visibility = "metadata-only"
    generator = [ordered]@{
        name = "scripts/generate-ai-content-manifest.ps1"
        version = $script:GeneratorVersion
    }
    schema = [ordered]@{
        name = $script:SchemaName
        version = $script:SchemaVersion
    }
    source = [ordered]@{
        repository = $script:Repository
        revision = $revisionInfo.Revision
        revisionSource = $revisionInfo.Source
        configuration = Get-Configuration -Root $root
        baseUrl = $manifestBaseUrl
    }
    scope = [ordered]@{
        sourcePaths = $script:SourcePaths
        domains = @("Automation", "Connector")
    }
    license = [ordered]@{
        identifier = $script:LicenseIdentifier
        name = $script:LicenseName
        url = $script:LicenseUrl
        attribution = $script:Attribution
        source = "contributing/CTB_Documentation_Corpus_Policy.md"
    }
    counts = $counts
    entries = $orderedEntries
    gaps = @($gaps.ToArray())
}

Write-Manifest -Path $output -Manifest $manifest
& $ValidatorPath -RepositoryRoot $root -Path $output -SchemaPath $schemaPath | Out-Null

Write-Output "Wrote $output."
Write-Output "Manifest entries: $($orderedEntries.Count) ($($currentEntries.Count) current, $($removedEntries.Count) tombstones)."
Write-Output "Added: $($counts.added); changed: $($counts.changed); moved: $($counts.moved); unchanged: $($counts.unchanged); removed: $($counts.removed)."
