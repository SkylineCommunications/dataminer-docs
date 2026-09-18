[CmdletBinding()]
param()

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

function Write-JsonFile {
    param(
        [Parameter(Mandatory = $true)][string]$Path,
        [Parameter(Mandatory = $true)]$Value
    )

    $directory = Split-Path -Parent $Path
    if (-not (Test-Path -LiteralPath $directory -PathType Container)) {
        New-Item -ItemType Directory -Path $directory -Force | Out-Null
    }
    $utf8NoBom = New-Object Text.UTF8Encoding($false)
    [IO.File]::WriteAllText($Path, ($Value | ConvertTo-Json -Depth 30) + [Environment]::NewLine, $utf8NoBom)
}

function New-Entry {
    param(
        [Parameter(Mandatory = $true)][string]$Uid,
        [Parameter(Mandatory = $true)][string]$Path,
        [Parameter(Mandatory = $true)][string]$Url,
        [Parameter(Mandatory = $true)][string]$Revision,
        [Parameter(Mandatory = $true)][string]$ContentHash,
        [string]$Lifecycle = "active",
        [string]$UrlCompatibility = "stable",
        [string[]]$UrlAliases = @(),
        [switch]$Tombstone,
        [string]$RemovedInCommit = ""
    )

    $compatibility = [ordered]@{
        uid = "stable"
        url = $UrlCompatibility
    }
    if ($UrlAliases.Count -gt 0) {
        $compatibility.urlAliases = @($UrlAliases | Sort-Object -Unique)
    }

    $entry = [ordered]@{
        uid = $Uid
        url = $Url
        sourcePath = $Path
        sourceCommit = $Revision
        sourceBlob = "https://github.com/SkylineCommunications/dataminer-docs/blob/$Revision/$Path"
        contentHash = $ContentHash
        type = "conceptual"
        area = "develop"
        domain = "Connector"
        authority = "canonical"
        authoritySource = "not_applicable"
        lifecycle = $Lifecycle
        appliesTo = @("DataMiner")
        version = "unversioned"
        compatibility = $compatibility
        license = "CC BY-NC-ND 4.0"
        attribution = "Skyline Communications"
        xrefs = @()
        dependencies = @()
        changeType = "unchanged"
        tombstone = [bool]$Tombstone
        moved = $false
    }
    if ($Tombstone) {
        $entry.removedInCommit = $RemovedInCommit
    }
    return $entry
}

function New-Manifest {
    param(
        [Parameter(Mandatory = $true)][string]$Revision,
        [Parameter(Mandatory = $true)][object[]]$Entries
    )

    return [ordered]@{
        schemaVersion = 1
        format = "json"
        visibility = "metadata-only"
        generator = [ordered]@{
            name = "scripts/generate-ai-content-manifest.ps1"
            version = "1.0.0"
        }
        schema = [ordered]@{
            name = "contributing/metadata/ai-content-manifest-v1.schema.json"
            version = 1
        }
        source = [ordered]@{
            repository = "SkylineCommunications/dataminer-docs"
            revision = $Revision
            revisionSource = "argument"
            configuration = [ordered]@{
                path = "docfx.json"
                sha256 = (("0" * 64) -join "")
            }
            baseUrl = "https://docs.dataminer.services/"
        }
        scope = [ordered]@{
            sourcePaths = @("*.md", "develop/**.md")
            domains = @("Automation", "Connector")
        }
        license = [ordered]@{
            identifier = "CC BY-NC-ND 4.0"
            name = "Creative Commons Attribution-NonCommercial-NoDerivatives 4.0 International"
            url = "https://creativecommons.org/licenses/by-nc-nd/4.0/"
            attribution = "Skyline Communications"
            source = "contributing/CTB_Documentation_Corpus_Policy.md"
        }
        counts = [ordered]@{
            current = @($Entries | Where-Object { -not $_.tombstone }).Count
            added = 0
            changed = 0
            moved = 0
            unchanged = 0
            removed = @($Entries | Where-Object { $_.tombstone }).Count
            tombstones = @($Entries | Where-Object { $_.tombstone }).Count
            total = $Entries.Count
        }
        entries = @($Entries | Sort-Object uid, tombstone, sourcePath)
        gaps = @()
    }
}

