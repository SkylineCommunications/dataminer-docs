[CmdletBinding()]
param(
    [string]$RepositoryRoot = "",
    [string]$Path = "",
    [string]$SchemaPath = ""
)

Set-StrictMode -Version 2.0
$ErrorActionPreference = "Stop"

$script:MetricCountKeys = @{
    metadataCoverage = @("totalPages", "metadataVersion1", "coveragePercent", "unknownVersions", "unknownAuthorities", "unknownOwners", "pendingReview")
    uidUrlLinkHealth = @("pages", "pagesWithUid", "pagesWithoutUid", "duplicateUid", "urls", "sitemapUrls", "duplicateUrls", "xrefReferences", "duplicateXref", "referencesWithoutHref", "localLinks", "externalLinks", "externalLinkFailures", "localLinkWarnings")
    snippetValidation = @("csharpExamples", "csharpCompiled", "csharpFailed", "csharpNotAttempted", "xmlExamples", "xmlPassed", "xmlExpectedFailures", "xmlFailed", "xmlUnverified", "xmlGaps", "compileSuccess", "compileFailure", "schemaSuccess", "schemaFailure")
    qualityGates = @("findings", "newFindings", "legacyExceptions", "markdownFiles", "externalLinks", "externalLinkFailures", "preExistingWarnings")
    safety = @("findings", "newFindings", "legacyExceptions", "allowlisted", "gaps", "newGaps", "preExistingGaps", "contradictions")
    generatedProvenance = @("apiOutputs", "schemaOutputs", "sourceArtifacts", "gaps")
    governance = @("filesScanned", "version1Pages", "metadataVersionGaps", "ownerGaps", "authorityGaps", "reviewGaps", "pendingReviews", "dueReviews", "staleReviews", "unmappedVersion1Pages", "configurationEvidenceGaps")
    coupling = @("matchedEntries", "targetedChecks", "gaps", "unresolved", "acknowledged", "notAcknowledged", "unknownAcknowledgements", "gatePass", "gatePending", "gateFail")
    sourceDocumentationDelta = @("manifestCurrent", "manifestAdded", "manifestChanged", "manifestMoved", "manifestUnchanged", "manifestRemoved", "manifestTombstones", "manifestTotal", "deltaEvents", "deltaAdded", "deltaChanged", "deltaMoved", "deltaDeprecated", "deltaRemoved", "deltaAmbiguousMoves", "redirects", "tombstones", "manifestGaps", "deltaGaps", "sitemapGaps", "sitemapUrls")
    agentSync = @("events", "lagDays", "eventsWithTimestamp")
}
$script:DomainCountKeys = @{
    metadataCoverage = @("pages", "metadataVersion1", "unknownVersions", "unknownAuthorities", "pendingReview")
    uidUrlLinkHealth = @("pages", "pagesWithUid", "pagesWithoutUid", "links", "xrefs")
    snippetValidation = @("csharpExamples", "csharpCompiled", "csharpFailed", "csharpNotAttempted", "xmlExamples", "xmlPassed", "xmlFailed", "schemaSuccess", "schemaFailure")
    qualityGates = @("findings", "newFindings", "legacyExceptions")
    safety = @("findings", "newFindings", "legacyExceptions", "contradictions")
    generatedProvenance = @("apiOutputs", "schemaOutputs", "sourceArtifacts", "gaps")
    governance = @("findings", "staleReviews", "pendingReviews", "ownerGaps", "authorityGaps")
    coupling = @("matchedEntries", "targetedPaths", "gaps")
    sourceDocumentationDelta = @("events", "added", "changed", "moved", "deprecated", "removed", "ambiguousMoves")
    agentSync = @("events", "lagDays")
}
$script:Domains = @("Automation", "Connector")
$script:ScriptRoot = $PSScriptRoot
if ([String]::IsNullOrWhiteSpace($script:ScriptRoot)) {
    $script:ScriptRoot = Split-Path -Parent $MyInvocation.MyCommand.Path
}
if ([String]::IsNullOrWhiteSpace($RepositoryRoot)) { $RepositoryRoot = Join-Path $script:ScriptRoot ".." }
if ([String]::IsNullOrWhiteSpace($Path)) { $Path = Join-Path $script:ScriptRoot "..\_artifacts\documentation-metrics.json" }
if ([String]::IsNullOrWhiteSpace($SchemaPath)) { $SchemaPath = Join-Path $script:ScriptRoot "..\contributing\metadata\documentation-metrics-v1.schema.json" }

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

