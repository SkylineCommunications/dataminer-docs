[CmdletBinding()]
param(
    [string]$RepositoryRoot = (Join-Path $PSScriptRoot ".."),
    [string]$PolicyPath = (Join-Path (Join-Path $PSScriptRoot "..") "contributing\metadata\documentation-governance-v1.json"),
    [string[]]$Path,
    [datetime]$AsOfDate = (Get-Date).Date,
    [string]$ReportPath,
    [switch]$RequireVersion1,
    [switch]$FailOnOwnerGap
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

function ConvertTo-RepositoryRelativePath {
    param(
        [Parameter(Mandatory = $true)][string]$Value,
        [Parameter(Mandatory = $true)][string]$Root
    )

    $fullPath = [IO.Path]::GetFullPath($Value)
    $prefix = $Root.TrimEnd("\") + "\"
    if (-not $fullPath.StartsWith($prefix, [StringComparison]::OrdinalIgnoreCase)) {
        throw "Path '$Value' is outside the repository root '$Root'."
    }

    return $fullPath.Substring($prefix.Length).Replace("\", "/")
}

function Get-MarkdownPaths {
    param(
        [Parameter(Mandatory = $true)][string]$Root,
        [string[]]$RequestedPaths
    )

    if ($null -ne $RequestedPaths -and $RequestedPaths.Count -gt 0) {
        $paths = New-Object "System.Collections.Generic.List[string]"
        foreach ($requestedPath in $RequestedPaths) {
            $candidate = if ([IO.Path]::IsPathRooted($requestedPath)) {
                [IO.Path]::GetFullPath($requestedPath)
            }
            else {
                [IO.Path]::GetFullPath((Join-Path $Root $requestedPath))
            }

            if (-not (Test-Path -LiteralPath $candidate -PathType Leaf)) {
                throw "Governance path '$requestedPath' does not exist."
            }
            if ([IO.Path]::GetExtension($candidate) -ine ".md") {
                throw "Governance path '$requestedPath' is not a Markdown file."
            }

            $paths.Add($candidate) | Out-Null
        }

        return @($paths | Sort-Object -Unique)
    }

    $paths = New-Object "System.Collections.Generic.List[string]"
    foreach ($file in Get-ChildItem -LiteralPath $Root -File -Filter "*.md") {
        $paths.Add($file.FullName) | Out-Null
    }

    foreach ($directoryName in @("contributing", "dataminer", "develop", "release-notes", "solutions", "tutorials")) {
        $directoryPath = Join-Path $Root $directoryName
        if (-not (Test-Path -LiteralPath $directoryPath -PathType Container)) {
            continue
        }

        foreach ($file in Get-ChildItem -LiteralPath $directoryPath -Recurse -File -Filter "*.md") {
            $paths.Add($file.FullName) | Out-Null
        }
    }

    return @($paths | Sort-Object -Unique)
}

function Get-FrontMatter {
    param([Parameter(Mandatory = $true)][string]$Text)

    $normalized = [Regex]::Replace($Text, "`r`n?", "`n")
    $lines = @($normalized -split "`n")
    if ($lines.Count -lt 3 -or $lines[0].Trim() -ne "---") {
        return $null
    }

    for ($index = 1; $index -lt $lines.Count; $index++) {
        if ($lines[$index].Trim() -eq "---") {
            if ($index -eq 1) {
                return ""
            }

            return ($lines[1..($index - 1)] -join "`n")
        }
    }

    return $null
}

function Get-FrontMatterValues {
    param([AllowEmptyString()][string]$Text)

    $values = @{}
    if ($null -eq $Text) {
        return $values
    }

    foreach ($line in @($Text -split "`n")) {
        if ([String]::IsNullOrWhiteSpace($line) -or $line.TrimStart().StartsWith("#")) {
            continue
        }

        $match = [Regex]::Match($line, "^(?<indent> *)?(?<key>[A-Za-z_][A-Za-z0-9_-]*):(?:[ \t]*(?<value>.*))?$")
        if (-not $match.Success -or $match.Groups["indent"].Value.Length -ne 0) {
            continue
        }

        $value = $match.Groups["value"].Value.Trim()
        if (($value.StartsWith('"') -and $value.EndsWith('"')) -or ($value.StartsWith("'") -and $value.EndsWith("'"))) {
            if ($value.Length -ge 2) {
                $value = $value.Substring(1, $value.Length - 2)
            }
        }

        $values[$match.Groups["key"].Value] = $value
    }

    return $values
}

function Get-Policy {
    param([Parameter(Mandatory = $true)][string]$Path)

    if (-not (Test-Path -LiteralPath $Path -PathType Leaf)) {
        throw "Governance policy '$Path' does not exist."
    }

    try {
        return Get-Content -LiteralPath $Path -Raw | ConvertFrom-Json
    }
    catch {
        throw "Governance policy '$Path' is not valid JSON. $($_.Exception.Message)"
    }
}

function Assert-Policy {
    param([Parameter(Mandatory = $true)]$Policy)

    if ($Policy.schemaVersion -ne 1) {
        throw "Governance policy schemaVersion must be 1."
    }
    if ($Policy.policy -ne "D6.1") {
        throw "Governance policy must identify D6.1."
    }
    if ($Policy.accountableOwner -ne "Docs Writing Team") {
        throw "Governance policy accountableOwner must be Docs Writing Team."
    }
    if ($Policy.accountableOwnerHandle -notin @("unknown", "not_applicable")) {
        throw "Governance policy must keep the unconfirmed accountable owner handle as unknown or not_applicable."
    }

    $requiredExpectationFields = @("metadata_version", "authority", "content_type", "owner")
    foreach ($requiredField in $requiredExpectationFields) {
        if (@($Policy.metadataExpectations.requiredFields) -notcontains $requiredField) {
            throw "Governance policy metadataExpectations.requiredFields is missing '$requiredField'."
        }
    }

    $profileIds = @{}
    foreach ($profile in @($Policy.cadenceProfiles)) {
        if ([String]::IsNullOrWhiteSpace([string]$profile.id) -or $profileIds.ContainsKey([string]$profile.id)) {
            throw "Governance policy cadence profile IDs must be unique and non-empty."
        }
        if ([int]$profile.reviewEveryDays -lt 1 -or [int]$profile.staleAfterDays -lt [int]$profile.reviewEveryDays) {
            throw "Governance policy cadence profile '$($profile.id)' has invalid review or stale thresholds."
        }
        $profileIds[[string]$profile.id] = $true
    }

    $workstreamIds = @{}
    foreach ($workstream in @($Policy.workstreams)) {
        if ([String]::IsNullOrWhiteSpace([string]$workstream.id) -or $workstreamIds.ContainsKey([string]$workstream.id)) {
            throw "Governance policy workstream IDs must be unique and non-empty."
        }
        foreach ($pattern in @($workstream.pathPatterns)) {
            try {
                [Regex]::new([string]$pattern) | Out-Null
            }
            catch {
                throw "Governance policy workstream '$($workstream.id)' has an invalid path pattern '$pattern'."
            }
        }
        $workstreamIds[[string]$workstream.id] = $true
    }
}

function Test-ListMatch {
    param(
        [Parameter(Mandatory = $true)]$Values,
        [Parameter(Mandatory = $true)][string]$Value
    )

    return @($Values) -contains "*" -or @($Values) -contains $Value
}

function Find-Workstream {
    param(
        [Parameter(Mandatory = $true)][string]$RelativePath,
        [Parameter(Mandatory = $true)]$Policy
    )

    foreach ($workstream in @($Policy.workstreams)) {
        foreach ($pattern in @($workstream.pathPatterns)) {
            if ([Regex]::IsMatch($RelativePath, [string]$pattern, [Text.RegularExpressions.RegexOptions]::IgnoreCase)) {
                return $workstream
            }
        }
    }

    return $null
}

function Find-CadenceProfile {
    param(
        [Parameter(Mandatory = $true)][string]$WorkstreamId,
        [Parameter(Mandatory = $true)][string]$Authority,
        [Parameter(Mandatory = $true)][string]$ContentType,
        [Parameter(Mandatory = $true)]$Policy
    )

    foreach ($profile in @($Policy.cadenceProfiles)) {
        $workstreamMatches = @($profile.workstreams) -contains "*" -or @($profile.workstreams) -contains $WorkstreamId
        $authorityMatches = Test-ListMatch -Values $profile.authorities -Value $Authority
        $contentTypeMatches = Test-ListMatch -Values $profile.contentTypes -Value $ContentType
        if ($workstreamMatches -and $authorityMatches -and $contentTypeMatches) {
            return $profile
        }
    }

    return $null
}

function Add-Finding {
    param(
        [Parameter(Mandatory = $true)][AllowEmptyCollection()][System.Collections.Generic.List[object]]$Findings,
        [Parameter(Mandatory = $true)][string]$Path,
        [Parameter(Mandatory = $true)][string]$Workstream,
        [Parameter(Mandatory = $true)][string]$Code,
        [Parameter(Mandatory = $true)][ValidateSet("error", "warning", "info")][string]$Severity,
        [Parameter(Mandatory = $true)][string]$Message,
        [hashtable]$Details = @{}
    )

    $record = [ordered]@{
        path = $Path
        workstream = $Workstream
        code = $Code
        severity = $Severity
        message = $Message
    }
    foreach ($key in $Details.Keys) {
        $record[$key] = $Details[$key]
    }

    $Findings.Add([PSCustomObject]$record) | Out-Null
}

$repositoryRootFullPath = [IO.Path]::GetFullPath((ConvertTo-FullPath $RepositoryRoot))
$policyFullPath = if ([IO.Path]::IsPathRooted($PolicyPath)) {
    [IO.Path]::GetFullPath($PolicyPath)
}
else {
    [IO.Path]::GetFullPath((Join-Path $repositoryRootFullPath $PolicyPath))
}
$policy = Get-Policy -Path $policyFullPath
Assert-Policy -Policy $policy

$markdownPaths = @(Get-MarkdownPaths -Root $repositoryRootFullPath -RequestedPaths $Path)
$findings = New-Object "System.Collections.Generic.List[object]"
$counts = [ordered]@{
    filesScanned = 0
    version1Pages = 0
    metadataVersionGaps = 0
    ownerGaps = 0
    authorityGaps = 0
    unmappedVersion1Pages = 0
    configurationEvidenceGaps = 0
}

foreach ($markdownPath in $markdownPaths) {
    $relativePath = ConvertTo-RepositoryRelativePath -Value $markdownPath -Root $repositoryRootFullPath
    $workstream = Find-Workstream -RelativePath $relativePath -Policy $policy
    $text = Get-Content -LiteralPath $markdownPath -Raw
    $frontMatter = Get-FrontMatter -Text $text

    if ($null -eq $frontMatter) {
        if ($RequireVersion1) {
            $requiredWorkstream = if ($null -ne $workstream) { [string]$workstream.id } else { "unmapped" }
            Add-Finding -Findings $findings -Path $relativePath -Workstream $requiredWorkstream -Code "missing_front_matter" -Severity "error" -Message "A requested Markdown page must have version 1 front matter."
        }
        continue
    }

    $metadata = Get-FrontMatterValues -Text $frontMatter
    $metadataVersion = if ($metadata.ContainsKey("metadata_version")) { $metadata["metadata_version"] } else { "" }
    $preclassifiedAuthority = if ($metadata.ContainsKey("authority")) { [string]$metadata["authority"] } else { "" }
    $preclassifiedContentType = if ($metadata.ContainsKey("content_type")) { [string]$metadata["content_type"] } else { "" }
    if ($null -eq $workstream -and $metadataVersion -eq "1" -and ($preclassifiedAuthority -eq "historical" -or $preclassifiedContentType -eq "legacy")) {
        $workstream = @($policy.workstreams | Where-Object { $_.id -eq "legacy-historical" } | Select-Object -First 1)
    }
    if ($metadataVersion -ne "1") {
        if ($RequireVersion1 -or $null -ne $workstream) {
            $counts.metadataVersionGaps++
            $severity = if ($RequireVersion1) { "error" } else { "warning" }
            $gapWorkstream = if ($null -ne $workstream) { [string]$workstream.id } else { "unmapped" }
            Add-Finding -Findings $findings -Path $relativePath -Workstream $gapWorkstream -Code "metadata_version_gap" -Severity $severity -Message "This requested or governed page is not opted into metadata version 1; migration scope must be explicit before treating it as compliant."
        }
        continue
    }

    $counts.version1Pages++
    if ($null -eq $workstream) {
        $counts.unmappedVersion1Pages++
        Add-Finding -Findings $findings -Path $relativePath -Workstream "unmapped" -Code "unmapped_version1_page" -Severity "info" -Message "The page has version 1 metadata but is outside the D6.1 workstream path registry."
        continue
    }

    $counts.filesScanned++
    foreach ($requiredField in @($policy.metadataExpectations.requiredFields)) {
        if (-not $metadata.ContainsKey($requiredField) -or [String]::IsNullOrWhiteSpace([string]$metadata[$requiredField])) {
            Add-Finding -Findings $findings -Path $relativePath -Workstream $workstream.id -Code "missing_metadata_field" -Severity "error" -Message "The governed page is missing required metadata field '$requiredField'."
        }
    }

    $authority = if ($metadata.ContainsKey("authority")) { [string]$metadata["authority"] } else { "" }
    $contentType = if ($metadata.ContainsKey("content_type")) { [string]$metadata["content_type"] } else { "" }
    $owner = if ($metadata.ContainsKey("owner")) { [string]$metadata["owner"] } else { "" }

    if ($owner -ieq [string]$policy.accountableOwner) {
        Add-Finding -Findings $findings -Path $relativePath -Workstream $workstream.id -Code "owner_must_not_be_accountable_team_name" -Severity "error" -Message "Use an existing owner handle or the metadata contract sentinel instead of the accountable team name."
    }
    if (@($policy.metadataExpectations.ownerSentinels) -contains $owner) {
        $counts.ownerGaps++
        Add-Finding -Findings $findings -Path $relativePath -Workstream $workstream.id -Code "owner_gap" -Severity "warning" -Message "The page has no confirmed owner handle; keep the approved sentinel and record the follow-up rather than inventing an owner." -Details @{ owner = $owner }
    }

    if ($authority -in @("unknown", "not_applicable", "")) {
        $counts.authorityGaps++
        Add-Finding -Findings $findings -Path $relativePath -Workstream $workstream.id -Code "authority_gap" -Severity "warning" -Message "The page authority is not confirmed; assign no cadence until the authority is reviewed." -Details @{ authority = $authority }
    }

    $profile = $null
    if ($authority -notin @("unknown", "not_applicable", "") -and $contentType -ne "") {
        $profile = Find-CadenceProfile -WorkstreamId ([string]$workstream.id) -Authority $authority -ContentType $contentType -Policy $policy
        if ($null -eq $profile) {
            Add-Finding -Findings $findings -Path $relativePath -Workstream $workstream.id -Code "cadence_gap" -Severity "warning" -Message "No D6.1 cadence profile matches the page authority and content type." -Details @{ authority = $authority; contentType = $contentType }
        }
    }

}

foreach ($workstream in @($policy.workstreams)) {
    foreach ($evidencePath in @($workstream.evidencePaths)) {
        $fullEvidencePath = Join-Path $repositoryRootFullPath ([string]$evidencePath)
        if (-not (Test-Path -LiteralPath $fullEvidencePath)) {
            $counts.configurationEvidenceGaps++
            Add-Finding -Findings $findings -Path ([string]$evidencePath) -Workstream $workstream.id -Code "configuration_evidence_gap" -Severity "warning" -Message "The governance evidence path listed for this workstream does not exist."
        }
    }
}

$report = [ordered]@{
    schemaVersion = 1
    policy = [string]$policy.policy
    asOfDate = $AsOfDate.ToString("yyyy-MM-dd")
    accountableOwner = [string]$policy.accountableOwner
    accountableOwnerHandle = [string]$policy.accountableOwnerHandle
    ownerHandleFollowUp = [string]$policy.ownerHandleFollowUp
    summary = [PSCustomObject]$counts
    findings = $findings.ToArray()
}

if (-not [String]::IsNullOrWhiteSpace($ReportPath)) {
    $reportFullPath = if ([IO.Path]::IsPathRooted($ReportPath)) {
        [IO.Path]::GetFullPath($ReportPath)
    }
    else {
        [IO.Path]::GetFullPath((Join-Path $repositoryRootFullPath $ReportPath))
    }
    $reportDirectory = Split-Path -Parent $reportFullPath
    if (-not (Test-Path -LiteralPath $reportDirectory -PathType Container)) {
        New-Item -ItemType Directory -Path $reportDirectory -Force | Out-Null
    }
    $utf8NoBom = New-Object Text.UTF8Encoding($false)
    [IO.File]::WriteAllText($reportFullPath, ($report | ConvertTo-Json -Depth 20), $utf8NoBom)
}

$errors = @($findings | Where-Object { $_.severity -eq "error" })
$ownerFailures = @()
if ($FailOnOwnerGap) {
    $ownerFailures = @($findings | Where-Object { $_.code -eq "owner_gap" })
}
Write-Output "Documentation governance: $($counts.filesScanned) governed version 1 pages scanned; $($counts.ownerGaps) owner gaps; $($counts.authorityGaps) authority gaps."

if ($errors.Count -gt 0 -or $ownerFailures.Count -gt 0) {
    $failureCodes = @($errors + $ownerFailures | Select-Object -ExpandProperty code -Unique) -join ", "
    throw "Documentation governance validation failed: $failureCodes."
}
