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

$repositoryRoot = [IO.Path]::GetFullPath((Join-Path $PSScriptRoot ".."))
$migrator = Join-Path $PSScriptRoot "migrate-documentation-metadata.ps1"
$schemaPath = Join-Path $repositoryRoot "contributing\metadata\documentation-metadata-v1.schema.json"
$fixtureRoot = Join-Path ([IO.Path]::GetTempPath()) ("dataminer-docs-migration-" + [Guid]::NewGuid().ToString("N"))
$manifestPath = Join-Path $fixtureRoot "scope.json"
$reportPath = Join-Path $fixtureRoot "report.json"

try {
    New-Item -ItemType Directory -Path $fixtureRoot -Force | Out-Null
    Write-TestFile $fixtureRoot "develop\devguide\Connector\guide.md" @'
---
uid: Fixture_Guide
---

# Fixture guide

This guide contains no confirmed release applicability.
'@
    Write-TestFile $fixtureRoot "develop\schemadoc\Protocol\schema.md" @'
---
uid: Fixture_Schema
---

# fixture attribute

This page is aligned with Protocol XML schema package 1.2.3.
'@
    Write-TestFile $fixtureRoot "develop\devguide\Automation\existing.md" @'
---
metadata_version: 1
uid: Fixture_Existing
description: Keep an existing complete metadata object unchanged while the migration processes the surrounding target pages.
area: develop
content_type: conceptual
authority: unknown
authority_source: unknown
lifecycle: active
applies_to:
  - DataMiner
version: unknown
owner: unknown
review_status: needs_update
review_date: 2026-09-17
compatibility:
  uid: stable
  url: stable
---

# Existing metadata
'@
    Write-TestFile $fixtureRoot "develop\toc.yml" @'
items:
- name: Fixture
'@
    $manifest = @'
{
  "schemaVersion": 1,
  "migration": "D2.2",
  "baseline": {
    "id": "D0.2",
    "sourceRevision": "fixture",
    "sourcePageCount": 3,
    "staleTrackerCount": 3,
    "currentExpectedPageCount": 3,
    "unicodeNormalizedAdditions": []
  },
  "migrationDate": "2026-09-17",
  "scopes": [
    {
      "domain": "Connector",
      "relativeRoot": "develop/devguide/Connector",
      "contentType": "conceptual",
      "baselineCount": 1
    },
    {
      "domain": "Connector",
      "relativeRoot": "develop/schemadoc/Protocol",
      "contentType": "schema",
      "baselineCount": 1
    },
    {
      "domain": "Automation",
      "relativeRoot": "develop/devguide/Automation",
      "contentType": "conceptual",
      "baselineCount": 1
    }
  ]
}
'@
    Write-TestFile $fixtureRoot "scope.json" $manifest

    & $migrator -RepositoryRoot $fixtureRoot -ScopeManifestPath $manifestPath -ReportPath $reportPath -SchemaPath $schemaPath
    $firstReport = [IO.File]::ReadAllText($reportPath)
    $firstFiles = @(
        Get-ChildItem -LiteralPath $fixtureRoot -Recurse -File -Filter "*.md" |
            ForEach-Object { [IO.File]::ReadAllText($_.FullName) }
    )

    & $migrator -RepositoryRoot $fixtureRoot -ScopeManifestPath $manifestPath -ReportPath $reportPath -SchemaPath $schemaPath
    $secondReport = [IO.File]::ReadAllText($reportPath)
    $secondFiles = @(
        Get-ChildItem -LiteralPath $fixtureRoot -Recurse -File -Filter "*.md" |
            ForEach-Object { [IO.File]::ReadAllText($_.FullName) }
    )

    Assert-Condition ($firstReport -eq $secondReport) "The migration report is not deterministic across repeat runs."
    Assert-Condition ($firstFiles.Count -eq $secondFiles.Count) "The repeat run changed the fixture file count."
    for ($index = 0; $index -lt $firstFiles.Count; $index++) {
        Assert-Condition ($firstFiles[$index] -eq $secondFiles[$index]) "The repeat run changed fixture page content."
    }

    $guide = [IO.File]::ReadAllText((Join-Path $fixtureRoot "develop\devguide\Connector\guide.md"))
    Assert-Condition ($guide -match "(?m)^metadata_version: 1\r?$") "The guide did not receive version 1 metadata."
    Assert-Condition ($guide -match "(?m)^version: unknown\r?$") "The guide did not retain an unknown version sentinel."
    $schema = [IO.File]::ReadAllText((Join-Path $fixtureRoot "develop\schemadoc\Protocol\schema.md"))
    Assert-Condition ($schema -match "(?m)^version: 1\.2\.3\r?$") "The schema package version was not extracted."
    Assert-Condition ($schema -match "(?m)^content_type: schema\r?$") "The schema classification was not applied."

    Write-Output "Documentation metadata migration tests passed."
}
finally {
    if (Test-Path -LiteralPath $fixtureRoot) {
        Remove-Item -LiteralPath $fixtureRoot -Recurse -Force
    }
}
