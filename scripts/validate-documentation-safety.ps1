[CmdletBinding()]
param(
    [string]$RepositoryRoot = (Join-Path $PSScriptRoot ".."),
    [string]$AuthorityRoot,
    [string]$RulesPath = (Join-Path $PSScriptRoot "d4-4-documentation-safety-rules.json"),
    [string]$ReportPath = (Join-Path $PSScriptRoot "..\_artifacts\d4-4-documentation-safety-report.json"),
    [string]$BaseRevision,
    [string[]]$Path,
    [switch]$IncludeAllSource,
    [switch]$IncludeSite,
    [switch]$FailOnGaps
)

Set-StrictMode -Version 2.0
$ErrorActionPreference = "Stop"

$script:RepoRoot = $null
$script:Rules = $null
$script:GeneratedSourceMap = $null
$script:SourceUnchangedCache = @{}
$script:TextExtensions = @(
    ".cmd",
    ".config",
    ".cs",
    ".csproj",
    ".htm",
    ".html",
    ".json",
    ".md",
    ".props",
    ".ps1",
    ".py",
    ".sh",
    ".targets",
    ".txt",
    ".xml",
    ".yaml",
    ".yml"
)

function ConvertTo-FullPath {
    param([Parameter(Mandatory = $true)][string]$Value)

    if ([IO.Path]::IsPathRooted($Value)) {
        return [IO.Path]::GetFullPath($Value)
    }

    return [IO.Path]::GetFullPath((Join-Path (Get-Location).Path $Value))
}

