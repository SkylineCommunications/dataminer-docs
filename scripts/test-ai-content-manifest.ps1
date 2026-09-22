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

function Write-TestFile {
    param(
        [Parameter(Mandatory = $true)][string]$Root,
        [Parameter(Mandatory = $true)][string]$RelativePath,
        [Parameter(Mandatory = $true)][string]$Content
    )

    $path = Join-Path $Root $RelativePath
    $directory = Split-Path -Parent $path
    if (-not (Test-Path -LiteralPath $directory -PathType Container)) {
        New-Item -ItemType Directory -Path $directory -Force | Out-Null
    }
    $utf8NoBom = New-Object Text.UTF8Encoding($false)
    [IO.File]::WriteAllText($path, $Content, $utf8NoBom)
}

function Get-Hash {
    param([Parameter(Mandatory = $true)][string]$Path)

    return (Get-FileHash -LiteralPath $Path -Algorithm SHA256).Hash.ToLowerInvariant()
}

$repositoryRoot = [IO.Path]::GetFullPath((Join-Path $PSScriptRoot ".."))
$generator = Join-Path $PSScriptRoot "generate-ai-content-manifest.ps1"
$validator = Join-Path $PSScriptRoot "validate-ai-content-manifest.ps1"
$fixtureRoot = Join-Path ([IO.Path]::GetTempPath()) ("dataminer-docs-ai-manifest-" + [Guid]::NewGuid().ToString("N"))
$manifestOne = Join-Path $fixtureRoot "manifest-one.json"
$manifestTwo = Join-Path $fixtureRoot "manifest-two.json"
$manifestThree = Join-Path $fixtureRoot "manifest-three.json"
$revisionOne = "1111111111111111111111111111111111111111"
$revisionTwo = "2222222222222222222222222222222222222222"

