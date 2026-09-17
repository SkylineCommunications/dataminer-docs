[CmdletBinding()]
param(
    [string]$RepositoryRoot = (Join-Path $PSScriptRoot ".."),
    [string]$Path = (Join-Path $PSScriptRoot "..\_artifacts\html-source-metadata.json")
)

Set-StrictMode -Version 2.0
$ErrorActionPreference = "Stop"

function ConvertTo-FullPath {
    param([Parameter(Mandatory = $true)][string]$Value)

    if ([IO.Path]::IsPathRooted($Value)) {
        return [IO.Path]::GetFullPath($Value)
    }

    return [IO.Path]::GetFullPath((Join-Path (Get-Location).Path $Value))
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

function Assert-RelativePath {
    param(
        [Parameter(Mandatory = $true)][string]$Value,
        [Parameter(Mandatory = $true)][string]$Context
    )

    Assert-Condition (-not [IO.Path]::IsPathRooted($Value)) "$Context contains an absolute path."
    Assert-Condition ($Value -notmatch "\\") "$Context contains a Windows path separator."
    Assert-Condition (-not $Value.StartsWith("../", [StringComparison]::Ordinal)) "$Context escapes the repository root."
    Assert-Condition (-not [String]::IsNullOrWhiteSpace($Value)) "$Context is empty."
}

$repositoryRootFullPath = ConvertTo-FullPath -Value $RepositoryRoot
$metadataPath = ConvertTo-FullPath -Value $Path
Assert-Condition (Test-Path -LiteralPath $metadataPath -PathType Leaf) "HTML source metadata file '$metadataPath' does not exist."

$metadata = Get-Content -LiteralPath $metadataPath -Raw | ConvertFrom-Json
$allowedFields = @("canonicalUrl", "sourceurl", "dateModified", "_sourceDateYear", "_sourceDateMonth", "_sourceDateDay", "sourceCommit", "sourceBlob")
$fieldNames = @($metadata.PSObject.Properties.Name)
foreach ($fieldName in $fieldNames) {
    Assert-Condition ($allowedFields -contains $fieldName) "HTML source metadata contains undocumented field '$fieldName'."
    $field = $metadata.$fieldName
    foreach ($pathProperty in @($field.PSObject.Properties)) {
        $sourcePath = [string]$pathProperty.Name
        Assert-RelativePath -Value $sourcePath -Context "$fieldName.$sourcePath"
        $value = [string]$pathProperty.Value
        Assert-Condition (-not [String]::IsNullOrWhiteSpace($value)) "$fieldName.$sourcePath is empty."

        switch ($fieldName) {
            "canonicalUrl" {
                Assert-Condition ($value -match "^https?://") "$fieldName.$sourcePath is not an absolute URL."
            }
            "sourceurl" {
                Assert-Condition ($value -match "^https://github\.com/SkylineCommunications/dataminer-docs/edit/[^/]+/") "$fieldName.$sourcePath is not a human edit URL."
            }
            "dateModified" {
                Assert-Condition ($value -match "^\d{4}-\d{2}-\d{2}$") "$fieldName.$sourcePath is not an ISO date."
            }
            "_sourceDateYear" {
                Assert-Condition ($value -match "^\d{4}$") "$fieldName.$sourcePath is not a four-digit year."
            }
            "_sourceDateMonth" {
                Assert-Condition ($value -match "^(?:0[1-9]|1[0-2])$") "$fieldName.$sourcePath is not a two-digit month."
            }
            "_sourceDateDay" {
                Assert-Condition ($value -match "^(?:0[1-9]|[12]\d|3[01])$") "$fieldName.$sourcePath is not a two-digit day."
            }
            "sourceCommit" {
                Assert-Condition ($value -match "^[0-9a-f]{40}$") "$fieldName.$sourcePath is not a full commit SHA."
            }
            "sourceBlob" {
                Assert-Condition ($value -match "^https://github\.com/SkylineCommunications/dataminer-docs/blob/[0-9a-f]{40}/") "$fieldName.$sourcePath is not a commit-pinned repository URL."
            }
        }
    }
}

$sourceCommits = @{}
if ($fieldNames -contains "sourceCommit") {
    foreach ($property in @($metadata.sourceCommit.PSObject.Properties)) {
        $sourceCommits[[string]$property.Name] = [string]$property.Value
    }
}
if ($fieldNames -contains "sourceBlob") {
    foreach ($property in @($metadata.sourceBlob.PSObject.Properties)) {
        $sourcePath = [string]$property.Name
        Assert-Condition $sourceCommits.ContainsKey($sourcePath) "sourceBlob.$sourcePath has no matching sourceCommit."
        $commit = $sourceCommits[$sourcePath]
        Assert-Condition ([string]$property.Value -match ("/blob/{0}/" -f $commit)) "sourceBlob.$sourcePath does not use its sourceCommit."
    }
}

Write-Output ("Validated HTML source metadata at {0}." -f $metadataPath)
