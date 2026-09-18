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
        [Parameter(Mandatory = $true)][string]$Path,
        [Parameter(Mandatory = $true)][string]$Content
    )

    $directory = Split-Path -Parent $Path
    if (-not (Test-Path -LiteralPath $directory -PathType Container)) {
        New-Item -ItemType Directory -Path $directory -Force | Out-Null
    }
    $utf8NoBom = New-Object Text.UTF8Encoding($false)
    [IO.File]::WriteAllText($Path, $Content, $utf8NoBom)
}

function Write-Json {
    param(
        [Parameter(Mandatory = $true)][string]$Path,
        [Parameter(Mandatory = $true)]$Value
    )

    Write-TestFile -Path $Path -Content (($Value | ConvertTo-Json -Depth 30) + [Environment]::NewLine)
}

function Get-Sha256 {
    param([Parameter(Mandatory = $true)][string]$Path)

    return (Get-FileHash -LiteralPath $Path -Algorithm SHA256).Hash.ToLowerInvariant()
}

function Invoke-ExpectedFailure {
    param(
        [Parameter(Mandatory = $true)][scriptblock]$Action,
        [Parameter(Mandatory = $true)][string]$Message
    )

    $failed = $false
    try {
        & $Action
    }
    catch {
        $failed = $true
    }
    Assert-Condition $failed $Message
}

$repositoryRoot = [IO.Path]::GetFullPath((Join-Path $PSScriptRoot ".."))
$generator = Join-Path $repositoryRoot "scripts\generate-xml-documentation-examples.ps1"
$validator = Join-Path $repositoryRoot "scripts\validate-xml-documentation-examples.ps1"
$fixtureRoot = Join-Path $repositoryRoot "scripts\fixtures\xml-documentation-examples"
$testRoot = Join-Path ([IO.Path]::GetTempPath()) ("dataminer-docs-xml-examples-" + [Guid]::NewGuid().ToString("N"))
$sourceRoot = Join-Path $testRoot "source"
$schemaRoot = Join-Path $testRoot "schemas"
$configurationPath = Join-Path $testRoot "configuration.json"
$outputOne = Join-Path $testRoot "report-one.json"
$outputTwo = Join-Path $testRoot "report-two.json"
$missingSourceOutput = Join-Path $testRoot "report-missing-source.json"
$invalidOutput = Join-Path $testRoot "report-invalid.json"
$revision = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"

