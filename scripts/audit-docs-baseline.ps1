[CmdletBinding()]
param(
    [string]$RepositoryRoot = (Join-Path $PSScriptRoot ".."),
    [string]$OutputPath = (Join-Path $PSScriptRoot "..\docs-corpus-baseline.json"),
    [string]$SitePath,
    [string]$ManifestPath,
    [string]$XrefMapPath,
    [string]$SitemapPath,
    [string]$BaseUrl = "https://docs.dataminer.services/",
    [int]$OversizedPageCharacters = 64000,
    [int]$StubPageCharacters = 200,
    [string]$SourceRevision = "working-tree",
    [string]$ManifestSource = "local",
    [string]$XrefMapSource = "local",
    [string]$SitemapSource = "local"
)

Set-StrictMode -Version 2.0
$ErrorActionPreference = "Stop"

$script:BaselineSchemaVersion = 2
$script:MetadataManifestSchemaVersion = 1
$script:GeneratorName = "scripts/audit-docs-baseline.ps1"
$script:GeneratorVersion = "1.1.0"
$script:LicenseIdentifier = "CC BY-NC-ND 4.0"
$script:LicenseName = "Creative Commons Attribution-NonCommercial-NoDerivatives 4.0 International"
$script:LicenseUrl = "https://creativecommons.org/licenses/by-nc-nd/4.0/"
$script:Attribution = "Skyline Communications"

function ConvertTo-FullPath {
    param([Parameter(Mandatory = $true)][string]$Path)

    if ([IO.Path]::IsPathRooted($Path)) {
        return [IO.Path]::GetFullPath($Path)
    }

    return [IO.Path]::GetFullPath((Join-Path (Get-Location).Path $Path))
}

