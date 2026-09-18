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

function Normalize-Text {
    param([AllowEmptyString()][string]$Text)

    if ($null -eq $Text) {
        return ""
    }
    return [Regex]::Replace($Text, "`r`n?", "`n")
}

function Get-TextSha256 {
    param([AllowEmptyString()][string]$Text)

    $bytes = [Text.Encoding]::UTF8.GetBytes((Normalize-Text $Text))
    $hash = [Security.Cryptography.SHA256]::Create()
    try {
        return ([BitConverter]::ToString($hash.ComputeHash($bytes))).Replace("-", "").ToLowerInvariant()
    }
    finally {
        $hash.Dispose()
    }
}

function Get-FileSha256 {
    param([Parameter(Mandatory = $true)][string]$Path)

    return (Get-FileHash -LiteralPath $Path -Algorithm SHA256).Hash.ToLowerInvariant()
}

function Write-Json {
    param(
        [Parameter(Mandatory = $true)][string]$Path,
        [Parameter(Mandatory = $true)]$Value
    )

    $utf8NoBom = New-Object Text.UTF8Encoding($false)
    [IO.File]::WriteAllText($Path, (($Value | ConvertTo-Json -Depth 30) + [Environment]::NewLine), $utf8NoBom)
}

function Get-DirectoryDigest {
    param([Parameter(Mandatory = $true)][string]$Root)

    $records = New-Object "System.Collections.Generic.List[string]"
    foreach ($file in @(Get-ChildItem -LiteralPath $Root -Recurse -File | Sort-Object FullName)) {
        $relative = $file.FullName.Substring($Root.TrimEnd("\").Length + 1).Replace("\", "/")
        [void]$records.Add("$relative|$(Get-FileSha256 -Path $file.FullName)")
    }
    return Get-TextSha256 (($records.ToArray() -join "`n") + "`n")
}

function New-ManifestEntry {
    param(
        [Parameter(Mandatory = $true)][string]$Root,
        [Parameter(Mandatory = $true)][string]$RelativePath,
        [Parameter(Mandatory = $true)][string]$Uid,
        [Parameter(Mandatory = $true)][string]$Domain,
        [Parameter(Mandatory = $true)][string]$Revision
    )

    $fullPath = Join-Path $Root $RelativePath
    $sourceHash = Get-TextSha256 (Get-Content -LiteralPath $fullPath -Raw)
    return [ordered]@{
        uid = $Uid
        url = "https://docs.dataminer.services/$($RelativePath.Replace('\', '/').Replace('.md', '.html'))"
        sourcePath = $RelativePath.Replace("\", "/")
        sourceCommit = $Revision
        sourceBlob = "https://github.com/SkylineCommunications/dataminer-docs/blob/$Revision/$($RelativePath.Replace('\', '/'))"
        contentHash = $sourceHash
        type = "conceptual"
        area = "develop"
        domain = $Domain
        authority = "reference"
        authoritySource = "unknown"
        lifecycle = "active"
        appliesTo = @("DataMiner")
        version = "unversioned"
        compatibility = [ordered]@{
            uid = "stable"
            url = "stable"
        }
        license = "CC BY-NC-ND 4.0"
        attribution = "Skyline Communications"
        xrefs = @()
        dependencies = @()
        changeType = "added"
        tombstone = $false
        moved = $false
    }
}

$repositoryRoot = [IO.Path]::GetFullPath((Join-Path $PSScriptRoot ".."))
$generator = Join-Path $PSScriptRoot "generate-internal-topic-packs.ps1"
$validator = Join-Path $PSScriptRoot "validate-internal-topic-packs.ps1"
$schemaPath = Join-Path $repositoryRoot "contributing\metadata\internal-topic-pack-v1.schema.json"
$fixtureRoot = Join-Path ([IO.Path]::GetTempPath()) ("dataminer-docs-topic-packs-" + [Guid]::NewGuid().ToString("N"))
$outputOne = Join-Path $fixtureRoot "_artifacts\output-one"
$outputTwo = Join-Path $fixtureRoot "_artifacts\output-two"
$badManifest = Join-Path $fixtureRoot "bad-manifest.json"
$revision = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"

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
    ]
  }
}
'@
    Write-TestFile $fixtureRoot "develop\devguide\Connector\Fixture.md" @'
