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

$fixtureRoot = Join-Path ([IO.Path]::GetTempPath()) ("dataminer-docs-anchors-" + [Guid]::NewGuid().ToString("N"))
$validator = Join-Path $PSScriptRoot "validate-documentation-anchors.ps1"

try {
    New-Item -ItemType Directory -Path $fixtureRoot -Force | Out-Null

    Write-TestFile $fixtureRoot "first.md" @'
# Anchor fixture

<a id="stable-scope"></a>

## Scope

<a name="legacy-footnote"></a>

Text.

```html
<a id="stable-scope"></a>
```
'@

    Write-TestFile $fixtureRoot "second.md" @'
# Another anchor fixture

<a id="stable-scope"></a>
'@

    & $validator -RepositoryRoot $fixtureRoot

    Write-TestFile $fixtureRoot "first.md" @'
# Anchor fixture

<a id="stable-scope"></a>

<a name="stable-scope"></a>
'@

    $duplicateDetected = $false
    try {
        & $validator -RepositoryRoot $fixtureRoot
    }
    catch {
        $duplicateDetected = $true
    }

    Assert-Condition $duplicateDetected "The anchor validator did not reject duplicate IDs in one document."
    Write-Output "Documentation anchor validator tests passed."
}
finally {
    if (Test-Path -LiteralPath $fixtureRoot) {
        Remove-Item -LiteralPath $fixtureRoot -Recurse -Force
    }
}
