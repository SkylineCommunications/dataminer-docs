[CmdletBinding()]
param(
    [string]$RepositoryRoot = (Join-Path $PSScriptRoot ".."),
    [string]$Path = (Join-Path $PSScriptRoot "..\_artifacts\csharp-documentation-examples\csharp-documentation-examples.json"),
    [string]$SchemaPath = (Join-Path $PSScriptRoot "..\contributing\metadata\csharp-documentation-example-v1.schema.json")
)

Set-StrictMode -Version 2.0
$ErrorActionPreference = "Stop"

$script:Repository = "SkylineCommunications/dataminer-docs"
$script:GeneratorName = "scripts/generate-csharp-documentation-examples.ps1"
$script:SchemaName = "contributing/metadata/csharp-documentation-example-v1.schema.json"

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
    param(
        [Parameter(Mandatory = $true)][string]$Path,
        [string]$BasePath = (Get-Location).Path
    )

    if ([IO.Path]::IsPathRooted($Path)) {
        return [IO.Path]::GetFullPath($Path)
    }

    return [IO.Path]::GetFullPath((Join-Path $BasePath $Path))
}

function ConvertTo-PortablePath {
    param([Parameter(Mandatory = $true)][string]$Path)

    return $Path.Replace("\", "/")
}

function ConvertTo-RepositoryRelativePath {
    param(
        [Parameter(Mandatory = $true)][string]$Path,
        [Parameter(Mandatory = $true)][string]$Root
    )

    $fullPath = [IO.Path]::GetFullPath($Path)
    $rootPath = [IO.Path]::GetFullPath($Root).TrimEnd("\")
    if ($fullPath.Equals($rootPath, [StringComparison]::OrdinalIgnoreCase)) {
        return ""
    }

    $prefix = $rootPath + "\"
    Assert-Condition $fullPath.StartsWith($prefix, [StringComparison]::OrdinalIgnoreCase) `
        "Path '$Path' is outside repository root '$Root'."
    return ConvertTo-PortablePath $fullPath.Substring($prefix.Length)
}

function Assert-SafeRelativePath {
    param(
        [Parameter(Mandatory = $true)][string]$Value,
        [Parameter(Mandatory = $true)][string]$Context
    )

    Assert-Condition (-not [IO.Path]::IsPathRooted($Value)) "$Context is absolute."
    Assert-Condition ($Value -notmatch "\\") "$Context contains a Windows path separator."
    Assert-Condition ($Value -notmatch "(^|/)\.\.(?:/|$)") "$Context escapes its root."
    Assert-Condition ($Value -notmatch "^/") "$Context starts at the filesystem root."
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

function Assert-Hash {
    param(
        [Parameter(Mandatory = $true)][string]$Value,
        [Parameter(Mandatory = $true)][string]$Context
    )

    Assert-Condition ($Value -match "^[0-9a-f]{64}$") "$Context is not a lowercase SHA-256 value."
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

function Assert-ProjectPath {
    param(
        [Parameter(Mandatory = $true)][string]$Value,
        [Parameter(Mandatory = $true)][string]$Context
    )

    Assert-SafeRelativePath -Value $Value -Context $Context
    Assert-Condition $Value.StartsWith("projects/", [StringComparison]::Ordinal) "$Context is outside projects/."
}

function Get-ProjectPackageKeys {
    param([Parameter(Mandatory = $true)]$Project)

    $keys = New-Object "System.Collections.Generic.List[string]"
    $references = @()
    $itemGroupProperty = $Project.Project.PSObject.Properties["ItemGroup"]
    if ($null -ne $itemGroupProperty) {
        foreach ($itemGroup in @($itemGroupProperty.Value)) {
            $packageReferenceProperty = $itemGroup.PSObject.Properties["PackageReference"]
            if ($null -ne $packageReferenceProperty) {
                $references += @($packageReferenceProperty.Value)
            }
        }
    }

    foreach ($reference in $references) {
        [void]$keys.Add("$($reference.Include)@$($reference.Version)")
    }
    return @($keys.ToArray() | Sort-Object)
}

function Get-ProjectCompilePaths {
    param([Parameter(Mandatory = $true)]$Project)

    $paths = New-Object "System.Collections.Generic.List[string]"
    $itemGroupProperty = $Project.Project.PSObject.Properties["ItemGroup"]
    if ($null -ne $itemGroupProperty) {
        foreach ($itemGroup in @($itemGroupProperty.Value)) {
            $compileProperty = $itemGroup.PSObject.Properties["Compile"]
            if ($null -ne $compileProperty) {
                foreach ($compile in @($compileProperty.Value)) {
                    [void]$paths.Add([string]$compile.Include)
                }
            }
        }
    }
    return @($paths.ToArray() | Sort-Object)
}

$root = ConvertTo-FullPath $RepositoryRoot
$manifestPath = ConvertTo-FullPath $Path
$schemaPath = ConvertTo-FullPath $SchemaPath
Assert-Condition (Test-Path -LiteralPath $root -PathType Container) "Repository root '$root' does not exist."
Assert-Condition (Test-Path -LiteralPath $manifestPath -PathType Leaf) "C# example manifest '$manifestPath' does not exist."
Assert-Condition (Test-Path -LiteralPath $schemaPath -PathType Leaf) "C# example schema '$schemaPath' does not exist."

$manifestJson = Get-Content -LiteralPath $manifestPath -Raw
try {
    $manifest = $manifestJson | ConvertFrom-Json
    $schema = Get-Content -LiteralPath $schemaPath -Raw | ConvertFrom-Json
}
catch {
    throw "C# documentation example manifest or schema is not valid JSON: $($_.Exception.Message)"
}

Assert-Condition ([string]$schema.title -eq "DataMiner C# documentation example validation manifest") `
    "Unexpected C# documentation example schema."
if ($null -ne (Get-Command Test-Json -ErrorAction SilentlyContinue)) {
    try {
        if (-not (Test-Json -Json $manifestJson -SchemaFile $schemaPath)) {
            throw "The C# documentation example manifest does not conform to its JSON Schema."
        }
    }
    catch {
        throw "C# documentation example JSON Schema validation failed: $($_.Exception.Message)"
    }
}

Assert-Properties -Object $manifest `
    -Required @("schemaVersion", "format", "generator", "schema", "source", "scope", "generation", "counts", "gaps", "examples") `
    -Allowed @("schemaVersion", "format", "generator", "schema", "source", "scope", "generation", "counts", "gaps", "examples") `
    -Context "C# documentation example manifest"
Assert-Condition ([int]$manifest.schemaVersion -eq 1) "Unsupported C# documentation example schema version."
Assert-Condition ([string]$manifest.format -eq "csharp-documentation-examples") "Unexpected C# documentation example format."

Assert-Properties -Object $manifest.generator -Required @("name", "version") -Allowed @("name", "version") `
    -Context "C# documentation example manifest.generator"
Assert-Condition ([string]$manifest.generator.name -eq $script:GeneratorName) "Unexpected C# documentation example generator."
Assert-Condition (-not [string]::IsNullOrWhiteSpace([string]$manifest.generator.version)) "C# example generator version is empty."

Assert-Properties -Object $manifest.schema -Required @("name", "version") -Allowed @("name", "version") `
    -Context "C# documentation example manifest.schema"
Assert-Condition ([string]$manifest.schema.name -eq $script:SchemaName -and [int]$manifest.schema.version -eq 1) `
    "Unexpected C# documentation example schema identity."

Assert-Properties -Object $manifest.source -Required @("repository", "revision", "revisionSource") `
    -Allowed @("repository", "revision", "revisionSource") -Context "C# documentation example manifest.source"
Assert-Condition ([string]$manifest.source.repository -eq $script:Repository) "Unexpected C# example source repository."
Assert-Condition ([string]$manifest.source.revision -eq "unknown" -or [string]$manifest.source.revision -match "^[0-9a-f]{40}$") `
    "C# example source revision is not immutable or explicitly unknown."
Assert-Condition ([string]$manifest.source.revisionSource -in @("argument", "environment", "git", "unknown")) `
    "C# example source revision source is invalid."

Assert-Properties -Object $manifest.scope `
    -Required @("mode", "configuration", "include", "exclude", "coverage") `
    -Allowed @("mode", "configuration", "include", "exclude", "coverage") `
    -Context "C# documentation example manifest.scope"
Assert-Condition ([string]$manifest.scope.mode -eq "bounded-representative") "C# example scope is not bounded-representative."
Assert-Properties -Object $manifest.scope.configuration -Required @("path", "sha256") -Allowed @("path", "sha256") `
    -Context "C# documentation example manifest.scope.configuration"
Assert-SafeRelativePath -Value ([string]$manifest.scope.configuration.path) -Context "C# example scope configuration path"
Assert-Hash -Value ([string]$manifest.scope.configuration.sha256) -Context "C# example scope configuration hash"
$scopePath = Join-Path $root ([string]$manifest.scope.configuration.path).Replace("/", "\")
Assert-Condition (Test-Path -LiteralPath $scopePath -PathType Leaf) "C# example scope configuration does not exist."
Assert-Condition ((Get-FileSha256 $scopePath) -eq [string]$manifest.scope.configuration.sha256) `
    "C# example scope configuration hash does not match."
Assert-Condition (@($manifest.scope.include).Count -gt 0) "C# example scope include list is empty."
Assert-Condition ((@($manifest.scope.include | Sort-Object -Unique) -join "`n") -eq (@($manifest.scope.include | Sort-Object) -join "`n")) `
    "C# example scope include paths contain duplicates."
Assert-Properties -Object $manifest.scope.coverage `
    -Required @("pageCount", "csharpBlockCount", "fullCorpusAudited", "notes") `
    -Allowed @("pageCount", "csharpBlockCount", "fullCorpusAudited", "notes") `
    -Context "C# documentation example manifest.scope.coverage"
Assert-Condition (-not [bool]$manifest.scope.coverage.fullCorpusAudited) "The bounded C# example scope cannot claim full-corpus coverage."

Assert-Properties -Object $manifest.generation `
    -Required @("deterministic", "contentHashAlgorithm", "generatedContent") `
    -Allowed @("deterministic", "contentHashAlgorithm", "generatedContent") `
    -Context "C# documentation example manifest.generation"
Assert-Condition ([bool]$manifest.generation.deterministic -and [string]$manifest.generation.contentHashAlgorithm -eq "sha256") `
    "C# example determinism metadata is missing."
Assert-Condition ((@($manifest.generation.generatedContent) -join ",") -eq "complete-example-projects") `
    "C# example generated content metadata is incorrect."

Assert-Properties -Object $manifest.counts `
    -Required @("pageCount", "csharpBlockCount", "complete", "fragment", "pseudocode", "invalidMetadata", "compiled", "failed", "notAttempted") `
    -Allowed @("pageCount", "csharpBlockCount", "complete", "fragment", "pseudocode", "invalidMetadata", "compiled", "failed", "notAttempted") `
    -Context "C# documentation example manifest.counts"

$examples = @($manifest.examples)
$expectedCount = [int]$manifest.counts.csharpBlockCount
Assert-Condition ($examples.Count -eq $expectedCount) "C# example count does not match manifest.counts."
Assert-Condition ([int]$manifest.counts.pageCount -eq [int]$manifest.scope.coverage.pageCount) "C# example page counts disagree."
Assert-Condition ([int]$manifest.counts.csharpBlockCount -eq [int]$manifest.scope.coverage.csharpBlockCount) "C# example block counts disagree."

$expectedOrder = @($examples | Sort-Object sourcePage, codeBlockIndex)
for ($index = 0; $index -lt $examples.Count; $index++) {
    Assert-Condition ([string]$examples[$index].id -eq [string]$expectedOrder[$index].id) `
        "C# documentation examples are not sorted deterministically."
}

$manifestOutputRoot = Split-Path -Parent $manifestPath
$expectedProjectPaths = New-Object "System.Collections.Generic.HashSet[string]"
$classificationCounts = @{
    complete = 0
    fragment = 0
    pseudocode = 0
    invalidMetadata = 0
    compiled = 0
    failed = 0
    notAttempted = 0
}
$seenIds = @{}

foreach ($example in $examples) {
    $context = "C# documentation example '$($example.id)'"
    Assert-Condition (-not $seenIds.ContainsKey([string]$example.id)) "$context is duplicated."
    $seenIds[[string]$example.id] = $true
    Assert-Condition ([string]$example.sourcePage -notmatch "\\") "$context source page uses a Windows separator."
    Assert-SafeRelativePath -Value ([string]$example.sourcePage) -Context "$context source page"
    $sourcePagePath = Join-Path $root ([string]$example.sourcePage).Replace("/", "\")
    Assert-Condition (Test-Path -LiteralPath $sourcePagePath -PathType Leaf) "$context source page does not exist."
    Assert-Hash -Value ([string]$example.sourcePageHash) -Context "$context source page hash"
    Assert-Condition ((Get-TextSha256 (Get-Content -LiteralPath $sourcePagePath -Raw)) -eq [string]$example.sourcePageHash) `
        "$context source page hash does not match the current page."
    Assert-Hash -Value ([string]$example.sourceCodeHash) -Context "$context source code hash"
    Assert-Condition ([int]$example.sourceLineStart -le [int]$example.sourceLineEnd) "$context source line range is invalid."
    Assert-Condition ([int]$example.codeBlockIndex -ge 1) "$context code block index is invalid."
    Assert-Condition ([string]$example.classification -in @("complete", "fragment", "pseudocode")) "$context classification is invalid."
    Assert-Condition ([string]$example.classificationSource -in @("fence-info", "comment", "missing")) "$context classification source is invalid."
    Assert-Properties -Object $example.metadata `
        -Required @("classification", "framework", "packages") `
        -Allowed @("classification", "framework", "packages") `
        -Context "$context metadata"
    Assert-Properties -Object $example.result `
        -Required @("status", "reason", "projectPath", "sourcePath", "assemblyPath", "diagnosticHash") `
        -Allowed @("status", "reason", "projectPath", "sourcePath", "assemblyPath", "diagnosticHash") `
        -Context "$context result"

    $classification = [string]$example.classification
    $classificationCounts[$classification]++
    $declared = [string]$example.declaredClassification
    $declaredNormalized = $declared.ToLowerInvariant()
    if ($declaredNormalized -in @("complete", "compilable")) {
        Assert-Condition ($classification -eq "complete") "$context declared complete but was not classified complete."
    }
    if ($classification -eq "complete") {
        Assert-Condition ($declaredNormalized -in @("complete", "compilable")) "$context is complete without an explicit complete declaration."
        Assert-Condition ([string]$example.targetFramework -match "^net(?:standard|coreapp)?[0-9]+(?:\.[0-9]+)?(?:-[A-Za-z0-9.]+)?$") `
            "$context target framework is not exact."
        if (@($example.packages).Count -eq 0) {
            Assert-Condition ([string]$example.metadata.packages -ieq "none") "$context does not explicitly declare packages=none."
        }
        else {
            Assert-Condition ([string]$example.metadata.packages -ine "not_applicable") "$context package metadata is missing."
        }
        foreach ($package in @($example.packages)) {
            Assert-Properties -Object $package -Required @("id", "version") -Allowed @("id", "version") -Context "$context package"
            Assert-Condition ([string]$package.id -match "^[A-Za-z0-9_.-]+$") "$context package ID is invalid."
            Assert-Condition ([string]$package.version -match "^[0-9][A-Za-z0-9+.-]*$") "$context package version is not exact."
        }

        Assert-Condition ([string]$example.result.status -eq "compiled") "$context was not compiled successfully."
        Assert-ProjectPath -Value ([string]$example.result.projectPath) -Context "$context result project path"
        Assert-ProjectPath -Value ([string]$example.result.sourcePath) -Context "$context result source path"
        Assert-ProjectPath -Value ([string]$example.result.assemblyPath) -Context "$context result assembly path"
        Assert-Condition ([string]$example.result.diagnosticHash -eq "not_applicable") `
            "$context has non-deterministic diagnostics for a successful build."

        $projectRelativePath = [string]$example.result.projectPath
        $projectPath = Join-Path $manifestOutputRoot $projectRelativePath.Replace("/", "\")
        Assert-Condition (Test-Path -LiteralPath $projectPath -PathType Leaf) "$context generated project does not exist."
        $projectSourcePath = Join-Path $manifestOutputRoot ([string]$example.result.sourcePath).Replace("/", "\")
        Assert-Condition (Test-Path -LiteralPath $projectSourcePath -PathType Leaf) "$context generated source does not exist."
        $assemblyPath = Join-Path $manifestOutputRoot ([string]$example.result.assemblyPath).Replace("/", "\")
        Assert-Condition (Test-Path -LiteralPath $assemblyPath -PathType Leaf) "$context compiled assembly does not exist."
        $projectText = Get-Content -LiteralPath $projectPath -Raw
        Assert-Condition ($projectText -notmatch "(?i)(password|secret|token|AZURE_|NUGET_AUTH)") `
            "$context generated project contains a credential-like value."
        try {
            $project = [xml]$projectText
        }
        catch {
            throw "$context generated project is not valid XML: $($_.Exception.Message)"
        }
        Assert-Condition ([string]$project.Project.PropertyGroup.TargetFramework -eq [string]$example.targetFramework) `
            "$context project target framework does not match its manifest."
        $compilePaths = Get-ProjectCompilePaths -Project $project
        Assert-Condition (($compilePaths -join "`n") -eq "Example.cs") `
            "$context project does not compile exactly its isolated Example.cs source."
        $expectedPackages = @($example.packages | ForEach-Object { "$($_.id)@$($_.version)" } | Sort-Object)
        $actualPackages = Get-ProjectPackageKeys -Project $project
        Assert-Condition (($actualPackages -join "`n") -eq ($expectedPackages -join "`n")) `
            "$context project package references do not match declared package references."
        [void]$expectedProjectPaths.Add($projectRelativePath)
        $classificationCounts.compiled++
    }
    else {
        Assert-Condition ($declaredNormalized -notin @("complete", "compilable")) "$context has an invalid complete declaration."
        Assert-Condition ([string]$example.result.status -eq "not-attempted") "$context was presented as independently compilable."
        foreach ($propertyName in @("projectPath", "sourcePath", "assemblyPath")) {
            Assert-Condition ([string]$example.result.$propertyName -eq "not_applicable") `
                "$context has generated output for a non-complete classification."
        }
        Assert-Condition ([string]$example.result.diagnosticHash -eq "not_applicable") `
            "$context has compiler diagnostics despite not being compiled."
        $classificationCounts.notAttempted++
        if ([string]$example.classificationReason -eq "invalid-complete-metadata") {
            $classificationCounts.invalidMetadata++
        }
    }
}

Assert-Condition ([int]$manifest.counts.complete -eq $classificationCounts.complete) "Complete example count is incorrect."
Assert-Condition ([int]$manifest.counts.fragment -eq $classificationCounts.fragment) "Fragment example count is incorrect."
Assert-Condition ([int]$manifest.counts.pseudocode -eq $classificationCounts.pseudocode) "Pseudocode example count is incorrect."
Assert-Condition ([int]$manifest.counts.invalidMetadata -eq $classificationCounts.invalidMetadata) "Invalid metadata count is incorrect."
Assert-Condition ([int]$manifest.counts.compiled -eq $classificationCounts.compiled) "Compiled example count is incorrect."
Assert-Condition ([int]$manifest.counts.failed -eq 0) "A complete example failed compilation."
Assert-Condition ([int]$manifest.counts.notAttempted -eq $classificationCounts.notAttempted) "Not-attempted example count is incorrect."
Assert-Condition ([int]$manifest.counts.notAttempted -eq ([int]$manifest.counts.fragment + [int]$manifest.counts.pseudocode)) `
    "Only fragments and pseudocode may be not-attempted."
Assert-Condition ($manifestJson -notmatch '```') "C# source code must not be copied into the metadata manifest."

$projectsDirectory = Join-Path $manifestOutputRoot "projects"
$actualProjectPaths = @()
if (Test-Path -LiteralPath $projectsDirectory -PathType Container) {
    $actualProjectPaths = @(Get-ChildItem -LiteralPath $projectsDirectory -Recurse -File -Filter "*.csproj" |
        ForEach-Object { ConvertTo-RepositoryRelativePath -Path $_.FullName -Root $manifestOutputRoot })
}
$actualProjectKey = (($actualProjectPaths | Sort-Object) -join "`n")
$expectedProjectKey = (($expectedProjectPaths | Sort-Object) -join "`n")
Assert-Condition ($actualProjectKey -eq $expectedProjectKey) "Generated projects do not exactly match complete examples."

Write-Output "C# documentation example manifest is valid: $($examples.Count) block(s), $($manifest.counts.compiled) compiled, $($manifest.counts.notAttempted) not attempted."
