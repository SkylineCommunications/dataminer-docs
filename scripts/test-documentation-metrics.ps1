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
    [IO.File]::WriteAllText($Path, (($Value | ConvertTo-Json -Depth 30) + [Environment]::NewLine), $utf8NoBom)
}

function Invoke-Metrics {
    param(
        [Parameter(Mandatory = $true)][string]$Root,
        [Parameter(Mandatory = $true)][string]$Output,
        [Parameter(Mandatory = $true)][string]$Baseline,
        [Parameter(Mandatory = $true)][string]$Migration,
        [Parameter(Mandatory = $true)][string]$Validation,
        [Parameter(Mandatory = $true)][string]$Provenance,
        [Parameter(Mandatory = $true)][string]$Manifest,
        [Parameter(Mandatory = $true)][string]$Delta,
        [Parameter(Mandatory = $true)][string]$Sitemap,
        [Parameter(Mandatory = $true)][string]$Quality,
        [Parameter(Mandatory = $true)][string]$ExternalLinks,
        [Parameter(Mandatory = $true)][string]$CSharp,
        [Parameter(Mandatory = $true)][string]$Xml,
        [Parameter(Mandatory = $true)][string]$Safety,
        [Parameter(Mandatory = $true)][string]$Governance,
        [Parameter(Mandatory = $true)][string]$Coupling,
        [Parameter(Mandatory = $true)][string]$AgentSync,
        [Parameter(Mandatory = $true)][string]$OutputSchema
    )

    & $script:Generator `
        -RepositoryRoot $Root `
        -OutputPath $Output `
        -SchemaPath $OutputSchema `
        -BaselinePath $Baseline `
        -MetadataMigrationPath $Migration `
        -MetadataValidationPath $Validation `
        -ProvenancePath $Provenance `
        -ManifestPath $Manifest `
        -DeltaPath $Delta `
        -SitemapPath $Sitemap `
        -QualityPath $Quality `
        -ExternalLinkPath $ExternalLinks `
        -CSharpPath $CSharp `
        -XmlPath $Xml `
        -SafetyPath $Safety `
        -GovernancePath $Governance `
        -CouplingPath $Coupling `
        -AgentSyncEventsPath $AgentSync `
        -SourceRevision $script:Revision `
        -GenerationDate "2026-09-19" | Out-Null
}

function Assert-ValidReport {
    param([Parameter(Mandatory = $true)][string]$Root, [Parameter(Mandatory = $true)][string]$Path)

    & $script:Validator -RepositoryRoot $Root -Path $Path -SchemaPath $script:Schema | Out-Null
}

$repositoryRoot = [IO.Path]::GetFullPath((Join-Path $PSScriptRoot ".."))
$script:Generator = Join-Path $PSScriptRoot "generate-documentation-metrics.ps1"
$script:Validator = Join-Path $PSScriptRoot "validate-documentation-metrics.ps1"
$script:Schema = Join-Path $repositoryRoot "contributing\metadata\documentation-metrics-v1.schema.json"
$fixtureRoot = Join-Path ([IO.Path]::GetTempPath()) ("dataminer-docs-metrics-" + [Guid]::NewGuid().ToString("N"))
$script:Revision = "2222222222222222222222222222222222222222"

$baselinePath = Join-Path $fixtureRoot "docs-corpus-baseline.json"
$migrationPath = Join-Path $fixtureRoot "d2-2-metadata-migration-report.json"
$validationPath = Join-Path $fixtureRoot "d2-2-validation-report.json"
$provenancePath = Join-Path $fixtureRoot "_artifacts\generated-metadata-provenance.json"
$manifestPath = Join-Path $fixtureRoot "_artifacts\ai-content-manifest.json"
$deltaPath = Join-Path $fixtureRoot "_artifacts\deployment-delta.json"
$noChangeDeltaPath = Join-Path $fixtureRoot "_artifacts\deployment-delta-empty.json"
$sitemapPath = Join-Path $fixtureRoot "_artifacts\segmented-sitemap-report.json"
$qualityPath = Join-Path $fixtureRoot "_artifacts\d4-1-quality-report.json"
$externalLinksPath = Join-Path $fixtureRoot "_artifacts\external-link-report.json"
$csharpPath = Join-Path $fixtureRoot "_artifacts\csharp-documentation-examples\csharp-documentation-examples.json"
$xmlPath = Join-Path $fixtureRoot "_artifacts\xml-documentation-examples.json"
$safetyPath = Join-Path $fixtureRoot "_artifacts\d4-4-documentation-safety-report.json"
$governancePath = Join-Path $fixtureRoot "_artifacts\documentation-governance.json"
$couplingPath = Join-Path $fixtureRoot "_artifacts\documentation-coupling.json"
$agentSyncPath = Join-Path $fixtureRoot "_artifacts\agent-sync-events.json"
$missingAgentPath = Join-Path $fixtureRoot "_artifacts\missing-agent-sync-events.json"
$outputOne = Join-Path $fixtureRoot "metrics-one.json"
$outputTwo = Join-Path $fixtureRoot "metrics-two.json"
$outputNoChangeOne = Join-Path $fixtureRoot "metrics-no-change-one.json"
$outputNoChangeTwo = Join-Path $fixtureRoot "metrics-no-change-two.json"
$outputUnknownAgent = Join-Path $fixtureRoot "metrics-unknown-agent.json"

