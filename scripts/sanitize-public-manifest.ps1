[CmdletBinding()]
param(
    [string]$Path = (Join-Path $PSScriptRoot "..\_site\manifest.json"),
    [string]$OutputPath = ""
)

Set-StrictMode -Version 2.0
$ErrorActionPreference = "Stop"

$script:PrivatePropertyPattern = "(?i)^(?:source[_-]?base[_-]?path|runner(?:[_-].*)?|github[_-](?:workspace|runner|run[_-]?id|run[_-]?number|ref|sha)|build[_-]?(?:machine|path))$"
$script:AbsolutePathPattern = "(?i)(?:(?<![A-Za-z0-9])[A-Z]:[\\/]|\\\\\\\\|/(?:home|users|runner|workspace|_work)/|\\(?:Users|runner|workspace|_work)\\)"

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

function Get-ObjectProperties {
    param([Parameter(Mandatory = $true)]$Value)

    if ($Value -is [System.Collections.IDictionary]) {
        return @(
            foreach ($key in $Value.Keys) {
                [PSCustomObject]@{
                    Name = [string]$key
                    Value = $Value[$key]
                }
            }
        )
    }

    return @(
        foreach ($property in $Value.PSObject.Properties) {
            [PSCustomObject]@{
                Name = [string]$property.Name
                Value = $property.Value
            }
        }
    )
}

function Get-PropertyValue {
    param(
        [Parameter(Mandatory = $true)]$Object,
        [Parameter(Mandatory = $true)][string]$Name
    )

    foreach ($property in @(Get-ObjectProperties -Value $Object)) {
        if ([string]::Equals($property.Name, $Name, [StringComparison]::OrdinalIgnoreCase)) {
            return $property.Value
        }
    }

    return $null
}

function Test-PrivatePropertyName {
    param([Parameter(Mandatory = $true)][string]$Name)

    return $Name -match $script:PrivatePropertyPattern
}

function ConvertTo-PublicValue {
    param([AllowNull()]$Value)

    if ($null -eq $Value) {
        return $null
    }

    if ($Value -is [string] -or
        $Value -is [ValueType]) {
        return $Value
    }

    if ($Value -is [System.Collections.IEnumerable] -and
        $Value -isnot [System.Collections.IDictionary]) {
        return @($Value | ForEach-Object { ConvertTo-PublicValue -Value $_ })
    }

    $result = [ordered]@{}
    foreach ($property in @(Get-ObjectProperties -Value $Value)) {
        if (Test-PrivatePropertyName -Name $property.Name) {
            continue
        }

        if ([string]::Equals($property.Name, "version", [StringComparison]::OrdinalIgnoreCase) -and
            $property.Value -is [string] -and
            [string]::IsNullOrWhiteSpace([string]$property.Value)) {
            continue
        }

        $result[$property.Name] = ConvertTo-PublicValue -Value $property.Value
    }

    return [PSCustomObject]$result
}

function Assert-PublicValue {
    param(
        [AllowNull()]$Value,
        [Parameter(Mandatory = $true)][string]$Context
    )

    if ($null -eq $Value) {
        return
    }

    if ($Value -is [string]) {
        Assert-Condition ($Value -notmatch $script:AbsolutePathPattern) "$Context contains an absolute or build-machine path."
        return
    }

    if ($Value -is [System.Collections.IEnumerable] -and
        $Value -isnot [System.Collections.IDictionary]) {
        $index = 0
        foreach ($item in $Value) {
            Assert-PublicValue -Value $item -Context "$Context[$index]"
            $index++
        }
        return
    }

    foreach ($property in @(Get-ObjectProperties -Value $Value)) {
        Assert-Condition (-not (Test-PrivatePropertyName -Name $property.Name)) "$Context contains private property '$($property.Name)'."
        if ([string]::Equals($property.Name, "version", [StringComparison]::OrdinalIgnoreCase)) {
            Assert-Condition (-not ($property.Value -is [string] -and [string]::IsNullOrWhiteSpace([string]$property.Value))) "$Context contains an empty version."
        }
        Assert-PublicValue -Value $property.Value -Context "$Context.$($property.Name)"
    }
}

function Write-JsonAtomically {
    param(
        [Parameter(Mandatory = $true)][string]$Path,
        [Parameter(Mandatory = $true)]$Value
    )

    $directory = Split-Path -Parent $Path
    if (-not (Test-Path -LiteralPath $directory -PathType Container)) {
        New-Item -ItemType Directory -Path $directory -Force | Out-Null
    }

    $json = $Value | ConvertTo-Json -Depth 100
    $utf8NoBom = New-Object Text.UTF8Encoding($false)
    $temporaryPath = "$Path.$([Guid]::NewGuid().ToString('N')).tmp"
    try {
        [IO.File]::WriteAllText($temporaryPath, $json + [Environment]::NewLine, $utf8NoBom)
        Move-Item -LiteralPath $temporaryPath -Destination $Path -Force
    }
    finally {
        if (Test-Path -LiteralPath $temporaryPath -PathType Leaf) {
            Remove-Item -LiteralPath $temporaryPath -Force
        }
    }
}

$manifestPath = ConvertTo-FullPath -Value $Path
$outputPath = if ([string]::IsNullOrWhiteSpace($OutputPath)) {
    $manifestPath
}
else {
    ConvertTo-FullPath -Value $OutputPath
}

Assert-Condition (Test-Path -LiteralPath $manifestPath -PathType Leaf) "Public manifest '$manifestPath' does not exist."

try {
    $manifestJson = [IO.File]::ReadAllText($manifestPath)
    $manifest = $manifestJson | ConvertFrom-Json
}
catch {
    throw "Public manifest '$manifestPath' is not valid JSON."
}

$files = Get-PropertyValue -Object $manifest -Name "files"
Assert-Condition ($null -ne $files) "Public manifest '$manifestPath' does not contain a files collection."

$publicManifest = ConvertTo-PublicValue -Value $manifest
Assert-PublicValue -Value $publicManifest -Context "manifest"
Write-JsonAtomically -Path $outputPath -Value $publicManifest

Write-Output "Sanitized public manifest: $outputPath."
