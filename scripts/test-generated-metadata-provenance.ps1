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

function Get-Hash {
    param([Parameter(Mandatory = $true)][string]$Path)

    return (Get-FileHash -LiteralPath $Path -Algorithm SHA256).Hash.ToLowerInvariant()
}

$repositoryRoot = [IO.Path]::GetFullPath((Join-Path $PSScriptRoot ".."))
$generator = Join-Path $PSScriptRoot "generate-generated-metadata-provenance.ps1"
$validator = Join-Path $PSScriptRoot "validate-generated-metadata-provenance.ps1"
$fixtureRoot = Join-Path ([IO.Path]::GetTempPath()) ("dataminer-docs-provenance-" + [Guid]::NewGuid().ToString("N"))
$packageRoot = Join-Path $fixtureRoot "nuget-cache"
$outputOne = Join-Path $fixtureRoot "provenance-one.json"
$outputTwo = Join-Path $fixtureRoot "provenance-two.json"
$outputThree = Join-Path $fixtureRoot "provenance-three.json"
$outputFour = Join-Path $fixtureRoot "provenance-four.json"
$outputFive = Join-Path $fixtureRoot "provenance-five.json"
$outputSix = Join-Path $fixtureRoot "provenance-six.json"
$externalRoot = Join-Path ([IO.Path]::GetTempPath()) ("dataminer-docs-external-schema-" + [Guid]::NewGuid().ToString("N"))
$oldNuGetPackages = $env:NUGET_PACKAGES

