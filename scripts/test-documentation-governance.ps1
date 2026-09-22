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
$validator = Join-Path $PSScriptRoot "validate-documentation-governance.ps1"
$policyPath = Join-Path $repositoryRoot "contributing\metadata\documentation-governance-v1.json"
$fixtureRoot = Join-Path ([IO.Path]::GetTempPath()) ("dataminer-docs-governance-" + [Guid]::NewGuid().ToString("N"))
$reportPath = Join-Path $fixtureRoot "governance-report.json"

try {
    New-Item -ItemType Directory -Path $fixtureRoot -Force | Out-Null

    Write-TestFile $fixtureRoot "develop\devguide\Connector\valid.md" @'
---
metadata_version: 1
uid: Governance_Connector_Valid
description: Validate connector governance metadata with an explicit authority and owner sentinel.
area: develop
content_type: conceptual
authority: reference
authority_source: unknown
applies_to:
  - DataMiner
version: unversioned
owner: unknown
---

# Connector governance fixture
'@

    Write-TestFile $fixtureRoot "develop\api\GeneratedApi.md" @'
---
metadata_version: 1
uid: Governance_Generated_Api
description: Validate generated API governance metadata with an explicit authority and owner sentinel.
area: develop
content_type: api
authority: reference
authority_source: unknown
applies_to:
  - DataMiner
version: unversioned
owner: unknown
---

# Generated API governance fixture
'@

    Write-TestFile $fixtureRoot "develop\devguide\Automation\MissingOwner.md" @'
---
metadata_version: 1
uid: Governance_Automation_Missing_Owner
description: Reject governed metadata when the required owner field is absent instead of accepting an empty ownership claim.
area: develop
content_type: conceptual
authority: reference
authority_source: unknown
applies_to:
  - DataMiner
version: unversioned
---

# Missing owner fixture
'@

    Write-TestFile $fixtureRoot "dataminer\Historical.md" @'
---
metadata_version: 1
uid: Governance_Historical
description: Validate that historical governance content can use the metadata contract sentinel without receiving a false authority requirement.
area: dataminer
content_type: legacy
authority: historical
authority_source: unknown
applies_to:
  - unknown
version: unknown
owner: unknown
---

# Historical governance fixture
'@

    & $validator -RepositoryRoot $fixtureRoot -PolicyPath $policyPath -Path @(
        "develop\devguide\Connector\valid.md",
        "develop\api\GeneratedApi.md",
        "dataminer\Historical.md"
    ) -ReportPath $reportPath

    Assert-Condition (Test-Path -LiteralPath $reportPath -PathType Leaf) "The governance validator did not write its report."
    $report = Get-Content -LiteralPath $reportPath -Raw | ConvertFrom-Json
    Assert-Condition ($report.policy -eq "D6.1") "The governance report has the wrong policy identifier."
    Assert-Condition ($report.summary.ownerGaps -eq 3) "The governance report did not retain the three explicit owner gaps."
    Assert-Condition (@($report.summary.PSObject.Properties.Name) -notcontains "staleContent") "The governance report retained removed stale-review metadata."

    $failed = $false
    try {
        & $validator -RepositoryRoot $fixtureRoot -PolicyPath $policyPath -Path "develop\devguide\Automation\MissingOwner.md"
    }
    catch {
        $failed = $true
    }
    Assert-Condition $failed "The governance validator accepted a missing required owner field."

    Write-Output "Documentation governance validator tests passed."
}
finally {
    if (Test-Path -LiteralPath $fixtureRoot) {
        Remove-Item -LiteralPath $fixtureRoot -Recurse -Force
    }
}