---
uid: ConnectorFixture
---

# Connector fixture

Connector introduction.

See [the Automation details](xref:AutomationFixture#details).
See [the Automation page](../../devguide/Automation/Fixture.md).
See [the missing page](xref:MissingFixture).

## Details

Connector details retain their normative wording.

```text
xref:MissingFixture
```

## Examples

The example section remains a separate deterministic chunk.
'@
    Write-TestFile $fixtureRoot "develop\devguide\Automation\Fixture.md" @'
---
uid: AutomationFixture
---

# Automation fixture

Automation introduction.

## Details

Automation details.
'@
    Write-TestFile $fixtureRoot "develop\devguide\Connector\Duplicate.md" @'
---
uid: DuplicateFixture
---

# Connector duplicate

See [the duplicate target](xref:DuplicateFixture).
'@
    Write-TestFile $fixtureRoot "develop\devguide\Automation\Duplicate.md" @'
---
uid: DuplicateFixture
---

# Automation duplicate

This page intentionally creates an ambiguous target UID.
'@
    Write-TestFile $fixtureRoot "develop\other\Excluded.md" @'
---
uid: ExcludedFixture
---

# Excluded fixture

This page is outside the Connector and Automation manifest scope.
'@

    $entries = @(
        (New-ManifestEntry -Root $fixtureRoot -RelativePath "develop/devguide/Connector/Duplicate.md" -Uid "DuplicateFixture" -Domain "Connector" -Revision $revision),
        (New-ManifestEntry -Root $fixtureRoot -RelativePath "develop/devguide/Connector/Fixture.md" -Uid "ConnectorFixture" -Domain "Connector" -Revision $revision),
        (New-ManifestEntry -Root $fixtureRoot -RelativePath "develop/devguide/Automation/Duplicate.md" -Uid "DuplicateFixture" -Domain "Automation" -Revision $revision),
        (New-ManifestEntry -Root $fixtureRoot -RelativePath "develop/devguide/Automation/Fixture.md" -Uid "AutomationFixture" -Domain "Automation" -Revision $revision)
    )
    $manifest = [ordered]@{
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
            revision = $revision
            revisionSource = "argument"
            configuration = [ordered]@{
                path = "docfx.json"
                sha256 = Get-FileSha256 (Join-Path $fixtureRoot "docfx.json")
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
            current = 4
            added = 4
            changed = 0
            moved = 0
            unchanged = 0
            removed = 0
            tombstones = 0
            total = 4
        }
        entries = @($entries | Sort-Object uid, tombstone, sourcePath)
        gaps = @()
    }
    $manifestPath = Join-Path $fixtureRoot "ai-content-manifest.json"
    Write-Json -Path $manifestPath -Value $manifest

    & $generator -RepositoryRoot $fixtureRoot -ManifestPath $manifestPath -OutputPath $outputOne -SchemaPath $schemaPath -ValidatorPath $validator -GenerationDate "2026-09-18" -SourceRevision $revision | Out-Null
    & $generator -RepositoryRoot $fixtureRoot -ManifestPath $manifestPath -OutputPath $outputTwo -SchemaPath $schemaPath -ValidatorPath $validator -GenerationDate "2026-09-18" -SourceRevision $revision | Out-Null
    & $validator -RepositoryRoot $fixtureRoot -Path (Join-Path $outputOne "internal-only-topic-pack-manifest.json") -SchemaPath $schemaPath | Out-Null

    Assert-Condition ((Get-DirectoryDigest -Root $outputOne) -eq (Get-DirectoryDigest -Root $outputTwo)) "Repeated topic pack generation produced different files."
    $packManifestPath = Join-Path $outputOne "internal-only-topic-pack-manifest.json"
    $pack = Get-Content -LiteralPath $packManifestPath -Raw | ConvertFrom-Json
    Assert-Condition ($pack.visibility -eq "internal-only") "The fixture pack is not internal-only."
    Assert-Condition (-not $pack.distribution.publicRedistributionAllowed -and -not $pack.distribution.modelTrainingAllowed -and -not $pack.distribution.fineTuningAllowed) "The fixture pack has unsafe distribution flags."
    Assert-Condition ($pack.distribution.retentionDays -eq 14) "The fixture pack retention is not 14 days."
    Assert-Condition ($pack.source.revision -eq $revision) "The fixture source commit was not preserved."
    Assert-Condition ($pack.source.manifest.path -eq "ai-content-manifest.json") "The D3.1 manifest path was not preserved."
    Assert-Condition ($pack.counts.sourcePages -eq 4) "Unexpected fixture source page count."
    Assert-Condition ($pack.counts.chunks -eq 7) "Section chunking did not preserve the expected fixture structure."
    Assert-Condition ($pack.counts.resolvedLinks -ge 2) "Deterministic xref or local-link resolution did not occur."
    Assert-Condition ($pack.counts.unresolvedLinks -eq 2) "Expected missing and ambiguous links were not recorded."
    Assert-Condition ($pack.generation.contentIdentityExcludes[0] -eq "generatedAt") "Generation time was included in content identity."
    Assert-Condition (@($pack.chunks | Where-Object { $_.path -notmatch "^(automation|connector)/internal-only-[A-Za-z0-9._-]+\.md$" }).Count -eq 0) "A fixture chunk has an unsafe filename."
    $packManifestJson = Get-Content -LiteralPath $packManifestPath -Raw
    Assert-Condition ($packManifestJson -notlike "*normative wording*") "The pack manifest contains transformed source prose instead of metadata."

    $resolved = @($pack.chunks | ForEach-Object { $_.links.resolved } | Where-Object { $_.kind -eq "xref" })
    Assert-Condition (@($resolved | Where-Object { $_.original -eq "xref:AutomationFixture#details" }).Count -eq 1) "The section xref was not resolved."
    Assert-Condition (@($pack.unresolvedLinks | Where-Object { $_.reason -eq "target-not-in-pack" }).Count -eq 1) "The missing xref gap was not recorded."
    Assert-Condition (@($pack.unresolvedLinks | Where-Object { $_.reason -eq "ambiguous-target-uid" }).Count -eq 1) "The ambiguous UID gap was not recorded."

    $connectorDetail = @($pack.chunks | Where-Object { $_.sourceUid -eq "ConnectorFixture" -and $_.sourceSectionIdentity -like "*#details" })[0]
    $connectorDetailText = Get-Content -LiteralPath (Join-Path $outputOne $connectorDetail.path.Replace("/", "\")) -Raw
    Assert-Condition ($connectorDetailText -match "xref:MissingFixture") "A fenced-code xref was incorrectly transformed or removed."
    Assert-Condition ($connectorDetailText -match "source_section_identity") "Per-chunk section provenance is missing."
    Assert-Condition ($connectorDetailText -match "source_commit") "Per-chunk source commit provenance is missing."
    Assert-Condition ($connectorDetailText -match "license") "Per-chunk license provenance is missing."

    $packForBadManifest = $pack | ConvertTo-Json -Depth 30
    $bad = $packForBadManifest | ConvertFrom-Json
    $bad.visibility = "public"
    Write-Json -Path $badManifest -Value $bad
    $failed = $false
    try {
        & $validator -RepositoryRoot $fixtureRoot -Path $badManifest -SchemaPath $schemaPath | Out-Null
    }
    catch {
        $failed = $true
    }
    Assert-Condition $failed "The validator accepted a public topic pack manifest."

    Write-Output "Internal topic pack tests passed."
}
finally {
    if (Test-Path -LiteralPath $fixtureRoot) {
        Remove-Item -LiteralPath $fixtureRoot -Recurse -Force
    }
}
