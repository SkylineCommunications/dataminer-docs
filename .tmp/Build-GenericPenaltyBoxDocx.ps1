param(
    [string]$RepoRoot = "C:\Users\MicahBR\Documents\dataminer-docs",
    [string]$OutputPath = "C:\Users\MicahBR\Documents\Generic_Penalty_Box_Documentation.docx"
)

$ErrorActionPreference = "Stop"

$folder = Join-Path $RepoRoot "solutions\custom_solutions\Generic_Penalty_Box"
$imagesFolder = Join-Path $RepoRoot "solutions\images"

$files = @(
    (Join-Path $folder "Generic_Penalty_Box_Overview.md"),
    (Join-Path $folder "Generic_Penalty_Box_Installation.md"),
    (Join-Path $folder "Generic_Penalty_Box_Configuration.md"),
    (Join-Path $folder "Generic_Penalty_Box_Use.md")
)

# ---------- Markdown parsing ----------

function ConvertTo-Slug([string]$text) {
    $s = $text.ToLowerInvariant()
    $s = $s -replace '[^a-z0-9\s-]', ''
    $s = $s -replace '\s+', '-'
    return $s.Trim('-')
}

function Parse-MarkdownFile([string]$path) {
    $lines = Get-Content -LiteralPath $path -Encoding UTF8
    $uid = $null
    $i = 0

    if ($lines.Count -ge 3 -and $lines[0].Trim() -eq '---') {
        $j = 1
        while ($j -lt $lines.Count -and $lines[$j].Trim() -ne '---') {
            if ($lines[$j] -match '^\s*uid:\s*(\S+)\s*$') { $uid = $matches[1] }
            $j++
        }
        $i = $j + 1
    }

    $blocks = New-Object System.Collections.Generic.List[object]

    while ($i -lt $lines.Count) {
        $line = $lines[$i]

        if ($line -match '^```') {
            $lang = $line -replace '^```', ''
            $codeLines = New-Object System.Collections.Generic.List[string]
            $i++
            while ($i -lt $lines.Count -and $lines[$i] -notmatch '^```') {
                $codeLines.Add($lines[$i])
                $i++
            }
            $i++ # skip closing fence
            $blocks.Add([pscustomobject]@{ Type = 'Code'; Lang = $lang; Lines = $codeLines })
            continue
        }

        if ($line -match '^####\s+(.+)') {
            $blocks.Add([pscustomobject]@{ Type = 'Heading'; Level = 4; Text = $matches[1].Trim() })
            $i++; continue
        }
        if ($line -match '^###\s+(.+)') {
            $blocks.Add([pscustomobject]@{ Type = 'Heading'; Level = 3; Text = $matches[1].Trim() })
            $i++; continue
        }
        if ($line -match '^##\s+(.+)') {
            $blocks.Add([pscustomobject]@{ Type = 'Heading'; Level = 2; Text = $matches[1].Trim() })
            $i++; continue
        }
        if ($line -match '^#\s+(.+)') {
            $blocks.Add([pscustomobject]@{ Type = 'Heading'; Level = 1; Text = $matches[1].Trim(); Uid = $uid })
            $i++; continue
        }

        if ($line -match '^!\[(.*?)\]\((.*?)\)\s*$') {
            $blocks.Add([pscustomobject]@{ Type = 'Image'; Alt = $matches[1]; Src = $matches[2] })
            $i++; continue
        }

        if ($line -match '^\|.+\|\s*$') {
            $tableLines = New-Object System.Collections.Generic.List[string]
            while ($i -lt $lines.Count -and $lines[$i] -match '^\|.+\|\s*$') {
                $tableLines.Add($lines[$i])
                $i++
            }
            $rows = New-Object System.Collections.Generic.List[object]
            foreach ($tl in $tableLines) {
                if ($tl -match '^\|[\s:\-\|]+\|\s*$') { continue } # separator row
                $cells = $tl.Trim().Trim('|') -split '\|' | ForEach-Object { $_.Trim() }
                $rows.Add($cells)
            }
            $blocks.Add([pscustomobject]@{ Type = 'Table'; Rows = $rows })
            continue
        }

        if ($line -match '^>\s*\[!NOTE\]\s*$') {
            $noteLines = New-Object System.Collections.Generic.List[string]
            $i++
            while ($i -lt $lines.Count -and $lines[$i] -match '^>\s?(.*)$') {
                $noteLines.Add($matches[1])
                $i++
            }
            $blocks.Add([pscustomobject]@{ Type = 'Note'; Text = ($noteLines -join ' ').Trim() })
            continue
        }

        if ($line -match '^\d+\.\s+(.+)') {
            $blocks.Add([pscustomobject]@{ Type = 'Number'; Text = $matches[1].Trim() })
            $i++; continue
        }

        if ($line -match '^-\s+(.+)') {
            $blocks.Add([pscustomobject]@{ Type = 'Bullet'; Text = $matches[1].Trim() })
            $i++; continue
        }

        if ($line.Trim() -eq '') { $i++; continue }

        $blocks.Add([pscustomobject]@{ Type = 'Para'; Text = $line.Trim() })
        $i++
    }

    return [pscustomobject]@{ Uid = $uid; Blocks = $blocks }
}

