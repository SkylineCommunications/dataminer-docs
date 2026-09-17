[CmdletBinding()]
param(
    [string]$RepositoryRoot = (Join-Path $PSScriptRoot ".."),
    [string[]]$Path
)

Set-StrictMode -Version 2.0
$ErrorActionPreference = "Stop"

function ConvertTo-FullPath {
    param([Parameter(Mandatory = $true)][string]$Path)

    if ([IO.Path]::IsPathRooted($Path)) {
        return [IO.Path]::GetFullPath($Path)
    }

    return [IO.Path]::GetFullPath((Join-Path (Get-Location).Path $Path))
}

function ConvertTo-RepositoryRelativePath {
    param(
        [Parameter(Mandatory = $true)][string]$Path,
        [Parameter(Mandatory = $true)][string]$Root
    )

    $fullPath = [IO.Path]::GetFullPath($Path)
    $prefix = $Root.TrimEnd("\") + "\"
    if (-not $fullPath.StartsWith($prefix, [StringComparison]::OrdinalIgnoreCase)) {
        throw "Anchor path '$Path' is outside the repository root '$Root'."
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

function Get-MarkdownPaths {
    param(
        [Parameter(Mandatory = $true)][string]$Root,
        [string[]]$RequestedPaths
    )

    if ($null -ne $RequestedPaths -and $RequestedPaths.Count -gt 0) {
        $paths = @()
        foreach ($requestedPath in $RequestedPaths) {
            $candidate = if ([IO.Path]::IsPathRooted($requestedPath)) {
                [IO.Path]::GetFullPath($requestedPath)
            }
            else {
                [IO.Path]::GetFullPath((Join-Path $Root $requestedPath))
            }

            if (-not (Test-Path -LiteralPath $candidate -PathType Leaf)) {
                throw "Anchor path '$requestedPath' does not exist."
            }
            if ([IO.Path]::GetExtension($candidate) -ine ".md") {
                throw "Anchor path '$requestedPath' is not a Markdown file."
            }

            $paths += $candidate
        }

        return @($paths | Sort-Object -Unique)
    }

    $paths = @()
    foreach ($file in Get-ChildItem -LiteralPath $Root -File -Filter "*.md") {
        $paths += $file.FullName
    }

    foreach ($directoryName in @("contributing", "dataminer", "develop", "release-notes", "solutions", "tutorials")) {
        $directoryPath = Join-Path $Root $directoryName
        if (-not (Test-Path -LiteralPath $directoryPath -PathType Container)) {
            continue
        }

        $paths += @(Get-ChildItem -LiteralPath $directoryPath -Recurse -File -Filter "*.md" | ForEach-Object { $_.FullName })
    }

    return @($paths | Sort-Object -Unique)
}

function Get-ExplicitAnchors {
    param(
        [Parameter(Mandatory = $true)][string]$Text,
        [Parameter(Mandatory = $true)][string]$RelativePath
    )

    $lines = [Regex]::Split((Normalize-Text $Text), "`n")
    $fenceCharacter = $null
    $anchors = @()
    $anchorPattern = '^\s*<a\s+(?:(?:id|name)\s*=\s*["''](?<id>[^"'']+)["''])\s*>\s*</a>\s*$'
    $fencePattern = '^\s*(?<marker>`{3,}|~{3,})'

    for ($index = 0; $index -lt $lines.Count; $index++) {
        $line = $lines[$index]
        $fenceMatch = [Regex]::Match($line, $fencePattern)
        if ($fenceMatch.Success) {
            $marker = $fenceMatch.Groups["marker"].Value
            if ($null -eq $fenceCharacter) {
                $fenceCharacter = $marker.Substring(0, 1)
            }
            elseif ($marker.StartsWith($fenceCharacter, [StringComparison]::Ordinal)) {
                $fenceCharacter = $null
            }

            continue
        }

        if ($null -ne $fenceCharacter) {
            continue
        }

        $anchorMatch = [Regex]::Match($line, $anchorPattern)
        if (-not $anchorMatch.Success) {
            continue
        }

        $anchorId = $anchorMatch.Groups["id"].Value
        if ([String]::IsNullOrWhiteSpace($anchorId) -or $anchorId -match "\s") {
            throw "Explicit anchor in '$RelativePath' on line $($index + 1) must have a non-empty ID without whitespace."
        }

        $anchors += [PSCustomObject]@{
            Id = $anchorId
            Line = $index + 1
        }
    }

    return @($anchors)
}

$script:RepositoryRoot = ConvertTo-FullPath $RepositoryRoot
if (-not (Test-Path -LiteralPath $script:RepositoryRoot -PathType Container)) {
    throw "Repository root '$script:RepositoryRoot' does not exist."
}

$markdownPaths = @(Get-MarkdownPaths -Root $script:RepositoryRoot -RequestedPaths $Path)
$anchorCount = 0

foreach ($markdownPath in $markdownPaths) {
    $relativePath = ConvertTo-RepositoryRelativePath -Path $markdownPath -Root $script:RepositoryRoot
    $anchors = @(Get-ExplicitAnchors -Text ([IO.File]::ReadAllText($markdownPath)) -RelativePath $relativePath)
    $anchorsById = @{}

    foreach ($anchor in $anchors) {
        if ($anchorsById.ContainsKey($anchor.Id)) {
            $first = $anchorsById[$anchor.Id]
            throw "Duplicate explicit anchor '$($anchor.Id)' in '$relativePath' on lines $($first.Line) and $($anchor.Line)."
        }

        $anchorsById[$anchor.Id] = $anchor
        $anchorCount++
    }
}

Write-Output ("Validated {0} Markdown files; {1} explicit anchors are unique." -f $markdownPaths.Count, $anchorCount)
