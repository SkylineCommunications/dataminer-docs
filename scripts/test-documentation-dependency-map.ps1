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

function Write-JsonFixture {
    param(
        [Parameter(Mandatory = $true)][string]$Path,
        [Parameter(Mandatory = $true)]$Value
    )

    $utf8NoBom = New-Object Text.UTF8Encoding($false)
    [IO.File]::WriteAllText($Path, ($Value | ConvertTo-Json -Depth 30) + [Environment]::NewLine, $utf8NoBom)
}

$repositoryRoot = [IO.Path]::GetFullPath((Join-Path $PSScriptRoot ".."))
$validator = Join-Path $PSScriptRoot "validate-documentation-dependency-map.ps1"
$resolver = Join-Path $PSScriptRoot "resolve-documentation-coupling.ps1"
$mapPath = Join-Path $repositoryRoot "contributing\metadata\documentation-dependency-map-v1.json"
$fixtureRoot = Join-Path ([IO.Path]::GetTempPath()) ("dataminer-docs-coupling-" + [Guid]::NewGuid().ToString("N"))
$changePath = Join-Path $fixtureRoot "product-change.json"
$unknownChangePath = Join-Path $fixtureRoot "unknown-change.json"
$reportPath = Join-Path $fixtureRoot "coupling-report.json"
$unknownReportPath = Join-Path $fixtureRoot "unknown-report.json"

function New-Change {
    param(
        [string]$Acknowledgement = "acknowledged",
        [string]$UpdateStatus = "updated",
        [string]$Release = "10.6.8",
        [string]$PackageId = "Skyline.Protocol",
        [string]$PackageVersion = "1.2.3"
    )

    return [ordered]@{
        '$schema' = "documentation-coupling-change-v1.schema.json"
        schemaVersion = 1
        policy = "D6.2"
        format = "json"
        visibility = "repository-metadata"
        changeId = "product-pr-unknown"
        source = [ordered]@{
            repository = "unknown"
            pullRequest = "unknown"
            revision = "unknown"
            release = $Release
            package = [ordered]@{
                id = $PackageId
                version = $PackageVersion
            }
            followUp = "Confirm the product repository and immutable revision before release."
        }
        changeKinds = @("schema")
        changedPaths = @("schemas/Protocol.xsd")
        affectedDocumentation = [ordered]@{
            uids = @("CTB_Documentation_Metadata", "CTB_Documentation_Coupling")
            areas = @("develop", "contributing")
            followUp = "Review the matched map targets and preserve stable UIDs and URLs."
        }
        generatedReferences = [ordered]@{
            present = $true
            contentTypes = @("schema")
            sourceIdentity = [ordered]@{
                release = $Release
                package = [ordered]@{
                    id = $PackageId
                    version = $PackageVersion
                }
                followUp = "Confirm the source release and package identity from the product build."
            }
            followUp = "Inspect D2.3 provenance before documentation release."
        }
        acknowledgement = [ordered]@{
            status = $Acknowledgement
            actor = "unknown"
            recordedAt = "2026-09-19"
            evidence = "product change metadata"
            followUp = "Confirm the acknowledging actor without inventing a handle."
        }
        documentationUpdate = [ordered]@{
            status = $UpdateStatus
            uids = @("CTB_Documentation_Metadata", "CTB_Documentation_Coupling")
            areas = @("develop", "contributing")
            evidence = "documentation PR unknown"
            followUp = "Record the documentation PR or explain why no update applies."
        }
        dispatch = [ordered]@{
            status = "unknown"
            permission = "unknown"
            followUp = "Confirm cross-repository invocation permission."
        }
    }
}

