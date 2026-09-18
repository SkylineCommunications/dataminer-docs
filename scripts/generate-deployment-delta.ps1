[CmdletBinding()]
param(
    [string]$RepositoryRoot = (Join-Path $PSScriptRoot ".."),
    [Alias("ManifestPath", "CurrentPath")][string]$CurrentManifestPath = (Join-Path $PSScriptRoot "..\_artifacts\ai-content-manifest.json"),
    [Alias("PriorManifestPath", "PreviousPath")][string]$PreviousManifestPath = "",
    [string]$OutputPath = (Join-Path $PSScriptRoot "..\_artifacts\deployment-delta.json"),
    [string]$SourceRevision = "",
    [string]$SchemaPath = (Join-Path $PSScriptRoot "..\contributing\metadata\deployment-delta-v1.schema.json"),
    [string]$ValidatorPath = (Join-Path $PSScriptRoot "validate-deployment-delta.ps1")
)

Set-StrictMode -Version 2.0
$ErrorActionPreference = "Stop"

$script:GeneratorVersion = "1.0.0"
$script:Repository = "SkylineCommunications/dataminer-docs"
$script:LicenseIdentifier = "CC BY-NC-ND 4.0"
$script:LicenseName = "Creative Commons Attribution-NonCommercial-NoDerivatives 4.0 International"
$script:LicenseUrl = "https://creativecommons.org/licenses/by-nc-nd/4.0/"
$script:Attribution = "Skyline Communications"
$script:LicenseSource = "contributing/CTB_Documentation_Corpus_Policy.md"
$script:SchemaName = "contributing/metadata/deployment-delta-v1.schema.json"
$script:SchemaVersion = 1
$script:TombstoneRetentionDays = 90

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