try {
    New-Item -ItemType Directory -Path $fixtureRoot -Force | Out-Null

    Write-JsonFile -Path $baselinePath -Value ([ordered]@{
            schemaVersion = 2
            source = [ordered]@{
                metrics = [ordered]@{
                    pages = 10
                    pagesWithUid = 9
                    pagesWithoutUid = 1
                    byDomain = [ordered]@{
                        Automation = 4
                        Connector = 6
                    }
                }
                uid = [ordered]@{
                    pagesWithUid = 9
                    pagesWithoutUid = 1
                    duplicateUidCount = 1
                }
                links = [ordered]@{
                    linkCount = 20
                    xrefCount = 12
                    localLinkCount = 14
                    externalLinkCount = 6
                }
                automation = [ordered]@{
                    pages = 4
                    pagesWithUid = 4
                    pagesWithoutUid = 0
                    linkCount = 8
                    xrefCount = 5
                }
                connector = [ordered]@{
                    pages = 6
                    pagesWithUid = 5
                    pagesWithoutUid = 1
                    linkCount = 12
                    xrefCount = 7
                }
            }
            generated = [ordered]@{
                sitemap = [ordered]@{
                    urlCount = 9
                    duplicateUrlCount = 0
                }
                xrefmap = [ordered]@{
                    xrefCount = 12
                    duplicateUidCount = 1
                    referencesWithoutHref = 0
                }
            }
        })

    Write-JsonFile -Path $migrationPath -Value ([ordered]@{
            schemaVersion = 1
            coverage = [ordered]@{
                totalPages = 10
                domains = [ordered]@{
                    Automation = 4
                    Connector = 6
                }
                metadataVersion1 = 8
                unknownVersions = 2
                unknownAuthorities = 1
                pendingReview = 3
            }
            scopes = @(
                [ordered]@{ domain = "Automation"; currentCount = 4 },
                [ordered]@{ domain = "Connector"; currentCount = 6 }
            )
        })

    Write-JsonFile -Path $validationPath -Value ([ordered]@{
            schemaVersion = 1
            checks = @(
                [ordered]@{ name = "local-link-check"; status = "passed_with_preexisting_warnings"; warnings = 2 }
            )
        })

    Write-JsonFile -Path $provenancePath -Value ([ordered]@{
            schemaVersion = 1
            outputs = [ordered]@{
                api = @(@{ path = "develop/api/a.md" })
                schema = @(@{ path = "develop/schemadoc/Protocol/a.md" })
            }
            artifacts = @(@{ kind = "package"; identity = "fixture" })
            gaps = @()
        })

    Write-JsonFile -Path $manifestPath -Value ([ordered]@{
            schemaVersion = 1
            counts = [ordered]@{
                current = 10
                added = 1
                changed = 1
                moved = 1
                unchanged = 7
                removed = 0
                tombstones = 0
                total = 10
            }
            gaps = @()
        })

    $delta = [ordered]@{
        schemaVersion = 1
        empty = $false
        counts = [ordered]@{
            total = 3
            added = 1
            changed = 1
            moved = 1
            deprecated = 0
            removed = 0
            ambiguousMoves = 0
            redirects = 1
            tombstones = 0
        }
        events = @(
            [ordered]@{
                type = "added"
                current = [ordered]@{ domain = "Automation"; sourcePath = "develop/devguide/Automation/a.md" }
                previous = $null
            },
            [ordered]@{
                type = "changed"
                current = [ordered]@{ domain = "Connector"; sourcePath = "develop/devguide/Connector/a.md" }
                previous = $null
            },
            [ordered]@{
                type = "moved"
                current = [ordered]@{ domain = "Connector"; sourcePath = "develop/devguide/Connector/b.md" }
                previous = [ordered]@{ domain = "Connector"; sourcePath = "develop/devguide/Connector/old.md" }
            }
        )
        gaps = @()
    }
    Write-JsonFile -Path $deltaPath -Value $delta
    Write-JsonFile -Path $noChangeDeltaPath -Value ([ordered]@{
            schemaVersion = 1
            empty = $true
            counts = [ordered]@{
                total = 0
                added = 0
                changed = 0
                moved = 0
                deprecated = 0
                removed = 0
                ambiguousMoves = 0
                redirects = 0
                tombstones = 0
            }
            events = @()
            gaps = @()
        })

    Write-JsonFile -Path $sitemapPath -Value ([ordered]@{
            schemaVersion = 1
            counts = [ordered]@{
                urls = 9
                segments = 2
                withLastmod = 9
                withoutLastmod = 0
            }
            gaps = @()
        })

    Write-JsonFile -Path $qualityPath -Value ([ordered]@{
            schemaVersion = 1
            summary = [ordered]@{
                changedMarkdownFiles = 2
                findings = 2
                newFindings = 1
                legacyExceptions = 1
            }
            findings = @(
                [ordered]@{ status = "new"; path = "develop/devguide/Automation/a.md"; workstream = "automation" },
                [ordered]@{ status = "legacy_exception"; path = "develop/devguide/Connector/a.md"; workstream = "connector" }
            )
        })

    Write-JsonFile -Path $externalLinksPath -Value ([ordered]@{
            schemaVersion = 1
            summary = [ordered]@{
                passed = 5
                failed = 1
            }
        })

    Write-JsonFile -Path $csharpPath -Value ([ordered]@{
            schemaVersion = 1
            counts = [ordered]@{
                csharpBlockCount = 2
                compiled = 1
                failed = 0
                notAttempted = 1
            }
            examples = @(
                [ordered]@{ domain = "Automation"; result = [ordered]@{ status = "compiled" } },
                [ordered]@{ domain = "Connector"; result = [ordered]@{ status = "not-attempted" } }
            )
        })

    Write-JsonFile -Path $xmlPath -Value ([ordered]@{
            schemaVersion = 1
            counts = [ordered]@{
                examples = 2
                passed = 1
                expectedFailures = 1
                failed = 0
                unverified = 0
                gaps = 0
            }
            examples = @(
                [ordered]@{ domain = "Automation"; result = [ordered]@{ status = "passed" } },
                [ordered]@{ domain = "Protocol"; result = [ordered]@{ status = "expected-failure" } }
            )
        })

    Write-JsonFile -Path $safetyPath -Value ([ordered]@{
            schemaVersion = 1
            summary = [ordered]@{
                findings = 3
                newFindings = 1
                legacyExceptions = 1
                allowlisted = 1
                gaps = 1
                newGaps = 1
                preExistingGaps = 0
            }
            findings = @(
                [ordered]@{ status = "new"; category = "normative_conflict"; ruleId = "conflicting-rule"; path = "develop/devguide/Automation/a.md" },
                [ordered]@{ status = "legacy_exception"; category = "unsafe_default"; ruleId = "legacy-rule"; path = "develop/devguide/Connector/a.md" },
                [ordered]@{ status = "allowlisted"; category = "credential_exposure"; ruleId = "example-rule"; path = "develop/devguide/Connector/b.md" }
            )
            gaps = @(@{ status = "new"; kind = "unclassified-code-block" })
        })

    Write-JsonFile -Path $governancePath -Value ([ordered]@{
            schemaVersion = 1
            summary = [ordered]@{
                filesScanned = 10
                version1Pages = 10
                metadataVersionGaps = 0
                ownerGaps = 4
                authorityGaps = 2
                reviewGaps = 1
                pendingReviews = 2
                dueReviews = 1
                staleContent = 1
                unmappedVersion1Pages = 0
                configurationEvidenceGaps = 0
            }
            findings = @(
                [ordered]@{ workstream = "automation"; code = "stale_content"; path = "develop/devguide/Automation/a.md" },
                [ordered]@{ workstream = "connector"; code = "owner_gap"; path = "develop/devguide/Connector/a.md" }
            )
        })

    Write-JsonFile -Path $couplingPath -Value ([ordered]@{
            schemaVersion = 1
            summary = [ordered]@{
                matchedEntries = 2
                targetedChecks = 3
                gaps = 1
            }
            documentationReleaseGate = [ordered]@{
                status = "pass"
                acknowledgement = "acknowledged"
            }
            affectedDocumentation = [ordered]@{
                paths = @("develop/devguide/Automation/a.md", "develop/devguide/Connector/a.md")
            }
            matchedEntries = @(
                [ordered]@{
                    id = "automation"
                    targets = [ordered]@{
                        paths = @("develop/devguide/Automation/a.md")
                    }
                },
                [ordered]@{
                    id = "connector"
                    targets = [ordered]@{
                        paths = @("develop/devguide/Connector/a.md")
                    }
                }
            )
            unresolved = @(@{ id = "follow-up" })
            gaps = @(@{ code = "unresolved-follow-up" })
        })

    Write-JsonFile -Path $agentSyncPath -Value ([ordered]@{
            schemaVersion = 1
            events = @(
                [ordered]@{ domain = "Automation"; occurredAt = "2026-09-18T00:00:00Z" },
                [ordered]@{ domain = "Connector"; occurredAt = "2026-09-17T00:00:00Z" }
            )
        })

    Invoke-Metrics -Root $fixtureRoot -Output $outputOne -Baseline $baselinePath -Migration $migrationPath -Validation $validationPath -Provenance $provenancePath -Manifest $manifestPath -Delta $deltaPath -Sitemap $sitemapPath -Quality $qualityPath -ExternalLinks $externalLinksPath -CSharp $csharpPath -Xml $xmlPath -Safety $safetyPath -Governance $governancePath -Coupling $couplingPath -AgentSync $agentSyncPath -OutputSchema $script:Schema
    Invoke-Metrics -Root $fixtureRoot -Output $outputTwo -Baseline $baselinePath -Migration $migrationPath -Validation $validationPath -Provenance $provenancePath -Manifest $manifestPath -Delta $deltaPath -Sitemap $sitemapPath -Quality $qualityPath -ExternalLinks $externalLinksPath -CSharp $csharpPath -Xml $xmlPath -Safety $safetyPath -Governance $governancePath -Coupling $couplingPath -AgentSync $agentSyncPath -OutputSchema $script:Schema
    Assert-Condition ((Get-FileHash -LiteralPath $outputOne -Algorithm SHA256).Hash -eq (Get-FileHash -LiteralPath $outputTwo -Algorithm SHA256).Hash) "Repeated D6.3 generation was not byte-identical."
    Assert-ValidReport -Root $fixtureRoot -Path $outputOne

    $report = Get-Content -LiteralPath $outputOne -Raw | ConvertFrom-Json
    Assert-Condition ([int]$report.summary.metricCount -eq 10) "D6.3 metric count was not recorded."
    Assert-Condition ([int]$report.metrics.metadataCoverage.counts.totalPages -eq 10) "D2 metadata coverage was not aggregated."
    Assert-Condition ([int]$report.metrics.metadataCoverage.counts.unknownVersions -eq 2) "D2 unknown-version count was not aggregated."
    Assert-Condition ([int]$report.metrics.uidUrlLinkHealth.counts.pagesWithoutUid -eq 1) "UID health was not aggregated."
    Assert-Condition ([int]$report.metrics.snippetValidation.counts.csharpCompiled -eq 1 -and [int]$report.metrics.snippetValidation.counts.xmlPassed -eq 1) "Snippet compile or schema success was not aggregated."
    Assert-Condition ([int]$report.metrics.safety.counts.newFindings -eq 1 -and [int]$report.metrics.safety.counts.legacyExceptions -eq 1) "Safety new-versus-legacy counts were not aggregated."
    Assert-Condition ([int]$report.metrics.governance.counts.staleReviews -eq 1) "Stale review count was not aggregated."
    Assert-Condition ([int]$report.metrics.coupling.counts.acknowledged -eq 1) "Coupling acknowledgement was not aggregated."
    Assert-Condition ([int]$report.metrics.sourceDocumentationDelta.counts.deltaEvents -eq 3) "Source-to-documentation delta events were not aggregated."
    Assert-Condition ([int]$report.metrics.agentSync.counts.lagDays -eq 1) "Agent synchronization lag was not calculated from the latest event."
    Assert-Condition (@($report.gaps | Where-Object { $_.code -eq "quality-new-findings" }).Count -eq 1) "Quality findings were not retained as a gap."
    $reportJson = Get-Content -LiteralPath $outputOne -Raw
    Assert-Condition ($reportJson -notmatch "Fixture prose|password|ghp_") "D6.3 report exposed prose or a secret-shaped fixture value."

    Invoke-Metrics -Root $fixtureRoot -Output $outputNoChangeOne -Baseline $baselinePath -Migration $migrationPath -Validation $validationPath -Provenance $provenancePath -Manifest $manifestPath -Delta $noChangeDeltaPath -Sitemap $sitemapPath -Quality $qualityPath -ExternalLinks $externalLinksPath -CSharp $csharpPath -Xml $xmlPath -Safety $safetyPath -Governance $governancePath -Coupling $couplingPath -AgentSync $agentSyncPath -OutputSchema $script:Schema
    Invoke-Metrics -Root $fixtureRoot -Output $outputNoChangeTwo -Baseline $baselinePath -Migration $migrationPath -Validation $validationPath -Provenance $provenancePath -Manifest $manifestPath -Delta $noChangeDeltaPath -Sitemap $sitemapPath -Quality $qualityPath -ExternalLinks $externalLinksPath -CSharp $csharpPath -Xml $xmlPath -Safety $safetyPath -Governance $governancePath -Coupling $couplingPath -AgentSync $agentSyncPath -OutputSchema $script:Schema
    Assert-Condition ((Get-FileHash -LiteralPath $outputNoChangeOne -Algorithm SHA256).Hash -eq (Get-FileHash -LiteralPath $outputNoChangeTwo -Algorithm SHA256).Hash) "Repeated no-change metrics were not byte-identical."
    Assert-ValidReport -Root $fixtureRoot -Path $outputNoChangeOne
    $noChange = Get-Content -LiteralPath $outputNoChangeOne -Raw | ConvertFrom-Json
    Assert-Condition ([bool]$noChange.metrics.sourceDocumentationDelta.empty) "No-change metrics did not retain empty=true."
    Assert-Condition ([int]$noChange.metrics.sourceDocumentationDelta.counts.deltaEvents -eq 0) "No-change metrics contained delta events."
    Assert-Condition ([bool]$noChange.summary.emptyDelta) "No-change summary did not retain empty=true."
    Assert-Condition ([string]$noChange.identity.value -eq [string]$noChange.summary.reportIdentity) "No-change report identity was not stable."

    Invoke-Metrics -Root $fixtureRoot -Output $outputUnknownAgent -Baseline $baselinePath -Migration $migrationPath -Validation $validationPath -Provenance $provenancePath -Manifest $manifestPath -Delta $deltaPath -Sitemap $sitemapPath -Quality $qualityPath -ExternalLinks $externalLinksPath -CSharp $csharpPath -Xml $xmlPath -Safety $safetyPath -Governance $governancePath -Coupling $couplingPath -AgentSync $missingAgentPath -OutputSchema $script:Schema
    Assert-ValidReport -Root $fixtureRoot -Path $outputUnknownAgent
    $unknownAgent = Get-Content -LiteralPath $outputUnknownAgent -Raw | ConvertFrom-Json
    Assert-Condition ([string]$unknownAgent.metrics.agentSync.status -eq "not_available") "Missing agent event source was not explicit."
    Assert-Condition ([string]$unknownAgent.metrics.agentSync.counts.lagDays -eq "unknown") "Missing agent event source did not retain unknown lag."
    Assert-Condition (@($unknownAgent.gaps | Where-Object { $_.code -eq "agent-sync-event-source-not-available" }).Count -eq 1) "Missing agent event source did not produce an explicit gap."

    Write-Output "Documentation metrics tests passed."
}
finally {
    if (Test-Path -LiteralPath $fixtureRoot) {
        Remove-Item -LiteralPath $fixtureRoot -Recurse -Force
    }
}
