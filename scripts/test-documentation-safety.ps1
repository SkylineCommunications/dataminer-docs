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

function Get-Report {
    param([Parameter(Mandatory = $true)][string]$Path)

    Assert-Condition (Test-Path -LiteralPath $Path -PathType Leaf) "Expected D4.4 report '$Path' was not written."
    return Get-Content -LiteralPath $Path -Raw | ConvertFrom-Json
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

$repositoryRoot = [IO.Path]::GetFullPath((Join-Path $PSScriptRoot ".."))
$validator = Join-Path $PSScriptRoot "validate-documentation-safety.ps1"
$rulesPath = Join-Path $PSScriptRoot "d4-4-documentation-safety-rules.json"
$fixtureRoot = Join-Path $PSScriptRoot "fixtures\documentation-safety"
$sourceRoot = Join-Path $fixtureRoot "source"
$artifactRoot = Join-Path $fixtureRoot "artifacts"
$internalRoot = Join-Path $artifactRoot "internal-only-topic-packs"
$testOutputRoot = Join-Path $fixtureRoot "_test-output"
$validReportOne = Join-Path $testOutputRoot "valid-one.json"
$validReportTwo = Join-Path $testOutputRoot "valid-two.json"
$invalidReport = Join-Path $testOutputRoot "invalid.json"
$legacyRoot = Join-Path ([IO.Path]::GetTempPath()) ("dataminer-docs-safety-baseline-" + [Guid]::NewGuid().ToString("N"))
$legacyReport = Join-Path $legacyRoot "report.json"

try {
    New-Item -ItemType Directory -Path $testOutputRoot -Force | Out-Null

    $safePaths = @(
        (Join-Path $sourceRoot "valid.md"),
        (Join-Path $sourceRoot "legacy.md"),
        (Join-Path $artifactRoot "safe-report.json"),
        (Join-Path $internalRoot "internal-only-safe.md")
    )
    & $validator `
        -RepositoryRoot $repositoryRoot `
        -RulesPath $rulesPath `
        -Path $safePaths `
        -ReportPath $validReportOne | Out-Null
    & $validator `
        -RepositoryRoot $repositoryRoot `
        -RulesPath $rulesPath `
        -Path $safePaths `
        -ReportPath $validReportTwo | Out-Null

    $validReport = Get-Report -Path $validReportOne
    $validJson = Get-Content -LiteralPath $validReportOne -Raw
    $validIds = @($validReport.findings | ForEach-Object { [string]$_.ruleId })
    Assert-Condition ([int]$validReport.summary.newFindings -eq 0) "Allowlisted D4.4 fixture content produced a new finding."
    Assert-Condition ([int]$validReport.summary.allowlisted -ge 3) "Explicit legacy, conditional, placeholder, or negative-example allowlists were not reported."
    Assert-Condition ([int]$validReport.summary.gaps -ge 1) "The unmarked code block did not remain a reported classification gap."
    Assert-Condition (@($validReport.findings | Where-Object { $_.scope -eq "internal-only-generated-artifact" }).Count -eq 0) `
        "The safe internal-only artifact unexpectedly produced a finding."
    Assert-Condition ($validJson -notmatch "ghp_") "A credential-shaped value entered the D4.4 report."
    Assert-Condition ((Get-FileHash -LiteralPath $validReportOne -Algorithm SHA256).Hash -eq
        (Get-FileHash -LiteralPath $validReportTwo -Algorithm SHA256).Hash) `
        "Repeated D4.4 report generation was not byte-identical."

    $unsafePaths = @(
        (Join-Path $sourceRoot "invalid.md"),
        (Join-Path $artifactRoot "leaked-report.json"),
        (Join-Path $internalRoot "internal-only-leak.json")
    )
    Invoke-ExpectedFailure -Action {
        & $validator `
            -RepositoryRoot $repositoryRoot `
            -RulesPath $rulesPath `
            -Path $unsafePaths `
            -ReportPath $invalidReport | Out-Null
    } -Message "Unsafe D4.4 fixture content passed the safety gate."

    $invalidResult = Get-Report -Path $invalidReport
    $invalidRuleIds = @($invalidResult.findings | ForEach-Object { [string]$_.ruleId })
    foreach ($requiredRule in @(
            "obsolete-engine-signature",
            "obsolete-interactive-run",
            "interactive-dialog-conflict",
            "dropdown-noun",
            "certificate-validation-bypass",
            "unsafe-exception-logging",
            "insecure-sample-credential",
            "github-token"
        )) {
        Assert-Condition ($invalidRuleIds -contains $requiredRule) "D4.4 did not report '$requiredRule'."
    }
    Assert-Condition (@($invalidResult.findings | Where-Object {
                $_.scope -eq "internal-only-generated-artifact" -and $_.ruleId -eq "insecure-sample-credential"
            }).Count -eq 1) "Internal-only generated artifacts were not scanned and scoped explicitly."
    $invalidJson = Get-Content -LiteralPath $invalidReport -Raw
    Assert-Condition ($invalidJson -notmatch "ghp_") "The raw token entered the D4.4 report."
    Assert-Condition ($invalidJson -notmatch '"admin"') "The insecure sample credential entered the D4.4 report."

    New-Item -ItemType Directory -Path $legacyRoot -Force | Out-Null
    Write-TestFile -Path (Join-Path $legacyRoot "page.md") -Content @'
# Existing finding

Use the dropdown here.

<!-- documentation-safety: context=legacy -->
```csharp
public void Run(Engine engine)
{
    controller.Run(dialog);
}
```
'@
    & git -C $legacyRoot init --quiet
    & git -C $legacyRoot config user.email "d4-4-test@example.invalid"
    & git -C $legacyRoot config user.name "D4.4 test"
    & git -C $legacyRoot add page.md
    & git -C $legacyRoot commit --quiet -m "baseline"
    $legacyRevision = ([string](& git -C $legacyRoot rev-parse HEAD)).Trim()

    & $validator `
        -RepositoryRoot $legacyRoot `
        -AuthorityRoot $repositoryRoot `
        -RulesPath $rulesPath `
        -BaseRevision $legacyRevision `
        -Path "page.md" `
        -ReportPath $legacyReport | Out-Null
    $legacyResult = Get-Report -Path $legacyReport
    Assert-Condition ([int]$legacyResult.summary.newFindings -eq 0) "Pre-existing D4.4 findings were treated as new failures."
    Assert-Condition ([int]$legacyResult.summary.legacyExceptions -ge 1) "Pre-existing D4.4 findings were not retained as legacy_exception findings."

    Assert-Condition ($validIds -contains "certificate-validation-bypass") "The negative-example allowlist was not recorded."
    Write-Output "Documentation safety checks passed."
}
finally {
    if (Test-Path -LiteralPath $testOutputRoot) {
        Remove-Item -LiteralPath $testOutputRoot -Recurse -Force
    }
    if (Test-Path -LiteralPath $legacyRoot) {
        Remove-Item -LiteralPath $legacyRoot -Recurse -Force
    }
}
