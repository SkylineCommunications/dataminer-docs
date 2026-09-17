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

function Invoke-FixtureGit {
    param(
        [Parameter(Mandatory = $true)][string]$Root,
        [Parameter(Mandatory = $true)][string[]]$Arguments
    )

    $output = @(& git -C $Root @Arguments 2>&1)
    if ($LASTEXITCODE -ne 0) {
        throw "Git command failed: git -C '$Root' $($Arguments -join ' ')`n$($output -join "`n")"
    }

    return (($output | ForEach-Object { [string]$_ }) -join "`n").Trim()
}

function Assert-Contains {
    param(
        [Parameter(Mandatory = $true)][string]$Text,
        [Parameter(Mandatory = $true)][string]$Expected,
        [Parameter(Mandatory = $true)][string]$Context
    )

    Assert-Condition $Text.Contains($Expected, [StringComparison]::Ordinal) "$Context does not contain '$Expected'."
}

$repositoryRoot = [IO.Path]::GetFullPath((Join-Path $PSScriptRoot ".."))
$generator = Join-Path $PSScriptRoot "generate-html-source-metadata.ps1"
$validator = Join-Path $PSScriptRoot "validate-html-source-metadata.ps1"
$templatePath = Join-Path $repositoryRoot "templates\skyline"
$fixtureRoot = Join-Path ([IO.Path]::GetTempPath()) ("dataminer-docs-html-metadata-" + [Guid]::NewGuid().ToString("N"))
$oldAuthorDate = $env:GIT_AUTHOR_DATE
$oldCommitterDate = $env:GIT_COMMITTER_DATE

try {
    New-Item -ItemType Directory -Path $fixtureRoot -Force | Out-Null
    Write-TestFile $fixtureRoot "develop\devguide\Connector\fixture.md" @'
---
metadata_version: 1
uid: FixtureConnector
description: "A Connector fixture page with deterministic source metadata for the HTML build."
area: develop
content_type: conceptual
authority: reference
authority_source: unknown
lifecycle: active
applies_to:
  - DataMiner
version: unknown
owner: unknown
review_status: unknown
review_date: unknown
compatibility:
  uid: stable
  url: stable
---

# Connector fixture

This page verifies source metadata for Connector documentation.
'@
    Write-TestFile $fixtureRoot "develop\devguide\Automation\fixture.md" @'
---
metadata_version: 1
uid: FixtureAutomation
description: "An Automation fixture page with deterministic source metadata for the HTML build."
area: develop
content_type: conceptual
authority: reference
authority_source: unknown
lifecycle: active
applies_to:
  - DataMiner
version: unknown
owner: unknown
review_status: unknown
review_date: unknown
compatibility:
  uid: stable
  url: stable
---

# Automation fixture

This page verifies source metadata for Automation documentation.
'@
    Write-TestFile $fixtureRoot "legacy.md" @'
---
uid: LegacyFixture
description: "A legacy fixture page without D2 metadata values to verify that unknown values are not invented."
---

# Legacy fixture

This page intentionally has no D2 classification.
'@

    $config = [ordered]@{
        build = [ordered]@{
            content = @(
                [ordered]@{
                    files = "**/*.md"
                }
            )
            sitemap = [ordered]@{
                baseUrl = "https://docs.dataminer.services/"
            }
            fileMetadata = [ordered]@{
                sourceurl = [ordered]@{
                    "develop/devguide/Connector/fixture.md" = "https://github.com/SkylineCommunications/dataminer-docs/edit/main/develop/devguide/Connector/fixture.md"
                    "develop/devguide/Automation/fixture.md" = "https://github.com/SkylineCommunications/dataminer-docs/edit/main/develop/devguide/Automation/fixture.md"
                }
            }
            fileMetadataFiles = @("_artifacts/html-source-metadata.json")
            template = @("default", "modern", $templatePath)
            dest = "_site"
        }
    }
    Write-TestFile $fixtureRoot "docfx.json" (($config | ConvertTo-Json -Depth 10) + "`n")

    Invoke-FixtureGit -Root $fixtureRoot -Arguments @("init") | Out-Null
    Invoke-FixtureGit -Root $fixtureRoot -Arguments @("config", "user.email", "fixture@example.invalid") | Out-Null
    Invoke-FixtureGit -Root $fixtureRoot -Arguments @("config", "user.name", "HTML metadata fixture") | Out-Null
    Invoke-FixtureGit -Root $fixtureRoot -Arguments @("remote", "add", "origin", "https://github.com/SkylineCommunications/dataminer-docs.git") | Out-Null
    $env:GIT_AUTHOR_DATE = "2026-01-02T03:04:05Z"
    $env:GIT_COMMITTER_DATE = "2026-01-02T03:04:05Z"
    Invoke-FixtureGit -Root $fixtureRoot -Arguments @("add", "--all") | Out-Null
    Invoke-FixtureGit -Root $fixtureRoot -Arguments @("commit", "-m", "Add HTML metadata fixtures") | Out-Null
    $revision = Invoke-FixtureGit -Root $fixtureRoot -Arguments @("rev-parse", "HEAD")

    $metadataPath = Join-Path $fixtureRoot "_artifacts\html-source-metadata.json"
    & $generator -RepositoryRoot $fixtureRoot -DocFxConfigPath (Join-Path $fixtureRoot "docfx.json") -OutputPath $metadataPath -SourceRevision $revision
    Assert-Condition ($LASTEXITCODE -eq 0) "HTML source metadata generation failed."
    & $validator -RepositoryRoot $fixtureRoot -Path $metadataPath
    Assert-Condition ($LASTEXITCODE -eq 0) "HTML source metadata validation failed."
    $unknownMetadataPath = Join-Path $fixtureRoot "_artifacts\html-source-metadata-unknown.json"
    & $generator -RepositoryRoot $fixtureRoot -DocFxConfigPath (Join-Path $fixtureRoot "docfx.json") -OutputPath $unknownMetadataPath -SourceRevision "working-tree"
    Assert-Condition ($LASTEXITCODE -eq 0) "HTML source metadata generation without a commit failed."
    & $validator -RepositoryRoot $fixtureRoot -Path $unknownMetadataPath
    Assert-Condition ($LASTEXITCODE -eq 0) "HTML source metadata validation without a commit failed."
    $unknownMetadata = Get-Content -LiteralPath $unknownMetadataPath -Raw | ConvertFrom-Json
    $unknownFields = @($unknownMetadata.PSObject.Properties.Name)
    Assert-Condition (-not ($unknownFields -contains "sourceCommit")) "Unproven sourceCommit metadata was emitted."
    Assert-Condition (-not ($unknownFields -contains "sourceBlob")) "Unproven sourceBlob metadata was emitted."
    Assert-Condition (-not ($unknownFields -contains "dateModified")) "Unproven dateModified metadata was emitted."

    $buildLog = Join-Path $fixtureRoot "docfx-build.log"
    Push-Location $fixtureRoot
    try {
        docfx build docfx.json --warningsAsErrors *> $buildLog
        $buildExitCode = $LASTEXITCODE
    }
    finally {
        Pop-Location
    }
    Assert-Condition ($buildExitCode -eq 0) ("DocFX fixture build failed.`n{0}" -f (Get-Content -LiteralPath $buildLog -Raw))

    $connectorHtml = Get-Content -LiteralPath (Join-Path $fixtureRoot "_site\develop\devguide\Connector\fixture.html") -Raw
    $automationHtml = Get-Content -LiteralPath (Join-Path $fixtureRoot "_site\develop\devguide\Automation\fixture.html") -Raw
    foreach ($page in @(
            [PSCustomObject]@{
                Name = "Connector"
                Html = $connectorHtml
                Path = "develop/devguide/Connector/fixture.md"
            },
            [PSCustomObject]@{
                Name = "Automation"
                Html = $automationHtml
                Path = "develop/devguide/Automation/fixture.md"
            }
        )) {
        $outputPath = $page.Path.Replace(".md", ".html")
        $sourceUrl = "https://github.com/SkylineCommunications/dataminer-docs/blob/{0}/{1}" -f $revision, $page.Path
        Assert-Contains -Text $page.Html -Expected ("<link rel=""canonical"" href=""https://docs.dataminer.services/{0}"">" -f $outputPath) -Context "$($page.Name) canonical URL"
        Assert-Contains -Text $page.Html -Expected '<meta property="article:modified_time" content="2026-01-02">' -Context "$($page.Name) source date"
        Assert-Contains -Text $page.Html -Expected ('<meta name="dm:source-commit" content="{0}">' -f $revision) -Context "$($page.Name) source commit"
        Assert-Contains -Text $page.Html -Expected '<meta name="dm:content-type" content="conceptual">' -Context "$($page.Name) content type"
        Assert-Contains -Text $page.Html -Expected '<meta name="dm:authority" content="reference">' -Context "$($page.Name) authority"
        Assert-Contains -Text $page.Html -Expected '<meta name="dm:version" content="unknown">' -Context "$($page.Name) applicable version"
        Assert-Contains -Text $page.Html -Expected '<meta name="dm:owner" content="unknown">' -Context "$($page.Name) owner sentinel"
        Assert-Contains -Text $page.Html -Expected '<meta name="dm:applies-to" content="DataMiner; ">' -Context "$($page.Name) applicability"
        Assert-Contains -Text $page.Html -Expected ('<link rel="source" href="{0}">' -f $sourceUrl) -Context "$($page.Name) pinned source link"
        Assert-Contains -Text $page.Html -Expected ('<a href="{0}" class="edit-link">' -f ("https://github.com/SkylineCommunications/dataminer-docs/edit/main/{0}" -f $page.Path)) -Context "$($page.Name) human edit link"
    }

    $legacyHtml = Get-Content -LiteralPath (Join-Path $fixtureRoot "_site\legacy.html") -Raw
    Assert-Condition (-not $legacyHtml.Contains('name="dm:content-type"', [StringComparison]::Ordinal)) "Legacy page received an invented content type."
    Assert-Condition (-not $legacyHtml.Contains('name="dm:authority"', [StringComparison]::Ordinal)) "Legacy page received an invented authority."
    Assert-Contains -Text $connectorHtml -Expected '<meta name="dm:license" content="CC BY-NC-ND 4.0">' -Context "license attribution"
    Assert-Contains -Text $connectorHtml -Expected '<meta name="dm:attribution" content="Skyline Communications">' -Context "license attribution"

    Write-Output "HTML source metadata template/build tests passed."
}
finally {
    if ($null -eq $oldAuthorDate) {
        Remove-Item Env:GIT_AUTHOR_DATE -ErrorAction SilentlyContinue
    }
    else {
        $env:GIT_AUTHOR_DATE = $oldAuthorDate
    }
    if ($null -eq $oldCommitterDate) {
        Remove-Item Env:GIT_COMMITTER_DATE -ErrorAction SilentlyContinue
    }
    else {
        $env:GIT_COMMITTER_DATE = $oldCommitterDate
    }
    if (Test-Path -LiteralPath $fixtureRoot) {
        Remove-Item -LiteralPath $fixtureRoot -Recurse -Force
    }
}