function ConvertTo-RepositoryPath {
    param(
        [Parameter(Mandatory = $true)][string]$Path,
        [Parameter(Mandatory = $true)][string]$Root
    )

    $fullPath = [IO.Path]::GetFullPath($Path)
    $prefix = $Root.TrimEnd("\") + "\"
    if ($fullPath.StartsWith($prefix, [StringComparison]::OrdinalIgnoreCase)) {
        return $fullPath.Substring($prefix.Length).Replace("\", "/")
    }

    return [IO.Path]::GetFileName($fullPath).Replace("\", "/")
}

function Get-FileSha256 {
    param([Parameter(Mandatory = $true)][string]$Path)

    return (Get-FileHash -LiteralPath $Path -Algorithm SHA256).Hash.ToLowerInvariant()
}

function Get-StringProperty {
    param(
        [AllowNull()]$Object,
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

function Read-JsonFile {
    param([Parameter(Mandatory = $true)][string]$Path)

    Assert-Condition (Test-Path -LiteralPath $Path -PathType Leaf) "Manifest '$Path' does not exist."
    try {
        return Get-Content -LiteralPath $Path -Raw | ConvertFrom-Json
    }
    catch {
        throw "Manifest '$Path' is not valid JSON: $($_.Exception.Message)"
    }
}

function Assert-ManifestContract {
    param(
        [Parameter(Mandatory = $true)]$Manifest,
        [Parameter(Mandatory = $true)][string]$Path
    )

    Assert-Condition ([int](Get-StringProperty $Manifest "schemaVersion") -eq 1) "Manifest '$Path' is not a version 1 AI content manifest."
    Assert-Condition ((Get-StringProperty $Manifest "format") -eq "json") "Manifest '$Path' is not JSON."
    Assert-Condition ((Get-StringProperty $Manifest "visibility") -eq "metadata-only") "Manifest '$Path' is not metadata-only."
    Assert-Condition (@($Manifest.PSObject.Properties.Name) -contains "entries") "Manifest '$Path' has no entries array."
    Assert-Condition (@($Manifest.PSObject.Properties.Name) -contains "source") "Manifest '$Path' has no source object."
    $revision = Get-StringProperty $Manifest.source "revision"
    Assert-Condition ($revision -match "^[0-9a-fA-F]{40}$") "Manifest '$Path' has no immutable source revision."
    $baseUrl = Get-StringProperty $Manifest.source "baseUrl"
    $uri = $null
    Assert-Condition ([Uri]::TryCreate($baseUrl, [UriKind]::Absolute, [ref]$uri) -and $uri.Scheme -in @("http", "https")) "Manifest '$Path' has an invalid base URL."
}

function New-Identity {
    param(
        [Parameter(Mandatory = $true)]$Entry,
        [Parameter(Mandatory = $true)]$Manifest,
        [Parameter(Mandatory = $true)][string]$Context
    )

    $uid = Get-StringProperty $Entry "uid"
    $sourcePath = (Get-StringProperty $Entry "sourcePath" (Get-StringProperty $Entry "path")).Replace("\", "/").TrimStart("/")
    $url = Get-StringProperty $Entry "url"
    $sourceCommit = Get-StringProperty $Entry "sourceCommit" (Get-StringProperty $Manifest.source "revision")
    $sourceBlob = Get-StringProperty $Entry "sourceBlob"
    $contentHash = Get-StringProperty $Entry "contentHash"
    Assert-Condition (-not [String]::IsNullOrWhiteSpace($uid)) "$Context has no UID."
    Assert-Condition (-not [String]::IsNullOrWhiteSpace($sourcePath)) "$Context has no source path."
    Assert-Condition (-not [String]::IsNullOrWhiteSpace($url)) "$Context has no public URL."
    Assert-Condition ($sourceCommit -match "^[0-9a-fA-F]{40}$") "$Context has an invalid source commit."
    Assert-Condition ($sourceBlob -match "^https?://") "$Context has an invalid source blob."
    Assert-Condition ($contentHash -match "^[0-9a-fA-F]{64}$") "$Context has an invalid content hash."
    Assert-Condition (-not [IO.Path]::IsPathRooted($sourcePath)) "$Context has an absolute source path."

    $compatibility = $Entry.compatibility
    $urlAliases = @(Get-StringArray (Get-StringProperty $compatibility "urlAliases"))
    if ($urlAliases.Count -eq 0) {
        $urlAliases = @(Get-StringArray (Get-StringProperty $compatibility "url_aliases"))
    }

    $compatibilityRecord = [ordered]@{
        uid = Get-StringProperty $compatibility "uid" "unknown"
        url = Get-StringProperty $compatibility "url" "unknown"
    }
    if ($urlAliases.Count -gt 0) {
        $compatibilityRecord.urlAliases = @($urlAliases)
    }

    return [ordered]@{
        uid = $uid
        url = $url
        sourcePath = $sourcePath
        sourceCommit = $sourceCommit.ToLowerInvariant()
        sourceBlob = $sourceBlob
        contentHash = $contentHash.ToLowerInvariant()
        type = Get-StringProperty $Entry "type" "legacy"
        area = Get-StringProperty $Entry "area" "unknown"
        domain = Get-StringProperty $Entry "domain" "unknown"
        authority = Get-StringProperty $Entry "authority" "unknown"
        authoritySource = Get-StringProperty $Entry "authoritySource" "unknown"
        lifecycle = Get-StringProperty $Entry "lifecycle" "unknown"
        appliesTo = @(Get-StringArray $Entry.appliesTo)
        version = Get-StringProperty $Entry "version" "unknown"
        compatibility = $compatibilityRecord
        license = Get-StringProperty $Entry "license" (Get-StringProperty $Manifest.license "identifier")
        attribution = Get-StringProperty $Entry "attribution" (Get-StringProperty $Manifest.license "attribution")
        xrefs = @(Get-StringArray $Entry.xrefs)
        dependencies = @(Get-StringArray $Entry.dependencies)
    }
}

function Get-EntryKey {
    param([Parameter(Mandatory = $true)]$Identity)

    return ([string]$Identity.uid + "|" + [string]$Identity.sourcePath)
}

function Get-ManifestRecords {
    param(
        [Parameter(Mandatory = $true)]$Manifest,
        [Parameter(Mandatory = $true)][string]$Path
    )

    $active = New-Object "System.Collections.Generic.List[object]"
    $tombstones = New-Object "System.Collections.Generic.List[object]"
    $activeKeys = @{}
    $tombstoneKeys = @{}
    $index = 0
    foreach ($rawEntry in @($Manifest.entries)) {
        $context = "Manifest '$Path' entry $index"
        $identity = New-Identity -Entry $rawEntry -Manifest $Manifest -Context $context
        $key = Get-EntryKey $identity
        $isTombstone = [string](Get-StringProperty $rawEntry "tombstone" "false") -ieq "true"
        if ($isTombstone) {
            if ($tombstoneKeys.ContainsKey($key)) {
                throw "Manifest '$Path' contains duplicate tombstone identity '$key'."
            }
            $removedInCommit = Get-StringProperty $rawEntry "removedInCommit" (Get-StringProperty $Manifest.source "revision")
            Assert-Condition ($removedInCommit -match "^[0-9a-fA-F]{40}$") "$context has an invalid removal commit."
            $tombstoneKeys[$key] = $true
            $tombstones.Add([PSCustomObject][ordered]@{
                    identity = $identity
                    key = $key
                    removedInCommit = $removedInCommit.ToLowerInvariant()
                })
        }
        else {
            if ($activeKeys.ContainsKey($key)) {
                throw "Manifest '$Path' contains duplicate active identity '$key'."
            }
            $activeKeys[$key] = $true
            $active.Add([PSCustomObject][ordered]@{
                    identity = $identity
                    key = $key
                })
        }
        $index++
    }

    return [PSCustomObject][ordered]@{
        active = @($active.ToArray() | Sort-Object @{ Expression = { $_.identity.uid } }, @{ Expression = { $_.identity.sourcePath } })
        tombstones = @($tombstones.ToArray() | Sort-Object @{ Expression = { $_.identity.uid } }, @{ Expression = { $_.identity.sourcePath } })
    }
}

function Find-IdentityMatch {
    param(
        [Parameter(Mandatory = $true)]$Current,
        [Parameter(Mandatory = $true)][AllowEmptyCollection()][object[]]$Previous,
        [Parameter(Mandatory = $true)][AllowEmptyCollection()][System.Collections.Generic.HashSet[string]]$MatchedKeys
    )

    $available = @($Previous | Where-Object { -not $MatchedKeys.Contains([string]$_.key) })
    $criteria = @(
        [PSCustomObject]@{
            name = "identity"
            matches = @($available | Where-Object { $_.key -eq [string]$Current.key })
        },
        [PSCustomObject]@{
            name = "uid"
            matches = @($available | Where-Object { [string]$_.identity.uid -eq [string]$Current.identity.uid })
        },
        [PSCustomObject]@{
            name = "source-path"
            matches = @($available | Where-Object { [string]$_.identity.sourcePath -eq [string]$Current.identity.sourcePath })
        },
        [PSCustomObject]@{
            name = "content-hash"
            matches = @($available | Where-Object { [string]$_.identity.contentHash -eq [string]$Current.identity.contentHash })
        }
    )

    foreach ($criterion in $criteria) {
        if ($criterion.matches.Count -eq 1) {
            return [PSCustomObject][ordered]@{
                entry = $criterion.matches[0]
                ambiguous = $false
                criterion = $criterion.name
                candidates = @()
            }
        }
        if ($criterion.matches.Count -gt 1) {
            return [PSCustomObject][ordered]@{
                entry = $null
                ambiguous = $true
                criterion = $criterion.name
                candidates = @($criterion.matches | ForEach-Object { $_.identity } | Sort-Object uid, sourcePath)
            }
        }
    }

    return [PSCustomObject][ordered]@{
        entry = $null
        ambiguous = $false
        criterion = ""
        candidates = @()
    }
}

function Find-TombstoneMatch {
    param(
        [Parameter(Mandatory = $true)]$Previous,
        [Parameter(Mandatory = $true)][AllowEmptyCollection()][object[]]$CurrentTombstones,
        [Parameter(Mandatory = $true)][AllowEmptyCollection()][System.Collections.Generic.HashSet[string]]$ConsumedKeys
    )

    $available = @($CurrentTombstones | Where-Object { -not $ConsumedKeys.Contains([string]$_.key) })
    $exact = @($available | Where-Object { $_.key -eq [string]$Previous.key })
    if ($exact.Count -eq 1) {
        return $exact[0]
    }

    $sameUid = @($available | Where-Object { [string]$_.identity.uid -eq [string]$Previous.identity.uid })
    if ($sameUid.Count -eq 1) {
        return $sameUid[0]
    }

    $sameUrl = @($available | Where-Object { [string]$_.identity.url -eq [string]$Previous.identity.url })
    if ($sameUrl.Count -eq 1) {
        return $sameUrl[0]
    }

    return $null
}

function New-Event {
    param(
        [Parameter(Mandatory = $true)][string]$Type,
        [Parameter(Mandatory = $true)][string]$Uid,
        [AllowNull()]$Current,
        [AllowNull()]$Previous,
        [AllowEmptyCollection()][object[]]$Candidates = @(),
        [Parameter(Mandatory = $true)][string]$Reason,
        [bool]$Moved = $false,
        [bool]$ContentChanged = $false,
        [bool]$Tombstone = $false
    )

    return [ordered]@{
        type = $Type
        uid = $Uid
        current = if ($null -eq $Current) { $null } else { $Current.identity }
        previous = if ($null -eq $Previous) { $null } else { $Previous.identity }
        candidates = @($Candidates)
        reason = $Reason
        moved = $Moved
        contentChanged = $ContentChanged
        tombstone = $Tombstone
    }
}

function New-Tombstone {
    param(
        [Parameter(Mandatory = $true)]$Identity,
        [Parameter(Mandatory = $true)][string]$RemovedInCommit
    )

    return [ordered]@{
        uid = $Identity.uid
        url = $Identity.url
        sourcePath = $Identity.sourcePath
        sourceCommit = $Identity.sourceCommit
        sourceBlob = $Identity.sourceBlob
        contentHash = $Identity.contentHash
        license = $Identity.license
        attribution = $Identity.attribution
        removedInCommit = $RemovedInCommit
        retentionDays = $script:TombstoneRetentionDays
    }
}

function New-Redirect {
    param(
        [Parameter(Mandatory = $true)]$Previous,
        [Parameter(Mandatory = $true)]$Current
    )

    return [ordered]@{
        from = $Previous.identity.url
        to = $Current.identity.url
        previousUid = $Previous.identity.uid
        currentUid = $Current.identity.uid
        previousSourcePath = $Previous.identity.sourcePath
        currentSourcePath = $Current.identity.sourcePath
        status = "permanent"
        reason = "published-url-changed"
        license = $Current.identity.license
        attribution = $Current.identity.attribution
    }
}

function Add-UniqueGap {
    param(
        [Parameter(Mandatory = $true)][AllowEmptyCollection()][System.Collections.Generic.List[object]]$Gaps,
        [Parameter(Mandatory = $true)][string]$Code
    )

    if (@($Gaps | Where-Object { [string]$_.code -eq $Code }).Count -eq 0) {
        $Gaps.Add([ordered]@{
                code = $Code
                count = 1
            })
    }
}

function Write-Json {
    param(
        [Parameter(Mandatory = $true)][string]$Path,
        [Parameter(Mandatory = $true)]$Value
    )

    $directory = Split-Path -Parent $Path
    if (-not (Test-Path -LiteralPath $directory -PathType Container)) {
        New-Item -ItemType Directory -Path $directory -Force | Out-Null
    }
    $json = $Value | ConvertTo-Json -Depth 30
    $utf8NoBom = New-Object Text.UTF8Encoding($false)
    [IO.File]::WriteAllText($Path, $json + [Environment]::NewLine, $utf8NoBom)
}

$root = ConvertTo-FullPath $RepositoryRoot
$currentPath = ConvertTo-FullPath $CurrentManifestPath
$outputPath = ConvertTo-FullPath $OutputPath
$schemaFile = ConvertTo-FullPath $SchemaPath
$validatorFile = ConvertTo-FullPath $ValidatorPath
Assert-Condition (Test-Path -LiteralPath $root -PathType Container) "Repository root '$root' does not exist."
Assert-Condition (Test-Path -LiteralPath $schemaFile -PathType Leaf) "Deployment delta schema '$schemaFile' does not exist."
Assert-Condition (Test-Path -LiteralPath $validatorFile -PathType Leaf) "Deployment delta validator '$validatorFile' does not exist."

$currentManifest = Read-JsonFile $currentPath
Assert-ManifestContract -Manifest $currentManifest -Path $currentPath
$currentRecords = Get-ManifestRecords -Manifest $currentManifest -Path $currentPath
$currentRevision = (Get-StringProperty $currentManifest.source "revision").ToLowerInvariant()
if (-not [String]::IsNullOrWhiteSpace($SourceRevision)) {
    $requestedRevision = $SourceRevision.Trim().ToLowerInvariant()
    Assert-Condition ($requestedRevision -match "^[0-9a-f]{40}$") "Source revision '$SourceRevision' is not a full commit."
    Assert-Condition ($requestedRevision -eq $currentRevision) "Source revision '$requestedRevision' does not match the current manifest revision '$currentRevision'."
}

$previousManifest = $null
$previousRecords = [PSCustomObject][ordered]@{
    active = @()
    tombstones = @()
}
$previousPath = ""
$previousHash = $null
$previousRevision = $null
$hasPrevious = -not [String]::IsNullOrWhiteSpace($PreviousManifestPath)
if ($hasPrevious) {
    $previousPath = ConvertTo-FullPath $PreviousManifestPath
    $previousManifest = Read-JsonFile $previousPath
    Assert-ManifestContract -Manifest $previousManifest -Path $previousPath
    $previousRecords = Get-ManifestRecords -Manifest $previousManifest -Path $previousPath
    $previousHash = Get-FileSha256 $previousPath
    $previousRevision = (Get-StringProperty $previousManifest.source "revision").ToLowerInvariant()
}

$events = New-Object "System.Collections.Generic.List[object]"
$redirects = New-Object "System.Collections.Generic.List[object]"
$tombstones = New-Object "System.Collections.Generic.List[object]"
$gaps = New-Object "System.Collections.Generic.List[object]"
$matchedPreviousKeys = New-Object "System.Collections.Generic.HashSet[string]"
$consumedCurrentTombstoneKeys = New-Object "System.Collections.Generic.HashSet[string]"
$redirectFrom = @{}

if (-not $hasPrevious) {
    Add-UniqueGap -Gaps $gaps -Code "previous-manifest-unavailable"
}

foreach ($current in @($currentRecords.active)) {
    if (-not $hasPrevious) {
        $events.Add((New-Event -Type "added" -Uid $current.identity.uid -Current $current -Previous $null -Reason "new-entry"))
        continue
    }

    $match = Find-IdentityMatch -Current $current -Previous $previousRecords.active -MatchedKeys $matchedPreviousKeys
    if ($match.ambiguous) {
        $events.Add((New-Event `
                -Type "ambiguous-move" `
                -Uid $current.identity.uid `
                -Current $current `
                -Previous $null `
                -Candidates $match.candidates `
                -Reason "ambiguous-identity-match"))
        Add-UniqueGap -Gaps $gaps -Code "ambiguous-move"
        continue
    }
    if ($null -eq $match.entry) {
        $events.Add((New-Event -Type "added" -Uid $current.identity.uid -Current $current -Previous $null -Reason "new-entry"))
        continue
    }

    [void]$matchedPreviousKeys.Add([string]$match.entry.key)
    $previous = $match.entry
    $contentChanged = [string]$current.identity.contentHash -ne [string]$previous.identity.contentHash
    $moved = [string]$current.identity.uid -ne [string]$previous.identity.uid -or
        [string]$current.identity.sourcePath -ne [string]$previous.identity.sourcePath -or
        [string]$current.identity.url -ne [string]$previous.identity.url

    if ($contentChanged -or $moved) {
        $eventType = if ($contentChanged) { "changed" } else { "moved" }
        $reason = if ($contentChanged) { "content-hash-changed" } else { "identity-or-url-changed" }
        $events.Add((New-Event `
                -Type $eventType `
                -Uid $current.identity.uid `
                -Current $current `
                -Previous $previous `
                -Reason $reason `
                -Moved $moved `
                -ContentChanged $contentChanged))
    }

    $wasDeprecated = [string]$previous.identity.lifecycle -eq "deprecated"
    $isDeprecated = [string]$current.identity.lifecycle -eq "deprecated"
    if ($isDeprecated -and -not $wasDeprecated) {
        $events.Add((New-Event `
                -Type "deprecated" `
                -Uid $current.identity.uid `
                -Current $current `
                -Previous $previous `
                -Reason "lifecycle-transition" `
                -Moved $moved `
                -ContentChanged $contentChanged))
    }

    if ([string]$current.identity.url -ne [string]$previous.identity.url) {
        if ([string]$current.identity.compatibility.url -ne "redirect_required") {
            Add-UniqueGap -Gaps $gaps -Code "redirect-contract-missing"
        }
        $redirect = New-Redirect -Previous $previous -Current $current
        if ($redirectFrom.ContainsKey([string]$redirect.from)) {
            Add-UniqueGap -Gaps $gaps -Code "duplicate-redirect-source"
        }
        else {
            $redirectFrom[[string]$redirect.from] = $true
            $redirects.Add($redirect)
        }
    }
}

foreach ($previous in @($previousRecords.active)) {
    if ($matchedPreviousKeys.Contains([string]$previous.key)) {
        continue
    }

    $currentTombstone = Find-TombstoneMatch `
        -Previous $previous `
        -CurrentTombstones $currentRecords.tombstones `
        -ConsumedKeys $consumedCurrentTombstoneKeys
    $identity = $previous.identity
    $removedInCommit = $currentRevision
    if ($null -ne $currentTombstone) {
        [void]$consumedCurrentTombstoneKeys.Add([string]$currentTombstone.key)
        $identity = $currentTombstone.identity
        $removedInCommit = $currentTombstone.removedInCommit
    }

    $events.Add((New-Event `
            -Type "removed" `
            -Uid $identity.uid `
            -Current $null `
            -Previous ([PSCustomObject][ordered]@{ identity = $identity }) `
            -Reason "entry-removed" `
            -Tombstone $true))
    $tombstones.Add((New-Tombstone -Identity $identity -RemovedInCommit $removedInCommit))
}

foreach ($currentTombstone in @($currentRecords.tombstones)) {
    if ($consumedCurrentTombstoneKeys.Contains([string]$currentTombstone.key)) {
        continue
    }

    $wasKnownTombstone = @(
        $previousRecords.tombstones |
            Where-Object { [string]$_.key -eq [string]$currentTombstone.key }
    ).Count -gt 0
    if ($wasKnownTombstone) {
        continue
    }

    $events.Add((New-Event `
            -Type "removed" `
            -Uid $currentTombstone.identity.uid `
            -Current $null `
            -Previous ([PSCustomObject][ordered]@{ identity = $currentTombstone.identity }) `
            -Reason "entry-removed" `
            -Tombstone $true))
    $tombstones.Add((New-Tombstone `
            -Identity $currentTombstone.identity `
            -RemovedInCommit $currentTombstone.removedInCommit))
}

$orderedEvents = @(
    $events.ToArray() |
        Sort-Object `
            @{ Expression = {
                switch ([string]$_.type) {
                    "added" { "1" }
                    "changed" { "2" }
                    "moved" { "3" }
                    "deprecated" { "4" }
                    "removed" { "5" }
                    "ambiguous-move" { "6" }
                    default { "9" }
                }
            } }, `
            @{ Expression = { [string]$_.uid } }, `
            @{ Expression = { if ($null -eq $_.current) { [string]$_.previous.sourcePath } else { [string]$_.current.sourcePath } } }
)
$orderedRedirects = @(
    $redirects.ToArray() |
        Sort-Object from, to, previousUid, currentUid
)
$orderedTombstones = @(
    $tombstones.ToArray() |
        Sort-Object uid, sourcePath, removedInCommit
)
$orderedGaps = @($gaps.ToArray() | Sort-Object code)

$counts = [ordered]@{
    added = @($orderedEvents | Where-Object { $_.type -eq "added" }).Count
    changed = @($orderedEvents | Where-Object { $_.type -eq "changed" }).Count
    moved = @($orderedEvents | Where-Object { $_.moved }).Count
    deprecated = @($orderedEvents | Where-Object { $_.type -eq "deprecated" }).Count
    removed = @($orderedEvents | Where-Object { $_.type -eq "removed" }).Count
    ambiguousMoves = @($orderedEvents | Where-Object { $_.type -eq "ambiguous-move" }).Count
    redirects = $orderedRedirects.Count
    tombstones = $orderedTombstones.Count
    total = $orderedEvents.Count
}

$currentManifestReference = [ordered]@{
    path = ConvertTo-RepositoryPath -Path $currentPath -Root $root
    sha256 = Get-FileSha256 $currentPath
    available = $true
}
$previousManifestReference = [ordered]@{
    path = if ($hasPrevious) { ConvertTo-RepositoryPath -Path $previousPath -Root $root } else { $null }
    sha256 = $previousHash
    available = $hasPrevious
}
$baseUrl = (Get-StringProperty $currentManifest.source "baseUrl").TrimEnd("/") + "/"
$delta = [ordered]@{
    schemaVersion = $script:SchemaVersion
    format = "json"
    visibility = "metadata-only"
    generator = [ordered]@{
        name = "scripts/generate-deployment-delta.ps1"
        version = $script:GeneratorVersion
    }
    schema = [ordered]@{
        name = $script:SchemaName
        version = $script:SchemaVersion
    }
    source = [ordered]@{
        repository = $script:Repository
        currentRevision = $currentRevision
        previousRevision = $previousRevision
        baseUrl = $baseUrl
        currentManifest = $currentManifestReference
        previousManifest = $previousManifestReference
    }
    retention = [ordered]@{
        days = $script:TombstoneRetentionDays
        policy = "protected-main-commit-addressed"
        tombstoneSemantics = "retain-removed-uid-url-identities"
    }
    license = [ordered]@{
        identifier = $script:LicenseIdentifier
        name = $script:LicenseName
        url = $script:LicenseUrl
        attribution = $script:Attribution
        source = $script:LicenseSource
    }
    counts = $counts
    empty = ($orderedEvents.Count -eq 0 -and $orderedRedirects.Count -eq 0 -and $orderedTombstones.Count -eq 0)
    events = $orderedEvents
    redirects = $orderedRedirects
    tombstones = $orderedTombstones
    gaps = $orderedGaps
}

Write-Json -Path $outputPath -Value $delta
& $validatorFile -RepositoryRoot $root -Path $outputPath -SchemaPath $schemaFile | Out-Null

Write-Output "Wrote $outputPath."
Write-Output "Events: $($counts.total); added: $($counts.added); changed: $($counts.changed); moved: $($counts.moved); deprecated: $($counts.deprecated); removed: $($counts.removed); ambiguous: $($counts.ambiguousMoves); redirects: $($counts.redirects); tombstones: $($counts.tombstones)."
