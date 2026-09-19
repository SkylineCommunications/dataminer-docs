Set-StrictMode -Version 2.0
$ErrorActionPreference = "Stop"

$script:ChangeKinds = @("schema", "api", "package", "validator", "template", "behavior", "unknown")
$script:Areas = @("root", "dataminer", "develop", "solutions", "tutorials", "connectors", "release-notes", "contributing", "unknown")
$script:ContentTypes = @("api", "schema", "example")

function Get-PropertyValue {
    param(
        [AllowNull()]$Object,
        [Parameter(Mandatory = $true)][string]$Name
    )

    if ($null -eq $Object) {
        return $null
    }

    $property = $Object.PSObject.Properties[$Name]
    if ($null -eq $property) {
        return $null
    }

    return $property.Value
}

function Get-StringArray {
    param([AllowNull()]$Value)

    if ($null -eq $Value) {
        return @()
    }
    if ($Value -is [string]) {
        if ([String]::IsNullOrWhiteSpace([string]$Value)) {
            return @()
        }
        return @([string]$Value)
    }

    return @(
        $Value |
            ForEach-Object { [string]$_ } |
            Where-Object { -not [String]::IsNullOrWhiteSpace($_) }
    )
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

function Assert-Properties {
    param(
        [AllowNull()]$Object,
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

function Assert-NonEmpty {
    param(
        [AllowNull()][string]$Value,
        [Parameter(Mandatory = $true)][string]$Context
    )

    Assert-Condition (-not [String]::IsNullOrWhiteSpace($Value)) "$Context must be a non-empty string."
}

function Assert-UniqueStrings {
    param(
        [AllowNull()]$Values,
        [Parameter(Mandatory = $true)][string]$Context,
        [int]$Minimum = 0
    )

    $strings = @(Get-StringArray $Values)
    Assert-Condition ($strings.Count -ge $Minimum) "$Context must contain at least $Minimum value(s)."
    Assert-Condition ((@($strings | Sort-Object -Unique).Count) -eq $strings.Count) "$Context contains duplicate values."
    foreach ($value in $strings) {
        Assert-NonEmpty -Value $value -Context "$Context value"
    }
}

function Assert-RegexPatterns {
    param(
        [AllowNull()]$Patterns,
        [Parameter(Mandatory = $true)][string]$Context,
        [int]$Minimum = 0
    )

    $values = @(Get-StringArray $Patterns)
    Assert-Condition ($values.Count -ge $Minimum) "$Context must contain at least $Minimum pattern(s)."
    foreach ($pattern in $values) {
        Assert-NonEmpty -Value $pattern -Context "$Context pattern"
        try {
            [Regex]::new($pattern) | Out-Null
        }
        catch {
            throw "$Context contains invalid regular expression '$pattern'."
        }
    }
}

function Read-JsonDocument {
    param([Parameter(Mandatory = $true)][string]$Path)

    Assert-Condition (Test-Path -LiteralPath $Path -PathType Leaf) "JSON document '$Path' does not exist."
    try {
        return Get-Content -LiteralPath $Path -Raw | ConvertFrom-Json
    }
    catch {
        throw "JSON document '$Path' is not valid JSON: $($_.Exception.Message)"
    }
}

function Write-JsonDocument {
    param(
        [Parameter(Mandatory = $true)][string]$Path,
        [Parameter(Mandatory = $true)]$Value
    )

    $directory = Split-Path -Parent $Path
    if (-not (Test-Path -LiteralPath $directory -PathType Container)) {
        New-Item -ItemType Directory -Path $directory -Force | Out-Null
    }

    $utf8NoBom = New-Object Text.UTF8Encoding($false)
    [IO.File]::WriteAllText($Path, ($Value | ConvertTo-Json -Depth 30) + [Environment]::NewLine, $utf8NoBom)
}

function ConvertTo-RepositoryRelativePath {
    param(
        [Parameter(Mandatory = $true)][string]$Path,
        [Parameter(Mandatory = $true)][string]$Root
    )

    $fullPath = [IO.Path]::GetFullPath($Path)
    $prefix = $Root.TrimEnd("\") + "\"
    if ($fullPath.StartsWith($prefix, [StringComparison]::OrdinalIgnoreCase)) {
        return $fullPath.Substring($prefix.Length).Replace("\", "/")
    }

    return $fullPath.Replace("\", "/")
}

function Get-RepositoryFiles {
    param([Parameter(Mandatory = $true)][string]$Root)

    $paths = New-Object "System.Collections.Generic.List[string]"
    $directories = @(
        "",
        "contributing",
        "dataminer",
        "develop",
        "release-notes",
        "solutions",
        "tutorials",
        "scripts",
        "src"
    )
    foreach ($directory in $directories) {
        $directoryPath = if ($directory -eq "") { $Root } else { Join-Path $Root $directory }
        if (-not (Test-Path -LiteralPath $directoryPath -PathType Container)) {
            continue
        }
        foreach ($file in @(Get-ChildItem -LiteralPath $directoryPath -Recurse -File -ErrorAction SilentlyContinue)) {
            $relative = ConvertTo-RepositoryRelativePath -Path $file.FullName -Root $Root
            if ($relative -match "^(?:\.git|obj|bin|_site|_artifacts)(?:/|$)") {
                continue
            }
            $paths.Add($relative) | Out-Null
        }
    }

    return @($paths | Sort-Object -Unique)
}

function Get-RepositoryUids {
    param([Parameter(Mandatory = $true)][string]$Root)

    $uids = @{}
    foreach ($relativePath in @(Get-RepositoryFiles -Root $Root | Where-Object { $_ -like "*.md" })) {
        $path = Join-Path $Root $relativePath.Replace("/", "\")
        $lines = @(Get-Content -LiteralPath $path -TotalCount 80 -ErrorAction SilentlyContinue)
        foreach ($line in $lines) {
            $match = [Regex]::Match([string]$line, "^\s*uid:\s*[`"']?(?<uid>[^`"'\r\n]+)[`"']?\s*$")
            if ($match.Success) {
                $uid = $match.Groups["uid"].Value.Trim()
                if ($uid -ne "") {
                    $uids[$uid] = $relativePath
                }
                break
            }
        }
    }

    return $uids
}

function Assert-MapContract {
    param(
        [Parameter(Mandatory = $true)]$Map,
        [string]$RepositoryRoot = ""
    )

    Assert-Properties `
        -Object $Map `
        -Required @('$schema', 'schemaVersion', 'policy', 'format', 'visibility', 'accountableOwner', 'accountableOwnerHandle', 'ownerHandleFollowUp', 'crossRepositoryTrigger', 'distribution', 'checks', 'gates', 'entries', 'followUps') `
        -Allowed @('$schema', 'schemaVersion', 'policy', 'format', 'visibility', 'accountableOwner', 'accountableOwnerHandle', 'ownerHandleFollowUp', 'crossRepositoryTrigger', 'distribution', 'checks', 'gates', 'entries', 'followUps') `
        -Context "dependency map"
    Assert-Condition ([int]$Map.schemaVersion -eq 1) "Dependency map schemaVersion must be 1."
    Assert-Condition ([string]$Map.policy -eq "D6.2") "Dependency map policy must identify D6.2."
    Assert-Condition ([string]$Map.format -eq "json") "Dependency map format must be json."
    Assert-Condition ([string]$Map.visibility -eq "repository-metadata") "Dependency map visibility must be repository-metadata."
    Assert-Condition ([string]$Map.accountableOwner -eq "Docs Writing Team") "Dependency map accountableOwner must be Docs Writing Team."
    Assert-Condition ([string]$Map.accountableOwnerHandle -in @("unknown", "not_applicable")) "Dependency map must keep the unconfirmed accountable owner handle unresolved."
    Assert-NonEmpty -Value ([string]$Map.ownerHandleFollowUp) -Context "dependency map ownerHandleFollowUp"

    Assert-Properties `
        -Object $Map.crossRepositoryTrigger `
        -Required @("status", "invocation", "permission", "permissionOwner", "followUp") `
        -Allowed @("status", "invocation", "permission", "permissionOwner", "followUp") `
        -Context "dependency map crossRepositoryTrigger"
    Assert-Condition ([string]$Map.crossRepositoryTrigger.status -in @("configured", "not_configured", "unknown")) "Dependency map crossRepositoryTrigger.status is invalid."
    Assert-Condition ([string]$Map.crossRepositoryTrigger.invocation -in @("caller_supplied", "repository_dispatch", "workflow_dispatch", "unknown")) "Dependency map crossRepositoryTrigger.invocation is invalid."
    Assert-Condition ([string]$Map.crossRepositoryTrigger.permission -in @("available", "unavailable", "unknown")) "Dependency map crossRepositoryTrigger.permission is invalid."
    Assert-Condition ([string]$Map.crossRepositoryTrigger.permissionOwner -in @("unknown", "not_applicable")) "Dependency map crossRepositoryTrigger.permissionOwner must remain unresolved."
    Assert-NonEmpty -Value ([string]$Map.crossRepositoryTrigger.followUp) -Context "dependency map crossRepositoryTrigger.followUp"

    Assert-Properties `
        -Object $Map.distribution `
        -Required @("publicDocumentation", "metadataArtifact", "internalDiagnostics", "license", "attribution") `
        -Allowed @("publicDocumentation", "metadataArtifact", "internalDiagnostics", "license", "attribution") `
        -Context "dependency map distribution"
    Assert-Condition ([string]$Map.distribution.publicDocumentation -eq "unchanged") "Dependency map cannot change the public documentation distribution."
    Assert-Condition ([string]$Map.distribution.metadataArtifact -eq "repository-only") "Dependency map metadata must remain repository-only."
    Assert-Condition ([string]$Map.distribution.internalDiagnostics -eq "internal-only") "Dependency map diagnostics must remain internal-only."
    Assert-Condition ([string]$Map.distribution.license -eq "CC BY-NC-ND 4.0") "Dependency map license must use the D0.3 license."
    Assert-Condition ([string]$Map.distribution.attribution -eq "Skyline Communications") "Dependency map attribution must use Skyline Communications."

    $checksById = @{}
    foreach ($check in @($Map.checks)) {
        Assert-Properties -Object $check -Required @("id", "label", "command", "scope") -Allowed @("id", "label", "command", "scope") -Context "dependency map check"
        $checkId = [string]$check.id
        Assert-NonEmpty -Value $checkId -Context "dependency map check id"
        Assert-Condition (-not $checksById.ContainsKey($checkId)) "Dependency map check IDs must be unique; '$checkId' is duplicated."
        Assert-Condition ($checkId -match "^[a-z0-9-]+$") "Dependency map check '$checkId' has an invalid ID."
        Assert-NonEmpty -Value ([string]$check.label) -Context "dependency map check '$checkId' label"
        Assert-NonEmpty -Value ([string]$check.command) -Context "dependency map check '$checkId' command"
        Assert-Condition ([string]$check.scope -in @("map", "targeted", "generated", "repository", "workflow")) "Dependency map check '$checkId' has an invalid scope."
        $checksById[$checkId] = $true
    }

    $gatesById = @{}
    foreach ($gate in @($Map.gates)) {
        Assert-Properties -Object $gate -Required @("id", "label", "requiredBefore", "acknowledgementField", "updateDecisionField", "acceptedAcknowledgement", "acceptedUpdateDecisions", "unresolvedValues", "productReleaseBlocking", "owner", "followUp") -Allowed @("id", "label", "requiredBefore", "acknowledgementField", "updateDecisionField", "acceptedAcknowledgement", "acceptedUpdateDecisions", "unresolvedValues", "productReleaseBlocking", "owner", "followUp") -Context "dependency map gate"
        $gateId = [string]$gate.id
        Assert-NonEmpty -Value $gateId -Context "dependency map gate id"
        Assert-Condition (-not $gatesById.ContainsKey($gateId)) "Dependency map gate IDs must be unique; '$gateId' is duplicated."
        Assert-Condition ($gateId -match "^[a-z0-9-]+$") "Dependency map gate '$gateId' has an invalid ID."
        Assert-Condition ([string]$gate.requiredBefore -eq "documentation-release") "Dependency map gate '$gateId' must be required before documentation-release."
        Assert-Condition ([string]$gate.acknowledgementField -eq "acknowledgement.status") "Dependency map gate '$gateId' has an unexpected acknowledgement field."
        Assert-Condition ([string]$gate.updateDecisionField -eq "documentationUpdate.status") "Dependency map gate '$gateId' has an unexpected update decision field."
        Assert-Condition (@($gate.acceptedAcknowledgement) -contains "acknowledged") "Dependency map gate '$gateId' must accept acknowledged."
        Assert-Condition (@($gate.acceptedUpdateDecisions) -contains "updated" -and @($gate.acceptedUpdateDecisions) -contains "not_applicable") "Dependency map gate '$gateId' must accept updated and not_applicable."
        Assert-Condition (@($gate.unresolvedValues) -contains "unknown") "Dependency map gate '$gateId' must represent unknown as unresolved."
        Assert-Condition ([string]$gate.productReleaseBlocking -eq "unknown") "Dependency map gate '$gateId' must not claim a product release blocker."
        Assert-Condition ([string]$gate.owner -in @("unknown", "not_applicable")) "Dependency map gate '$gateId' owner must remain unresolved."
        Assert-NonEmpty -Value ([string]$gate.followUp) -Context "dependency map gate '$gateId' followUp"
        $gatesById[$gateId] = $true
    }

    $repositoryUids = $null
    if (-not [String]::IsNullOrWhiteSpace($RepositoryRoot) -and (Test-Path -LiteralPath $RepositoryRoot -PathType Container)) {
        $repositoryUids = Get-RepositoryUids -Root $RepositoryRoot
    }

    $entryIds = @{}
    $sourcePatternCount = 0
    $targetPatternCount = 0
    $targetUids = @{}
    foreach ($entry in @($Map.entries)) {
        Assert-Properties -Object $entry -Required @("id", "label", "changeKinds", "source", "targets", "trigger", "checks", "generated", "gate") -Allowed @("id", "label", "changeKinds", "source", "targets", "trigger", "checks", "generated", "gate") -Context "dependency map entry"
        $entryId = [string]$entry.id
        Assert-NonEmpty -Value $entryId -Context "dependency map entry id"
        Assert-Condition (-not $entryIds.ContainsKey($entryId)) "Dependency map entry IDs must be unique; '$entryId' is duplicated."
        Assert-Condition ($entryId -match "^[a-z0-9-]+$") "Dependency map entry '$entryId' has an invalid ID."
        Assert-NonEmpty -Value ([string]$entry.label) -Context "dependency map entry '$entryId' label"
        Assert-UniqueStrings -Values $entry.changeKinds -Context "dependency map entry '$entryId' changeKinds" -Minimum 1
        foreach ($changeKind in @(Get-StringArray $entry.changeKinds)) {
            Assert-Condition ($script:ChangeKinds -contains $changeKind -and $changeKind -ne "unknown") "Dependency map entry '$entryId' has an invalid change kind '$changeKind'."
        }

        Assert-Properties -Object $entry.source -Required @("repository", "pathPatterns", "revision", "release", "package", "followUp") -Allowed @("repository", "pathPatterns", "revision", "release", "package", "followUp") -Context "dependency map entry '$entryId' source"
        Assert-NonEmpty -Value ([string]$entry.source.repository) -Context "dependency map entry '$entryId' source.repository"
        Assert-RegexPatterns -Patterns $entry.source.pathPatterns -Context "dependency map entry '$entryId' source.pathPatterns" -Minimum 1
        $sourcePatternCount += @($entry.source.pathPatterns).Count
        Assert-NonEmpty -Value ([string]$entry.source.revision) -Context "dependency map entry '$entryId' source.revision"
        Assert-NonEmpty -Value ([string]$entry.source.release) -Context "dependency map entry '$entryId' source.release"
        Assert-Properties -Object $entry.source.package -Required @("id", "version") -Allowed @("id", "version") -Context "dependency map entry '$entryId' source.package"
        Assert-NonEmpty -Value ([string]$entry.source.package.id) -Context "dependency map entry '$entryId' source.package.id"
        Assert-NonEmpty -Value ([string]$entry.source.package.version) -Context "dependency map entry '$entryId' source.package.version"
        Assert-NonEmpty -Value ([string]$entry.source.followUp) -Context "dependency map entry '$entryId' source.followUp"

        Assert-Properties -Object $entry.targets -Required @("areas", "uids", "pathPatterns", "urlCompatibility") -Allowed @("areas", "uids", "pathPatterns", "urlCompatibility") -Context "dependency map entry '$entryId' targets"
        Assert-UniqueStrings -Values $entry.targets.areas -Context "dependency map entry '$entryId' target areas" -Minimum 1
        foreach ($area in @(Get-StringArray $entry.targets.areas)) {
            Assert-Condition ($script:Areas -contains $area) "Dependency map entry '$entryId' has an invalid target area '$area'."
        }
        Assert-UniqueStrings -Values $entry.targets.uids -Context "dependency map entry '$entryId' target UIDs" -Minimum 1
        foreach ($uid in @(Get-StringArray $entry.targets.uids)) {
            $targetUids[$uid] = $true
            if ($null -ne $repositoryUids) {
                Assert-Condition ($repositoryUids.ContainsKey($uid)) "Dependency map entry '$entryId' targets UID '$uid', but that UID is not present in the repository."
            }
        }
        Assert-RegexPatterns -Patterns $entry.targets.pathPatterns -Context "dependency map entry '$entryId' target pathPatterns" -Minimum 1
        $targetPatternCount += @($entry.targets.pathPatterns).Count
        Assert-Condition ([string]$entry.targets.urlCompatibility -eq "stable-by-default") "Dependency map entry '$entryId' must preserve stable UID and URL identities by default."

        Assert-Properties -Object $entry.trigger -Required @("matchModes", "inputFields", "explicitUnknownAllowed") -Allowed @("matchModes", "inputFields", "explicitUnknownAllowed") -Context "dependency map entry '$entryId' trigger"
        Assert-UniqueStrings -Values $entry.trigger.matchModes -Context "dependency map entry '$entryId' trigger.matchModes" -Minimum 1
        foreach ($mode in @(Get-StringArray $entry.trigger.matchModes)) {
            Assert-Condition ($mode -in @("change_kind", "source_path", "explicit_uid", "explicit_area", "documentation_path")) "Dependency map entry '$entryId' has an invalid trigger match mode '$mode'."
        }
        Assert-UniqueStrings -Values $entry.trigger.inputFields -Context "dependency map entry '$entryId' trigger.inputFields" -Minimum 1
        Assert-Condition ([bool]$entry.trigger.explicitUnknownAllowed) "Dependency map entry '$entryId' must allow explicit unknown follow-up values."

        Assert-UniqueStrings -Values $entry.checks -Context "dependency map entry '$entryId' checks" -Minimum 1
        foreach ($checkId in @(Get-StringArray $entry.checks)) {
            Assert-Condition ($checksById.ContainsKey($checkId)) "Dependency map entry '$entryId' references unknown check '$checkId'."
        }

        Assert-Properties -Object $entry.generated -Required @("required", "contentTypes", "sourceIdentityFields", "provenance", "followUp") -Allowed @("required", "contentTypes", "sourceIdentityFields", "provenance", "followUp") -Context "dependency map entry '$entryId' generated"
        Assert-UniqueStrings -Values $entry.generated.contentTypes -Context "dependency map entry '$entryId' generated.contentTypes"
        foreach ($contentType in @(Get-StringArray $entry.generated.contentTypes)) {
            Assert-Condition ($script:ContentTypes -contains $contentType) "Dependency map entry '$entryId' has an invalid generated content type '$contentType'."
        }
        Assert-UniqueStrings -Values $entry.generated.sourceIdentityFields -Context "dependency map entry '$entryId' generated.sourceIdentityFields"
        foreach ($field in @(Get-StringArray $entry.generated.sourceIdentityFields)) {
            Assert-Condition ($field -in @("release", "package.id", "package.version")) "Dependency map entry '$entryId' has an invalid generated source identity field '$field'."
        }
        if ([bool]$entry.generated.required) {
            foreach ($field in @("release", "package.id", "package.version")) {
                Assert-Condition (@($entry.generated.sourceIdentityFields) -contains $field) "Dependency map entry '$entryId' must require generated source identity field '$field'."
            }
            Assert-Condition (@($entry.generated.contentTypes).Count -gt 0) "Dependency map entry '$entryId' requires generated identity but has no generated content types."
        }
        Assert-NonEmpty -Value ([string]$entry.generated.provenance) -Context "dependency map entry '$entryId' generated.provenance"
        Assert-NonEmpty -Value ([string]$entry.generated.followUp) -Context "dependency map entry '$entryId' generated.followUp"

        Assert-Condition ($gatesById.ContainsKey([string]$entry.gate)) "Dependency map entry '$entryId' references unknown gate '$($entry.gate)'."
        $entryIds[$entryId] = $true
    }

    $followUpIds = @{}
    foreach ($followUp in @($Map.followUps)) {
        Assert-Properties -Object $followUp -Required @("id", "status", "action", "owner") -Allowed @("id", "status", "action", "owner") -Context "dependency map follow-up"
        $followUpId = [string]$followUp.id
        Assert-NonEmpty -Value $followUpId -Context "dependency map follow-up id"
        Assert-Condition (-not $followUpIds.ContainsKey($followUpId)) "Dependency map follow-up IDs must be unique; '$followUpId' is duplicated."
        Assert-Condition ([string]$followUp.status -in @("open", "complete", "unknown")) "Dependency map follow-up '$followUpId' has an invalid status."
        Assert-NonEmpty -Value ([string]$followUp.action) -Context "dependency map follow-up '$followUpId' action"
        Assert-Condition ([string]$followUp.owner -in @("unknown", "not_applicable")) "Dependency map follow-up '$followUpId' owner must remain unresolved."
        $followUpIds[$followUpId] = $true
    }

    return [ordered]@{
        entries = @($Map.entries).Count
        checks = @($Map.checks).Count
        gates = @($Map.gates).Count
        followUps = @($Map.followUps).Count
        sourcePatterns = $sourcePatternCount
        targetPatterns = $targetPatternCount
        targetUids = $targetUids.Count
    }
}

function Assert-ChangeContract {
    param([Parameter(Mandatory = $true)]$Change)

    Assert-Properties `
        -Object $Change `
        -Required @('$schema', 'schemaVersion', 'policy', 'format', 'visibility', 'changeId', 'source', 'changeKinds', 'changedPaths', 'affectedDocumentation', 'generatedReferences', 'acknowledgement', 'documentationUpdate', 'dispatch') `
        -Allowed @('$schema', 'schemaVersion', 'policy', 'format', 'visibility', 'changeId', 'source', 'changeKinds', 'changedPaths', 'affectedDocumentation', 'generatedReferences', 'acknowledgement', 'documentationUpdate', 'dispatch') `
        -Context "product change"
    Assert-Condition ([int]$Change.schemaVersion -eq 1) "Product change schemaVersion must be 1."
    Assert-Condition ([string]$Change.policy -eq "D6.2") "Product change policy must identify D6.2."
    Assert-Condition ([string]$Change.format -eq "json") "Product change format must be json."
    Assert-Condition ([string]$Change.visibility -eq "repository-metadata") "Product change visibility must be repository-metadata."
    Assert-NonEmpty -Value ([string]$Change.changeId) -Context "product change changeId"

    Assert-Properties -Object $Change.source -Required @("repository", "pullRequest", "revision", "release", "package", "followUp") -Allowed @("repository", "pullRequest", "revision", "release", "package", "followUp") -Context "product change source"
    foreach ($field in @("repository", "pullRequest", "revision", "release", "followUp")) {
        Assert-NonEmpty -Value ([string](Get-PropertyValue -Object $Change.source -Name $field)) -Context "product change source.$field"
    }
    Assert-Properties -Object $Change.source.package -Required @("id", "version") -Allowed @("id", "version") -Context "product change source.package"
    Assert-NonEmpty -Value ([string]$Change.source.package.id) -Context "product change source.package.id"
    Assert-NonEmpty -Value ([string]$Change.source.package.version) -Context "product change source.package.version"
    Assert-UniqueStrings -Values $Change.changeKinds -Context "product change changeKinds" -Minimum 1
    foreach ($changeKind in @(Get-StringArray $Change.changeKinds)) {
        Assert-Condition ($script:ChangeKinds -contains $changeKind) "Product change has invalid change kind '$changeKind'."
    }
    Assert-UniqueStrings -Values $Change.changedPaths -Context "product change changedPaths" -Minimum 1

    Assert-Properties -Object $Change.affectedDocumentation -Required @("uids", "areas", "followUp") -Allowed @("uids", "areas", "followUp") -Context "product change affectedDocumentation"
    Assert-UniqueStrings -Values $Change.affectedDocumentation.uids -Context "product change affectedDocumentation.uids" -Minimum 1
    Assert-UniqueStrings -Values $Change.affectedDocumentation.areas -Context "product change affectedDocumentation.areas" -Minimum 1
    foreach ($area in @(Get-StringArray $Change.affectedDocumentation.areas)) {
        Assert-Condition ($script:Areas -contains $area) "Product change has invalid documentation area '$area'."
    }
    Assert-NonEmpty -Value ([string]$Change.affectedDocumentation.followUp) -Context "product change affectedDocumentation.followUp"

    Assert-Properties -Object $Change.generatedReferences -Required @("present", "contentTypes", "sourceIdentity", "followUp") -Allowed @("present", "contentTypes", "sourceIdentity", "followUp") -Context "product change generatedReferences"
    Assert-UniqueStrings -Values $Change.generatedReferences.contentTypes -Context "product change generatedReferences.contentTypes"
    foreach ($contentType in @(Get-StringArray $Change.generatedReferences.contentTypes)) {
        Assert-Condition ($script:ContentTypes -contains $contentType) "Product change has invalid generated content type '$contentType'."
    }
    Assert-Properties -Object $Change.generatedReferences.sourceIdentity -Required @("release", "package", "followUp") -Allowed @("release", "package", "followUp") -Context "product change generatedReferences.sourceIdentity"
    Assert-NonEmpty -Value ([string]$Change.generatedReferences.sourceIdentity.release) -Context "product change generatedReferences.sourceIdentity.release"
    Assert-Properties -Object $Change.generatedReferences.sourceIdentity.package -Required @("id", "version") -Allowed @("id", "version") -Context "product change generatedReferences.sourceIdentity.package"
    Assert-NonEmpty -Value ([string]$Change.generatedReferences.sourceIdentity.package.id) -Context "product change generatedReferences.sourceIdentity.package.id"
    Assert-NonEmpty -Value ([string]$Change.generatedReferences.sourceIdentity.package.version) -Context "product change generatedReferences.sourceIdentity.package.version"
    Assert-NonEmpty -Value ([string]$Change.generatedReferences.sourceIdentity.followUp) -Context "product change generatedReferences.sourceIdentity.followUp"
    Assert-NonEmpty -Value ([string]$Change.generatedReferences.followUp) -Context "product change generatedReferences.followUp"

    Assert-Properties -Object $Change.acknowledgement -Required @("status", "actor", "recordedAt", "evidence", "followUp") -Allowed @("status", "actor", "recordedAt", "evidence", "followUp") -Context "product change acknowledgement"
    Assert-Condition ([string]$Change.acknowledgement.status -in @("acknowledged", "not_acknowledged", "unknown")) "Product change acknowledgement status is invalid."
    Assert-NonEmpty -Value ([string]$Change.acknowledgement.actor) -Context "product change acknowledgement.actor"
    Assert-Condition ([string]$Change.acknowledgement.recordedAt -match "^\d{4}-\d{2}-\d{2}$|^unknown$") "Product change acknowledgement.recordedAt must be an ISO date or unknown."
    Assert-NonEmpty -Value ([string]$Change.acknowledgement.evidence) -Context "product change acknowledgement.evidence"
    Assert-NonEmpty -Value ([string]$Change.acknowledgement.followUp) -Context "product change acknowledgement.followUp"

    Assert-Properties -Object $Change.documentationUpdate -Required @("status", "uids", "areas", "evidence", "followUp") -Allowed @("status", "uids", "areas", "evidence", "followUp") -Context "product change documentationUpdate"
    Assert-Condition ([string]$Change.documentationUpdate.status -in @("updated", "not_applicable", "required", "unknown")) "Product change documentation update status is invalid."
    Assert-UniqueStrings -Values $Change.documentationUpdate.uids -Context "product change documentationUpdate.uids" -Minimum 1
    Assert-UniqueStrings -Values $Change.documentationUpdate.areas -Context "product change documentationUpdate.areas" -Minimum 1
    foreach ($area in @(Get-StringArray $Change.documentationUpdate.areas)) {
        Assert-Condition ($script:Areas -contains $area) "Product change update has invalid documentation area '$area'."
    }
    Assert-NonEmpty -Value ([string]$Change.documentationUpdate.evidence) -Context "product change documentationUpdate.evidence"
    Assert-NonEmpty -Value ([string]$Change.documentationUpdate.followUp) -Context "product change documentationUpdate.followUp"

    Assert-Properties -Object $Change.dispatch -Required @("status", "permission", "followUp") -Allowed @("status", "permission", "followUp") -Context "product change dispatch"
    Assert-Condition ([string]$Change.dispatch.status -in @("not_requested", "requested", "completed", "unknown")) "Product change dispatch status is invalid."
    Assert-Condition ([string]$Change.dispatch.permission -in @("available", "unavailable", "unknown")) "Product change dispatch permission is invalid."
    Assert-NonEmpty -Value ([string]$Change.dispatch.followUp) -Context "product change dispatch.followUp"
}

function Get-ChangedPathsFromGit {
    param(
        [Parameter(Mandatory = $true)][string]$Root,
        [string]$BaseRevision = "",
        [string]$HeadRevision = ""
    )

    $arguments = @("diff", "--name-only")
    if (-not [String]::IsNullOrWhiteSpace($BaseRevision) -and -not [String]::IsNullOrWhiteSpace($HeadRevision)) {
        $arguments += "$BaseRevision...$HeadRevision"
    }
    else {
        $arguments += "HEAD^", "HEAD"
    }

    try {
        $result = & git -C $Root @arguments 2>$null
        if ($LASTEXITCODE -ne 0) {
            return @()
        }
        return @(
            $result |
                ForEach-Object { ([string]$_).Trim().Replace("\", "/") } |
                Where-Object { $_ -ne "" } |
                Sort-Object -Unique
        )
    }
    catch {
        return @()
    }
}

function Test-PatternMatch {
    param(
        [Parameter(Mandatory = $true)][string]$Value,
        [Parameter(Mandatory = $true)]$Patterns
    )

    foreach ($pattern in @($Patterns)) {
        if ([Regex]::IsMatch($Value, [string]$pattern, [Text.RegularExpressions.RegexOptions]::IgnoreCase)) {
            return $true
        }
    }
    return $false
}

function Add-UniqueString {
    param(
        [Parameter(Mandatory = $true)][AllowEmptyCollection()][System.Collections.Generic.List[string]]$List,
        [Parameter(Mandatory = $true)][string]$Value
    )

    if (-not $List.Contains($Value)) {
        $List.Add($Value) | Out-Null
    }
}

function Resolve-CouplingReport {
    param(
        [Parameter(Mandatory = $true)]$Map,
        [AllowNull()]$Change,
        [Parameter(Mandatory = $true)][string]$RepositoryRoot,
        [string[]]$ChangedPaths = @()
    )

    $normalizedPaths = New-Object "System.Collections.Generic.List[string]"
    foreach ($path in @(Get-StringArray $ChangedPaths)) {
        Add-UniqueString -List $normalizedPaths -Value $path.Replace("\", "/").TrimStart("/")
    }
    if ($null -ne $Change) {
        foreach ($path in @(Get-StringArray $Change.changedPaths)) {
            Add-UniqueString -List $normalizedPaths -Value $path.Replace("\", "/").TrimStart("/")
        }
    }

    $changeKinds = if ($null -ne $Change) { @(Get-StringArray $Change.changeKinds) } else { @() }
    $explicitUids = if ($null -ne $Change) { @(Get-StringArray $Change.affectedDocumentation.uids) } else { @() }
    $explicitAreas = if ($null -ne $Change) { @(Get-StringArray $Change.affectedDocumentation.areas) } else { @() }
    $repositoryFiles = @(Get-RepositoryFiles -Root $RepositoryRoot)
    $matchedEntries = New-Object "System.Collections.Generic.List[object]"
    $targetedUids = New-Object "System.Collections.Generic.List[string]"
    $targetedAreas = New-Object "System.Collections.Generic.List[string]"
    $targetedPaths = New-Object "System.Collections.Generic.List[string]"
    $targetedCheckIds = New-Object "System.Collections.Generic.List[string]"
    $gaps = New-Object "System.Collections.Generic.List[object]"

    foreach ($entry in @($Map.entries)) {
        $reasons = New-Object "System.Collections.Generic.List[string]"
        foreach ($kind in $changeKinds) {
            if (@($entry.changeKinds) -contains $kind) {
                Add-UniqueString -List $reasons -Value "change-kind:$kind"
            }
        }
        foreach ($path in $normalizedPaths) {
            if (Test-PatternMatch -Value $path -Patterns $entry.source.pathPatterns) {
                Add-UniqueString -List $reasons -Value "source-path:$path"
            }
            if (Test-PatternMatch -Value $path -Patterns $entry.targets.pathPatterns) {
                Add-UniqueString -List $reasons -Value "documentation-path:$path"
            }
        }
        foreach ($uid in $explicitUids) {
            if ($uid -ne "unknown" -and @($entry.targets.uids) -contains $uid) {
                Add-UniqueString -List $reasons -Value "explicit-uid:$uid"
            }
        }
        foreach ($area in $explicitAreas) {
            if ($area -ne "unknown" -and @($entry.targets.areas) -contains $area) {
                Add-UniqueString -List $reasons -Value "explicit-area:$area"
            }
        }

        if ($reasons.Count -eq 0) {
            continue
        }

        foreach ($uid in @($entry.targets.uids)) {
            Add-UniqueString -List $targetedUids -Value ([string]$uid)
        }
        foreach ($area in @($entry.targets.areas)) {
            Add-UniqueString -List $targetedAreas -Value ([string]$area)
        }
        foreach ($checkId in @($entry.checks)) {
            Add-UniqueString -List $targetedCheckIds -Value ([string]$checkId)
        }
        foreach ($path in $repositoryFiles) {
            if (Test-PatternMatch -Value $path -Patterns $entry.targets.pathPatterns) {
                Add-UniqueString -List $targetedPaths -Value $path
            }
        }

        $matchedEntries.Add([ordered]@{
            id = [string]$entry.id
            label = [string]$entry.label
            matchedBy = @($reasons | Sort-Object)
            changeKinds = @($entry.changeKinds | Sort-Object)
            uids = @($entry.targets.uids | Sort-Object)
            areas = @($entry.targets.areas | Sort-Object)
            pathPatterns = @($entry.targets.pathPatterns | Sort-Object)
            checks = @($entry.checks | Sort-Object)
            generated = [ordered]@{
                required = [bool]$entry.generated.required
                contentTypes = @($entry.generated.contentTypes | Sort-Object)
                sourceIdentityFields = @($entry.generated.sourceIdentityFields | Sort-Object)
                provenance = [string]$entry.generated.provenance
            }
        }) | Out-Null
    }

    if ($null -ne $Change -and $matchedEntries.Count -eq 0) {
        $gaps.Add([ordered]@{
            code = "unmapped-product-change"
            severity = "error"
            message = "The product change did not match a dependency-map entry by change kind, source path, documentation UID, or documentation area."
        }) | Out-Null
    }

    $generatedEntries = @($matchedEntries | Where-Object { $_.generated.required })
    $identityGap = $false
    if ($null -ne $Change -and $generatedEntries.Count -gt 0) {
        if (-not [bool]$Change.generatedReferences.present) {
            $identityGap = $true
            $gaps.Add([ordered]@{
                code = "generated-reference-identity-missing"
                severity = "error"
                message = "A matched dependency requires generated references or examples, but generatedReferences.present is false."
            }) | Out-Null
        }
        else {
            $identity = $Change.generatedReferences.sourceIdentity
            $unknownFields = New-Object "System.Collections.Generic.List[string]"
            if ([string]$identity.release -eq "unknown") { $unknownFields.Add("release") | Out-Null }
            if ([string]$identity.package.id -eq "unknown") { $unknownFields.Add("package.id") | Out-Null }
            if ([string]$identity.package.version -eq "unknown") { $unknownFields.Add("package.version") | Out-Null }
            if ($unknownFields.Count -gt 0) {
                $identityGap = $true
                $gaps.Add([ordered]@{
                    code = "generated-source-identity-unknown"
                    severity = "warning"
                    fields = @($unknownFields.ToArray())
                    message = "Generated references or examples have an unresolved source release or package identity; retain unknown and record the follow-up."
                }) | Out-Null
            }
        }
    }

    $gateStatus = "not_applicable"
    $gateFollowUps = New-Object "System.Collections.Generic.List[string]"
    if ($null -ne $Change) {
        $acknowledgementStatus = [string]$Change.acknowledgement.status
        $updateStatus = [string]$Change.documentationUpdate.status
        if ($matchedEntries.Count -eq 0 -or $acknowledgementStatus -eq "not_acknowledged" -or $updateStatus -eq "required") {
            $gateStatus = "fail"
        }
        elseif ($acknowledgementStatus -eq "acknowledged" -and $updateStatus -in @("updated", "not_applicable") -and -not $identityGap) {
            $gateStatus = "pass"
        }
        else {
            $gateStatus = "pending"
        }
        if ($acknowledgementStatus -ne "acknowledged") {
            $gateFollowUps.Add("Record acknowledgement.status as acknowledged with evidence before documentation release.") | Out-Null
        }
        if ($updateStatus -notin @("updated", "not_applicable")) {
            $gateFollowUps.Add("Record documentationUpdate.status as updated or not_applicable with affected UIDs and areas before documentation release.") | Out-Null
        }
        if ($identityGap) {
            $gateFollowUps.Add("Record generated source release and package identity, or retain unknown with an explicit follow-up.") | Out-Null
        }
    }

    if ($targetedCheckIds.Count -eq 0) {
        Add-UniqueString -List $targetedCheckIds -Value "dependency-map"
    }

    $checkRecords = New-Object "System.Collections.Generic.List[object]"
    foreach ($checkId in @($targetedCheckIds | Sort-Object)) {
        $check = @($Map.checks | Where-Object { [string]$_.id -eq $checkId } | Select-Object -First 1)
        if ($check.Count -eq 0) {
            continue
        }
        $checkRecords.Add([ordered]@{
            id = [string]$check[0].id
            label = [string]$check[0].label
            command = [string]$check[0].command
            scope = [string]$check[0].scope
        }) | Out-Null
    }

    $sourceRecord = [ordered]@{
        changeId = if ($null -ne $Change) { [string]$Change.changeId } else { "repository-change" }
        repository = if ($null -ne $Change) { [string]$Change.source.repository } else { "SkylineCommunications/dataminer-docs" }
        pullRequest = if ($null -ne $Change) { [string]$Change.source.pullRequest } else { "unknown" }
        revision = if ($null -ne $Change) { [string]$Change.source.revision } else { "unknown" }
        release = if ($null -ne $Change) { [string]$Change.source.release } else { "unknown" }
        package = [ordered]@{
            id = if ($null -ne $Change) { [string]$Change.source.package.id } else { "unknown" }
            version = if ($null -ne $Change) { [string]$Change.source.package.version } else { "unknown" }
        }
    }

    $gate = [ordered]@{
        id = "documentation-release-gate"
        status = $gateStatus
        acknowledgement = if ($null -ne $Change) { [string]$Change.acknowledgement.status } else { "not_applicable" }
        documentationUpdate = if ($null -ne $Change) { [string]$Change.documentationUpdate.status } else { "not_applicable" }
        productReleaseStatus = "unknown"
        followUps = @($gateFollowUps.ToArray())
    }

    return [ordered]@{
        schemaVersion = 1
        policy = "D6.2"
        visibility = "repository-metadata"
        source = $sourceRecord
        changedPaths = @($normalizedPaths | Sort-Object)
        affectedDocumentation = [ordered]@{
            uids = @($targetedUids | Sort-Object)
            areas = @($targetedAreas | Sort-Object)
            paths = @($targetedPaths | Sort-Object)
        }
        matchedEntries = @($matchedEntries | Sort-Object id)
        targetedChecks = @($checkRecords.ToArray() | Sort-Object id)
        documentationReleaseGate = $gate
        summary = [ordered]@{
            mapEntries = @($Map.entries).Count
            matchedEntries = $matchedEntries.Count
            unmatchedEntries = @($Map.entries).Count - $matchedEntries.Count
            changedPaths = $normalizedPaths.Count
            targetedPaths = $targetedPaths.Count
            targetedUids = $targetedUids.Count
            targetedAreas = $targetedAreas.Count
            targetedChecks = $checkRecords.Count
            gaps = $gaps.Count
            gateStatus = $gateStatus
        }
        gaps = @($gaps.ToArray())
        unresolved = @(
            $Map.followUps |
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
}

Export-ModuleMember -Function @(
    "Assert-Condition",
    "Assert-MapContract",
    "Assert-ChangeContract",
    "ConvertTo-RepositoryRelativePath",
    "Get-StringArray",
    "Read-JsonDocument",
    "Write-JsonDocument",
    "Get-ChangedPathsFromGit",
    "Resolve-CouplingReport"
)
