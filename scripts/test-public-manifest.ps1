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

$sanitizer = Join-Path $PSScriptRoot "sanitize-public-manifest.ps1"
$fixtureRoot = Join-Path ([IO.Path]::GetTempPath()) ("dataminer-docs-public-manifest-" + [Guid]::NewGuid().ToString("N"))
$manifestPath = Join-Path $fixtureRoot "manifest.json"
$unsafeManifestPath = Join-Path $fixtureRoot "unsafe-manifest.json"

try {
    New-Item -ItemType Directory -Path $fixtureRoot -Force | Out-Null
    $manifest = [ordered]@{
        source_base_path = $fixtureRoot
        runner = [ordered]@{
            name = "GitHub Actions"
            workspace = $fixtureRoot
        }
        github_workspace = $fixtureRoot
        build_machine = "runner"
        xrefmap = "xrefmap.yml"
        files = @(
            [ordered]@{
                type = "Conceptual"
                source_relative_path = "README.md"
                output = [ordered]@{
                    ".html" = [ordered]@{ relative_path = "README.html" }
                }
                version = ""
            },
            [ordered]@{
                type = "ManagedReference"
                source_relative_path = "develop/api/types/Fixture.yml"
                output = [ordered]@{
                    ".html" = [ordered]@{ relative_path = "develop/api/types/Fixture.html" }
                }
                version = "10.6.0"
            }
        )
    }
    [IO.File]::WriteAllText(
        $manifestPath,
        ($manifest | ConvertTo-Json -Depth 20),
        (New-Object Text.UTF8Encoding($false))
    )

    & $sanitizer -Path $manifestPath | Out-Null
    $clean = Get-Content -LiteralPath $manifestPath -Raw | ConvertFrom-Json
    $cleanJson = Get-Content -LiteralPath $manifestPath -Raw
    $cleanProperties = @($clean.PSObject.Properties.Name)
    Assert-Condition ($cleanProperties -notcontains "source_base_path") "The checkout path was retained."
    Assert-Condition ($cleanProperties -notcontains "runner") "Runner details were retained."
    Assert-Condition ($cleanProperties -notcontains "github_workspace") "The GitHub workspace was retained."
    Assert-Condition ($cleanProperties -notcontains "build_machine") "Build-machine details were retained."
    Assert-Condition ($clean.xrefmap -eq "xrefmap.yml") "The public xref map reference was changed."
    Assert-Condition (@($clean.files[0].PSObject.Properties.Name) -notcontains "version") "An empty version was retained."
    Assert-Condition ($clean.files[1].version -eq "10.6.0") "A meaningful version was removed."
    Assert-Condition ($clean.files[0].source_relative_path -eq "README.md") "The source-relative path was changed."
    Assert-Condition ($clean.files[0].output.".html".relative_path -eq "README.html") "The output path was changed."
    Assert-Condition ($cleanJson -notlike "*$fixtureRoot*") "The fixture path leaked into the public manifest."

    $unsafe = [ordered]@{
        files = @(
            [ordered]@{
                type = "Conceptual"
                source_relative_path = "README.md"
                output = [ordered]@{
                    ".html" = [ordered]@{ relative_path = "README.html" }
                }
            }
        )
        diagnostic = $fixtureRoot
    }
    [IO.File]::WriteAllText(
        $unsafeManifestPath,
        ($unsafe | ConvertTo-Json -Depth 20),
        (New-Object Text.UTF8Encoding($false))
    )
    $failed = $false
    try {
        & $sanitizer -Path $unsafeManifestPath | Out-Null
    }
    catch {
        $failed = $true
    }
    Assert-Condition $failed "An unrecognized absolute path was not rejected."

    Write-Output "Public manifest sanitization tests passed."
}
finally {
    if (Test-Path -LiteralPath $fixtureRoot) {
        Remove-Item -LiteralPath $fixtureRoot -Recurse -Force
    }
}