function Get-Property {
    param(
        [AllowNull()]$Object,
        [Parameter(Mandatory = $true)][string]$Name,
        [AllowNull()]$Default = $null
    )

    if ($null -eq $Object) {
        return $Default
    }
    $property = $Object.PSObject.Properties[$Name]
    if ($null -ne $property) {
        return $property.Value
    }
    return $Default
}

function Get-Array {
    param([AllowNull()]$Value)

    if ($null -eq $Value) {
        return @()
    }
    if ($Value -is [string]) {
        return @([string]$Value)
    }
    return @($Value)
}

function Assert-Properties {
    param(
        [AllowNull()]$Object,
        [Parameter(Mandatory = $true)][string[]]$Required,
        [Parameter(Mandatory = $true)][string[]]$Allowed,
        [Parameter(Mandatory = $true)][string]$Context
    )

    Assert-Condition ($null -ne $Object) "$Context is missing."
    $names = @($Object.PSObject.Properties.Name)
    foreach ($name in $Required) {
        Assert-Condition ($names -contains $name) "$Context is missing '$name'."
    }
    foreach ($name in $names) {
        Assert-Condition ($Allowed -contains $name) "$Context contains unexpected property '$name'."
    }
}

function Test-CountValue {
    param(
        [AllowNull()]$Value,
        [Parameter(Mandatory = $true)][string]$Context
    )

    if ($Value -is [string]) {
        Assert-Condition ([string]$Value -in @("unknown", "not_available")) "$Context has an invalid unknown sentinel."
        return
    }
    Assert-Condition ($Value -is [byte] -or $Value -is [int16] -or $Value -is [int32] -or $Value -is [int64] -or $Value -is [single] -or $Value -is [double] -or $Value -is [decimal]) "$Context must be a non-negative number or an approved unknown sentinel."
    Assert-Condition ([double]$Value -ge 0) "$Context must not be negative."
}

function Assert-CountMap {
    param(
        [AllowNull()]$Counts,
        [Parameter(Mandatory = $true)][string[]]$AllowedKeys,
        [Parameter(Mandatory = $true)][string]$Context
    )

    Assert-Condition ($null -ne $Counts) "$Context is missing."
    foreach ($property in @($Counts.PSObject.Properties)) {
        Assert-Condition ($AllowedKeys -contains [string]$property.Name) "$Context contains unexpected count '$($property.Name)'."
        Test-CountValue -Value $property.Value -Context "$Context.$($property.Name)"
        if ([string]$property.Name -eq "coveragePercent" -and $property.Value -isnot [string]) {
            Assert-Condition ([double]$property.Value -le 100) "$Context.coveragePercent cannot exceed 100."
        }
    }
}

function Assert-DomainMetrics {
    param(
        [Parameter(Mandatory = $true)]$Metric,
        [Parameter(Mandatory = $true)][string]$MetricName
    )

    $domains = @(Get-Array $Metric.byDomain)
    Assert-Condition ($domains.Count -eq 2) "Metric '$MetricName' must contain exactly two domain records."
    $seen = @{}
    foreach ($domainRecord in $domains) {
        Assert-Properties -Object $domainRecord -Required @("domain", "status", "counts") -Allowed @("domain", "status", "counts") -Context "metric '$MetricName' domain"
        Assert-Condition ([string]$domainRecord.domain -in $script:Domains) "Metric '$MetricName' has an invalid domain."
        Assert-Condition (-not $seen.ContainsKey([string]$domainRecord.domain)) "Metric '$MetricName' contains duplicate domain '$($domainRecord.domain)'."
        $seen[[string]$domainRecord.domain] = $true
        Assert-Condition ([string]$domainRecord.status -in @("available", "partial", "not_available")) "Metric '$MetricName' domain status is invalid."
        Assert-CountMap -Counts $domainRecord.counts -AllowedKeys $script:DomainCountKeys[$MetricName] -Context "metric '$MetricName' domain '$($domainRecord.domain)' counts"
    }
}