try {
    New-Item -ItemType Directory -Path $testRoot -Force | Out-Null
    Copy-Item -LiteralPath (Join-Path $fixtureRoot "source") -Destination $sourceRoot -Recurse -Force
    Copy-Item -LiteralPath (Join-Path $fixtureRoot "schemas") -Destination $schemaRoot -Recurse -Force

    $protocolSchemaPath = Join-Path $schemaRoot "protocol.xsd"
    $automationSchemaPath = Join-Path $schemaRoot "automation.xsd"
    $configuration = [ordered]@{
        schemaVersion = 1
        format = "xml-documentation-examples"
        repository = "SkylineCommunications/dataminer-docs"
        language = "xml"
        domains = @(
            [ordered]@{
                id = "protocol"
                name = "Protocol"
                rootElement = "Protocol"
                namespace = "urn:fixture:protocol"
                sourceRoots = @("source/Protocol")
                schemaId = "protocol"
                fragmentWrapper = [ordered]@{
                    id = "protocol-fixture-fragment"
                    rootElement = "DocumentationFragment"
                    namespace = "urn:fixture:protocol"
                    allowOpenElementsAtEnd = $true
                    validation = "wrapped-well-formed"
                }
            },
            [ordered]@{
                id = "automation"
                name = "Automation"
                rootElement = "DMSScript"
                namespace = "urn:fixture:automation"
                sourceRoots = @("source/Automation")
                schemaId = "automation"
                fragmentWrapper = [ordered]@{
                    id = "automation-fixture-fragment"
                    rootElement = "DocumentationFragment"
                    namespace = "urn:fixture:automation"
                    allowOpenElementsAtEnd = $true
                    validation = "wrapped-well-formed"
                }
            }
        )
        schemas = @(
            [ordered]@{
                id = "protocol"
                domain = "Protocol"
                rootElement = "Protocol"
                namespace = "urn:fixture:protocol"
                version = "unknown"
                versionEvidence = [ordered]@{
                    sourcePage = "source/SchemaProtocol.md"
                    sourceLine = 1
                    status = "not-published"
                    note = "The fixture intentionally has no Protocol package version."
                }
                source = [ordered]@{
                    repository = "SkylineCommunications/dataminer-docs-fixtures"
                    commit = $revision
                    files = @(
                        [ordered]@{
                            path = "schemas/protocol.xsd"
                            role = "entry"
                            url = "https://example.invalid/protocol.xsd"
                            sha256 = Get-Sha256 -Path $protocolSchemaPath
                        }
                    )
                }
            },
            [ordered]@{
                id = "automation"
                domain = "Automation"
                rootElement = "DMSScript"
                namespace = "urn:fixture:automation"
                version = "1.1.10"
                versionEvidence = [ordered]@{
                    sourcePage = "source/SchemaAutomationScript.md"
                    sourceLine = 1
                    status = "published"
                    note = "The fixture pins the published Automation evidence."
                }
                source = [ordered]@{
                    repository = "SkylineCommunications/dataminer-docs-fixtures"
                    commit = $revision
                    files = @(
                        [ordered]@{
                            path = "schemas/automation.xsd"
                            role = "entry"
                            url = "https://example.invalid/automation.xsd"
                            sha256 = Get-Sha256 -Path $automationSchemaPath
                        }
                    )
                }
            }
        )
    }
    Write-Json -Path $configurationPath -Value $configuration

    & $generator -RepositoryRoot $testRoot -ConfigurationPath $configurationPath -OutputPath $outputOne -SchemaRoot $testRoot -SourceRevision $revision -GenerationDate "2026-09-18" | Out-Null
    & $generator -RepositoryRoot $testRoot -ConfigurationPath $configurationPath -OutputPath $outputTwo -SchemaRoot $testRoot -SourceRevision $revision -GenerationDate "2026-09-18" | Out-Null
    & $validator -RepositoryRoot $testRoot -ConfigurationPath $configurationPath -Path $outputOne | Out-Null

    Assert-Condition ((Get-Sha256 -Path $outputOne) -eq (Get-Sha256 -Path $outputTwo)) "Repeated XML example generation was not deterministic."
    $report = Get-Content -LiteralPath $outputOne -Raw | ConvertFrom-Json
    Assert-Condition ($report.counts.examples -eq 3) "Fixture example count is incorrect."
    Assert-Condition ($report.counts.completeDocuments -eq 2) "Complete-document classification is incorrect."
    Assert-Condition ($report.counts.fragments -eq 1) "Fragment classification is incorrect."
    Assert-Condition ($report.counts.passed -eq 2) "Fixture passed count is incorrect."
    Assert-Condition ($report.counts.expectedFailures -eq 1) "Negative example was not recorded as an expected failure."
    Assert-Condition ($report.counts.failed -eq 0) "Fixture contains an unexpected failure."
    $fragment = @($report.examples | Where-Object { $_.source.uid -eq "XmlAutomationFragment" })[0]
    Assert-Condition ($fragment.classification.kind -eq "fragment" -and $fragment.wrapper.applied -and $fragment.wrapper.validation -eq "wrapped-well-formed") "The fragment did not use its declared wrapper."
    $negative = @($report.examples | Where-Object { $_.source.uid -eq "XmlAutomationNegative" })[0]
    Assert-Condition ($negative.negative -and $negative.result.status -eq "expected-failure" -and $negative.result.schemaStatus -eq "invalid") "The explicitly negative schema-invalid example was not allowed."
    $automationSchema = @($report.schemas | Where-Object { $_.id -eq "automation" })[0]
    $protocolSchema = @($report.schemas | Where-Object { $_.id -eq "protocol" })[0]
    Assert-Condition ($automationSchema.version -eq "1.1.10" -and $protocolSchema.version -eq "unknown") "Schema version evidence was changed or invented."

    & $generator -RepositoryRoot $testRoot -ConfigurationPath $configurationPath -OutputPath $missingSourceOutput -SourceRevision $revision -GenerationDate "2026-09-18" | Out-Null
    & $validator -RepositoryRoot $testRoot -ConfigurationPath $configurationPath -Path $missingSourceOutput | Out-Null
    $missingSourceReport = Get-Content -LiteralPath $missingSourceOutput -Raw | ConvertFrom-Json
    Assert-Condition (@($missingSourceReport.gaps | Where-Object { $_.kind -eq "schema-source-missing" }).Count -ge 2) "Missing schema sources were not reported."
    Invoke-ExpectedFailure -Action {
        & $generator -RepositoryRoot $testRoot -ConfigurationPath $configurationPath -OutputPath (Join-Path $testRoot "required-sources.json") -RequireSchemaSources
    } -Message "RequireSchemaSources did not fail for missing pinned sources."

    Write-TestFile -Path (Join-Path $sourceRoot "Protocol\unmarked-invalid.md") -Content @'
---
uid: XmlProtocolUnmarkedInvalid
---

# Unmarked invalid fixture

```xml complete
<?xml version="1.0" encoding="utf-8"?>
<Protocol xmlns="urn:fixture:protocol" />
```
'@
    Invoke-ExpectedFailure -Action {
        & $generator -RepositoryRoot $testRoot -ConfigurationPath $configurationPath -OutputPath $invalidOutput -SchemaRoot $testRoot -SourceRevision $revision -GenerationDate "2026-09-18"
    } -Message "An unmarked schema-invalid example did not fail the harness."
    $invalidReport = Get-Content -LiteralPath $invalidOutput -Raw | ConvertFrom-Json
    Assert-Condition (@($invalidReport.examples | Where-Object { $_.source.uid -eq "XmlProtocolUnmarkedInvalid" -and $_.result.status -eq "failed" }).Count -eq 1) "The unmarked schema-invalid example was not recorded as failed."

    Write-Output "XML documentation example tests passed."
}
finally {
    if (Test-Path -LiteralPath $testRoot) {
        Remove-Item -LiteralPath $testRoot -Recurse -Force
    }
}
