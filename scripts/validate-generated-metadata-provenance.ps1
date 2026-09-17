[CmdletBinding()]
param(
    [string]$RepositoryRoot = (Join-Path $PSScriptRoot ".."),
    [string]$Path = (Join-Path $PSScriptRoot "..\_artifacts\generated-metadata-provenance.json"),
    [string]$SchemaPath = (Join-Path $PSScriptRoot "..\contributing\metadata\generated-metadata-provenance-v1.schema.json")
)

Set-StrictMode -Version 2.0
$ErrorActionPreference = "Stop"

function ConvertTo-FullPath {
    param([Parameter(Mandatory = $true)][string]$Value)

    if ([IO.Path]::IsPathRooted($Value)) {
        return [IO.Path]::GetFullPath($Value)
    }
    return [IO.Path]::GetFullPath((Join-Path (Get-Location).Path $Value))
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

function Get-FileSha256 {
    param([Parameter(Mandatory = $true)][string]$FilePath)

    return (Get-FileHash -LiteralPath $FilePath -Algorithm SHA256).Hash.ToLowerInvariant()
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

function Assert-FileReference {
    param(
        [Parameter(Mandatory = $true)]$Reference,
        [Parameter(Mandatory = $true)][string]$Context
    )

    Assert-Properties `
        -Object $Reference `
        -Required @("path", "sha256", "available") `
        -Allowed @("path", "sha256", "canonicalSha256", "available", "reason") `
        -Context "$Context.file"
    if ($null -ne $Reference.sha256) {
        Assert-Condition ([string]$Reference.sha256 -match "^[0-9a-f]{64}$") "$Context has an invalid SHA-256 value."
    }
    if (@($Reference.PSObject.Properties.Name) -contains "canonicalSha256" -and $null -ne $Reference.canonicalSha256) {
        Assert-Condition ([string]$Reference.canonicalSha256 -match "^[0-9a-f]{64}$") "$Context has an invalid canonical SHA-256 value."
    }
    if ($Reference.available) {
        Assert-Condition (-not [String]::IsNullOrWhiteSpace([string]$Reference.path)) "$Context is available without a path."
        Assert-Condition ($null -ne $Reference.sha256) "$Context is available without a hash."
        $relativePath = [string]$Reference.path
        if (-not $relativePath.StartsWith("~") -and -not $relativePath.StartsWith("external/")) {
            $candidatePath = Join-Path $script:RepositoryRoot $relativePath.Replace("/", "\")
            if (Test-Path -LiteralPath $candidatePath -PathType Leaf) {
                Assert-Condition ((Get-FileSha256 -FilePath $candidatePath) -eq [string]$Reference.sha256) "$Context hash does not match the referenced file."
            }
        }
    }
    if ($null -ne $Reference.path) {
        Assert-Condition (-not [IO.Path]::IsPathRooted([string]$Reference.path)) "$Context contains a machine-specific absolute path."
    }
}

function Assert-Constraint {
    param(
        [Parameter(Mandatory = $true)]$Constraint,
        [Parameter(Mandatory = $true)][string]$Context
    )

    Assert-Properties `
        -Object $Constraint `
        -Required @("target", "value", "sourceLine") `
        -Allowed @("target", "value", "sourceLine") `
        -Context $Context
    Assert-Condition (-not [String]::IsNullOrWhiteSpace([string]$Constraint.target)) "$Context has no target."
    if ($null -ne $Constraint.sourceLine) {
        Assert-Condition ($Constraint.sourceLine -is [int] -or $Constraint.sourceLine -is [long]) "$Context has a non-integer source line."
        Assert-Condition ([int]$Constraint.sourceLine -gt 0) "$Context has an invalid source line."
    }
    if ($null -ne $Constraint.value) {
        Assert-Condition ($Constraint.value -is [string] -or $Constraint.value -is [bool]) "$Context has an unsupported value type."
    }
}

function Assert-Facts {
    param(
        [Parameter(Mandatory = $true)]$Facts,
        [Parameter(Mandatory = $true)][string]$Context
    )

    $categories = @("required", "defaults", "ranges", "enums", "structural", "introduced", "deprecated", "removed")
    Assert-Properties -Object $Facts -Required $categories -Allowed $categories -Context "$Context.facts"
    foreach ($category in @("required", "defaults", "ranges", "enums", "structural")) {
        foreach ($constraint in @($Facts.$category)) {
            Assert-Constraint -Constraint $constraint -Context "$Context.facts.$category"
        }
    }
    foreach ($category in @("introduced", "deprecated", "removed")) {
        foreach ($constraint in @($Facts.$category)) {
            Assert-Properties `
                -Object $constraint `
                -Required @("kind", "version", "sourceLine") `
                -Allowed @("kind", "version", "sourceLine") `
                -Context "$Context.facts.$category"
            Assert-Condition ([string]$constraint.kind -eq $category) "$Context has a mismatched lifecycle constraint kind."
            if ($null -ne $constraint.version) {
                Assert-Condition ([string]$constraint.version -match "^\d+(?:\.\d+){1,3}$") "$Context has an invalid lifecycle version."
            }
            if ($null -ne $constraint.sourceLine) {
                Assert-Condition ([int]$constraint.sourceLine -gt 0) "$Context has an invalid lifecycle source line."
            }
        }
    }
}

function Assert-Manual {
    param(
        [Parameter(Mandatory = $true)]$Manual,
        [Parameter(Mandatory = $true)][string]$Context
    )

    Assert-Properties `
        -Object $Manual `
        -Required @("remarksCount", "examplesCount", "overwriteCount", "sectionNames") `
        -Allowed @("remarksCount", "examplesCount", "overwriteCount", "sectionNames") `
        -Context "$Context.manual"
    Assert-Condition ([int]$Manual.remarksCount -ge 0) "$Context has a negative remarks count."
    Assert-Condition ([int]$Manual.examplesCount -ge 0) "$Context has a negative examples count."
    Assert-Condition ([int]$Manual.overwriteCount -ge 0) "$Context has a negative overwrite count."
    Assert-Condition (@($Manual.sectionNames | Sort-Object -Unique).Count -eq @($Manual.sectionNames).Count) "$Context has duplicate manual section names."
}

function Assert-Generated {
    param(
        [Parameter(Mandatory = $true)]$Generated,
        [Parameter(Mandatory = $true)][string]$Context
    )

    Assert-Properties `
        -Object $Generated `
        -Required @("sections") `
        -Allowed @("sections", "type", "memberCount", "parameterCount", "assemblies") `
        -Context "$Context.generated"
    foreach ($section in @($Generated.sections)) {
        Assert-Condition (-not [String]::IsNullOrWhiteSpace([string]$section)) "$Context has an empty generated section."
    }
    foreach ($countName in @("memberCount", "parameterCount")) {
        if ($null -ne $Generated.$countName) {
            Assert-Condition ([int]$Generated.$countName -ge 0) "$Context has an invalid generated count."
        }
    }
    foreach ($assembly in @($Generated.assemblies)) {
        Assert-Condition (-not [String]::IsNullOrWhiteSpace([string]$assembly)) "$Context has an empty generated assembly."
    }
}

function Assert-Output {
    param(
        [Parameter(Mandatory = $true)]$Output,
        [Parameter(Mandatory = $true)][ValidateSet("api", "schema")][string]$Kind,
        [Parameter(Mandatory = $true)]$ArtifactIds,
        [Parameter(Mandatory = $true)][string]$Context
    )

    Assert-Properties `
        -Object $Output `
        -Required @("path", "uid", "url", "file", "artifactIds", "pipeline", "compatibility", "generated", "facts", "manual") `
        -Allowed @("path", "uid", "url", "file", "artifactIds", "pipeline", "compatibility", "generated", "facts", "manual") `
        -Context $Context
    Assert-Condition (-not [String]::IsNullOrWhiteSpace([string]$Output.path)) "$Context has no output path."
    Assert-Condition (-not [IO.Path]::IsPathRooted([string]$Output.path)) "$Context has an absolute output path."
    Assert-Condition (-not [String]::IsNullOrWhiteSpace([string]$Output.url)) "$Context has no published URL."
    Assert-Condition ([string]$Output.url -notmatch "\\") "$Context has a Windows path instead of a URL."
    if ($null -ne $Output.uid) {
        Assert-Condition (-not [String]::IsNullOrWhiteSpace([string]$Output.uid)) "$Context has an empty UID."
    }
    Assert-FileReference -Reference $Output.file -Context $Context
    Assert-Condition ($null -ne $Output.file.canonicalSha256) "$Context has no canonical output hash."
    Assert-Condition ([string]$Output.pipeline -eq $(if ($Kind -eq "api") { "docfx metadata" } else { "schema documentation" })) "$Context has an unexpected pipeline."
    Assert-Properties `
        -Object $Output.compatibility `
        -Required @("uid", "url") `
        -Allowed @("uid", "url") `
        -Context "$Context.compatibility"
    Assert-Condition ([string]$Output.compatibility.uid -in @("stable", "unknown")) "$Context has an invalid UID compatibility value."
    Assert-Condition ([string]$Output.compatibility.url -in @("stable", "unknown")) "$Context has an invalid URL compatibility value."
    $ids = @($Output.artifactIds)
    Assert-Condition (@($ids | Sort-Object -Unique).Count -eq $ids.Count) "$Context has duplicate artifact IDs."
    foreach ($id in $ids) {
        Assert-Condition ($ArtifactIds.ContainsKey([string]$id)) "$Context references unknown artifact '$id'."
    }
    Assert-Generated -Generated $Output.generated -Context $Context
    Assert-Facts -Facts $Output.facts -Context $Context
    Assert-Manual -Manual $Output.manual -Context $Context
}

$root = ConvertTo-FullPath $RepositoryRoot
$script:RepositoryRoot = $root
$manifestPath = ConvertTo-FullPath $Path
$schemaFile = ConvertTo-FullPath $SchemaPath
Assert-Condition (Test-Path -LiteralPath $root -PathType Container) "Repository root '$root' does not exist."
Assert-Condition (Test-Path -LiteralPath $manifestPath -PathType Leaf) "Provenance manifest '$manifestPath' does not exist."
Assert-Condition (Test-Path -LiteralPath $schemaFile -PathType Leaf) "Provenance schema '$schemaFile' does not exist."

try {
    $contract = Get-Content -LiteralPath $schemaFile -Raw | ConvertFrom-Json
}
catch {
    throw "Provenance schema '$schemaFile' is not valid JSON."
}
Assert-Condition ([string]$contract.title -eq "DataMiner generated metadata provenance") "Unexpected provenance schema."

try {
    $manifestJson = Get-Content -LiteralPath $manifestPath -Raw
    $manifest = $manifestJson | ConvertFrom-Json
}
catch {
    throw "Provenance manifest '$manifestPath' is not valid JSON."
}
if ($null -ne (Get-Command Test-Json -ErrorAction SilentlyContinue)) {
    try {
        if (-not (Test-Json -Json $manifestJson -SchemaFile $schemaFile)) {
            throw "The provenance manifest does not conform to the committed JSON Schema."
        }
    }
    catch {
        throw "Provenance JSON Schema validation failed: $($_.Exception.Message)"
    }
}

Assert-Properties `
    -Object $manifest `
    -Required @("schemaVersion", "generator", "generatedAt", "generatedAtSource", "source", "license", "artifacts", "outputs", "gaps") `
    -Allowed @("schemaVersion", "generator", "generatedAt", "generatedAtSource", "source", "license", "artifacts", "outputs", "gaps") `
    -Context "manifest"
Assert-Condition ([int]$manifest.schemaVersion -eq 1) "Unsupported provenance schema version."
Assert-Properties -Object $manifest.generator -Required @("name", "version") -Allowed @("name", "version") -Context "manifest.generator"
Assert-Condition ([string]$manifest.generator.name -eq "scripts/generate-generated-metadata-provenance.ps1") "Unexpected provenance generator."
Assert-Condition (-not [String]::IsNullOrWhiteSpace([string]$manifest.generator.version)) "Provenance generator version is empty."
Assert-Condition ([string]$manifest.generatedAt -match "^\d{4}-\d{2}-\d{2}$|^unknown$") "Invalid generation date."
Assert-Condition ([string]$manifest.generatedAtSource -in @("argument", "source_date_epoch", "git_commit", "unknown")) "Invalid generation date source."

Assert-Properties -Object $manifest.source -Required @("repository", "revision", "revisionSource", "configuration") -Allowed @("repository", "revision", "revisionSource", "configuration") -Context "manifest.source"
Assert-Condition ([string]$manifest.source.repository -eq "SkylineCommunications/dataminer-docs") "Unexpected source repository."
Assert-Condition (-not [String]::IsNullOrWhiteSpace([string]$manifest.source.revision)) "Source revision is empty."
Assert-Condition ([string]$manifest.source.revisionSource -in @("argument", "git", "working-tree")) "Invalid source revision source."
Assert-FileReference -Reference $manifest.source.configuration -Context "manifest.source.configuration"

Assert-Properties `
    -Object $manifest.license `
    -Required @("identifier", "name", "url", "attribution", "source") `
    -Allowed @("identifier", "name", "url", "attribution", "source") `
    -Context "manifest.license"
Assert-Condition ([string]$manifest.license.identifier -eq "CC BY-NC-ND 4.0") "The D0 license identifier is missing."
Assert-Condition ([string]$manifest.license.name -eq "Creative Commons Attribution-NonCommercial-NoDerivatives 4.0 International") "The D0 license name is missing."
Assert-Condition ([string]$manifest.license.url -eq "https://creativecommons.org/licenses/by-nc-nd/4.0/") "The D0 license URL is missing."
Assert-Condition ([string]$manifest.license.attribution -eq "Skyline Communications") "The D0 attribution is missing."
Assert-Condition ([string]$manifest.license.source -eq "contributing/CTB_Documentation_Corpus_Policy.md") "The D0 policy source is missing."

$artifactIds = @{}
foreach ($artifact in @($manifest.artifacts)) {
    Assert-Properties `
        -Object $artifact `
        -Required @("id", "kind", "identity", "version", "file", "available", "sourceType") `
        -Allowed @("id", "kind", "identity", "version", "file", "available", "sourceType", "assemblyFullName", "assemblyName", "targetFramework", "sourceProject", "direct", "license", "attribution", "reason") `
        -Context "manifest.artifact"
    Assert-Condition (-not $artifactIds.ContainsKey([string]$artifact.id)) "Duplicate artifact ID '$($artifact.id)'."
    $artifactIds[[string]$artifact.id] = $true
    Assert-Condition ([string]$artifact.kind -in @("project", "source", "assembly", "xml-documentation", "package", "schema", "overwrite")) "Artifact '$($artifact.id)' has an invalid kind."
    Assert-Condition (-not [String]::IsNullOrWhiteSpace([string]$artifact.identity)) "Artifact '$($artifact.id)' has no identity."
    Assert-Condition ([string]$artifact.sourceType -in @("repository", "build-output", "nuget-cache", "documentation-identity", "external")) "Artifact '$($artifact.id)' has an invalid source type."
    if ($null -ne $artifact.version) {
        Assert-Condition (-not [String]::IsNullOrWhiteSpace([string]$artifact.version)) "Artifact '$($artifact.id)' has an empty version."
    }
    Assert-FileReference -Reference $artifact.file -Context "manifest.artifact '$($artifact.id)'"
    if ($artifact.available) {
        Assert-Condition $artifact.file.available "Artifact '$($artifact.id)' availability disagrees with its file reference."
    }
}

Assert-Properties -Object $manifest.outputs -Required @("api", "schema") -Allowed @("api", "schema") -Context "manifest.outputs"
foreach ($output in @($manifest.outputs.api)) {
    Assert-Output -Output $output -Kind api -ArtifactIds $artifactIds -Context "manifest.outputs.api '$($output.path)'"
}
foreach ($output in @($manifest.outputs.schema)) {
    Assert-Output -Output $output -Kind schema -ArtifactIds $artifactIds -Context "manifest.outputs.schema '$($output.path)'"
}

$gapCodes = @{}
foreach ($gap in @($manifest.gaps)) {
    Assert-Properties -Object $gap -Required @("code", "count") -Allowed @("code", "count") -Context "manifest.gap"
    Assert-Condition (-not [String]::IsNullOrWhiteSpace([string]$gap.code)) "A provenance gap has no code."
    Assert-Condition ([int]$gap.count -gt 0) "Provenance gap '$($gap.code)' has an invalid count."
    Assert-Condition (-not $gapCodes.ContainsKey([string]$gap.code)) "Duplicate provenance gap '$($gap.code)'."
    $gapCodes[[string]$gap.code] = $true
}

Write-Output "Generated metadata provenance validation passed."
Write-Output "API outputs: $(@($manifest.outputs.api).Count)."
Write-Output "Schema outputs: $(@($manifest.outputs.schema).Count)."
Write-Output "Source artifacts: $(@($manifest.artifacts).Count)."
Write-Output "Recorded source gaps: $(@($manifest.gaps).Count)."