try {
    New-Item -ItemType Directory -Path $fixtureRoot -Force | Out-Null

    & $validator -RepositoryRoot $repositoryRoot -MapPath $mapPath -ReportPath $reportPath | Out-Null
    Assert-Condition (Test-Path -LiteralPath $reportPath -PathType Leaf) "Dependency map validator did not write its report."
    $mapReport = Get-Content -LiteralPath $reportPath -Raw | ConvertFrom-Json
    Assert-Condition ($mapReport.policy -eq "D6.2") "Dependency map report has the wrong policy."
    Assert-Condition ($mapReport.summary.entries -eq 6) "Dependency map entry count is incorrect."
    Assert-Condition ($mapReport.summary.checks -eq 8) "Dependency map check count is incorrect."
    Assert-Condition ($mapReport.summary.gates -eq 1) "Dependency map gate count is incorrect."
    Assert-Condition ($mapReport.summary.targetUids -eq 7) "Dependency map target UID count is incorrect."
    Assert-Condition ($mapReport.crossRepositoryTrigger.permission -eq "unknown") "Cross-repository permission was not retained as unknown."

    Write-JsonFixture -Path $changePath -Value (New-Change)
    & $validator -RepositoryRoot $repositoryRoot -MapPath $mapPath -ChangePath $changePath | Out-Null
    & $resolver -RepositoryRoot $repositoryRoot -MapPath $mapPath -ChangePath $changePath -OutputPath $reportPath -FailOnGate -FailOnUnmapped | Out-Null
    $report = Get-Content -LiteralPath $reportPath -Raw | ConvertFrom-Json
    Assert-Condition ($report.summary.matchedEntries -ge 1) "Schema change did not match a dependency-map entry."
    Assert-Condition (@($report.matchedEntries | Where-Object { $_.id -eq "schema-contract" }).Count -eq 1) "Schema change did not match the schema-contract entry."
    Assert-Condition (@($report.targetedChecks | Where-Object { $_.id -eq "provenance" }).Count -eq 1) "Schema change did not target provenance validation."
    Assert-Condition (@($report.affectedDocumentation.uids | Where-Object { $_ -eq "CTB_Documentation_Metadata" }).Count -eq 1) "Schema target UID was not reported."
    Assert-Condition ($report.documentationReleaseGate.status -eq "pass") "Acknowledged and updated schema change did not pass the documentation gate."
    Assert-Condition ($report.source.release -eq "10.6.8" -and $report.source.package.version -eq "1.2.3") "Product source release or package identity was not retained."

    Write-JsonFixture -Path $unknownChangePath -Value (New-Change -Acknowledgement "unknown" -UpdateStatus "unknown" -Release "unknown" -PackageId "unknown" -PackageVersion "unknown")
    & $resolver -RepositoryRoot $repositoryRoot -MapPath $mapPath -ChangePath $unknownChangePath -OutputPath $unknownReportPath | Out-Null
    $unknownReport = Get-Content -LiteralPath $unknownReportPath -Raw | ConvertFrom-Json
    Assert-Condition ($unknownReport.documentationReleaseGate.status -eq "pending") "Unknown acknowledgement or source identity did not leave the gate pending."
    Assert-Condition (@($unknownReport.gaps | Where-Object { $_.code -eq "generated-source-identity-unknown" }).Count -eq 1) "Unknown generated source identity was not reported."

    $failed = $false
    try {
        & $resolver -RepositoryRoot $repositoryRoot -MapPath $mapPath -ChangePath $unknownChangePath -OutputPath $unknownReportPath -FailOnGate | Out-Null
    }
    catch {
        $failed = $true
    }
    Assert-Condition $failed "FailOnGate accepted an unresolved documentation gate."

    & $resolver -RepositoryRoot $repositoryRoot -MapPath $mapPath -ChangedPath @("contributing/CTB_Documentation_Coupling.md") -OutputPath $reportPath | Out-Null
    $documentationReport = Get-Content -LiteralPath $reportPath -Raw | ConvertFrom-Json
    Assert-Condition ($documentationReport.summary.matchedEntries -ge 4) "A coupling page change did not resolve the expected documentation targets."
    Assert-Condition (@($documentationReport.targetedChecks | Where-Object { $_.id -eq "docfx" }).Count -eq 1) "A coupling page change did not target DocFX."

    Write-Output "Documentation dependency map tests passed."
}
finally {
    if (Test-Path -LiteralPath $fixtureRoot) {
        Remove-Item -LiteralPath $fixtureRoot -Recurse -Force
    }
}