try {
    New-Item -ItemType Directory -Path $fixtureRoot -Force | Out-Null
    New-Item -ItemType Directory -Path $packageRoot -Force | Out-Null
    $env:NUGET_PACKAGES = $packageRoot

    $sourcePath = Join-Path $fixtureRoot "src\Fixture\Fixture.cs"
    Write-TestFile $fixtureRoot "src\Fixture\Fixture.csproj" @'
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <AssemblyName>Fixture</AssemblyName>
    <GenerateDocumentationFile>true</GenerateDocumentationFile>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include="Example.Package" Version="1.2.3" />
  </ItemGroup>
</Project>
'@
    Write-TestFile $fixtureRoot "src\Fixture\Fixture.cs" @'
/// <summary>Fixture type.</summary>
public class FixtureType { }
'@
    Write-TestFile $fixtureRoot "src\Fixture\bin\Release\Fixture.dll" "different-build-output"
    Write-TestFile $fixtureRoot "src\Fixture\bin\Release\Fixture.xml" @'
<?xml version="1.0"?>
<doc>
  <assembly><name>Fixture</name></assembly>
  <members>
    <member name="T:Fixture.Type"><summary>Build output documentation deprecated since 10.6.</summary></member>
    <member name="M:Fixture.Type.Parse(System.String)">
      <summary>Parses a build output value introduced in 10.5.</summary>
      <param name="value">This required value has default 7, is in the range 1 to 9, and must be one of red or blue.</param>
    </member>
  </members>
</doc>
'@
    Write-TestFile $fixtureRoot "src\Fixture\obj\project.assets.json" @'
{
  "version": 3,
  "libraries": {
    "Example.Package/1.2.3": {
      "type": "package",
      "sha512": "fixture"
    }
  }
}
'@
    Write-TestFile $fixtureRoot "assemblies\Fixture.dll" "not-a-real-assembly"
    Write-TestFile $fixtureRoot "assemblies\Fixture.xml" @'
<?xml version="1.0"?>
<doc>
  <assembly>
    <name>Fixture</name>
  </assembly>
  <members>
    <member name="T:Fixture.Type">
      <summary>This type is deprecated since 10.6.</summary>
      <remarks>Manual API remarks are retained.</remarks>
      <example><code>new Fixture.Type()</code></example>
    </member>
    <member name="M:Fixture.Type.Parse(System.String)">
      <summary>Parses a fixture value introduced in 10.5.</summary>
      <param name="value">This required value has default 7, is in the range 1 to 9, and must be one of red or blue.</param>
      <returns>The parsed value.</returns>
    </member>
  </members>
</doc>
'@

    $apiSource = $sourcePath
    Write-TestFile $fixtureRoot "develop\api\types\Fixture.yml" @"
### YamlMime:ManagedReference
items:
- uid: Fixture.Type
  commentId: T:Fixture.Type
  type: Class
  source:
    id: Type
    path: $apiSource
    startLine: 1
  assemblies:
  - Fixture
  summary: Fixture type.
  remarks: Manual API remarks are retained.
  example: []
  syntax:
    content: public class Type
- uid: Fixture.Type.Parse
  commentId: M:Fixture.Type.Parse(System.String)
  type: Method
  assemblies:
  - Fixture
  summary: Parses a fixture value.
  syntax:
    content: public static Type Parse(string value)
    parameters:
    - id: value
      type: System.String
references: []
"@
    Write-TestFile $fixtureRoot "develop\api\types\toc.yml" @'
### YamlMime:TableOfContent
items:
- name: Fixture
'@
    Write-TestFile $fixtureRoot "develop\schemadoc\SchemaProtocol.md" @'
---
uid: SchemaProtocol
---

# Protocol schema

The Protocol XML schema package 1.2.3.
'@
    Write-TestFile $fixtureRoot "develop\schemadoc\Protocol\Fixture.md" @'
---
uid: Fixture.Schema
---

# Fixture schema

## Attributes

| Name | Type | Required | Default | Range |
| --- | --- | --- | --- | --- |
| value | integer | Yes | 7 | 1 to 9 |

## Values

| Value | Description |
| --- | --- |
| red | Red |
| blue | Blue |

## Remarks

These remarks are manual.

## Examples

```xml
<Fixture />
```

## Lifecycle

| Constraint | Value |
| --- | --- |
| Introduced | 10.5 |
| Deprecated | 10.6 |
| Removed | 11.0 |

## Constraints

| Type | Description | Selector | Fields |
| --- | --- | --- | --- |
| Key | A value must be unique. | Fixture/value | @id |

Introduced in 10.5.
Deprecated since 10.6.
Removed in 11.0.
'@
    Write-TestFile $fixtureRoot "overwrite\Fixture.md" @'
---
uid: Fixture.Type
---

# Fixture type

## Remarks

Manual overwrite remarks.
'@
    Write-TestFile $fixtureRoot "overwrite\Unrelated.md" @'
---
uid: Fixture.Type.Parse
---

Manual method override.
'@
    Write-TestFile $fixtureRoot "docfx.json" @'
{
  "metadata": [
    {
      "src": [
        {
          "files": [
            "src/**.csproj",
            "assemblies/**.dll"
          ],
          "exclude": [
            "**/obj/**"
          ]
        }
      ],
      "dest": "develop/api/types"
    }
  ],
  "build": {
    "overwrite": "overwrite/*.md"
  }
}
'@
    Write-TestFile $packageRoot "example.package\1.2.3\Example.Package.1.2.3.nupkg" "fixture package"
    Write-TestFile $packageRoot "example.package\1.2.3\Example.Package.nuspec" @'
<?xml version="1.0"?>
<package>
  <metadata>
    <id>Example.Package</id>
    <version>1.2.3</version>
    <authors>Fixture Author</authors>
    <license type="expression">MIT</license>
  </metadata>
</package>
'@

    & $generator `
        -RepositoryRoot $fixtureRoot `
        -DocFxConfigPath (Join-Path $fixtureRoot "docfx.json") `
        -ApiOutputPath (Join-Path $fixtureRoot "develop\api\types") `
        -SchemaOutputPath (Join-Path $fixtureRoot "develop\schemadoc") `
        -OutputPath $outputOne `
        -ValidatorPath $validator `
        -SourceRevision "fixture" `
        -GenerationDate "2026-09-17" | Out-Null
    & $generator `
        -RepositoryRoot $fixtureRoot `
        -DocFxConfigPath (Join-Path $fixtureRoot "docfx.json") `
        -ApiOutputPath (Join-Path $fixtureRoot "develop\api\types") `
        -SchemaOutputPath (Join-Path $fixtureRoot "develop\schemadoc") `
        -OutputPath $outputTwo `
        -ValidatorPath $validator `
        -SourceRevision "fixture" `
        -GenerationDate "2026-09-17" | Out-Null

    Assert-Condition ((Get-Hash $outputOne) -eq (Get-Hash $outputTwo)) "Repeated provenance runs produced different JSON."
    & $validator -RepositoryRoot $fixtureRoot -Path $outputOne -SchemaPath (Join-Path $repositoryRoot "contributing\metadata\generated-metadata-provenance-v1.schema.json") | Out-Null

    $manifest = Get-Content -LiteralPath $outputOne -Raw | ConvertFrom-Json
    Assert-Condition ($manifest.generatedAt -eq "2026-09-17") "The explicit generation date was not retained."
    Assert-Condition ($manifest.generatedAtSource -eq "argument") "The generation date source was not retained."
    Assert-Condition (@($manifest.outputs.api).Count -eq 1) "The API fixture output was not recorded."
    Assert-Condition (@($manifest.outputs.api | Where-Object { $_.path -like "*/toc.yml" }).Count -eq 0) "The DocFX TOC was incorrectly recorded as an API output."
    Assert-Condition (@($manifest.outputs.schema).Count -eq 1) "The schema fixture output was not recorded."
    $package = @($manifest.artifacts | Where-Object { $_.kind -eq "package" -and $_.identity -eq "Example.Package" })[0]
    Assert-Condition ($null -ne $package) "The package artifact was not recorded."
    Assert-Condition ($package.version -eq "1.2.3") "The package version was not recorded."
    Assert-Condition ($package.file.available) "The restored package artifact was not hashed."
    Assert-Condition ($package.license -eq "MIT") "The package license was not read from the nuspec."
    $api = @($manifest.outputs.api)[0]
    Assert-Condition ($api.generated.memberCount -eq 2) "The generated API member count was not recorded."
    Assert-Condition ($api.url -eq "develop/api/types/Fixture.html") "The DocFX API URL was not recorded."
    Assert-Condition ($null -ne $api.file.canonicalSha256) "The canonical API output hash was not recorded."
    Assert-Condition ($api.manual.remarksCount -ge 1) "The API manual remarks boundary was not recorded."
    Assert-Condition ($api.manual.overwriteCount -eq 2) "The API overwrite boundary was not recorded."
    Assert-Condition (@($api.facts.deprecated).Count -ge 1) "The API deprecated constraint was not recorded."
    Assert-Condition (@($api.facts.required).Count -ge 1) "The API required constraint was not recorded."
    Assert-Condition (@($api.facts.defaults).Count -ge 1) "The API default constraint was not recorded."
    Assert-Condition (@($api.facts.ranges).Count -ge 1) "The API range constraint was not recorded."
    Assert-Condition (@($api.facts.enums).Count -ge 1) "The API enum constraint was not recorded."
    $apiAssemblies = @($api.artifactIds | Where-Object { $_ -like "assembly:*" })
    Assert-Condition ($apiAssemblies.Count -eq 1) "Duplicate simple-name assemblies were attached to the API output."
    $selectedAssembly = @($manifest.artifacts | Where-Object { $_.id -eq $apiAssemblies[0] })[0]
    Assert-Condition ($selectedAssembly.sourceProject -eq "src/Fixture/Fixture.csproj") "The API source project did not select its matching assembly."
    Assert-Condition (@($api.artifactIds | Where-Object { $_ -like "package:*Example.Package*" }).Count -eq 1) "The API package provenance link was not recorded."
    $schema = @($manifest.outputs.schema)[0]
    Assert-Condition (@($schema.facts.required).Count -eq 1) "The schema required constraint was not recorded."
    Assert-Condition (@($schema.facts.defaults).Count -eq 1) "The schema default constraint was not recorded."
    Assert-Condition (@($schema.facts.ranges).Count -eq 1) "The schema range constraint was not recorded."
    Assert-Condition (@($schema.facts.enums).Count -eq 2) "The schema enum constraints were not recorded."
    Assert-Condition (@($schema.facts.structural).Count -eq 1) "The schema structural constraint was not recorded."
    Assert-Condition (@($schema.facts.introduced).Count -eq 1) "The schema introduced constraint was not recorded."
    Assert-Condition (@($schema.facts.deprecated).Count -eq 1) "The schema deprecated constraint was not recorded."
    Assert-Condition (@($schema.facts.removed).Count -eq 1) "The schema removed constraint was not recorded."
    Assert-Condition (@($schema.manual.sectionNames | Where-Object { $_ -eq "Remarks" }).Count -eq 1) "The schema manual remarks boundary was not recorded."
    Assert-Condition (@($manifest.gaps | Where-Object { $_.code -eq "schema-source-artifact-not-present:SchemaProtocol" }).Count -eq 1) "The schema source gap was not recorded."

    $invalidPath = Join-Path $fixtureRoot "invalid-provenance.json"
    $manifest.schemaVersion = 2
    [IO.File]::WriteAllText($invalidPath, ($manifest | ConvertTo-Json -Depth 20))
    $invalidRejected = $false
    try {
        & $validator -RepositoryRoot $fixtureRoot -Path $invalidPath -SchemaPath (Join-Path $repositoryRoot "contributing\metadata\generated-metadata-provenance-v1.schema.json") | Out-Null
    }
    catch {
        $invalidRejected = $true
    }
    Assert-Condition $invalidRejected "The provenance validator accepted a schema-version mismatch."

    Write-TestFile $fixtureRoot "schemas\Protocol.xsd" @'
<?xml version="1.0"?>
<xs:schema xmlns:xs="http://www.w3.org/2001/XMLSchema" version="2.0" />
'@
    & $generator `
        -RepositoryRoot $fixtureRoot `
        -DocFxConfigPath (Join-Path $fixtureRoot "docfx.json") `
        -ApiOutputPath (Join-Path $fixtureRoot "develop\api\types") `
        -SchemaOutputPath (Join-Path $fixtureRoot "develop\schemadoc") `
        -SchemaSourcePath (Join-Path $fixtureRoot "schemas") `
        -OutputPath $outputThree `
        -ValidatorPath $validator `
        -SourceRevision "fixture" `
        -GenerationDate "2026-09-17" | Out-Null
    & $generator `
        -RepositoryRoot $fixtureRoot `
        -DocFxConfigPath (Join-Path $fixtureRoot "docfx.json") `
        -ApiOutputPath (Join-Path $fixtureRoot "develop\api\types") `
        -SchemaOutputPath (Join-Path $fixtureRoot "develop\schemadoc") `
        -SchemaSourcePath (Join-Path $fixtureRoot "schemas") `
        -OutputPath $outputFour `
        -ValidatorPath $validator `
        -SourceRevision "fixture" `
        -GenerationDate "2026-09-17" | Out-Null
    Assert-Condition ((Get-Hash $outputThree) -eq (Get-Hash $outputFour)) "Configured schema provenance is not deterministic."
    $configuredManifest = Get-Content -LiteralPath $outputThree -Raw | ConvertFrom-Json
    $configuredSchemaArtifact = @($configuredManifest.artifacts | Where-Object { $_.kind -eq "schema" -and $_.identity -eq "SchemaProtocol" })[0]
    Assert-Condition ($configuredSchemaArtifact.sourceType -eq "repository") "The configured schema source type was not retained."
    Assert-Condition ($configuredSchemaArtifact.version -eq "2.0") "The configured schema version was not read from the source artifact."
    Assert-Condition ($configuredSchemaArtifact.file.available) "The configured schema source was not linked to the schema output."
    Assert-Condition (@($configuredManifest.gaps | Where-Object { $_.code -eq "schema-source-artifact-not-present:SchemaProtocol" }).Count -eq 0) "A configured schema source was incorrectly reported as missing."

    Write-TestFile $externalRoot "Protocol.xsd" @'
<?xml version="1.0"?>
<xs:schema xmlns:xs="http://www.w3.org/2001/XMLSchema" version="3.0" />
'@
    & $generator `
        -RepositoryRoot $fixtureRoot `
        -DocFxConfigPath (Join-Path $fixtureRoot "docfx.json") `
        -ApiOutputPath (Join-Path $fixtureRoot "develop\api\types") `
        -SchemaOutputPath (Join-Path $fixtureRoot "develop\schemadoc") `
        -SchemaSourcePath $externalRoot `
        -OutputPath $outputFive `
        -ValidatorPath $validator `
        -SourceRevision "fixture" `
        -GenerationDate "2026-09-17" | Out-Null
    & $generator `
        -RepositoryRoot $fixtureRoot `
        -DocFxConfigPath (Join-Path $fixtureRoot "docfx.json") `
        -ApiOutputPath (Join-Path $fixtureRoot "develop\api\types") `
        -SchemaOutputPath (Join-Path $fixtureRoot "develop\schemadoc") `
        -SchemaSourcePath $externalRoot `
        -OutputPath $outputSix `
        -ValidatorPath $validator `
        -SourceRevision "fixture" `
        -GenerationDate "2026-09-17" | Out-Null
    Assert-Condition ((Get-Hash $outputFive) -eq (Get-Hash $outputSix)) "External schema provenance is not deterministic."
    $externalManifest = Get-Content -LiteralPath $outputFive -Raw | ConvertFrom-Json
    $externalSchemaArtifact = @($externalManifest.artifacts | Where-Object { $_.kind -eq "schema" -and $_.identity -eq "SchemaProtocol" })[0]
    Assert-Condition ($externalSchemaArtifact.sourceType -eq "external") "The external schema source type was not retained."
    Assert-Condition ($externalSchemaArtifact.file.available) "The external schema source was not hashed."
    Assert-Condition ($externalSchemaArtifact.file.path -like "external/*") "The external schema path was not made portable."

    Write-Output "Generated metadata provenance tests passed."
}
finally {
    if ([String]::IsNullOrWhiteSpace($oldNuGetPackages)) {
        Remove-Item Env:NUGET_PACKAGES -ErrorAction SilentlyContinue
    }
    else {
        $env:NUGET_PACKAGES = $oldNuGetPackages
    }
    if (Test-Path -LiteralPath $fixtureRoot) {
        Remove-Item -LiteralPath $fixtureRoot -Recurse -Force
    }
    if (Test-Path -LiteralPath $externalRoot) {
        Remove-Item -LiteralPath $externalRoot -Recurse -Force
    }
}