function Assert-Metric {
    param(
        [Parameter(Mandatory = $true)]$Metric,
        [Parameter(Mandatory = $true)][string]$MetricName,
        [switch]$RequireEmpty
    )

    $required = @("status", "sourceArtifacts", "counts", "byDomain")
    $allowed = @("status", "sourceArtifacts", "counts", "byDomain")
    if ($RequireEmpty) {
        $required += "empty"
        $allowed += "empty"
    }
    Assert-Properties -Object $Metric -Required $required -Allowed $allowed -Context "metric '$MetricName'"
    Assert-Condition ([string]$Metric.status -in @("available", "partial", "not_available")) "Metric '$MetricName' status is invalid."
    Assert-Condition ($null -ne $Metric.sourceArtifacts) "Metric '$MetricName' sourceArtifacts is missing."
    Assert-CountMap -Counts $Metric.counts -AllowedKeys $script:MetricCountKeys[$MetricName] -Context "metric '$MetricName' counts"
    Assert-DomainMetrics -Metric $Metric -MetricName $MetricName
    if ($RequireEmpty) {
        if ($Metric.empty -is [string]) {
            Assert-Condition ([string]$Metric.empty -in @("unknown", "not_available")) "Metric '$MetricName' empty has an invalid sentinel."
        }
        else {
            Assert-Condition ($Metric.empty -is [bool]) "Metric '$MetricName' empty must be boolean or unknown."
        }
    }
}

function Get-ObjectSha256 {
    param([Parameter(Mandatory = $true)]$Value)

    $json = $Value | ConvertTo-Json -Depth 40 -Compress
    $bytes = [Text.Encoding]::UTF8.GetBytes($json)
    $sha = [Security.Cryptography.SHA256]::Create()
    try {
        return ([BitConverter]::ToString($sha.ComputeHash($bytes))).Replace("-", "").ToLowerInvariant()
    }
    finally {
        $sha.Dispose()
    }
}

function Get-IdentityMaterial {
    param([Parameter(Mandatory = $true)]$Report)

    $summary = [ordered]@{
        artifactCount = [int]$Report.summary.artifactCount
        availableArtifacts = [int]$Report.summary.availableArtifacts
        unavailableArtifacts = [int]$Report.summary.unavailableArtifacts
        invalidArtifacts = [int]$Report.summary.invalidArtifacts
        metricCount = [int]$Report.summary.metricCount
        availableMetrics = [int]$Report.summary.availableMetrics
        gapRecords = [int]$Report.summary.gapRecords
        unresolvedGaps = [int]$Report.summary.unresolvedGaps
        notAvailableGaps = [int]$Report.summary.notAvailableGaps
        emptyDelta = $Report.summary.emptyDelta
    }
    return [ordered]@{
        schemaVersion = 1
        policy = "D6.3"
        sourceRevision = [string]$Report.source.revision
        scope = $Report.scope
        artifacts = @($Report.artifacts | ForEach-Object {
                [ordered]@{
                    id = [string]$_.id
                    path = [string]$_.path
                    status = [string]$_.status
                    available = [bool]$_.available
                    sha256 = [string]$_.sha256
                    schemaVersion = $_.schemaVersion
                }
            })
        metrics = $Report.metrics
        gaps = $Report.gaps
        summary = $summary
    }
}

$repositoryRoot = ConvertTo-FullPath $RepositoryRoot
$reportPath = ConvertTo-FullPath $Path
$schemaPath = ConvertTo-FullPath $SchemaPath
Assert-Condition (Test-Path -LiteralPath $repositoryRoot -PathType Container) "Repository root '$repositoryRoot' does not exist."
Assert-Condition (Test-Path -LiteralPath $reportPath -PathType Leaf) "Documentation metrics report '$reportPath' does not exist."
Assert-Condition (Test-Path -LiteralPath $schemaPath -PathType Leaf) "Documentation metrics schema '$schemaPath' does not exist."

$reportJson = Get-Content -LiteralPath $reportPath -Raw
try {
    $report = $reportJson | ConvertFrom-Json
    $schema = Get-Content -LiteralPath $schemaPath -Raw | ConvertFrom-Json
}
catch {
    throw "Documentation metrics report or schema is not valid JSON: $($_.Exception.Message)"
}

Assert-Condition ([string]$schema.title -eq "DataMiner documentation quality and synchronization metrics") "Unexpected D6.3 schema."
if ($null -ne (Get-Command Test-Json -ErrorAction SilentlyContinue)) {
    try {
        Assert-Condition (Test-Json -Json $reportJson -SchemaFile $schemaPath) "Documentation metrics report does not conform to the committed JSON Schema."
    }
    catch {
        throw "Documentation metrics JSON Schema validation failed: $($_.Exception.Message)"
    }
}