function ConvertTo-RepositoryRelativePath {
    param([Parameter(Mandatory = $true)][string]$Path)

    $fullPath = [IO.Path]::GetFullPath($Path)
    $prefix = $script:RepositoryRoot.TrimEnd("\") + "\"
    if (-not $fullPath.StartsWith($prefix, [StringComparison]::OrdinalIgnoreCase)) {
        throw "Path '$Path' is outside the repository root '$script:RepositoryRoot'."
    }

    return $fullPath.Substring($prefix.Length).Replace("\", "/")
}

function Normalize-Text {
    param([AllowEmptyString()][string]$Text)

    if ($null -eq $Text) {
        return ""
    }

    return [Regex]::Replace($Text, "`r`n?", "`n")
}

function Get-TextSha256 {
    param([AllowEmptyString()][string]$Text)

    $normalized = Normalize-Text $Text
    $bytes = [Text.Encoding]::UTF8.GetBytes($normalized)
    $hash = [Security.Cryptography.SHA256]::Create()
    try {
        return ([BitConverter]::ToString($hash.ComputeHash($bytes))).Replace("-", "").ToLowerInvariant()
    }
    finally {
        $hash.Dispose()
    }
}

function Get-FileSha256 {
    param([Parameter(Mandatory = $true)][string]$Path)

    $hash = [Security.Cryptography.SHA256]::Create()
    try {
        $bytes = [IO.File]::ReadAllBytes($Path)
        return ([BitConverter]::ToString($hash.ComputeHash($bytes))).Replace("-", "").ToLowerInvariant()
    }
    finally {
        $hash.Dispose()
    }
}

function Get-YamlScalar {
    param([AllowEmptyString()][string]$Value)

    if ($null -eq $Value) {
        return ""
    }

    $value = $Value.Trim()
    if ($value -eq "" -or $value -eq "~" -or $value -ieq "null") {
        return ""
    }

    if ($value.Length -ge 2 -and $value.StartsWith('"') -and $value.EndsWith('"')) {
        return $value.Substring(1, $value.Length - 2).Replace('\"', '"').Replace("\\", "\")
    }

    if ($value.Length -ge 2 -and $value.StartsWith("'") -and $value.EndsWith("'")) {
        return $value.Substring(1, $value.Length - 2).Replace("''", "'")
    }

    return ($value -replace "\s+#.*$", "").Trim()
}

function Get-FrontMatterValue {
    param(
        [AllowEmptyString()][string]$FrontMatter,
        [Parameter(Mandatory = $true)][string]$Name
    )

    $match = [Regex]::Match($FrontMatter, "(?im)^\s*" + [Regex]::Escape($Name) + "\s*:\s*(?<value>.*)$")
    if (-not $match.Success) {
        return ""
    }

    return Get-YamlScalar $match.Groups["value"].Value
}

function Get-FrontMatterNestedValue {
    param(
        [AllowEmptyString()][string]$FrontMatter,
        [Parameter(Mandatory = $true)][string]$Name
    )

    $match = [Regex]::Match($FrontMatter, "(?im)^\s{2,}" + [Regex]::Escape($Name) + "\s*:\s*(?<value>.*)$")
    if (-not $match.Success) {
        return ""
    }

    return Get-YamlScalar $match.Groups["value"].Value
}

function Get-MarkdownParts {
    param([Parameter(Mandatory = $true)][string]$Text)

    $normalized = Normalize-Text $Text
    $frontMatter = ""
    $body = $normalized
    $frontMatterMatch = [Regex]::Match($normalized, "\A---\n(?<front>.*?)\n---(?:\n|\z)", [Text.RegularExpressions.RegexOptions]::Singleline)
    if ($frontMatterMatch.Success) {
        $frontMatter = $frontMatterMatch.Groups["front"].Value
        $body = $normalized.Substring($frontMatterMatch.Length)
    }

    return [PSCustomObject]@{
        FrontMatter = $frontMatter
        Body = $body
        Uid = Get-FrontMatterValue -FrontMatter $frontMatter -Name "uid"
        Description = Get-FrontMatterValue -FrontMatter $frontMatter -Name "description"
        ContentType = Get-FrontMatterValue -FrontMatter $frontMatter -Name "content_type"
        Authority = Get-FrontMatterValue -FrontMatter $frontMatter -Name "authority"
        Lifecycle = Get-FrontMatterValue -FrontMatter $frontMatter -Name "lifecycle"
        CompatibilityUid = Get-FrontMatterNestedValue -FrontMatter $frontMatter -Name "uid"
        CompatibilityUrl = Get-FrontMatterNestedValue -FrontMatter $frontMatter -Name "url"
    }
}

function Get-MarkdownTitle {
    param([Parameter(Mandatory = $true)][string]$Body)

    $match = [Regex]::Match($Body, "(?m)^\s*#\s+(?<title>.+?)\s*$")
    if (-not $match.Success) {
        return ""
    }

    return $match.Groups["title"].Value.Trim()
}

function Get-CodeBlocks {
    param([Parameter(Mandatory = $true)][string]$Body)

    $blocks = @()
    $patterns = @(
        '(?ms)^[ \t]*```[ \t]*(?<language>[^\r\n`]*)\r?\n(?<code>.*?)^[ \t]*```[ \t]*$',
        '(?ms)^[ \t]*~~~[ \t]*(?<language>[^\r\n~]*)\r?\n(?<code>.*?)^[ \t]*~~~[ \t]*$'
    )

    foreach ($pattern in $patterns) {
        foreach ($match in [Regex]::Matches($Body, $pattern)) {
            $languageInfo = $match.Groups["language"].Value.Trim()
            $language = ($languageInfo -split "\s+")[0].ToLowerInvariant()
            if ($language -eq "") {
                $language = "untyped"
            }

            $snippetType = "typed"
            if ($language -in @("text", "txt", "plaintext", "none", "pseudocode", "untyped")) {
                $snippetType = "text-or-pseudocode"
            }

            $blocks += [PSCustomObject]@{
                Language = $language
                Type = $snippetType
            }
        }
    }

    return @($blocks | Sort-Object Language, Type)
}

function Get-MarkdownMetrics {
    param([Parameter(Mandatory = $true)][string]$Body)

    $codeBlocks = @(Get-CodeBlocks $Body)
    $plainText = $Body
    $plainText = [Regex]::Replace($plainText, '(?ms)^[ \t]*(```|~~~).*?^[ \t]*\1[ \t]*$', "")
    $plainText = [Regex]::Replace($plainText, "(?s)<!--.*?-->", "")
    $plainText = [Regex]::Replace($plainText, "!\[[^\]]*\]\([^)]*\)", "")
    $plainText = [Regex]::Replace($plainText, "\[([^\]]+)\]\([^)]*\)", '$1')
    $plainText = [Regex]::Replace($plainText, "[#>*_`~|]", "")
    $contentCharacters = ($plainText -replace "\s", "").Length

    $links = @([Regex]::Matches($Body, "\[[^\]]*\]\((?<target>[^)\s]+)(?:\s+[^)]*)?\)"))
    $externalLinks = 0
    $localLinks = 0
    foreach ($link in $links) {
        $target = $link.Groups["target"].Value
        if ($target -match "^(?i:https?://|mailto:)") {
            $externalLinks++
        }
        elseif (-not $target.StartsWith("#")) {
            $localLinks++
        }
    }

    $xrefCount = @([Regex]::Matches($Body, "(?i)\bxref:[A-Za-z0-9_.-]+")).Count
    $versionStatementCount = @([Regex]::Matches($Body, "(?i)\b(?:DataMiner\s+)?v?(?:9|10)\.\d+(?:\.\d+){0,2}\b")).Count

    $languageCounts = @{}
    $snippetTypeCounts = @{}
    foreach ($block in $codeBlocks) {
        if (-not $languageCounts.ContainsKey($block.Language)) {
            $languageCounts[$block.Language] = 0
        }
        $languageCounts[$block.Language]++
        if (-not $snippetTypeCounts.ContainsKey($block.Type)) {
            $snippetTypeCounts[$block.Type] = 0
        }
        $snippetTypeCounts[$block.Type]++
    }

    return [PSCustomObject]@{
        BodyCharacters = $Body.Length
        ContentCharacters = $contentCharacters
        CodeBlockCount = $codeBlocks.Count
        CodeLanguages = ConvertTo-CountObject $languageCounts
        SnippetTypes = ConvertTo-CountObject $snippetTypeCounts
        LinkCount = $links.Count
        ExternalLinkCount = $externalLinks
        LocalLinkCount = $localLinks
        XrefCount = $xrefCount
        VersionStatementCount = $versionStatementCount
    }
}

function Get-ContentCategory {
    param(
        [AllowEmptyString()][string]$RelativePath,
        [AllowEmptyString()][string]$ManifestType
    )

    $path = $RelativePath.ToLowerInvariant()
    if ($ManifestType -eq "Resource") {
        return "resource"
    }
    if ($ManifestType -eq "Toc" -or $path.EndsWith("/toc.yml") -or $path -eq "toc.yml") {
        return "toc"
    }
    if ($ManifestType -eq "ManagedReference" -or $path.StartsWith("develop/api/")) {
        return "api"
    }
    if ($path.StartsWith("release-notes/")) {
        return "release-note"
    }
    if ($path.StartsWith("develop/schemadoc/")) {
        return "schema"
    }

    return "conceptual"
}

function Get-DocumentationDomain {
    param([AllowEmptyString()][string]$Path)

    $path = $Path.ToLowerInvariant()
    if (
        $path -match "(^|/)develop/devguide/connector(/|$)" -or
        $path -match "(^|/)develop/schemadoc/protocol(/|$)" -or
        $path -match "(^|/)develop/codingguidelines/protocol(/|$)" -or
        $path -match "(^|/)develop/tools/dis(/|$)"
    ) {
        return "Connector"
    }
    if (
        $path -match "(^|/)develop/devguide/automation(/|$)" -or
        $path -match "(^|/)develop/schemadoc/automation(/|$)" -or
        $path -match "(^|/)dataminer/functions/automation_module(/|$)" -or
        $path -match "(^|/)develop/api/.+(automation|scriptparam|interactivity)"
    ) {
        return "Automation"
    }

    return ""
}

function ConvertTo-CountObject {
    param([hashtable]$Counts)

    $result = [ordered]@{}
    foreach ($key in @($Counts.Keys | Sort-Object)) {
        $result[$key] = [int]$Counts[$key]
    }

    return [PSCustomObject]$result
}

function Add-Count {
    param(
        [hashtable]$Counts,
        [string]$Key
    )

    if (-not $Counts.ContainsKey($Key)) {
        $Counts[$Key] = 0
    }
    $Counts[$Key]++
}

function Get-SourceFiles {
    $files = @()
    foreach ($file in Get-ChildItem -LiteralPath $script:RepositoryRoot -File -Filter "*.md") {
        $files += $file
    }

    foreach ($directoryName in @("contributing", "dataminer", "develop", "release-notes", "solutions", "tutorials")) {
        $directoryPath = Join-Path $script:RepositoryRoot $directoryName
        if (-not (Test-Path -LiteralPath $directoryPath -PathType Container)) {
            continue
        }

        $files += @(Get-ChildItem -LiteralPath $directoryPath -Recurse -File | Where-Object { $_.Extension -ieq ".md" })
    }

    return @($files | Sort-Object FullName -Unique)
}

function Get-SourceRecord {
    param([Parameter(Mandatory = $true)][IO.FileInfo]$File)

    $relativePath = ConvertTo-RepositoryRelativePath $File.FullName
    $text = Normalize-Text ([IO.File]::ReadAllText($File.FullName))
    $parts = Get-MarkdownParts $text
    $metrics = Get-MarkdownMetrics $parts.Body
    $category = Get-ContentCategory $relativePath ""
    $domain = Get-DocumentationDomain $relativePath

    return [PSCustomObject][ordered]@{
        path = $relativePath
        category = $category
        domain = $domain
        uid = $parts.Uid
        type = if ([String]::IsNullOrWhiteSpace($parts.ContentType)) { $category } else { $parts.ContentType }
        authority = if ([String]::IsNullOrWhiteSpace($parts.Authority)) { "unknown" } else { $parts.Authority }
        lifecycle = if ([String]::IsNullOrWhiteSpace($parts.Lifecycle)) { "unknown" } else { $parts.Lifecycle }
        compatibilityUid = if ([String]::IsNullOrWhiteSpace($parts.CompatibilityUid)) { "unknown" } else { $parts.CompatibilityUid }
        compatibilityUrl = if ([String]::IsNullOrWhiteSpace($parts.CompatibilityUrl)) { "unknown" } else { $parts.CompatibilityUrl }
        title = Get-MarkdownTitle $parts.Body
        hasDescription = -not [String]::IsNullOrWhiteSpace($parts.Description)
        descriptionCharacters = $parts.Description.Length
        characters = $text.Length
        bodyCharacters = $metrics.BodyCharacters
        contentCharacters = $metrics.ContentCharacters
        codeBlockCount = $metrics.CodeBlockCount
        codeLanguages = $metrics.CodeLanguages
        snippetTypes = $metrics.SnippetTypes
        linkCount = $metrics.LinkCount
        externalLinkCount = $metrics.ExternalLinkCount
        localLinkCount = $metrics.LocalLinkCount
        xrefCount = $metrics.XrefCount
        versionStatementCount = $metrics.VersionStatementCount
        contentSha256 = Get-TextSha256 $text
    }
}

function Get-PageMetrics {
    param([Parameter(Mandatory = $true)][object[]]$Records)

    $categoryCounts = @{}
    $domainCounts = @{}
    $pagesWithUid = 0
    $pagesWithDescription = 0
    $codeBlockCount = 0
    $linkCount = 0
    $xrefCount = 0
    $versionStatementCount = 0

    foreach ($record in $Records) {
        Add-Count $categoryCounts $record.category
        if ($record.domain -ne "") {
            Add-Count $domainCounts $record.domain
        }
        if ($record.uid -ne "") {
            $pagesWithUid++
        }
        if ($record.hasDescription) {
            $pagesWithDescription++
        }
        $codeBlockCount += $record.codeBlockCount
        $linkCount += $record.linkCount
        $xrefCount += $record.xrefCount
        $versionStatementCount += $record.versionStatementCount
    }

    return [PSCustomObject][ordered]@{
        pages = $Records.Count
        byCategory = ConvertTo-CountObject $categoryCounts
        byDomain = ConvertTo-CountObject $domainCounts
        pagesWithUid = $pagesWithUid
        pagesWithoutUid = $Records.Count - $pagesWithUid
        pagesWithDescription = $pagesWithDescription
        pagesWithoutDescription = $Records.Count - $pagesWithDescription
        codeBlockCount = $codeBlockCount
        linkCount = $linkCount
        xrefCount = $xrefCount
        versionStatementCount = $versionStatementCount
    }
}

function Get-ConfigurationInfo {
    $docfxPath = Join-Path $script:RepositoryRoot "docfx.json"
    $buildScriptPath = Join-Path $script:RepositoryRoot "buildDocs.cmd"
    $info = [ordered]@{
        docfx = [ordered]@{
            path = "docfx.json"
            available = $false
            sha256 = ""
            contentPatterns = @()
            resourcePatterns = @()
            xrefSources = @()
            sitemap = [PSCustomObject]@{}
        }
        localBuildScript = [ordered]@{
            path = "buildDocs.cmd"
            available = $false
            sha256 = ""
        }
    }

    if (Test-Path -LiteralPath $docfxPath -PathType Leaf) {
        $config = Get-Content -LiteralPath $docfxPath -Raw | ConvertFrom-Json
        $contentPatterns = @()
        foreach ($contentGroup in @($config.build.content)) {
            foreach ($pattern in @($contentGroup.files)) {
                $contentPatterns += [string]$pattern
            }
        }

        $resourcePatterns = @()
        foreach ($resourceGroup in @($config.build.resource)) {
            foreach ($pattern in @($resourceGroup.files)) {
                $resourcePatterns += [string]$pattern
            }
        }

        $xrefSources = @()
        foreach ($xrefSource in @($config.build.xref)) {
            $xrefSources += [string]$xrefSource
        }

        $info.docfx.available = $true
        $info.docfx.sha256 = Get-FileSha256 $docfxPath
        $info.docfx.contentPatterns = @($contentPatterns | Sort-Object -Unique)
        $info.docfx.resourcePatterns = @($resourcePatterns | Sort-Object -Unique)
        $info.docfx.xrefSources = @($xrefSources | Sort-Object -Unique)
        $info.docfx.sitemap = [PSCustomObject][ordered]@{
            baseUrl = [string]$config.build.sitemap.baseUrl
            changeFrequency = [string]$config.build.sitemap.changefreq
        }
    }

    if (Test-Path -LiteralPath $buildScriptPath -PathType Leaf) {
        $info.localBuildScript.available = $true
        $info.localBuildScript.sha256 = Get-FileSha256 $buildScriptPath
    }

    return [PSCustomObject]$info
}

function Get-ManifestOutputPaths {
    param([Parameter(Mandatory = $true)]$Entry)

    $paths = @()
    if ($null -eq $Entry.output) {
        return $paths
    }

    foreach ($property in $Entry.output.PSObject.Properties) {
        if ($null -ne $property.Value -and $null -ne $property.Value.relative_path) {
            $paths += [string]$property.Value.relative_path
        }
    }

    return @($paths | Sort-Object -Unique)
}

function Get-ManifestInfo {
    param([AllowEmptyString()][string]$Path)

    $info = [ordered]@{
        available = $false
        artifact = "manifest.json"
        source = $script:ManifestSource
        sha256 = ""
        entryCount = 0
        outputCount = 0
        sourceBasePathPresent = $false
        xrefmap = ""
        byType = [PSCustomObject]@{}
        byCategory = [PSCustomObject]@{}
        byDomain = [PSCustomObject]@{}
        byOutputExtension = [PSCustomObject]@{}
        versionedEntries = 0
    }

    if ([String]::IsNullOrWhiteSpace($Path)) {
        return [PSCustomObject]$info
    }
    if (-not (Test-Path -LiteralPath $Path -PathType Leaf)) {
        return [PSCustomObject]$info
    }

    $manifest = Get-Content -LiteralPath $Path -Raw | ConvertFrom-Json
    $entries = @($manifest.files)
    $typeCounts = @{}
    $categoryCounts = @{}
    $domainCounts = @{}
    $outputExtensionCounts = @{}
    foreach ($entry in $entries) {
        $sourcePath = [string]$entry.source_relative_path
        $type = [string]$entry.type
        $category = Get-ContentCategory $sourcePath $type
        $domain = Get-DocumentationDomain $sourcePath
        Add-Count $typeCounts $type
        Add-Count $categoryCounts $category
        if ($domain -ne "") {
            Add-Count $domainCounts $domain
        }
        if (-not [String]::IsNullOrWhiteSpace([string]$entry.version)) {
            $info.versionedEntries++
        }

        $outputPaths = @(Get-ManifestOutputPaths $entry)
        $info.outputCount += $outputPaths.Count
        foreach ($outputPath in $outputPaths) {
            $extension = [IO.Path]::GetExtension($outputPath).ToLowerInvariant()
            if ($extension -eq "") {
                $extension = "(none)"
            }
            Add-Count $outputExtensionCounts $extension
        }
    }

    $info.available = $true
    $info.sha256 = Get-FileSha256 $Path
    $info.entryCount = $entries.Count
    $info.sourceBasePathPresent = $null -ne $manifest.source_base_path
    $info.xrefmap = [string]$manifest.xrefmap
    $info.byType = ConvertTo-CountObject $typeCounts
    $info.byCategory = ConvertTo-CountObject $categoryCounts
    $info.byDomain = ConvertTo-CountObject $domainCounts
    $info.byOutputExtension = ConvertTo-CountObject $outputExtensionCounts

    return [PSCustomObject]$info
}

function Get-XrefEntries {
    param([Parameter(Mandatory = $true)][string]$Path)

    $entries = @()
    $current = $null
    foreach ($line in Get-Content -LiteralPath $Path) {
        $uidMatch = [Regex]::Match($line, "^\s*(?:-\s+)?uid:\s*(?<value>.+?)\s*$")
        if ($uidMatch.Success) {
            if ($null -ne $current) {
                $entries += [PSCustomObject]$current
            }
            $current = [ordered]@{
                uid = Get-YamlScalar $uidMatch.Groups["value"].Value
                name = ""
                href = ""
            }
            continue
        }

        if ($null -eq $current) {
            continue
        }

        $nameMatch = [Regex]::Match($line, "^\s+name:\s*(?<value>.+?)\s*$")
        if ($nameMatch.Success) {
            $current.name = Get-YamlScalar $nameMatch.Groups["value"].Value
            continue
        }

        $hrefMatch = [Regex]::Match($line, "^\s+href:\s*(?<value>.+?)\s*$")
        if ($hrefMatch.Success) {
            $current.href = Get-YamlScalar $hrefMatch.Groups["value"].Value
        }
    }

    if ($null -ne $current) {
        $entries += [PSCustomObject]$current
    }

    return @($entries | Where-Object { $_.uid -ne "" } | Sort-Object uid, href)
}

function Get-XrefInfo {
    param([AllowEmptyString()][string]$Path)

    $info = [ordered]@{
        available = $false
        artifact = "xrefmap.yml"
        source = $script:XrefMapSource
        sha256 = ""
        referenceCount = 0
        referencesWithoutHref = 0
        duplicateUidCount = 0
    }
    $script:XrefEntries = @()

    if ([String]::IsNullOrWhiteSpace($Path)) {
        return [PSCustomObject]$info
    }
    if (-not (Test-Path -LiteralPath $Path -PathType Leaf)) {
        return [PSCustomObject]$info
    }

    $entries = @(Get-XrefEntries $Path)
    $duplicateUidCount = @($entries | Group-Object uid | Where-Object { $_.Count -gt 1 }).Count
    $info.available = $true
    $info.sha256 = Get-FileSha256 $Path
    $info.referenceCount = $entries.Count
    $info.referencesWithoutHref = @($entries | Where-Object { $_.href -eq "" }).Count
    $info.duplicateUidCount = $duplicateUidCount
    $script:XrefEntries = $entries

    return [PSCustomObject]$info
}

function Get-SitemapInfo {
    param([AllowEmptyString()][string]$Path)

    $info = [ordered]@{
        available = $false
        artifact = "sitemap.xml"
        source = $script:SitemapSource
        sha256 = ""
        urlCount = 0
        duplicateUrlCount = 0
        byLastModified = [PSCustomObject]@{}
        byChangeFrequency = [PSCustomObject]@{}
        byPriority = [PSCustomObject]@{}
    }
    if ([String]::IsNullOrWhiteSpace($Path)) {
        return [PSCustomObject]$info
    }
    if (-not (Test-Path -LiteralPath $Path -PathType Leaf)) {
        return [PSCustomObject]$info
    }

    $xml = New-Object System.Xml.XmlDocument
    $xml.Load($Path)
    $entries = @()
    foreach ($node in $xml.SelectNodes("//*[local-name()='url']")) {
        $values = @{}
        foreach ($child in $node.ChildNodes) {
            $values[$child.LocalName] = [string]$child.InnerText
        }
        $entries += [PSCustomObject][ordered]@{
            loc = [string]$values["loc"]
            lastmod = [string]$values["lastmod"]
            changefreq = [string]$values["changefreq"]
            priority = [string]$values["priority"]
        }
    }

    $lastModifiedCounts = @{}
    $changeFrequencyCounts = @{}
    $priorityCounts = @{}
    foreach ($entry in $entries) {
        Add-Count $lastModifiedCounts $entry.lastmod
        Add-Count $changeFrequencyCounts $entry.changefreq
        Add-Count $priorityCounts $entry.priority
    }

    $info.available = $true
    $info.sha256 = Get-FileSha256 $Path
    $info.urlCount = $entries.Count
    $info.duplicateUrlCount = @($entries | Group-Object loc | Where-Object { $_.Count -gt 1 }).Count
    $info.byLastModified = ConvertTo-CountObject $lastModifiedCounts
    $info.byChangeFrequency = ConvertTo-CountObject $changeFrequencyCounts
    $info.byPriority = ConvertTo-CountObject $priorityCounts

    return [PSCustomObject]$info
}

function ConvertTo-OutputPath {
    param([Parameter(Mandatory = $true)][string]$Path)

    $output = $Path.Replace("\", "/")
    if ($output.EndsWith(".md", [StringComparison]::OrdinalIgnoreCase)) {
        $output = $output.Substring(0, $output.Length - 3) + ".html"
    }

    $segments = @($output.Split("/") | ForEach-Object { [Uri]::EscapeDataString($_) })
    return ($segments -join "/")
}

function Get-CompatibilityEntries {
    param([Parameter(Mandatory = $true)][object[]]$SourceRecords)

    $compatibility = @()
    if (@($script:XrefEntries).Count -gt 0) {
        foreach ($reference in @($script:XrefEntries)) {
            if ($reference.href -eq "") {
                continue
            }

            $compatibility += [PSCustomObject][ordered]@{
                uid = $reference.uid
                href = $reference.href
            }
        }
    }
    else {
        foreach ($record in $SourceRecords | Where-Object { $_.uid -ne "" }) {
            $href = ConvertTo-OutputPath $record.path
            $compatibility += [PSCustomObject][ordered]@{
                uid = $record.uid
                href = $href
            }
        }
    }

    return @($compatibility | Sort-Object uid, href)
}

function Get-SourceBlobUrl {
    param([Parameter(Mandatory = $true)][string]$Path)

    if ([String]::IsNullOrWhiteSpace($SourceRevision) -or $SourceRevision -eq "working-tree") {
        return ""
    }

    return "https://github.com/SkylineCommunications/dataminer-docs/blob/{0}/{1}" -f $SourceRevision, $Path
}

function Get-MetadataManifest {
    param([Parameter(Mandatory = $true)][object[]]$SourceRecords)

    $entries = @()
    foreach ($record in @($SourceRecords | Where-Object { $_.uid -ne "" } | Sort-Object uid, path)) {
        $outputPath = ConvertTo-OutputPath $record.path
        $entries += [PSCustomObject][ordered]@{
            uid = $record.uid
            url = $script:BaseUrl + $outputPath
            sourceCommit = $SourceRevision
            sourceBlob = Get-SourceBlobUrl $record.path
            contentHash = $record.contentSha256
            type = $record.type
            authority = $record.authority
            lifecycle = $record.lifecycle
            compatibility = [PSCustomObject][ordered]@{
                uid = $record.compatibilityUid
                url = $record.compatibilityUrl
            }
            license = $script:LicenseIdentifier
            attribution = $script:Attribution
        }
    }

    return [PSCustomObject][ordered]@{
        schemaVersion = $script:MetadataManifestSchemaVersion
        visibility = "metadata-only"
        sourceRevision = $SourceRevision
        generator = [PSCustomObject][ordered]@{
            name = $script:GeneratorName
            version = $script:GeneratorVersion
        }
        scope = [PSCustomObject][ordered]@{
            sourcePaths = @(
                "*.md",
                "contributing/**.md",
                "dataminer/**.md",
                "develop/**.md",
                "release-notes/**.md",
                "solutions/**.md",
                "tutorials/**.md"
            )
            domains = @("Connector", "Automation")
        }
        license = [PSCustomObject][ordered]@{
            identifier = $script:LicenseIdentifier
            name = $script:LicenseName
            url = $script:LicenseUrl
        }
        attribution = $script:Attribution
        entries = $entries
    }
}

function Get-DomainMetrics {
    param(
        [Parameter(Mandatory = $true)][object[]]$Records,
        [Parameter(Mandatory = $true)][string]$Domain
    )

    $domainRecords = @($Records | Where-Object { $_.domain -eq $Domain })
    $metrics = Get-PageMetrics $domainRecords
    $metrics | Add-Member -NotePropertyName oversizedPages -NotePropertyValue @($domainRecords | Where-Object { $_.characters -gt $script:OversizedPageCharacters } | Select-Object path, characters, category)
    $metrics | Add-Member -NotePropertyName stubPages -NotePropertyValue @($domainRecords | Where-Object { $_.contentCharacters -lt $script:StubPageCharacters } | Select-Object path, contentCharacters, category)
    return $metrics
}

$script:RepositoryRoot = ConvertTo-FullPath $RepositoryRoot
if (-not (Test-Path -LiteralPath $script:RepositoryRoot -PathType Container)) {
    throw "Repository root '$script:RepositoryRoot' does not exist."
}

if ([String]::IsNullOrWhiteSpace($SitePath)) {
    $SitePath = Join-Path $script:RepositoryRoot "_site"
}
else {
    $SitePath = ConvertTo-FullPath $SitePath
}

if ([String]::IsNullOrWhiteSpace($ManifestPath) -and (Test-Path -LiteralPath $SitePath -PathType Container)) {
    $ManifestPath = Join-Path $SitePath "manifest.json"
}
if ([String]::IsNullOrWhiteSpace($XrefMapPath) -and (Test-Path -LiteralPath $SitePath -PathType Container)) {
    $XrefMapPath = Join-Path $SitePath "xrefmap.yml"
}
if ([String]::IsNullOrWhiteSpace($SitemapPath) -and (Test-Path -LiteralPath $SitePath -PathType Container)) {
    $SitemapPath = Join-Path $SitePath "sitemap.xml"
}

if (-not [IO.Path]::IsPathRooted($OutputPath)) {
    $OutputPath = Join-Path $script:RepositoryRoot $OutputPath
}
$OutputPath = [IO.Path]::GetFullPath($OutputPath)
$script:BaseUrl = $BaseUrl.TrimEnd("/") + "/"
$script:ManifestSource = $ManifestSource
$script:XrefMapSource = $XrefMapSource
$script:SitemapSource = $SitemapSource
$script:OversizedPageCharacters = $OversizedPageCharacters
$script:StubPageCharacters = $StubPageCharacters
$script:XrefEntries = @()

$sourceRecords = @(Get-SourceFiles | ForEach-Object { Get-SourceRecord $_ } | Sort-Object path)
$pageMetrics = Get-PageMetrics $sourceRecords
$uidGroups = @($sourceRecords | Where-Object { $_.uid -ne "" } | Group-Object uid | Sort-Object Name)
$duplicateUids = @(
    $uidGroups |
        Where-Object { $_.Count -gt 1 } |
        ForEach-Object {
            [PSCustomObject][ordered]@{
                uid = $_.Name
                paths = @($_.Group | Sort-Object path | ForEach-Object { $_.path })
            }
        }
)
$missingUids = @($sourceRecords | Where-Object { $_.uid -eq "" } | ForEach-Object { $_.path })
$missingDescriptions = @($sourceRecords | Where-Object { -not $_.hasDescription } | ForEach-Object { $_.path })
$oversizedPages = @(
    $sourceRecords |
        Where-Object { $_.characters -gt $OversizedPageCharacters } |
        Select-Object path, category, domain, characters, contentCharacters
)
$stubPages = @(
    $sourceRecords |
        Where-Object { $_.contentCharacters -lt $StubPageCharacters } |
        Select-Object path, category, domain, contentCharacters, bodyCharacters
)

$languageCounts = @{}
$snippetTypeCounts = @{}
foreach ($record in $sourceRecords) {
    foreach ($languageProperty in $record.codeLanguages.PSObject.Properties) {
        if (-not $languageCounts.ContainsKey($languageProperty.Name)) {
            $languageCounts[$languageProperty.Name] = 0
        }
        $languageCounts[$languageProperty.Name] += [int]$languageProperty.Value
    }
    foreach ($typeProperty in $record.snippetTypes.PSObject.Properties) {
        if (-not $snippetTypeCounts.ContainsKey($typeProperty.Name)) {
            $snippetTypeCounts[$typeProperty.Name] = 0
        }
        $snippetTypeCounts[$typeProperty.Name] += [int]$typeProperty.Value
    }
}

$manifestInfo = Get-ManifestInfo $ManifestPath
$xrefInfo = Get-XrefInfo $XrefMapPath
$sitemapInfo = Get-SitemapInfo $SitemapPath
$configurationInfo = Get-ConfigurationInfo
$compatibilityEntries = @(Get-CompatibilityEntries $sourceRecords)
$metadataManifest = Get-MetadataManifest $sourceRecords

$baseline = [PSCustomObject][ordered]@{
    schemaVersion = $script:BaselineSchemaVersion
    generator = [PSCustomObject][ordered]@{
        name = $script:GeneratorName
        version = $script:GeneratorVersion
    }
    license = [PSCustomObject][ordered]@{
        identifier = $script:LicenseIdentifier
        name = $script:LicenseName
        url = $script:LicenseUrl
        attribution = $script:Attribution
    }
    baseline = [PSCustomObject][ordered]@{
        id = "D0.3"
        repository = "SkylineCommunications/dataminer-docs"
        sourceRevision = $SourceRevision
        baseUrl = $script:BaseUrl
        compatibilitySource = if ($xrefInfo.available) { "xrefmap" } else { "source-derived" }
        scope = [PSCustomObject][ordered]@{
            sourcePaths = @(
                "*.md",
                "contributing/**.md",
                "dataminer/**.md",
                "develop/**.md",
                "release-notes/**.md",
                "solutions/**.md",
                "tutorials/**.md"
            )
            generatedArtifacts = @("manifest.json", "xrefmap.yml", "sitemap.xml")
        }
        thresholds = [PSCustomObject][ordered]@{
            oversizedPageCharacters = $OversizedPageCharacters
            stubPageCharacters = $StubPageCharacters
        }
        domainScopes = [PSCustomObject][ordered]@{
            Connector = @(
                "develop/devguide/Connector/**",
                "develop/schemadoc/Protocol/**",
                "develop/codingguidelines/Protocol/**",
                "develop/TOOLS/DIS/**"
            )
            Automation = @(
                "develop/devguide/Automation/**",
                "develop/schemadoc/Automation/**",
                "dataminer/Functions/Automation_module/**",
                "develop/api/** with Automation, ScriptParam, or Interactivity in the path"
            )
        }
    }
    configuration = $configurationInfo
    source = [PSCustomObject][ordered]@{
        metrics = $pageMetrics
        connector = Get-DomainMetrics $sourceRecords "Connector"
        automation = Get-DomainMetrics $sourceRecords "Automation"
        uid = [PSCustomObject][ordered]@{
            pagesWithUid = $pageMetrics.pagesWithUid
            pagesWithoutUid = $pageMetrics.pagesWithoutUid
            duplicateUidCount = $duplicateUids.Count
            duplicateUids = $duplicateUids
            missingUidPaths = $missingUids
        }
        descriptions = [PSCustomObject][ordered]@{
            pagesWithDescription = $pageMetrics.pagesWithDescription
            pagesWithoutDescription = $pageMetrics.pagesWithoutDescription
            missingDescriptionPaths = $missingDescriptions
        }
        size = [PSCustomObject][ordered]@{
            oversizedPageCount = $oversizedPages.Count
            oversizedPages = $oversizedPages
        }
        stubs = [PSCustomObject][ordered]@{
            stubPageCount = $stubPages.Count
            stubPages = $stubPages
        }
        snippets = [PSCustomObject][ordered]@{
            codeBlockCount = $pageMetrics.codeBlockCount
            languages = ConvertTo-CountObject $languageCounts
            types = ConvertTo-CountObject $snippetTypeCounts
        }
        links = [PSCustomObject][ordered]@{
            linkCount = $pageMetrics.linkCount
            xrefCount = $pageMetrics.xrefCount
            externalLinkCount = [int](($sourceRecords | Measure-Object externalLinkCount -Sum).Sum)
            localLinkCount = [int](($sourceRecords | Measure-Object localLinkCount -Sum).Sum)
        }
        versionStatements = [PSCustomObject][ordered]@{
            occurrenceCount = $pageMetrics.versionStatementCount
            pagesWithStatements = @($sourceRecords | Where-Object { $_.versionStatementCount -gt 0 } | ForEach-Object { $_.path })
        }
    }
    generated = [PSCustomObject][ordered]@{
        manifest = $manifestInfo
        xrefmap = $xrefInfo
        sitemap = $sitemapInfo
    }
    compatibility = $compatibilityEntries
    metadataManifest = $metadataManifest
}

$outputDirectory = Split-Path -Parent $OutputPath
if (-not (Test-Path -LiteralPath $outputDirectory -PathType Container)) {
    New-Item -ItemType Directory -Path $outputDirectory -Force | Out-Null
}

$json = $baseline | ConvertTo-Json -Depth 30
$utf8NoBom = New-Object Text.UTF8Encoding($false)
[IO.File]::WriteAllText($OutputPath, $json + [Environment]::NewLine, $utf8NoBom)

Write-Output ("Wrote {0}: {1} source pages, {2} compatibility records." -f $OutputPath, $sourceRecords.Count, $compatibilityEntries.Count)
