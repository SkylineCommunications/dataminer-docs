[CmdletBinding()]
param(
    [string]$RepositoryRoot = (Join-Path $PSScriptRoot ".."),
    [string]$SitePath = (Join-Path $PSScriptRoot "..\_site"),
    [string]$InputSitemapPath = "",
    [string]$DocFxManifestPath = "",
    [string]$MetadataManifestPath = "",
    [string]$GeneratedProvenancePath = "",
    [string]$OutputPath = (Join-Path $PSScriptRoot "..\_artifacts\segmented-sitemap-report.json"),
    [string]$BaseUrl = "https://docs.dataminer.services/",
    [string]$SourceRevision = ""
)

Set-StrictMode -Version 2.0
$ErrorActionPreference = "Stop"

$script:GeneratorVersion = "1.0.0"
$script:SitemapNamespace = "http://www.sitemaps.org/schemas/sitemap/0.9"
$script:Repository = "SkylineCommunications/dataminer-docs"
$script:Root = $null
$script:OutputSite = $null
$script:PublicBaseUrl = $null
$script:SourceRevision = ""
$script:SourceRevisionSource = "unavailable"
$script:GitTimestampCache = @{}
$script:TimestampCacheInitialized = $false
$script:DocFxOutputMap = @{}
$script:MetadataBySourcePath = @{}
$script:ProvenanceByOutputPath = @{}
$script:GapRecords = New-Object "System.Collections.Generic.List[object]"

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