$topLevel = @('$schema', "schemaVersion", "policy", "format", "visibility", "generator", "schema", "identity", "source", "retention", "protection", "scope", "artifacts", "metrics", "gaps", "summary")
Assert-Properties -Object $report -Required $topLevel -Allowed $topLevel -Context "documentation metrics report"
Assert-Condition ([int]$report.schemaVersion -eq 1) "Unsupported documentation metrics schema version."
Assert-Condition ([string]$report.policy -eq "D6.3") "Documentation metrics policy must be D6.3."
Assert-Condition ([string]$report.format -eq "json") "Documentation metrics format must be json."
Assert-Condition ([string]$report.visibility -eq "repository-metadata") "Documentation metrics visibility must be repository-metadata."

Assert-Properties -Object $report.generator -Required @("name", "version") -Allowed @("name", "version") -Context "report.generator"
Assert-Condition ([string]$report.generator.name -eq "scripts/generate-documentation-metrics.ps1") "Unexpected documentation metrics generator."
Assert-Condition (-not [String]::IsNullOrWhiteSpace([string]$report.generator.version)) "Documentation metrics generator version is empty."
Assert-Properties -Object $report.schema -Required @("name", "version") -Allowed @("name", "version") -Context "report.schema"
Assert-Condition ([string]$report.schema.name -eq "contributing/metadata/documentation-metrics-v1.schema.json") "Unexpected documentation metrics schema name."
Assert-Condition ([int]$report.schema.version -eq 1) "Unexpected documentation metrics schema version."

Assert-Properties -Object $report.identity -Required @("algorithm", "value", "materialVersion") -Allowed @("algorithm", "value", "materialVersion") -Context "report.identity"
Assert-Condition ([string]$report.identity.algorithm -eq "sha256") "Documentation metrics identity must use SHA-256."
Assert-Condition ([string]$report.identity.value -match "^[0-9a-f]{64}$") "Documentation metrics identity is not a lowercase SHA-256 value."
Assert-Condition ([int]$report.identity.materialVersion -eq 1) "Unsupported documentation metrics identity material version."

Assert-Properties -Object $report.source -Required @("repository", "revision", "revisionSource", "generatedAt", "generatedAtSource") -Allowed @("repository", "revision", "revisionSource", "generatedAt", "generatedAtSource") -Context "report.source"
Assert-Condition ([string]$report.source.repository -eq "SkylineCommunications/dataminer-docs") "Documentation metrics source repository is incorrect."
Assert-Condition ([string]$report.source.revision -eq "unknown" -or [string]$report.source.revision -match "^[0-9a-f]{40}$") "Documentation metrics source revision is invalid."
Assert-Condition ([string]$report.source.revisionSource -in @("argument", "git", "unknown")) "Documentation metrics revision source is invalid."
Assert-Condition ([string]$report.source.generatedAt -eq "unknown" -or [string]$report.source.generatedAt -match "^\d{4}-\d{2}-\d{2}$") "Documentation metrics generation date is invalid."
Assert-Condition ([string]$report.source.generatedAtSource -in @("argument", "source_date_epoch", "git_commit", "unknown")) "Documentation metrics generation date source is invalid."

Assert-Properties -Object $report.retention -Required @("policy", "artifactClass", "retentionDays", "publication") -Allowed @("policy", "artifactClass", "retentionDays", "publication") -Context "report.retention"
Assert-Condition ([string]$report.retention.policy -eq "approved-ci-evidence") "Documentation metrics retention policy is not approved-ci-evidence."
Assert-Condition ([string]$report.retention.artifactClass -eq "d6-metrics") "Documentation metrics artifact class is incorrect."
Assert-Condition ([int]$report.retention.retentionDays -eq 90) "Documentation metrics retention must be 90 days."
Assert-Condition ([string]$report.retention.publication -eq "protected-main-or-scheduled") "Documentation metrics publication boundary is invalid."

