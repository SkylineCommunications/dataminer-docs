[CmdletBinding()]
param(
    [string]$RepositoryRoot = (Join-Path $PSScriptRoot ".."),
    [string]$ConfigurationPath = (Join-Path $PSScriptRoot "..\contributing\xml-documentation-examples-v1.json"),
    [string]$OutputRoot = (Join-Path $PSScriptRoot "..\_artifacts\xml-schemas")
)

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

function Get-StringProperty {
    param(
        [Parameter(Mandatory = $true)]$Object,
        [Parameter(Mandatory = $true)][string]$Name
    )

    if ($Object -is [System.Collections.IDictionary]) {
        if (-not $Object.Contains($Name)) {
            return ""
        }
        return [string]$Object[$Name]
    }

    if (@($Object.PSObject.Properties.Name) -contains $Name) {
        return [string]$Object.$Name
    }

    return ""
}

function Get-ObjectProperty {
    param(
        [Parameter(Mandatory = $true)]$Object,
        [Parameter(Mandatory = $true)][string]$Name
    )

    if ($Object -is [System.Collections.IDictionary]) {
        if (-not $Object.Contains($Name)) {
            return $null
        }
        return $Object[$Name]
    }

    if (@($Object.PSObject.Properties.Name) -contains $Name) {
        return $Object.$Name
    }

    return $null
}

function Get-Array {
    param($Value)

    if ($null -eq $Value) {
        return @()
    }

    return @($Value)
}

$repositoryRoot = [IO.Path]::GetFullPath($RepositoryRoot)
$configurationPath = if ([IO.Path]::IsPathRooted($ConfigurationPath)) {
    [IO.Path]::GetFullPath($ConfigurationPath)
}
else {
    [IO.Path]::GetFullPath((Join-Path $repositoryRoot $ConfigurationPath))
}
$outputRootPath = if ([IO.Path]::IsPathRooted($OutputRoot)) {
    [IO.Path]::GetFullPath($OutputRoot)
}
else {
    [IO.Path]::GetFullPath((Join-Path $repositoryRoot $OutputRoot))
}

Assert-Condition (Test-Path -LiteralPath $configurationPath -PathType Leaf) "XML documentation example configuration '$configurationPath' does not exist."
$configuration = Get-Content -LiteralPath $configurationPath -Raw | ConvertFrom-Json
Assert-Condition ((Get-StringProperty -Object $configuration -Name "format") -eq "xml-documentation-examples") "The XML documentation example configuration has an unsupported format."

foreach ($schema in (Get-Array (Get-ObjectProperty -Object $configuration -Name "schemas"))) {
    $source = Get-ObjectProperty -Object $schema -Name "source"
    $commit = Get-StringProperty -Object $source -Name "commit"
    Assert-Condition ($commit -match "^[0-9a-f]{40}$") "Schema '$(Get-StringProperty -Object $schema -Name 'id')' does not pin a source commit."
    foreach ($file in (Get-Array (Get-ObjectProperty -Object $source -Name "files"))) {
        $relativePath = Get-StringProperty -Object $file -Name "path"
        $url = Get-StringProperty -Object $file -Name "url"
        $expectedHash = (Get-StringProperty -Object $file -Name "sha256").ToLowerInvariant()
        Assert-Condition ($relativePath -match "^[A-Za-z0-9._/-]+$") "Schema source path '$relativePath' is not portable."
        Assert-Condition ($url -match "^https://raw\.githubusercontent\.com/SkylineCommunications/Skyline\.DataMiner\.XmlSchemas/$commit/.+$") "Schema source URL '$url' is not pinned to its declared commit."
        Assert-Condition ($expectedHash -match "^[0-9a-f]{64}$") "Schema source '$relativePath' does not have a SHA-256 pin."

        $targetPath = [IO.Path]::GetFullPath((Join-Path $outputRootPath ($relativePath.Replace("/", "\"))))
        $targetDirectory = Split-Path -Parent $targetPath
        if (-not (Test-Path -LiteralPath $targetDirectory -PathType Container)) {
            New-Item -ItemType Directory -Path $targetDirectory -Force | Out-Null
        }

        $download = $true
        if (Test-Path -LiteralPath $targetPath -PathType Leaf) {
            $download = (Get-FileHash -LiteralPath $targetPath -Algorithm SHA256).Hash.ToLowerInvariant() -ne $expectedHash
        }
        if ($download) {
            Invoke-WebRequest -Uri $url -OutFile $targetPath -UseBasicParsing
        }

        $actualHash = (Get-FileHash -LiteralPath $targetPath -Algorithm SHA256).Hash.ToLowerInvariant()
        Assert-Condition ($actualHash -eq $expectedHash) "Downloaded schema '$relativePath' has SHA-256 '$actualHash', expected '$expectedHash'."
        Write-Output "Pinned XML schema ready: $relativePath"
    }
}
