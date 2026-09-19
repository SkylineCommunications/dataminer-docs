[CmdletBinding()]
param(
    [string]$RepositoryRoot = "",
    [string]$OutputPath = "",
    [string]$SchemaPath = "",
    [string]$ValidatorPath = "",
    [string]$BaselinePath = "",
    [string]$MetadataMigrationPath = "",
    [string]$MetadataValidationPath = "",
    [string]$ProvenancePath = "",
    [string]$ManifestPath = "",
    [Alias("DeploymentDeltaPath", "ManifestDeltaPath")]
    [string]$DeltaPath = "",
    [string]$SitemapPath = "",
    [string]$QualityPath = "",
    [string]$ExternalLinkPath = "",
    [string]$CSharpPath = "",
    [string]$XmlPath = "",
    [string]$SafetyPath = "",
    [string]$GovernancePath = "",
    [string]$CouplingPath = "",
    [string]$AgentSyncEventsPath = "",
    [string]$SourceRevision = "",
    [string]$GenerationDate = ""
)

Set-StrictMode -Version 2.0
$ErrorActionPreference = "Stop"

$script:GeneratorVersion = "1.0.0"
$script:SchemaVersion = 1
$script:SchemaName = "contributing/metadata/documentation-metrics-v1.schema.json"
$script:Repository = "SkylineCommunications/dataminer-docs"
$script:Domains = @("Automation", "Connector")
$script:Unknown = "unknown"
$script:NotAvailable = "not_available"
$script:ScriptRoot = $PSScriptRoot
if ([String]::IsNullOrWhiteSpace($script:ScriptRoot)) {
    $script:ScriptRoot = Split-Path -Parent $MyInvocation.MyCommand.Path
}
if ([String]::IsNullOrWhiteSpace($RepositoryRoot)) { $RepositoryRoot = Join-Path $script:ScriptRoot ".." }
if ([String]::IsNullOrWhiteSpace($OutputPath)) { $OutputPath = Join-Path $script:ScriptRoot "..\_artifacts\documentation-metrics.json" }
if ([String]::IsNullOrWhiteSpace($SchemaPath)) { $SchemaPath = Join-Path $script:ScriptRoot "..\contributing\metadata\documentation-metrics-v1.schema.json" }
if ([String]::IsNullOrWhiteSpace($ValidatorPath)) { $ValidatorPath = Join-Path $script:ScriptRoot "validate-documentation-metrics.ps1" }
if ([String]::IsNullOrWhiteSpace($BaselinePath)) { $BaselinePath = Join-Path $script:ScriptRoot "..\docs-corpus-baseline.json" }
if ([String]::IsNullOrWhiteSpace($MetadataMigrationPath)) { $MetadataMigrationPath = Join-Path $script:ScriptRoot "..\d2-2-metadata-migration-report.json" }
if ([String]::IsNullOrWhiteSpace($MetadataValidationPath)) { $MetadataValidationPath = Join-Path $script:ScriptRoot "..\d2-2-validation-report.json" }
if ([String]::IsNullOrWhiteSpace($ProvenancePath)) { $ProvenancePath = Join-Path $script:ScriptRoot "..\_artifacts\generated-metadata-provenance.json" }
if ([String]::IsNullOrWhiteSpace($ManifestPath)) { $ManifestPath = Join-Path $script:ScriptRoot "..\_artifacts\ai-content-manifest.json" }
if ([String]::IsNullOrWhiteSpace($DeltaPath)) { $DeltaPath = Join-Path $script:ScriptRoot "..\_artifacts\deployment-delta.json" }
if ([String]::IsNullOrWhiteSpace($SitemapPath)) { $SitemapPath = Join-Path $script:ScriptRoot "..\_artifacts\segmented-sitemap-report.json" }
if ([String]::IsNullOrWhiteSpace($QualityPath)) { $QualityPath = Join-Path $script:ScriptRoot "..\_artifacts\d4-1-quality-report.json" }
if ([String]::IsNullOrWhiteSpace($ExternalLinkPath)) { $ExternalLinkPath = Join-Path $script:ScriptRoot "..\_artifacts\external-link-report.json" }
if ([String]::IsNullOrWhiteSpace($CSharpPath)) { $CSharpPath = Join-Path $script:ScriptRoot "..\_artifacts\csharp-documentation-examples\csharp-documentation-examples.json" }
if ([String]::IsNullOrWhiteSpace($XmlPath)) { $XmlPath = Join-Path $script:ScriptRoot "..\_artifacts\xml-documentation-examples.json" }
if ([String]::IsNullOrWhiteSpace($SafetyPath)) { $SafetyPath = Join-Path $script:ScriptRoot "..\_artifacts\d4-4-documentation-safety-report.json" }
if ([String]::IsNullOrWhiteSpace($GovernancePath)) { $GovernancePath = Join-Path $script:ScriptRoot "..\_artifacts\documentation-governance.json" }
if ([String]::IsNullOrWhiteSpace($CouplingPath)) { $CouplingPath = Join-Path $script:ScriptRoot "..\_artifacts\documentation-coupling.json" }
if ([String]::IsNullOrWhiteSpace($AgentSyncEventsPath)) { $AgentSyncEventsPath = Join-Path $script:ScriptRoot "..\_artifacts\agent-sync-events.json" }

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
    param([Parameter(Mandatory = $true)][string]$Path)

    if ([IO.Path]::IsPathRooted($Path)) {
        return [IO.Path]::GetFullPath($Path)
    }

    return [IO.Path]::GetFullPath((Join-Path (Get-Location).Path $Path))
}