Assert-Properties -Object $report.protection -Required @("metadataOnly", "transformedProseIncluded", "secretsIncluded") -Allowed @("metadataOnly", "transformedProseIncluded", "secretsIncluded") -Context "report.protection"
Assert-Condition ([bool]$report.protection.metadataOnly) "Documentation metrics must be metadata-only."
Assert-Condition (-not [bool]$report.protection.transformedProseIncluded) "Documentation metrics cannot include transformed prose."
Assert-Condition (-not [bool]$report.protection.secretsIncluded) "Documentation metrics cannot include secrets."

Assert-Properties -Object $report.scope -Required @("domains", "domainMetrics") -Allowed @("domains", "domainMetrics") -Context "report.scope"
Assert-Condition ((@($report.scope.domains) -join ",") -eq "Automation,Connector") "Documentation metrics domains are not deterministic."
Assert-Condition ([string]$report.scope.domainMetrics -eq "separate-where-evidence-exists") "Documentation metrics domain policy is invalid."

$artifactIds = @{}
$artifacts = @(Get-Array $report.artifacts)
Assert-Condition ($artifacts.Count -gt 0) "Documentation metrics must retain input artifact records."
foreach ($artifact in $artifacts) {
    Assert-Properties -Object $artifact -Required @("id", "path", "status", "available", "sha256", "schemaVersion") -Allowed @("id", "path", "status", "available", "sha256", "schemaVersion") -Context "report artifact"
    $artifactId = [string]$artifact.id
    Assert-Condition ($artifactId -match "^[a-z0-9-]+$") "Documentation metrics artifact ID '$artifactId' is invalid."
    Assert-Condition (-not $artifactIds.ContainsKey($artifactId)) "Documentation metrics contains duplicate artifact '$artifactId'."
    $artifactIds[$artifactId] = $true
    Assert-Condition ([string]$artifact.status -in @("available", "not_available", "invalid")) "Documentation metrics artifact '$artifactId' has an invalid status."
    Assert-Condition (([bool]$artifact.available) -eq ([string]$artifact.status -eq "available")) "Documentation metrics artifact '$artifactId' availability disagrees with status."
    if ([string]$artifact.sha256 -ne "unknown") {
        Assert-Condition ([string]$artifact.sha256 -match "^[0-9a-f]{64}$") "Documentation metrics artifact '$artifactId' hash is invalid."
    }
    if ([string]$artifact.schemaVersion -ne "unknown") {
        Assert-Condition ([int]$artifact.schemaVersion -ge 1) "Documentation metrics artifact '$artifactId' schema version is invalid."
    }
    if ([string]$artifact.status -eq "available" -and ([string]$artifact.path -notmatch "^external/")) {
        $artifactPath = Join-Path $repositoryRoot ([string]$artifact.path).Replace("/", "\")
        Assert-Condition (Test-Path -LiteralPath $artifactPath -PathType Leaf) "Available metrics artifact '$artifactPath' does not exist."
        Assert-Condition ((Get-FileHash -LiteralPath $artifactPath -Algorithm SHA256).Hash.ToLowerInvariant() -eq [string]$artifact.sha256) "Metrics artifact '$artifactId' hash does not match the report."
    }
}

$metricNames = @($script:MetricCountKeys.Keys)
Assert-Properties -Object $report.metrics -Required $metricNames -Allowed $metricNames -Context "report.metrics"
foreach ($metricName in $metricNames) {
    Assert-Metric -Metric $report.metrics.$metricName -MetricName $metricName -RequireEmpty:($metricName -eq "sourceDocumentationDelta")
    foreach ($sourceArtifact in @(Get-Array $report.metrics.$metricName.sourceArtifacts)) {
        Assert-Condition ($artifactIds.ContainsKey([string]$sourceArtifact)) "Metric '$metricName' references unknown artifact '$sourceArtifact'."
    }
}

$gaps = @(Get-Array $report.gaps)
$gapCodes = @{}
foreach ($gap in $gaps) {
    Assert-Properties -Object $gap -Required @("code", "sourceArtifact", "count", "domain", "status") -Allowed @("code", "sourceArtifact", "count", "domain", "status") -Context "report gap"
    Assert-Condition ([string]$gap.code -match "^[a-z0-9-]+$") "Documentation metrics gap code is invalid."
    Assert-Condition (-not $gapCodes.ContainsKey([string]$gap.code)) "Documentation metrics contains duplicate gap '$($gap.code)'."
    $gapCodes[[string]$gap.code] = $true
    Assert-Condition ($artifactIds.ContainsKey([string]$gap.sourceArtifact)) "Documentation metrics gap references unknown artifact '$($gap.sourceArtifact)'."
    Assert-Condition ([int]$gap.count -gt 0) "Documentation metrics gap '$($gap.code)' must have a positive count."
    Assert-Condition ([string]$gap.domain -in @("Automation", "Connector", "unknown")) "Documentation metrics gap '$($gap.code)' has an invalid domain."
    Assert-Condition ([string]$gap.status -in @("unresolved", "not_available", "pre_existing")) "Documentation metrics gap '$($gap.code)' has an invalid status."
}

Assert-Properties -Object $report.summary -Required @("artifactCount", "availableArtifacts", "unavailableArtifacts", "invalidArtifacts", "metricCount", "availableMetrics", "gapRecords", "unresolvedGaps", "notAvailableGaps", "emptyDelta", "reportIdentity") -Allowed @("artifactCount", "availableArtifacts", "unavailableArtifacts", "invalidArtifacts", "metricCount", "availableMetrics", "gapRecords", "unresolvedGaps", "notAvailableGaps", "emptyDelta", "reportIdentity") -Context "report.summary"
foreach ($summaryKey in @("artifactCount", "availableArtifacts", "unavailableArtifacts", "invalidArtifacts", "metricCount", "availableMetrics", "gapRecords", "unresolvedGaps", "notAvailableGaps")) {
    Assert-Condition ([int]$report.summary.$summaryKey -ge 0) "Documentation metrics summary '$summaryKey' cannot be negative."
}
Assert-Condition ([int]$report.summary.artifactCount -eq $artifacts.Count) "Documentation metrics artifact count is incorrect."
Assert-Condition ([int]$report.summary.availableArtifacts -eq @($artifacts | Where-Object { $_.status -eq "available" }).Count) "Documentation metrics available artifact count is incorrect."
Assert-Condition ([int]$report.summary.unavailableArtifacts -eq @($artifacts | Where-Object { $_.status -eq "not_available" }).Count) "Documentation metrics unavailable artifact count is incorrect."
Assert-Condition ([int]$report.summary.invalidArtifacts -eq @($artifacts | Where-Object { $_.status -eq "invalid" }).Count) "Documentation metrics invalid artifact count is incorrect."
Assert-Condition ([int]$report.summary.metricCount -eq 10) "Documentation metrics metric count is incorrect."
Assert-Condition ([int]$report.summary.gapRecords -eq $gaps.Count) "Documentation metrics gap record count is incorrect."
Assert-Condition ([int]$report.summary.unresolvedGaps -eq @($gaps | Where-Object { $_.status -eq "unresolved" }).Count) "Documentation metrics unresolved gap count is incorrect."
Assert-Condition ([int]$report.summary.notAvailableGaps -eq @($gaps | Where-Object { $_.status -eq "not_available" }).Count) "Documentation metrics not-available gap count is incorrect."
Assert-Condition ([string]$report.summary.reportIdentity -eq [string]$report.identity.value) "Documentation metrics summary identity does not match report identity."

if ($report.summary.emptyDelta -is [string]) {
    Assert-Condition ([string]$report.summary.emptyDelta -in @("unknown", "not_available")) "Documentation metrics summary emptyDelta sentinel is invalid."
}
else {
    Assert-Condition ($report.summary.emptyDelta -is [bool]) "Documentation metrics summary emptyDelta must be boolean or unknown."
}

$expectedIdentity = Get-ObjectSha256 -Value (Get-IdentityMaterial -Report $report)
Assert-Condition ($expectedIdentity -eq [string]$report.identity.value) "Documentation metrics identity is not stable for the recorded evidence."
Assert-Condition ($reportJson -notmatch '(?s)```') "Documentation metrics report contains a code fence or transformed source content."
Assert-Condition ($reportJson -notmatch "(?i)(?:ghp_|github_pat_|sk-[A-Za-z0-9]{20,}|password\s*[:=]|secret\s*[:=]|token\s*[:=])") "Documentation metrics report contains a credential-shaped value."

Write-Output "Documentation metrics validation passed."
Write-Output "Metrics: $($report.summary.metricCount); available artifacts: $($report.summary.availableArtifacts); unresolved gaps: $($report.summary.unresolvedGaps); identity: $($report.identity.value)."
