[CmdletBinding()]
param(
    [string]$RepositoryRoot = (Join-Path $PSScriptRoot ".."),
    [Parameter(Mandatory = $true)][string]$Path,
    [string]$ConfigurationPath = (Join-Path $PSScriptRoot "..\contributing\xml-documentation-examples-v1.json"),
    [string]$SchemaPath = (Join-Path $PSScriptRoot "..\contributing\metadata\xml-documentation-examples-v1.schema.json")
)

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

function Get-ObjectProperty {
    param(
        [Parameter(Mandatory = $true)]$Object,
        [Parameter(Mandatory = $true)][string]$Name,
        $Default = $null
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
    if (@($Object.PSObject.Properties.Name) -contains $Name) {
        return $Object.$Name
    }
    return $Default
}

function Get-StringProperty {
    param(
        [Parameter(Mandatory = $true)]$Object,
        [Parameter(Mandatory = $true)][string]$Name,
        [string]$Default = ""
    )

    $value = Get-ObjectProperty -Object $Object -Name $Name -Default $Default
    if ($null -eq $value) {
        return $Default
    }
    return [string]$value
}

function Get-Array {
    param($Value)

    if ($null -eq $Value) {
        return @()
    }
    return @($Value)
}

function Assert-Properties {
    param(
        [Parameter(Mandatory = $true)]$Object,
        [Parameter(Mandatory = $true)][string[]]$Required,
        [Parameter(Mandatory = $true)][string[]]$Allowed,
        [Parameter(Mandatory = $true)][string]$Context
    )

    Assert-Condition ($null -ne $Object) "$Context is missing."
    $properties = @($Object.PSObject.Properties.Name)
    foreach ($name in $Required) {
        Assert-Condition ($properties -contains $name) "$Context is missing '$name'."
    }
    foreach ($name in $properties) {
        Assert-Condition ($Allowed -contains $name) "$Context contains undocumented property '$name'."
    }
}

function ConvertTo-FullPath {
    param([Parameter(Mandatory = $true)][string]$Path)

    if ([IO.Path]::IsPathRooted($Path)) {
        return [IO.Path]::GetFullPath($Path)
    }
    return [IO.Path]::GetFullPath((Join-Path (Get-Location).Path $Path))
}

function ConvertTo-RepositoryRelativePath {
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
    if ($fullPath.Equals($rootPath, [StringComparison]::OrdinalIgnoreCase)) {
        return ""
    }
    throw "Path '$Path' is outside repository root '$Root'."
}

$repositoryRoot = ConvertTo-FullPath $RepositoryRoot
$reportPath = if ([IO.Path]::IsPathRooted($Path)) {
    [IO.Path]::GetFullPath($Path)
}
else {
    [IO.Path]::GetFullPath((Join-Path $repositoryRoot $Path))
}
$configurationPath = if ([IO.Path]::IsPathRooted($ConfigurationPath)) {
    [IO.Path]::GetFullPath($ConfigurationPath)
}
else {
    [IO.Path]::GetFullPath((Join-Path $repositoryRoot $ConfigurationPath))
}
$schemaPath = if ([IO.Path]::IsPathRooted($SchemaPath)) {
    [IO.Path]::GetFullPath($SchemaPath)
}
else {
    [IO.Path]::GetFullPath((Join-Path $repositoryRoot $SchemaPath))
}
Assert-Condition (Test-Path -LiteralPath $reportPath -PathType Leaf) "XML documentation example report '$reportPath' does not exist."
Assert-Condition (Test-Path -LiteralPath $configurationPath -PathType Leaf) "XML documentation example configuration '$configurationPath' does not exist."
Assert-Condition (Test-Path -LiteralPath $schemaPath -PathType Leaf) "XML documentation example report schema '$schemaPath' does not exist."

try {
    $report = Get-Content -LiteralPath $reportPath -Raw | ConvertFrom-Json
    $configuration = Get-Content -LiteralPath $configurationPath -Raw | ConvertFrom-Json
    $reportSchema = Get-Content -LiteralPath $schemaPath -Raw | ConvertFrom-Json
}
catch {
    throw "Could not parse an XML documentation example artifact: $($_.Exception.Message)"
}

Assert-Condition ([int](Get-ObjectProperty -Object $report -Name "schemaVersion") -eq 1) "XML documentation example report must use schemaVersion 1."
Assert-Condition ((Get-StringProperty -Object $report -Name "format") -eq "xml-documentation-examples") "XML documentation example report has an unsupported format."
Assert-Condition ((Get-StringProperty -Object $reportSchema -Name "title") -eq "DataMiner XML documentation examples validation report") "The XML documentation example report schema is not the expected contract."

Assert-Properties -Object $report -Required @("schemaVersion", "format", "generator", "source", "scope", "generation", "schemas", "counts", "examples", "gaps") -Allowed @("schemaVersion", "format", "generator", "source", "scope", "generation", "schemas", "counts", "examples", "gaps") -Context "report"
Assert-Properties -Object $report.generator -Required @("name", "version") -Allowed @("name", "version") -Context "report.generator"
Assert-Condition ((Get-StringProperty -Object $report.generator -Name "name") -eq "scripts/generate-xml-documentation-examples.ps1") "The report generator name is incorrect."
Assert-Properties -Object $report.source -Required @("repository", "revision", "revisionSource", "configuration") -Allowed @("repository", "revision", "revisionSource", "configuration") -Context "report.source"
Assert-Condition ((Get-StringProperty -Object $report.source -Name "repository") -eq "SkylineCommunications/dataminer-docs") "The report source repository is incorrect."
Assert-Properties -Object $report.source.configuration -Required @("path", "sha256") -Allowed @("path", "sha256") -Context "report.source.configuration"
Assert-Condition ((Get-StringProperty -Object $report.source.configuration -Name "sha256") -eq (Get-FileHash -LiteralPath $configurationPath -Algorithm SHA256).Hash.ToLowerInvariant()) "The report configuration hash does not match the configured rules."

Assert-Properties -Object $report.scope -Required @("language", "domains", "sourcePaths") -Allowed @("language", "domains", "sourcePaths") -Context "report.scope"
Assert-Condition ((Get-StringProperty -Object $report.scope -Name "language") -eq "xml") "The report scope language is not XML."
Assert-Condition ((@(Get-Array $report.scope.domains) -join ",") -eq "Automation,Protocol") "The report scope domains are not deterministic."

Assert-Properties -Object $report.generation -Required @("generatedAt", "generatedAtSource", "deterministic", "contentIdentityAlgorithm", "contentIdentityFields", "contentIdentityExcludes") -Allowed @("generatedAt", "generatedAtSource", "deterministic", "contentIdentityAlgorithm", "contentIdentityFields", "contentIdentityExcludes") -Context "report.generation"
Assert-Condition ([bool]$report.generation.deterministic) "The report is not marked deterministic."
Assert-Condition ((Get-StringProperty -Object $report.generation -Name "contentIdentityAlgorithm") -eq "sha256") "The report content identity algorithm is not SHA-256."

$configuredSchemas = @{}
foreach ($schema in (Get-Array (Get-ObjectProperty -Object $configuration -Name "schemas"))) {
    $configuredSchemas[(Get-StringProperty -Object $schema -Name "id")] = $schema
}
$reportedSchemas = @(Get-Array (Get-ObjectProperty -Object $report -Name "schemas"))
Assert-Condition ($reportedSchemas.Count -eq $configuredSchemas.Count) "The report schema count does not match the configured schema count."
foreach ($schema in $reportedSchemas) {
    Assert-Properties -Object $schema -Required @("id", "domain", "rootElement", "namespace", "version", "versionEvidence", "source", "available") -Allowed @("id", "domain", "rootElement", "namespace", "version", "versionEvidence", "source", "available") -Context "report schema"
    $schemaId = Get-StringProperty -Object $schema -Name "id"
    Assert-Condition ($configuredSchemas.ContainsKey($schemaId)) "Report contains unknown schema '$schemaId'."
    $configured = $configuredSchemas[$schemaId]
    Assert-Condition ((Get-StringProperty -Object $schema -Name "version") -eq (Get-StringProperty -Object $configured -Name "version")) "Schema '$schemaId' version evidence changed from the configuration."
    Assert-Condition ((Get-StringProperty -Object $schema.source -Name "commit") -eq (Get-StringProperty -Object (Get-ObjectProperty -Object $configured -Name "source") -Name "commit")) "Schema '$schemaId' source commit changed from the configuration."
    foreach ($file in (Get-Array (Get-ObjectProperty -Object $schema.source -Name "files"))) {
        Assert-Properties -Object $file -Required @("path", "role", "url", "sha256", "available") -Allowed @("path", "role", "url", "sha256", "available") -Context "report schema file"
    }
}

$examples = @(Get-Array (Get-ObjectProperty -Object $report -Name "examples"))
$gaps = @(Get-Array (Get-ObjectProperty -Object $report -Name "gaps"))
$counts = $report.counts
Assert-Properties -Object $counts -Required @("sourcePages", "examples", "completeDocuments", "fragments", "passed", "expectedFailures", "failed", "unverified", "repairedFragments", "gaps", "byDomain") -Allowed @("sourcePages", "examples", "completeDocuments", "fragments", "passed", "expectedFailures", "failed", "unverified", "repairedFragments", "gaps", "byDomain") -Context "report.counts"
Assert-Condition ([int]$counts.examples -eq $examples.Count) "Report example count does not match examples."
Assert-Condition ([int]$counts.gaps -eq $gaps.Count) "Report gap count does not match gaps."
Assert-Condition ([int]$counts.completeDocuments -eq @($examples | Where-Object { $_.classification.kind -eq "complete" }).Count) "Report complete-document count does not match examples."
Assert-Condition ([int]$counts.fragments -eq @($examples | Where-Object { $_.classification.kind -eq "fragment" }).Count) "Report fragment count does not match examples."
Assert-Condition ([int]$counts.passed -eq @($examples | Where-Object { $_.result.status -eq "passed" }).Count) "Report passed count does not match examples."
Assert-Condition ([int]$counts.expectedFailures -eq @($examples | Where-Object { $_.result.status -eq "expected-failure" }).Count) "Report expected-failure count does not match examples."
Assert-Condition ([int]$counts.failed -eq @($examples | Where-Object { $_.result.status -eq "failed" }).Count) "Report failed count does not match examples."
Assert-Condition ([int]$counts.unverified -eq @($examples | Where-Object { $_.result.status -eq "unverified" }).Count) "Report unverified count does not match examples."

$exampleIds = New-Object System.Collections.Generic.HashSet[string]
foreach ($example in $examples) {
    Assert-Properties -Object $example -Required @("id", "domain", "source", "classification", "negative", "contentHash", "schema", "wrapper", "result") -Allowed @("id", "domain", "source", "classification", "negative", "contentHash", "schema", "wrapper", "result") -Context "report example"
    Assert-Condition ($exampleIds.Add((Get-StringProperty -Object $example -Name "id"))) "Duplicate example ID '$($example.id)'."
    Assert-Properties -Object $example.source -Required @("path", "uid", "startLine", "endLine", "fenceLine") -Allowed @("path", "uid", "startLine", "endLine", "fenceLine") -Context "report example source"
    $sourcePath = Join-Path $repositoryRoot ($example.source.path.Replace("/", "\"))
    Assert-Condition (Test-Path -LiteralPath $sourcePath -PathType Leaf) "Example source page '$($example.source.path)' does not exist."
    Assert-Condition ([int]$example.source.startLine -le [int]$example.source.endLine) "Example source line range is invalid for '$($example.id)'."
    Assert-Properties -Object $example.classification -Required @("kind", "reason", "rootElement", "namespace") -Allowed @("kind", "reason", "rootElement", "namespace") -Context "report example classification"
    Assert-Properties -Object $example.wrapper -Required @("id", "rootElement", "namespace", "applied", "validation", "normalized", "repaired") -Allowed @("id", "rootElement", "namespace", "applied", "validation", "normalized", "repaired") -Context "report example wrapper"
    Assert-Properties -Object $example.result -Required @("status", "schemaStatus", "message") -Allowed @("status", "schemaStatus", "message") -Context "report example result"

    $status = Get-StringProperty -Object $example.result -Name "status"
    $negative = [bool]$example.negative
    if ($status -eq "expected-failure") {
        Assert-Condition $negative "An expected-failure example must be explicitly marked negative."
    }
    if ($status -eq "failed" -and -not $negative) {
        throw "Unmarked XML example '$($example.id)' failed validation."
    }
    if ($negative -and $status -eq "passed") {
        throw "Negative XML example '$($example.id)' unexpectedly passed validation."
    }
    if ($example.classification.kind -eq "complete") {
        Assert-Condition ($example.wrapper.validation -eq "xsd") "Complete XML example '$($example.id)' was not validated with XSD."
    }
    else {
        Assert-Condition ([bool]$example.wrapper.applied) "Fragment XML example '$($example.id)' did not apply its declared wrapper."
    }
}

foreach ($gap in $gaps) {
    Assert-Properties -Object $gap -Required @("id", "kind", "severity", "message") -Allowed @("id", "kind", "severity", "domain", "sourcePath", "sourceLine", "schemaId", "message") -Context "report gap"
}

Write-Output "Validated XML documentation example report: $($examples.Count) examples, $($gaps.Count) gaps."
