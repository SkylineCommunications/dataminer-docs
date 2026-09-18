[CmdletBinding()]
param(
    [string]$RepositoryRoot = (Join-Path $PSScriptRoot ".."),
    [string]$Path = (Join-Path $PSScriptRoot "..\_artifacts\deployment-delta.json"),
    [string]$SchemaPath = (Join-Path $PSScriptRoot "..\contributing\metadata\deployment-delta-v1.schema.json")
)

Set-StrictMode -Version 2.0
$ErrorActionPreference = "Stop"

$script:LicenseIdentifier = "CC BY-NC-ND 4.0"
$script:LicenseName = "Creative Commons Attribution-NonCommercial-NoDerivatives 4.0 International"
$script:LicenseUrl = "https://creativecommons.org/licenses/by-nc-nd/4.0/"
$script:Attribution = "Skyline Communications"
$script:LicenseSource = "contributing/CTB_Documentation_Corpus_Policy.md"

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
        return @([string]$Value)
    }
    return @($Value | ForEach-Object { [string]$_ })
}

function Assert-UniqueSortedStrings {
    param(
        [AllowNull()][AllowEmptyCollection()]$Value,
        [Parameter(Mandatory = $true)][string]$Context
    )

    $items = @(Get-StringArray $Value)
    Assert-Condition (@($items | Sort-Object -Unique).Count -eq $items.Count) "$Context contains duplicate values."
    Assert-Condition (($items -join "`n") -eq (@($items | Sort-Object) -join "`n")) "$Context is not sorted deterministically."
}

function Assert-AbsoluteHttpUrl {
    param(
        [Parameter(Mandatory = $true)][string]$Value,
        [Parameter(Mandatory = $true)][string]$Context
    )

    $uri = $null
    Assert-Condition ([Uri]::TryCreate($Value, [UriKind]::Absolute, [ref]$uri) -and $uri.Scheme -in @("http", "https")) "$Context is not an absolute HTTP(S) URL."
    Assert-Condition ($Value -notmatch "\\") "$Context contains a Windows path."
}

function Assert-License {
    param(
        [Parameter(Mandatory = $true)]$License,
        [Parameter(Mandatory = $true)][string]$Context
    )

    Assert-Properties `
        -Object $License `
        -Required @("identifier", "name", "url", "attribution", "source") `
        -Allowed @("identifier", "name", "url", "attribution", "source") `
        -Context $Context
    Assert-Condition ([string]$License.identifier -eq $script:LicenseIdentifier) "$Context has an invalid identifier."
    Assert-Condition ([string]$License.name -eq $script:LicenseName) "$Context has an invalid name."
    Assert-Condition ([string]$License.url -eq $script:LicenseUrl) "$Context has an invalid URL."
    Assert-Condition ([string]$License.attribution -eq $script:Attribution) "$Context has an invalid attribution."
    Assert-Condition ([string]$License.source -eq $script:LicenseSource) "$Context has an invalid policy source."
}

