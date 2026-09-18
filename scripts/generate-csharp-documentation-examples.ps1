[CmdletBinding()]
param(
    [string]$RepositoryRoot = (Join-Path $PSScriptRoot ".."),
    [string]$ScopePath = (Join-Path $PSScriptRoot "csharp-documentation-examples-scope.json"),
    [string]$OutputPath = (Join-Path $PSScriptRoot "..\_artifacts\csharp-documentation-examples"),
    [string]$SourceRevision = ""
)

Set-StrictMode -Version 2.0
$ErrorActionPreference = "Stop"

$script:GeneratorVersion = "1.0.0"
$script:SchemaVersion = 1
$script:SchemaName = "contributing/metadata/csharp-documentation-example-v1.schema.json"
$script:Repository = "SkylineCommunications/dataminer-docs"
$script:SupportedLanguages = @("csharp", "cs", "c#")

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
    param(
        [Parameter(Mandatory = $true)][string]$Path,
        [string]$BasePath = (Get-Location).Path
    )

    if ([IO.Path]::IsPathRooted($Path)) {
        return [IO.Path]::GetFullPath($Path)
    }

    return [IO.Path]::GetFullPath((Join-Path $BasePath $Path))
}

function ConvertTo-PortablePath {
    param([Parameter(Mandatory = $true)][string]$Path)

    return $Path.Replace("\", "/")
}

function ConvertTo-RepositoryRelativePath {
    param(
        [Parameter(Mandatory = $true)][string]$Path,
        [Parameter(Mandatory = $true)][string]$Root
    )

    $fullPath = [IO.Path]::GetFullPath($Path)
    $rootPath = [IO.Path]::GetFullPath($Root).TrimEnd("\")
    if ($fullPath.Equals($rootPath, [StringComparison]::OrdinalIgnoreCase)) {
        return ""
    }

    $prefix = $rootPath + "\"
    Assert-Condition $fullPath.StartsWith($prefix, [StringComparison]::OrdinalIgnoreCase) `
        "Path '$Path' is outside repository root '$Root'."
    return ConvertTo-PortablePath $fullPath.Substring($prefix.Length)
}

function Assert-SafeRelativePath {
    param(
        [Parameter(Mandatory = $true)][string]$Value,
        [Parameter(Mandatory = $true)][string]$Context
    )

    Assert-Condition (-not [IO.Path]::IsPathRooted($Value)) "$Context is absolute."
    Assert-Condition ($Value -notmatch "\\") "$Context contains a Windows path separator."
    Assert-Condition ($Value -notmatch "(^|/)\.\.(?:/|$)") "$Context escapes its root."
    Assert-Condition ($Value -notmatch "^/") "$Context starts at the filesystem root."
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
    param([Parameter(Mandatory = $true)][string]$Path)

    return (Get-FileHash -LiteralPath $Path -Algorithm SHA256).Hash.ToLowerInvariant()
}

function Write-Json {
    param(
        [Parameter(Mandatory = $true)][string]$Path,
        [Parameter(Mandatory = $true)]$Value
    )

    $directory = Split-Path -Parent $Path
    if (-not (Test-Path -LiteralPath $directory -PathType Container)) {
        New-Item -ItemType Directory -Path $directory -Force | Out-Null
    }

    $utf8NoBom = New-Object Text.UTF8Encoding($false)
    [IO.File]::WriteAllText($Path, (($Value | ConvertTo-Json -Depth 30) + [Environment]::NewLine), $utf8NoBom)
}

function Get-SourceRevision {
    param(
        [Parameter(Mandatory = $true)][string]$Root,
        [AllowEmptyString()][string]$RequestedRevision
    )

    if ($RequestedRevision -match "^[0-9a-f]{40}$") {
        return [PSCustomObject]@{
            Value = $RequestedRevision.ToLowerInvariant()
            Source = "argument"
        }
    }

    if ($env:GITHUB_SHA -match "^[0-9a-f]{40}$") {
        return [PSCustomObject]@{
            Value = $env:GITHUB_SHA.ToLowerInvariant()
            Source = "environment"
        }
    }

    try {
        $revision = (& git -C $Root rev-parse HEAD 2>$null | Select-Object -First 1)
        if ([string]$revision -match "^[0-9a-f]{40}$") {
            return [PSCustomObject]@{
                Value = ([string]$revision).ToLowerInvariant()
                Source = "git"
            }
        }
    }
    catch {
        # A source archive or fixture does not have to be a Git checkout.
    }

    return [PSCustomObject]@{
        Value = "unknown"
        Source = "unknown"
    }
}

function Get-PageUid {
    param([Parameter(Mandatory = $true)][AllowEmptyString()][string]$Text)

    $match = [Regex]::Match(
        (Normalize-Text $Text),
        "\A---\n(?<front>.*?)\n---(?:\n|\z)",
        [Text.RegularExpressions.RegexOptions]::Singleline
    )
    if (-not $match.Success) {
        return "unknown"
    }

    $uidMatch = [Regex]::Match($match.Groups["front"].Value, "(?m)^uid:\s*(?<uid>.+?)\s*$")
    if (-not $uidMatch.Success) {
        return "unknown"
    }

    $uid = $uidMatch.Groups["uid"].Value.Trim()
    if (($uid.StartsWith('"') -and $uid.EndsWith('"')) -or
        ($uid.StartsWith("'") -and $uid.EndsWith("'"))) {
        $uid = $uid.Substring(1, $uid.Length - 2)
    }
    if ([string]::IsNullOrWhiteSpace($uid)) {
        return "unknown"
    }
    return $uid
}

function Get-ScopeConfiguration {
    param(
        [Parameter(Mandatory = $true)][string]$Path
    )

    $json = Get-Content -LiteralPath $Path -Raw
    try {
        $configuration = $json | ConvertFrom-Json
    }
    catch {
        throw "C# documentation example scope '$Path' is not valid JSON: $($_.Exception.Message)"
    }

    Assert-Condition ([int]$configuration.schemaVersion -eq 1) "C# example scope schemaVersion must be 1."
    Assert-Condition ([string]$configuration.format -eq "csharp-documentation-example-scope") `
        "C# example scope format is not supported."
    Assert-Condition ($null -ne $configuration.include -and @($configuration.include).Count -gt 0) `
        "C# example scope must include at least one path."
    Assert-Condition ([string]$configuration.defaultClassification -eq "fragment") `
        "C# example scope must default unannotated blocks to fragment."
    return $configuration
}

function Get-ScopeFiles {
    param(
        [Parameter(Mandatory = $true)][string]$Root,
        [Parameter(Mandatory = $true)]$Configuration
    )

    $paths = New-Object "System.Collections.Generic.List[string]"
    foreach ($includeValue in @($Configuration.include)) {
        $include = [string]$includeValue
        $candidate = ConvertTo-FullPath -Path $include -BasePath $Root
        if (Test-Path -LiteralPath $candidate -PathType Leaf) {
            Assert-Condition ([IO.Path]::GetExtension($candidate) -ieq ".md") `
                "C# example scope file '$include' is not Markdown."
            [void]$paths.Add([IO.Path]::GetFullPath($candidate))
            continue
        }

        Assert-Condition (Test-Path -LiteralPath $candidate -PathType Container) `
            "C# example scope path '$include' does not exist."
        foreach ($file in @(Get-ChildItem -LiteralPath $candidate -Recurse -File -Filter "*.md")) {
            [void]$paths.Add($file.FullName)
        }
    }

    $excluded = @{}
    foreach ($excludeValue in @($Configuration.exclude)) {
        $exclude = ConvertTo-PortablePath ([string]$excludeValue).Trim("/")
        if (-not [string]::IsNullOrWhiteSpace($exclude)) {
            $excluded[$exclude.ToLowerInvariant()] = $true
        }
    }

    $result = New-Object "System.Collections.Generic.List[string]"
    $seen = @{}
    foreach ($path in @($paths | Sort-Object)) {
        $relative = ConvertTo-RepositoryRelativePath -Path $path -Root $Root
        $key = $relative.ToLowerInvariant()
        $isExcluded = $false
        foreach ($excludedPath in $excluded.Keys) {
            if ($key -eq $excludedPath -or $key.StartsWith($excludedPath + "/")) {
                $isExcluded = $true
                break
            }
        }
        if (-not $isExcluded -and -not $seen.ContainsKey($key)) {
            $seen[$key] = $true
            [void]$result.Add($path)
        }
    }

    return @($result.ToArray())
}

function Get-MetadataTokens {
    param([AllowEmptyString()][string]$Text)

    $values = @{}
    if ([string]::IsNullOrWhiteSpace($Text)) {
        return $values
    }

    foreach ($token in @([Regex]::Split($Text.Trim().Replace(";", " "), "\s+"))) {
        if ([string]::IsNullOrWhiteSpace($token)) {
            continue
        }

        $match = [Regex]::Match($token, "^(?<key>[A-Za-z][A-Za-z0-9_-]*)\s*(?:=|:)\s*(?<value>.+)$")
        if ($match.Success) {
            $key = $match.Groups["key"].Value.ToLowerInvariant()
            $value = $match.Groups["value"].Value.Trim()
            if (($value.StartsWith('"') -and $value.EndsWith('"')) -or
                ($value.StartsWith("'") -and $value.EndsWith("'"))) {
                $value = $value.Substring(1, $value.Length - 2)
            }
            $values[$key] = $value
            continue
        }

        if (-not $values.ContainsKey("example") -and
            $token.ToLowerInvariant() -in @("complete", "compilable", "fragment", "pseudocode")) {
            $values["example"] = $token
        }
    }

    return $values
}

function Get-BlockMetadata {
    param(
        [AllowEmptyCollection()][AllowEmptyString()][string[]]$Lines,
        [Parameter(Mandatory = $true)][int]$OpeningLineIndex,
        [Parameter(Mandatory = $true)][string]$Info
    )

    $commentMetadata = @{}
    $previousIndex = $OpeningLineIndex - 1
    while ($previousIndex -ge 0 -and [string]::IsNullOrWhiteSpace($Lines[$previousIndex])) {
        $previousIndex--
    }
    if ($previousIndex -ge 0) {
        $commentMatch = [Regex]::Match(
            $Lines[$previousIndex],
            "<!--\s*csharp-example\s*:\s*(?<metadata>.*?)\s*-->",
            [Text.RegularExpressions.RegexOptions]::IgnoreCase
        )
        if ($commentMatch.Success) {
            $commentMetadata = Get-MetadataTokens $commentMatch.Groups["metadata"].Value
        }
    }

    $infoMatch = [Regex]::Match($Info.Trim(), "^(?<language>[^\s]+)(?<metadata>.*)$")
    $infoMetadata = @{}
    if ($infoMatch.Success) {
        $infoMetadata = Get-MetadataTokens $infoMatch.Groups["metadata"].Value
    }

    $merged = @{}
    foreach ($key in $commentMetadata.Keys) {
        $merged[$key] = $commentMetadata[$key]
    }
    foreach ($key in $infoMetadata.Keys) {
        $merged[$key] = $infoMetadata[$key]
    }

    $source = "missing"
    if ($infoMetadata.ContainsKey("example") -or
        $infoMetadata.ContainsKey("classification") -or
        $infoMetadata.ContainsKey("framework") -or
        $infoMetadata.ContainsKey("targetframework") -or
        $infoMetadata.ContainsKey("packages")) {
        $source = "fence-info"
    }
    elseif ($commentMetadata.Count -gt 0) {
        $source = "comment"
    }

    return [PSCustomObject]@{
        Values = $merged
        Source = $source
    }
}

function Get-BlockClassification {
    param(
        [Parameter(Mandatory = $true)]$Metadata,
        [Parameter(Mandatory = $true)][bool]$IsClosed
    )

    $values = $Metadata.Values
    $declared = "none"
    if ($values.ContainsKey("example")) {
        $declared = [string]$values["example"]
    }
    elseif ($values.ContainsKey("classification")) {
        $declared = [string]$values["classification"]
    }

    $normalizedDeclared = $declared.ToLowerInvariant()
    $classification = "fragment"
    $reason = "missing-explicit-classification"
    $validationErrors = New-Object "System.Collections.Generic.List[string]"
    $targetFramework = "not_applicable"
    $packageDeclaration = "not_applicable"
    $packages = @()

    if ($normalizedDeclared -in @("pseudocode")) {
        $classification = "pseudocode"
        $reason = "explicit-pseudocode"
    }
    elseif ($normalizedDeclared -in @("fragment")) {
        $classification = "fragment"
        $reason = "explicit-fragment"
    }
    elseif ($normalizedDeclared -in @("complete", "compilable")) {
        $classification = "complete"
        $reason = "explicit-complete"

        $frameworkKey = if ($values.ContainsKey("framework")) { "framework" } elseif ($values.ContainsKey("targetframework")) { "targetframework" } else { "" }
        if ([string]::IsNullOrWhiteSpace($frameworkKey)) {
            [void]$validationErrors.Add("complete examples must declare framework=<target-framework>")
        }
        else {
            $targetFramework = [string]$values[$frameworkKey]
            if ($targetFramework -notmatch "^net(?:standard|coreapp)?[0-9]+(?:\.[0-9]+)?(?:-[A-Za-z0-9.]+)?$") {
                [void]$validationErrors.Add("framework '$targetFramework' is not an exact supported target framework")
            }
        }

        if (-not $values.ContainsKey("packages") -or [string]::IsNullOrWhiteSpace([string]$values["packages"])) {
            [void]$validationErrors.Add("complete examples must declare packages=none or exact package versions")
        }
        else {
            $packageDeclaration = [string]$values["packages"]
            if ($packageDeclaration -ine "none") {
                $packageValues = @($packageDeclaration.Split(",") | ForEach-Object { $_.Trim() } | Where-Object { $_ -ne "" })
                $packageIds = @{}
                foreach ($packageValue in $packageValues) {
                    $packageMatch = [Regex]::Match($packageValue, "^(?<id>[A-Za-z0-9_.-]+)@(?<version>[0-9][A-Za-z0-9+.-]*)$")
                    if (-not $packageMatch.Success) {
                        [void]$validationErrors.Add("package '$packageValue' must use Package.Id@exact-version")
                        continue
                    }
                    $packageId = $packageMatch.Groups["id"].Value
                    if ($packageIds.ContainsKey($packageId.ToLowerInvariant())) {
                        [void]$validationErrors.Add("package '$packageId' is declared more than once")
                        continue
                    }
                    $packageIds[$packageId.ToLowerInvariant()] = $true
                    $packages += [ordered]@{
                        id = $packageId
                        version = $packageMatch.Groups["version"].Value
                    }
                }
                $packages = @($packages | Sort-Object id, version)
            }
        }

        if (-not $IsClosed) {
            [void]$validationErrors.Add("complete examples must have a closing code fence")
        }
        if ($validationErrors.Count -gt 0) {
            $classification = "fragment"
            $reason = "invalid-complete-metadata"
        }
    }
    elseif ($normalizedDeclared -eq "none") {
        $classification = "fragment"
        $reason = "missing-explicit-classification"
    }
    else {
        $classification = "fragment"
        $reason = "invalid-classification"
        [void]$validationErrors.Add("classification '$declared' is not complete, fragment, or pseudocode")
    }

    return [PSCustomObject]@{
        Declared = $declared
        Classification = $classification
        ClassificationReason = $reason
        TargetFramework = $targetFramework
        PackageDeclaration = $packageDeclaration
        Packages = @($packages)
        ValidationErrors = @($validationErrors.ToArray())
    }
}

function Get-CSharpBlocks {
    param(
        [AllowEmptyCollection()][AllowEmptyString()][string[]]$Lines,
        [Parameter(Mandatory = $true)][string]$PageHash
    )

    $blocks = New-Object "System.Collections.Generic.List[object]"
    $inFence = $false
    $openingIndex = -1
    $openingIndent = ""
    $openingMarker = ""
    $openingInfo = ""
    $content = New-Object "System.Collections.Generic.List[string]"
    $csharpIndex = 0

    for ($index = 0; $index -lt $Lines.Count; $index++) {
        $line = $Lines[$index]
        $fencePattern = "^(?<indent> *)(?<marker>" + [char]96 + "{3,}|~{3,})(?<info>.*)$"
        $fenceMatch = [Regex]::Match($line, $fencePattern)

        if (-not $inFence) {
            if ($fenceMatch.Success) {
                $inFence = $true
                $openingIndex = $index
                $openingIndent = $fenceMatch.Groups["indent"].Value
                $openingMarker = $fenceMatch.Groups["marker"].Value
                $openingInfo = $fenceMatch.Groups["info"].Value.Trim()
                $content = New-Object "System.Collections.Generic.List[string]"
            }
            continue
        }

        $closingPattern = "^\s*(?<marker>" + [Regex]::Escape($openingMarker.Substring(0, 1)) + "{"+ $openingMarker.Length + ",})\s*$"
        $closingMatch = [Regex]::Match($line, $closingPattern)
        if ($closingMatch.Success) {
            $infoMatch = [Regex]::Match($openingInfo, "^(?<language>[^\s]+)")
            $language = if ($infoMatch.Success) { $infoMatch.Groups["language"].Value.ToLowerInvariant() } else { "" }
            if ($script:SupportedLanguages -contains $language) {
                $csharpIndex++
                $codeLines = New-Object "System.Collections.Generic.List[string]"
                foreach ($codeLine in $content.ToArray()) {
                    if ($openingIndent.Length -gt 0 -and $codeLine.StartsWith($openingIndent, [StringComparison]::Ordinal)) {
                        [void]$codeLines.Add($codeLine.Substring($openingIndent.Length))
                    }
                    else {
                        [void]$codeLines.Add($codeLine)
                    }
                }
                $code = ($codeLines.ToArray() -join "`n")
                $metadata = Get-BlockMetadata -Lines $Lines -OpeningLineIndex $openingIndex -Info $openingInfo
                [void]$blocks.Add([PSCustomObject]@{
                        Index = $csharpIndex
                        Language = $language
                        OpeningLine = $openingIndex + 1
                        ClosingLine = $index + 1
                        Code = $code
                        CodeHash = Get-TextSha256 $code
                        PageHash = $PageHash
                        Metadata = $metadata
                        IsClosed = $true
                    })
            }

            $inFence = $false
            $openingIndex = -1
            $openingIndent = ""
            $openingMarker = ""
            $openingInfo = ""
            $content = New-Object "System.Collections.Generic.List[string]"
            continue
        }

        [void]$content.Add($line)
    }

    if ($inFence) {
        $infoMatch = [Regex]::Match($openingInfo, "^(?<language>[^\s]+)")
        $language = if ($infoMatch.Success) { $infoMatch.Groups["language"].Value.ToLowerInvariant() } else { "" }
        if ($script:SupportedLanguages -contains $language) {
            $csharpIndex++
            $codeLines = New-Object "System.Collections.Generic.List[string]"
            foreach ($codeLine in $content.ToArray()) {
                if ($openingIndent.Length -gt 0 -and $codeLine.StartsWith($openingIndent, [StringComparison]::Ordinal)) {
                    [void]$codeLines.Add($codeLine.Substring($openingIndent.Length))
                }
                else {
                    [void]$codeLines.Add($codeLine)
                }
            }
            $code = ($codeLines.ToArray() -join "`n")
            $metadata = Get-BlockMetadata -Lines $Lines -OpeningLineIndex $openingIndex -Info $openingInfo
            [void]$blocks.Add([PSCustomObject]@{
                    Index = $csharpIndex
                    Language = $language
                    OpeningLine = $openingIndex + 1
                    ClosingLine = $Lines.Count
                    Code = $code
                    CodeHash = Get-TextSha256 $code
                    PageHash = $PageHash
                    Metadata = $metadata
                    IsClosed = $false
                })
        }
    }

    return @($blocks.ToArray())
}

function Write-CSharpProject {
    param(
        [Parameter(Mandatory = $true)][string]$ProjectDirectory,
        [Parameter(Mandatory = $true)][string]$Code,
        [Parameter(Mandatory = $true)][string]$TargetFramework,
        [Parameter(Mandatory = $true)]$Packages
    )

    New-Item -ItemType Directory -Path $ProjectDirectory -Force | Out-Null
    $packageReferences = New-Object "System.Collections.Generic.List[string]"
    foreach ($package in @($Packages | Sort-Object id, version)) {
        [void]$packageReferences.Add(
            "    <PackageReference Include=""$($package.id)"" Version=""$($package.version)"" />"
        )
    }
    $packageItemGroup = if ($packageReferences.Count -gt 0) {
        "  <ItemGroup>`n" + ($packageReferences.ToArray() -join "`n") + "`n  </ItemGroup>`n"
    }
    else {
        ""
    }

    $project = @"
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>$TargetFramework</TargetFramework>
    <OutputType>Library</OutputType>
    <ImplicitUsings>disable</ImplicitUsings>
    <Nullable>disable</Nullable>
    <EnableDefaultCompileItems>false</EnableDefaultCompileItems>
  </PropertyGroup>
  <ItemGroup>
    <Compile Include="Example.cs" />
  </ItemGroup>
$packageItemGroup</Project>
"@

    $utf8NoBom = New-Object Text.UTF8Encoding($false)
    [IO.File]::WriteAllText((Join-Path $ProjectDirectory "Example.csproj"), $project, $utf8NoBom)
    [IO.File]::WriteAllText((Join-Path $ProjectDirectory "Example.cs"), ($Code.TrimEnd() + [Environment]::NewLine), $utf8NoBom)
}

function Invoke-DotNet {
    param(
        [Parameter(Mandatory = $true)][string[]]$Arguments,
        [Parameter(Mandatory = $true)][string]$WorkingDirectory,
        [Parameter(Mandatory = $true)][string]$RepositoryRoot
    )

    $dotnet = Get-Command dotnet -ErrorAction SilentlyContinue
    if ($null -eq $dotnet) {
        return [PSCustomObject]@{
            ExitCode = 9009
            DiagnosticHash = Get-TextSha256 "dotnet executable was not found"
        }
    }

    $output = @()
    Push-Location $WorkingDirectory
    try {
        $output = @(& $dotnet.Source @Arguments 2>&1)
        $exitCode = $LASTEXITCODE
    }
    finally {
        Pop-Location
    }

    $diagnostics = (($output | ForEach-Object { [string]$_ }) -join "`n")
    $diagnostics = $diagnostics.Replace($RepositoryRoot, "<repository>").Replace($WorkingDirectory, "<project>")
    return [PSCustomObject]@{
        ExitCode = [int]$exitCode
        DiagnosticHash = Get-TextSha256 $diagnostics
    }
}

function Invoke-ExampleCompilation {
    param(
        [Parameter(Mandatory = $true)][string]$ProjectPath,
        [Parameter(Mandatory = $true)][string]$ProjectDirectory,
        [Parameter(Mandatory = $true)][string]$RepositoryRoot
    )

    $restore = Invoke-DotNet -Arguments @(
        "restore",
        $ProjectPath,
        "--nologo",
        "--ignore-failed-sources",
        "-p:NuGetAudit=false"
    ) -WorkingDirectory $ProjectDirectory -RepositoryRoot $RepositoryRoot
    if ($restore.ExitCode -ne 0) {
        return [PSCustomObject]@{
            Status = "failed"
            Reason = "dotnet-restore-failed"
            DiagnosticHash = $restore.DiagnosticHash
        }
    }

    $build = Invoke-DotNet -Arguments @(
        "build",
        $ProjectPath,
        "--configuration",
        "Release",
        "--no-restore",
        "--nologo",
        "-p:NuGetAudit=false"
    ) -WorkingDirectory $ProjectDirectory -RepositoryRoot $RepositoryRoot
    if ($build.ExitCode -ne 0) {
        return [PSCustomObject]@{
            Status = "failed"
            Reason = "dotnet-build-failed"
            DiagnosticHash = $build.DiagnosticHash
        }
    }

    return [PSCustomObject]@{
        Status = "compiled"
        Reason = "dotnet-build-succeeded"
        DiagnosticHash = "not_applicable"
    }
}

$root = ConvertTo-FullPath $RepositoryRoot
$scopePath = ConvertTo-FullPath $ScopePath -BasePath (Get-Location).Path
$output = ConvertTo-FullPath $OutputPath -BasePath (Get-Location).Path
Assert-Condition (Test-Path -LiteralPath $root -PathType Container) "Repository root '$root' does not exist."
Assert-Condition (Test-Path -LiteralPath $scopePath -PathType Leaf) "C# example scope '$scopePath' does not exist."

$configuration = Get-ScopeConfiguration -Path $scopePath
$scopeFiles = Get-ScopeFiles -Root $root -Configuration $configuration
$revision = Get-SourceRevision -Root $root -RequestedRevision $SourceRevision
$scopeRelativePath = ConvertTo-RepositoryRelativePath -Path $scopePath -Root $root
$scopeHash = Get-FileSha256 $scopePath

if (Test-Path -LiteralPath $output) {
    Remove-Item -LiteralPath $output -Recurse -Force
}
New-Item -ItemType Directory -Path $output -Force | Out-Null
$projectsRoot = Join-Path $output "projects"
New-Item -ItemType Directory -Path $projectsRoot -Force | Out-Null

$examples = New-Object "System.Collections.Generic.List[object]"
$validationErrors = New-Object "System.Collections.Generic.List[string]"
$compiledCount = 0
$failedCount = 0
$notAttemptedCount = 0
$completeCount = 0
$fragmentCount = 0
$pseudocodeCount = 0
$invalidMetadataCount = 0

foreach ($pagePath in $scopeFiles) {
    $relativePagePath = ConvertTo-RepositoryRelativePath -Path $pagePath -Root $root
    $normalizedPage = Normalize-Text (Get-Content -LiteralPath $pagePath -Raw)
    $pageHash = Get-TextSha256 $normalizedPage
    $lines = @($normalizedPage -split "`n")
    $uid = Get-PageUid $normalizedPage
    $blocks = @()
    if (-not [string]::IsNullOrEmpty($normalizedPage)) {
        $blocks = @(Get-CSharpBlocks -Lines $lines -PageHash $pageHash)
    }

    foreach ($block in $blocks) {
        $classification = Get-BlockClassification -Metadata $block.Metadata -IsClosed $block.IsClosed
        $identity = "$relativePagePath#csharp-block-$($block.Index)"
        $exampleId = "csharp-" + (Get-TextSha256 $identity).Substring(0, 16)
        $declaredClassification = [string]$classification.Declared
        $metadataValues = $block.Metadata.Values
        $metadataClassification = if ($metadataValues.ContainsKey("classification")) { [string]$metadataValues["classification"] } elseif ($metadataValues.ContainsKey("example")) { [string]$metadataValues["example"] } else { "none" }
        $metadataFramework = if ($metadataValues.ContainsKey("framework")) { [string]$metadataValues["framework"] } elseif ($metadataValues.ContainsKey("targetframework")) { [string]$metadataValues["targetframework"] } else { "not_applicable" }
        $metadataPackages = if ($metadataValues.ContainsKey("packages")) { [string]$metadataValues["packages"] } else { "not_applicable" }
        $projectPath = "not_applicable"
        $sourcePath = "not_applicable"
        $assemblyPath = "not_applicable"
        $diagnosticHash = "not_applicable"
        $resultStatus = "not-attempted"
        $resultReason = $classification.ClassificationReason

        foreach ($validationError in @($classification.ValidationErrors)) {
            [void]$validationErrors.Add("${relativePagePath}:$($block.OpeningLine): $validationError")
        }
        if ($classification.ValidationErrors.Count -gt 0) {
            $invalidMetadataCount++
        }

        if ($classification.Classification -eq "complete") {
            $completeCount++
            $projectDirectory = Join-Path $projectsRoot $exampleId
            Write-CSharpProject -ProjectDirectory $projectDirectory -Code $block.Code `
                -TargetFramework $classification.TargetFramework -Packages $classification.Packages
            $projectRelativeDirectory = Join-Path "projects" $exampleId
            $projectPath = ConvertTo-PortablePath (Join-Path $projectRelativeDirectory "Example.csproj")
            $sourcePath = ConvertTo-PortablePath (Join-Path $projectRelativeDirectory "Example.cs")
            $assemblyRelativeDirectory = Join-Path $projectRelativeDirectory "bin\Release\$($classification.TargetFramework)"
            $assemblyPath = ConvertTo-PortablePath (Join-Path $assemblyRelativeDirectory "Example.dll")
            if ($classification.ValidationErrors.Count -eq 0) {
                $compilation = Invoke-ExampleCompilation `
                    -ProjectPath (Join-Path $projectDirectory "Example.csproj") `
                    -ProjectDirectory $projectDirectory `
                    -RepositoryRoot $root
                $resultStatus = $compilation.Status
                $resultReason = $compilation.Reason
                $diagnosticHash = $compilation.DiagnosticHash
                if ($resultStatus -eq "compiled") {
                    $compiledCount++
                }
                else {
                    $failedCount++
                }
            }
            else {
                $resultStatus = "failed"
                $resultReason = "invalid-complete-metadata"
                $diagnosticHash = Get-TextSha256 (($classification.ValidationErrors -join "`n"))
                $failedCount++
            }
        }
        else {
            $notAttemptedCount++
            if ($classification.Classification -eq "fragment") {
                $fragmentCount++
            }
            elseif ($classification.Classification -eq "pseudocode") {
                $pseudocodeCount++
            }
        }

        [void]$examples.Add([ordered]@{
                id = $exampleId
                sourcePage = $relativePagePath
                sourceUid = $uid
                codeBlockIndex = [int]$block.Index
                sourceLineStart = [int]$block.OpeningLine
                sourceLineEnd = [int]$block.ClosingLine
                sourcePageHash = $pageHash
                sourceCodeHash = $block.CodeHash
                language = $block.Language
                declaredClassification = $declaredClassification
                classification = $classification.Classification
                classificationSource = $block.Metadata.Source
                metadata = [ordered]@{
                    classification = $metadataClassification
                    framework = $metadataFramework
                    packages = $metadataPackages
                }
                targetFramework = $classification.TargetFramework
                packages = @($classification.Packages)
                classificationReason = [string]$classification.ClassificationReason
                result = [ordered]@{
                    status = $resultStatus
                    reason = $resultReason
                    projectPath = $projectPath
                    sourcePath = $sourcePath
                    assemblyPath = $assemblyPath
                    diagnosticHash = $diagnosticHash
                }
            })
    }
}

$sortedExamples = @(
    $examples.ToArray() |
        Sort-Object @{ Expression = { $_["sourcePage"] } }, @{ Expression = { $_["codeBlockIndex"] } }
)
$gaps = New-Object "System.Collections.Generic.List[string]"
foreach ($gap in @($configuration.gaps)) {
    [void]$gaps.Add([string]$gap)
}
if ($fragmentCount -gt 0) {
    [void]$gaps.Add("$fragmentCount C# block(s) are fragments and were not compiled.")
}
if ($pseudocodeCount -gt 0) {
    [void]$gaps.Add("$pseudocodeCount C# block(s) are pseudocode and were not compiled.")
}
if ($completeCount -eq 0) {
    [void]$gaps.Add("No complete examples are currently opted into compilation in this bounded scope.")
}
if ($invalidMetadataCount -gt 0) {
    [void]$gaps.Add("$invalidMetadataCount complete-example declaration(s) have invalid metadata and require correction.")
}
if ($failedCount -gt 0) {
    [void]$gaps.Add("$failedCount complete example project(s) did not compile.")
}

$manifest = [ordered]@{
    schemaVersion = $script:SchemaVersion
    format = "csharp-documentation-examples"
    generator = [ordered]@{
        name = "scripts/generate-csharp-documentation-examples.ps1"
        version = $script:GeneratorVersion
    }
    schema = [ordered]@{
        name = $script:SchemaName
        version = $script:SchemaVersion
    }
    source = [ordered]@{
        repository = $script:Repository
        revision = $revision.Value
        revisionSource = $revision.Source
    }
    scope = [ordered]@{
        mode = "bounded-representative"
        configuration = [ordered]@{
            path = $scopeRelativePath
            sha256 = $scopeHash
        }
        include = @($configuration.include | ForEach-Object { ConvertTo-PortablePath ([string]$_) })
        exclude = @($configuration.exclude | ForEach-Object { ConvertTo-PortablePath ([string]$_) })
        coverage = [ordered]@{
            pageCount = $scopeFiles.Count
            csharpBlockCount = $examples.Count
            fullCorpusAudited = $false
            notes = @(
                "Only pages selected by the committed scope configuration were scanned.",
                "C# blocks without explicit classification metadata remain fragments."
            )
        }
    }
    generation = [ordered]@{
        deterministic = $true
        contentHashAlgorithm = "sha256"
        generatedContent = @("complete-example-projects")
    }
    counts = [ordered]@{
        pageCount = $scopeFiles.Count
        csharpBlockCount = $examples.Count
        complete = $completeCount
        fragment = $fragmentCount
        pseudocode = $pseudocodeCount
        invalidMetadata = $invalidMetadataCount
        compiled = $compiledCount
        failed = $failedCount
        notAttempted = $notAttemptedCount
    }
    gaps = @($gaps.ToArray())
    examples = $sortedExamples
}

$manifestPath = Join-Path $output "csharp-documentation-examples.json"
Write-Json -Path $manifestPath -Value $manifest

if ($validationErrors.Count -gt 0) {
    throw "C# documentation example metadata validation failed: $($validationErrors.ToArray() -join '; ')"
}
if ($failedCount -gt 0) {
    throw "$failedCount complete C# documentation example project(s) failed to compile. See '$manifestPath'."
}

Write-Output "C# documentation example manifest generated: $($scopeFiles.Count) page(s), $($examples.Count) C# block(s), $compiledCount compiled, $fragmentCount fragment(s), $pseudocodeCount pseudocode block(s)."