try {
    New-Item -ItemType Directory -Path $fixtureRoot -Force | Out-Null
    Write-TestFile $fixtureRoot "docfx.json" @'
{
  "build": {
    "content": [
      {
        "files": [
          "**/*.md"
        ]
      }
    ],
    "resource": [
      {
        "files": [
          "images/**"
        ]
      }
    ],
    "xref": [
      "xrefmap.yml"
    ],
    "sitemap": {
      "baseUrl": "https://docs.dataminer.services/",
      "changefreq": "hourly"
    }
  }
}
'@
    Write-TestFile $fixtureRoot "README.md" @'
---
uid: RootFixture
content_type: conceptual
authority: reference
authority_source: RootSource
applies_to:
  - DataMiner
version: unversioned
---

# Fixture root

See [the fixture page](develop/devguide/Connector/Page.md) and xref:PageFixture.

Fixture prose must not appear in the manifest.
'@
    Write-TestFile $fixtureRoot "develop/devguide/Connector/Page.md" @'
---
uid: PageFixture
content_type: conceptual
authority: canonical
applies_to:
  - DataMiner
version: "10.6.8"
---

# Fixture page

Stable page content.
'@
    Write-TestFile $fixtureRoot "develop/devguide/Connector/Removed.md" @'
---
uid: RemovedFixture
---

# Removed fixture

Stable removed content.
'@

    & $generator `
        -RepositoryRoot $fixtureRoot `
        -OutputPath $manifestOne `
        -SourceRevision $revisionOne `
        -ValidatorPath $validator | Out-Null
    & $validator -RepositoryRoot $fixtureRoot -Path $manifestOne | Out-Null

    $first = Get-Content -LiteralPath $manifestOne -Raw | ConvertFrom-Json
    Assert-Condition ($first.schemaVersion -eq 1) "Manifest schema version was not recorded."
    Assert-Condition ($first.format -eq "json") "Manifest format was not recorded."
    Assert-Condition ($first.visibility -eq "metadata-only") "Manifest visibility was not recorded."
    Assert-Condition ($first.counts.current -eq 3 -and $first.counts.added -eq 3) "Initial manifest counts were not recorded."
    Assert-Condition (@($first.entries | Where-Object { $_.uid -eq "PageFixture" }).Count -eq 1) "Fixture page was not recorded."
    $page = @($first.entries | Where-Object { $_.uid -eq "PageFixture" })[0]
    Assert-Condition ($page.area -eq "develop" -and $page.domain -eq "Connector") "Area and domain were not recorded."
    Assert-Condition ($page.appliesTo[0] -eq "DataMiner" -and $page.version -eq "10.6.8") "Applicability and version were not recorded."
    $rootEntry = @($first.entries | Where-Object { $_.uid -eq "RootFixture" })[0]
    Assert-Condition (@($rootEntry.xrefs | Where-Object { $_ -eq "PageFixture" }).Count -eq 1) "XRef dependency was not recorded."
    Assert-Condition (@($rootEntry.dependencies | Where-Object { $_ -like "*Page.md" }).Count -eq 1) "Local dependency was not recorded."
    Assert-Condition ($rootEntry.sourceBlob -like "https://github.com/SkylineCommunications/dataminer-docs/blob/$revisionOne/*") "Immutable source blob was not recorded."
    Assert-Condition ((Get-Content -LiteralPath $manifestOne -Raw) -notlike "*Fixture prose must not appear*") "Manifest contains source prose."

    Move-Item -LiteralPath (Join-Path $fixtureRoot "develop/devguide/Connector/Page.md") -Destination (Join-Path $fixtureRoot "develop/devguide/Connector/Renamed.md")
    Write-TestFile $fixtureRoot "README.md" @'
---
uid: RootFixture
content_type: conceptual
authority: reference
authority_source: RootSource
applies_to:
  - DataMiner
version: unversioned
---

# Fixture root

See the renamed fixture page.

Changed fixture prose must not appear in the manifest.
'@
    Remove-Item -LiteralPath (Join-Path $fixtureRoot "develop/devguide/Connector/Removed.md") -Force

    & $generator `
        -RepositoryRoot $fixtureRoot `
        -OutputPath $manifestTwo `
        -PriorManifestPath $manifestOne `
        -SourceRevision $revisionTwo `
        -ValidatorPath $validator | Out-Null
    & $generator `
        -RepositoryRoot $fixtureRoot `
        -OutputPath $manifestThree `
        -PriorManifestPath $manifestOne `
        -SourceRevision $revisionTwo `
        -ValidatorPath $validator | Out-Null
    & $validator -RepositoryRoot $fixtureRoot -Path $manifestTwo | Out-Null

    Assert-Condition ((Get-Hash $manifestTwo) -eq (Get-Hash $manifestThree)) "Repeated manifest runs produced different JSON."
    $second = Get-Content -LiteralPath $manifestTwo -Raw | ConvertFrom-Json
    Assert-Condition ($second.counts.current -eq 2) "Current entry count after changes is incorrect."
    Assert-Condition ($second.counts.added -eq 0 -and $second.counts.changed -eq 1) "Changed entry count is incorrect."
    Assert-Condition ($second.counts.moved -eq 1 -and $second.counts.removed -eq 1 -and $second.counts.tombstones -eq 1) "Move and tombstone counts are incorrect."
    Assert-Condition ($second.counts.total -eq 3) "Total entry count after changes is incorrect."

    $moved = @($second.entries | Where-Object { $_.uid -eq "PageFixture" })[0]
    Assert-Condition ($moved.changeType -eq "moved" -and $moved.moved -and $moved.previous.sourcePath -like "*Page.md") "Move semantics were not recorded."
    $changed = @($second.entries | Where-Object { $_.uid -eq "RootFixture" })[0]
    Assert-Condition ($changed.changeType -eq "changed" -and -not $changed.moved) "Content change semantics were not recorded."
    $removed = @($second.entries | Where-Object { $_.uid -eq "RemovedFixture" })[0]
    Assert-Condition ($removed.tombstone -and $removed.changeType -eq "removed" -and $removed.removedInCommit -eq $revisionTwo) "Removal tombstone semantics were not recorded."
    Assert-Condition ((Get-Content -LiteralPath $manifestTwo -Raw) -notlike "*Changed fixture prose must not appear*") "Changed source prose leaked into the manifest."

    Write-Output "AI content manifest tests passed."
}
finally {
    if (Test-Path -LiteralPath $fixtureRoot) {
        Remove-Item -LiteralPath $fixtureRoot -Recurse -Force
    }
}
