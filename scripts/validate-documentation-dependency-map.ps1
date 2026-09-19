[CmdletBinding()]
param(
    [string]$RepositoryRoot = (Join-Path $PSScriptRoot ".."),
    [string]$MapPath = (Join-Path $PSScriptRoot "..\contributing\metadata\documentation-dependency-map-v1.json"),
    [string]$SchemaPath = (Join-Path $PSScriptRoot "..\contributing\metadata\documentation-dependency-map-v1.schema.json"),
    [string]$ChangePath = "",
    [string]$ReportPath = ""
)

Set-StrictMode -Version 2.0
$ErrorActionPreference = "Stop"

Import-Module (Join-Path $PSScriptRoot "DocumentationDependencyMap.psm1") -Force

$root = [IO.Path]::GetFullPath($RepositoryRoot)
$mapFullPath = if ([IO.Path]::IsPathRooted($MapPath)) { [IO.Path]::GetFullPath($MapPath) } else { [IO.Path]::GetFullPath((Join-Path $root $MapPath)) }
$schemaFullPath = if ([IO.Path]::IsPathRooted($SchemaPath)) { [IO.Path]::GetFullPath($SchemaPath) } else { [IO.Path]::GetFullPath((Join-Path $root $SchemaPath)) }
Assert-Condition (Test-Path -LiteralPath $root -PathType Container) "Repository root '$root' does not exist."
Assert-Condition (Test-Path -LiteralPath $schemaFullPath -PathType Leaf) "Dependency map schema '$schemaFullPath' does not exist."
$schema = Read-JsonDocument -Path $schemaFullPath
Assert-Condition ([string]$schema.title -eq "DataMiner product-to-documentation dependency map") "Unexpected dependency map schema."
$map = Read-JsonDocument -Path $mapFullPath
$counts = Assert-MapContract -Map $map -RepositoryRoot $root

$change = $null
if (-not [String]::IsNullOrWhiteSpace($ChangePath)) {
    $changeFullPath = if ([IO.Path]::IsPathRooted($ChangePath)) { [IO.Path]::GetFullPath($ChangePath) } else { [IO.Path]::GetFullPath((Join-Path $root $ChangePath)) }
    $change = Read-JsonDocument -Path $changeFullPath
    Assert-ChangeContract -Change $change
}

$report = [ordered]@{
    schemaVersion = 1
    policy = "D6.2"
    mapPath = (ConvertTo-RepositoryRelativePath -Path $mapFullPath -Root $root)
    changePath = if ($null -ne $change) { ConvertTo-RepositoryRelativePath -Path $changeFullPath -Root $root } else { $null }
    summary = $counts
    crossRepositoryTrigger = [ordered]@{
        status = [string]$map.crossRepositoryTrigger.status
        permission = [string]$map.crossRepositoryTrigger.permission
        followUp = [string]$map.crossRepositoryTrigger.followUp
    }
    unresolved = @(
        $map.followUps |
            Where-Object { [string]$_.status -ne "complete" } |
            ForEach-Object {
                [ordered]@{
                    id = [string]$_.id
                    status = [string]$_.status
                    action = [string]$_.action
                    owner = [string]$_.owner
                }
            }
    )
}

if (-not [String]::IsNullOrWhiteSpace($ReportPath)) {
    $reportFullPath = if ([IO.Path]::IsPathRooted($ReportPath)) { [IO.Path]::GetFullPath($ReportPath) } else { [IO.Path]::GetFullPath((Join-Path $root $ReportPath)) }
    Write-JsonDocument -Path $reportFullPath -Value $report
}

Write-Output "Documentation dependency map: $($counts.entries) entries, $($counts.checks) checks, $($counts.gates) gate(s), $($counts.targetUids) target UIDs."