Write-Host "Parsing markdown files..."
$parsedFiles = @()
foreach ($f in $files) { $parsedFiles += Parse-MarkdownFile $f }

# ---------- Build bookmark map (uid / uid#slug -> bookmark name) ----------

$bookmarkMap = @{}
$bmCounter = 0
foreach ($pf in $parsedFiles) {
    foreach ($b in $pf.Blocks) {
        if ($b.Type -eq 'Heading') {
            $bmCounter++
            $bmName = "bm$bmCounter"
            if ($b.Level -eq 1) {
                $bookmarkMap[$pf.Uid] = $bmName
            } else {
                $slug = ConvertTo-Slug $b.Text
                $bookmarkMap["$($pf.Uid)#$slug"] = $bmName
            }
            $b | Add-Member -NotePropertyName BookmarkName -NotePropertyValue $bmName
        }
    }
}

# ---------- Word automation ----------

Write-Host "Starting Word..."
$word = New-Object -ComObject Word.Application
$word.Visible = $false
$doc = $word.Documents.Add()

$wdStyleHeading1 = -2
$wdStyleHeading2 = -3
$wdStyleHeading3 = -4
$wdStyleHeading4 = -5
$wdStyleTitle = -63
$wdStyleNormal = -1
$wdStyleListBullet = -158
$wdStyleListNumber = -160

$sel = $word.Selection

function Type-Plain([string]$text) {
    $sel.Font.Bold = 0
    $sel.Font.Italic = 0
    $sel.Font.Name = "Calibri"
    $sel.TypeText($text)
}

function Add-InlineRuns([string]$text) {
    $pattern = '(\*\*[^\*]+?\*\*)|(`[^`]+?`)|(\[[^\]]+?\]\([^\)]+?\))|(\*[^\*]+?\*)'
    $ms = [regex]::Matches($text, $pattern)
    $last = 0
    foreach ($m in $ms) {
        if ($m.Index -gt $last) {
            Type-Plain ($text.Substring($last, $m.Index - $last))
        }
        $val = $m.Value
        if ($val.StartsWith('**')) {
            $sel.Font.Bold = 1
            $sel.TypeText($val.Substring(2, $val.Length - 4))
            $sel.Font.Bold = 0
        }
        elseif ($val.StartsWith('`')) {
            $sel.Font.Name = "Consolas"
            $sel.TypeText($val.Substring(1, $val.Length - 2))
            $sel.Font.Name = "Calibri"
        }
        elseif ($val.StartsWith('[')) {
            if ($val -match '^\[(.*?)\]\((.*?)\)$') {
                $linkText = $matches[1]
                $target = $matches[2]
                $startPos = $sel.Range.Start
                Type-Plain $linkText
                $endPos = $sel.Range.Start
                $range = $doc.Range($startPos, $endPos)
                if ($target -match '^xref:(.*)$') {
                    $ref = $matches[1]
                    if ($bookmarkMap.ContainsKey($ref)) {
                        $doc.Hyperlinks.Add($range, "", $bookmarkMap[$ref]) | Out-Null
                    }
                }
                elseif ($target -match '^https?://') {
                    $doc.Hyperlinks.Add($range, $target) | Out-Null
                }
            }
        }
        elseif ($val.StartsWith('*')) {
            $sel.Font.Italic = 1
            $sel.TypeText($val.Substring(1, $val.Length - 2))
            $sel.Font.Italic = 0
        }
        $last = $m.Index + $m.Length
    }
    if ($last -lt $text.Length) {
        Type-Plain ($text.Substring($last))
    }
}

# Title page
$sel.Style = $wdStyleTitle
$sel.TypeText("Generic Penalty Box - Documentation")
$sel.TypeParagraph()
$sel.Style = $wdStyleNormal
$sel.TypeText("Combined export of the Generic Penalty Box documentation pages, for review purposes.")
$sel.TypeParagraph()
$sel.TypeParagraph()

# Table of contents
$tocRange = $sel.Range
$doc.TablesOfContents.Add($tocRange, $true, 1, 3) | Out-Null
$sel.EndKey(6) | Out-Null # wdStory
$sel.TypeParagraph()

