[CmdletBinding()]
param(
    [string]$RepositoryRoot = (Join-Path $PSScriptRoot ".."),
    [string]$Path = (Join-Path $PSScriptRoot "..\_artifacts\internal-only-topic-packs\internal-only-topic-pack-manifest.json"),
    [string]$SchemaPath = (Join-Path $PSScriptRoot "..\contributing\metadata\internal-topic-pack-v1.schema.json")
)

Set-StrictMode -Version 2.0
$ErrorActionPreference = "Stop"

$script:RepositoryRootValue = $null
$script:LicenseIdentifier = "CC BY-NC-ND 4.0"
$script:Attribution = "Skyline Communications"
$script:PolicyId = "D0.3"
$script:PolicySource = "contributing/CTB_Documentation_Corpus_Policy.md"
$script:Repository = "SkylineCommunications/dataminer-docs"

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
    param([Parameter(Mandatory = $true)][string]$Value)

    if ([IO.Path]::IsPathRooted($Value)) {
        return [IO.Path]::GetFullPath($Value)
    }

    return [IO.Path]::GetFullPath((Join-Path (Get-Location).Path $Value))
}

function ConvertTo-PortablePath {
    param([Parameter(Mandatory = $true)][string]$Value)

    return $Value.Replace("\", "/")
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

    $bytes = [Text.Encoding]::UTF8.GetBytes((Normalize-Text $Text))
    $hash = [Security.Cryptography.SHA256]::Create()
    try {
        return ([BitConverter]::ToString($hash.ComputeHash($bytes))).Replace("-", "").ToLowerInvariant()
    }
    finally {
        $hash.Dispose()
    }
}

function Get-FileSha256 {
    param([Parameter(Mandatory = $true)][string]$FilePath)

    return (Get-FileHash -LiteralPath $FilePath -Algorithm SHA256).Hash.ToLowerInvariant()
}

function Assert-Properties {
    param(
        [Parameter(Mandatory = $true)]$Object,
        [Parameter(Mandatory = $true)][string[]]$Required,
        [Parameter(Mandatory = $true)][string[]]$Allowed,
        [Parameter(Mandatory = $true)][string]$Context
    )

    Assert-Condition ($null -ne $Object) "$Context is missing."
    $properties = @($Object.PSObject.Properties.Name)
    foreach ($name in $Required) {
        Assert-Condition ($properties -contains $name) "$Context is missing '$name'."
    }
    foreach ($name in $properties) {
        Assert-Condition ($Allowed -contains $name) "$Context contains undocumented property '$name'."
    }
}

function ConvertFrom-YamlScalar {
    param([AllowEmptyString()][string]$Value)

    if ($null -eq $Value) {
        return ""
    }
    $trimmed = $Value.Trim()
    if ($trimmed.StartsWith('"') -and $trimmed.EndsWith('"')) {
        try {
            return ($trimmed | ConvertFrom-Json)
        }
        catch {
            throw "Generated topic pack metadata contains an invalid quoted scalar '$trimmed'."
        }
    }
    return $trimmed
}

function Get-GeneratedFrontMatter {
    param([Parameter(Mandatory = $true)][string]$Text)

    $normalized = Normalize-Text $Text
    $match = [Regex]::Match(
        $normalized,
        "\A---\n(?<front>.*?)\n---(?:\n|\z)",
        [Text.RegularExpressions.RegexOptions]::Singleline
    )
    Assert-Condition $match.Success "A generated topic pack chunk is missing its front matter."
    $values = @{}
    foreach ($line in ($match.Groups["front"].Value -split "`n")) {
        if ([String]::IsNullOrWhiteSpace($line)) {
            continue
        }
        $lineMatch = [Regex]::Match($line, "^(?<name>[a-z][a-z0-9_]*)\s*:\s*(?<value>.*)$")
        Assert-Condition $lineMatch.Success "Generated topic pack front matter contains an invalid line '$line'."
        $name = $lineMatch.Groups["name"].Value
        Assert-Condition (-not $values.ContainsKey($name)) "Generated topic pack front matter repeats '$name'."
        $values[$name] = ConvertFrom-YamlScalar $lineMatch.Groups["value"].Value
    }

    $body = $normalized.Substring($match.Length)
    if ($body.StartsWith("`n")) {
        $body = $body.Substring(1)
    }
    return [PSCustomObject]@{
        Values = $values
        Body = $body
    }
}

function Get-SourceSectionText {
    param(
        [Parameter(Mandatory = $true)][string]$SourcePath,
        [Parameter(Mandatory = $true)][int]$StartLine,
        [Parameter(Mandatory = $true)][int]$EndLine
    )

    $normalized = Normalize-Text (Get-Content -LiteralPath $SourcePath -Raw)
    $lines = @($normalized -split "`n")
    Assert-Condition ($StartLine -ge 1 -and $EndLine -ge $StartLine -and $EndLine -le $lines.Count) "Chunk source line range $StartLine-$EndLine is outside '$SourcePath'."
    return (@($lines | Select-Object -Skip ($StartLine - 1) -First ($EndLine - $StartLine + 1)) -join "`n")
}

function Assert-SafeRelativePath {
    param(
        [Parameter(Mandatory = $true)][string]$Value,
        [Parameter(Mandatory = $true)][string]$Context
    )

    Assert-Condition (-not [IO.Path]::IsPathRooted($Value)) "$Context is an absolute path."
    Assert-Condition ($Value -notmatch "\\") "$Context contains a Windows path separator."
    Assert-Condition ($Value -notmatch "(^|/)\.\.(?:/|$)") "$Context escapes its output directory."
    Assert-Condition ($Value -notmatch "^/") "$Context starts at the filesystem root."
}

function Assert-Hash {
    param(
        [Parameter(Mandatory = $true)][string]$Value,
        [Parameter(Mandatory = $true)][string]$Context
    )

    Assert-Condition ($Value -match "^[0-9a-f]{64}$") "$Context is not a lowercase SHA-256 value."
}

function Assert-FrontMatter {
    param(
        [Parameter(Mandatory = $true)]$FrontMatter,
        [Parameter(Mandatory = $true)]$Chunk,
        [Parameter(Mandatory = $true)][string]$SourceManifestPath
    )

    $values = $FrontMatter.Values
    $required = @(
        "topic_pack_schema_version", "visibility", "policy", "policy_source", "source_manifest",
        "domain", "source_uid", "source_url", "source_path", "source_commit", "source_blob",
        "source_content_hash", "source_section_hash", "source_section_identity", "source_section_title",
        "chunk_id", "content_identity", "chunk_index", "chunk_count", "chunk_content_hash", "content_type", "authority",
        "lifecycle", "license", "attribution", "resolved_link_count", "unresolved_link_count"
    )
    foreach ($name in $required) {
        Assert-Condition $values.ContainsKey($name) "Chunk '$($Chunk.id)' is missing front matter '$name'."
    }
    Assert-Condition ($values.Keys.Count -eq $required.Count) "Chunk '$($Chunk.id)' contains undocumented front matter fields."
    Assert-Condition ([int]$values["topic_pack_schema_version"] -eq 1) "Chunk '$($Chunk.id)' has an unsupported topic pack schema version."
    Assert-Condition ([string]$values["visibility"] -eq "internal-only") "Chunk '$($Chunk.id)' is not marked internal-only."
    Assert-Condition ([string]$values["policy"] -eq $script:PolicyId -and [string]$values["policy_source"] -eq $script:PolicySource) "Chunk '$($Chunk.id)' is missing the D0.3 policy boundary."
    Assert-Condition ([string]$values["source_manifest"] -eq $SourceManifestPath) "Chunk '$($Chunk.id)' points to an unexpected source manifest."

    $comparisons = @{
        domain = "domain"
        source_uid = "sourceUid"
        source_url = "sourceUrl"
        source_path = "sourcePath"
        source_commit = "sourceCommit"
        source_blob = "sourceBlob"
        source_content_hash = "contentHash"
        source_section_hash = "sourceSectionHash"
        source_section_identity = "sourceSectionIdentity"
        source_section_title = "sourceSectionTitle"
        chunk_id = "id"
        content_identity = "contentIdentity"
        content_type = "contentType"
        authority = "authority"
        lifecycle = "lifecycle"
        license = "license"
        attribution = "attribution"
    }
    foreach ($frontName in $comparisons.Keys) {
        $recordName = $comparisons[$frontName]
        $expected = [string]$Chunk.$recordName
        Assert-Condition ([string]$values[$frontName] -eq $expected) "Chunk '$($Chunk.id)' front matter '$frontName' does not match its manifest record."
    }
    Assert-Condition ([int]$values["chunk_index"] -eq [int]$Chunk.chunkIndex) "Chunk '$($Chunk.id)' has an incorrect section index."
    Assert-Condition ([int]$values["chunk_count"] -eq [int]$Chunk.chunkCount) "Chunk '$($Chunk.id)' has an incorrect section count."
    Assert-Condition ([int]$values["resolved_link_count"] -eq @($Chunk.links.resolved).Count) "Chunk '$($Chunk.id)' has an incorrect resolved-link count."
    Assert-Condition ([int]$values["unresolved_link_count"] -eq @($Chunk.links.unresolved).Count) "Chunk '$($Chunk.id)' has an incorrect unresolved-link count."
    Assert-Hash -Value ([string]$values["source_content_hash"]) -Context "Chunk '$($Chunk.id)' source content hash"
    Assert-Hash -Value ([string]$values["source_section_hash"]) -Context "Chunk '$($Chunk.id)' source section hash"
    Assert-Hash -Value ([string]$values["content_identity"]) -Context "Chunk '$($Chunk.id)' content identity"
    Assert-Hash -Value ([string]$values["chunk_content_hash"]) -Context "Chunk '$($Chunk.id)' chunk content hash"
}

$root = ConvertTo-FullPath $RepositoryRoot
$script:RepositoryRootValue = $root
$manifestPath = ConvertTo-FullPath $Path
$schemaPath = ConvertTo-FullPath $SchemaPath
Assert-Condition (Test-Path -LiteralPath $root -PathType Container) "Repository root '$root' does not exist."
Assert-Condition (Test-Path -LiteralPath $manifestPath -PathType Leaf) "Internal topic pack manifest '$manifestPath' does not exist."
Assert-Condition (Test-Path -LiteralPath $schemaPath -PathType Leaf) "Internal topic pack schema '$schemaPath' does not exist."

try {
    $schema = Get-Content -LiteralPath $schemaPath -Raw | ConvertFrom-Json
    $manifestJson = Get-Content -LiteralPath $manifestPath -Raw
    $manifest = $manifestJson | ConvertFrom-Json
}
catch {
    throw "The internal topic pack manifest or schema is not valid JSON: $($_.Exception.Message)"
}
Assert-Condition ([string]$schema.title -eq "DataMiner internal-only Markdown topic pack manifest") "Unexpected internal topic pack schema."
if ($null -ne (Get-Command Test-Json -ErrorAction SilentlyContinue)) {
    try {
        if (-not (Test-Json -Json $manifestJson -SchemaFile $schemaPath)) {
            throw "The internal topic pack manifest does not conform to its JSON Schema."
        }
    }
    catch {
        throw "Internal topic pack JSON Schema validation failed: $($_.Exception.Message)"
    }
}

Assert-Properties -Object $manifest `
    -Required @("schemaVersion", "format", "visibility", "distribution", "generator", "schema", "source", "scope", "generation", "license", "notice", "counts", "packs", "chunks", "unresolvedLinks") `
    -Allowed @("schemaVersion", "format", "visibility", "distribution", "generator", "schema", "source", "scope", "generation", "license", "notice", "counts", "packs", "chunks", "unresolvedLinks") `
    -Context "topic pack manifest"
Assert-Condition ([int]$manifest.schemaVersion -eq 1) "Unsupported internal topic pack schema version."
Assert-Condition ([string]$manifest.format -eq "markdown-topic-packs") "The topic pack format is not Markdown."
Assert-Condition ([string]$manifest.visibility -eq "internal-only") "The topic pack manifest is not internal-only."

Assert-Properties -Object $manifest.distribution `
    -Required @("use", "publicRedistributionAllowed", "modelTrainingAllowed", "fineTuningAllowed", "retentionDays", "policy") `
    -Allowed @("use", "publicRedistributionAllowed", "modelTrainingAllowed", "fineTuningAllowed", "retentionDays", "policy") `
    -Context "topic pack manifest.distribution"
Assert-Condition ([string]$manifest.distribution.use -eq "normalized-transformed-content-internal-only") "The transformed-content use boundary is missing."
Assert-Condition (-not [bool]$manifest.distribution.publicRedistributionAllowed -and
    -not [bool]$manifest.distribution.modelTrainingAllowed -and
    -not [bool]$manifest.distribution.fineTuningAllowed) "The topic pack distribution flags authorize a prohibited use."
Assert-Condition ([int]$manifest.distribution.retentionDays -eq 14) "Internal topic packs must use 14-day operational retention."
Assert-Properties -Object $manifest.distribution.policy -Required @("id", "source") -Allowed @("id", "source") -Context "topic pack manifest.distribution.policy"
Assert-Condition ([string]$manifest.distribution.policy.id -eq $script:PolicyId -and [string]$manifest.distribution.policy.source -eq $script:PolicySource) "The topic pack manifest does not identify policy D0.3."

Assert-Properties -Object $manifest.generator -Required @("name", "version") -Allowed @("name", "version") -Context "topic pack manifest.generator"
Assert-Condition ([string]$manifest.generator.name -eq "scripts/generate-internal-topic-packs.ps1") "Unexpected internal topic pack generator."
Assert-Condition (-not [String]::IsNullOrWhiteSpace([string]$manifest.generator.version)) "Internal topic pack generator version is empty."
Assert-Properties -Object $manifest.schema -Required @("name", "version") -Allowed @("name", "version") -Context "topic pack manifest.schema"
Assert-Condition ([string]$manifest.schema.name -eq "contributing/metadata/internal-topic-pack-v1.schema.json" -and [int]$manifest.schema.version -eq 1) "Unexpected internal topic pack schema identity."

Assert-Properties -Object $manifest.source -Required @("repository", "revision", "revisionSource", "manifest") -Allowed @("repository", "revision", "revisionSource", "manifest") -Context "topic pack manifest.source"
Assert-Condition ([string]$manifest.source.repository -eq $script:Repository) "Unexpected topic pack source repository."
Assert-Condition ([string]$manifest.source.revisionSource -eq "manifest" -and [string]$manifest.source.revision -match "^[0-9a-f]{40}$") "Topic pack source revision is not an immutable manifest commit."
Assert-Properties -Object $manifest.source.manifest -Required @("path", "sha256", "schema") -Allowed @("path", "sha256", "schema") -Context "topic pack manifest.source.manifest"
Assert-SafeRelativePath -Value ([string]$manifest.source.manifest.path) -Context "topic pack source manifest path"
Assert-Hash -Value ([string]$manifest.source.manifest.sha256) -Context "topic pack source manifest hash"
Assert-Properties -Object $manifest.source.manifest.schema -Required @("name", "version") -Allowed @("name", "version") -Context "topic pack source manifest schema"
Assert-Condition ([string]$manifest.source.manifest.schema.name -eq "contributing/metadata/ai-content-manifest-v1.schema.json" -and [int]$manifest.source.manifest.schema.version -eq 1) "Topic pack source manifest schema is not D3.1."
$sourceManifestPath = Join-Path $root ([string]$manifest.source.manifest.path).Replace("/", "\")
Assert-Condition (Test-Path -LiteralPath $sourceManifestPath -PathType Leaf) "The recorded D3.1 source manifest '$($manifest.source.manifest.path)' does not exist."
Assert-Condition ((Get-FileSha256 $sourceManifestPath) -eq [string]$manifest.source.manifest.sha256) "The recorded D3.1 manifest hash does not match the source manifest."

Assert-Properties -Object $manifest.scope -Required @("domains", "sourcePaths") -Allowed @("domains", "sourcePaths") -Context "topic pack manifest.scope"
Assert-Condition ((@($manifest.scope.domains) -join ",") -eq "Automation,Connector") "Topic pack domains are not the required Automation and Connector order."
Assert-Condition (@($manifest.scope.sourcePaths | Sort-Object -Unique).Count -eq @($manifest.scope.sourcePaths).Count) "Topic pack source paths contain duplicates."
Assert-Condition ((@($manifest.scope.sourcePaths | Sort-Object) -join "`n") -eq (@($manifest.scope.sourcePaths) -join "`n")) "Topic pack source paths are not sorted."

Assert-Properties -Object $manifest.generation `
    -Required @("generatedAt", "generatedAtSource", "deterministic", "contentIdentityAlgorithm", "contentIdentityFields", "contentIdentityExcludes") `
    -Allowed @("generatedAt", "generatedAtSource", "deterministic", "contentIdentityAlgorithm", "contentIdentityFields", "contentIdentityExcludes") `
    -Context "topic pack manifest.generation"
Assert-Condition ([string]$manifest.generation.generatedAt -eq "unknown" -or [string]$manifest.generation.generatedAt -match "^\d{4}-\d{2}-\d{2}$") "Topic pack generation date is invalid."
Assert-Condition ([string]$manifest.generation.generatedAtSource -in @("argument", "source_date_epoch", "git_commit", "unknown")) "Topic pack generation date source is invalid."
Assert-Condition ([bool]$manifest.generation.deterministic -and [string]$manifest.generation.contentIdentityAlgorithm -eq "sha256") "Topic pack determinism metadata is missing."
Assert-Condition ((@($manifest.generation.contentIdentityFields) -join ",") -eq "sourceCommit,sourcePath,sourceUid,sourceContentHash,sourceSectionIdentity") "Topic pack content identity fields are incorrect."
Assert-Condition ((@($manifest.generation.contentIdentityExcludes) -join ",") -eq "generatedAt") "Topic pack content identity must exclude generation time."

Assert-Properties -Object $manifest.license `
    -Required @("identifier", "name", "url", "attribution", "source") `
    -Allowed @("identifier", "name", "url", "attribution", "source") `
    -Context "topic pack manifest.license"
Assert-Condition ([string]$manifest.license.identifier -eq $script:LicenseIdentifier -and
    [string]$manifest.license.attribution -eq $script:Attribution -and
    [string]$manifest.license.source -eq $script:PolicySource) "Topic pack license or attribution metadata is incorrect."

Assert-Properties -Object $manifest.notice -Required @("path", "sha256") -Allowed @("path", "sha256") -Context "topic pack manifest.notice"
Assert-SafeRelativePath -Value ([string]$manifest.notice.path) -Context "topic pack notice path"
Assert-Hash -Value ([string]$manifest.notice.sha256) -Context "topic pack notice hash"
$noticeFullPath = Join-Path (Split-Path -Parent $manifestPath) ([string]$manifest.notice.path).Replace("/", "\")
Assert-Condition (Test-Path -LiteralPath $noticeFullPath -PathType Leaf) "Topic pack notice '$($manifest.notice.path)' does not exist."
Assert-Condition ((Get-FileSha256 $noticeFullPath) -eq [string]$manifest.notice.sha256) "Topic pack notice hash does not match."
$notice = Get-Content -LiteralPath $noticeFullPath -Raw
Assert-Condition ($notice -match "(?im)^INTERNAL-ONLY TRANSFORMED DOCUMENTATION") "Topic pack notice does not state the internal-only boundary."
Assert-Condition ($notice -match "(?im)Public redistribution is not authorized") "Topic pack notice does not prohibit public redistribution."
Assert-Condition ($notice -match "(?im)Model training and fine-tuning are not authorized") "Topic pack notice does not prohibit model training."

$chunks = @($manifest.chunks)
$expectedChunks = @($chunks | Sort-Object domain, sourceUid, sourcePath, chunkIndex)
for ($index = 0; $index -lt $chunks.Count; $index++) {
    Assert-Condition ([string]$chunks[$index].id -eq [string]$expectedChunks[$index].id) "Topic pack chunks are not sorted deterministically."
}
$chunkById = @{}
$chunkByPath = @{}
$sectionKeys = @{}
$resolvedCount = 0
$unresolvedById = @{}
$sourcePages = @{}
foreach ($chunk in $chunks) {
    $context = "topic pack chunk '$($chunk.id)'"
    Assert-Condition (-not $chunkById.ContainsKey([string]$chunk.id)) "$context is duplicated."
    $chunkById[[string]$chunk.id] = $chunk
    Assert-Condition (-not $chunkByPath.ContainsKey([string]$chunk.path)) "$context output path is duplicated."
    $chunkByPath[[string]$chunk.path] = $chunk
    Assert-SafeRelativePath -Value ([string]$chunk.path) -Context "$context path"
    Assert-Condition ([string]$chunk.path -match "^(?:automation|connector)/internal-only-[A-Za-z0-9._-]+\.md$") "$context has an unsafe or non-internal filename."
    Assert-Condition ([string]$chunk.sourcePath -match "^(?!/)(?!.*\.\.(?:/|$)).+\.md$") "$context has an unsafe source path."
    Assert-Condition ([string]$chunk.domain -in @("Automation", "Connector")) "$context has an invalid domain."
    Assert-Condition ([string]$chunk.sourceCommit -eq [string]$manifest.source.revision) "$context source commit differs from the D3.1 manifest commit."
    Assert-Condition ([string]$chunk.sourceBlob -eq "https://github.com/SkylineCommunications/dataminer-docs/blob/$($manifest.source.revision)/$($chunk.sourcePath)") "$context source blob is not commit-addressed."
    Assert-Hash -Value ([string]$chunk.contentHash) -Context "$context source content hash"
    Assert-Hash -Value ([string]$chunk.sourceSectionHash) -Context "$context source section hash"
    Assert-Hash -Value ([string]$chunk.contentIdentity) -Context "$context content identity"
    Assert-Hash -Value ([string]$chunk.chunkContentHash) -Context "$context transformed chunk hash"
    Assert-Hash -Value ([string]$chunk.fileSha256) -Context "$context file hash"
    $identityInput = @(
        "internal-topic-pack-v1",
        [string]$chunk.domain,
        [string]$chunk.sourceUid,
        [string]$chunk.sourcePath,
        [string]$chunk.sourceCommit,
        [string]$chunk.contentHash,
        [string]$chunk.sourceSectionIdentity
    ) -join "`n"
    Assert-Condition ((Get-TextSha256 $identityInput) -eq [string]$chunk.contentIdentity) "$context content identity does not match its immutable source fields."
    Assert-Condition ([string]$chunk.license -eq $script:LicenseIdentifier -and [string]$chunk.attribution -eq $script:Attribution) "$context is missing license or attribution."
    Assert-Condition ([int]$chunk.chunkIndex -ge 0 -and [int]$chunk.chunkIndex -lt [int]$chunk.chunkCount) "$context has an invalid section index."
    $sectionKey = "$($chunk.sourcePath)|$($chunk.sourceUid)|$($chunk.sourceSectionIdentity)"
    Assert-Condition (-not $sectionKeys.ContainsKey($sectionKey)) "$context has a duplicate source section identity."
    $sectionKeys[$sectionKey] = $true
    $sourcePages[[string]$chunk.sourcePath] = $true

    $chunkFilePath = Join-Path (Split-Path -Parent $manifestPath) ([string]$chunk.path).Replace("/", "\")
    Assert-Condition (Test-Path -LiteralPath $chunkFilePath -PathType Leaf) "$context output file does not exist."
    Assert-Condition ((Get-FileSha256 $chunkFilePath) -eq [string]$chunk.fileSha256) "$context file hash does not match."
    $frontMatter = Get-GeneratedFrontMatter -Text (Get-Content -LiteralPath $chunkFilePath -Raw)
    Assert-FrontMatter -FrontMatter $frontMatter -Chunk $chunk -SourceManifestPath ([string]$manifest.source.manifest.path)
    Assert-Condition ((Get-TextSha256 $frontMatter.Body) -eq [string]$chunk.chunkContentHash) "$context transformed body hash does not match."
    $sourceFilePath = Join-Path $root ([string]$chunk.sourcePath).Replace("/", "\")
    Assert-Condition (Test-Path -LiteralPath $sourceFilePath -PathType Leaf) "$context source file does not exist."
    Assert-Condition ((Get-TextSha256 (Get-Content -LiteralPath $sourceFilePath -Raw)) -eq [string]$chunk.contentHash) "$context source content hash does not match its source file."
    Assert-Condition ((Get-TextSha256 (Get-SourceSectionText -SourcePath $sourceFilePath -StartLine ([int]$chunk.sourceStartLine) -EndLine ([int]$chunk.sourceEndLine))) -eq [string]$chunk.sourceSectionHash) "$context source section hash does not match its source lines."

    $resolvedCount += @($chunk.links.resolved).Count
    foreach ($link in @($chunk.links.resolved)) {
        Assert-Condition ([string]$link.target -notmatch "\\|^/") "$context contains a non-portable resolved link."
    }
    foreach ($link in @($chunk.links.unresolved)) {
        Assert-Condition (-not $unresolvedById.ContainsKey([string]$link.id)) "Duplicate unresolved link '$($link.id)'."
        $unresolvedById[[string]$link.id] = $link
        Assert-Condition ([string]$link.chunkId -eq [string]$chunk.id) "$context contains an unresolved link for another chunk."
    }
}

foreach ($chunk in $chunks) {
    $indices = @($chunks | Where-Object { $_.sourcePath -eq $chunk.sourcePath -and $_.sourceUid -eq $chunk.sourceUid } | Sort-Object chunkIndex | ForEach-Object { [int]$_.chunkIndex })
    if ($indices.Count -gt 0 -and [int]$chunk.chunkIndex -eq 0) {
        for ($index = 0; $index -lt $indices.Count; $index++) {
            Assert-Condition ($indices[$index] -eq $index) "Chunks for '$($chunk.sourcePath)' do not have contiguous section indices."
        }
        Assert-Condition ([int]$chunk.chunkCount -eq $indices.Count) "Chunks for '$($chunk.sourcePath)' disagree on section count."
    }
}

$unresolved = @($manifest.unresolvedLinks)
Assert-Condition ($unresolved.Count -eq $unresolvedById.Count) "Top-level unresolved-link count does not match chunk records."
foreach ($link in $unresolved) {
    Assert-Condition ($unresolvedById.ContainsKey([string]$link.id)) "Top-level unresolved link '$($link.id)' is not recorded by its chunk."
}
$expectedUnresolved = @($unresolved | Sort-Object chunkId, sourceLine, target, reason, id)
for ($index = 0; $index -lt $unresolved.Count; $index++) {
    Assert-Condition ([string]$unresolved[$index].id -eq [string]$expectedUnresolved[$index].id) "Top-level unresolved links are not sorted deterministically."
}

Assert-Condition ([int]$manifest.counts.sourcePages -eq $sourcePages.Count) "Manifest source-page count is incorrect."
Assert-Condition ([int]$manifest.counts.chunks -eq $chunks.Count) "Manifest chunk count is incorrect."
Assert-Condition ([int]$manifest.counts.resolvedLinks -eq $resolvedCount) "Manifest resolved-link count is incorrect."
Assert-Condition ([int]$manifest.counts.unresolvedLinks -eq $unresolved.Count) "Manifest unresolved-link count is incorrect."
Assert-Condition ([int]$manifest.scope.sourcePaths.Count -eq $sourcePages.Count) "Manifest scope does not match chunk source pages."
foreach ($pack in @($manifest.packs)) {
    $packChunks = @($chunks | Where-Object { $_.domain -eq $pack.domain })
    Assert-Condition ([int]$pack.chunks -eq $packChunks.Count) "Pack '$($pack.domain)' chunk count is incorrect."
    Assert-Condition ([int]$pack.sourcePages -eq @($packChunks | Select-Object -ExpandProperty sourcePath -Unique).Count) "Pack '$($pack.domain)' source-page count is incorrect."
    Assert-Condition ([string]$pack.directory -eq ([string]$pack.domain).ToLowerInvariant()) "Pack '$($pack.domain)' directory is incorrect."
}

$actualMarkdown = @(Get-ChildItem -LiteralPath (Split-Path -Parent $manifestPath) -Recurse -File -Filter "*.md" | ForEach-Object {
        $_.FullName.Substring((Split-Path -Parent $manifestPath).Length + 1).Replace("\", "/")
    })
Assert-Condition ($actualMarkdown.Count -eq $chunkByPath.Count) "The output directory contains unrecorded or stale Markdown files."
foreach ($path in $actualMarkdown) {
    Assert-Condition $chunkByPath.ContainsKey($path) "Output Markdown '$path' is not listed in the manifest."
}

Write-Output "Internal topic pack validation passed."
Write-Output "Source pages: $($sourcePages.Count)."
Write-Output "Chunks: $($chunks.Count)."
Write-Output "Resolved links: $resolvedCount; unresolved links: $($unresolved.Count)."