function ConvertTo-RepositoryPath {
    param(
        [Parameter(Mandatory = $true)][string]$Path,
        [Parameter(Mandatory = $true)][string]$Root
    )

    $fullPath = [IO.Path]::GetFullPath($Path)
    $rootPath = [IO.Path]::GetFullPath($Root).TrimEnd("\")
    $prefix = $rootPath + "\"
    if ($fullPath.StartsWith($prefix, [StringComparison]::OrdinalIgnoreCase)) {
        return $fullPath.Substring($prefix.Length).Replace("\", "/")
    }

    return "external/" + [IO.Path]::GetFileName($fullPath)
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

    if ($Object -is [System.Collections.IDictionary]) {
        if ($Object.Contains($Name)) {
            return $Object[$Name]
        }
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
        if ([String]::IsNullOrWhiteSpace([string]$Value)) {
            return @()
        }
        return @([string]$Value)
    }

    return @($Value)
}

function Get-StringValue {
    param(
        [AllowNull()]$Object,
        [Parameter(Mandatory = $true)][string]$Name,
        [string]$Default = ""
    )

    $value = Get-Property -Object $Object -Name $Name
    if ($null -eq $value) {
        return $Default
    }

    $text = [string]$value
    if ([String]::IsNullOrWhiteSpace($text)) {
        return $Default
    }

    return $text
}

function Get-CountValue {
    param(
        [AllowNull()]$Object,
        [Parameter(Mandatory = $true)][string]$Name,
        [string]$Missing = "unknown"
    )

    $value = Get-Property -Object $Object -Name $Name
    if ($null -eq $value -or [String]::IsNullOrWhiteSpace([string]$value)) {
        return $Missing
    }

    $number = 0
    if ([int]::TryParse([string]$value, [Globalization.NumberStyles]::Integer, [Globalization.CultureInfo]::InvariantCulture, [ref]$number) -and $number -ge 0) {
        return $number
    }

    return "unknown"
}

function Get-FirstCount {
    param(
        [AllowNull()][object[]]$Objects,
        [Parameter(Mandatory = $true)][string]$Name,
        [string]$Missing = "not_available"
    )

    foreach ($object in @(Get-Array $Objects)) {
        $value = Get-CountValue -Object $object -Name $Name -Missing "unknown"
        if ($value -is [int]) {
            return $value
        }
    }

    if (@(Get-Array $Objects).Count -gt 0) {
        return "unknown"
    }

    return $Missing
}

function Get-SumCounts {
    param(
        [AllowNull()][object[]]$Objects,
        [Parameter(Mandatory = $true)][string]$Name,
        [string]$Missing = "not_available"
    )

    $items = @(Get-Array $Objects)
    if ($items.Count -eq 0) {
        return $Missing
    }

    $sum = 0
    $known = 0
    foreach ($object in $items) {
        $value = Get-CountValue -Object $object -Name $Name -Missing "unknown"
        if ($value -is [int]) {
            $sum += $value
            $known++
        }
    }
    if ($known -eq $items.Count) {
        return $sum
    }
    return "unknown"
}

function Get-FileSha256 {
    param([Parameter(Mandatory = $true)][string]$Path)

    return (Get-FileHash -LiteralPath $Path -Algorithm SHA256).Hash.ToLowerInvariant()
}

function Get-GitValue {
    param(
        [Parameter(Mandatory = $true)][string]$Root,
        [Parameter(Mandatory = $true)][string[]]$Arguments
    )

    try {
        $result = & git -C $Root @Arguments 2>$null
        if ($LASTEXITCODE -eq 0) {
            $value = (($result -join "`n").Trim())
            if ($value -ne "") {
                return $value
            }
        }
    }
    catch {
        return ""
    }

    return ""
}

function Get-SourceRevisionInfo {
    param(
        [Parameter(Mandatory = $true)][string]$Root,
        [AllowEmptyString()][string]$RequestedRevision
    )

    $revision = $RequestedRevision.Trim().ToLowerInvariant()
    $source = "argument"
    if ([String]::IsNullOrWhiteSpace($revision)) {
        $revision = (Get-GitValue -Root $Root -Arguments @("rev-parse", "HEAD")).ToLowerInvariant()
        $source = "git"
    }

    if ([String]::IsNullOrWhiteSpace($revision)) {
        return [ordered]@{
            revision = "unknown"
            revisionSource = "unknown"
        }
    }

    Assert-Condition ($revision -match "^[0-9a-f]{40}$") "Source revision '$revision' is not a full 40-character commit."
    return [ordered]@{
        revision = $revision
        revisionSource = $source
    }
}

function Get-GenerationInfo {
    param(
        [Parameter(Mandatory = $true)][string]$Root,
        [AllowEmptyString()][string]$RequestedDate
    )

    if (-not [String]::IsNullOrWhiteSpace($RequestedDate)) {
        $parsed = [datetime]::MinValue
        if ([datetime]::TryParseExact($RequestedDate.Trim(), "yyyy-MM-dd", [Globalization.CultureInfo]::InvariantCulture, [Globalization.DateTimeStyles]::None, [ref]$parsed)) {
            return [ordered]@{
                generatedAt = $parsed.ToString("yyyy-MM-dd")
                generatedAtSource = "argument"
            }
        }
        throw "Generation date '$RequestedDate' must use yyyy-MM-dd."
    }

    $epoch = [Environment]::GetEnvironmentVariable("SOURCE_DATE_EPOCH")
    if (-not [String]::IsNullOrWhiteSpace($epoch)) {
        $seconds = 0L
        if ([long]::TryParse($epoch, [Globalization.NumberStyles]::Integer, [Globalization.CultureInfo]::InvariantCulture, [ref]$seconds)) {
            try {
                return [ordered]@{
                    generatedAt = [DateTimeOffset]::FromUnixTimeSeconds($seconds).UtcDateTime.ToString("yyyy-MM-dd")
                    generatedAtSource = "source_date_epoch"
                }
            }
            catch {
            }
        }
    }

    $commitDate = Get-GitValue -Root $Root -Arguments @("show", "-s", "--format=%cI", "HEAD")
    if (-not [String]::IsNullOrWhiteSpace($commitDate)) {
        try {
            return [ordered]@{
                generatedAt = ([DateTimeOffset]::Parse($commitDate, [Globalization.CultureInfo]::InvariantCulture).Date.ToString("yyyy-MM-dd"))
                generatedAtSource = "git_commit"
            }
        }
        catch {
        }
    }

    return [ordered]@{
        generatedAt = "unknown"
        generatedAtSource = "unknown"
    }
}

function Get-Domain {
    param([AllowEmptyString()][string]$Path)

    $normalized = $Path.Replace("\", "/")
    if ($normalized -match "(?i)(^|/)automation(/|_|-)" -or $normalized -match "(?i)(^|/)automation[^/]*\.") {
        return "Automation"
    }
    if ($normalized -match "(?i)(^|/)(connector|protocol)(/|_|-)" -or $normalized -match "(?i)(^|/)(connector|protocol)[^/]*\.") {
        return "Connector"
    }

    return "unknown"
}

function Normalize-Domain {
    param([AllowEmptyString()][string]$Value)

    if ($Value -in @("Automation", "Connector")) {
        return $Value
    }
    if ($Value -ieq "Protocol") {
        return "Connector"
    }
    return Get-Domain $Value
}

function Get-StatusForArtifacts {
    param([AllowEmptyCollection()][object[]]$Artifacts)

    $items = @(Get-Array $Artifacts)
    $available = @($items | Where-Object { $_.status -eq "available" }).Count
    $invalid = @($items | Where-Object { $_.status -eq "invalid" }).Count
    if ($items.Count -eq 0 -or $available -eq 0) {
        return "not_available"
    }
    if ($available -lt $items.Count -or $invalid -gt 0) {
        return "partial"
    }
    return "available"
}

function Read-InputArtifact {
    param(
        [Parameter(Mandatory = $true)][string]$Id,
        [Parameter(Mandatory = $true)][string]$Path,
        [Parameter(Mandatory = $true)][string]$Root
    )

    $fullPath = ConvertTo-FullPath $Path
    $record = [ordered]@{
        id = $Id
        path = ConvertTo-RepositoryPath -Path $fullPath -Root $Root
        status = "not_available"
        available = $false
        sha256 = "unknown"
        schemaVersion = "unknown"
        data = $null
    }

    if (-not (Test-Path -LiteralPath $fullPath -PathType Leaf)) {
        return [PSCustomObject]$record
    }

    try {
        $json = Get-Content -LiteralPath $fullPath -Raw
        $record.data = $json | ConvertFrom-Json
        $record.status = "available"
        $record.available = $true
        $record.sha256 = Get-FileSha256 -Path $fullPath
        $schemaVersion = Get-Property -Object $record.data -Name "schemaVersion"
        if ($null -ne $schemaVersion -and -not [String]::IsNullOrWhiteSpace([string]$schemaVersion)) {
            $versionNumber = 0
            if ([int]::TryParse([string]$schemaVersion, [Globalization.NumberStyles]::Integer, [Globalization.CultureInfo]::InvariantCulture, [ref]$versionNumber) -and $versionNumber -ge 1) {
                $record.schemaVersion = $versionNumber
            }
        }
    }
    catch {
        $record.status = "invalid"
        $record.available = $false
        $record.sha256 = Get-FileSha256 -Path $fullPath
    }

    return [PSCustomObject]$record
}

function New-CountMap {
    param([Parameter(Mandatory = $true)][string[]]$Keys)

    $counts = [ordered]@{}
    foreach ($key in $Keys) {
        $counts[$key] = "not_available"
    }
    return $counts
}

function New-DomainMetric {
    param(
        [Parameter(Mandatory = $true)][string]$Domain,
        [Parameter(Mandatory = $true)][string]$Status,
        [Parameter(Mandatory = $true)]$Counts
    )

    return [ordered]@{
        domain = $Domain
        status = $Status
        counts = $Counts
    }
}

function New-UnknownDomains {
    param([Parameter(Mandatory = $true)][string[]]$Keys)

    $domains = New-Object System.Collections.Generic.List[object]
    foreach ($domain in $script:Domains) {
        [void]$domains.Add((New-DomainMetric -Domain $domain -Status "not_available" -Counts (New-CountMap -Keys $Keys)))
    }
    return @($domains.ToArray())
}

function Get-KnownPercentage {
    param(
        [AllowNull()]$Numerator,
        [AllowNull()]$Denominator
    )

    if ($Numerator -is [int] -and $Denominator -is [int] -and $Denominator -gt 0) {
        return [math]::Round((100.0 * $Numerator / $Denominator), 2)
    }
    return "unknown"
}

function Get-ReportGaps {
    param([AllowNull()]$Data)

    return @(Get-Array (Get-Property -Object $Data -Name "gaps"))
}

function Get-MetadataCoverageMetric {
    param(
        [Parameter(Mandatory = $true)]$Migration,
        [Parameter(Mandatory = $true)]$Baseline,
        [Parameter(Mandatory = $true)]$Governance
    )

    $sources = @($Migration, $Baseline | Where-Object { $_.status -eq "available" })
    $migrationData = if ($Migration.status -eq "available") { $Migration.data } else { $null }
    $baselineData = if ($Baseline.status -eq "available") { $Baseline.data } else { $null }
    $coverage = Get-Property -Object $migrationData -Name "coverage"
    $baselineMetrics = Get-Property -Object (Get-Property -Object (Get-Property -Object $baselineData -Name "source") -Name "metrics") -Name "metrics"
    if ($null -eq $baselineMetrics) {
        $baselineMetrics = Get-Property -Object (Get-Property -Object $baselineData -Name "source") -Name "metrics"
    }

    $total = Get-FirstCount -Objects @($coverage, $baselineMetrics) -Name "totalPages"
    $metadataVersion1 = Get-FirstCount -Objects @($coverage) -Name "metadataVersion1"
    if ($metadataVersion1 -eq "not_available") {
        $metadataVersion1 = Get-FirstCount -Objects @($baselineMetrics) -Name "pagesWithUid" -Missing "not_available"
    }
    $unknownVersions = Get-FirstCount -Objects @($coverage) -Name "unknownVersions"
    $unknownAuthorities = Get-FirstCount -Objects @($coverage) -Name "unknownAuthorities"
    $pendingReview = Get-FirstCount -Objects @($coverage) -Name "pendingReview"
    $ownerGaps = Get-FirstCount -Objects @(
        (Get-Property -Object (Get-Property -Object $Governance.data -Name "summary") -Name "ownerGaps")
    ) -Name "value" -Missing "not_available"
    if ($Governance.status -eq "available") {
        $ownerGaps = Get-CountValue -Object (Get-Property -Object $Governance.data -Name "summary") -Name "ownerGaps" -Missing "unknown"
    }

    $counts = [ordered]@{
        totalPages = $total
        metadataVersion1 = $metadataVersion1
        coveragePercent = Get-KnownPercentage -Numerator $metadataVersion1 -Denominator $total
        unknownVersions = $unknownVersions
        unknownAuthorities = $unknownAuthorities
        unknownOwners = $ownerGaps
        pendingReview = $pendingReview
    }

    $domainRecords = New-Object System.Collections.Generic.List[object]
    $scopes = @(Get-Array (Get-Property -Object $migrationData -Name "scopes"))
    foreach ($domain in $script:Domains) {
        $domainCount = "not_available"
        if ($null -ne $coverage) {
            $domainCount = Get-CountValue -Object (Get-Property -Object $coverage -Name "domains") -Name $domain -Missing "unknown"
        }
        if ($domainCount -eq "not_available" -and $null -ne $baselineMetrics) {
            $domainCount = Get-CountValue -Object (Get-Property -Object (Get-Property -Object $baselineMetrics -Name "byDomain") -Name $domain) -Name "value" -Missing "unknown"
        }
        $domainScopes = @($scopes | Where-Object { [string]$_.domain -eq $domain })
        $domainMetadata = Get-SumCounts -Objects $domainScopes -Name "currentCount" -Missing "not_available"
        if ($domainMetadata -eq "not_available" -and $domainCount -is [int]) {
            $domainMetadata = $domainCount
        }
        $domainCounts = [ordered]@{
            pages = $domainCount
            metadataVersion1 = $domainMetadata
            unknownVersions = if ($domainCount -is [int] -and $metadataVersion1 -is [int]) { "unknown" } else { "not_available" }
            unknownAuthorities = "unknown"
            pendingReview = "unknown"
        }
        $domainStatus = if ($domainCount -is [int]) { "available" } else { "not_available" }
        [void]$domainRecords.Add((New-DomainMetric -Domain $domain -Status $domainStatus -Counts $domainCounts))
    }

    return [ordered]@{
        status = Get-StatusForArtifacts -Artifacts $sources
        sourceArtifacts = @($sources | Where-Object { $_.status -ne "not_available" } | ForEach-Object { [string]$_.id } | Sort-Object -Unique)
        counts = $counts
        byDomain = @($domainRecords.ToArray())
    }
}

function Get-IdentityAndLinkMetric {
    param(
        [Parameter(Mandatory = $true)]$Baseline,
        [Parameter(Mandatory = $true)]$Manifest,
        [Parameter(Mandatory = $true)]$Sitemap,
        [Parameter(Mandatory = $true)]$ExternalLinks,
        [Parameter(Mandatory = $true)]$MetadataValidation
    )

    $baselineData = if ($Baseline.status -eq "available") { $Baseline.data } else { $null }
    $source = Get-Property -Object $baselineData -Name "source"
    $sourceMetrics = Get-Property -Object $source -Name "metrics"
    $uid = Get-Property -Object $source -Name "uid"
    $links = Get-Property -Object $source -Name "links"
    $generated = Get-Property -Object $baselineData -Name "generated"
    $generatedSitemap = Get-Property -Object $generated -Name "sitemap"
    $generatedXref = Get-Property -Object $generated -Name "xrefmap"
    $manifestData = if ($Manifest.status -eq "available") { $Manifest.data } else { $null }
    $manifestCounts = Get-Property -Object $manifestData -Name "counts"
    $sitemapData = if ($Sitemap.status -eq "available") { $Sitemap.data } else { $null }
    $sitemapCounts = Get-Property -Object $sitemapData -Name "counts"
    $externalData = if ($ExternalLinks.status -eq "available") { $ExternalLinks.data } else { $null }
    $externalSummary = Get-Property -Object $externalData -Name "summary"
    $validationData = if ($MetadataValidation.status -eq "available") { $MetadataValidation.data } else { $null }
    $validationChecks = @(Get-Array (Get-Property -Object $validationData -Name "checks"))
    $localLinkCheck = @($validationChecks | Where-Object { [string]$_.name -eq "local-link-check" } | Select-Object -First 1)
    $manifestUrls = Get-FirstCount -Objects @($manifestCounts) -Name "current" -Missing "not_available"
    if ($manifestUrls -eq "not_available") {
        $manifestUrls = Get-FirstCount -Objects @($generatedSitemap) -Name "urlCount" -Missing "not_available"
    }
    $sitemapUrls = Get-FirstCount -Objects @($sitemapCounts) -Name "urls" -Missing "not_available"
    if ($sitemapUrls -eq "not_available") {
        $sitemapUrls = Get-FirstCount -Objects @($generatedSitemap) -Name "urlCount" -Missing "not_available"
    }

    $counts = [ordered]@{
        pages = Get-FirstCount -Objects @($sourceMetrics) -Name "pages"
        pagesWithUid = Get-FirstCount -Objects @($sourceMetrics, $uid) -Name "pagesWithUid"
        pagesWithoutUid = Get-FirstCount -Objects @($sourceMetrics, $uid) -Name "pagesWithoutUid"
        duplicateUid = Get-FirstCount -Objects @($uid) -Name "duplicateUidCount"
        urls = $manifestUrls
        sitemapUrls = $sitemapUrls
        duplicateUrls = Get-FirstCount -Objects @($generatedSitemap) -Name "duplicateUrlCount"
        xrefReferences = Get-FirstCount -Objects @($links, $generatedXref) -Name "xrefCount" -Missing "not_available"
        duplicateXref = Get-FirstCount -Objects @($generatedXref) -Name "duplicateUidCount"
        referencesWithoutHref = Get-FirstCount -Objects @($generatedXref) -Name "referencesWithoutHref"
        localLinks = Get-FirstCount -Objects @($links) -Name "localLinkCount"
        externalLinks = Get-FirstCount -Objects @($links, $externalSummary) -Name "externalLinkCount" -Missing "not_available"
        externalLinkFailures = Get-FirstCount -Objects @($externalSummary) -Name "failed"
        localLinkWarnings = Get-FirstCount -Objects @($localLinkCheck) -Name "warnings"
    }

    $domainRecords = New-Object System.Collections.Generic.List[object]
    foreach ($domain in $script:Domains) {
        $domainData = Get-Property -Object $source -Name $domain.ToLowerInvariant()
        $domainCounts = [ordered]@{
            pages = Get-CountValue -Object $domainData -Name "pages" -Missing "not_available"
            pagesWithUid = Get-CountValue -Object $domainData -Name "pagesWithUid" -Missing "not_available"
            pagesWithoutUid = Get-CountValue -Object $domainData -Name "pagesWithoutUid" -Missing "not_available"
            links = Get-CountValue -Object $domainData -Name "linkCount" -Missing "not_available"
            xrefs = Get-CountValue -Object $domainData -Name "xrefCount" -Missing "not_available"
        }
        $domainStatus = if ($domainCounts.pages -is [int]) { "available" } else { "not_available" }
        [void]$domainRecords.Add((New-DomainMetric -Domain $domain -Status $domainStatus -Counts $domainCounts))
    }

    return [ordered]@{
        status = Get-StatusForArtifacts -Artifacts @($Baseline, $Manifest, $Sitemap, $ExternalLinks, $MetadataValidation)
        sourceArtifacts = @($Baseline, $Manifest, $Sitemap, $ExternalLinks, $MetadataValidation | Where-Object { $_.status -ne "not_available" } | ForEach-Object { [string]$_.id } | Sort-Object -Unique)
        counts = $counts
        byDomain = @($domainRecords.ToArray())
    }
}

function Get-SnippetMetric {
    param(
        [Parameter(Mandatory = $true)]$CSharp,
        [Parameter(Mandatory = $true)]$Xml
    )

    $csharpData = if ($CSharp.status -eq "available") { $CSharp.data } else { $null }
    $xmlData = if ($Xml.status -eq "available") { $Xml.data } else { $null }
    $csharpCounts = Get-Property -Object $csharpData -Name "counts"
    $xmlCounts = Get-Property -Object $xmlData -Name "counts"
    $counts = [ordered]@{
        csharpExamples = Get-FirstCount -Objects @($csharpCounts) -Name "csharpBlockCount"
        csharpCompiled = Get-FirstCount -Objects @($csharpCounts) -Name "compiled"
        csharpFailed = Get-FirstCount -Objects @($csharpCounts) -Name "failed"
        csharpNotAttempted = Get-FirstCount -Objects @($csharpCounts) -Name "notAttempted"
        xmlExamples = Get-FirstCount -Objects @($xmlCounts) -Name "examples"
        xmlPassed = Get-FirstCount -Objects @($xmlCounts) -Name "passed"
        xmlExpectedFailures = Get-FirstCount -Objects @($xmlCounts) -Name "expectedFailures"
        xmlFailed = Get-FirstCount -Objects @($xmlCounts) -Name "failed"
        xmlUnverified = Get-FirstCount -Objects @($xmlCounts) -Name "unverified"
        xmlGaps = Get-FirstCount -Objects @($xmlCounts) -Name "gaps"
        compileSuccess = Get-FirstCount -Objects @($csharpCounts) -Name "compiled"
        compileFailure = Get-FirstCount -Objects @($csharpCounts) -Name "failed"
        schemaSuccess = Get-FirstCount -Objects @($xmlCounts) -Name "passed"
        schemaFailure = Get-FirstCount -Objects @($xmlCounts) -Name "failed"
    }

    $domainCounts = @{}
    foreach ($domain in $script:Domains) {
        $domainCounts[$domain] = [ordered]@{
            csharpExamples = 0
            csharpCompiled = 0
            csharpFailed = 0
            csharpNotAttempted = 0
            xmlExamples = 0
            xmlPassed = 0
            xmlFailed = 0
            schemaSuccess = 0
            schemaFailure = 0
        }
    }
    foreach ($example in @(Get-Array (Get-Property -Object $csharpData -Name "examples"))) {
        $domain = Normalize-Domain (Get-StringValue -Object $example -Name "domain" -Default (Get-StringValue -Object (Get-Property -Object $example -Name "source") -Name "path"))
        if (-not $domainCounts.ContainsKey($domain)) {
            continue
        }
        $domainCounts[$domain].csharpExamples = [int]$domainCounts[$domain].csharpExamples + 1
        $resultStatus = Get-StringValue -Object (Get-Property -Object $example -Name "result") -Name "status"
        if ($resultStatus -eq "compiled") {
            $domainCounts[$domain].csharpCompiled = [int]$domainCounts[$domain].csharpCompiled + 1
        }
        elseif ($resultStatus -eq "failed") {
            $domainCounts[$domain].csharpFailed = [int]$domainCounts[$domain].csharpFailed + 1
        }
        elseif ($resultStatus -eq "not-attempted") {
            $domainCounts[$domain].csharpNotAttempted = [int]$domainCounts[$domain].csharpNotAttempted + 1
        }
    }
    foreach ($example in @(Get-Array (Get-Property -Object $xmlData -Name "examples"))) {
        $domain = Normalize-Domain (Get-StringValue -Object $example -Name "domain" -Default (Get-StringValue -Object (Get-Property -Object $example -Name "source") -Name "path"))
        if (-not $domainCounts.ContainsKey($domain)) {
            continue
        }
        $domainCounts[$domain].xmlExamples = [int]$domainCounts[$domain].xmlExamples + 1
        $resultStatus = Get-StringValue -Object (Get-Property -Object $example -Name "result") -Name "status"
        if ($resultStatus -eq "passed") {
            $domainCounts[$domain].xmlPassed = [int]$domainCounts[$domain].xmlPassed + 1
            $domainCounts[$domain].schemaSuccess = [int]$domainCounts[$domain].schemaSuccess + 1
        }
        elseif ($resultStatus -eq "failed") {
            $domainCounts[$domain].xmlFailed = [int]$domainCounts[$domain].xmlFailed + 1
            $domainCounts[$domain].schemaFailure = [int]$domainCounts[$domain].schemaFailure + 1
        }
    }

    $domainRecords = New-Object System.Collections.Generic.List[object]
    foreach ($domain in $script:Domains) {
        $domainValue = $domainCounts[$domain]
        $known = @($domainValue.Values | Where-Object { $_ -is [int] }).Count -gt 0
        $domainStatus = if ($known) { "available" } else { "not_available" }
        [void]$domainRecords.Add((New-DomainMetric -Domain $domain -Status $domainStatus -Counts $domainValue))
    }

    return [ordered]@{
        status = Get-StatusForArtifacts -Artifacts @($CSharp, $Xml)
        sourceArtifacts = @($CSharp, $Xml | Where-Object { $_.status -ne "not_available" } | ForEach-Object { [string]$_.id } | Sort-Object -Unique)
        counts = $counts
        byDomain = @($domainRecords.ToArray())
    }
}

function Get-QualityMetric {
    param(
        [Parameter(Mandatory = $true)]$Quality,
        [Parameter(Mandatory = $true)]$ExternalLinks,
        [Parameter(Mandatory = $true)]$MetadataValidation
    )

    $qualityData = if ($Quality.status -eq "available") { $Quality.data } else { $null }
    $qualitySummary = Get-Property -Object $qualityData -Name "summary"
    $externalData = if ($ExternalLinks.status -eq "available") { $ExternalLinks.data } else { $null }
    $externalSummary = Get-Property -Object $externalData -Name "summary"
    $validationData = if ($MetadataValidation.status -eq "available") { $MetadataValidation.data } else { $null }
    $checks = @(Get-Array (Get-Property -Object $validationData -Name "checks"))
    $warningCount = 0
    foreach ($check in $checks) {
        if ([string]$check.status -eq "passed_with_preexisting_warnings") {
            $value = Get-CountValue -Object $check -Name "warnings" -Missing "unknown"
            if ($value -is [int]) {
                $warningCount += $value
            }
        }
    }
    $counts = [ordered]@{
        findings = Get-CountValue -Object $qualitySummary -Name "findings" -Missing "not_available"
        newFindings = Get-CountValue -Object $qualitySummary -Name "newFindings" -Missing "not_available"
        legacyExceptions = Get-CountValue -Object $qualitySummary -Name "legacyExceptions" -Missing "not_available"
        markdownFiles = Get-CountValue -Object $qualitySummary -Name "changedMarkdownFiles" -Missing "not_available"
        externalLinks = Get-FirstCount -Objects @($externalSummary) -Name "passed" -Missing "not_available"
        externalLinkFailures = Get-FirstCount -Objects @($externalSummary) -Name "failed"
        preExistingWarnings = if ($MetadataValidation.status -eq "available") { $warningCount } else { "not_available" }
    }

    $domainRecords = New-Object System.Collections.Generic.List[object]
    foreach ($domain in $script:Domains) {
        $domainFindings = @(
            Get-Array (Get-Property -Object $qualityData -Name "findings") |
                Where-Object { (Normalize-Domain ([string]$_.workstream)) -eq $domain -or (Normalize-Domain ([string]$_.path)) -eq $domain }
        )
        $domainCounts = [ordered]@{
            findings = $domainFindings.Count
            newFindings = @($domainFindings | Where-Object { [string]$_.status -eq "new" }).Count
            legacyExceptions = @($domainFindings | Where-Object { [string]$_.status -eq "legacy_exception" }).Count
        }
        $domainStatus = if ($Quality.status -eq "available") { "available" } else { "not_available" }
        [void]$domainRecords.Add((New-DomainMetric -Domain $domain -Status $domainStatus -Counts $domainCounts))
    }

    return [ordered]@{
        status = Get-StatusForArtifacts -Artifacts @($Quality, $ExternalLinks, $MetadataValidation)
        sourceArtifacts = @($Quality, $ExternalLinks, $MetadataValidation | Where-Object { $_.status -ne "not_available" } | ForEach-Object { [string]$_.id } | Sort-Object -Unique)
        counts = $counts
        byDomain = @($domainRecords.ToArray())
    }
}

function Get-SafetyMetric {
    param(
        [Parameter(Mandatory = $true)]$Safety,
        [Parameter(Mandatory = $true)]$Quality
    )

    $safetyData = if ($Safety.status -eq "available") { $Safety.data } else { $null }
    $safetySummary = Get-Property -Object $safetyData -Name "summary"
    $findings = @(Get-Array (Get-Property -Object $safetyData -Name "findings"))
    $gaps = @(Get-Array (Get-Property -Object $safetyData -Name "gaps"))
    $contradictions = @($findings | Where-Object {
            [string]$_.category -eq "normative_conflict" -or
            [string]$_.ruleId -match "(?i)contradiction|conflict"
        }).Count
    $counts = [ordered]@{
        findings = Get-CountValue -Object $safetySummary -Name "findings" -Missing "not_available"
        newFindings = Get-CountValue -Object $safetySummary -Name "newFindings" -Missing "not_available"
        legacyExceptions = Get-CountValue -Object $safetySummary -Name "legacyExceptions" -Missing "not_available"
        allowlisted = Get-CountValue -Object $safetySummary -Name "allowlisted" -Missing "not_available"
        gaps = Get-CountValue -Object $safetySummary -Name "gaps" -Missing "not_available"
        newGaps = Get-CountValue -Object $safetySummary -Name "newGaps" -Missing "not_available"
        preExistingGaps = Get-CountValue -Object $safetySummary -Name "preExistingGaps" -Missing "not_available"
        contradictions = if ($Safety.status -eq "available") { $contradictions } else { "not_available" }
    }
    $domainRecords = New-Object System.Collections.Generic.List[object]
    foreach ($domain in $script:Domains) {
        $domainFindings = @($findings | Where-Object { (Normalize-Domain ([string]$_.path)) -eq $domain })
        $domainCounts = [ordered]@{
            findings = $domainFindings.Count
            newFindings = @($domainFindings | Where-Object { [string]$_.status -eq "new" }).Count
            legacyExceptions = @($domainFindings | Where-Object { [string]$_.status -eq "legacy_exception" }).Count
            contradictions = @($domainFindings | Where-Object { [string]$_.category -eq "normative_conflict" }).Count
        }
        $domainStatus = if ($Safety.status -eq "available") { "available" } else { "not_available" }
        [void]$domainRecords.Add((New-DomainMetric -Domain $domain -Status $domainStatus -Counts $domainCounts))
    }

    return [ordered]@{
        status = if ($Safety.status -eq "available") { "available" } else { "not_available" }
        sourceArtifacts = @($Safety, $Quality | Where-Object { $_.status -ne "not_available" } | ForEach-Object { [string]$_.id } | Sort-Object -Unique)
        counts = $counts
        byDomain = @($domainRecords.ToArray())
    }
}

function Get-ProvenanceMetric {
    param([Parameter(Mandatory = $true)]$Provenance)

    $data = if ($Provenance.status -eq "available") { $Provenance.data } else { $null }
    $outputs = Get-Property -Object $data -Name "outputs"
    $counts = [ordered]@{
        apiOutputs = @(Get-Array (Get-Property -Object $outputs -Name "api")).Count
        schemaOutputs = @(Get-Array (Get-Property -Object $outputs -Name "schema")).Count
        sourceArtifacts = @(Get-Array (Get-Property -Object $data -Name "artifacts")).Count
        gaps = @(Get-Array (Get-Property -Object $data -Name "gaps")).Count
    }
    if ($Provenance.status -ne "available") {
        foreach ($key in @($counts.Keys)) {
            $counts[$key] = "not_available"
        }
    }
    $domainRecords = New-Object System.Collections.Generic.List[object]
    $domainStatus = if ($Provenance.status -eq "available") { "available" } else { "not_available" }
    foreach ($domain in $script:Domains) {
        $domainRecords.Add((New-DomainMetric -Domain $domain -Status $domainStatus -Counts ([ordered]@{
                    apiOutputs = "unknown"
                    schemaOutputs = "unknown"
                    sourceArtifacts = "unknown"
                    gaps = "unknown"
                }))) | Out-Null
    }

    return [ordered]@{
        status = if ($Provenance.status -eq "available") { "available" } else { "not_available" }
        sourceArtifacts = @($Provenance | Where-Object { $_.status -ne "not_available" } | ForEach-Object { [string]$_.id })
        counts = $counts
        byDomain = @($domainRecords.ToArray())
    }
}

function Get-GovernanceMetric {
    param([Parameter(Mandatory = $true)]$Governance)

    $data = if ($Governance.status -eq "available") { $Governance.data } else { $null }
    $summary = Get-Property -Object $data -Name "summary"
    $counts = [ordered]@{
        filesScanned = Get-CountValue -Object $summary -Name "filesScanned" -Missing "not_available"
        version1Pages = Get-CountValue -Object $summary -Name "version1Pages" -Missing "not_available"
        metadataVersionGaps = Get-CountValue -Object $summary -Name "metadataVersionGaps" -Missing "not_available"
        ownerGaps = Get-CountValue -Object $summary -Name "ownerGaps" -Missing "not_available"
        authorityGaps = Get-CountValue -Object $summary -Name "authorityGaps" -Missing "not_available"
        reviewGaps = Get-CountValue -Object $summary -Name "reviewGaps" -Missing "not_available"
        pendingReviews = Get-CountValue -Object $summary -Name "pendingReviews" -Missing "not_available"
        dueReviews = Get-CountValue -Object $summary -Name "dueReviews" -Missing "not_available"
        staleReviews = Get-CountValue -Object $summary -Name "staleContent" -Missing "not_available"
        unmappedVersion1Pages = Get-CountValue -Object $summary -Name "unmappedVersion1Pages" -Missing "not_available"
        configurationEvidenceGaps = Get-CountValue -Object $summary -Name "configurationEvidenceGaps" -Missing "not_available"
    }
    $findings = @(Get-Array (Get-Property -Object $data -Name "findings"))
    $domainRecords = New-Object System.Collections.Generic.List[object]
    foreach ($domain in $script:Domains) {
        $workstream = $domain.ToLowerInvariant()
        $domainFindings = @($findings | Where-Object { [string]$_.workstream -eq $workstream -or (Normalize-Domain ([string]$_.path)) -eq $domain })
        $domainCounts = [ordered]@{
            findings = $domainFindings.Count
            staleReviews = @($domainFindings | Where-Object { [string]$_.code -eq "stale_content" }).Count
            pendingReviews = @($domainFindings | Where-Object { [string]$_.code -eq "review_pending" }).Count
            ownerGaps = @($domainFindings | Where-Object { [string]$_.code -eq "owner_gap" }).Count
            authorityGaps = @($domainFindings | Where-Object { [string]$_.code -eq "authority_gap" }).Count
        }
        $domainStatus = if ($Governance.status -eq "available") { "available" } else { "not_available" }
        [void]$domainRecords.Add((New-DomainMetric -Domain $domain -Status $domainStatus -Counts $domainCounts))
    }

    return [ordered]@{
        status = if ($Governance.status -eq "available") { "available" } else { "not_available" }
        sourceArtifacts = @($Governance | Where-Object { $_.status -ne "not_available" } | ForEach-Object { [string]$_.id })
        counts = $counts
        byDomain = @($domainRecords.ToArray())
    }
}

function Get-CouplingMetric {
    param([Parameter(Mandatory = $true)]$Coupling)

    $data = if ($Coupling.status -eq "available") { $Coupling.data } else { $null }
    $summary = Get-Property -Object $data -Name "summary"
    $gate = Get-Property -Object $data -Name "documentationReleaseGate"
    $acknowledgement = Get-StringValue -Object $gate -Name "acknowledgement" -Default "not_applicable"
    $gateStatus = Get-StringValue -Object $gate -Name "status" -Default "not_applicable"
    $unresolved = @(Get-Array (Get-Property -Object $data -Name "unresolved"))
    $counts = [ordered]@{
        matchedEntries = Get-CountValue -Object $summary -Name "matchedEntries" -Missing "not_available"
        targetedChecks = Get-CountValue -Object $summary -Name "targetedChecks" -Missing "not_available"
        gaps = Get-CountValue -Object $summary -Name "gaps" -Missing "not_available"
        unresolved = if ($Coupling.status -eq "available") { $unresolved.Count } else { "not_available" }
        acknowledged = if ($Coupling.status -eq "available" -and $acknowledgement -eq "acknowledged") { 1 } else { 0 }
        notAcknowledged = if ($Coupling.status -eq "available" -and $acknowledgement -eq "not_acknowledged") { 1 } else { 0 }
        unknownAcknowledgements = if ($Coupling.status -eq "available" -and $acknowledgement -eq "unknown") { 1 } else { 0 }
        gatePass = if ($Coupling.status -eq "available" -and $gateStatus -eq "pass") { 1 } else { 0 }
        gatePending = if ($Coupling.status -eq "available" -and $gateStatus -eq "pending") { 1 } else { 0 }
        gateFail = if ($Coupling.status -eq "available" -and $gateStatus -eq "fail") { 1 } else { 0 }
    }
    if ($Coupling.status -eq "not_available") {
        foreach ($key in @("acknowledged", "notAcknowledged", "unknownAcknowledgements", "gatePass", "gatePending", "gateFail")) {
            $counts[$key] = "not_available"
        }
    }

    $paths = @(Get-Array (Get-Property -Object (Get-Property -Object $data -Name "affectedDocumentation") -Name "paths"))
    $entries = @(Get-Array (Get-Property -Object $data -Name "matchedEntries"))
    $domainRecords = New-Object System.Collections.Generic.List[object]
    foreach ($domain in $script:Domains) {
        $domainPaths = @($paths | Where-Object { (Normalize-Domain ([string]$_)) -eq $domain })
        $domainEntries = @($entries | Where-Object {
                $target = Get-Property -Object $_ -Name "targets"
                @((Get-Array (Get-Property -Object $target -Name "paths")) | Where-Object { (Normalize-Domain ([string]$_) -eq $domain) }).Count -gt 0
            })
        $domainCounts = [ordered]@{
            matchedEntries = $domainEntries.Count
            targetedPaths = $domainPaths.Count
            gaps = "unknown"
        }
        $domainStatus = if ($Coupling.status -eq "available") { "available" } else { "not_available" }
        [void]$domainRecords.Add((New-DomainMetric -Domain $domain -Status $domainStatus -Counts $domainCounts))
    }

    return [ordered]@{
        status = if ($Coupling.status -eq "available") { "available" } else { "not_available" }
        sourceArtifacts = @($Coupling | Where-Object { $_.status -ne "not_available" } | ForEach-Object { [string]$_.id })
        counts = $counts
        byDomain = @($domainRecords.ToArray())
    }
}

function Get-ManifestDeltaMetric {
    param(
        [Parameter(Mandatory = $true)]$Manifest,
        [Parameter(Mandatory = $true)]$Delta,
        [Parameter(Mandatory = $true)]$Sitemap
    )

    $manifestData = if ($Manifest.status -eq "available") { $Manifest.data } else { $null }
    $manifestCounts = Get-Property -Object $manifestData -Name "counts"
    $deltaData = if ($Delta.status -eq "available") { $Delta.data } else { $null }
    $deltaCounts = Get-Property -Object $deltaData -Name "counts"
    $sitemapData = if ($Sitemap.status -eq "available") { $Sitemap.data } else { $null }
    $sitemapCounts = Get-Property -Object $sitemapData -Name "counts"
    $empty = Get-Property -Object $deltaData -Name "empty" -Default "unknown"
    if ($empty -isnot [bool]) {
        $empty = if ($Delta.status -eq "available") { "unknown" } else { "not_available" }
    }
    $counts = [ordered]@{
        manifestCurrent = Get-CountValue -Object $manifestCounts -Name "current" -Missing "not_available"
        manifestAdded = Get-CountValue -Object $manifestCounts -Name "added" -Missing "not_available"
        manifestChanged = Get-CountValue -Object $manifestCounts -Name "changed" -Missing "not_available"
        manifestMoved = Get-CountValue -Object $manifestCounts -Name "moved" -Missing "not_available"
        manifestUnchanged = Get-CountValue -Object $manifestCounts -Name "unchanged" -Missing "not_available"
        manifestRemoved = Get-CountValue -Object $manifestCounts -Name "removed" -Missing "not_available"
        manifestTombstones = Get-CountValue -Object $manifestCounts -Name "tombstones" -Missing "not_available"
        manifestTotal = Get-CountValue -Object $manifestCounts -Name "total" -Missing "not_available"
        deltaEvents = Get-CountValue -Object $deltaCounts -Name "total" -Missing "not_available"
        deltaAdded = Get-CountValue -Object $deltaCounts -Name "added" -Missing "not_available"
        deltaChanged = Get-CountValue -Object $deltaCounts -Name "changed" -Missing "not_available"
        deltaMoved = Get-CountValue -Object $deltaCounts -Name "moved" -Missing "not_available"
        deltaDeprecated = Get-CountValue -Object $deltaCounts -Name "deprecated" -Missing "not_available"
        deltaRemoved = Get-CountValue -Object $deltaCounts -Name "removed" -Missing "not_available"
        deltaAmbiguousMoves = Get-CountValue -Object $deltaCounts -Name "ambiguousMoves" -Missing "not_available"
        redirects = Get-CountValue -Object $deltaCounts -Name "redirects" -Missing "not_available"
        tombstones = Get-CountValue -Object $deltaCounts -Name "tombstones" -Missing "not_available"
        manifestGaps = @(Get-ReportGaps -Data $manifestData).Count
        deltaGaps = @(Get-ReportGaps -Data $deltaData).Count
        sitemapGaps = @(Get-ReportGaps -Data $sitemapData).Count
        sitemapUrls = Get-CountValue -Object $sitemapCounts -Name "urls" -Missing "not_available"
    }
    if ($Manifest.status -ne "available") {
        $counts.manifestGaps = "not_available"
    }
    if ($Delta.status -ne "available") {
        $counts.deltaGaps = "not_available"
    }
    if ($Sitemap.status -ne "available") {
        $counts.sitemapGaps = "not_available"
    }

    $events = @(Get-Array (Get-Property -Object $deltaData -Name "events"))
    $domainCounts = @{}
    foreach ($domain in $script:Domains) {
        $domainCounts[$domain] = [ordered]@{
            events = 0
            added = 0
            changed = 0
            moved = 0
            deprecated = 0
            removed = 0
            ambiguousMoves = 0
        }
    }
    foreach ($event in $events) {
        $current = Get-Property -Object $event -Name "current"
        $previous = Get-Property -Object $event -Name "previous"
        $domain = Normalize-Domain (Get-StringValue -Object $current -Name "domain" -Default (Get-StringValue -Object $previous -Name "domain" -Default (Get-StringValue -Object $current -Name "sourcePath" -Default (Get-StringValue -Object $previous -Name "sourcePath"))))
        if (-not $domainCounts.ContainsKey($domain)) {
            continue
        }
        $domainCounts[$domain].events++
        $eventType = Get-StringValue -Object $event -Name "type"
        if ($domainCounts[$domain].Contains($eventType)) {
            $domainCounts[$domain][$eventType]++
        }
    }
    $domainRecords = New-Object System.Collections.Generic.List[object]
    foreach ($domain in $script:Domains) {
        $domainStatus = if ($Delta.status -eq "available") { "available" } else { "not_available" }
        [void]$domainRecords.Add((New-DomainMetric -Domain $domain -Status $domainStatus -Counts $domainCounts[$domain]))
    }

    return [ordered]@{
        status = Get-StatusForArtifacts -Artifacts @($Manifest, $Delta, $Sitemap)
        sourceArtifacts = @($Manifest, $Delta, $Sitemap | Where-Object { $_.status -ne "not_available" } | ForEach-Object { [string]$_.id } | Sort-Object -Unique)
        empty = $empty
        counts = $counts
        byDomain = @($domainRecords.ToArray())
    }
}

function Get-AgentSyncMetric {
    param(
        [Parameter(Mandatory = $true)]$AgentSync,
        [Parameter(Mandatory = $true)][string]$AsOfDate
    )

    $data = if ($AgentSync.status -eq "available") { $AgentSync.data } else { $null }
    $events = @(Get-Array (Get-Property -Object $data -Name "events"))
    if ($events.Count -eq 0) {
        $events = @(Get-Array (Get-Property -Object (Get-Property -Object $data -Name "agentSync") -Name "events"))
    }
    $latestDate = $null
    foreach ($event in $events) {
        $value = Get-StringValue -Object $event -Name "occurredAt" -Default (Get-StringValue -Object $event -Name "timestamp" -Default (Get-StringValue -Object $event -Name "recordedAt" -Default ""))
        if ([String]::IsNullOrWhiteSpace($value)) {
            continue
        }
        try {
            $date = [DateTimeOffset]::Parse($value, [Globalization.CultureInfo]::InvariantCulture).Date
            if ($null -eq $latestDate -or $date -gt $latestDate) {
                $latestDate = $date
            }
        }
        catch {
        }
    }
    $lag = "unknown"
    if ($null -ne $latestDate -and $AsOfDate -match "^\d{4}-\d{2}-\d{2}$") {
        $asOf = [datetime]::ParseExact($AsOfDate, "yyyy-MM-dd", [Globalization.CultureInfo]::InvariantCulture)
        $lag = [math]::Max(0, [int]($asOf.Date - $latestDate).TotalDays)
    }

    $counts = [ordered]@{
        events = if ($AgentSync.status -eq "available") { $events.Count } else { "not_available" }
        lagDays = if ($AgentSync.status -eq "available") { $lag } else { "unknown" }
        eventsWithTimestamp = @($events | Where-Object {
                -not [String]::IsNullOrWhiteSpace((Get-StringValue -Object $_ -Name "occurredAt" -Default (Get-StringValue -Object $_ -Name "timestamp" -Default (Get-StringValue -Object $_ -Name "recordedAt" -Default ""))))
            }).Count
    }
    if ($AgentSync.status -ne "available") {
        $counts.eventsWithTimestamp = "not_available"
    }
    $domainRecords = New-Object System.Collections.Generic.List[object]
    $domainStatus = if ($AgentSync.status -eq "available") { "available" } else { "not_available" }
    foreach ($domain in $script:Domains) {
        $domainEvents = @($events | Where-Object {
                (Normalize-Domain (Get-StringValue -Object $_ -Name "domain" -Default (Get-StringValue -Object $_ -Name "sourcePath"))) -eq $domain
            })
        [void]$domainRecords.Add((New-DomainMetric -Domain $domain -Status $domainStatus -Counts ([ordered]@{
                    events = if ($AgentSync.status -eq "available") { $domainEvents.Count } else { "not_available" }
                    lagDays = "unknown"
                })))
    }

    return [ordered]@{
        status = if ($AgentSync.status -eq "available") { "available" } else { "not_available" }
        sourceArtifacts = @($AgentSync | Where-Object { $_.status -ne "not_available" } | ForEach-Object { [string]$_.id })
        counts = $counts
        byDomain = @($domainRecords.ToArray())
    }
}

function Add-Gap {
    param(
        [Parameter(Mandatory = $true)][AllowEmptyCollection()][System.Collections.Generic.List[object]]$Gaps,
        [Parameter(Mandatory = $true)][string]$Code,
        [Parameter(Mandatory = $true)][string]$Source,
        [Parameter(Mandatory = $true)][int]$Count,
        [string]$Domain = "unknown",
        [ValidateSet("unresolved", "not_available", "pre_existing")][string]$Status = "unresolved"
    )

    if ($Count -le 0) {
        return
    }
    $Gaps.Add([ordered]@{
            code = $Code
            sourceArtifact = $Source
            count = $Count
            domain = $Domain
            status = $Status
        }) | Out-Null
}

function Get-IntOrZero {
    param([AllowNull()]$Value)

    if ($Value -is [int]) {
        return [int]$Value
    }
    return 0
}

function Add-InputGaps {
    param(
        [Parameter(Mandatory = $true)][AllowEmptyCollection()][System.Collections.Generic.List[object]]$Gaps,
        [Parameter(Mandatory = $true)]$Artifact
    )

    if ($Artifact.status -ne "available") {
        return
    }
    $items = @(Get-ReportGaps -Data $Artifact.data)
    if ($items.Count -eq 0) {
        return
    }
    $Gaps.Add([ordered]@{
            code = "input-gaps-$($Artifact.id)"
            sourceArtifact = [string]$Artifact.id
            count = $items.Count
            domain = "unknown"
            status = "unresolved"
        }) | Out-Null
}

function Get-IdentityMaterial {
    param(
        [Parameter(Mandatory = $true)]$Source,
        [Parameter(Mandatory = $true)]$Scope,
        [Parameter(Mandatory = $true)]$Artifacts,
        [Parameter(Mandatory = $true)]$Metrics,
        [Parameter(Mandatory = $true)]$Gaps,
        [Parameter(Mandatory = $true)]$Summary
    )

    return [ordered]@{
        schemaVersion = 1
        policy = "D6.3"
        sourceRevision = [string]$Source.revision
        scope = $Scope
        artifacts = @($Artifacts | ForEach-Object {
                [ordered]@{
                    id = [string]$_.id
                    path = [string]$_.path
                    status = [string]$_.status
                    available = [bool]$_.available
                    sha256 = [string]$_.sha256
                    schemaVersion = $_.schemaVersion
                }
            })
        metrics = $Metrics
        gaps = $Gaps
        summary = [ordered]@{
            artifactCount = [int]$Summary.artifactCount
            availableArtifacts = [int]$Summary.availableArtifacts
            unavailableArtifacts = [int]$Summary.unavailableArtifacts
            invalidArtifacts = [int]$Summary.invalidArtifacts
            metricCount = [int]$Summary.metricCount
            availableMetrics = [int]$Summary.availableMetrics
            gapRecords = [int]$Summary.gapRecords
            unresolvedGaps = [int]$Summary.unresolvedGaps
            notAvailableGaps = [int]$Summary.notAvailableGaps
            emptyDelta = $Summary.emptyDelta
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

function Write-Json {
    param(
        [Parameter(Mandatory = $true)][string]$Path,
        [Parameter(Mandatory = $true)]$Value
    )

    $directory = Split-Path -Parent $Path
    if (-not (Test-Path -LiteralPath $directory -PathType Container)) {
        New-Item -ItemType Directory -Path $directory -Force | Out-Null
    }
    $utf8NoBom = New-Object Text.UTF8Encoding($false)
    [IO.File]::WriteAllText($Path, (($Value | ConvertTo-Json -Depth 40) + [Environment]::NewLine), $utf8NoBom)
}

$root = ConvertTo-FullPath $RepositoryRoot
Assert-Condition (Test-Path -LiteralPath $root -PathType Container) "Repository root '$root' does not exist."
$output = ConvertTo-FullPath $OutputPath
$schema = ConvertTo-FullPath $SchemaPath
$validator = ConvertTo-FullPath $ValidatorPath
Assert-Condition (Test-Path -LiteralPath $schema -PathType Leaf) "Documentation metrics schema '$schema' does not exist."
Assert-Condition (Test-Path -LiteralPath $validator -PathType Leaf) "Documentation metrics validator '$validator' does not exist."
$source = Get-SourceRevisionInfo -Root $root -RequestedRevision $SourceRevision
$generation = Get-GenerationInfo -Root $root -RequestedDate $GenerationDate

$artifactDefinitions = @(
    [ordered]@{ id = "metadata-baseline"; path = $BaselinePath },
    [ordered]@{ id = "metadata-migration"; path = $MetadataMigrationPath },
    [ordered]@{ id = "metadata-validation"; path = $MetadataValidationPath },
    [ordered]@{ id = "generated-provenance"; path = $ProvenancePath },
    [ordered]@{ id = "content-manifest"; path = $ManifestPath },
    [ordered]@{ id = "deployment-delta"; path = $DeltaPath },
    [ordered]@{ id = "segmented-sitemap"; path = $SitemapPath },
    [ordered]@{ id = "quality-gate"; path = $QualityPath },
    [ordered]@{ id = "external-link-check"; path = $ExternalLinkPath },
    [ordered]@{ id = "csharp-snippets"; path = $CSharpPath },
    [ordered]@{ id = "xml-snippets"; path = $XmlPath },
    [ordered]@{ id = "safety-gate"; path = $SafetyPath },
    [ordered]@{ id = "governance"; path = $GovernancePath },
    [ordered]@{ id = "coupling"; path = $CouplingPath },
    [ordered]@{ id = "agent-sync-events"; path = $AgentSyncEventsPath }
)
$artifactMap = @{}
$artifactRecords = New-Object System.Collections.Generic.List[object]
foreach ($definition in $artifactDefinitions) {
    $artifact = Read-InputArtifact -Id ([string]$definition.id) -Path ([string]$definition.path) -Root $root
    $artifactMap[[string]$definition.id] = $artifact
    [void]$artifactRecords.Add($artifact)
}

$metadataMetric = Get-MetadataCoverageMetric -Migration $artifactMap["metadata-migration"] -Baseline $artifactMap["metadata-baseline"] -Governance $artifactMap["governance"]
$identityMetric = Get-IdentityAndLinkMetric -Baseline $artifactMap["metadata-baseline"] -Manifest $artifactMap["content-manifest"] -Sitemap $artifactMap["segmented-sitemap"] -ExternalLinks $artifactMap["external-link-check"] -MetadataValidation $artifactMap["metadata-validation"]
$snippetMetric = Get-SnippetMetric -CSharp $artifactMap["csharp-snippets"] -Xml $artifactMap["xml-snippets"]
$qualityMetric = Get-QualityMetric -Quality $artifactMap["quality-gate"] -ExternalLinks $artifactMap["external-link-check"] -MetadataValidation $artifactMap["metadata-validation"]
$safetyMetric = Get-SafetyMetric -Safety $artifactMap["safety-gate"] -Quality $artifactMap["quality-gate"]
$provenanceMetric = Get-ProvenanceMetric -Provenance $artifactMap["generated-provenance"]
$governanceMetric = Get-GovernanceMetric -Governance $artifactMap["governance"]
$couplingMetric = Get-CouplingMetric -Coupling $artifactMap["coupling"]
$deltaMetric = Get-ManifestDeltaMetric -Manifest $artifactMap["content-manifest"] -Delta $artifactMap["deployment-delta"] -Sitemap $artifactMap["segmented-sitemap"]
$agentMetric = Get-AgentSyncMetric -AgentSync $artifactMap["agent-sync-events"] -AsOfDate ([string]$generation.generatedAt)

$metrics = [ordered]@{
    metadataCoverage = $metadataMetric
    uidUrlLinkHealth = $identityMetric
    snippetValidation = $snippetMetric
    qualityGates = $qualityMetric
    safety = $safetyMetric
    generatedProvenance = $provenanceMetric
    governance = $governanceMetric
    coupling = $couplingMetric
    sourceDocumentationDelta = $deltaMetric
    agentSync = $agentMetric
}

$gaps = New-Object "System.Collections.Generic.List[object]"
foreach ($artifact in @($artifactRecords.ToArray())) {
    if ($artifact.status -eq "not_available") {
        Add-Gap -Gaps $gaps -Code "artifact-not-available-$($artifact.id)" -Source $artifact.id -Count 1 -Status "not_available"
    }
    elseif ($artifact.status -eq "invalid") {
        Add-Gap -Gaps $gaps -Code "artifact-invalid-$($artifact.id)" -Source $artifact.id -Count 1 -Status "unresolved"
    }
}
foreach ($artifact in @($artifactRecords.ToArray())) {
    Add-InputGaps -Gaps $gaps -Artifact $artifact
}

$metadataCounts = $metadataMetric.counts
Add-Gap -Gaps $gaps -Code "metadata-unknown-versions" -Source "metadata-migration" -Count (Get-IntOrZero $metadataCounts.unknownVersions)
Add-Gap -Gaps $gaps -Code "metadata-unknown-authorities" -Source "metadata-migration" -Count (Get-IntOrZero $metadataCounts.unknownAuthorities)
Add-Gap -Gaps $gaps -Code "metadata-pending-review" -Source "metadata-migration" -Count (Get-IntOrZero $metadataCounts.pendingReview)
Add-Gap -Gaps $gaps -Code "missing-stable-uids" -Source "metadata-baseline" -Count (Get-IntOrZero $identityMetric.counts.pagesWithoutUid)
Add-Gap -Gaps $gaps -Code "duplicate-stable-uids" -Source "metadata-baseline" -Count (Get-IntOrZero $identityMetric.counts.duplicateUid)
Add-Gap -Gaps $gaps -Code "quality-new-findings" -Source "quality-gate" -Count (Get-IntOrZero $qualityMetric.counts.newFindings)
Add-Gap -Gaps $gaps -Code "safety-new-findings" -Source "safety-gate" -Count (Get-IntOrZero $safetyMetric.counts.newFindings)
Add-Gap -Gaps $gaps -Code "safety-new-gaps" -Source "safety-gate" -Count (Get-IntOrZero $safetyMetric.counts.newGaps)
Add-Gap -Gaps $gaps -Code "governance-stale-reviews" -Source "governance" -Count (Get-IntOrZero $governanceMetric.counts.staleReviews)
Add-Gap -Gaps $gaps -Code "governance-review-gaps" -Source "governance" -Count (Get-IntOrZero $governanceMetric.counts.reviewGaps)
Add-Gap -Gaps $gaps -Code "coupling-unresolved" -Source "coupling" -Count (Get-IntOrZero $couplingMetric.counts.unresolved)
Add-Gap -Gaps $gaps -Code "coupling-gaps" -Source "coupling" -Count (Get-IntOrZero $couplingMetric.counts.gaps)
Add-Gap -Gaps $gaps -Code "delta-gaps" -Source "deployment-delta" -Count (Get-IntOrZero $deltaMetric.counts.deltaGaps)
if ($agentMetric.status -eq "not_available") {
    Add-Gap -Gaps $gaps -Code "agent-sync-event-source-not-available" -Source "agent-sync-events" -Count 1 -Status "not_available"
}

$orderedGaps = @(
    $gaps.ToArray() |
        Sort-Object code, sourceArtifact, domain
)
$orderedArtifacts = @(
    $artifactRecords.ToArray() |
        Sort-Object id
)
$availableArtifactCount = @($orderedArtifacts | Where-Object { $_.status -eq "available" }).Count
$unavailableArtifactCount = @($orderedArtifacts | Where-Object { $_.status -eq "not_available" }).Count
$invalidArtifactCount = @($orderedArtifacts | Where-Object { $_.status -eq "invalid" }).Count
$metricValues = @($metrics.Values)
$availableMetricCount = @($metricValues | Where-Object { $_.status -eq "available" }).Count
$emptyDelta = $deltaMetric.empty
$summary = [ordered]@{
    artifactCount = $orderedArtifacts.Count
    availableArtifacts = $availableArtifactCount
    unavailableArtifacts = $unavailableArtifactCount
    invalidArtifacts = $invalidArtifactCount
    metricCount = $metricValues.Count
    availableMetrics = $availableMetricCount
    gapRecords = $orderedGaps.Count
    unresolvedGaps = @($orderedGaps | Where-Object { $_.status -eq "unresolved" }).Count
    notAvailableGaps = @($orderedGaps | Where-Object { $_.status -eq "not_available" }).Count
    emptyDelta = $emptyDelta
    reportIdentity = "unknown"
}
$scope = [ordered]@{
    domains = @("Automation", "Connector")
    domainMetrics = "separate-where-evidence-exists"
}
$identityMaterial = Get-IdentityMaterial -Source $source -Scope $scope -Artifacts $orderedArtifacts -Metrics $metrics -Gaps $orderedGaps -Summary $summary
$identityValue = Get-ObjectSha256 -Value $identityMaterial
$summary.reportIdentity = $identityValue

$report = [ordered]@{
    '$schema' = "documentation-metrics-v1.schema.json"
    schemaVersion = $script:SchemaVersion
    policy = "D6.3"
    format = "json"
    visibility = "repository-metadata"
    generator = [ordered]@{
        name = "scripts/generate-documentation-metrics.ps1"
        version = $script:GeneratorVersion
    }
    schema = [ordered]@{
        name = $script:SchemaName
        version = $script:SchemaVersion
    }
    identity = [ordered]@{
        algorithm = "sha256"
        value = $identityValue
        materialVersion = 1
    }
    source = [ordered]@{
        repository = $script:Repository
        revision = $source.revision
        revisionSource = $source.revisionSource
        generatedAt = $generation.generatedAt
        generatedAtSource = $generation.generatedAtSource
    }
    retention = [ordered]@{
        policy = "approved-ci-evidence"
        artifactClass = "d6-metrics"
        retentionDays = 90
        publication = "protected-main-or-scheduled"
    }
    protection = [ordered]@{
        metadataOnly = $true
        transformedProseIncluded = $false
        secretsIncluded = $false
    }
    scope = $scope
    artifacts = @($orderedArtifacts | ForEach-Object {
            [ordered]@{
                id = [string]$_.id
                path = [string]$_.path
                status = [string]$_.status
                available = [bool]$_.available
                sha256 = [string]$_.sha256
                schemaVersion = $_.schemaVersion
            }
        })
    metrics = $metrics
    gaps = $orderedGaps
    summary = $summary
}

Write-Json -Path $output -Value $report
& $validator -RepositoryRoot $root -Path $output -SchemaPath $schema | Out-Null
Write-Output ("D6.3 documentation metrics: {0} metrics, {1} available artifacts, {2} unresolved gap record(s), identity {3}." -f $summary.metricCount, $summary.availableArtifacts, $summary.unresolvedGaps, $identityValue)
