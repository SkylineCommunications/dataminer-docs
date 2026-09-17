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

$fixtureRoot = Join-Path ([IO.Path]::GetTempPath()) ("dataminer-docs-baseline-" + [Guid]::NewGuid().ToString("N"))
$outputOne = Join-Path $fixtureRoot "baseline-one.json"
$outputTwo = Join-Path $fixtureRoot "baseline-two.json"
$auditScript = Join-Path $PSScriptRoot "audit-docs-baseline.ps1"

try {
    New-Item -ItemType Directory -Path $fixtureRoot -Force | Out-Null

    Write-TestFile $fixtureRoot "README.md" @'
---
uid: Duplicate
description: "A deterministic fixture page with enough context for the audit."
---

# Fixture root

This page contains a typed example.

```csharp
Console.WriteLine("fixture");
```
'@

    Write-TestFile $fixtureRoot "develop/devguide/Connector/connector.md" @'
---
uid: Duplicate
---

# Connector fixture

This page intentionally reuses a UID.

```xml
<Protocol />
```
'@

    Write-TestFile $fixtureRoot "develop/devguide/Connector/missing.md" @'
# Missing metadata fixture
'@

    Write-TestFile $fixtureRoot "develop/devguide/Automation/automation.md" @'
---
uid: AutomationFixture
description: "A deterministic Automation fixture page with a typed XML example."
---

# Automation fixture

See [the root fixture](xref:Duplicate).

```xml
<DMSScript />
```
'@

    Write-TestFile $fixtureRoot "develop/schemadoc/Protocol/schema.md" @'
---
uid: SchemaFixture
description: "A deterministic schema fixture page with a text snippet."
---

# Schema fixture

```text
schema fragment
```
'@

    Write-TestFile $fixtureRoot "release-notes/release.md" @'
---
uid: ReleaseFixture
description: "A deterministic release-note fixture page."
---

# Release fixture

DataMiner 10.6 introduced the fixture.
'@

    Write-TestFile $fixtureRoot "docfx.json" @'
{
  "build": {
    "content": [
      {
        "files": [
          "**/*.md"
        ]
      }
    ],
    "resource": [
      {
        "files": [
          "images/**"
        ]
      }
    ],
    "xref": [
      "xrefmap.yml"
    ],
    "sitemap": {
      "baseUrl": "https://docs.dataminer.services/",
      "changefreq": "hourly"
    }
  }
}
'@
    Write-TestFile $fixtureRoot "buildDocs.cmd" "@echo off`n"

    $manifest = [ordered]@{
        sitemap = [ordered]@{
            baseUrl = "https://docs.dataminer.services/"
            changefreq = "hourly"
        }
        source_base_path = "fixture"
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
                type = "Conceptual"
                source_relative_path = "develop/devguide/Automation/automation.md"
                output = [ordered]@{
                    ".html" = [ordered]@{ relative_path = "develop/devguide/Automation/automation.html" }
                }
                version = ""
            },
            [ordered]@{
                type = "Resource"
                source_relative_path = "images/fixture.png"
                output = [ordered]@{
                    resource = [ordered]@{ relative_path = "images/fixture.png" }
                }
                version = ""
            }
        )
    }
    $siteRoot = Join-Path $fixtureRoot "_site"
    New-Item -ItemType Directory -Path $siteRoot -Force | Out-Null
    Write-TestFile $fixtureRoot "_site/manifest.json" ($manifest | ConvertTo-Json -Depth 10)
    Write-TestFile $fixtureRoot "_site/xrefmap.yml" @'
### YamlMime:XRefMap
sorted: true
references:
- uid: AutomationFixture
  name: Automation fixture
  href: develop/devguide/Automation/automation.html
- uid: Duplicate
  name: Fixture root
  href: README.html
'@
    Write-TestFile $fixtureRoot "_site/sitemap.xml" @'
<?xml version="1.0" encoding="utf-8"?>
<urlset xmlns="http://www.sitemaps.org/schemas/sitemap/0.9">
  <url>
    <loc>https://docs.dataminer.services/README.html</loc>
    <lastmod>2026-09-17T00:00:00+00:00</lastmod>
    <changefreq>hourly</changefreq>
    <priority>0.5</priority>
  </url>
</urlset>
'@

    & $auditScript -RepositoryRoot $fixtureRoot -OutputPath $outputOne -SourceRevision "fixture"
    & $auditScript -RepositoryRoot $fixtureRoot -OutputPath $outputTwo -SourceRevision "fixture"

    $firstHash = (Get-FileHash -LiteralPath $outputOne -Algorithm SHA256).Hash
    $secondHash = (Get-FileHash -LiteralPath $outputTwo -Algorithm SHA256).Hash
    Assert-Condition ($firstHash -eq $secondHash) "Repeated audit runs produced different JSON."

    $baseline = Get-Content -LiteralPath $outputOne -Raw | ConvertFrom-Json
    Assert-Condition ($baseline.source.metrics.pages -eq 6) "Unexpected source page count."
    Assert-Condition ($baseline.source.uid.duplicateUidCount -eq 1) "Duplicate UID was not recorded."
    Assert-Condition ($baseline.source.uid.pagesWithoutUid -eq 1) "Missing UID was not recorded."
    Assert-Condition ($baseline.source.descriptions.pagesWithoutDescription -eq 2) "Missing descriptions were not recorded."
    Assert-Condition ($baseline.source.snippets.codeBlockCount -eq 4) "Code block count was not recorded."
    Assert-Condition ($baseline.source.snippets.languages.csharp -eq 1) "C# snippet type was not recorded."
    Assert-Condition ($baseline.source.snippets.languages.xml -eq 2) "XML snippet type was not recorded."
    Assert-Condition ($baseline.source.connector.pages -eq 3) "Connector scope was not reported separately."
    Assert-Condition ($baseline.source.automation.pages -eq 1) "Automation scope was not reported separately."
    Assert-Condition ($baseline.generated.manifest.available) "Manifest output was not read."
    Assert-Condition ($baseline.generated.manifest.entryCount -eq 3) "Manifest entry count was not recorded."
    Assert-Condition ($baseline.generated.manifest.outputCount -eq 3) "Manifest output count was not recorded."
    Assert-Condition ($baseline.generated.xrefmap.referenceCount -eq 2) "xref map output was not read."
    Assert-Condition ($baseline.generated.sitemap.urlCount -eq 1) "Sitemap output was not read."
    Assert-Condition ($baseline.configuration.docfx.available) "DocFX configuration was not read."
    Assert-Condition ($baseline.configuration.localBuildScript.available) "Local build script was not fingerprinted."
    Assert-Condition ($baseline.baseline.compatibilitySource -eq "xrefmap") "xref map was not selected as compatibility source."
    Assert-Condition ($baseline.compatibility.Count -eq 2) "Compatibility records were not frozen."

    Write-Output "Documentation corpus audit tests passed."
}
finally {
    if (Test-Path -LiteralPath $fixtureRoot) {
        Remove-Item -LiteralPath $fixtureRoot -Recurse -Force
    }
}