function Normalize-RepositoryPath {
    param([AllowEmptyString()][string]$Path)

    if ([String]::IsNullOrWhiteSpace($Path)) {
        return ""
    }

    return $Path.Replace("\", "/").TrimStart("/")
}

function Normalize-BaseUrl {
    param([Parameter(Mandatory = $true)][string]$Value)

    $normalized = $Value.Trim()
    if (-not $normalized.EndsWith("/")) {
        $normalized += "/"
    }

    $uri = $null
    if (-not [Uri]::TryCreate($normalized, [UriKind]::Absolute, [ref]$uri) -or
        $uri.Scheme -notin @("http", "https")) {
        throw "Base URL '$Value' is not an absolute HTTP(S) URL."
    }

    return $normalized
}

function Add-Gap {
    param(
        [Parameter(Mandatory = $true)][string]$Code,
        [AllowEmptyString()][string]$Path = "",
        [AllowEmptyString()][string]$Message = ""
    )

    $script:GapRecords.Add([PSCustomObject][ordered]@{
            code = $Code
            path = $Path
            message = $Message
        })
}

function Get-GitOutput {
    param([Parameter(Mandatory = $true)][string[]]$Arguments)

    try {
        $result = & git -C $script:Root @Arguments 2>$null
        if ($LASTEXITCODE -eq 0) {
            return (($result -join "`n").Trim())
        }
    }
    catch {
        return ""
    }

    return ""
}

function Resolve-SourceRevision {
    param([AllowEmptyString()][string]$RequestedRevision)

    if (-not [String]::IsNullOrWhiteSpace($RequestedRevision) -and $RequestedRevision -ne "working-tree") {
        $revision = $RequestedRevision.Trim().ToLowerInvariant()
        if ($revision -match "^[0-9a-f]{40}$") {
            $script:SourceRevisionSource = "argument"
            return $revision
        }

        Add-Gap -Code "source-revision-invalid" -Message "The supplied source revision is not a full commit SHA."
        return ""
    }

    $revision = Get-GitOutput -Arguments @("rev-parse", "HEAD")
    if ($revision -match "^[0-9a-fA-F]{40}$") {
        $script:SourceRevisionSource = "git"
        return $revision.ToLowerInvariant()
    }

    Add-Gap -Code "source-revision-unavailable" -Message "Git did not provide a full source commit SHA."
    return ""
}

function Get-UrlPathKey {
    param([Parameter(Mandatory = $true)][string]$Url)

    try {
        $uri = [Uri]$Url
        return [Uri]::UnescapeDataString($uri.AbsolutePath.TrimStart("/"))
    }
    catch {
        return [Uri]::UnescapeDataString($Url.TrimStart("/"))
    }
}

function ConvertTo-UrlPath {
    param([Parameter(Mandatory = $true)][string]$Path)

    $segments = @(
        (Normalize-RepositoryPath $Path).Split("/") |
            ForEach-Object { [Uri]::EscapeDataString($_) }
    )
    return ($segments -join "/")
}

function ConvertTo-PublicUrl {
    param([Parameter(Mandatory = $true)][string]$Path)

    return $script:PublicBaseUrl + (ConvertTo-UrlPath $Path)
}

function Get-LocalPathFromSitemapUrl {
    param([Parameter(Mandatory = $true)][string]$Url)

    try {
        $uri = [Uri]$Url
        $baseUri = [Uri]$script:PublicBaseUrl
        if ($uri.Scheme -ne $baseUri.Scheme -or
            $uri.Host -ne $baseUri.Host -or
            $uri.Port -ne $baseUri.Port) {
            return $null
        }
        $relativePath = [Uri]::UnescapeDataString($uri.AbsolutePath.TrimStart("/"))
    }
    catch {
        return $null
    }

    if ([String]::IsNullOrWhiteSpace($relativePath) -or
        $relativePath -match "(^|/)\.\.?(/|$)") {
        return $null
    }

    $candidate = [IO.Path]::GetFullPath((Join-Path $script:OutputSite $relativePath.Replace("/", "\")))
    $sitePrefix = $script:OutputSite.TrimEnd("\") + "\"
    if (-not $candidate.StartsWith($sitePrefix, [StringComparison]::OrdinalIgnoreCase) -and
        $candidate -ne $script:OutputSite) {
        return $null
    }

    return $candidate
}

function Get-LocalSitemapPath {
    param([Parameter(Mandatory = $true)][string]$Location)

    $path = Get-LocalPathFromSitemapUrl -Url $Location
    if ($null -ne $path) {
        return $path
    }

    if ($Location -match "^[^:/?#]+\.xml$") {
        $relativePath = [Uri]::UnescapeDataString($Location.TrimStart("/"))
        if ($relativePath -notmatch "(^|/)\.\.?(/|$)") {
            $candidate = [IO.Path]::GetFullPath((Join-Path $script:OutputSite $relativePath.Replace("/", "\")))
            $sitePrefix = $script:OutputSite.TrimEnd("\") + "\"
            if ($candidate.StartsWith($sitePrefix, [StringComparison]::OrdinalIgnoreCase)) {
                return $candidate
            }
        }
    }

    return $null
}

function Read-SitemapFile {
    param(
        [Parameter(Mandatory = $true)][string]$Path,
        [Parameter(Mandatory = $true)][AllowEmptyCollection()][System.Collections.Generic.HashSet[string]]$Visited,
        [Parameter(Mandatory = $true)][AllowEmptyCollection()][System.Collections.Generic.List[string]]$Urls
    )

    $fullPath = [IO.Path]::GetFullPath($Path)
    if (-not $Visited.Add($fullPath.ToLowerInvariant())) {
        return
    }
    if (-not (Test-Path -LiteralPath $fullPath -PathType Leaf)) {
        Add-Gap -Code "sitemap-child-missing" -Path $fullPath
        return
    }

    $xml = New-Object System.Xml.XmlDocument
    try {
        $xml.Load($fullPath)
    }
    catch {
        Add-Gap -Code "sitemap-invalid-xml" -Path $fullPath -Message $_.Exception.Message
        return
    }

    $rootName = $xml.DocumentElement.LocalName
    if ($rootName -eq "sitemapindex") {
        foreach ($node in @($xml.SelectNodes("//*[local-name()='sitemap']/*[local-name()='loc']"))) {
            $childPath = Get-LocalSitemapPath -Location ([string]$node.InnerText.Trim())
            if ($null -eq $childPath) {
                Add-Gap -Code "sitemap-child-unavailable" -Path ([string]$node.InnerText.Trim())
                continue
            }
            Read-SitemapFile -Path $childPath -Visited $Visited -Urls $Urls
        }
        return
    }

    if ($rootName -ne "urlset") {
        Add-Gap -Code "sitemap-root-unsupported" -Path $fullPath -Message "Expected urlset or sitemapindex."
        return
    }

    foreach ($node in @($xml.SelectNodes("//*[local-name()='url']/*[local-name()='loc']"))) {
        $location = [string]$node.InnerText.Trim()
        if (-not [String]::IsNullOrWhiteSpace($location)) {
            $Urls.Add($location)
        }
    }
}

function Read-DocFxManifest {
    param([Parameter(Mandatory = $true)][string]$Path)

    if (-not (Test-Path -LiteralPath $Path -PathType Leaf)) {
        Add-Gap -Code "docfx-manifest-unavailable" -Path $Path
        return
    }

    $manifest = $null
    try {
        $manifest = Get-Content -LiteralPath $Path -Raw | ConvertFrom-Json
    }
    catch {
        Add-Gap -Code "docfx-manifest-invalid" -Path $Path -Message $_.Exception.Message
        return
    }

    foreach ($file in @($manifest.files)) {
        if ($null -eq $file.output) {
            continue
        }

        $htmlProperty = @($file.output.PSObject.Properties | Where-Object { $_.Name -eq ".html" }) | Select-Object -First 1
        if ($null -eq $htmlProperty -or $null -eq $htmlProperty.Value) {
            continue
        }

        $outputPath = Normalize-RepositoryPath ([string]$htmlProperty.Value.relative_path)
        if ([String]::IsNullOrWhiteSpace($outputPath)) {
            continue
        }

        $key = $outputPath.ToLowerInvariant()
        if ($script:DocFxOutputMap.ContainsKey($key)) {
            Add-Gap -Code "duplicate-docfx-output" -Path $outputPath
            continue
        }

        $script:DocFxOutputMap[$key] = [PSCustomObject][ordered]@{
            sourcePath = Normalize-RepositoryPath ([string]$file.source_relative_path)
            type = [string]$file.type
            outputPath = $outputPath
        }
    }
}

function Read-MetadataManifest {
    param([AllowEmptyString()][string]$Path)

    if ([String]::IsNullOrWhiteSpace($Path) -or -not (Test-Path -LiteralPath $Path -PathType Leaf)) {
        return
    }

    try {
        $manifest = Get-Content -LiteralPath $Path -Raw | ConvertFrom-Json
    }
    catch {
        Add-Gap -Code "metadata-manifest-invalid" -Path $Path -Message $_.Exception.Message
        return
    }

    foreach ($entry in @($manifest.entries | Where-Object { -not [bool]$_.tombstone })) {
        $sourcePath = Normalize-RepositoryPath ([string]$entry.sourcePath)
        if ([String]::IsNullOrWhiteSpace($sourcePath)) {
            continue
        }
        if (-not $script:MetadataBySourcePath.ContainsKey($sourcePath.ToLowerInvariant())) {
            $script:MetadataBySourcePath[$sourcePath.ToLowerInvariant()] = $entry
        }
    }
}

function Read-GeneratedProvenance {
    param([AllowEmptyString()][string]$Path)

    if ([String]::IsNullOrWhiteSpace($Path) -or -not (Test-Path -LiteralPath $Path -PathType Leaf)) {
        return
    }

    try {
        $provenance = Get-Content -LiteralPath $Path -Raw | ConvertFrom-Json
    }
    catch {
        Add-Gap -Code "generated-provenance-invalid" -Path $Path -Message $_.Exception.Message
        return
    }

    $artifactsById = @{}
    $projectsByIdentity = @{}
    foreach ($artifact in @($provenance.artifacts)) {
        $artifactId = [string]$artifact.id
        if (-not [String]::IsNullOrWhiteSpace($artifactId)) {
            $artifactsById[$artifactId] = $artifact
        }
        if ([string]$artifact.kind -eq "project" -and
            -not [String]::IsNullOrWhiteSpace([string]$artifact.identity) -and
            $null -ne $artifact.file -and
            @($artifact.file.PSObject.Properties.Name) -contains "path" -and
            -not [String]::IsNullOrWhiteSpace([string]$artifact.file.path)) {
            $projectsByIdentity[[string]$artifact.identity] = Normalize-RepositoryPath ([string]$artifact.file.path)
        }
    }

    foreach ($output in @($provenance.outputs.api)) {
        $candidateSourcePaths = New-Object "System.Collections.Generic.List[string]"
        foreach ($artifactId in @($output.artifactIds)) {
            $artifactKey = [string]$artifactId
            if (-not $artifactsById.ContainsKey($artifactKey)) {
                continue
            }
            $artifact = $artifactsById[$artifactKey]
            if ($null -eq $artifact.file -or
                @($artifact.file.PSObject.Properties.Name) -notcontains "path" -or
                [String]::IsNullOrWhiteSpace([string]$artifact.file.path)) {
                continue
            }
            if ([string]$artifact.kind -in @("source", "project")) {
                $candidateSourcePaths.Add((Normalize-RepositoryPath ([string]$artifact.file.path)))
            }
        }
        if ($candidateSourcePaths.Count -eq 0) {
            foreach ($assembly in @($output.generated.assemblies)) {
                $assemblyName = [string]$assembly
                if ($projectsByIdentity.ContainsKey($assemblyName)) {
                    $candidateSourcePaths.Add($projectsByIdentity[$assemblyName])
                }
            }
        }
        $sourcePath = @(
            $candidateSourcePaths |
                Where-Object { -not [String]::IsNullOrWhiteSpace($_) } |
                Sort-Object -Unique |
                Select-Object -First 1
        )
        if ($sourcePath.Count -gt 0) {
            $outputPath = Normalize-RepositoryPath ([string]$output.path)
            if (-not [String]::IsNullOrWhiteSpace($outputPath)) {
                $script:ProvenanceByOutputPath[$outputPath.ToLowerInvariant()] = [string]$sourcePath[0]
            }
        }
    }
}

function Get-FrontMatterValue {
    param(
        [AllowEmptyString()][string]$Text,
        [Parameter(Mandatory = $true)][string]$Name
    )

    $frontMatterMatch = [Regex]::Match($Text, "(?ms)\A---\s*\r?\n(?<front>.*?)\r?\n---(?:\s*\r?\n|$)")
    if (-not $frontMatterMatch.Success) {
        return ""
    }

    $pattern = "(?m)^\s*" + [Regex]::Escape($Name) + "\s*:\s*(?<value>[^#\r\n]*?)(?:\s+#.*)?$"
    $match = [Regex]::Match($frontMatterMatch.Groups["front"].Value, $pattern)
    if (-not $match.Success) {
        return ""
    }

    $value = $match.Groups["value"].Value.Trim()
    if ($value.Length -ge 2 -and
        (($value.StartsWith('"') -and $value.EndsWith('"')) -or
        ($value.StartsWith("'") -and $value.EndsWith("'")))) {
        return $value.Substring(1, $value.Length - 2)
    }

    return $value
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

function Get-DocumentationArea {
    param([AllowEmptyString()][string]$Path)

    $normalized = Normalize-RepositoryPath $Path
    $firstSegment = ($normalized -split "/")[0].ToLowerInvariant()
    if ([String]::IsNullOrWhiteSpace($firstSegment)) {
        return "unknown"
    }
    if ($firstSegment -in @("dataminer", "develop", "solutions", "tutorials", "connectors", "release-notes", "contributing")) {
        return $firstSegment
    }
    if ($firstSegment -eq $normalized.ToLowerInvariant()) {
        return "root"
    }

    return "unknown"
}

function Get-ContentType {
    param(
        [Parameter(Mandatory = $true)][AllowEmptyString()][string]$SourcePath,
        [AllowEmptyString()][string]$ManifestType = ""
    )

    if (-not [String]::IsNullOrWhiteSpace($ManifestType)) {
        $normalized = $ManifestType.Trim().ToLowerInvariant()
        switch ($normalized) {
            "conceptual" { return "conceptual" }
            "schema" { return "schema" }
            "api" { return "api" }
            "example" { return "example" }
            "release-note" { return "release-note" }
            "legacy" { return "legacy" }
        }
    }

    $sourceFile = Join-Path $script:Root $SourcePath.Replace("/", "\")
    if (Test-Path -LiteralPath $sourceFile -PathType Leaf) {
        $frontMatterType = Get-FrontMatterValue -Text (Get-Content -LiteralPath $sourceFile -Raw) -Name "content_type"
        if (-not [String]::IsNullOrWhiteSpace($frontMatterType)) {
            return $frontMatterType.Trim().ToLowerInvariant()
        }
    }

    $path = $SourcePath.ToLowerInvariant()
    if ($path.StartsWith("release-notes/")) {
        return "release-note"
    }
    if ($path.StartsWith("develop/schemadoc/")) {
        return "schema"
    }
    if ($path.StartsWith("develop/api/")) {
        return "api"
    }

    return "legacy"
}

function Get-SegmentToken {
    param([AllowEmptyString()][string]$Value)

    $token = $Value.Trim().ToLowerInvariant()
    $token = [Regex]::Replace($token, "[^a-z0-9]+", "-").Trim("-")
    if ([String]::IsNullOrWhiteSpace($token)) {
        return "unknown"
    }

    return $token
}

function Get-SegmentIdentity {
    param(
        [Parameter(Mandatory = $true)][AllowEmptyString()][string]$SourcePath,
        [AllowEmptyString()][string]$MetadataDomain = "",
        [AllowEmptyString()][string]$MetadataArea = "",
        [AllowEmptyString()][string]$MetadataType = "",
        [AllowEmptyString()][string]$DocFxType = ""
    )

    $domain = $MetadataDomain
    if ([String]::IsNullOrWhiteSpace($domain) -or $domain -in @("unknown", "not_applicable")) {
        $domain = Get-DocumentationDomain $SourcePath
    }
    $area = $MetadataArea
    if ([String]::IsNullOrWhiteSpace($area)) {
        $area = Get-DocumentationArea $SourcePath
    }
    $type = Get-ContentType -SourcePath $SourcePath -ManifestType $MetadataType
    if ([String]::IsNullOrWhiteSpace($MetadataType) -and
        [String]::IsNullOrWhiteSpace($type) -and
        -not [String]::IsNullOrWhiteSpace($DocFxType)) {
        $type = "legacy"
    }

    $scope = if ($domain -in @("Connector", "Automation")) { $domain } else { $area }
    $scopeToken = Get-SegmentToken $scope
    $typeToken = Get-SegmentToken $type
    return [PSCustomObject][ordered]@{
        scope = $scopeToken
        contentType = $typeToken
        name = "sitemap-$scopeToken-$typeToken.xml"
    }
}

function Get-SourceLastModified {
    param([Parameter(Mandatory = $true)][string]$SourcePath)

    $cacheKey = $SourcePath.ToLowerInvariant()
    if ($script:GitTimestampCache.ContainsKey($cacheKey)) {
        return $script:GitTimestampCache[$cacheKey]
    }

    $sourceFile = Join-Path $script:Root $SourcePath.Replace("/", "\")
    if (-not (Test-Path -LiteralPath $sourceFile -PathType Leaf)) {
        $result = [PSCustomObject][ordered]@{
            value = ""
            gapCode = "source-file-missing"
        }
        $script:GitTimestampCache[$cacheKey] = $result
        return $result
    }

    if ($script:TimestampCacheInitialized) {
        $result = [PSCustomObject][ordered]@{
            value = ""
            gapCode = "source-commit-timestamp-missing"
        }
        $script:GitTimestampCache[$cacheKey] = $result
        return $result
    }

    if ([String]::IsNullOrWhiteSpace($script:SourceRevision)) {
        $result = [PSCustomObject][ordered]@{
            value = ""
            gapCode = "source-revision-unavailable"
        }
        $script:GitTimestampCache[$cacheKey] = $result
        return $result
    }

    $dateText = Get-GitOutput -Arguments @(
        "log",
        "-1",
        "--format=%cI",
        "--follow",
        $script:SourceRevision,
        "--",
        $SourcePath
    )
    if ([String]::IsNullOrWhiteSpace($dateText)) {
        $result = [PSCustomObject][ordered]@{
            value = ""
            gapCode = "source-commit-timestamp-missing"
        }
        $script:GitTimestampCache[$cacheKey] = $result
        return $result
    }

    try {
        $date = [DateTimeOffset]::Parse(
            $dateText,
            [Globalization.CultureInfo]::InvariantCulture,
            [Globalization.DateTimeStyles]::RoundtripKind
        )
        $result = [PSCustomObject][ordered]@{
            value = $date.ToUniversalTime().ToString("yyyy-MM-dd'T'HH:mm:ss'Z'", [Globalization.CultureInfo]::InvariantCulture)
            gapCode = ""
        }
    }
    catch {
        $result = [PSCustomObject][ordered]@{
            value = ""
            gapCode = "source-commit-timestamp-invalid"
        }
    }

    $script:GitTimestampCache[$cacheKey] = $result
    return $result
}

function ConvertTo-LastModResult {
    param([AllowEmptyString()][string]$DateText)

    if ([String]::IsNullOrWhiteSpace($DateText)) {
        return [PSCustomObject][ordered]@{
            value = ""
            gapCode = "source-commit-timestamp-missing"
        }
    }

    try {
        $date = [DateTimeOffset]::Parse(
            $DateText,
            [Globalization.CultureInfo]::InvariantCulture,
            [Globalization.DateTimeStyles]::RoundtripKind
        )
        return [PSCustomObject][ordered]@{
            value = $date.ToUniversalTime().ToString("yyyy-MM-dd'T'HH:mm:ss'Z'", [Globalization.CultureInfo]::InvariantCulture)
            gapCode = ""
        }
    }
    catch {
        return [PSCustomObject][ordered]@{
            value = ""
            gapCode = "source-commit-timestamp-invalid"
        }
    }
}

function Initialize-GitTimestampCache {
    param(
        [Parameter(Mandatory = $true)][AllowNull()][AllowEmptyCollection()][string[]]$SourcePaths
    )

    $script:TimestampCacheInitialized = $true
    $paths = @(
        $SourcePaths |
            Where-Object { -not [String]::IsNullOrWhiteSpace($_) } |
            ForEach-Object { Normalize-RepositoryPath $_ } |
            Sort-Object -Unique
    )
    if ($paths.Count -eq 0) {
        return
    }

    $trackedByKey = @{}
    try {
        $trackedResult = & git -C $script:Root ls-files 2>$null
        if ($LASTEXITCODE -eq 0) {
            foreach ($trackedPath in @($trackedResult)) {
                $normalizedTrackedPath = Normalize-RepositoryPath ([string]$trackedPath)
                if (-not [String]::IsNullOrWhiteSpace($normalizedTrackedPath)) {
                    $trackedByKey[$normalizedTrackedPath.ToLowerInvariant()] = $normalizedTrackedPath
                }
            }
        }
    }
    catch {
        $trackedByKey = @{}
    }
    $paths = @(
        $paths |
            ForEach-Object {
                $pathKey = $_.ToLowerInvariant()
                if ($trackedByKey.ContainsKey($pathKey)) {
                    $trackedByKey[$pathKey]
                }
                else {
                    $_
                }
            } |
            Sort-Object -Unique
    )

    if ([String]::IsNullOrWhiteSpace($script:SourceRevision)) {
        foreach ($path in $paths) {
            $script:GitTimestampCache[$path.ToLowerInvariant()] = [PSCustomObject][ordered]@{
                value = ""
                gapCode = "source-revision-unavailable"
            }
        }
        return
    }

    $pathSet = @{}
    foreach ($path in $paths) {
        $pathSet[$path.ToLowerInvariant()] = $true
    }
    $resolved = @{}
    $batchSize = 100
    for ($start = 0; $start -lt $paths.Count; $start += $batchSize) {
        $end = [Math]::Min($start + $batchSize - 1, $paths.Count - 1)
        $batch = @($paths[$start..$end])
        $arguments = @(
            "-c",
            "core.quotePath=false",
            "log",
            "--format=commit:%H%x09%cI",
            "--name-only",
            $script:SourceRevision,
            "--"
        ) + $batch
        $output = ""
        try {
            $result = & git -C $script:Root @arguments 2>$null
            if ($LASTEXITCODE -eq 0) {
                $output = $result -join "`n"
            }
            else {
                Add-Gap -Code "git-timestamp-scan-failed" -Message "Git could not enumerate source commit dates."
            }
        }
        catch {
            Add-Gap -Code "git-timestamp-scan-failed" -Message $_.Exception.Message
        }

        $currentDate = ""
        foreach ($line in @($output -split "`r?`n")) {
            $commitMatch = [Regex]::Match($line, "^commit:[0-9a-fA-F]{40}`t(?<date>.+)$")
            if ($commitMatch.Success) {
                $currentDate = $commitMatch.Groups["date"].Value.Trim()
                continue
            }
            if ([String]::IsNullOrWhiteSpace($line) -or [String]::IsNullOrWhiteSpace($currentDate)) {
                continue
            }
            $path = Normalize-RepositoryPath $line.Trim()
            $cacheKey = $path.ToLowerInvariant()
            if ($pathSet.ContainsKey($cacheKey) -and -not $resolved.ContainsKey($cacheKey)) {
                $resolved[$cacheKey] = ConvertTo-LastModResult $currentDate
            }
        }
    }

    foreach ($path in $paths) {
        $cacheKey = $path.ToLowerInvariant()
        if ($resolved.ContainsKey($cacheKey)) {
            $script:GitTimestampCache[$cacheKey] = $resolved[$cacheKey]
        }
        else {
            $script:GitTimestampCache[$cacheKey] = [PSCustomObject][ordered]@{
                value = ""
                gapCode = "source-commit-timestamp-missing"
            }
        }
    }
}

function New-XmlText {
    param([Parameter(Mandatory = $true)][scriptblock]$WriteContent)

    $builder = New-Object Text.StringBuilder
    $settings = New-Object System.Xml.XmlWriterSettings
    $settings.Indent = $true
    $settings.IndentChars = "  "
    $settings.NewLineChars = "`n"
    $settings.NewLineHandling = [System.Xml.NewLineHandling]::None
    $settings.OmitXmlDeclaration = $false
    $settings.Encoding = New-Object Text.UTF8Encoding($false)
    $writer = [System.Xml.XmlWriter]::Create($builder, $settings)
    try {
        & $WriteContent $writer
    }
    finally {
        $writer.Flush()
        $writer.Dispose()
    }

    $text = $builder.ToString().Replace('encoding="utf-16"', 'encoding="utf-8"')
    return $text + "`n"
}

function Write-TextFile {
    param(
        [Parameter(Mandatory = $true)][string]$Path,
        [Parameter(Mandatory = $true)][string]$Text
    )

    $directory = Split-Path -Parent $Path
    if (-not (Test-Path -LiteralPath $directory -PathType Container)) {
        New-Item -ItemType Directory -Path $directory -Force | Out-Null
    }

    $temporaryPath = "$Path.$([Guid]::NewGuid().ToString('N')).tmp"
    $utf8NoBom = New-Object Text.UTF8Encoding($false)
    try {
        [IO.File]::WriteAllText($temporaryPath, $Text, $utf8NoBom)
        Move-Item -LiteralPath $temporaryPath -Destination $Path -Force
    }
    finally {
        if (Test-Path -LiteralPath $temporaryPath -PathType Leaf) {
            Remove-Item -LiteralPath $temporaryPath -Force
        }
    }
}

function Write-UrlSet {
    param(
        [Parameter(Mandatory = $true)][string]$Path,
        [Parameter(Mandatory = $true)][object[]]$Entries
    )

    $xml = New-XmlText {
        param($writer)
        $writer.WriteStartDocument()
        $writer.WriteStartElement("urlset", $script:SitemapNamespace)
        foreach ($entry in @($Entries | Sort-Object loc)) {
            $writer.WriteStartElement("url")
            $writer.WriteElementString("loc", [string]$entry.loc)
            if (-not [String]::IsNullOrWhiteSpace([string]$entry.lastmod)) {
                $writer.WriteElementString("lastmod", [string]$entry.lastmod)
            }
            $writer.WriteEndElement()
        }
        $writer.WriteEndElement()
        $writer.WriteEndDocument()
    }
    Write-TextFile -Path $Path -Text $xml
}

function Write-SitemapIndex {
    param(
        [Parameter(Mandatory = $true)][string]$Path,
        [Parameter(Mandatory = $true)][object[]]$Segments
    )

    $xml = New-XmlText {
        param($writer)
        $writer.WriteStartDocument()
        $writer.WriteStartElement("sitemapindex", $script:SitemapNamespace)
        foreach ($segment in @($Segments | Sort-Object name)) {
            $writer.WriteStartElement("sitemap")
            $writer.WriteElementString("loc", [string]$segment.url)
            $writer.WriteEndElement()
        }
        $writer.WriteEndElement()
        $writer.WriteEndDocument()
    }
    Write-TextFile -Path $Path -Text $xml
}

function Get-PreviousSegmentPaths {
    param([Parameter(Mandatory = $true)][string]$Path)

    $paths = New-Object "System.Collections.Generic.List[string]"
    if (-not (Test-Path -LiteralPath $Path -PathType Leaf)) {
        return @()
    }

    try {
        $xml = New-Object System.Xml.XmlDocument
        $xml.Load($Path)
        if ($xml.DocumentElement.LocalName -ne "sitemapindex") {
            return @()
        }
        foreach ($node in @($xml.SelectNodes("//*[local-name()='sitemap']/*[local-name()='loc']"))) {
            $childPath = Get-LocalSitemapPath -Location ([string]$node.InnerText.Trim())
            if ($null -ne $childPath -and
                ([IO.Path]::GetFileName($childPath) -match "^sitemap-[a-z0-9-]+\.xml$")) {
                $paths.Add($childPath)
            }
        }
    }
    catch {
        return @()
    }

    return @($paths | Sort-Object -Unique)
}

function Remove-StaleSegments {
    param(
        [Parameter(Mandatory = $true)][AllowNull()][AllowEmptyCollection()][string[]]$PreviousPaths,
        [Parameter(Mandatory = $true)][AllowNull()][AllowEmptyCollection()][string[]]$CurrentPaths
    )

    $currentSet = @{}
    foreach ($path in $CurrentPaths) {
        $currentSet[[IO.Path]::GetFullPath($path).ToLowerInvariant()] = $true
    }
    $pathsToRemove = New-Object "System.Collections.Generic.List[string]"
    foreach ($path in @($PreviousPaths)) {
        if (-not [String]::IsNullOrWhiteSpace($path)) {
            $pathsToRemove.Add($path)
        }
    }
    foreach ($file in @(Get-ChildItem -LiteralPath $script:OutputSite -File -Filter "sitemap-*.xml" -ErrorAction SilentlyContinue)) {
        $pathsToRemove.Add($file.FullName)
    }
    foreach ($path in @($pathsToRemove | Sort-Object -Unique)) {
        $key = [IO.Path]::GetFullPath($path).ToLowerInvariant()
        if (-not $currentSet.ContainsKey($key) -and
            (Test-Path -LiteralPath $path -PathType Leaf)) {
            Remove-Item -LiteralPath $path -Force
        }
    }
}

function Get-GapSummary {
    $summary = @()
    foreach ($group in @($script:GapRecords | Group-Object code | Sort-Object Name)) {
        $paths = @(
            $group.Group |
                Where-Object { -not [String]::IsNullOrWhiteSpace([string]$_.path) } |
                ForEach-Object { [string]$_.path } |
                Sort-Object -Unique
        )
        $messages = @(
            $group.Group |
                Where-Object { -not [String]::IsNullOrWhiteSpace([string]$_.message) } |
                ForEach-Object { [string]$_.message } |
                Sort-Object -Unique
        )
        $summary += [PSCustomObject][ordered]@{
            code = [string]$group.Name
            count = [int]$group.Count
            paths = $paths
            messages = $messages
        }
    }
    return @($summary)
}

function Write-Report {
    param(
        [Parameter(Mandatory = $true)][string]$Path,
        [Parameter(Mandatory = $true)]$Report
    )

    $json = $Report | ConvertTo-Json -Depth 20
    Write-TextFile -Path $Path -Text ($json + [Environment]::NewLine)
}

$script:Root = ConvertTo-FullPath -Path $RepositoryRoot
$script:OutputSite = ConvertTo-FullPath -Path $SitePath
Assert-Condition (Test-Path -LiteralPath $script:Root -PathType Container) "Repository root '$script:Root' does not exist."
Assert-Condition (Test-Path -LiteralPath $script:OutputSite -PathType Container) "Site path '$script:OutputSite' does not exist."
$script:PublicBaseUrl = Normalize-BaseUrl $BaseUrl

if ([String]::IsNullOrWhiteSpace($InputSitemapPath)) {
    $InputSitemapPath = Join-Path $script:OutputSite "sitemap.xml"
}
else {
    $InputSitemapPath = ConvertTo-FullPath $InputSitemapPath
}
if ([String]::IsNullOrWhiteSpace($DocFxManifestPath)) {
    $DocFxManifestPath = Join-Path $script:OutputSite "manifest.json"
}
else {
    $DocFxManifestPath = ConvertTo-FullPath $DocFxManifestPath
}
if ([String]::IsNullOrWhiteSpace($MetadataManifestPath)) {
    $defaultMetadataManifest = Join-Path $script:Root "_artifacts\ai-content-manifest.json"
    $publicMetadataManifest = Join-Path $script:OutputSite "ai-content-manifest.json"
    $MetadataManifestPath = if (Test-Path -LiteralPath $defaultMetadataManifest -PathType Leaf) {
        $defaultMetadataManifest
    }
    elseif (Test-Path -LiteralPath $publicMetadataManifest -PathType Leaf) {
        $publicMetadataManifest
    }
    else {
        ""
    }
}
else {
    $MetadataManifestPath = ConvertTo-FullPath $MetadataManifestPath
}
if ([String]::IsNullOrWhiteSpace($GeneratedProvenancePath)) {
    $defaultGeneratedProvenance = Join-Path $script:Root "_artifacts\generated-metadata-provenance.json"
    $GeneratedProvenancePath = if (Test-Path -LiteralPath $defaultGeneratedProvenance -PathType Leaf) {
        $defaultGeneratedProvenance
    }
    else {
        ""
    }
}
else {
    $GeneratedProvenancePath = ConvertTo-FullPath $GeneratedProvenancePath
}
if (-not [IO.Path]::IsPathRooted($OutputPath)) {
    $OutputPath = Join-Path $script:Root $OutputPath
}
$OutputPath = [IO.Path]::GetFullPath($OutputPath)

$script:SourceRevision = Resolve-SourceRevision $SourceRevision
Read-DocFxManifest -Path $DocFxManifestPath
Read-MetadataManifest -Path $MetadataManifestPath
Read-GeneratedProvenance -Path $GeneratedProvenancePath

$previousSegmentPaths = Get-PreviousSegmentPaths -Path $InputSitemapPath
$inputUrls = New-Object "System.Collections.Generic.List[string]"
$visitedSitemaps = New-Object "System.Collections.Generic.HashSet[string]"
if (Test-Path -LiteralPath $InputSitemapPath -PathType Leaf) {
    Read-SitemapFile -Path $InputSitemapPath -Visited $visitedSitemaps -Urls $inputUrls
}
else {
    Add-Gap -Code "sitemap-input-unavailable" -Path $InputSitemapPath
    foreach ($mapping in @($script:DocFxOutputMap.Values | Sort-Object outputPath)) {
        $inputUrls.Add((ConvertTo-PublicUrl $mapping.outputPath))
    }
}

$uniqueUrls = New-Object "System.Collections.Generic.List[string]"
$seenUrls = @{}
foreach ($url in @($inputUrls | Sort-Object)) {
    if ($seenUrls.ContainsKey($url)) {
        Add-Gap -Code "duplicate-sitemap-url" -Path $url
        continue
    }
    $seenUrls[$url] = $true
    $uniqueUrls.Add($url)
}
if ($uniqueUrls.Count -eq 0) {
    throw "No sitemap URLs were found in '$InputSitemapPath' or the DocFX manifest."
}

$timestampPaths = New-Object "System.Collections.Generic.List[string]"
foreach ($mapping in @($script:DocFxOutputMap.Values)) {
    $sourcePath = Normalize-RepositoryPath ([string]$mapping.sourcePath)
    if (-not [String]::IsNullOrWhiteSpace($sourcePath)) {
        $timestampPath = if ($script:ProvenanceByOutputPath.ContainsKey($sourcePath.ToLowerInvariant())) {
            [string]$script:ProvenanceByOutputPath[$sourcePath.ToLowerInvariant()]
        }
        else {
            $sourcePath
        }
        $timestampPaths.Add($timestampPath)
    }
}
foreach ($url in $uniqueUrls) {
    $candidate = Get-UrlPathKey $url
    if ($candidate -match "\.html$") {
        $candidate = $candidate.Substring(0, $candidate.Length - 5) + ".md"
        if (Test-Path -LiteralPath (Join-Path $script:Root $candidate.Replace("/", "\")) -PathType Leaf) {
            $timestampPaths.Add((Normalize-RepositoryPath $candidate))
        }
    }
}
Initialize-GitTimestampCache -SourcePaths $timestampPaths.ToArray()

$records = New-Object "System.Collections.Generic.List[object]"
foreach ($url in $uniqueUrls) {
    $pathKey = (Get-UrlPathKey $url).ToLowerInvariant()
    $mapping = if ($script:DocFxOutputMap.ContainsKey($pathKey)) { $script:DocFxOutputMap[$pathKey] } else { $null }
    $sourcePath = if ($null -ne $mapping) { [string]$mapping.sourcePath } else { "" }
    if ([String]::IsNullOrWhiteSpace($sourcePath)) {
        $candidate = Get-UrlPathKey $url
        if ($candidate -match "\.html$") {
            $candidate = $candidate.Substring(0, $candidate.Length - 5) + ".md"
            if (Test-Path -LiteralPath (Join-Path $script:Root $candidate.Replace("/", "\")) -PathType Leaf) {
                $sourcePath = Normalize-RepositoryPath $candidate
            }
        }
    }
    if ([String]::IsNullOrWhiteSpace($sourcePath)) {
        Add-Gap -Code "source-mapping-missing" -Path $url
    }

    $metadata = if (-not [String]::IsNullOrWhiteSpace($sourcePath) -and
        $script:MetadataBySourcePath.ContainsKey($sourcePath.ToLowerInvariant())) {
        $script:MetadataBySourcePath[$sourcePath.ToLowerInvariant()]
    }
    else {
        $null
    }
    $metadataDomain = if ($null -ne $metadata) { [string]$metadata.domain } else { "" }
    $metadataArea = if ($null -ne $metadata) { [string]$metadata.area } else { "" }
    $metadataType = if ($null -ne $metadata) { [string]$metadata.type } else { "" }
    $docFxType = if ($null -ne $mapping) { [string]$mapping.type } else { "" }
    $segment = Get-SegmentIdentity `
        -SourcePath $sourcePath `
        -MetadataDomain $metadataDomain `
        -MetadataArea $metadataArea `
        -MetadataType $metadataType `
        -DocFxType $docFxType

    $timestampSourcePath = if (-not [String]::IsNullOrWhiteSpace($sourcePath) -and
        $script:ProvenanceByOutputPath.ContainsKey($sourcePath.ToLowerInvariant())) {
        [string]$script:ProvenanceByOutputPath[$sourcePath.ToLowerInvariant()]
    }
    else {
        $sourcePath
    }
    $lastModified = if (-not [String]::IsNullOrWhiteSpace($timestampSourcePath)) {
        Get-SourceLastModified -SourcePath $timestampSourcePath
    }
    else {
        [PSCustomObject][ordered]@{
            value = ""
            gapCode = ""
        }
    }
    if (-not [String]::IsNullOrWhiteSpace([string]$lastModified.gapCode)) {
        Add-Gap -Code ([string]$lastModified.gapCode) -Path $timestampSourcePath
    }

    $records.Add([PSCustomObject][ordered]@{
            loc = $url
            sourcePath = $sourcePath
            segmentName = $segment.name
            scope = $segment.scope
            contentType = $segment.contentType
            lastmod = [string]$lastModified.value
        })
}

$segments = New-Object "System.Collections.Generic.List[object]"
$segmentGroups = @($records | Group-Object segmentName | Sort-Object Name)
foreach ($group in $segmentGroups) {
    $segmentName = [string]$group.Name
    $segmentPath = Join-Path $script:OutputSite $segmentName
    $segmentEntries = @($group.Group | Sort-Object loc)
    Write-UrlSet -Path $segmentPath -Entries $segmentEntries
    $first = $segmentEntries[0]
    $segments.Add([PSCustomObject][ordered]@{
            name = $segmentName
            url = $script:PublicBaseUrl + $segmentName
            scope = [string]$first.scope
            contentType = [string]$first.contentType
            urlCount = $segmentEntries.Count
            lastmodCount = @($segmentEntries | Where-Object { -not [String]::IsNullOrWhiteSpace([string]$_.lastmod) }).Count
        })
}

$currentSegmentPaths = @($segments | ForEach-Object { Join-Path $script:OutputSite ([string]$_.name) })
Remove-StaleSegments -PreviousPaths $previousSegmentPaths -CurrentPaths $currentSegmentPaths
Write-SitemapIndex -Path (Join-Path $script:OutputSite "sitemap.xml") -Segments $segments.ToArray()

$gapSummary = @(Get-GapSummary)
$report = [ordered]@{
    schemaVersion = 1
    format = "json"
    generator = [ordered]@{
        name = "scripts/generate-segmented-sitemaps.ps1"
        version = $script:GeneratorVersion
    }
    source = [ordered]@{
        repository = $script:Repository
        revision = if ([String]::IsNullOrWhiteSpace($script:SourceRevision)) { "unknown" } else { $script:SourceRevision }
        revisionSource = $script:SourceRevisionSource
        baseUrl = $script:PublicBaseUrl
        timestampSource = "git-commit-committer-date"
    }
    input = [ordered]@{
        sitemap = "sitemap.xml"
        docfxManifest = if (Test-Path -LiteralPath $DocFxManifestPath -PathType Leaf) { "manifest.json" } else { $null }
        metadataManifest = if (-not [String]::IsNullOrWhiteSpace($MetadataManifestPath) -and (Test-Path -LiteralPath $MetadataManifestPath -PathType Leaf)) { "ai-content-manifest.json" } else { $null }
        generatedProvenance = if (-not [String]::IsNullOrWhiteSpace($GeneratedProvenancePath) -and (Test-Path -LiteralPath $GeneratedProvenancePath -PathType Leaf)) { "generated-metadata-provenance.json" } else { $null }
    }
    output = [ordered]@{
        index = "sitemap.xml"
        segments = @($segments | Sort-Object name)
    }
    counts = [ordered]@{
        urls = $records.Count
        segments = $segments.Count
        withLastmod = @($records | Where-Object { -not [String]::IsNullOrWhiteSpace([string]$_.lastmod) }).Count
        withoutLastmod = @($records | Where-Object { [String]::IsNullOrWhiteSpace([string]$_.lastmod) }).Count
    }
    gaps = $gapSummary
}
Write-Report -Path $OutputPath -Report $report

Write-Output "Wrote segmented sitemap index: $(Join-Path $script:OutputSite 'sitemap.xml')."
Write-Output "Sitemap URLs: $($records.Count); segments: $($segments.Count); lastmod: $($report.counts.withLastmod); gaps: $(@($gapSummary).Count)."
foreach ($gap in $gapSummary) {
    Write-Output "Gap $($gap.code): $($gap.count)."
}
