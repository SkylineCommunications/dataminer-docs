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

function Invoke-Git {
    param(
        [Parameter(Mandatory = $true)][string]$Root,
        [Parameter(Mandatory = $true)][string[]]$Arguments
    )

    $result = & git -C $Root @Arguments 2>$null
    if ($LASTEXITCODE -ne 0) {
        throw "Git command failed: git -C $Root $($Arguments -join ' ')`n$result"
    }
    return (($result -join "`n").Trim())
}

function Invoke-GitCommit {
    param(
        [Parameter(Mandatory = $true)][string]$Root,
        [Parameter(Mandatory = $true)][string]$Date
    )

    $oldAuthorDate = $env:GIT_AUTHOR_DATE
    $oldCommitterDate = $env:GIT_COMMITTER_DATE
    try {
        $env:GIT_AUTHOR_DATE = $Date
        $env:GIT_COMMITTER_DATE = $Date
        Invoke-Git -Root $Root -Arguments @("add", ".") | Out-Null
        Invoke-Git -Root $Root -Arguments @("commit", "-m", "fixture") | Out-Null
    }
    finally {
        $env:GIT_AUTHOR_DATE = $oldAuthorDate
        $env:GIT_COMMITTER_DATE = $oldCommitterDate
    }
}

function Get-UrlNodes {
    param([Parameter(Mandatory = $true)][string]$Path)

    $xml = New-Object System.Xml.XmlDocument
    $xml.Load($Path)
    return [PSCustomObject]@{
        xml = $xml
        urls = @($xml.SelectNodes("//*[local-name()='url']"))
        segments = @($xml.SelectNodes("//*[local-name()='sitemap']"))
    }
}

function Get-UrlLastMod {
    param(
        [Parameter(Mandatory = $true)][string]$Path,
        [Parameter(Mandatory = $true)][string]$Url
    )

    $parsed = Get-UrlNodes $Path
    foreach ($node in $parsed.urls) {
        $loc = [string]$node.SelectSingleNode("./*[local-name()='loc']").InnerText
        if ($loc -eq $Url) {
            $lastmod = $node.SelectSingleNode("./*[local-name()='lastmod']")
            if ($null -eq $lastmod) {
                return ""
            }
            return [string]$lastmod.InnerText
        }
    }
    throw "URL '$Url' was not found in '$Path'."
}

$repositoryRoot = [IO.Path]::GetFullPath((Join-Path $PSScriptRoot ".."))
$generator = Join-Path $PSScriptRoot "generate-segmented-sitemaps.ps1"
$validator = Join-Path $PSScriptRoot "validate-segmented-sitemaps.ps1"
$fixtureRoot = Join-Path ([IO.Path]::GetTempPath()) ("dataminer-docs-sitemap-" + [Guid]::NewGuid().ToString("N"))
$siteRoot = Join-Path $fixtureRoot "_site"
$reportOne = Join-Path $fixtureRoot "report-one.json"
$reportTwo = Join-Path $fixtureRoot "report-two.json"
$reportThree = Join-Path $fixtureRoot "report-three.json"
$baseUrl = "https://docs.dataminer.services/"
$connectorUrl = $baseUrl + "develop/devguide/Connector/ConnectorFixture.html"
$automationUrl = $baseUrl + "develop/devguide/Automation/AutomationFixture.html"
$generatedUrl = $baseUrl + "develop/api/types/GeneratedFixture.html"

