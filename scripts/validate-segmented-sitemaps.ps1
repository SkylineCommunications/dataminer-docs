[CmdletBinding()]
param(
    [string]$RepositoryRoot = (Join-Path $PSScriptRoot ".."),
    [string]$SitePath = (Join-Path $PSScriptRoot "..\_site"),
    [string]$ReportPath = (Join-Path $PSScriptRoot "..\_artifacts\segmented-sitemap-report.json"),
    [string]$BaseUrl = "https://docs.dataminer.services/"
)

Set-StrictMode -Version 2.0
$ErrorActionPreference = "Stop"

$script:SitemapNamespace = "http://www.sitemaps.org/schemas/sitemap/0.9"

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
    param([Parameter(Mandatory = $true)][string]$Path)

    if ([IO.Path]::IsPathRooted($Path)) {
        return [IO.Path]::GetFullPath($Path)
    }

    return [IO.Path]::GetFullPath((Join-Path (Get-Location).Path $Path))
}

function Normalize-BaseUrl {
    param([Parameter(Mandatory = $true)][string]$Value)

    $normalized = $Value.Trim()
    if (-not $normalized.EndsWith("/")) {
        $normalized += "/"
    }
    $uri = $null
    Assert-Condition (
        [Uri]::TryCreate($normalized, [UriKind]::Absolute, [ref]$uri) -and
        $uri.Scheme -in @("http", "https")
    ) "Base URL '$Value' is not an absolute HTTP(S) URL."
    return $normalized
}