function Assert-FileReference {
    param(
        [Parameter(Mandatory = $true)]$Reference,
        [Parameter(Mandatory = $true)][string]$Context,
        [Parameter(Mandatory = $true)][string]$RepositoryRoot
    )

    Assert-Properties `
        -Object $Reference `
        -Required @("path", "sha256", "available") `
        -Allowed @("path", "sha256", "available") `
        -Context $Context
    Assert-Condition ($Reference.available -is [bool]) "$Context.available is not boolean."
    if ($Reference.available) {
        Assert-Condition ($null -ne $Reference.path -and -not [String]::IsNullOrWhiteSpace([string]$Reference.path)) "$Context has no path."
        Assert-Condition ($null -ne $Reference.sha256 -and [string]$Reference.sha256 -match "^[0-9a-f]{64}$") "$Context has an invalid SHA-256 hash."
        Assert-Condition (-not [IO.Path]::IsPathRooted([string]$Reference.path)) "$Context has an absolute path."
        Assert-Condition ([string]$Reference.path -notmatch "\\") "$Context has a Windows path."
        $candidate = Join-Path $RepositoryRoot ([string]$Reference.path).Replace("/", "\")
        if (Test-Path -LiteralPath $candidate -PathType Leaf) {
            $actual = (Get-FileHash -LiteralPath $candidate -Algorithm SHA256).Hash.ToLowerInvariant()
            Assert-Condition ($actual -eq [string]$Reference.sha256) "$Context hash does not match '$($Reference.path)'."
        }
    }
    else {
        Assert-Condition ($null -eq $Reference.path) "$Context unavailable reference has a path."
        Assert-Condition ($null -eq $Reference.sha256) "$Context unavailable reference has a hash."
    }
}

function Assert-Compatibility {
    param(
        [Parameter(Mandatory = $true)]$Compatibility,
        [Parameter(Mandatory = $true)][string]$Context
    )

    Assert-Properties `
        -Object $Compatibility `
        -Required @("uid", "url") `
        -Allowed @("uid", "url", "urlAliases") `
        -Context $Context
    Assert-Condition ([string]$Compatibility.uid -in @("stable", "unknown", "not_applicable")) "$Context.uid is invalid."
    Assert-Condition ([string]$Compatibility.url -in @("stable", "unknown", "redirect_required", "not_applicable")) "$Context.url is invalid."
    if (@($Compatibility.PSObject.Properties.Name) -contains "urlAliases") {
        Assert-UniqueSortedStrings -Value $Compatibility.urlAliases -Context "$Context.urlAliases"
    }
}

function Assert-Identity {
    param(
        [Parameter(Mandatory = $true)]$Identity,
        [Parameter(Mandatory = $true)][string]$Context
    )

    Assert-Properties `
        -Object $Identity `
        -Required @("uid", "url", "sourcePath", "sourceCommit", "sourceBlob", "contentHash", "type", "area", "domain", "authority", "authoritySource", "lifecycle", "appliesTo", "version", "compatibility", "license", "attribution", "xrefs", "dependencies") `
        -Allowed @("uid", "url", "sourcePath", "sourceCommit", "sourceBlob", "contentHash", "type", "area", "domain", "authority", "authoritySource", "lifecycle", "appliesTo", "version", "compatibility", "license", "attribution", "xrefs", "dependencies") `
        -Context $Context
    Assert-Condition (-not [String]::IsNullOrWhiteSpace([string]$Identity.uid)) "$Context has no UID."
    Assert-AbsoluteHttpUrl -Value ([string]$Identity.url) -Context "$Context.url"
    Assert-Condition (-not [IO.Path]::IsPathRooted([string]$Identity.sourcePath)) "$Context has an absolute source path."
    Assert-Condition ([string]$Identity.sourcePath -notmatch "^[\\/]|\\") "$Context has an invalid source path."
    Assert-Condition ([string]$Identity.sourceCommit -match "^[0-9a-f]{40}$") "$Context has an invalid source commit."
    Assert-AbsoluteHttpUrl -Value ([string]$Identity.sourceBlob) -Context "$Context.sourceBlob"
    Assert-Condition ([string]$Identity.contentHash -match "^[0-9a-f]{64}$") "$Context has an invalid content hash."
    Assert-Condition ([string]$Identity.type -in @("conceptual", "schema", "api", "example", "release-note", "legacy")) "$Context.type is invalid."
    Assert-Condition ([string]$Identity.area -in @("root", "dataminer", "develop", "solutions", "tutorials", "connectors", "release-notes", "contributing", "unknown")) "$Context.area is invalid."
    Assert-Condition (-not [String]::IsNullOrWhiteSpace([string]$Identity.domain)) "$Context.domain is empty."
    Assert-Condition ([string]$Identity.authority -in @("canonical", "reference", "illustrative", "historical", "unknown", "not_applicable")) "$Context.authority is invalid."
    Assert-Condition (-not [String]::IsNullOrWhiteSpace([string]$Identity.authoritySource)) "$Context.authoritySource is empty."
    Assert-Condition ([string]$Identity.lifecycle -in @("draft", "active", "deprecated", "archived", "unknown")) "$Context.lifecycle is invalid."
    Assert-UniqueSortedStrings -Value $Identity.appliesTo -Context "$Context.appliesTo"
    Assert-Condition (@($Identity.appliesTo).Count -gt 0) "$Context.appliesTo is empty."
    Assert-Condition (-not [String]::IsNullOrWhiteSpace([string]$Identity.version)) "$Context.version is empty."
    Assert-Compatibility -Compatibility $Identity.compatibility -Context "$Context.compatibility"
    Assert-Condition ([string]$Identity.license -eq $script:LicenseIdentifier) "$Context has an invalid license."
    Assert-Condition ([string]$Identity.attribution -eq $script:Attribution) "$Context has an invalid attribution."
    Assert-UniqueSortedStrings -Value $Identity.xrefs -Context "$Context.xrefs"
    Assert-UniqueSortedStrings -Value $Identity.dependencies -Context "$Context.dependencies"
}

function Get-IdentityKey {
    param([Parameter(Mandatory = $true)]$Identity)

    return ([string]$Identity.uid + "|" + [string]$Identity.sourcePath)
}

function Assert-NullableIdentity {
    param(
        [AllowNull()]$Identity,
        [Parameter(Mandatory = $true)][string]$Context
    )

    if ($null -ne $Identity) {
        Assert-Identity -Identity $Identity -Context $Context
    }
}

function Get-EventSortKey {
    param([Parameter(Mandatory = $true)]$Event)

    $rank = switch ([string]$Event.type) {
        "added" { "1" }
        "changed" { "2" }
        "moved" { "3" }
        "deprecated" { "4" }
        "removed" { "5" }
        "ambiguous-move" { "6" }
        default { "9" }
    }
    $path = if ($null -eq $Event.current) { [string]$Event.previous.sourcePath } else { [string]$Event.current.sourcePath }
    return "$rank|$($Event.uid)|$path"
}

function Get-EventTypeRank {
    param([Parameter(Mandatory = $true)]$Event)

    switch ([string]$Event.type) {
        "added" { return 1 }
        "changed" { return 2 }
        "moved" { return 3 }
        "deprecated" { return 4 }
        "removed" { return 5 }
        "ambiguous-move" { return 6 }
        default { return 9 }
    }
}

function Assert-NoPublicContent {
    param(
        [AllowNull()]$Object,
        [Parameter(Mandatory = $true)][string]$Context
    )

    if ($null -eq $Object -or $Object -is [string] -or $Object.GetType().IsPrimitive) {
        return
    }
    $forbidden = @(
        "description",
        "body",
        "markdown",
        "text",
        "summary",
        "embedding",
        "embeddings",
        "prompt",
        "chunk",
        "chunks",
        "prose",
        "token",
        "secret",
        "password",
        "authorization",
        "connectionstring"
    )
    if ($Object -is [System.Collections.IEnumerable] -and -not ($Object -is [System.Collections.IDictionary])) {
        foreach ($item in $Object) {
            Assert-NoPublicContent -Object $item -Context $Context
        }
        return
    }
    foreach ($property in @($Object.PSObject.Properties)) {
        $name = [string]$property.Name
        Assert-Condition ($forbidden -notcontains $name.ToLowerInvariant()) "$Context contains prohibited public-content or secret property '$name'."
        Assert-NoPublicContent -Object $property.Value -Context "$Context.$name"
    }
}

$root = ConvertTo-FullPath $RepositoryRoot
$deltaPath = ConvertTo-FullPath $Path
$schemaFile = ConvertTo-FullPath $SchemaPath
Assert-Condition (Test-Path -LiteralPath $root -PathType Container) "Repository root '$root' does not exist."
Assert-Condition (Test-Path -LiteralPath $deltaPath -PathType Leaf) "Deployment delta '$deltaPath' does not exist."
Assert-Condition (Test-Path -LiteralPath $schemaFile -PathType Leaf) "Deployment delta schema '$schemaFile' does not exist."

$schemaJson = Get-Content -LiteralPath $schemaFile -Raw
try {
    $schema = $schemaJson | ConvertFrom-Json
}
catch {
    throw "Deployment delta schema '$schemaFile' is not valid JSON."
}
Assert-Condition ([string]$schema.title -eq "DataMiner deployment delta") "Unexpected deployment delta schema."

$deltaJson = Get-Content -LiteralPath $deltaPath -Raw
try {
    $delta = $deltaJson | ConvertFrom-Json
}
catch {
    throw "Deployment delta '$deltaPath' is not valid JSON."
}

if ($null -ne (Get-Command Test-Json -ErrorAction SilentlyContinue)) {
    try {
        if (-not (Test-Json -Json $deltaJson -SchemaFile $schemaFile)) {
            throw "The deployment delta does not conform to the committed JSON Schema."
        }
    }
    catch {
        throw "Deployment delta JSON Schema validation failed: $($_.Exception.Message)"
    }
}

Assert-NoPublicContent -Object $delta -Context "delta"
Assert-Properties `
    -Object $delta `
    -Required @("schemaVersion", "format", "visibility", "generator", "schema", "source", "retention", "license", "counts", "empty", "events", "redirects", "tombstones", "gaps") `
    -Allowed @("schemaVersion", "format", "visibility", "generator", "schema", "source", "retention", "license", "counts", "empty", "events", "redirects", "tombstones", "gaps") `
    -Context "delta"
Assert-Condition ([int]$delta.schemaVersion -eq 1) "Unsupported deployment delta schema version."
Assert-Condition ([string]$delta.format -eq "json") "Deployment delta is not JSON."
Assert-Condition ([string]$delta.visibility -eq "metadata-only") "Deployment delta is not metadata-only."
Assert-Properties -Object $delta.generator -Required @("name", "version") -Allowed @("name", "version") -Context "delta.generator"
Assert-Condition ([string]$delta.generator.name -eq "scripts/generate-deployment-delta.ps1") "Unexpected deployment delta generator."
Assert-Properties -Object $delta.schema -Required @("name", "version") -Allowed @("name", "version") -Context "delta.schema"
Assert-Condition ([string]$delta.schema.name -eq "contributing/metadata/deployment-delta-v1.schema.json") "Unexpected deployment delta schema name."
Assert-Condition ([int]$delta.schema.version -eq 1) "Unexpected deployment delta schema version."

Assert-Properties `
    -Object $delta.source `
    -Required @("repository", "currentRevision", "previousRevision", "baseUrl", "currentManifest", "previousManifest") `
    -Allowed @("repository", "currentRevision", "previousRevision", "baseUrl", "currentManifest", "previousManifest") `
    -Context "delta.source"
Assert-Condition ([string]$delta.source.repository -eq "SkylineCommunications/dataminer-docs") "Unexpected source repository."
Assert-Condition ([string]$delta.source.currentRevision -match "^[0-9a-f]{40}$") "Current source revision is not immutable."
if ($null -ne $delta.source.previousRevision) {
    Assert-Condition ([string]$delta.source.previousRevision -match "^[0-9a-f]{40}$") "Previous source revision is not immutable."
}
Assert-AbsoluteHttpUrl -Value ([string]$delta.source.baseUrl) -Context "delta.source.baseUrl"
Assert-FileReference -Reference $delta.source.currentManifest -Context "delta.source.currentManifest" -RepositoryRoot $root
Assert-FileReference -Reference $delta.source.previousManifest -Context "delta.source.previousManifest" -RepositoryRoot $root
if ($delta.source.previousManifest.available) {
    Assert-Condition ($null -ne $delta.source.previousRevision) "Available previous manifest has no revision."
}
else {
    Assert-Condition ($null -eq $delta.source.previousRevision) "Unavailable previous manifest has a revision."
}

Assert-Properties -Object $delta.retention -Required @("days", "policy", "tombstoneSemantics") -Allowed @("days", "policy", "tombstoneSemantics") -Context "delta.retention"
Assert-Condition ([int]$delta.retention.days -eq 90) "Deployment delta retention must be 90 days."
Assert-Condition ([string]$delta.retention.policy -eq "protected-main-commit-addressed") "Deployment delta retention policy is invalid."
Assert-Condition ([string]$delta.retention.tombstoneSemantics -eq "retain-removed-uid-url-identities") "Deployment delta tombstone semantics are invalid."
Assert-License -License $delta.license -Context "delta.license"

Assert-Properties `
    -Object $delta.counts `
    -Required @("added", "changed", "moved", "deprecated", "removed", "ambiguousMoves", "redirects", "tombstones", "total") `
    -Allowed @("added", "changed", "moved", "deprecated", "removed", "ambiguousMoves", "redirects", "tombstones", "total") `
    -Context "delta.counts"
foreach ($name in @("added", "changed", "moved", "deprecated", "removed", "ambiguousMoves", "redirects", "tombstones", "total")) {
    Assert-Condition ([int]$delta.counts.$name -ge 0) "delta.counts.$name is negative."
}

$events = @($delta.events)
$expectedEventOrder = @(
    $events |
        Sort-Object `
            @{ Expression = { Get-EventTypeRank $_ } }, `
            @{ Expression = { [string]$_.uid } }, `
            @{ Expression = { if ($null -eq $_.current) { [string]$_.previous.sourcePath } else { [string]$_.current.sourcePath } } }
)
for ($index = 0; $index -lt $events.Count; $index++) {
    $actualPath = if ($null -eq $events[$index].current) { [string]$events[$index].previous.sourcePath } else { [string]$events[$index].current.sourcePath }
    $expectedPath = if ($null -eq $expectedEventOrder[$index].current) { [string]$expectedEventOrder[$index].previous.sourcePath } else { [string]$expectedEventOrder[$index].current.sourcePath }
    Assert-Condition (
        [string]$events[$index].type -eq [string]$expectedEventOrder[$index].type -and
        [string]$events[$index].uid -eq [string]$expectedEventOrder[$index].uid -and
        $actualPath -eq $expectedPath
    ) "Deployment delta events are not sorted deterministically."
}

$eventIdentityKeys = @{}
$redirects = @($delta.redirects)
$redirectFrom = @{}
foreach ($event in $events) {
    $context = "delta.events '$($event.uid)'"
    Assert-Properties `
        -Object $event `
        -Required @("type", "uid", "current", "previous", "candidates", "reason", "moved", "contentChanged", "tombstone") `
        -Allowed @("type", "uid", "current", "previous", "candidates", "reason", "moved", "contentChanged", "tombstone") `
        -Context $context
    Assert-Condition ([string]$event.uid -ne "") "$context has no UID."
    Assert-Condition ([string]$event.type -in @("added", "changed", "moved", "deprecated", "removed", "ambiguous-move")) "$context has an invalid type."
    Assert-NullableIdentity -Identity $event.current -Context "$context.current"
    Assert-NullableIdentity -Identity $event.previous -Context "$context.previous"
    $candidates = @($event.candidates)
    foreach ($candidate in $candidates) {
        Assert-Identity -Identity $candidate -Context "$context.candidates"
    }
    $candidateKeys = @($candidates | ForEach-Object { Get-IdentityKey $_ })
    Assert-Condition (@($candidateKeys | Sort-Object -Unique).Count -eq $candidateKeys.Count) "$context.candidates contains duplicates."
    Assert-Condition (($candidateKeys -join "`n") -eq (@($candidateKeys | Sort-Object) -join "`n")) "$context.candidates are not sorted deterministically."

    switch ([string]$event.type) {
        "added" {
            Assert-Condition ($null -ne $event.current -and $null -eq $event.previous) "$context added event identity is invalid."
            Assert-Condition (-not $event.moved -and -not $event.contentChanged -and -not $event.tombstone) "$context added flags are invalid."
            Assert-Condition (@($candidates).Count -eq 0) "$context added event has candidates."
        }
        "changed" {
            Assert-Condition ($null -ne $event.current -and $null -ne $event.previous) "$context changed event identity is invalid."
            Assert-Condition ($event.contentChanged -and -not $event.tombstone) "$context changed flags are invalid."
            Assert-Condition ([string]$event.reason -eq "content-hash-changed") "$context changed reason is invalid."
        }
        "moved" {
            Assert-Condition ($null -ne $event.current -and $null -ne $event.previous) "$context moved event identity is invalid."
            Assert-Condition ($event.moved -and -not $event.contentChanged -and -not $event.tombstone) "$context moved flags are invalid."
            Assert-Condition ([string]$event.reason -eq "identity-or-url-changed") "$context moved reason is invalid."
        }
        "deprecated" {
            Assert-Condition ($null -ne $event.current -and $null -ne $event.previous) "$context deprecation identity is invalid."
            Assert-Condition ([string]$event.current.lifecycle -eq "deprecated" -and [string]$event.previous.lifecycle -ne "deprecated") "$context deprecation transition is invalid."
            Assert-Condition ([string]$event.reason -eq "lifecycle-transition" -and -not $event.tombstone) "$context deprecation flags are invalid."
        }
        "removed" {
            Assert-Condition ($null -eq $event.current -and $null -ne $event.previous) "$context removal identity is invalid."
            Assert-Condition ($event.tombstone -and -not $event.moved -and -not $event.contentChanged) "$context removal flags are invalid."
            Assert-Condition ([string]$event.reason -eq "entry-removed") "$context removal reason is invalid."
            Assert-Condition (@($candidates).Count -eq 0) "$context removal event has candidates."
        }
        "ambiguous-move" {
            Assert-Condition ($null -ne $event.current -and $null -eq $event.previous) "$context ambiguous move identity is invalid."
            Assert-Condition (@($candidates).Count -gt 1 -and -not $event.moved -and -not $event.contentChanged -and -not $event.tombstone) "$context ambiguity flags are invalid."
            Assert-Condition ([string]$event.reason -eq "ambiguous-identity-match") "$context ambiguity reason is invalid."
        }
    }

    if ($null -ne $event.current -and $null -ne $event.previous) {
        $identityKey = [string]$event.type + "|" + [string]$event.current.uid + "|" + [string]$event.previous.uid + "|" + [string]$event.current.sourcePath
        Assert-Condition (-not $eventIdentityKeys.ContainsKey($identityKey)) "$context is duplicated."
        $eventIdentityKeys[$identityKey] = $true
        if ([string]$event.current.url -ne [string]$event.previous.url) {
            $matchingRedirect = @(
                $redirects |
                    Where-Object {
                        [string]$_.from -eq [string]$event.previous.url -and
                        [string]$_.to -eq [string]$event.current.url
                    }
            )
            Assert-Condition ($matchingRedirect.Count -eq 1) "$context changed URL without exactly one redirect mapping."
        }
    }
}

foreach ($redirect in $redirects) {
    $context = "delta.redirects '$($redirect.from)'"
    Assert-Properties `
        -Object $redirect `
        -Required @("from", "to", "previousUid", "currentUid", "previousSourcePath", "currentSourcePath", "status", "reason", "license", "attribution") `
        -Allowed @("from", "to", "previousUid", "currentUid", "previousSourcePath", "currentSourcePath", "status", "reason", "license", "attribution") `
        -Context $context
    Assert-AbsoluteHttpUrl -Value ([string]$redirect.from) -Context "$context.from"
    Assert-AbsoluteHttpUrl -Value ([string]$redirect.to) -Context "$context.to"
    Assert-Condition ([string]$redirect.from -ne [string]$redirect.to) "$context is a self-redirect."
    Assert-Condition (-not $redirectFrom.ContainsKey([string]$redirect.from)) "$context has a duplicate source URL."
    $redirectFrom[[string]$redirect.from] = $true
    Assert-Condition ([string]$redirect.status -eq "permanent") "$context has a non-permanent status."
    Assert-Condition ([string]$redirect.reason -eq "published-url-changed") "$context has an invalid reason."
    Assert-Condition ([string]$redirect.license -eq $script:LicenseIdentifier) "$context has an invalid license."
    Assert-Condition ([string]$redirect.attribution -eq $script:Attribution) "$context has an invalid attribution."

    $relatedEvents = @(
        $events |
            Where-Object {
                $null -ne $_.current -and
                $null -ne $_.previous -and
                [string]$_.current.url -eq [string]$redirect.to -and
                [string]$_.previous.url -eq [string]$redirect.from
            }
    )
    Assert-Condition ($relatedEvents.Count -gt 0) "$context has no matching move event."
    foreach ($relatedEvent in $relatedEvents) {
        Assert-Condition ([string]$relatedEvent.current.compatibility.url -eq "redirect_required") "$context is missing the redirect-required compatibility contract."
    }
}

$tombstones = @($delta.tombstones)
$tombstoneKeys = @{}
foreach ($tombstone in $tombstones) {
    $context = "delta.tombstones '$($tombstone.uid)'"
    Assert-Properties `
        -Object $tombstone `
        -Required @("uid", "url", "sourcePath", "sourceCommit", "sourceBlob", "contentHash", "license", "attribution", "removedInCommit", "retentionDays") `
        -Allowed @("uid", "url", "sourcePath", "sourceCommit", "sourceBlob", "contentHash", "license", "attribution", "removedInCommit", "retentionDays") `
        -Context $context
    Assert-AbsoluteHttpUrl -Value ([string]$tombstone.url) -Context "$context.url"
    Assert-Condition ([string]$tombstone.sourcePath -notmatch "^[\\/]|\\") "$context has an invalid source path."
    Assert-Condition ([string]$tombstone.sourceCommit -match "^[0-9a-f]{40}$") "$context has an invalid source commit."
    Assert-AbsoluteHttpUrl -Value ([string]$tombstone.sourceBlob) -Context "$context.sourceBlob"
    Assert-Condition ([string]$tombstone.contentHash -match "^[0-9a-f]{64}$") "$context has an invalid content hash."
    Assert-Condition ([string]$tombstone.license -eq $script:LicenseIdentifier) "$context has an invalid license."
    Assert-Condition ([string]$tombstone.attribution -eq $script:Attribution) "$context has an invalid attribution."
    Assert-Condition ([string]$tombstone.removedInCommit -eq [string]$delta.source.currentRevision) "$context removal commit is not the current deployment revision."
    Assert-Condition ([int]$tombstone.retentionDays -eq 90) "$context has an invalid retention period."
    $key = [string]$tombstone.uid + "|" + [string]$tombstone.sourcePath
    Assert-Condition (-not $tombstoneKeys.ContainsKey($key)) "$context is duplicated."
    $tombstoneKeys[$key] = $true
    $matchingRemoval = @(
        $events |
            Where-Object {
                $_.type -eq "removed" -and
                $null -ne $_.previous -and
                [string]$_.previous.uid -eq [string]$tombstone.uid -and
                [string]$_.previous.sourcePath -eq [string]$tombstone.sourcePath
            }
    )
    Assert-Condition ($matchingRemoval.Count -eq 1) "$context has no matching removal event."
}

foreach ($gap in @($delta.gaps)) {
    Assert-Properties -Object $gap -Required @("code", "count") -Allowed @("code", "count") -Context "delta.gap"
    Assert-Condition (-not [String]::IsNullOrWhiteSpace([string]$gap.code)) "A delta gap has no code."
    Assert-Condition ([int]$gap.count -gt 0) "Delta gap '$($gap.code)' has an invalid count."
}

$expectedCounts = @{
    added = @($events | Where-Object { $_.type -eq "added" }).Count
    changed = @($events | Where-Object { $_.type -eq "changed" }).Count
    moved = @($events | Where-Object { $_.moved }).Count
    deprecated = @($events | Where-Object { $_.type -eq "deprecated" }).Count
    removed = @($events | Where-Object { $_.type -eq "removed" }).Count
    ambiguousMoves = @($events | Where-Object { $_.type -eq "ambiguous-move" }).Count
    redirects = $redirects.Count
    tombstones = $tombstones.Count
    total = $events.Count
}
foreach ($name in $expectedCounts.Keys) {
    Assert-Condition ([int]$delta.counts.$name -eq [int]$expectedCounts[$name]) "delta.counts.$name does not match the generated records."
}

$expectedEmpty = ($events.Count -eq 0 -and $redirects.Count -eq 0 -and $tombstones.Count -eq 0)
Assert-Condition ([bool]$delta.empty -eq $expectedEmpty) "delta.empty does not match the event records."

Write-Output "Deployment delta validation passed."
Write-Output "Events: $($events.Count); redirects: $($redirects.Count); tombstones: $($tombstones.Count); gaps: $(@($delta.gaps).Count)."