try {
    New-Item -ItemType Directory -Path $siteRoot -Force | Out-Null
    Invoke-Git -Root $fixtureRoot -Arguments @("init", "--initial-branch=main") | Out-Null
    Invoke-Git -Root $fixtureRoot -Arguments @("config", "core.autocrlf", "false") | Out-Null
    Invoke-Git -Root $fixtureRoot -Arguments @("config", "user.email", "fixture@example.invalid") | Out-Null
    Invoke-Git -Root $fixtureRoot -Arguments @("config", "user.name", "Fixture") | Out-Null

    Write-TestFile $fixtureRoot "develop/devguide/Connector/ConnectorFixture.md" @'
---
uid: ConnectorFixture
content_type: conceptual
---

# Connector fixture

Connector source content.
'@
    Write-TestFile $fixtureRoot "develop/devguide/Automation/AutomationFixture.md" @'
---
uid: AutomationFixture
content_type: conceptual
---

# Automation fixture

Automation source content.
'@
    Write-TestFile $fixtureRoot "_site/manifest.json" @'
{
  "files": [
    {
      "type": "Conceptual",
      "source_relative_path": "develop/devguide/Automation/AutomationFixture.md",
      "output": {
        ".html": {
          "relative_path": "develop/devguide/Automation/AutomationFixture.html"
        }
      }
    },
    {
      "type": "Conceptual",
      "source_relative_path": "develop/devguide/Connector/ConnectorFixture.md",
      "output": {
        ".html": {
          "relative_path": "develop/devguide/Connector/ConnectorFixture.html"
        }
      }
    },
    {
      "type": "ManagedReference",
      "source_relative_path": "develop/api/types/GeneratedFixture.yml",
      "output": {
        ".html": {
          "relative_path": "develop/api/types/GeneratedFixture.html"
        }
      }
    }
  ]
}
'@
    Write-TestFile $fixtureRoot "_artifacts/generated-metadata-provenance.json" @'
{
  "artifacts": [
    {
      "id": "source:develop/devguide/Connector/ConnectorFixture.md",
      "kind": "source",
      "identity": "develop/devguide/Connector/ConnectorFixture.md",
      "file": {
        "path": "develop/devguide/Connector/ConnectorFixture.md"
      }
    }
  ],
  "outputs": {
    "api": [
      {
        "path": "develop/api/types/GeneratedFixture.yml",
        "artifactIds": [
          "source:develop/devguide/Connector/ConnectorFixture.md"
        ],
        "generated": {
          "assemblies": []
        }
      }
    ]
  }
}
'@
    Write-TestFile $siteRoot "robots.txt" @'
User-agent: *
Sitemap: https://docs.dataminer.services/sitemap.xml
'@
    Write-TestFile $siteRoot "sitemap.xml" @'
<?xml version="1.0" encoding="utf-8"?>
<urlset xmlns="http://www.sitemaps.org/schemas/sitemap/0.9">
  <url>
    <loc>https://docs.dataminer.services/develop/devguide/Automation/AutomationFixture.html</loc>
    <lastmod>2026-09-18T00:00:00Z</lastmod>
    <changefreq>hourly</changefreq>
    <priority>0.5</priority>
  </url>
  <url>
    <loc>https://docs.dataminer.services/develop/devguide/Connector/ConnectorFixture.html</loc>
    <lastmod>2026-09-18T00:00:00Z</lastmod>
    <changefreq>hourly</changefreq>
    <priority>0.5</priority>
  </url>
  <url>
    <loc>https://docs.dataminer.services/develop/api/types/GeneratedFixture.html</loc>
    <lastmod>2026-09-18T00:00:00Z</lastmod>
    <changefreq>hourly</changefreq>
    <priority>0.5</priority>
  </url>
</urlset>
'@

    Invoke-GitCommit -Root $fixtureRoot -Date "2026-09-17T10:00:00Z"
    $revisionOne = Invoke-Git -Root $fixtureRoot -Arguments @("rev-parse", "HEAD")
    & $generator `
        -RepositoryRoot $fixtureRoot `
        -SitePath $siteRoot `
        -OutputPath $reportOne `
        -SourceRevision $revisionOne | Out-Null
    & $validator `
        -RepositoryRoot $fixtureRoot `
        -SitePath $siteRoot `
        -ReportPath $reportOne | Out-Null

    $firstIndex = Get-UrlNodes (Join-Path $siteRoot "sitemap.xml")
    $firstSegmentLocations = @($firstIndex.segments | ForEach-Object { [string]$_.SelectSingleNode("./*[local-name()='loc']").InnerText })
    Assert-Condition (@($firstSegmentLocations | Where-Object { $_ -like "*sitemap-connector-conceptual.xml" }).Count -eq 1) "Connector segment was not independently indexed."
    Assert-Condition (@($firstSegmentLocations | Where-Object { $_ -like "*sitemap-automation-conceptual.xml" }).Count -eq 1) "Automation segment was not independently indexed."
    Assert-Condition (@($firstSegmentLocations | Where-Object { $_ -like "*sitemap-develop-api.xml" }).Count -eq 1) "Generated API segment was not indexed."

    $connectorSegmentPath = Join-Path $siteRoot "sitemap-connector-conceptual.xml"
    $automationSegmentPath = Join-Path $siteRoot "sitemap-automation-conceptual.xml"
    $apiSegmentPath = Join-Path $siteRoot "sitemap-develop-api.xml"
    Assert-Condition (@((Get-UrlNodes $connectorSegmentPath).urls | ForEach-Object { [string]$_.SelectSingleNode("./*[local-name()='loc']").InnerText } | Where-Object { $_ -eq $connectorUrl }).Count -eq 1) "Connector URL was not present in the Connector segment."
    Assert-Condition (@((Get-UrlNodes $connectorSegmentPath).urls | ForEach-Object { [string]$_.SelectSingleNode("./*[local-name()='loc']").InnerText } | Where-Object { $_ -eq $automationUrl }).Count -eq 0) "Automation URL leaked into the Connector segment."
    Assert-Condition (@((Get-UrlNodes $automationSegmentPath).urls | ForEach-Object { [string]$_.SelectSingleNode("./*[local-name()='loc']").InnerText } | Where-Object { $_ -eq $automationUrl }).Count -eq 1) "Automation URL was not present in the Automation segment."
    Assert-Condition (@((Get-UrlNodes $automationSegmentPath).urls | ForEach-Object { [string]$_.SelectSingleNode("./*[local-name()='loc']").InnerText } | Where-Object { $_ -eq $connectorUrl }).Count -eq 0) "Connector URL leaked into the Automation segment."
    Assert-Condition (@((Get-UrlNodes $apiSegmentPath).urls | ForEach-Object { [string]$_.SelectSingleNode("./*[local-name()='loc']").InnerText } | Where-Object { $_ -eq $generatedUrl }).Count -eq 1) "Generated API URL was not present in the API segment."
    Assert-Condition ((Get-Content -LiteralPath (Join-Path $siteRoot "sitemap.xml") -Raw) -notmatch "changefreq|priority") "Legacy sitemap metadata was retained."

    $connectorLastModOne = Get-UrlLastMod -Path $connectorSegmentPath -Url $connectorUrl
    $automationLastModOne = Get-UrlLastMod -Path $automationSegmentPath -Url $automationUrl
    $generatedLastModOne = Get-UrlLastMod -Path $apiSegmentPath -Url $generatedUrl
    Assert-Condition ($connectorLastModOne -eq "2026-09-17T10:00:00Z") "Connector lastmod did not use the source commit timestamp."
    Assert-Condition ($automationLastModOne -eq "2026-09-17T10:00:00Z") "Automation lastmod did not use the source commit timestamp."
    Assert-Condition ($generatedLastModOne -eq $connectorLastModOne) "Generated API lastmod did not use the D2.3 source provenance timestamp."
    $firstReport = Get-Content -LiteralPath $reportOne -Raw | ConvertFrom-Json
    Assert-Condition (@($firstReport.gaps).Count -eq 0) "The fixture reported an unexpected source timestamp gap."

    Write-TestFile $fixtureRoot "develop/devguide/Automation/AutomationFixture.md" @'
---
uid: AutomationFixture
content_type: conceptual
---

# Automation fixture

Changed Automation source content.
'@
    Invoke-GitCommit -Root $fixtureRoot -Date "2026-09-18T10:00:00Z"
    $revisionTwo = Invoke-Git -Root $fixtureRoot -Arguments @("rev-parse", "HEAD")
    & $generator `
        -RepositoryRoot $fixtureRoot `
        -SitePath $siteRoot `
        -OutputPath $reportTwo `
        -SourceRevision $revisionTwo | Out-Null
    & $validator `
        -RepositoryRoot $fixtureRoot `
        -SitePath $siteRoot `
        -ReportPath $reportTwo | Out-Null

    $connectorLastModTwo = Get-UrlLastMod -Path $connectorSegmentPath -Url $connectorUrl
    $automationLastModTwo = Get-UrlLastMod -Path $automationSegmentPath -Url $automationUrl
    $generatedLastModTwo = Get-UrlLastMod -Path $apiSegmentPath -Url $generatedUrl
    Assert-Condition ($connectorLastModTwo -eq $connectorLastModOne) "Unchanged Connector pages did not retain their source lastmod across deployments."
    Assert-Condition ($automationLastModTwo -ne $automationLastModOne -and $automationLastModTwo -eq "2026-09-18T10:00:00Z") "Changed Automation pages did not receive the new source lastmod."
    Assert-Condition ($generatedLastModTwo -eq $generatedLastModOne) "Unchanged generated API pages did not retain their provenance lastmod."

    & $generator `
        -RepositoryRoot $fixtureRoot `
        -SitePath $siteRoot `
        -OutputPath $reportThree `
        -SourceRevision $revisionTwo | Out-Null
    $hashTwo = (Get-FileHash -LiteralPath $reportTwo -Algorithm SHA256).Hash
    $hashThree = (Get-FileHash -LiteralPath $reportThree -Algorithm SHA256).Hash
    Assert-Condition ($hashTwo -eq $hashThree) "Repeated sitemap generation was not deterministic."

    Write-Output "Segmented sitemap tests passed."
}
finally {
    if (Test-Path -LiteralPath $fixtureRoot) {
        Remove-Item -LiteralPath $fixtureRoot -Recurse -Force
    }
}
