[CmdletBinding()]
param(
    [string]$RepositoryRoot = (Join-Path $PSScriptRoot ".."),
    [string]$SchemaPath,
    [string[]]$Path,
    [switch]$RequireVersion1
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
        throw "Path '$Path' is outside the repository root '$Root'."
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
                throw "Metadata path '$requestedPath' does not exist."
            }
            if ([IO.Path]::GetExtension($candidate) -ine ".md") {
                throw "Metadata path '$requestedPath' is not a Markdown file."
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

function Get-FrontMatter {
    param([Parameter(Mandatory = $true)][string]$Text)

    $normalized = Normalize-Text $Text
    $match = [Regex]::Match(
        $normalized,
        "\A---\n(?<front>.*?)\n---(?:\n|\z)",
        [Text.RegularExpressions.RegexOptions]::Singleline
    )

    if (-not $match.Success) {
        return [PSCustomObject]@{
            Found = $false
            Text = ""
        }
    }

    return [PSCustomObject]@{
        Found = $true
        Text = $match.Groups["front"].Value
    }
}

function Get-NextYamlLineIndex {
    param(
        [Parameter(Mandatory = $true)][string[]]$Lines,
        [Parameter(Mandatory = $true)][int]$StartIndex
    )

    for ($index = $StartIndex; $index -lt $Lines.Count; $index++) {
        if (-not [String]::IsNullOrWhiteSpace($Lines[$index]) -and $Lines[$index].TrimStart() -notmatch "^#") {
            return $index
        }
    }

    return -1
}

function Get-YamlIndent {
    param([Parameter(Mandatory = $true)][string]$Line)

    if ($Line -match "^\t") {
        throw "Tabs are not supported in metadata front matter."
    }

    return ([Regex]::Match($Line, "^ *")).Value.Length
}

function ConvertFrom-YamlScalar {
    param([AllowEmptyString()][string]$Text)

    $value = if ($null -eq $Text) { "" } else { $Text.Trim() }
    if ($value -eq "") {
        return $null
    }

    if ($value.StartsWith('"') -and $value.EndsWith('"') -and $value.Length -ge 2) {
        return $value.Substring(1, $value.Length - 2).Replace('\"', '"').Replace("\\", "\")
    }

    if ($value.StartsWith("'") -and $value.EndsWith("'") -and $value.Length -ge 2) {
        return $value.Substring(1, $value.Length - 2).Replace("''", "'")
    }

    if ($value -match "^\s*(?<value>.*?)(?<!\\)\s+#") {
        $value = $Matches["value"].Trim()
    }

    if ($value -match "^(?i:true|false)$") {
        return [Boolean]::Parse($value)
    }

    if ($value -match "^-?\d+$") {
        return [Int64]::Parse($value, [Globalization.CultureInfo]::InvariantCulture)
    }

    if ($value -ieq "null" -or $value -eq "~") {
        return $null
    }

    return $value
}

function ConvertFrom-YamlBlock {
    param(
        [Parameter(Mandatory = $true)][string[]]$Lines,
        [Parameter(Mandatory = $true)][ref]$Index,
        [Parameter(Mandatory = $true)][int]$Indent
    )

    $nextIndex = Get-NextYamlLineIndex -Lines $Lines -StartIndex $Index.Value
    if ($nextIndex -lt 0) {
        $Index.Value = $Lines.Count
        return $null
    }

    $nextIndent = Get-YamlIndent $Lines[$nextIndex]
    if ($nextIndent -ne $Indent) {
        throw "Unexpected metadata indentation on line $($nextIndex + 1)."
    }

    if ($Lines[$nextIndex].TrimStart().StartsWith("-")) {
        $items = New-Object "System.Collections.Generic.List[object]"
        $Index.Value = $nextIndex

        while ($true) {
            $currentIndex = Get-NextYamlLineIndex -Lines $Lines -StartIndex $Index.Value
            if ($currentIndex -lt 0) {
                $Index.Value = $Lines.Count
                break
            }

            $currentIndent = Get-YamlIndent $Lines[$currentIndex]
            if ($currentIndent -lt $Indent) {
                $Index.Value = $currentIndex
                break
            }
            if ($currentIndent -gt $Indent) {
                throw "Unexpected metadata indentation on line $($currentIndex + 1)."
            }

            $sequenceMatch = [Regex]::Match($Lines[$currentIndex], "^(?<indent> *)-(?:[ \t]*(?<value>.*))?$")
            if (-not $sequenceMatch.Success) {
                throw "Expected a metadata list item on line $($currentIndex + 1)."
            }

            $itemText = $sequenceMatch.Groups["value"].Value
            $Index.Value = $currentIndex + 1
            if ([String]::IsNullOrWhiteSpace($itemText)) {
                $childIndex = Get-NextYamlLineIndex -Lines $Lines -StartIndex $Index.Value
                if ($childIndex -lt 0 -or (Get-YamlIndent $Lines[$childIndex]) -le $Indent) {
                    throw "Metadata list item on line $($currentIndex + 1) has no value."
                }

                $Index.Value = $childIndex
                $items.Add((ConvertFrom-YamlBlock -Lines $Lines -Index $Index -Indent (Get-YamlIndent $Lines[$childIndex]))) | Out-Null
            }
            else {
                $items.Add((ConvertFrom-YamlScalar $itemText)) | Out-Null
            }
        }

        return ,$items.ToArray()
    }

    $map = New-Object "System.Collections.Specialized.OrderedDictionary"
    $Index.Value = $nextIndex

    while ($true) {
        $currentIndex = Get-NextYamlLineIndex -Lines $Lines -StartIndex $Index.Value
        if ($currentIndex -lt 0) {
            $Index.Value = $Lines.Count
            break
        }

        $currentIndent = Get-YamlIndent $Lines[$currentIndex]
        if ($currentIndent -lt $Indent) {
            $Index.Value = $currentIndex
            break
        }
        if ($currentIndent -gt $Indent) {
            throw "Unexpected metadata indentation on line $($currentIndex + 1)."
        }

        $mappingMatch = [Regex]::Match($Lines[$currentIndex], "^(?<indent> *)(?<key>[A-Za-z_][A-Za-z0-9_-]*):(?:[ \t]*(?<value>.*))?$")
        if (-not $mappingMatch.Success) {
            throw "Expected a metadata key on line $($currentIndex + 1)."
        }

        $key = $mappingMatch.Groups["key"].Value
        if ($map.Contains($key)) {
            throw "Duplicate metadata key '$key' on line $($currentIndex + 1)."
        }

        $valueText = $mappingMatch.Groups["value"].Value
        $Index.Value = $currentIndex + 1
        if (-not [String]::IsNullOrWhiteSpace($valueText)) {
            $map.Add($key, (ConvertFrom-YamlScalar $valueText))
            continue
        }

        $childIndex = Get-NextYamlLineIndex -Lines $Lines -StartIndex $Index.Value
        if ($childIndex -lt 0 -or (Get-YamlIndent $Lines[$childIndex]) -le $Indent) {
            $map.Add($key, $null)
            continue
        }

        $Index.Value = $childIndex
        $map.Add($key, (ConvertFrom-YamlBlock -Lines $Lines -Index $Index -Indent (Get-YamlIndent $Lines[$childIndex])))
    }

    return $map
}

function ConvertFrom-MetadataFrontMatter {
    param([Parameter(Mandatory = $true)][string]$FrontMatter)

    $lines = (Normalize-Text $FrontMatter) -split "`n"
    $index = 0
    $metadata = ConvertFrom-YamlBlock -Lines $lines -Index ([ref]$index) -Indent 0
    if ($metadata -isnot [Collections.IDictionary]) {
        throw "Metadata front matter must be a YAML object."
    }

    return $metadata
}

function Get-ObjectProperty {
    param(
        [Parameter(Mandatory = $true)]$Object,
        [Parameter(Mandatory = $true)][string]$Name,
        [Parameter(Mandatory = $true)][ref]$Found
    )

    [void]($Found.Value = $false)
    if ($null -eq $Object) {
        return $null
    }

    if ($Object -is [Collections.IDictionary]) {
        if ($Object.Contains($Name)) {
            [void]($Found.Value = $true)
            return ,$Object[$Name]
        }
        return $null
    }

    $property = $Object.PSObject.Properties[$Name]
    if ($null -ne $property) {
        [void]($Found.Value = $true)
        return ,$property.Value
    }

    return $null
}

function Test-DeepEqual {
    param($Left, $Right)

    if ($null -eq $Left -or $null -eq $Right) {
        return $null -eq $Left -and $null -eq $Right
    }

    if ($Left -is [Array] -or $Right -is [Array]) {
        if ($Left -isnot [Array] -or $Right -isnot [Array] -or $Left.Count -ne $Right.Count) {
            return $false
        }
        for ($index = 0; $index -lt $Left.Count; $index++) {
            if (-not (Test-DeepEqual $Left[$index] $Right[$index])) {
                return $false
            }
        }
        return $true
    }

    if ($Left -is [Collections.IDictionary] -or $Right -is [Collections.IDictionary]) {
        if ($Left -isnot [Collections.IDictionary] -or $Right -isnot [Collections.IDictionary] -or $Left.Count -ne $Right.Count) {
            return $false
        }
        foreach ($key in $Left.Keys) {
            if (-not $Right.Contains($key) -or -not (Test-DeepEqual $Left[$key] $Right[$key])) {
                return $false
            }
        }
        return $true
    }

    return $Left.GetType() -eq $Right.GetType() -and $Left -eq $Right
}

function Test-SchemaType {
    param($Value, [string]$Type)

    switch ($Type) {
        "object" { return $Value -is [Collections.IDictionary] }
        "array" { return $Value -is [Array] }
        "string" { return $Value -is [string] }
        "integer" {
            return $Value -is [sbyte] -or $Value -is [byte] -or $Value -is [int16] -or
                $Value -is [uint16] -or $Value -is [int32] -or $Value -is [uint32] -or
                $Value -is [int64] -or $Value -is [uint64]
        }
        "number" {
            return (Test-SchemaType $Value "integer") -or $Value -is [single] -or
                $Value -is [double] -or $Value -is [decimal]
        }
        "boolean" { return $Value -is [bool] }
        default { throw "Unsupported JSON Schema type '$Type'." }
    }
}

function Test-SchemaNode {
    param(
        $Value,
        [Parameter(Mandatory = $true)]$Schema,
        [Parameter(Mandatory = $true)][string]$Location
    )

    $errors = @()
    $found = $false
    $schemaType = Get-ObjectProperty -Object $Schema -Name "type" -Found ([ref]$found)
    if ($found -and -not (Test-SchemaType $Value ([string]$schemaType))) {
        $errors += "$Location must be of type '$schemaType'."
        return $errors
    }

    $constValue = Get-ObjectProperty -Object $Schema -Name "const" -Found ([ref]$found)
    if ($found -and -not (Test-DeepEqual $Value $constValue)) {
        $errors += "$Location must equal '$constValue'."
    }

    $enumValues = Get-ObjectProperty -Object $Schema -Name "enum" -Found ([ref]$found)
    if ($found) {
        $enumMatch = $false
        foreach ($enumValue in @($enumValues)) {
            if (Test-DeepEqual $Value $enumValue) {
                $enumMatch = $true
                break
            }
        }
        if (-not $enumMatch) {
            $errors += "$Location contains a value outside the schema enum."
        }
    }

    $notFound = $false
    $notSchema = Get-ObjectProperty -Object $Schema -Name "not" -Found ([ref]$notFound)
    if ($notFound -and @(Test-SchemaNode -Value $Value -Schema $notSchema -Location $Location).Count -eq 0) {
        $errors += "$Location matches a schema branch that is explicitly disallowed."
    }

    $required = Get-ObjectProperty -Object $Schema -Name "required" -Found ([ref]$found)
    if ($found) {
        foreach ($requiredName in @($required)) {
            $propertyFound = $false
            [void](Get-ObjectProperty -Object $Value -Name ([string]$requiredName) -Found ([ref]$propertyFound))
            if (-not $propertyFound) {
                $errors += "$Location is missing required property '$requiredName'."
            }
        }
    }

    $additionalProperties = Get-ObjectProperty -Object $Schema -Name "additionalProperties" -Found ([ref]$found)
    if ($found -and $additionalProperties -eq $false -and $Value -is [Collections.IDictionary]) {
        $schemaPropertiesFound = $false
        $schemaProperties = Get-ObjectProperty -Object $Schema -Name "properties" -Found ([ref]$schemaPropertiesFound)
        $allowedNames = @()
        if ($schemaPropertiesFound) {
            $allowedNames = @($schemaProperties.PSObject.Properties | ForEach-Object { $_.Name })
        }
        foreach ($propertyName in $Value.Keys) {
            if ($propertyName -notin $allowedNames) {
                $errors += "$Location contains undocumented property '$propertyName'."
            }
        }
    }

    $propertiesFound = $false
    $properties = Get-ObjectProperty -Object $Schema -Name "properties" -Found ([ref]$propertiesFound)
    if ($propertiesFound -and $Value -is [Collections.IDictionary]) {
        foreach ($property in $properties.PSObject.Properties) {
            $propertyFound = $false
            $propertyValue = Get-ObjectProperty -Object $Value -Name $property.Name -Found ([ref]$propertyFound)
            if ($propertyFound) {
                $errors += @(Test-SchemaNode -Value $propertyValue -Schema $property.Value -Location "$Location.$($property.Name)")
            }
        }
    }

    $minLength = Get-ObjectProperty -Object $Schema -Name "minLength" -Found ([ref]$found)
    if ($found -and $Value -is [string] -and $Value.Length -lt [int]$minLength) {
        $errors += "$Location must contain at least $minLength characters."
    }

    $maxLength = Get-ObjectProperty -Object $Schema -Name "maxLength" -Found ([ref]$found)
    if ($found -and $Value -is [string] -and $Value.Length -gt [int]$maxLength) {
        $errors += "$Location must contain at most $maxLength characters."
    }

    $pattern = Get-ObjectProperty -Object $Schema -Name "pattern" -Found ([ref]$found)
    if ($found -and $Value -is [string] -and $Value -notmatch $pattern) {
        $errors += "$Location does not match the schema pattern."
    }

    $format = Get-ObjectProperty -Object $Schema -Name "format" -Found ([ref]$found)
    if ($found -and $format -eq "date" -and $Value -is [string]) {
        $parsedDate = [DateTime]::MinValue
        if (-not [DateTime]::TryParseExact(
                $Value,
                "yyyy-MM-dd",
                [Globalization.CultureInfo]::InvariantCulture,
                [Globalization.DateTimeStyles]::None,
                [ref]$parsedDate
            )) {
            $errors += "$Location must be a valid ISO 8601 date."
        }
    }

    $minItems = Get-ObjectProperty -Object $Schema -Name "minItems" -Found ([ref]$found)
    if ($found -and $Value -is [Array] -and $Value.Count -lt [int]$minItems) {
        $errors += "$Location must contain at least $minItems item(s)."
    }

    $uniqueItems = Get-ObjectProperty -Object $Schema -Name "uniqueItems" -Found ([ref]$found)
    if ($found -and $uniqueItems -eq $true -and $Value -is [Array]) {
        for ($left = 0; $left -lt $Value.Count; $left++) {
            for ($right = $left + 1; $right -lt $Value.Count; $right++) {
                if (Test-DeepEqual $Value[$left] $Value[$right]) {
                    $errors += "$Location must contain unique items."
                }
            }
        }
    }

    $itemsFound = $false
    $itemsSchema = Get-ObjectProperty -Object $Schema -Name "items" -Found ([ref]$itemsFound)
    if ($itemsFound -and $Value -is [Array]) {
        for ($index = 0; $index -lt $Value.Count; $index++) {
            $errors += @(Test-SchemaNode -Value $Value[$index] -Schema $itemsSchema -Location "$Location[$index]")
        }
    }

    $oneOfFound = $false
    $oneOf = Get-ObjectProperty -Object $Schema -Name "oneOf" -Found ([ref]$oneOfFound)
    if ($oneOfFound) {
        $matchingBranches = 0
        foreach ($branch in @($oneOf)) {
            if (@(Test-SchemaNode -Value $Value -Schema $branch -Location $Location).Count -eq 0) {
                $matchingBranches++
            }
        }
        if ($matchingBranches -ne 1) {
            $errors += "$Location must match exactly one schema branch, but matched $matchingBranches."
        }
    }

    $allOfFound = $false
    $allOf = Get-ObjectProperty -Object $Schema -Name "allOf" -Found ([ref]$allOfFound)
    if ($allOfFound) {
        foreach ($branch in @($allOf)) {
            $errors += @(Test-SchemaNode -Value $Value -Schema $branch -Location $Location)
        }
    }

    $ifFound = $false
    $ifSchema = Get-ObjectProperty -Object $Schema -Name "if" -Found ([ref]$ifFound)
    if ($ifFound) {
        $thenFound = $false
        $thenSchema = Get-ObjectProperty -Object $Schema -Name "then" -Found ([ref]$thenFound)
        if ($thenFound -and @(Test-SchemaNode -Value $Value -Schema $ifSchema -Location $Location).Count -eq 0) {
            $errors += @(Test-SchemaNode -Value $Value -Schema $thenSchema -Location $Location)
        }
    }

    return $errors
}

$script:RepositoryRoot = ConvertTo-FullPath $RepositoryRoot
if (-not (Test-Path -LiteralPath $script:RepositoryRoot -PathType Container)) {
    throw "Repository root '$script:RepositoryRoot' does not exist."
}

if ([String]::IsNullOrWhiteSpace($SchemaPath)) {
    $SchemaPath = Join-Path $script:RepositoryRoot "contributing\metadata\documentation-metadata-v1.schema.json"
}
elseif (-not [IO.Path]::IsPathRooted($SchemaPath)) {
    $SchemaPath = Join-Path $script:RepositoryRoot $SchemaPath
}
$SchemaPath = [IO.Path]::GetFullPath($SchemaPath)
if (-not (Test-Path -LiteralPath $SchemaPath -PathType Leaf)) {
    throw "Metadata schema '$SchemaPath' does not exist."
}

$schema = Get-Content -LiteralPath $SchemaPath -Raw | ConvertFrom-Json
$markdownPaths = @(Get-MarkdownPaths -Root $script:RepositoryRoot -RequestedPaths $Path)
$errors = @()
$validatedCount = 0
$legacyCount = 0

foreach ($markdownPath in $markdownPaths) {
    $relativePath = ConvertTo-RepositoryRelativePath -Path $markdownPath -Root $script:RepositoryRoot
    $frontMatter = Get-FrontMatter -Text ([IO.File]::ReadAllText($markdownPath))
    $hasVersionMarker = $frontMatter.Found -and [Regex]::IsMatch($frontMatter.Text, "(?m)^metadata_version\s*:")

    if (-not $hasVersionMarker) {
        if ($RequireVersion1) {
            $errors += "$relativePath must include metadata_version: 1."
        }
        else {
            $legacyCount++
        }
        continue
    }

    try {
        $metadata = ConvertFrom-MetadataFrontMatter -FrontMatter $frontMatter.Text
        $schemaErrors = @(Test-SchemaNode -Value $metadata -Schema $schema -Location $relativePath)
        foreach ($schemaError in $schemaErrors) {
            $errors += $schemaError
        }
        if ($schemaErrors.Count -eq 0) {
            $validatedCount++
        }
    }
    catch {
        $errors += "${relativePath}: $($_.Exception.Message)"
    }
}

if ($errors.Count -gt 0) {
    throw ("Documentation metadata validation failed with {0} error(s):`n - {1}" -f $errors.Count, ($errors -join "`n - "))
}

Write-Output ("Validated {0} version 1 metadata file(s); skipped {1} legacy page(s)." -f $validatedCount, $legacyCount)
