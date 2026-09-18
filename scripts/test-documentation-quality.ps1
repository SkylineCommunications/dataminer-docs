[CmdletBinding()]
param()

Set-StrictMode -Version 2.0
$ErrorActionPreference = "Stop"

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

function Assert-Condition {
    param(
        [Parameter(Mandatory = $true)][bool]$Condition,
        [Parameter(Mandatory = $true)][string]$Message
    )

    if (-not $Condition) {
        throw $Message
    }
}

$fixtureRoot = Join-Path ([IO.Path]::GetTempPath()) ("dataminer-docs-quality-" + [Guid]::NewGuid().ToString("N"))
$validator = Join-Path $PSScriptRoot "validate-documentation-quality.ps1"

try {
    New-Item -ItemType Directory -Path $fixtureRoot -Force | Out-Null

    Write-TestFile $fixtureRoot "valid.md" @'
---
metadata_version: 1
uid: Quality_Valid_Fixture
version: 10.6.0
---

# Quality fixture

See [the fixture](xref:Quality_Valid_Fixture).

![A network topology diagram](images/topology.png)
'@

    Write-TestFile $fixtureRoot "invalid.md" @'
---
metadata_version: 1
uid: Quality_Invalid_Fixture
version: 10.2 - 10.4
---

# Invalid quality fixture

See [the legacy page](other.md).

![](images/missing-alt.png)
'@

    $baseline = [ordered]@{
        source = [ordered]@{
            uid = [ordered]@{
                duplicateUids = @(
                    [ordered]@{
                        uid = "Legacy_Duplicate"
                        paths = @("legacy-one.md", "legacy-two.md")
                    }
                )
                missingUidPaths = @("legacy.md")
            }
        }
        compatibility = @(
            [ordered]@{
                uid = "Legacy_Duplicate"
                href = "legacy-one.html"
            }
        )
        metadataManifest = [ordered]@{
            entries = @(
                [ordered]@{
                    uid = "Legacy_Duplicate"
                    url = "https://docs.dataminer.services/legacy-one.html"
                }
            )
        }
    }
    $baselinePath = Join-Path $fixtureRoot "docs-corpus-baseline.json"
    $currentPath = Join-Path $fixtureRoot "docs-corpus-baseline.generated.json"
    Write-TestFile $fixtureRoot "docs-corpus-baseline.json" ($baseline | ConvertTo-Json -Depth 10)
    Write-TestFile $fixtureRoot "docs-corpus-baseline.generated.json" ($baseline | ConvertTo-Json -Depth 10)

    $validReport = Join-Path $fixtureRoot "valid-report.json"
    & $validator `
        -RepositoryRoot $fixtureRoot `
        -BaselinePath $baselinePath `
        -CurrentBaselinePath $currentPath `
        -ReportPath $validReport `
        -Path "valid.md" `
        -SkipMarkdownLint
    $validResult = Get-Content -LiteralPath $validReport -Raw | ConvertFrom-Json
    Assert-Condition ($validResult.summary.newFindings -eq 0) "The valid fixture produced quality findings."
    Assert-Condition ($validResult.summary.legacyExceptions -eq 2) "The D0.2 legacy findings were not retained explicitly."

    $invalidReport = Join-Path $fixtureRoot "invalid-report.json"
    $invalidFailed = $false
    try {
        & $validator `
            -RepositoryRoot $fixtureRoot `
            -BaselinePath $baselinePath `
            -CurrentBaselinePath $currentPath `
            -ReportPath $invalidReport `
            -Path "invalid.md" `
            -SkipMarkdownLint `
            -SkipIdentityChecks
    }
    catch {
        $invalidFailed = $true
    }
    Assert-Condition $invalidFailed "The invalid Markdown fixture passed the quality gate."
    $invalidResult = Get-Content -LiteralPath $invalidReport -Raw | ConvertFrom-Json
    $invalidKinds = @($invalidResult.findings | ForEach-Object { $_.kind })
    Assert-Condition ($invalidKinds -contains "image_alt_text_missing") "Missing image alt text was not reported."
    Assert-Condition ($invalidKinds -contains "noncanonical_internal_link") "The noncanonical internal link was not reported."
    Assert-Condition ($invalidKinds -contains "invalid_version_range") "The invalid version range was not reported."

    $changedCurrent = [ordered]@{
        source = $baseline.source
        compatibility = @(
            [ordered]@{
                uid = "Legacy_Duplicate"
                href = "moved.html"
            }
        )
        metadataManifest = [ordered]@{
            entries = @(
                [ordered]@{
                    uid = "Legacy_Duplicate"
                    url = "https://docs.dataminer.services/moved.html"
                }
            )
        }
    }
    Write-TestFile $fixtureRoot "docs-corpus-baseline.generated.json" ($changedCurrent | ConvertTo-Json -Depth 10)
    $urlReport = Join-Path $fixtureRoot "url-report.json"
    $urlFailed = $false
    try {
        & $validator `
            -RepositoryRoot $fixtureRoot `
            -BaselinePath $baselinePath `
            -CurrentBaselinePath $currentPath `
            -ReportPath $urlReport `
            -Path "valid.md" `
            -SkipMarkdownLint
    }
    catch {
        $urlFailed = $true
    }
    Assert-Condition $urlFailed "The URL-preservation fixture passed after changing a published URL."
    $urlResult = Get-Content -LiteralPath $urlReport -Raw | ConvertFrom-Json
    Assert-Condition (@($urlResult.findings | Where-Object { $_.kind -eq "url_changed" }).Count -eq 1) "The URL change was not reported."

    Write-Output "Documentation quality gate tests passed."
}
finally {
    if (Test-Path -LiteralPath $fixtureRoot) {
        Remove-Item -LiteralPath $fixtureRoot -Recurse -Force
    }
}
