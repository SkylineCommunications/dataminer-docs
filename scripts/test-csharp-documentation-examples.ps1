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

$repositoryRoot = [IO.Path]::GetFullPath((Join-Path $PSScriptRoot ".."))
$generator = Join-Path $PSScriptRoot "generate-csharp-documentation-examples.ps1"
$validator = Join-Path $PSScriptRoot "validate-csharp-documentation-examples.ps1"
$fixtureRoot = Join-Path ([IO.Path]::GetTempPath()) ("dataminer-docs-csharp-examples-" + [Guid]::NewGuid().ToString("N"))
$outputOne = Join-Path $fixtureRoot "_artifacts\one"
$outputTwo = Join-Path $fixtureRoot "_artifacts\two"
$revision = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"

try {
    New-Item -ItemType Directory -Path $fixtureRoot -Force | Out-Null
    Write-TestFile $fixtureRoot "scope.json" @'
{
  "schemaVersion": 1,
  "format": "csharp-documentation-example-scope",
  "include": [
    "complete.md",
    "fragment.md",
    "pseudocode.md",
    "explicit-fragment.md"
  ],
  "exclude": [],
  "defaultClassification": "fragment",
  "conventions": [
    "Fixture convention."
  ],
  "gaps": [
    "The fixture is intentionally smaller than the documentation corpus."
  ]
}
'@
    Write-TestFile $fixtureRoot "complete.md" @'
---
uid: CSharp_Complete_Fixture
---

# Complete C# fixture

<!-- csharp-example: complete; framework=net8.0; packages=none -->
```csharp
using System;

public static class CompleteFixture
{
    public static string GetValue()
    {
        return "compiled";
    }
}
```
'@
    Write-TestFile $fixtureRoot "fragment.md" @'
---
uid: CSharp_Fragment_Fixture
---

# Fragment C# fixture

```csharp
engine.GenerateInformation("The host supplies the engine object.");
```
'@
    Write-TestFile $fixtureRoot "pseudocode.md" @'
---
uid: CSharp_Pseudocode_Fixture
---

# Pseudocode C# fixture

```csharp example=pseudocode
open the selected element and display its current state
```
'@
    Write-TestFile $fixtureRoot "explicit-fragment.md" @'
---
uid: CSharp_Explicit_Fragment_Fixture
---

# Explicit fragment C# fixture

```cs example=fragment framework=net8.0 packages=none
var value = hostProvidedValue;
```
'@

    & $generator -RepositoryRoot $fixtureRoot -ScopePath (Join-Path $fixtureRoot "scope.json") `
        -OutputPath $outputOne -SourceRevision $revision
    & $validator -RepositoryRoot $fixtureRoot `
        -Path (Join-Path $outputOne "csharp-documentation-examples.json") `
        -SchemaPath (Join-Path $repositoryRoot "contributing\metadata\csharp-documentation-example-v1.schema.json")

    & $generator -RepositoryRoot $fixtureRoot -ScopePath (Join-Path $fixtureRoot "scope.json") `
        -OutputPath $outputTwo -SourceRevision $revision
    $manifestOne = Join-Path $outputOne "csharp-documentation-examples.json"
    $manifestTwo = Join-Path $outputTwo "csharp-documentation-examples.json"
    Assert-Condition ((Get-FileHash -LiteralPath $manifestOne -Algorithm SHA256).Hash -eq
        (Get-FileHash -LiteralPath $manifestTwo -Algorithm SHA256).Hash) `
        "Repeated C# example generation was not byte-identical."

    $manifest = Get-Content -LiteralPath $manifestOne -Raw | ConvertFrom-Json
    Assert-Condition ([int]$manifest.counts.pageCount -eq 4) "The fixture page count is incorrect."
    Assert-Condition ([int]$manifest.counts.csharpBlockCount -eq 4) "The fixture C# block count is incorrect."
    Assert-Condition ([int]$manifest.counts.complete -eq 1) "The fixture complete count is incorrect."
    Assert-Condition ([int]$manifest.counts.fragment -eq 2) "The fixture fragment count is incorrect."
    Assert-Condition ([int]$manifest.counts.pseudocode -eq 1) "The fixture pseudocode count is incorrect."
    Assert-Condition ([int]$manifest.counts.compiled -eq 1) "The complete fixture did not compile."
    Assert-Condition ([int]$manifest.counts.notAttempted -eq 3) "The non-complete fixture count is incorrect."
    Assert-Condition (@($manifest.examples | Where-Object { $_.classification -ne "complete" -and $_.result.projectPath -ne "not_applicable" }).Count -eq 0) `
        "A fragment or pseudocode fixture was presented as independently compilable."

    $invalidRoot = Join-Path $fixtureRoot "invalid"
    New-Item -ItemType Directory -Path $invalidRoot -Force | Out-Null
    Write-TestFile $invalidRoot "scope.json" @'
{
  "schemaVersion": 1,
  "format": "csharp-documentation-example-scope",
  "include": [
    "invalid.md"
  ],
  "exclude": [],
  "defaultClassification": "fragment",
  "conventions": [
    "Fixture convention."
  ],
  "gaps": []
}
'@
    Write-TestFile $invalidRoot "invalid.md" @'
---
uid: CSharp_Invalid_Fixture
---

<!-- csharp-example: complete; framework=net8.0 -->
```csharp
public class InvalidFixture
{
}
```
'@
    $failed = $false
    try {
        & $generator -RepositoryRoot $invalidRoot -ScopePath (Join-Path $invalidRoot "scope.json") `
            -OutputPath (Join-Path $invalidRoot "_artifacts") -SourceRevision $revision
    }
    catch {
        $failed = $true
    }
    Assert-Condition $failed "The C# example generator accepted complete metadata without a package declaration."

    $compileFailureRoot = Join-Path $fixtureRoot "compile-failure"
    New-Item -ItemType Directory -Path $compileFailureRoot -Force | Out-Null
    Write-TestFile $compileFailureRoot "scope.json" @'
{
  "schemaVersion": 1,
  "format": "csharp-documentation-example-scope",
  "include": [
    "compile-failure.md"
  ],
  "exclude": [],
  "defaultClassification": "fragment",
  "conventions": [
    "Fixture convention."
  ],
  "gaps": []
}
'@
    Write-TestFile $compileFailureRoot "compile-failure.md" @'
---
uid: CSharp_Compile_Failure_Fixture
---

<!-- csharp-example: complete; framework=net8.0; packages=none -->
```csharp
public static class CompileFailureFixture
{
    public static string GetValue()
    {
        return;
    }
}
```
'@
    $failed = $false
    try {
        & $generator -RepositoryRoot $compileFailureRoot `
            -ScopePath (Join-Path $compileFailureRoot "scope.json") `
            -OutputPath (Join-Path $compileFailureRoot "_artifacts") -SourceRevision $revision
    }
    catch {
        $failed = $true
    }
    Assert-Condition $failed "The C# example generator accepted a project that failed compilation."

    $global:LASTEXITCODE = 0
    Write-Output "C# documentation example harness tests passed."
}
finally {
    if (Test-Path -LiteralPath $fixtureRoot) {
        Remove-Item -LiteralPath $fixtureRoot -Recurse -Force
    }
}
