[CmdletBinding()]
param(
    [string]$RepositoryRoot = (Join-Path $PSScriptRoot ".."),
    [string]$ConfigurationPath = (Join-Path $PSScriptRoot "..\contributing\xml-documentation-examples-v1.json"),
    [string]$OutputPath = (Join-Path $PSScriptRoot "..\_artifacts\xml-documentation-examples.json"),
    [string]$SchemaRoot = "",
    [string]$GenerationDate = "",
    [string]$SourceRevision = "",
    [switch]$RequireSchemaSources
)

Set-StrictMode -Version 2.0
$ErrorActionPreference = "Stop"

$script:GeneratorVersion = "1.0.0"
$script:SchemaVersion = 1
$script:SchemaName = "contributing/metadata/xml-documentation-examples-v1.schema.json"
$script:Repository = "SkylineCommunications/dataminer-docs"

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
    $rootPath = [IO.Path]::GetFullPath($Root).TrimEnd("\")
    $prefix = $rootPath + "\"
    if ($fullPath.StartsWith($prefix, [StringComparison]::OrdinalIgnoreCase)) {
        return $fullPath.Substring($prefix.Length).Replace("\", "/")
    }

    if ($fullPath.Equals($rootPath, [StringComparison]::OrdinalIgnoreCase)) {
        return ""
    }

    throw "Path '$Path' is outside repository root '$Root'."
}

function ConvertTo-PortablePath {
    param([Parameter(Mandatory = $true)][string]$Path)

    return $Path.Replace("\", "/")
}

function Normalize-Text {
    param([AllowEmptyString()][string]$Text)

    if ($null -eq $Text) {
        return ""
    }

    return [Regex]::Replace($Text, "`r`n?", "`n")
}

function Get-TextSha256 {
    param([AllowEmptyString()][string]$Text)

    $bytes = [Text.Encoding]::UTF8.GetBytes((Normalize-Text $Text))
    $hash = [Security.Cryptography.SHA256]::Create()
    try {
        return ([BitConverter]::ToString($hash.ComputeHash($bytes))).Replace("-", "").ToLowerInvariant()
    }
    finally {
        $hash.Dispose()
    }
}

function Get-FileSha256 {
    param([Parameter(Mandatory = $true)][string]$Path)

    return (Get-FileHash -LiteralPath $Path -Algorithm SHA256).Hash.ToLowerInvariant()
}

function Write-Json {
    param(
        [Parameter(Mandatory = $true)][string]$Path,
        [Parameter(Mandatory = $true)]$Value
    )

    $directory = Split-Path -Parent $Path
    if (-not [String]::IsNullOrWhiteSpace($directory) -and -not (Test-Path -LiteralPath $directory -PathType Container)) {
        New-Item -ItemType Directory -Path $directory -Force | Out-Null
    }

    $utf8NoBom = New-Object Text.UTF8Encoding($false)
    [IO.File]::WriteAllText($Path, (($Value | ConvertTo-Json -Depth 30) + [Environment]::NewLine), $utf8NoBom)
}

function Get-ObjectProperty {
    param(
        [Parameter(Mandatory = $true)]$Object,
        [Parameter(Mandatory = $true)][string]$Name,
        $Default = $null
    )

    if ($null -eq $Object) {
        return $Default
    }

    if ($Object -is [System.Collections.IDictionary]) {
        if ($Object.Contains($Name)) {
            return $Object[$Name]
        }
        return $Default
    }

    if (@($Object.PSObject.Properties.Name) -contains $Name) {
        return $Object.$Name
    }

    return $Default
}

function Get-StringProperty {
    param(
        [Parameter(Mandatory = $true)]$Object,
        [Parameter(Mandatory = $true)][string]$Name,
        [string]$Default = ""
    )

    $value = Get-ObjectProperty -Object $Object -Name $Name -Default $Default
    if ($null -eq $value) {
        return $Default
    }

    return [string]$value
}

function Get-ObjectArray {
    param($Value)

    if ($null -eq $Value) {
        return @()
    }

    if ($Value -is [System.Array]) {
        return @($Value)
    }

    return @($Value)
}

function Get-SourceRevision {
    param([string]$RequestedRevision)

    if (-not [String]::IsNullOrWhiteSpace($RequestedRevision)) {
        Assert-Condition ($RequestedRevision -match "^[0-9a-f]{40}$") "SourceRevision must be a 40-character lowercase commit SHA."
        return ,([ordered]@{
            value = $RequestedRevision
            source = "argument"
        })
    }

    try {
        $revision = (& git -C $script:RepositoryRoot rev-parse HEAD 2>$null).Trim()
        if ($revision -match "^[0-9a-f]{40}$") {
            return ,([ordered]@{
                value = $revision
                source = "git"
            })
        }
    }
    catch {
    }

    return ,([ordered]@{
        value = "unknown"
        source = "unknown"
    })
}

function Get-GenerationDateValue {
    param([string]$RequestedDate)

    if (-not [String]::IsNullOrWhiteSpace($RequestedDate)) {
        Assert-Condition ($RequestedDate -match "^\d{4}-\d{2}-\d{2}$") "GenerationDate must use yyyy-MM-dd format."
        return ,([ordered]@{
            value = $RequestedDate
            source = "argument"
        })
    }

    if (-not [String]::IsNullOrWhiteSpace($env:SOURCE_DATE_EPOCH)) {
        $epoch = 0L
        if ([long]::TryParse($env:SOURCE_DATE_EPOCH, [ref]$epoch)) {
            return ,([ordered]@{
                value = [DateTimeOffset]::FromUnixTimeSeconds($epoch).UtcDateTime.ToString("yyyy-MM-dd")
                source = "source_date_epoch"
            })
        }
    }

    return ,([ordered]@{
        value = "unknown"
        source = "unknown"
    })
}

function Get-PageUid {
    param([AllowEmptyCollection()][string[]]$Lines)

    $frontMatterLines = [Math]::Min($Lines.Count, 80)
    for ($index = 0; $index -lt $frontMatterLines; $index++) {
        $match = [Regex]::Match($Lines[$index], "^\s*uid:\s*(?<uid>\S.*?)\s*$")
        if ($match.Success) {
            return $match.Groups["uid"].Value
        }
    }

    return "unknown"
}

function Get-CommonIndent {
    param([AllowEmptyCollection()][string[]]$Lines)

    $indents = @(
        $Lines |
            Where-Object { -not [String]::IsNullOrWhiteSpace($_) } |
            ForEach-Object {
                ([Regex]::Match($_, "^\s*")).Value.Length
            }
    )
    if ($indents.Count -eq 0) {
        return 0
    }

    return ($indents | Measure-Object -Minimum).Minimum
}

function Remove-XmlExampleMarkerLines {
    param([Parameter(Mandatory = $true)][AllowEmptyString()][string]$Text)

    $lines = (Normalize-Text $Text) -split "`n"
    $filtered = @(
        $lines |
            Where-Object {
                $_ -notmatch "^\s*<!--\s*dataminer-xml-example\s*:\s*[^>]+-->\s*$"
            }
    )
    return ($filtered -join "`n").Trim()
}

function Get-ExampleFlags {
    param(
        [string]$FenceInfo,
        [string[]]$PriorLines,
        [string[]]$BodyLines
    )

    $tokens = New-Object System.Collections.Generic.List[string]
    foreach ($value in @($FenceInfo)) {
        if ([String]::IsNullOrWhiteSpace($value)) {
            continue
        }

        foreach ($match in [Regex]::Matches($value, "(?i)<!--\s*dataminer-xml-example\s*:\s*(?<flags>[^>]+?)-->|(?<flags>\b(?:complete|fragment|negative|expected-invalid)\b)")) {
            foreach ($flag in ($match.Groups["flags"].Value -split "[,\s]+")) {
                if (-not [String]::IsNullOrWhiteSpace($flag)) {
                    $normalized = $flag.ToLowerInvariant()
                    if (-not $tokens.Contains($normalized)) {
                        [void]$tokens.Add($normalized)
                    }
                }
            }
        }
    }

    foreach ($match in [Regex]::Matches(($PriorLines -join " "), "(?i)<!--\s*dataminer-xml-example\s*:\s*(?<flags>[^>]+?)-->")) {
        foreach ($flag in ($match.Groups["flags"].Value -split "[,\s]+")) {
            if (-not [String]::IsNullOrWhiteSpace($flag)) {
                $normalized = $flag.ToLowerInvariant()
                if (-not $tokens.Contains($normalized)) {
                    [void]$tokens.Add($normalized)
                }
            }
        }
    }

    $bodyMarkerText = (($BodyLines | Select-Object -First 2) -join " ")
    foreach ($match in [Regex]::Matches($bodyMarkerText, "(?i)<!--\s*dataminer-xml-example\s*:\s*(?<flags>[^>]+?)-->")) {
        foreach ($flag in ($match.Groups["flags"].Value -split "[,\s]+")) {
            if (-not [String]::IsNullOrWhiteSpace($flag)) {
                $normalized = $flag.ToLowerInvariant()
                if (-not $tokens.Contains($normalized)) {
                    [void]$tokens.Add($normalized)
                }
            }
        }
    }

    return @($tokens.ToArray())
}

function Get-XmlExamplesFromPage {
    param(
        [Parameter(Mandatory = $true)][string]$Path,
        [Parameter(Mandatory = $true)][string]$RelativePath,
        [Parameter(Mandatory = $true)][string]$Uid
    )

    $lines = [IO.File]::ReadAllLines($Path)
    $examples = New-Object System.Collections.Generic.List[object]
    $inFence = $false
    $fenceLine = 0
    $fenceInfo = ""
    $body = New-Object System.Collections.Generic.List[string]

    for ($index = 0; $index -lt $lines.Count; $index++) {
        $line = $lines[$index]
        if (-not $inFence) {
            $startMatch = [Regex]::Match($line, '^\s*```xml(?:\s+(?<info>.*?))?\s*$', [Text.RegularExpressions.RegexOptions]::IgnoreCase)
            if ($startMatch.Success) {
                $inFence = $true
                $fenceLine = $index + 1
                $fenceInfo = $startMatch.Groups["info"].Value
                $body.Clear()
            }
            continue
        }

        $isClosingFence = $line -match '^\s*```\s*$'
        $isUnclosedFenceAtEnd = $index -eq ($lines.Count - 1) -and -not $isClosingFence
        if ($isClosingFence -or $isUnclosedFenceAtEnd) {
            if ($isUnclosedFenceAtEnd) {
                [void]$body.Add($line)
            }
            $bodyLines = @($body.ToArray())
            $indent = Get-CommonIndent -Lines $bodyLines
            $normalizedLines = @(
                $bodyLines |
                    ForEach-Object {
                        if ($indent -gt 0 -and $_.Length -ge $indent) {
                            $_.Substring($indent)
                        }
                        else {
                            $_
                        }
                    }
            )
            $sourceStart = $fenceLine + 1
            $sourceEnd = [Math]::Max($sourceStart, $index)
            $priorStart = [Math]::Max(0, $fenceLine - 4)
            $priorLines = @($lines[$priorStart..($fenceLine - 2)])
            $flags = Get-ExampleFlags -FenceInfo $fenceInfo -PriorLines $priorLines -BodyLines $normalizedLines
            [void]$examples.Add([pscustomobject]@{
                RelativePath = ConvertTo-PortablePath $RelativePath
                Uid = $Uid
                FenceLine = $fenceLine
                StartLine = $sourceStart
                EndLine = $sourceEnd
                Lines = $normalizedLines
                Text = ($normalizedLines -join "`n")
                Flags = $flags
                UnclosedFence = $isUnclosedFenceAtEnd
            })
            $inFence = $false
            continue
        }

        [void]$body.Add($line)
    }

    return @($examples.ToArray())
}

function Read-XmlDocument {
    param([Parameter(Mandatory = $true)][AllowEmptyString()][string]$Text)

    $document = New-Object System.Xml.XmlDocument
    $document.PreserveWhitespace = $true
    $document.XmlResolver = $null
    try {
        $document.LoadXml($Text)
        return [pscustomobject]@{
            Success = $true
            Document = $document
            Message = ""
        }
    }
    catch {
        return [pscustomobject]@{
            Success = $false
            Document = $null
            Message = $_.Exception.Message
        }
    }
}

function Repair-XmlFragment {
    param(
        [Parameter(Mandatory = $true)][AllowEmptyString()][string]$Text,
        [Parameter(Mandatory = $true)][bool]$AllowOpenElementsAtEnd
    )

    $normalized = Remove-XmlExampleMarkerLines -Text $Text
    $normalized = [Regex]::Replace($normalized, "^\s*<\?xml.*?\?>\s*", "", [Text.RegularExpressions.RegexOptions]::Singleline)
    $normalized = [Regex]::Replace($normalized, "(?m)^\s*\.\.\.\s*$", "")
    $stack = New-Object System.Collections.Generic.List[string]
    $index = 0

    while ($index -lt $normalized.Length) {
        if ($normalized[$index] -ne "<") {
            $index++
            continue
        }

        $remaining = $normalized.Substring($index)
        if ($remaining.StartsWith("<!--", [StringComparison]::Ordinal)) {
            $endComment = $normalized.IndexOf("-->", $index + 4, [StringComparison]::Ordinal)
            if ($endComment -lt 0) {
                return [pscustomobject]@{
                    Success = $false
                    Text = $normalized
                    Repaired = $false
                    Message = "The fragment contains an unterminated XML comment."
                }
            }
            $index = $endComment + 3
            continue
        }

        if ($remaining.StartsWith("<![CDATA[", [StringComparison]::Ordinal)) {
            $endCdata = $normalized.IndexOf("]]>", $index + 9, [StringComparison]::Ordinal)
            if ($endCdata -lt 0) {
                return [pscustomobject]@{
                    Success = $false
                    Text = $normalized
                    Repaired = $false
                    Message = "The fragment contains an unterminated CDATA section."
                }
            }
            $index = $endCdata + 3
            continue
        }

        if ($remaining.StartsWith("<?", [StringComparison]::Ordinal)) {
            $endInstruction = $normalized.IndexOf("?>", $index + 2, [StringComparison]::Ordinal)
            if ($endInstruction -lt 0) {
                return [pscustomobject]@{
                    Success = $false
                    Text = $normalized
                    Repaired = $false
                    Message = "The fragment contains an unterminated processing instruction."
                }
            }
            $index = $endInstruction + 2
            continue
        }

        $endTag = $index + 1
        $quote = [char]0
        while ($endTag -lt $normalized.Length) {
            $character = $normalized[$endTag]
            if ($quote -ne [char]0) {
                if ($character -eq $quote) {
                    $quote = [char]0
                }
            }
            elseif ($character -eq '"' -or $character -eq "'") {
                $quote = $character
            }
            elseif ($character -eq ">") {
                break
            }
            $endTag++
        }

        if ($endTag -ge $normalized.Length) {
            return [pscustomobject]@{
                Success = $false
                Text = $normalized
                Repaired = $false
                Message = "The fragment contains an unterminated XML tag."
            }
        }

        $token = $normalized.Substring($index, $endTag - $index + 1)
        $tagMatch = [Regex]::Match(
            $token,
            "^<\s*(?<close>/)?\s*(?<name>[A-Za-z_][A-Za-z0-9_.:-]*)[^>]*?(?<self>/)?\s*>$"
        )
        if ($tagMatch.Success) {
            $name = $tagMatch.Groups["name"].Value
            $isClosing = $tagMatch.Groups["close"].Success
            $isSelfClosing = $tagMatch.Groups["self"].Success
            if ($isClosing) {
                if ($stack.Count -eq 0 -or $stack[$stack.Count - 1] -ne $name) {
                    return [pscustomobject]@{
                        Success = $false
                        Text = $normalized
                        Repaired = $false
                        Message = "The fragment contains a mismatched closing tag '$name'."
                    }
                }
                $stack.RemoveAt($stack.Count - 1)
            }
            elseif (-not $isSelfClosing) {
                [void]$stack.Add($name)
            }
        }

        $index = $endTag + 1
    }

    if ($stack.Count -gt 0) {
        if (-not $AllowOpenElementsAtEnd) {
            return [pscustomobject]@{
                Success = $false
                Text = $normalized
                Repaired = $false
                Message = "The fragment contains unclosed XML elements."
            }
        }

        $suffix = New-Object Text.StringBuilder
        for ($index = $stack.Count - 1; $index -ge 0; $index--) {
            [void]$suffix.Append("</").Append($stack[$index]).Append(">")
        }
        return [pscustomobject]@{
            Success = $true
            Text = $normalized + $suffix.ToString()
            Repaired = $true
            Message = ""
        }
    }

    return [pscustomobject]@{
        Success = $true
        Text = $normalized
        Repaired = $false
        Message = ""
    }
}

function Get-RootDetails {
    param([Parameter(Mandatory = $true)][AllowEmptyString()][string]$Text)

    $read = Read-XmlDocument -Text $Text
    if (-not $read.Success) {
        return [pscustomobject]@{
            Success = $false
            Document = $null
            RootElement = ""
            Namespace = ""
            Message = $read.Message
        }
    }

    return [pscustomobject]@{
        Success = $true
        Document = $read.Document
        RootElement = $read.Document.DocumentElement.LocalName
        Namespace = $read.Document.DocumentElement.NamespaceURI
        Message = ""
    }
}

function Get-SchemaPath {
    param(
        [Parameter(Mandatory = $true)]$SchemaFile,
        [string]$Root
    )

    if ([String]::IsNullOrWhiteSpace($Root)) {
        return $null
    }

    $relativePath = Get-StringProperty -Object $SchemaFile -Name "path"
    if ([String]::IsNullOrWhiteSpace($relativePath)) {
        return $null
    }

    return [IO.Path]::GetFullPath((Join-Path $Root ($relativePath.Replace("/", "\"))))
}

function Get-SchemaStates {
    param(
        [Parameter(Mandatory = $true)]$Configuration,
        [string]$Root
    )

    $states = @{}
    foreach ($schema in (Get-ObjectArray (Get-ObjectProperty -Object $Configuration -Name "schemas"))) {
        $schemaId = Get-StringProperty -Object $schema -Name "id"
        $files = Get-ObjectArray (Get-ObjectProperty -Object $schema -Name "source" | ForEach-Object { Get-ObjectProperty -Object $_ -Name "files" })
        $available = $true
        $missing = New-Object System.Collections.Generic.List[string]
        $resolvedFiles = New-Object System.Collections.Generic.List[object]
        foreach ($file in $files) {
            $path = Get-SchemaPath -SchemaFile $file -Root $Root
            $fileAvailable = $null -ne $path -and (Test-Path -LiteralPath $path -PathType Leaf)
            if ($fileAvailable) {
                $expectedHash = Get-StringProperty -Object $file -Name "sha256"
                if ($expectedHash -and (Get-FileSha256 -Path $path) -ne $expectedHash.ToLowerInvariant()) {
                    $fileAvailable = $false
                    [void]$missing.Add("hash mismatch: $(Get-StringProperty -Object $file -Name 'path')")
                }
            }
            elseif ($null -ne $path) {
                [void]$missing.Add("missing: $(Get-StringProperty -Object $file -Name 'path')")
            }
            else {
                [void]$missing.Add("schema root was not supplied")
            }

            if (-not $fileAvailable) {
                $available = $false
            }
            [void]$resolvedFiles.Add([pscustomobject]@{
                Config = $file
                Path = $path
                Available = $fileAvailable
            })
        }

        $schemaSet = $null
        $compileMessage = ""
        if ($available) {
            $entry = @($resolvedFiles | Where-Object { (Get-StringProperty -Object $_.Config -Name "role") -eq "entry" })[0]
            if ($null -eq $entry) {
                $entry = @($resolvedFiles)[0]
            }

            try {
                $schemaSet = New-Object System.Xml.Schema.XmlSchemaSet
                $schemaSet.XmlResolver = New-Object System.Xml.XmlUrlResolver
                [void]$schemaSet.Add((Get-StringProperty -Object $schema -Name "namespace"), $entry.Path)
                $schemaSet.Compile()
            }
            catch {
                $schemaSet = $null
                $compileMessage = $_.Exception.Message
            }
        }

        $source = Get-ObjectProperty -Object $schema -Name "source"
        $sourceFiles = @(
            $resolvedFiles |
                ForEach-Object {
                    [ordered]@{
                        path = Get-StringProperty -Object $_.Config -Name "path"
                        role = Get-StringProperty -Object $_.Config -Name "role"
                        url = Get-StringProperty -Object $_.Config -Name "url"
                        sha256 = Get-StringProperty -Object $_.Config -Name "sha256"
                        available = [bool]$_.Available
                    }
                }
        )
        $states[$schemaId] = [pscustomobject]@{
            Config = $schema
            SchemaSet = $schemaSet
            Available = [bool]($available -and $null -ne $schemaSet)
            Missing = @($missing)
            CompileMessage = $compileMessage
            Files = $sourceFiles
            Source = $source
        }
    }

    return $states
}

function Test-XmlAgainstSchema {
    param(
        [Parameter(Mandatory = $true)][AllowEmptyString()][string]$Text,
        [Parameter(Mandatory = $true)]$SchemaSet
    )

    $read = Read-XmlDocument -Text $Text
    if (-not $read.Success) {
        return [pscustomobject]@{
            Success = $false
            Message = $read.Message
        }
    }

    $messages = New-Object System.Collections.Generic.List[string]
    try {
        $read.Document.Schemas = $SchemaSet
        $handler = [System.Xml.Schema.ValidationEventHandler]{
            param($sender, $arguments)
            [void]$messages.Add($arguments.Message)
        }
        $read.Document.Validate($handler)
        if ($messages.Count -gt 0) {
            return [pscustomobject]@{
                Success = $false
                Message = $messages[0]
            }
        }

        return [pscustomobject]@{
            Success = $true
            Message = ""
        }
    }
    catch {
        return [pscustomobject]@{
            Success = $false
            Message = $_.Exception.Message
        }
    }
}

function Get-Classification {
    param(
        [Parameter(Mandatory = $true)]$Example,
        [Parameter(Mandatory = $true)]$Domain,
        [Parameter(Mandatory = $true)]$RootDetails,
        [Parameter(Mandatory = $true)]$SchemaState
    )

    if ($Example.Flags -contains "complete") {
        return [pscustomobject]@{
            Kind = "complete"
            Reason = "explicit-complete-marker"
        }
    }

    if ($Example.Flags -contains "fragment") {
        return [pscustomobject]@{
            Kind = "fragment"
            Reason = "explicit-fragment-marker"
        }
    }

    $rootElement = Get-StringProperty -Object $Domain -Name "rootElement"
    $hasDeclaration = $Example.Text -match "^\s*<\?xml\b"
    if ($RootDetails.Success -and $RootDetails.RootElement -eq $rootElement -and $hasDeclaration) {
        return [pscustomobject]@{
            Kind = "complete"
            Reason = "declared-root-with-xml-declaration"
        }
    }

    if ($RootDetails.Success -and $RootDetails.RootElement -eq $rootElement -and $SchemaState.Available) {
        $validation = Test-XmlAgainstSchema -Text $Example.Text -SchemaSet $SchemaState.SchemaSet
        if ($validation.Success) {
            return [pscustomobject]@{
                Kind = "complete"
                Reason = "schema-valid-root"
            }
        }
    }

    return [pscustomobject]@{
        Kind = "fragment"
        Reason = if ($RootDetails.Success) { "documentation-snippet-without-complete-marker" } else { "fragment-document-parse-required-wrapper" }
    }
}

function New-ExampleId {
    param(
        [Parameter(Mandatory = $true)][string]$Domain,
        [Parameter(Mandatory = $true)]$Example,
        [Parameter(Mandatory = $true)][string]$ContentHash,
        [Parameter(Mandatory = $true)][string]$SchemaId,
        [Parameter(Mandatory = $true)][string]$WrapperId,
        [Parameter(Mandatory = $true)][string]$SourceRevision
    )

    $identity = "$SourceRevision|$Domain|$($Example.RelativePath)|$($Example.StartLine)|$ContentHash|$SchemaId|$WrapperId"
    return "example-$((Get-TextSha256 $identity).Substring(0, 24))"
}

function Get-SchemaReport {
    param([Parameter(Mandatory = $true)]$SchemaState)

    $schema = $SchemaState.Config
    $versionEvidence = Get-ObjectProperty -Object $schema -Name "versionEvidence"
    $source = $SchemaState.Source
    return [ordered]@{
        id = Get-StringProperty -Object $schema -Name "id"
        domain = Get-StringProperty -Object $schema -Name "domain"
        rootElement = Get-StringProperty -Object $schema -Name "rootElement"
        namespace = Get-StringProperty -Object $schema -Name "namespace"
        version = Get-StringProperty -Object $schema -Name "version"
        versionEvidence = [ordered]@{
            sourcePage = Get-StringProperty -Object $versionEvidence -Name "sourcePage"
            sourceLine = [int](Get-ObjectProperty -Object $versionEvidence -Name "sourceLine")
            status = Get-StringProperty -Object $versionEvidence -Name "status"
            note = Get-StringProperty -Object $versionEvidence -Name "note"
        }
        source = [ordered]@{
            repository = Get-StringProperty -Object $source -Name "repository"
            commit = Get-StringProperty -Object $source -Name "commit"
            files = @($SchemaState.Files)
        }
        available = $SchemaState.Available
    }
}

function Get-Configuration {
    param([Parameter(Mandatory = $true)][string]$Path)

    Assert-Condition (Test-Path -LiteralPath $Path -PathType Leaf) "XML documentation example configuration '$Path' does not exist."
    try {
        $configuration = Get-Content -LiteralPath $Path -Raw | ConvertFrom-Json
    }
    catch {
        throw "Could not parse XML documentation example configuration '$Path': $($_.Exception.Message)"
    }

    Assert-Condition ([int](Get-ObjectProperty -Object $configuration -Name "schemaVersion") -eq 1) "XML documentation example configuration must use schemaVersion 1."
    Assert-Condition ((Get-StringProperty -Object $configuration -Name "format") -eq "xml-documentation-examples") "XML documentation example configuration has an unsupported format."
    $domains = @(Get-ObjectArray (Get-ObjectProperty -Object $configuration -Name "domains"))
    Assert-Condition ($domains.Count -eq 2) "XML documentation example configuration must define exactly two domains."
    $domainNames = @($domains | ForEach-Object { Get-StringProperty -Object $_ -Name "name" } | Sort-Object)
    Assert-Condition (($domainNames -join ",") -eq "Automation,Protocol") "XML documentation example configuration must define Automation and Protocol."

    $schemas = @(Get-ObjectArray (Get-ObjectProperty -Object $configuration -Name "schemas"))
    Assert-Condition ($schemas.Count -eq 2) "XML documentation example configuration must define exactly two schemas."
    foreach ($domain in $domains) {
        $wrapper = Get-ObjectProperty -Object $domain -Name "fragmentWrapper"
        Assert-Condition (-not [String]::IsNullOrWhiteSpace((Get-StringProperty -Object $domain -Name "schemaId"))) "A domain is missing schemaId."
        Assert-Condition ($null -ne $wrapper) "A domain is missing its explicit fragmentWrapper rule."
        Assert-Condition (-not [String]::IsNullOrWhiteSpace((Get-StringProperty -Object $wrapper -Name "id"))) "A fragmentWrapper is missing its id."
        Assert-Condition (-not [String]::IsNullOrWhiteSpace((Get-StringProperty -Object $wrapper -Name "rootElement"))) "A fragmentWrapper is missing its rootElement."
    }
    foreach ($schema in $schemas) {
        $version = Get-StringProperty -Object $schema -Name "version"
        Assert-Condition (-not [String]::IsNullOrWhiteSpace($version)) "Schema '$(Get-StringProperty -Object $schema -Name 'id')' has no version evidence. Use 'unknown' when no version is published."
        $source = Get-ObjectProperty -Object $schema -Name "source"
        $sourceFiles = @(Get-ObjectArray (Get-ObjectProperty -Object $source -Name "files"))
        Assert-Condition ($sourceFiles.Count -gt 0) "Schema '$(Get-StringProperty -Object $schema -Name 'id')' has no pinned source files."
        foreach ($file in $sourceFiles) {
            Assert-Condition ((Get-StringProperty -Object $file -Name "sha256") -match "^[0-9a-f]{64}$") "Schema source '$(Get-StringProperty -Object $file -Name 'path')' must have a lowercase SHA-256 pin."
        }
    }

    return $configuration
}

$script:RepositoryRoot = ConvertTo-FullPath $RepositoryRoot
$configurationPath = if ([IO.Path]::IsPathRooted($ConfigurationPath)) {
    [IO.Path]::GetFullPath($ConfigurationPath)
}
else {
    [IO.Path]::GetFullPath((Join-Path $script:RepositoryRoot $ConfigurationPath))
}
$outputPath = if ([IO.Path]::IsPathRooted($OutputPath)) {
    [IO.Path]::GetFullPath($OutputPath)
}
else {
    [IO.Path]::GetFullPath((Join-Path $script:RepositoryRoot $OutputPath))
}
$configuration = Get-Configuration -Path $configurationPath
$revision = Get-SourceRevision -RequestedRevision $SourceRevision
$generationDate = Get-GenerationDateValue -RequestedDate $GenerationDate
$schemaRootPath = ""
if (-not [String]::IsNullOrWhiteSpace($SchemaRoot)) {
    $schemaRootPath = if ([IO.Path]::IsPathRooted($SchemaRoot)) {
        [IO.Path]::GetFullPath($SchemaRoot)
    }
    else {
        [IO.Path]::GetFullPath((Join-Path $script:RepositoryRoot $SchemaRoot))
    }
}
$schemaStates = Get-SchemaStates -Configuration $configuration -Root $schemaRootPath

$gaps = New-Object System.Collections.Generic.List[object]
foreach ($schemaState in $schemaStates.Values) {
    if (-not $schemaState.Available) {
        $schemaId = Get-StringProperty -Object $schemaState.Config -Name "id"
        $message = if ($schemaState.CompileMessage) {
            "Schema '$schemaId' could not be compiled: $($schemaState.CompileMessage)"
        }
        elseif ($schemaState.Missing.Count -gt 0) {
            "Schema '$schemaId' source is unavailable: $($schemaState.Missing -join '; ')."
        }
        else {
            "Schema '$schemaId' source is unavailable."
        }
        [void]$gaps.Add([ordered]@{
            id = "gap-schema-$schemaId"
            kind = if ($schemaState.CompileMessage) { "schema-source-invalid" } else { "schema-source-missing" }
            severity = if ($RequireSchemaSources) { "error" } else { "warning" }
            schemaId = $schemaId
            message = $message
        })
    }
}

$examples = New-Object System.Collections.Generic.List[object]
$sourcePages = New-Object System.Collections.Generic.HashSet[string]([StringComparer]::OrdinalIgnoreCase)
$domains = Get-ObjectArray (Get-ObjectProperty -Object $configuration -Name "domains")
foreach ($domain in $domains) {
    $domainName = Get-StringProperty -Object $domain -Name "name"
    $schemaId = Get-StringProperty -Object $domain -Name "schemaId"
    Assert-Condition ($schemaStates.ContainsKey($schemaId)) "Domain '$domainName' references unknown schema '$schemaId'."
    $schemaState = $schemaStates[$schemaId]
    $wrapperRule = Get-ObjectProperty -Object $domain -Name "fragmentWrapper"
    foreach ($sourceRoot in (Get-ObjectArray (Get-ObjectProperty -Object $domain -Name "sourceRoots"))) {
        $sourceRootPath = ConvertTo-FullPath (Join-Path $script:RepositoryRoot ($sourceRoot.Replace("/", "\")))
        Assert-Condition (Test-Path -LiteralPath $sourceRootPath -PathType Container) "XML example source root '$sourceRoot' for domain '$domainName' does not exist."
        foreach ($page in (Get-ChildItem -LiteralPath $sourceRootPath -Recurse -File -Filter *.md | Sort-Object FullName)) {
            $relativePage = ConvertTo-RepositoryRelativePath -Path $page.FullName -Root $script:RepositoryRoot
            $pageLines = [IO.File]::ReadAllLines($page.FullName)
            $uid = Get-PageUid -Lines $pageLines
            $pageExamples = @(Get-XmlExamplesFromPage -Path $page.FullName -RelativePath $relativePage -Uid $uid)
            if ($pageExamples.Count -gt 0) {
                [void]$sourcePages.Add($relativePage)
            }

            foreach ($example in $pageExamples) {
                $content = Remove-XmlExampleMarkerLines -Text $example.Text
                $contentHash = Get-TextSha256 $content
                $strictRoot = Get-RootDetails -Text $content
                $classification = Get-Classification -Example $example -Domain $domain -RootDetails $strictRoot -SchemaState $schemaState
                $unclosedFence = [bool](Get-ObjectProperty -Object $example -Name "UnclosedFence")
                if ($unclosedFence) {
                    $classification = [pscustomobject]@{
                        Kind = "fragment"
                        Reason = "unclosed-xml-fence"
                    }
                }
                $negative = ($example.Flags -contains "negative" -or $example.Flags -contains "expected-invalid")
                $wrapperApplied = $classification.Kind -eq "fragment"
                $wrapperId = if ($wrapperApplied) { Get-StringProperty -Object $wrapperRule -Name "id" } else { "none" }
                $exampleId = New-ExampleId -Domain $domainName -Example $example -ContentHash $contentHash -SchemaId $schemaId -WrapperId $wrapperId -SourceRevision (Get-StringProperty -Object $revision -Name "value")
                $resultStatus = "unverified"
                $schemaStatus = "not-evaluated"
                $message = $null
                $repaired = $false

                if ($classification.Kind -eq "complete") {
                    if (-not $schemaState.Available) {
                        $schemaStatus = "source-missing"
                        $message = "The pinned schema source is unavailable."
                        [void]$gaps.Add([ordered]@{
                            id = "gap-$exampleId-schema"
                            kind = "schema-source-missing"
                            severity = if ($RequireSchemaSources) { "error" } else { "warning" }
                            domain = $domainName
                            sourcePath = $example.RelativePath
                            sourceLine = $example.StartLine
                            schemaId = $schemaId
                            message = $message
                        })
                    }
                    else {
                        $validation = Test-XmlAgainstSchema -Text $content -SchemaSet $schemaState.SchemaSet
                        $schemaStatus = if ($validation.Success) { "valid" } else { "invalid" }
                        if ($validation.Success) {
                            $resultStatus = if ($negative) { "failed" } else { "passed" }
                            if ($negative) {
                                $message = "The example is marked negative but validates against the pinned schema."
                            }
                        }
                        else {
                            $resultStatus = if ($negative) { "expected-failure" } else { "failed" }
                            $message = $validation.Message
                        }
                    }
                }
                else {
                    if ($unclosedFence) {
                        $schemaStatus = "not-applicable"
                        $message = "The XML code fence is not closed."
                        [void]$gaps.Add([ordered]@{
                            id = "gap-$exampleId-fence"
                            kind = "unclosed-xml-fence"
                            severity = "warning"
                            domain = $domainName
                            sourcePath = $example.RelativePath
                            sourceLine = $example.StartLine
                            schemaId = $schemaId
                            message = $message
                        })
                    }
                    else {
                        $repair = Repair-XmlFragment -Text $content -AllowOpenElementsAtEnd ([bool](Get-ObjectProperty -Object $wrapperRule -Name "allowOpenElementsAtEnd"))
                        $repaired = [bool]$repair.Repaired
                        if (-not $repair.Success) {
                            $schemaStatus = "not-applicable"
                            $message = $repair.Message
                            [void]$gaps.Add([ordered]@{
                                id = "gap-$exampleId-wrapper"
                                kind = "fragment-wrapper-failed"
                                severity = "warning"
                                domain = $domainName
                                sourcePath = $example.RelativePath
                                sourceLine = $example.StartLine
                                schemaId = $schemaId
                                message = $repair.Message
                            })
                        }
                        else {
                            $wrapperRoot = Get-StringProperty -Object $wrapperRule -Name "rootElement"
                            $wrapperNamespace = Get-StringProperty -Object $wrapperRule -Name "namespace"
                            $wrappedText = '<' + $wrapperRoot + ' xmlns="' + $wrapperNamespace + '">' + $repair.Text + '</' + $wrapperRoot + '>'
                            $wrapped = Read-XmlDocument -Text $wrappedText
                            if ($wrapped.Success) {
                                $resultStatus = if ($negative) { "failed" } else { "passed" }
                                $schemaStatus = "not-evaluated"
                                if ($negative) {
                                    $message = "The fragment is marked negative but is well-formed through its declared wrapper."
                                }
                            }
                            else {
                                $message = $wrapped.Message
                                [void]$gaps.Add([ordered]@{
                                    id = "gap-$exampleId-wrapper"
                                    kind = "fragment-wrapper-failed"
                                    severity = "warning"
                                    domain = $domainName
                                    sourcePath = $example.RelativePath
                                    sourceLine = $example.StartLine
                                    schemaId = $schemaId
                                    message = $wrapped.Message
                                })
                            }
                        }
                    }
                }

                $source = [ordered]@{
                    path = $example.RelativePath
                    uid = $example.Uid
                    startLine = $example.StartLine
                    endLine = $example.EndLine
                    fenceLine = $example.FenceLine
                }
                $schemaReport = Get-SchemaReport -SchemaState $schemaState
                [void]$schemaReport.Remove("available")
                $schemaReport["sourceFilesAvailable"] = $schemaState.Available
                $wrapperReport = [ordered]@{
                    id = $wrapperId
                    rootElement = if ($wrapperApplied) { Get-StringProperty -Object $wrapperRule -Name "rootElement" } else { Get-StringProperty -Object $domain -Name "rootElement" }
                    namespace = if ($wrapperApplied) { Get-StringProperty -Object $wrapperRule -Name "namespace" } else { Get-StringProperty -Object $domain -Name "namespace" }
                    applied = $wrapperApplied
                    validation = if ($classification.Kind -eq "complete") { "xsd" } elseif ($wrapperApplied) { "wrapped-well-formed" } else { "not-applicable" }
                    normalized = ($content -ne $example.Text)
                    repaired = $repaired
                }
                $classificationReport = [ordered]@{
                    kind = $classification.Kind
                    reason = $classification.Reason
                    rootElement = if ($strictRoot.Success) { $strictRoot.RootElement } else { "" }
                    namespace = if ($strictRoot.Success) { $strictRoot.Namespace } else { "" }
                }
                [void]$examples.Add([ordered]@{
                    id = $exampleId
                    domain = $domainName
                    source = $source
                    classification = $classificationReport
                    negative = $negative
                    contentHash = $contentHash
                    schema = $schemaReport
                    wrapper = $wrapperReport
                    result = [ordered]@{
                        status = $resultStatus
                        schemaStatus = $schemaStatus
                        message = $message
                    }
                })
            }
        }
    }
}

$counts = [ordered]@{
    sourcePages = $sourcePages.Count
    examples = $examples.Count
    completeDocuments = @($examples | Where-Object { $_.classification.kind -eq "complete" }).Count
    fragments = @($examples | Where-Object { $_.classification.kind -eq "fragment" }).Count
    passed = @($examples | Where-Object { $_.result.status -eq "passed" }).Count
    expectedFailures = @($examples | Where-Object { $_.result.status -eq "expected-failure" }).Count
    failed = @($examples | Where-Object { $_.result.status -eq "failed" }).Count
    unverified = @($examples | Where-Object { $_.result.status -eq "unverified" }).Count
    repairedFragments = @($examples | Where-Object { $_.wrapper.repaired }).Count
    gaps = $gaps.Count
    byDomain = @(
        foreach ($domainName in @("Automation", "Protocol")) {
            $domainExamples = @($examples | Where-Object { $_.domain -eq $domainName })
            [ordered]@{
                domain = $domainName
                examples = $domainExamples.Count
                completeDocuments = @($domainExamples | Where-Object { $_.classification.kind -eq "complete" }).Count
                fragments = @($domainExamples | Where-Object { $_.classification.kind -eq "fragment" }).Count
                passed = @($domainExamples | Where-Object { $_.result.status -eq "passed" }).Count
                expectedFailures = @($domainExamples | Where-Object { $_.result.status -eq "expected-failure" }).Count
                failed = @($domainExamples | Where-Object { $_.result.status -eq "failed" }).Count
                unverified = @($domainExamples | Where-Object { $_.result.status -eq "unverified" }).Count
            }
        }
    )
}

$sourcePaths = @(
    $domains |
        ForEach-Object {
            Get-ObjectArray (Get-ObjectProperty -Object $_ -Name "sourceRoots")
        } |
        ForEach-Object { ConvertTo-PortablePath $_ } |
        Sort-Object -Unique
)
$configurationRelativePath = ConvertTo-RepositoryRelativePath -Path $configurationPath -Root $script:RepositoryRoot
$report = [ordered]@{
    schemaVersion = $script:SchemaVersion
    format = "xml-documentation-examples"
    generator = [ordered]@{
        name = "scripts/generate-xml-documentation-examples.ps1"
        version = $script:GeneratorVersion
    }
    source = [ordered]@{
        repository = $script:Repository
        revision = Get-StringProperty -Object $revision -Name "value"
        revisionSource = Get-StringProperty -Object $revision -Name "source"
        configuration = [ordered]@{
            path = ConvertTo-PortablePath $configurationRelativePath
            sha256 = Get-FileSha256 -Path $configurationPath
        }
    }
    scope = [ordered]@{
        language = "xml"
        domains = @("Automation", "Protocol")
        sourcePaths = $sourcePaths
    }
    generation = [ordered]@{
        generatedAt = Get-StringProperty -Object $generationDate -Name "value"
        generatedAtSource = Get-StringProperty -Object $generationDate -Name "source"
        deterministic = $true
        contentIdentityAlgorithm = "sha256"
        contentIdentityFields = @("sourceRevision", "sourcePath", "sourceLine", "sourceContentHash", "schemaId", "wrapperId")
        contentIdentityExcludes = @("generatedAt")
    }
    schemas = @($schemaStates.Values | Sort-Object { Get-StringProperty -Object $_.Config -Name "id" } | ForEach-Object { Get-SchemaReport -SchemaState $_ })
    counts = $counts
    examples = @($examples | Sort-Object domain, source.path, source.startLine, id)
    gaps = @($gaps | Sort-Object id)
}

Write-Json -Path $outputPath -Value $report

$failedExamples = @($examples | Where-Object { $_.result.status -eq "failed" })
$errorGaps = @($gaps | Where-Object { $_.severity -eq "error" })
if ($failedExamples.Count -gt 0) {
    $locations = ($failedExamples | ForEach-Object { "$($_.source.path):$($_.source.startLine)" }) -join ", "
    throw "XML documentation example validation failed for $($failedExamples.Count) unmarked or unexpectedly valid example(s): $locations."
}
if ($errorGaps.Count -gt 0) {
    throw "XML documentation example validation has $($errorGaps.Count) required source gap(s)."
}

Write-Output "XML documentation examples: $($counts.examples) examples, $($counts.completeDocuments) complete, $($counts.fragments) fragments, $($counts.gaps) gaps."