function Get-LocalPath {
    param(
        [Parameter(Mandatory = $true)][string]$SiteRoot,
        [Parameter(Mandatory = $true)][string]$Url,
        [Parameter(Mandatory = $true)][string]$BaseUrl
    )

    $uri = [Uri]$Url
    $baseUri = [Uri]$BaseUrl
    Assert-Condition (
        $uri.Scheme -eq $baseUri.Scheme -and
        $uri.Host -eq $baseUri.Host -and
        $uri.Port -eq $baseUri.Port
    ) "Sitemap URL '$Url' is outside the configured base URL."
    $relativePath = [Uri]::UnescapeDataString($uri.AbsolutePath.TrimStart("/"))
    Assert-Condition (
        -not [String]::IsNullOrWhiteSpace($relativePath) -and
        $relativePath -notmatch "(^|/)\.\.?(/|$)"
    ) "Sitemap URL '$Url' has an invalid relative path."
    return [IO.Path]::GetFullPath((Join-Path $SiteRoot $relativePath.Replace("/", "\")))
}

function Read-Xml {
    param([Parameter(Mandatory = $true)][string]$Path)

    Assert-Condition (Test-Path -LiteralPath $Path -PathType Leaf) "Sitemap '$Path' does not exist."
    $xml = New-Object System.Xml.XmlDocument
    $xml.Load($Path)
    Assert-Condition ($xml.DocumentElement.NamespaceURI -eq $script:SitemapNamespace) "Sitemap '$Path' has an unexpected namespace."
    return $xml
}

function Assert-NoLegacyMetadata {
    param(
        [Parameter(Mandatory = $true)][System.Xml.XmlDocument]$Xml,
        [Parameter(Mandatory = $true)][string]$Path
    )

    Assert-Condition (@($Xml.SelectNodes("//*[local-name()='changefreq']")).Count -eq 0) "Sitemap '$Path' still contains changefreq."
    Assert-Condition (@($Xml.SelectNodes("//*[local-name()='priority']")).Count -eq 0) "Sitemap '$Path' still contains priority."
}

function Get-ReportProperty {
    param(
        [Parameter(Mandatory = $true)]$Object,
        [Parameter(Mandatory = $true)][string]$Name,
        [Parameter(Mandatory = $true)][string]$Context
    )

    Assert-Condition (@($Object.PSObject.Properties.Name) -contains $Name) "$Context is missing '$Name'."
    return $Object.$Name
}

$repositoryRoot = ConvertTo-FullPath $RepositoryRoot
$siteRoot = ConvertTo-FullPath $SitePath
$reportFile = ConvertTo-FullPath $ReportPath
$baseUrl = Normalize-BaseUrl $BaseUrl
$indexPath = Join-Path $siteRoot "sitemap.xml"

Assert-Condition (Test-Path -LiteralPath $repositoryRoot -PathType Container) "Repository root '$repositoryRoot' does not exist."
Assert-Condition (Test-Path -LiteralPath $siteRoot -PathType Container) "Site path '$siteRoot' does not exist."
Assert-Condition (Test-Path -LiteralPath $reportFile -PathType Leaf) "Sitemap report '$reportFile' does not exist."

$report = Get-Content -LiteralPath $reportFile -Raw | ConvertFrom-Json
Assert-Condition ([int](Get-ReportProperty $report "schemaVersion" "report") -eq 1) "Unsupported sitemap report schema version."
$generator = Get-ReportProperty $report "generator" "report"
Assert-Condition ([string](Get-ReportProperty $generator "name" "report.generator") -eq "scripts/generate-segmented-sitemaps.ps1") "Unexpected sitemap generator."
$source = Get-ReportProperty $report "source" "report"
Assert-Condition ([string](Get-ReportProperty $source "baseUrl" "report.source") -eq $baseUrl) "Sitemap report base URL does not match validation input."
$counts = Get-ReportProperty $report "counts" "report"
$reportSegments = @((Get-ReportProperty (Get-ReportProperty $report "output" "report") "segments" "report.output"))

$index = Read-Xml $indexPath
Assert-NoLegacyMetadata -Xml $index -Path $indexPath
Assert-Condition ($index.DocumentElement.LocalName -eq "sitemapindex") "Root sitemap must be a sitemapindex."

$indexLocations = @(
    $index.SelectNodes("//*[local-name()='sitemap']/*[local-name()='loc']") |
        ForEach-Object { [string]$_.InnerText.Trim() }
)
Assert-Condition ($indexLocations.Count -eq $reportSegments.Count) "Root sitemap segment count does not match the report."
Assert-Condition (@($indexLocations | Sort-Object -Unique).Count -eq $indexLocations.Count) "Root sitemap contains duplicate segment URLs."

$allLocations = New-Object "System.Collections.Generic.List[string]"
$lastmodCount = 0
$segmentNames = @{}
foreach ($location in $indexLocations) {
    Assert-Condition ($location.StartsWith($baseUrl, [StringComparison]::Ordinal)) "Segment URL '$location' is not rooted at the configured base URL."
    $segmentPath = Get-LocalPath -SiteRoot $siteRoot -Url $location -BaseUrl $baseUrl
    $segmentName = [IO.Path]::GetFileName($segmentPath)
    Assert-Condition ($segmentName -match "^sitemap-[a-z0-9-]+\.xml$") "Segment '$segmentName' has an invalid deterministic name."
    Assert-Condition (-not $segmentNames.ContainsKey($segmentName)) "Duplicate segment '$segmentName'."
    $segmentNames[$segmentName] = $true

    $segmentXml = Read-Xml $segmentPath
    Assert-NoLegacyMetadata -Xml $segmentXml -Path $segmentPath
    Assert-Condition ($segmentXml.DocumentElement.LocalName -eq "urlset") "Segment '$segmentName' must be a urlset."
    $urlNodes = @($segmentXml.SelectNodes("//*[local-name()='url']"))
    $reportSegment = @($reportSegments | Where-Object { [string]$_.name -eq $segmentName })
    Assert-Condition ($reportSegment.Count -eq 1) "Segment '$segmentName' is missing or duplicated in the report."
    Assert-Condition ($urlNodes.Count -eq [int]$reportSegment[0].urlCount) "Segment '$segmentName' URL count does not match the report."

    foreach ($urlNode in $urlNodes) {
        $locNode = $urlNode.SelectSingleNode("./*[local-name()='loc']")
        Assert-Condition ($null -ne $locNode) "Segment '$segmentName' contains a URL without loc."
        $locationValue = [string]$locNode.InnerText.Trim()
        Assert-Condition ($locationValue.StartsWith($baseUrl, [StringComparison]::Ordinal)) "Page URL '$locationValue' is not rooted at the configured base URL."
        $allLocations.Add($locationValue)
        $lastmodNode = $urlNode.SelectSingleNode("./*[local-name()='lastmod']")
        if ($null -ne $lastmodNode) {
            try {
                [DateTimeOffset]::Parse(
                    [string]$lastmodNode.InnerText,
                    [Globalization.CultureInfo]::InvariantCulture,
                    [Globalization.DateTimeStyles]::RoundtripKind
                ) | Out-Null
            }
            catch {
                throw "Page URL '$locationValue' has an invalid lastmod."
            }
            $lastmodCount++
        }
    }
}

Assert-Condition (@($allLocations | Sort-Object -Unique).Count -eq $allLocations.Count) "Segmented sitemaps contain duplicate page URLs."
Assert-Condition ([int]$counts.urls -eq $allLocations.Count) "Report URL count does not match the generated sitemap URLs."
Assert-Condition ([int]$counts.segments -eq $indexLocations.Count) "Report segment count does not match the root sitemap."
Assert-Condition ([int]$counts.withLastmod -eq $lastmodCount) "Report lastmod count does not match the generated sitemap URLs."
Assert-Condition ([int]$counts.withoutLastmod -eq ($allLocations.Count - $lastmodCount)) "Report missing-lastmod count does not match the generated sitemap URLs."

$robotsPath = Join-Path $siteRoot "robots.txt"
if (Test-Path -LiteralPath $robotsPath -PathType Leaf) {
    $robots = Get-Content -LiteralPath $robotsPath -Raw
    Assert-Condition ($robots -match "(?im)^\s*Sitemap:\s*$([Regex]::Escape($baseUrl))sitemap\.xml\s*$") "robots.txt does not preserve the root sitemap discovery URL."
}

Write-Output "Segmented sitemap validation passed."
Write-Output "URLs: $($allLocations.Count); segments: $($indexLocations.Count); lastmod: $lastmodCount; gaps: $(@($report.gaps).Count)."
