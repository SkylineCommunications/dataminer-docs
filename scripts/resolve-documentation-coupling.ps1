[CmdletBinding()]
param(
    [string]$RepositoryRoot = (Join-Path $PSScriptRoot ".."),
    [string]$MapPath = (Join-Path $PSScriptRoot "..\contributing\metadata\documentation-dependency-map-v1.json"),
    [string]$ChangePath = "",
    [string[]]$ChangedPath = @(),
    [string]$BaseRevision = "",
    [string]$HeadRevision = "",
    [string]$OutputPath = (Join-Path $PSScriptRoot "..\_artifacts\documentation-coupling.json"),
    [switch]$FailOnGate,
    [switch]$FailOnUnmapped
)

Set-StrictMode -Version 2.0
$ErrorActionPreference = "Stop"

Import-Module (Join-Path $PSScriptRoot "DocumentationDependencyMap.psm1") -Force

$root = [IO.Path]::GetFullPath($RepositoryRoot)
$mapFullPath = if ([IO.Path]::IsPathRooted($MapPath)) { [IO.Path]::GetFullPath($MapPath) } else { [IO.Path]::GetFullPath((Join-Path $root $MapPath)) }
Assert-Condition (Test-Path -LiteralPath $root -PathType Container) "Repository root '$root' does not exist."
$map = Read-JsonDocument -Path $mapFullPath
Assert-MapContract -Map $map -RepositoryRoot $root | Out-Null

$change = $null
if (-not [String]::IsNullOrWhiteSpace($ChangePath)) {
    $changeFullPath = if ([IO.Path]::IsPathRooted($ChangePath)) { [IO.Path]::GetFullPath($ChangePath) } else { [IO.Path]::GetFullPath((Join-Path $root $ChangePath)) }
    $change = Read-JsonDocument -Path $changeFullPath
    Assert-ChangeContract -Change $change
}

$paths = @(Get-StringArray $ChangedPath)
if ($paths.Count -eq 0 -and $null -eq $change) {
    $paths = @(Get-ChangedPathsFromGit -Root $root -BaseRevision $BaseRevision -HeadRevision $HeadRevision)
}

$report = Resolve-CouplingReport -Map $map -Change $change -RepositoryRoot $root -ChangedPaths $paths
$outputFullPath = if ([IO.Path]::IsPathRooted($OutputPath)) { [IO.Path]::GetFullPath($OutputPath) } else { [IO.Path]::GetFullPath((Join-Path $root $OutputPath)) }
Write-JsonDocument -Path $outputFullPath -Value $report

Write-Output "Documentation coupling: $($report.summary.matchedEntries) matched map entries, $($report.summary.targetedChecks) targeted checks, gate $($report.summary.gateStatus), $($report.summary.gaps) gap(s)."

if ($FailOnUnmapped -and [int]$report.summary.matchedEntries -eq 0 -and $null -ne $change) {
    throw "Documentation coupling resolution failed: the product change did not match a dependency-map entry."
}
if ($FailOnGate -and [string]$report.documentationReleaseGate.status -ne "pass" -and $null -ne $change) {
    throw "Documentation coupling release gate is $($report.documentationReleaseGate.status), not pass."
}