foreach ($pf in $parsedFiles) {
    foreach ($b in $pf.Blocks) {
        switch ($b.Type) {
            'Heading' {
                switch ($b.Level) {
                    1 { $sel.Style = $wdStyleHeading1 }
                    2 { $sel.Style = $wdStyleHeading2 }
                    3 { $sel.Style = $wdStyleHeading3 }
                    4 { $sel.Style = $wdStyleHeading4 }
                }
                $startPos = $sel.Range.Start
                $sel.TypeText($b.Text)
                $endPos = $sel.Range.Start
                $bmRange = $doc.Range($startPos, $endPos)
                $doc.Bookmarks.Add($b.BookmarkName, $bmRange) | Out-Null
                $sel.TypeParagraph()
                $sel.Style = $wdStyleNormal
            }
            'Para' {
                $sel.Style = $wdStyleNormal
                Add-InlineRuns $b.Text
                $sel.TypeParagraph()
            }
            'Bullet' {
                $sel.Style = $wdStyleListBullet
                Add-InlineRuns $b.Text
                $sel.TypeParagraph()
                $sel.Style = $wdStyleNormal
            }
            'Number' {
                $sel.Style = $wdStyleListNumber
                Add-InlineRuns $b.Text
                $sel.TypeParagraph()
                $sel.Style = $wdStyleNormal
            }
            'Note' {
                $sel.Style = $wdStyleNormal
                $sel.Font.Italic = 1
                $sel.Font.Shading.BackgroundPatternColor = 15921906
                $sel.TypeText("Note: ")
                $sel.Font.Bold = 0
                Add-InlineRuns $b.Text
                $sel.Font.Italic = 0
                $sel.Font.Shading.BackgroundPatternColor = -16777216
                $sel.TypeParagraph()
            }
            'Code' {
                $sel.Style = $wdStyleNormal
                $sel.Font.Name = "Consolas"
                $sel.Font.Size = 9
                $sel.Shading.BackgroundPatternColor = 15921906
                foreach ($cl in $b.Lines) {
                    $sel.TypeText($cl)
                    $sel.TypeParagraph()
                }
                $sel.Shading.BackgroundPatternColor = -16777216
                $sel.Font.Name = "Calibri"
                $sel.Font.Size = 11
            }
            'Table' {
                $rows = $b.Rows
                if ($rows.Count -eq 0) { continue }
                $numCols = $rows[0].Count
                $numRows = $rows.Count
                $tblRange = $sel.Range
                $tbl = $doc.Tables.Add($tblRange, $numRows, $numCols)
                $tbl.Borders.Enable = 1
                for ($r = 0; $r -lt $numRows; $r++) {
                    for ($c = 0; $c -lt $numCols; $c++) {
                        $cellText = if ($c -lt $rows[$r].Count) { [string]$rows[$r][$c] } else { "" }
                        $cellRange = $tbl.Cell($r + 1, $c + 1).Range
                        $cellRange.Text = ""
                        $cellSel = $cellRange
                        # Strip inline markdown markers for simplicity in table cells
                        $plain = [string]($cellText -replace '\*\*', '' -replace '`', '' -replace '\[([^\]]*)\]\([^\)]*\)', '$1')
                        $cellRange.Text = $plain
                        if ($r -eq 0) { $cellRange.Font.Bold = 1 }
                    }
                }
                $sel.EndKey(6) | Out-Null
                $word.Selection.MoveDown(5, 1) | Out-Null
                $sel.EndKey(6) | Out-Null
                $sel.TypeParagraph()
            }
            'Image' {
                $src = $b.Src -replace '^~/solutions/images/', ''
                $imgPath = Join-Path $imagesFolder $src
                if (Test-Path $imgPath) {
                    $shape = $sel.InlineShapes.AddPicture($imgPath)
                    $shape.LockAspectRatio = -1
                    if ($shape.Width -gt 396) { $shape.Width = 396 }
                    $sel.TypeParagraph()
                    $sel.Font.Italic = 1
                    $sel.Font.Size = 9
                    Type-Plain $b.Alt
                    $sel.Font.Italic = 0
                    $sel.Font.Size = 11
                    $sel.TypeParagraph()
                } else {
                    Write-Warning "Image not found: $imgPath"
                }
            }
        }
    }
    # page break between files
    $sel.InsertBreak(7) | Out-Null # wdPageBreak
}

# Update TOC field
$doc.TablesOfContents.Item(1).Update()

Write-Host "Saving to $OutputPath ..."
$doc.SaveAs2($OutputPath, 12) # wdFormatXMLDocument (.docx)
$doc.Close()
$word.Quit()

Write-Host "Done: $OutputPath"