function Invoke-Delta {
    param(
        [Parameter(Mandatory = $true)][string]$Generator,
        [Parameter(Mandatory = $true)][string]$Root,
        [Parameter(Mandatory = $true)][string]$Current,
        [Parameter(Mandatory = $true)][string]$Output,
        [string]$Previous = ""
    )

    & $Generator `
        -RepositoryRoot $Root `
        -CurrentManifestPath $Current `
        -PreviousManifestPath $Previous `
        -OutputPath $Output `
        -SourceRevision ((Get-Content -LiteralPath $Current -Raw | ConvertFrom-Json).source.revision) | Out-Null
}

$repositoryRoot = [IO.Path]::GetFullPath((Join-Path $PSScriptRoot ".."))
$generator = Join-Path $PSScriptRoot "generate-deployment-delta.ps1"
$validator = Join-Path $PSScriptRoot "validate-deployment-delta.ps1"
$fixtureRoot = Join-Path ([IO.Path]::GetTempPath()) ("dataminer-docs-deployment-delta-" + [Guid]::NewGuid().ToString("N"))
$previousPath = Join-Path $fixtureRoot "previous-manifest.json"
$currentPath = Join-Path $fixtureRoot "current-manifest.json"
$samePath = Join-Path $fixtureRoot "same-manifest.json"
$firstRunDeltaPath = Join-Path $fixtureRoot "first-run-delta.json"
$deltaPath = Join-Path $fixtureRoot "delta.json"
$repeatDeltaPath = Join-Path $fixtureRoot "delta-repeat.json"
$noChangeDeltaPath = Join-Path $fixtureRoot "no-change-delta.json"
$ambiguousPreviousPath = Join-Path $fixtureRoot "ambiguous-previous.json"
$ambiguousCurrentPath = Join-Path $fixtureRoot "ambiguous-current.json"
$ambiguousDeltaPath = Join-Path $fixtureRoot "ambiguous-delta.json"
$invalidCurrentPath = Join-Path $fixtureRoot "invalid-current.json"
$invalidDeltaPath = Join-Path $fixtureRoot "invalid-delta.json"
$revisionOne = "1111111111111111111111111111111111111111"
$revisionTwo = "2222222222222222222222222222222222222222"

try {
    New-Item -ItemType Directory -Path $fixtureRoot -Force | Out-Null

    $previousEntries = @(
        New-Entry -Uid "StableFixture" -Path "develop/stable.md" -Url "https://docs.dataminer.services/develop/stable.html" -Revision $revisionOne -ContentHash (("a" * 64) -join "")
        New-Entry -Uid "ChangedFixture" -Path "develop/changed.md" -Url "https://docs.dataminer.services/develop/changed.html" -Revision $revisionOne -ContentHash (("b" * 64) -join "")
        New-Entry -Uid "MovedOld" -Path "develop/old.md" -Url "https://docs.dataminer.services/develop/old.html" -Revision $revisionOne -ContentHash (("c" * 64) -join "")
        New-Entry -Uid "DeprecatedFixture" -Path "develop/deprecated.md" -Url "https://docs.dataminer.services/develop/deprecated.html" -Revision $revisionOne -ContentHash (("d" * 64) -join "")
        New-Entry -Uid "RemovedFixture" -Path "develop/removed.md" -Url "https://docs.dataminer.services/develop/removed.html" -Revision $revisionOne -ContentHash (("e" * 64) -join "")
    )
    $currentEntries = @(
        New-Entry -Uid "StableFixture" -Path "develop/stable.md" -Url "https://docs.dataminer.services/develop/stable.html" -Revision $revisionTwo -ContentHash (("a" * 64) -join "")
        New-Entry -Uid "ChangedFixture" -Path "develop/changed.md" -Url "https://docs.dataminer.services/develop/changed.html" -Revision $revisionTwo -ContentHash (("f" * 64) -join "")
        New-Entry -Uid "MovedNew" -Path "develop/new.md" -Url "https://docs.dataminer.services/develop/new.html" -Revision $revisionTwo -ContentHash (("c" * 64) -join "") -UrlCompatibility "redirect_required" -UrlAliases @("https://docs.dataminer.services/develop/old.html")
        New-Entry -Uid "DeprecatedFixture" -Path "develop/deprecated.md" -Url "https://docs.dataminer.services/develop/deprecated.html" -Revision $revisionTwo -ContentHash (("d" * 64) -join "") -Lifecycle "deprecated"
        New-Entry -Uid "AddedFixture" -Path "develop/added.md" -Url "https://docs.dataminer.services/develop/added.html" -Revision $revisionTwo -ContentHash (("9" * 64) -join "")
        New-Entry -Uid "RemovedFixture" -Path "develop/removed.md" -Url "https://docs.dataminer.services/develop/removed.html" -Revision $revisionOne -ContentHash (("e" * 64) -join "") -Tombstone -RemovedInCommit $revisionTwo
    )
    Write-JsonFile -Path $previousPath -Value (New-Manifest -Revision $revisionOne -Entries $previousEntries)
    Write-JsonFile -Path $currentPath -Value (New-Manifest -Revision $revisionTwo -Entries $currentEntries)
    Copy-Item -LiteralPath $currentPath -Destination $samePath

    Invoke-Delta -Generator $generator -Root $repositoryRoot -Current $currentPath -Previous $previousPath -Output $deltaPath
    & $validator -RepositoryRoot $repositoryRoot -Path $deltaPath | Out-Null
    $delta = Get-Content -LiteralPath $deltaPath -Raw | ConvertFrom-Json
    Assert-Condition ($delta.empty -eq $false) "A changed deployment was incorrectly marked empty."
    Assert-Condition ($delta.counts.added -eq 1) "Addition event count is incorrect."
    Assert-Condition ($delta.counts.changed -eq 1) "Content change event count is incorrect."
    Assert-Condition ($delta.counts.moved -eq 1) "Move event count is incorrect."
    Assert-Condition ($delta.counts.deprecated -eq 1) "Deprecation event count is incorrect."
    Assert-Condition ($delta.counts.removed -eq 1) "Removal event count is incorrect."
    Assert-Condition ($delta.counts.redirects -eq 1 -and $delta.counts.tombstones -eq 1) "Redirect or tombstone count is incorrect."
    Assert-Condition (@($delta.events | Where-Object { $_.type -eq "moved" -and $_.previous.uid -eq "MovedOld" -and $_.current.uid -eq "MovedNew" }).Count -eq 1) "UID/source move was not reported."
    Assert-Condition ($delta.redirects[0].from -eq "https://docs.dataminer.services/develop/old.html" -and $delta.redirects[0].to -eq "https://docs.dataminer.services/develop/new.html") "Redirect mapping is incorrect."
    Assert-Condition ($delta.tombstones[0].uid -eq "RemovedFixture" -and $delta.tombstones[0].url -eq "https://docs.dataminer.services/develop/removed.html") "Removed UID/URL tombstone is incorrect."
    Assert-Condition ((Get-Content -LiteralPath $deltaPath -Raw) -notmatch "Fixture prose|summary|embedding") "Deployment delta contains transformed prose."

    Invoke-Delta -Generator $generator -Root $repositoryRoot -Current $currentPath -Previous $previousPath -Output $repeatDeltaPath
    Assert-Condition ((Get-FileHash -LiteralPath $deltaPath -Algorithm SHA256).Hash -eq (Get-FileHash -LiteralPath $repeatDeltaPath -Algorithm SHA256).Hash) "Repeated delta generation is not deterministic."

    Invoke-Delta -Generator $generator -Root $repositoryRoot -Current $samePath -Previous $currentPath -Output $noChangeDeltaPath
    $noChange = Get-Content -LiteralPath $noChangeDeltaPath -Raw | ConvertFrom-Json
    Assert-Condition ($noChange.empty -and $noChange.counts.total -eq 0 -and $noChange.counts.redirects -eq 0 -and $noChange.counts.tombstones -eq 0) "A no-change deployment did not produce an empty delta."

    Invoke-Delta -Generator $generator -Root $repositoryRoot -Current $currentPath -Output $firstRunDeltaPath
    $firstRun = Get-Content -LiteralPath $firstRunDeltaPath -Raw | ConvertFrom-Json
    Assert-Condition ($firstRun.counts.added -eq 5 -and $firstRun.counts.removed -eq 1) "First-run manifest retrieval was not safe."
    Assert-Condition (@($firstRun.gaps | Where-Object { $_.code -eq "previous-manifest-unavailable" }).Count -eq 1) "First-run previous-manifest gap was not explicit."

    $ambiguousPreviousEntries = @(
        New-Entry -Uid "AmbiguousOne" -Path "develop/ambiguous-one.md" -Url "https://docs.dataminer.services/develop/ambiguous-one.html" -Revision $revisionOne -ContentHash (("8" * 64) -join "")
        New-Entry -Uid "AmbiguousTwo" -Path "develop/ambiguous-two.md" -Url "https://docs.dataminer.services/develop/ambiguous-two.html" -Revision $revisionOne -ContentHash (("8" * 64) -join "")
    )
    $ambiguousCurrentEntries = @(
        New-Entry -Uid "AmbiguousCurrent" -Path "develop/ambiguous-current.md" -Url "https://docs.dataminer.services/develop/ambiguous-current.html" -Revision $revisionTwo -ContentHash (("8" * 64) -join "")
    )
    Write-JsonFile -Path $ambiguousPreviousPath -Value (New-Manifest -Revision $revisionOne -Entries $ambiguousPreviousEntries)
    Write-JsonFile -Path $ambiguousCurrentPath -Value (New-Manifest -Revision $revisionTwo -Entries $ambiguousCurrentEntries)
    Invoke-Delta -Generator $generator -Root $repositoryRoot -Current $ambiguousCurrentPath -Previous $ambiguousPreviousPath -Output $ambiguousDeltaPath
    $ambiguousDelta = Get-Content -LiteralPath $ambiguousDeltaPath -Raw | ConvertFrom-Json
    Assert-Condition ($ambiguousDelta.counts.ambiguousMoves -eq 1 -and $ambiguousDelta.counts.redirects -eq 0) "Ambiguous move was guessed or not reported."
    Assert-Condition (@($ambiguousDelta.events | Where-Object { $_.type -eq "ambiguous-move" -and @($_.candidates).Count -eq 2 }).Count -eq 1) "Ambiguous move candidates were not retained."

    $invalidCurrent = Get-Content -LiteralPath $currentPath -Raw | ConvertFrom-Json
    $invalidMoved = @($invalidCurrent.entries | Where-Object { $_.uid -eq "MovedNew" })[0]
    $invalidMoved.compatibility.url = "stable"
    Write-JsonFile -Path $invalidCurrentPath -Value $invalidCurrent
    $redirectRejected = $false
    try {
        Invoke-Delta -Generator $generator -Root $repositoryRoot -Current $invalidCurrentPath -Previous $previousPath -Output $invalidDeltaPath
    }
    catch {
        $redirectRejected = $true
    }
    Assert-Condition $redirectRejected "A URL move without redirect_required was accepted."

    Write-Output "Deployment delta tests passed."
}
finally {
    if (Test-Path -LiteralPath $fixtureRoot) {
        Remove-Item -LiteralPath $fixtureRoot -Recurse -Force
    }
}
