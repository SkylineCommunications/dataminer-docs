---
description: "Scan all .md files in the repository for dead external links and produce a markdown report in the root folder."
name: "Dead Link Detector"
argument-hint: "Optional: subfolder to scope the scan (e.g. dataminer/ or release-notes/). Leave blank to scan the whole repo."
agent: "agent"
tools: [execute/runInTerminal, read/readFile, edit/createFile, search]
---

Scan the repository for dead external links in Markdown files and produce a report.

## Inputs

- **Scope** (optional, from argument): `{{input}}`. If blank, scan the entire repository. If a subfolder is provided, limit the scan to that folder.

## Instructions

### 1 — Collect external URLs

Use `grep_search` to find all external URLs (starting with `http://` or `https://`) inside `.md` files within the scope. Exclude:
- `_site/` and `_site_pdf/` (build output)
- `obj/` and `build/` (build artifacts)

Collect results as a de-duplicated list of `{ url, filePath, lineNumber }` records.

### 2 — Check each URL

For every unique URL, run a HEAD (then GET fallback) request using PowerShell to determine its HTTP status code. Use the following approach:

```powershell
try {
    $r = Invoke-WebRequest -Uri '<URL>' -Method Head -TimeoutSec 15 -MaximumRedirection 5 -ErrorAction Stop -UseBasicParsing
    $r.StatusCode
} catch {
    if ($_.Exception.Response) { $_.Exception.Response.StatusCode.value__ } else { 'ERROR' }
}
```

- Treat status codes **200–399** as **alive**.
- Treat status codes **400, 404, 410, 451** as **dead**.
- Treat status codes **401, 403, 405, 429** and connection errors as **unknown / unverifiable** (do not mark as dead).
- Skip `localhost`, `127.0.0.1`, `example.com`, and placeholder URLs.

Batch the checks in groups of 20 to avoid overwhelming the terminal.

### 3 — Produce the report

Create (or overwrite) the file `dead-link-report.md` in the repository root with the following structure:

```markdown
---
uid: dead-link-report
---

# Dead Link Report

**Generated:** <current date and time in ISO 8601>  
**Scope:** <folder scanned or "entire repository">  
**Total external URLs checked:** <N>  
**Dead links found:** <N>  
**Unverifiable links:** <N>

## Dead links

| File | Line | URL | Status |
|------|------|-----|--------|
| `path/to/file.md` | 42 | https://example.com/broken | 404 |

## Unverifiable links (may need manual review)

| File | Line | URL | Status |
|------|------|-----|--------|
| `path/to/file.md` | 10 | https://example.com/auth | 403 |

## Summary

<Brief paragraph summarising findings and recommended next steps.>
```

- List every **occurrence** of a dead link (same URL may appear in multiple files).
- Sort dead links by file path, then line number.
- If no dead links are found, state that clearly in the report and omit the table.

### 4 — Confirm

After creating the report, confirm the file path and the number of dead links found.