function ConvertTo-RepositoryRelativePath {
    param([Parameter(Mandatory = $true)][string]$Value)

    $fullPath = [IO.Path]::GetFullPath($Value)
    $prefix = $script:RepoRoot.TrimEnd("\") + "\"
    if (-not $fullPath.StartsWith($prefix, [StringComparison]::OrdinalIgnoreCase)) {
        throw "Path '$Value' is outside the repository root '$script:RepoRoot'."
    }

    return $fullPath.Substring($prefix.Length).Replace("\", "/")
}

function ConvertTo-ReferencePath {
    param([Parameter(Mandatory = $true)][string]$Value)

    $fullPath = [IO.Path]::GetFullPath($Value)
    $repositoryPrefix = $script:RepoRoot.TrimEnd("\") + "\"
    if ($fullPath.StartsWith($repositoryPrefix, [StringComparison]::OrdinalIgnoreCase)) {
        return $fullPath.Substring($repositoryPrefix.Length).Replace("\", "/")
    }

    $authorityPrefix = $script:AuthorityRoot.TrimEnd("\") + "\"
    if ($fullPath.StartsWith($authorityPrefix, [StringComparison]::OrdinalIgnoreCase)) {
        return $fullPath.Substring($authorityPrefix.Length).Replace("\", "/")
    }

    return "[external]"
}

function Normalize-Text {
    param([AllowEmptyString()][string]$Text)

    if ($null -eq $Text) {
        return ""
    }

    return [Regex]::Replace($Text, "`r`n?", "`n")
}

function Get-JsonArray {
    param($Value)

    if ($null -eq $Value) {
        return @()
    }

    return @($Value)
}

function Get-ConfiguredRules {
    param([Parameter(Mandatory = $true)][string]$RuleSet)

    if ($null -eq $script:Rules.rules) {
        return @()
    }

    return @(Get-JsonArray $script:Rules.rules.$RuleSet)
}

function Test-TextFile {
    param([Parameter(Mandatory = $true)][string]$Path)

    return $script:TextExtensions -contains ([IO.Path]::GetExtension($Path).ToLowerInvariant())
}

function Test-PathGlob {
    param(
        [Parameter(Mandatory = $true)][string]$RelativePath,
        [Parameter(Mandatory = $true)][string]$Glob
    )

    $escaped = [Regex]::Escape($Glob.Replace("\", "/"))
    $escaped = $escaped.Replace("\*\*", ".*").Replace("\*", "[^/]*").Replace("\?", "[^/]")
    return $RelativePath -match ("(?i)^" + $escaped + "$")
}

function Get-FileScope {
    param([Parameter(Mandatory = $true)][string]$RelativePath)

    $normalized = $RelativePath.Replace("\", "/")
    if ($normalized -match "(?i)(^|/)internal-only-topic-packs(/|$)") {
        return "internal-only-generated-artifact"
    }
    if ($normalized -match "(?i)^_artifacts/|^_site/") {
        return "generated-artifact"
    }
    return "source"
}

function Get-SourceMarkdownPaths {
    param([Parameter(Mandatory = $true)][bool]$AllSource)

    if (-not $AllSource) {
        $revision = $BaseRevision
        if ([String]::IsNullOrWhiteSpace($revision)) {
            $revision = "HEAD^"
        }

        $diffPaths = @(& git -C $script:RepoRoot diff --name-only --diff-filter=ACMR "$revision" HEAD -- "*.md" 2>$null)
        if ($LASTEXITCODE -ne 0) {
            throw "Unable to determine changed Markdown files relative to '$revision'."
        }

        $paths = @()
        foreach ($diffPath in $diffPaths) {
            $relative = ([string]$diffPath).Replace("\", "/").Trim()
            if ([String]::IsNullOrWhiteSpace($relative)) {
                continue
            }

            $candidate = Join-Path $script:RepoRoot $relative.Replace("/", "\")
            if (Test-Path -LiteralPath $candidate -PathType Leaf) {
                $paths += [IO.Path]::GetFullPath($candidate)
            }
        }
        return @($paths | Sort-Object -Unique)
    }

    $paths = @()
    $rootMarkdown = Get-ChildItem -LiteralPath $script:RepoRoot -File -Filter "*.md"
    $paths += @($rootMarkdown | ForEach-Object { $_.FullName })
    foreach ($directoryName in @("contributing", "dataminer", "develop", "release-notes", "solutions", "tutorials")) {
        $directoryPath = Join-Path $script:RepoRoot $directoryName
        if (Test-Path -LiteralPath $directoryPath -PathType Container) {
            $paths += @(Get-ChildItem -LiteralPath $directoryPath -Recurse -File -Filter "*.md" |
                    ForEach-Object { $_.FullName })
        }
    }
    return @($paths | Sort-Object -Unique)
}

function Get-GeneratedPaths {
    param([bool]$IncludeSite = $false)

    $paths = @()
    $relativeRoots = @("_artifacts")
    if ($IncludeSite) {
        $relativeRoots += "_site"
    }
    foreach ($relativeRoot in $relativeRoots) {
        $root = Join-Path $script:RepoRoot $relativeRoot
        if (-not (Test-Path -LiteralPath $root -PathType Container)) {
            continue
        }

        $paths += @(Get-ChildItem -LiteralPath $root -Recurse -File |
                Where-Object { Test-TextFile -Path $_.FullName } |
                ForEach-Object { $_.FullName })
    }
    return @($paths | Sort-Object -Unique)
}

function Initialize-GeneratedSourceMap {
    $map = @{}
    $manifestPath = Join-Path $script:RepoRoot "_artifacts\internal-only-topic-packs\internal-only-topic-pack-manifest.json"
    if (Test-Path -LiteralPath $manifestPath -PathType Leaf) {
        $manifest = Get-Content -LiteralPath $manifestPath -Raw | ConvertFrom-Json
        foreach ($chunk in (Get-JsonArray $manifest.chunks)) {
            if ([String]::IsNullOrWhiteSpace([string]$chunk.path) -or
                [String]::IsNullOrWhiteSpace([string]$chunk.sourcePath)) {
                continue
            }
            $artifactPath = ("_artifacts/internal-only-topic-packs/" + [string]$chunk.path).Replace("\", "/")
            $map[$artifactPath] = [string]$chunk.sourcePath
        }
    }
    $script:GeneratedSourceMap = $map
}

function Get-GeneratedSourcePath {
    param([Parameter(Mandatory = $true)][string]$RelativePath)

    if ($null -eq $script:GeneratedSourceMap) {
        Initialize-GeneratedSourceMap
    }
    if ($script:GeneratedSourceMap.ContainsKey($RelativePath)) {
        return [string]$script:GeneratedSourceMap[$RelativePath]
    }
    return $null
}

function Test-SourceUnchangedAtBase {
    param(
        [Parameter(Mandatory = $true)][string]$RelativePath,
        [AllowEmptyString()][string]$Revision
    )

    if ([String]::IsNullOrWhiteSpace($Revision)) {
        return $false
    }
    if ($script:SourceUnchangedCache.ContainsKey($RelativePath)) {
        return [bool]$script:SourceUnchangedCache[$RelativePath]
    }

    $currentPath = Join-Path $script:RepoRoot $RelativePath.Replace("/", "\")
    $baseText = Get-GitText -Revision $Revision -RelativePath $RelativePath
    $unchanged = $null -ne $baseText -and
        (Test-Path -LiteralPath $currentPath -PathType Leaf) -and
        (Normalize-Text ([IO.File]::ReadAllText($currentPath)) -eq (Normalize-Text $baseText))
    $script:SourceUnchangedCache[$RelativePath] = $unchanged
    return $unchanged
}

function Get-SelectedPaths {
    if ($null -ne $Path -and $Path.Count -gt 0) {
        $paths = @()
        foreach ($requestedPath in $Path) {
            $candidate = if ([IO.Path]::IsPathRooted($requestedPath)) {
                [IO.Path]::GetFullPath($requestedPath)
            }
            else {
                [IO.Path]::GetFullPath((Join-Path $script:RepoRoot $requestedPath))
            }

            if (Test-Path -LiteralPath $candidate -PathType Container) {
                $paths += @(Get-ChildItem -LiteralPath $candidate -Recurse -File |
                        Where-Object { Test-TextFile -Path $_.FullName } |
                        ForEach-Object { $_.FullName })
            }
            elseif (Test-Path -LiteralPath $candidate -PathType Leaf) {
                if (-not (Test-TextFile -Path $candidate)) {
                    throw "Safety gate path '$requestedPath' is not a supported text file."
                }
                $paths += $candidate
            }
            else {
                throw "Safety gate path '$requestedPath' does not exist."
            }
        }
        return @($paths | Sort-Object -Unique)
    }

    return @((Get-SourceMarkdownPaths -AllSource $IncludeAllSource.IsPresent) +
        (Get-GeneratedPaths -IncludeSite $IncludeSite.IsPresent) | Sort-Object -Unique)
}

function Get-GitText {
    param(
        [Parameter(Mandatory = $true)][string]$Revision,
        [Parameter(Mandatory = $true)][string]$RelativePath
    )

    $output = @(& git -C $script:RepoRoot show "$Revision`:$RelativePath" 2>$null)
    if ($LASTEXITCODE -ne 0) {
        return $null
    }
    return ($output -join "`n")
}

function Get-FrontMatter {
    param([Parameter(Mandatory = $true)][string]$Text)

    $match = [Regex]::Match(
        (Normalize-Text $Text),
        "\A---\n(?<front>.*?)\n---(?:\n|\z)",
        [Text.RegularExpressions.RegexOptions]::Singleline
    )
    if (-not $match.Success) {
        return ""
    }
    return $match.Groups["front"].Value
}

function Get-FrontMatterValue {
    param(
        [Parameter(Mandatory = $true)][AllowEmptyString()][string]$FrontMatter,
        [Parameter(Mandatory = $true)][string]$Name
    )

    if ([String]::IsNullOrWhiteSpace($FrontMatter)) {
        return ""
    }
    $match = [Regex]::Match(
        (Normalize-Text $FrontMatter),
        "(?mi)^" + [Regex]::Escape($Name) + "\s*:\s*(?<value>.*)$"
    )
    if (-not $match.Success) {
        return ""
    }

    $value = $match.Groups["value"].Value.Trim()
    if ($value.Length -ge 2 -and $value.StartsWith('"') -and $value.EndsWith('"')) {
        return $value.Substring(1, $value.Length - 2)
    }
    if ($value.Length -ge 2 -and $value.StartsWith("'") -and $value.EndsWith("'")) {
        return $value.Substring(1, $value.Length - 2).Replace("''", "'")
    }
    return $value
}

function ConvertTo-Context {
    param([AllowEmptyString()][string]$Value)

    if ([String]::IsNullOrWhiteSpace($Value)) {
        return ""
    }

    $normalized = $Value.Trim().ToLowerInvariant()
    switch ($normalized) {
        "complete" { return "executable" }
        "compilable" { return "executable" }
        "executable" { return "executable" }
        "fragment" { return "fragment" }
        "pseudocode" { return "pseudocode" }
        "illustrative" { return "illustrative" }
        "example" { return "illustrative" }
        "user" { return "user-supplied" }
        "user-supplied" { return "user-supplied" }
        "legacy" { return "legacy" }
        "conditional" { return "conditional" }
        "negative-example" { return "negative-example" }
        "ui-label" { return "ui-label" }
        "instruction" { return "instruction" }
        default { return "" }
    }
}

function Get-MetadataMarker {
    param([Parameter(Mandatory = $true)][AllowEmptyString()][string]$Line)

    $match = [Regex]::Match($Line, "(?i)documentation-safety\s*:\s*(?<body>.*?)(?:-->|$)")
    if (-not $match.Success) {
        return $null
    }

    $context = ""
    $ruleId = ""
    foreach ($part in $match.Groups["body"].Value.Split(";")) {
        $pair = $part.Trim() -split "=", 2
        if ($pair.Count -ne 2) {
            continue
        }
        $key = $pair[0].Trim().ToLowerInvariant()
        $value = $pair[1].Trim()
        if ($key -eq "context") {
            $context = ConvertTo-Context $value
        }
        elseif ($key -eq "rule") {
            $ruleId = $value
        }
    }

    return [PSCustomObject]@{
        context = $context
        ruleId = $ruleId
    }
}

function Get-ExampleContext {
    param([Parameter(Mandatory = $true)][AllowEmptyString()][string]$Text)

    $marker = Get-MetadataMarker -Line $Text
    if ($null -ne $marker -and -not [String]::IsNullOrWhiteSpace($marker.context)) {
        return $marker.context
    }

    $match = [Regex]::Match(
        $Text,
        "(?i)(?:csharp|xml)-example\s*:\s*(?<kind>complete|compilable|fragment|pseudocode|illustrative)"
    )
    if ($match.Success) {
        return ConvertTo-Context $match.Groups["kind"].Value
    }

    $infoMatch = [Regex]::Match(
        $Text,
        "(?i)(?:^|\s)(?:example|context|content)=?(?<kind>complete|compilable|fragment|pseudocode|illustrative|user-supplied|legacy|conditional|negative-example)(?:\s|$)"
    )
    if ($infoMatch.Success) {
        return ConvertTo-Context $infoMatch.Groups["kind"].Value
    }
    return ""
}

function Get-ExampleRuleId {
    param([Parameter(Mandatory = $true)][AllowEmptyString()][string]$Text)

    $marker = Get-MetadataMarker -Line $Text
    if ($null -ne $marker) {
        return [string]$marker.ruleId
    }
    return ""
}

function Get-ContextWindow {
    param(
        [Parameter(Mandatory = $true)][AllowEmptyCollection()][AllowEmptyString()][string[]]$Lines,
        [Parameter(Mandatory = $true)][int]$Index
    )

    $start = [Math]::Max(0, $Index - 2)
    $end = [Math]::Min($Lines.Count - 1, $Index + 2)
    if ($end -lt $start) {
        return ""
    }
    return (($Lines[$start..$end]) -join "`n")
}

function Get-AllowlistId {
    param(
        [Parameter(Mandatory = $true)][string]$RuleId,
        [Parameter(Mandatory = $true)][string]$RelativePath,
        [Parameter(Mandatory = $true)][string]$Classification,
        [Parameter(Mandatory = $true)][string]$ContextWindow,
        [AllowEmptyString()][string]$MarkerRuleId,
        [bool]$ExplicitContext = $false,
        $Rule
    )

    if ($Classification -eq "negative-example") {
        foreach ($negativeExample in (Get-JsonArray $script:Rules.negativeExamples)) {
            $ruleIds = @($negativeExample.ruleIds | ForEach-Object { [string]$_ })
            if ($ruleIds -contains $RuleId -and
                ([String]::IsNullOrWhiteSpace($MarkerRuleId) -or $MarkerRuleId -eq $RuleId)) {
                return [string]$negativeExample.id
            }
        }
    }

    foreach ($allowlist in (Get-JsonArray $script:Rules.allowlists)) {
        $ruleIds = @($allowlist.ruleIds | ForEach-Object { [string]$_ })
        if ($ruleIds -notcontains $RuleId) {
            continue
        }

        $pathMatches = $false
        foreach ($glob in (Get-JsonArray $allowlist.pathGlobs)) {
            if (Test-PathGlob -RelativePath $RelativePath -Glob ([string]$glob)) {
                $pathMatches = $true
                break
            }
        }
        if (-not $pathMatches) {
            continue
        }

        $contexts = @($allowlist.contexts | ForEach-Object { [string]$_ })
        $contextMatches = $contexts.Count -eq 0 -or $contexts -contains $Classification
        $linePatterns = @()
        if ($allowlist.PSObject.Properties.Name -contains "linePatterns") {
            $linePatterns = @(Get-JsonArray $allowlist.linePatterns)
        }
        $hasLinePatterns = @($linePatterns).Count -gt 0
        $lineMatches = $true
        if ($hasLinePatterns) {
            $lineMatches = $false
            foreach ($linePattern in @($linePatterns)) {
                if ([Regex]::IsMatch($ContextWindow, [string]$linePattern)) {
                    $lineMatches = $true
                    break
                }
            }
        }

        if ($ExplicitContext -and $contextMatches) {
            return [string]$allowlist.id
        }
        if ($hasLinePatterns -and $lineMatches -and
            ($contextMatches -or $Classification -in @("instruction", "unclassified"))) {
            return [string]$allowlist.id
        }
        if ($contextMatches -and $lineMatches) {
            return [string]$allowlist.id
        }
        continue
    }

    if ($null -ne $Rule -and $Rule.PSObject.Properties.Name -contains "allowContexts") {
        $allowContexts = @($Rule.allowContexts | ForEach-Object { [string]$_ })
        if ($allowContexts -contains $Classification) {
            return "rule-context-$Classification"
        }
    }

    return $null
}

function Test-Placeholder {
    param(
        [Parameter(Mandatory = $true)]$Rule,
        [Parameter(Mandatory = $true)][string]$Value
    )

    if ($Rule.PSObject.Properties.Name -notcontains "placeholderPatterns") {
        return $false
    }
    foreach ($pattern in (Get-JsonArray $Rule.placeholderPatterns)) {
        if ([Regex]::IsMatch($Value, [string]$pattern)) {
            return $true
        }
    }
    return $false
}

function Get-MatchValue {
    param(
        [Parameter(Mandatory = $true)]$Rule,
        [Parameter(Mandatory = $true)][Text.RegularExpressions.Match]$Match
    )

    if ($Rule.PSObject.Properties.Name -contains "redact" -and [bool]$Rule.redact) {
        return "[redacted]"
    }
    $value = $Match.Value.Trim()
    if ($value.Length -gt 120) {
        return $value.Substring(0, 120)
    }
    return $value
}

function Get-TextHash {
    param([AllowEmptyString()][string]$Text)

    $sha256 = [Security.Cryptography.SHA256]::Create()
    try {
        $bytes = [Text.Encoding]::UTF8.GetBytes($Text)
        return ([BitConverter]::ToString($sha256.ComputeHash($bytes))).Replace("-", "").ToLowerInvariant()
    }
    finally {
        $sha256.Dispose()
    }
}

function New-Finding {
    param(
        [Parameter(Mandatory = $true)][string]$RuleId,
        [Parameter(Mandatory = $true)][string]$Category,
        [Parameter(Mandatory = $true)][string]$Severity,
        [Parameter(Mandatory = $true)][string]$RelativePath,
        [Parameter(Mandatory = $true)][int]$Line,
        [Parameter(Mandatory = $true)][int]$Column,
        [Parameter(Mandatory = $true)][string]$Classification,
        [Parameter(Mandatory = $true)][string]$Scope,
        [Parameter(Mandatory = $true)][string]$Value,
        [Parameter(Mandatory = $true)][string]$Details,
        [AllowEmptyString()][string]$AllowlistId
    )

    $identity = ("{0}|{1}|{2}|{3}" -f $RelativePath, $RuleId, $Value, $Classification).ToLowerInvariant()
    return [PSCustomObject][ordered]@{
        id = "$RuleId-$Line-$Column"
        ruleId = $RuleId
        category = $Category
        severity = $Severity
        status = "new"
        path = $RelativePath
        line = $Line
        column = $Column
        classification = $Classification
        scope = $Scope
        value = $Value
        details = $Details
        identity = $identity
        allowlistId = if ([String]::IsNullOrWhiteSpace($AllowlistId)) { $null } else { $AllowlistId }
    }
}

function Add-RuleFindings {
    param(
        [Parameter(Mandatory = $true)][AllowEmptyCollection()][System.Collections.Generic.List[object]]$Findings,
        [Parameter(Mandatory = $true)][AllowEmptyString()][string]$Line,
        [Parameter(Mandatory = $true)][int]$LineIndex,
        [Parameter(Mandatory = $true)][AllowEmptyCollection()][AllowEmptyString()][string[]]$Lines,
        [Parameter(Mandatory = $true)][string]$RelativePath,
        [Parameter(Mandatory = $true)][string]$Classification,
        [Parameter(Mandatory = $true)][string]$Scope,
        [Parameter(Mandatory = $true)][string]$Category,
        [Parameter(Mandatory = $true)]$Rule,
        [Parameter(Mandatory = $true)][hashtable]$BaselineKeys,
        [AllowEmptyString()][string]$MarkerRuleId,
        [bool]$ExplicitContext = $false
    )

    $matches = @([Regex]::Matches($Line, [string]$Rule.pattern))
    foreach ($match in $matches) {
        $matchValue = Get-MatchValue -Rule $Rule -Match $match
        $allowlistId = Get-AllowlistId `
            -RuleId ([string]$Rule.id) `
            -RelativePath $RelativePath `
            -Classification $Classification `
            -ContextWindow (Get-ContextWindow -Lines $Lines -Index $LineIndex) `
            -MarkerRuleId $MarkerRuleId `
            -ExplicitContext $ExplicitContext `
            -Rule $Rule

        if ([string]$Rule.id -eq "credential-assignment" -and
            $match.Groups["credential"].Success -and
            (Test-Placeholder -Rule $Rule -Value $match.Groups["credential"].Value)) {
            $allowlistId = "placeholder-credential"
        }

        $finding = New-Finding `
            -RuleId ([string]$Rule.id) `
            -Category $Category `
            -Severity ([string]$Rule.severity) `
            -RelativePath $RelativePath `
            -Line ($LineIndex + 1) `
            -Column ($match.Index + 1) `
            -Classification $Classification `
            -Scope $Scope `
            -Value $matchValue `
            -Details ([string]$Rule.message) `
            -AllowlistId $allowlistId

        if (-not [String]::IsNullOrWhiteSpace($allowlistId)) {
            $finding.status = "allowlisted"
        }
        elseif ($BaselineKeys.ContainsKey($finding.identity)) {
            $finding.status = "legacy_exception"
        }
        $Findings.Add($finding) | Out-Null
    }
}

function New-Gap {
    param(
        [Parameter(Mandatory = $true)][string]$RelativePath,
        [Parameter(Mandatory = $true)][int]$Line,
        [Parameter(Mandatory = $true)][string]$Classification,
        [Parameter(Mandatory = $true)][string]$Message,
        [Parameter(Mandatory = $true)][string]$Fingerprint
    )

    $identity = ("{0}|unclassified-code-block|{1}" -f $RelativePath, $Fingerprint).ToLowerInvariant()
    return [PSCustomObject][ordered]@{
        id = "unclassified-code-block-$($Fingerprint.Substring(0, 12))"
        kind = "unclassified-code-block"
        status = "new"
        path = $RelativePath
        line = $Line
        classification = $Classification
        message = $Message
        identity = $identity
    }
}

function Get-TextLineColumn {
    param(
        [Parameter(Mandatory = $true)][string]$Text,
        [Parameter(Mandatory = $true)][int]$Index
    )

    $prefix = $Text.Substring(0, $Index)
    $line = 1 + ([Regex]::Matches($prefix, "`n")).Count
    $lastNewLine = $prefix.LastIndexOf("`n")
    $column = $Index - $lastNewLine
    return [PSCustomObject]@{
        line = $line
        column = $column
    }
}

function Get-GeneratedSafetyScan {
    param(
        [Parameter(Mandatory = $true)][string]$Text,
        [Parameter(Mandatory = $true)][string]$RelativePath,
        [Parameter(Mandatory = $true)][string]$Scope,
        [Parameter(Mandatory = $true)][hashtable]$BaselineKeys
    )

    $normalized = Normalize-Text $Text
    $findings = New-Object "System.Collections.Generic.List[object]"
    foreach ($ruleSet in @("secrets", "unsafeDefaults")) {
        $category = if ($ruleSet -eq "secrets") { "credential_exposure" } else { "unsafe_default" }
        foreach ($rule in (Get-ConfiguredRules -RuleSet $ruleSet)) {
            if (-not [Regex]::IsMatch($normalized, [string]$rule.pattern)) {
                continue
            }

            foreach ($match in ([Regex]::Matches($normalized, [string]$rule.pattern))) {
                $position = Get-TextLineColumn -Text $normalized -Index $match.Index
                $matchValue = Get-MatchValue -Rule $rule -Match $match
                $allowlistId = $null
                if ([string]$rule.id -eq "credential-assignment" -and
                    $match.Groups["credential"].Success -and
                    (Test-Placeholder -Rule $rule -Value $match.Groups["credential"].Value)) {
                    $allowlistId = "placeholder-credential"
                }

                $finding = New-Finding `
                    -RuleId ([string]$rule.id) `
                    -Category $category `
                    -Severity ([string]$rule.severity) `
                    -RelativePath $RelativePath `
                    -Line $position.line `
                    -Column $position.column `
                    -Classification $Scope `
                    -Scope $Scope `
                    -Value $matchValue `
                    -Details ([string]$rule.message) `
                    -AllowlistId $allowlistId
                if (-not [String]::IsNullOrWhiteSpace($allowlistId)) {
                    $finding.status = "allowlisted"
                }
                elseif ($BaselineKeys.ContainsKey($finding.identity)) {
                    $finding.status = "legacy_exception"
                }
                $findings.Add($finding) | Out-Null
            }
        }
    }

    return [PSCustomObject]@{
        findings = @($findings.ToArray())
        gaps = @()
    }
}

function Get-SafetyScan {
    param(
        [Parameter(Mandatory = $true)][string]$Text,
        [Parameter(Mandatory = $true)][string]$RelativePath,
        [Parameter(Mandatory = $true)][string]$Scope,
        [Parameter(Mandatory = $true)][hashtable]$BaselineKeys,
        [switch]$NoStatus
    )

    if ($Scope -ne "source") {
        return Get-GeneratedSafetyScan `
            -Text $Text `
            -RelativePath $RelativePath `
            -Scope $Scope `
            -BaselineKeys $BaselineKeys
    }

    $normalized = Normalize-Text $Text
    $lines = @($normalized -split "`n")
    $frontMatter = Get-FrontMatter -Text $normalized
    $pageContext = [string]$script:Rules.classification.defaultProse
    foreach ($mapping in (Get-JsonArray $script:Rules.classification.frontMatterMappings)) {
        $value = Get-FrontMatterValue -FrontMatter $frontMatter -Name ([string]$mapping.field)
        if ($value -eq [string]$mapping.value) {
            $pageContext = [string]$mapping.context
            break
        }
    }

    $findings = New-Object "System.Collections.Generic.List[object]"
    $gaps = New-Object "System.Collections.Generic.List[object]"
    $inFence = $false
    $fenceCharacter = ""
    $blockContext = ""
    $blockRuleId = ""
    $blockStart = 0
    $blockExplicitContext = $false
    $pendingMarker = $null
    $lineClassifications = New-Object object[] $lines.Count
    $lineExplicitContexts = New-Object bool[] $lines.Count

    for ($index = 0; $index -lt $lines.Count; $index++) {
        $line = $lines[$index]
        $fenceMatch = [Regex]::Match($line, '^\s*(?<fence>`{3,}|~{3,})(?<info>.*)$')
        if ($fenceMatch.Success) {
            $character = $fenceMatch.Groups["fence"].Value.Substring(0, 1)
            if (-not $inFence) {
                $inFence = $true
                $fenceCharacter = $character
                $blockStart = $index
                $marker = Get-MetadataMarker -Line $line
                $blockContext = if ($null -ne $marker -and -not [String]::IsNullOrWhiteSpace($marker.context)) {
                    $marker.context
                }
                else {
                    $infoContext = Get-ExampleContext -Text $fenceMatch.Groups["info"].Value
                    $previousExampleContext = if ($index -gt 0) {
                        Get-ExampleContext -Text $lines[$index - 1]
                    }
                    else {
                        ""
                    }
                    if (-not [String]::IsNullOrWhiteSpace($infoContext)) { $infoContext }
                    elseif (-not [String]::IsNullOrWhiteSpace($previousExampleContext)) { $previousExampleContext }
                    elseif ($null -ne $pendingMarker -and -not [String]::IsNullOrWhiteSpace($pendingMarker.context)) { $pendingMarker.context }
                    else { "unclassified" }
                }
                $previousExampleContext = if ($index -gt 0) {
                    Get-ExampleContext -Text $lines[$index - 1]
                }
                else {
                    ""
                }
                $explicitBlockContext = ($null -ne $marker -and -not [String]::IsNullOrWhiteSpace($marker.context)) -or
                    -not [String]::IsNullOrWhiteSpace((Get-ExampleContext -Text $fenceMatch.Groups["info"].Value)) -or
                    -not [String]::IsNullOrWhiteSpace($previousExampleContext) -or
                    ($null -ne $pendingMarker -and -not [String]::IsNullOrWhiteSpace($pendingMarker.context))
                $blockExplicitContext = $explicitBlockContext
                $blockRuleId = if ($null -ne $marker) { [string]$marker.ruleId }
                elseif ($null -ne $pendingMarker) { [string]$pendingMarker.ruleId }
                else { Get-ExampleRuleId -Text $fenceMatch.Groups["info"].Value }

                if ($blockContext -eq "unclassified") {
                    $fingerprintEnd = [Math]::Min($lines.Count - 1, $index + 8)
                    $fingerprint = Get-TextHash -Text (($lines[$index..$fingerprintEnd]) -join "`n")
                    $gaps.Add((New-Gap `
                            -RelativePath $RelativePath `
                            -Line ($index + 1) `
                            -Classification $blockContext `
                            -Message "Code block has no executable, illustrative, fragment, pseudocode, or user-supplied classification metadata." `
                            -Fingerprint $fingerprint)) | Out-Null
                }
                $lineClassifications[$index] = $blockContext
                $lineExplicitContexts[$index] = $explicitBlockContext
                $pendingMarker = $null
            }
            elseif ($fenceCharacter -eq $character) {
                $lineClassifications[$index] = $blockContext
                $lineExplicitContexts[$index] = $true
                $inFence = $false
                $fenceCharacter = ""
                $blockContext = ""
                $blockRuleId = ""
                $blockExplicitContext = $false
                $blockStart = 0
            }
            continue
        }

        $marker = Get-MetadataMarker -Line $line
        $exampleContext = Get-ExampleContext -Text $line
        if (-not $inFence -and $null -ne $marker) {
            $pendingMarker = $marker
        }

        $classification = if ($inFence) {
            $blockContext
        }
        elseif ($null -ne $marker -and -not [String]::IsNullOrWhiteSpace($marker.context)) {
            $marker.context
        }
        elseif (-not [String]::IsNullOrWhiteSpace($exampleContext)) {
            $exampleContext
        }
        elseif ($null -ne $pendingMarker -and -not [String]::IsNullOrWhiteSpace($pendingMarker.context)) {
            $pendingMarker.context
        }
        else {
            $pageContext
        }
        $lineClassifications[$index] = $classification
        $lineExplicitContexts[$index] = if ($inFence) {
            $blockExplicitContext
        }
        else {
            ($null -ne $marker -and -not [String]::IsNullOrWhiteSpace($marker.context)) -or
                -not [String]::IsNullOrWhiteSpace($exampleContext) -or
                ($null -ne $pendingMarker -and -not [String]::IsNullOrWhiteSpace($pendingMarker.context))
        }

        foreach ($ruleSet in @("prohibitedStrings", "terminology", "secrets", "unsafeDefaults")) {
            $category = switch ($ruleSet) {
                "prohibitedStrings" { "obsolete_guidance" }
                "terminology" { "canonical_terminology" }
                "secrets" { "credential_exposure" }
                "unsafeDefaults" { "unsafe_default" }
            }
            foreach ($rule in (Get-ConfiguredRules -RuleSet $ruleSet)) {
                Add-RuleFindings `
                    -Findings $findings `
                    -Line $line `
                    -LineIndex $index `
                    -Lines $lines `
                    -RelativePath $RelativePath `
                    -Classification $classification `
                    -Scope $Scope `
                    -Category $category `
                    -Rule $rule `
                    -BaselineKeys $BaselineKeys `
                    -MarkerRuleId $blockRuleId `
                    -ExplicitContext $lineExplicitContexts[$index]
            }
        }

        if (-not $inFence -and $null -ne $pendingMarker -and
            [String]::IsNullOrWhiteSpace($line.Trim()) -eq $false -and
            $null -eq $marker) {
            $pendingMarker = $null
        }
    }

    foreach ($rule in (Get-ConfiguredRules -RuleSet "normativeConflicts")) {
        $claimOccurrences = @{}
        foreach ($claim in (Get-JsonArray $rule.claims)) {
            $claimOccurrences[[string]$claim.id] = New-Object "System.Collections.Generic.List[object]"
        }
        for ($index = 0; $index -lt $lines.Count; $index++) {
            $line = $lines[$index]
            $classification = if ($null -eq $lineClassifications[$index]) {
                $pageContext
            }
            else {
                [string]$lineClassifications[$index]
            }
            $contextWindow = Get-ContextWindow -Lines $lines -Index $index
            foreach ($claim in (Get-JsonArray $rule.claims)) {
                $matches = @([Regex]::Matches($line, [string]$claim.pattern))
                foreach ($match in $matches) {
                    $allowlistId = Get-AllowlistId `
                        -RuleId ([string]$rule.id) `
                        -RelativePath $RelativePath `
                        -Classification $classification `
                        -ContextWindow $contextWindow `
                        -ExplicitContext $lineExplicitContexts[$index] `
                        -Rule $rule
                    if ([String]::IsNullOrWhiteSpace($allowlistId)) {
                        $claimOccurrences[[string]$claim.id].Add([PSCustomObject]@{
                                line = $index
                                column = $match.Index + 1
                                value = $match.Value
                            }) | Out-Null
                    }
                }
            }
        }

        $claimIds = @($rule.claims | ForEach-Object { [string]$_.id })
        if ($claimIds.Count -lt 2) {
            continue
        }
        $firstList = $claimOccurrences[[string]$claimIds[0]]
        $secondList = $claimOccurrences[[string]$claimIds[1]]
        $first = @($firstList.ToArray())
        $second = @($secondList.ToArray())
        if ($first.Count -eq 0 -or $second.Count -eq 0) {
            continue
        }
        $firstOccurrence = $first[0]
        $secondOccurrence = $second[0]
        $line = [Math]::Min([int]$firstOccurrence.line, [int]$secondOccurrence.line)
        $classification = if ($Scope -eq "source") { $pageContext } else { $Scope }
        $finding = New-Finding `
            -RuleId ([string]$rule.id) `
            -Category "normative_conflict" `
            -Severity ([string]$rule.severity) `
            -RelativePath $RelativePath `
            -Line ($line + 1) `
            -Column 1 `
            -Classification $classification `
            -Scope $Scope `
            -Value (($claimIds -join "|")) `
            -Details ([string]$rule.message) `
            -AllowlistId ""
        if (-not $NoStatus -and $BaselineKeys.ContainsKey($finding.identity)) {
            $finding.status = "legacy_exception"
        }
        $findings.Add($finding) | Out-Null
    }

    return [PSCustomObject]@{
        findings = @($findings.ToArray())
        gaps = @($gaps.ToArray())
    }
}

function Get-FindingIdentities {
    param([Parameter(Mandatory = $true)]$ScanResult)

    $keys = @{}
    foreach ($finding in (Get-JsonArray $ScanResult.findings)) {
        $keys[[string]$finding.identity] = $true
    }
    return $keys
}

function Get-GapIdentities {
    param([Parameter(Mandatory = $true)]$ScanResult)

    $keys = @{}
    foreach ($gap in (Get-JsonArray $ScanResult.gaps)) {
        $keys[[string]$gap.identity] = $true
    }
    return $keys
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
    [IO.File]::WriteAllText($Path, ($Value | ConvertTo-Json -Depth 20), $utf8NoBom)
}

function Assert-AuthoritySources {
    foreach ($source in (Get-JsonArray $script:Rules.authoritySources)) {
        $sourcePath = Join-Path $script:AuthorityRoot ([string]$source.path).Replace("/", "\")
        if (-not (Test-Path -LiteralPath $sourcePath)) {
            throw "D4.4 authority source '$($source.path)' does not exist."
        }
    }
}

$script:RepoRoot = ConvertTo-FullPath $RepositoryRoot
$script:AuthorityRoot = if ([String]::IsNullOrWhiteSpace($AuthorityRoot)) {
    $script:RepoRoot
}
else {
    ConvertTo-FullPath $AuthorityRoot
}
$RulesPath = ConvertTo-FullPath $RulesPath
$ReportPath = ConvertTo-FullPath $ReportPath
if (-not (Test-Path -LiteralPath $script:RepoRoot -PathType Container)) {
    throw "Repository root '$script:RepoRoot' does not exist."
}
if (-not (Test-Path -LiteralPath $RulesPath -PathType Leaf)) {
    throw "D4.4 rules map '$RulesPath' does not exist."
}
$script:Rules = Get-Content -LiteralPath $RulesPath -Raw | ConvertFrom-Json
if ([int]$script:Rules.schemaVersion -ne 1 -or [string]$script:Rules.format -ne "d4-4-documentation-safety-rules") {
    throw "D4.4 rules map '$RulesPath' has an unsupported schema or format."
}
Assert-AuthoritySources

if ([String]::IsNullOrWhiteSpace($BaseRevision)) {
    if (-not [String]::IsNullOrWhiteSpace($env:GITHUB_BASE_SHA)) {
        $BaseRevision = $env:GITHUB_BASE_SHA
    }
    elseif (-not [String]::IsNullOrWhiteSpace($env:GITHUB_BEFORE)) {
        $BaseRevision = $env:GITHUB_BEFORE
    }
}

$selectedPaths = @(Get-SelectedPaths)
$reportRelativePath = ConvertTo-RepositoryRelativePath $ReportPath
$selectedPaths = @($selectedPaths | Where-Object {
        (ConvertTo-RepositoryRelativePath $_) -ne $reportRelativePath
    })

$sourcePaths = @($selectedPaths | Where-Object { (Get-FileScope -RelativePath (ConvertTo-RepositoryRelativePath $_)) -eq "source" })
$generatedPaths = @($selectedPaths | Where-Object { (Get-FileScope -RelativePath (ConvertTo-RepositoryRelativePath $_)) -ne "source" })
$generatedRoots = @()
$reportedGeneratedRoots = @("_artifacts")
if ($IncludeSite) {
    $reportedGeneratedRoots += "_site"
}
foreach ($relativeRoot in $reportedGeneratedRoots) {
    if (Test-Path -LiteralPath (Join-Path $script:RepoRoot $relativeRoot) -PathType Container) {
        $generatedRoots += $relativeRoot
    }
}
$internalOnlyRoots = @()
if (Test-Path -LiteralPath (Join-Path $script:RepoRoot "_artifacts\internal-only-topic-packs") -PathType Container) {
    $internalOnlyRoots += "_artifacts/internal-only-topic-packs"
}

$allFindings = New-Object "System.Collections.Generic.List[object]"
$allGaps = New-Object "System.Collections.Generic.List[object]"
$baseFindingCache = @{}
$baseGapCache = @{}

foreach ($filePath in $selectedPaths) {
    $relativePath = ConvertTo-RepositoryRelativePath $filePath
    $scope = Get-FileScope -RelativePath $relativePath
    $text = [IO.File]::ReadAllText($filePath)
    $baselineKeys = @{}
    $baselineGapKeys = @{}

    if ($scope -eq "source" -and -not [String]::IsNullOrWhiteSpace($BaseRevision)) {
        if (-not $baseFindingCache.ContainsKey($relativePath)) {
            $baseText = Get-GitText -Revision $BaseRevision -RelativePath $relativePath
            if ($null -eq $baseText) {
                $baseFindingCache[$relativePath] = @{}
                $baseGapCache[$relativePath] = @{}
            }
            else {
                $baseScan = Get-SafetyScan `
                    -Text $baseText `
                    -RelativePath $relativePath `
                    -Scope "source" `
                    -BaselineKeys @{} `
                    -NoStatus
                $baseFindingCache[$relativePath] = Get-FindingIdentities -ScanResult $baseScan
                $baseGapCache[$relativePath] = Get-GapIdentities -ScanResult $baseScan
            }
        }
        $baselineKeys = $baseFindingCache[$relativePath]
        $baselineGapKeys = $baseGapCache[$relativePath]
    }

    $scan = Get-SafetyScan `
        -Text $text `
        -RelativePath $relativePath `
        -Scope $scope `
        -BaselineKeys $baselineKeys

    if ($scope -ne "source" -and -not [String]::IsNullOrWhiteSpace($BaseRevision)) {
        $generatedSourcePath = Get-GeneratedSourcePath -RelativePath $relativePath
        if (-not [String]::IsNullOrWhiteSpace($generatedSourcePath) -and
            (Test-SourceUnchangedAtBase -RelativePath $generatedSourcePath -Revision $BaseRevision)) {
            foreach ($finding in (Get-JsonArray $scan.findings)) {
                if ($finding.status -eq "new") {
                    $finding.status = "legacy_exception"
                }
            }
        }
    }

    foreach ($finding in (Get-JsonArray $scan.findings)) {
        $allFindings.Add($finding) | Out-Null
    }
    foreach ($gap in (Get-JsonArray $scan.gaps)) {
        if ($baselineGapKeys.ContainsKey($gap.identity)) {
            $gap.status = "pre_existing"
        }
        $allGaps.Add($gap) | Out-Null
    }
}

$categoryCounts = [ordered]@{}
foreach ($finding in @($allFindings.ToArray())) {
    $category = [string]$finding.category
    if (-not $categoryCounts.Contains($category)) {
        $categoryCounts[$category] = 0
    }
    $categoryCounts[$category] = [int]$categoryCounts[$category] + 1
}

$findings = @($allFindings.ToArray() | Sort-Object category, path, line, column, ruleId, value)
$gaps = @($allGaps.ToArray() | Sort-Object kind, path, line)
$newFindings = @($findings | Where-Object { $_.status -eq "new" })
$legacyExceptions = @($findings | Where-Object { $_.status -eq "legacy_exception" })
$allowlisted = @($findings | Where-Object { $_.status -eq "allowlisted" })
$newGaps = @($gaps | Where-Object { $_.status -eq "new" })
$preExistingGaps = @($gaps | Where-Object { $_.status -eq "pre_existing" })

$report = [ordered]@{
    schemaVersion = 1
    gate = "D4.4"
    repository = "SkylineCommunications/dataminer-docs"
    rules = [ordered]@{
        path = ConvertTo-ReferencePath $RulesPath
        schemaVersion = [int]$script:Rules.schemaVersion
        authoritySources = @($script:Rules.authoritySources | ForEach-Object { [string]$_.path })
    }
    scope = [ordered]@{
        baseRevision = if ([String]::IsNullOrWhiteSpace($BaseRevision)) { "working-tree" } else { $BaseRevision }
        sourcePaths = @($sourcePaths | ForEach-Object { ConvertTo-RepositoryRelativePath $_ })
        generatedRoots = @($generatedRoots)
        internalOnlyRoots = @($internalOnlyRoots)
    }
    checks = [ordered]@{
        authority = "Rules are sourced from the approved D0/D1 documents and D4.1-D4.3 harness contracts listed in the rules map."
        classification = "Executable, illustrative, fragment, pseudocode, user-supplied, legacy, conditional, and negative-example contexts are explicit when a marker is present; unmarked code is reported as a gap."
        identityCompatibility = "UID and URL stability remain delegated to the D4.1 gate and D0.2 inventory; this gate does not rewrite source or identity data."
        legacyPolicy = "Findings unchanged from BaseRevision remain visible as legacy_exception findings and never become silently green."
        internalOnlyPolicy = "Internal transformed packs are scanned for safety but remain outside public DocFX output and are identified as internal-only-generated-artifact."
    }
    summary = [ordered]@{
        files = $selectedPaths.Count
        findings = $findings.Count
        newFindings = $newFindings.Count
        legacyExceptions = $legacyExceptions.Count
        allowlisted = $allowlisted.Count
        gaps = $gaps.Count
        newGaps = $newGaps.Count
        preExistingGaps = $preExistingGaps.Count
        countsByCategory = $categoryCounts
    }
    findings = $findings
    gaps = $gaps
}

Write-Json -Path $ReportPath -Value $report

$failureItems = @($newFindings)
if ($FailOnGaps.IsPresent) {
    $failureItems += @($newGaps)
}
if ($failureItems.Count -gt 0) {
    $messages = @($failureItems | ForEach-Object {
            if ($_.PSObject.Properties.Name -contains "ruleId") {
                "$($_.path):$($_.line) [$($_.severity)] $($_.ruleId) $($_.details)"
            }
            else {
                "$($_.path):$($_.line) [$($_.kind)] $($_.message)"
            }
        })
    throw ("D4.4 documentation safety checks failed with {0} item(s). See '{1}'.`n - {2}" -f
        $failureItems.Count, $ReportPath, ($messages -join "`n - "))
}

$outputMessage = "D4.4 documentation safety checks passed. Scanned {0} file(s), retained {1} legacy exception(s), reported {2} allowlisted finding(s) and {3} classification gap(s), and wrote {4}." -f
    $selectedPaths.Count, $legacyExceptions.Count, $allowlisted.Count, $gaps.Count, $ReportPath
Write-Output $outputMessage
