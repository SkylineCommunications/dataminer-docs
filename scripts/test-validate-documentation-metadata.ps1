[CmdletBinding()]
param()

Set-StrictMode -Version 2.0
$ErrorActionPreference = "Stop"

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

function Assert-Condition {
    param(
        [Parameter(Mandatory = $true)][bool]$Condition,
        [Parameter(Mandatory = $true)][string]$Message
    )

    if (-not $Condition) {
        throw $Message
    }
}

$repositoryRoot = [IO.Path]::GetFullPath((Join-Path $PSScriptRoot ".."))
$validator = Join-Path $PSScriptRoot "validate-documentation-metadata.ps1"
$schemaPath = Join-Path $repositoryRoot "contributing\metadata\documentation-metadata-v1.schema.json"
$fixtureRoot = Join-Path ([IO.Path]::GetTempPath()) ("dataminer-docs-metadata-" + [Guid]::NewGuid().ToString("N"))

try {
    New-Item -ItemType Directory -Path $fixtureRoot -Force | Out-Null

    Write-TestFile $fixtureRoot "valid.md" @'
---
metadata_version: 1
uid: Metadata_Valid_Fixture
description: Validate a complete DataMiner documentation metadata object with controlled values and required page identity fields.
area: develop
content_type: conceptual
authority: reference
authority_source: unknown
applies_to:
  - DataMiner
version: unversioned
owner: unknown
---

# Valid metadata fixture
'@

    Write-TestFile $fixtureRoot "legacy.md" @'
---
uid: Legacy_Fixture
---

# Legacy fixture
'@

    Write-TestFile $fixtureRoot "sentinel.md" @'
---
metadata_version: 1
uid: Metadata_Sentinel_Fixture
description: Validate explicit unknown and not_applicable values for legacy content with no confirmed current scope.
area: unknown
content_type: legacy
authority: historical
authority_source: unknown
applies_to:
  - unknown
version: unknown
owner: unknown
---

# Sentinel metadata fixture
'@

    Write-TestFile $fixtureRoot "missing-field.md" @'
---
metadata_version: 1
uid: Metadata_Missing_Field_Fixture
description: Reject this object because the required owner field is intentionally missing.
area: develop
content_type: conceptual
authority: unknown
applies_to:
  - unknown
version: unknown
---

# Missing field fixture
'@

    Write-TestFile $fixtureRoot "mixed-unknown.md" @'
---
metadata_version: 1
uid: Metadata_Mixed_Unknown_Fixture
description: Reject this object because applicability cannot mix an unknown sentinel with a product value.
area: develop
content_type: conceptual
authority: unknown
applies_to:
  - unknown
  - DataMiner
version: unknown
owner: unknown
---

# Mixed applicability fixture
'@

    Write-TestFile $fixtureRoot "unknown-key.md" @'
---
metadata_version: 1
uid: Metadata_Unknown_Key_Fixture
description: Reject this object because an undocumented front matter key is present.
area: develop
content_type: conceptual
authority: unknown
applies_to:
  - unknown
version: unknown
owner: unknown
unexpected: value
---

# Unknown key fixture
'@

    & $validator -RepositoryRoot $fixtureRoot -SchemaPath $schemaPath -Path @("valid.md", "legacy.md", "sentinel.md")
    & $validator -RepositoryRoot $fixtureRoot -SchemaPath $schemaPath -Path @("valid.md", "sentinel.md") -RequireVersion1

    $failed = $false
    try {
        & $validator -RepositoryRoot $fixtureRoot -SchemaPath $schemaPath -Path "missing-field.md"
    }
    catch {
        $failed = $true
    }
    Assert-Condition $failed "The validator accepted metadata with a missing required field."

    $failed = $false
    try {
        & $validator -RepositoryRoot $fixtureRoot -SchemaPath $schemaPath -Path "mixed-unknown.md"
    }
    catch {
        $failed = $true
    }
    Assert-Condition $failed "The validator accepted mixed unknown applicability values."

    $failed = $false
    try {
        & $validator -RepositoryRoot $fixtureRoot -SchemaPath $schemaPath -Path "unknown-key.md"
    }
    catch {
        $failed = $true
    }
    Assert-Condition $failed "The validator accepted an undocumented metadata key."

    $failed = $false
    try {
        & $validator -RepositoryRoot $fixtureRoot -SchemaPath $schemaPath -Path "legacy.md" -RequireVersion1
    }
    catch {
        $failed = $true
    }
    Assert-Condition $failed "The validator accepted a legacy page when version 1 metadata was required."

    Write-Output "Documentation metadata validator tests passed."
}
finally {
    if (Test-Path -LiteralPath $fixtureRoot) {
        Remove-Item -LiteralPath $fixtureRoot -Recurse -Force
    }
}
