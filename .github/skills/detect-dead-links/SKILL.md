---
name: detect-dead-links
description: "Use when asked to Detect dead links, scan Markdown for broken external links, or check hyperlinks in Mermaid diagrams. Report only confirmed dead links without editing files."
argument-hint: "Optional subfolder; defaults to the whole repository, including Mermaid diagrams"
---

# Detect dead links

Scan the repository for dead external links in Markdown files, including hyperlinks in Mermaid diagrams, and return only the real dead links in chat.

## Inputs

- **Scope** (optional): Use the folder supplied in the request. If blank, scan the entire repository. If a subfolder is provided, limit the scan to that folder.

## Instructions

### Collect external URLs

Use the available repository search tool to find all external URLs (starting with `http://` or `https://`) inside `.md` files within the scope. Exclude:

- `_site/` and `_site_pdf/` (build output)
- `obj/` and `build/` (build artifacts)

Collect results as a de-duplicated list of `{ url, filePath, lineNumber, contextType }` records, where `contextType` is one of:

- `markdown-link` (e.g. `[text](https://...)`)
- `autolink` (plain URL in prose)
- `inline-code` (inside backticks)
- `fenced-code` (inside fenced code blocks)
- `mermaid-link` (a hyperlink in a Mermaid diagram, including `click`/`href` directives and HTML links in labels)

Identify all Mermaid diagrams containing hyperlinks within the scope and collect their targets and source line numbers. Mermaid hyperlinks are navigable links, not code examples: classify them as `mermaid-link` even though the diagrams are fenced code blocks, and check them normally. Ordinary inline and fenced code URLs remain examples by default and must not be classified as dead. Do not execute diagram callbacks or code.

Keep every source occurrence, but check each unique normalized URL only once. If a URL occurs both in an example and in a real link, validate the real link and report only eligible occurrences.

When cleaning an extracted URL, strip only unambiguous trailing punctuation: `.` `,` `:` `;`. Do **not** strip trailing `)` — parentheses are valid inside URLs (e.g., Microsoft Docs URLs such as `.../dn169026(v=ws.10)`). Only strip a trailing `)` when the URL was clearly wrapped in a Markdown link `[text](url)` and the `)` closes the link syntax rather than being part of the URL itself.

Before checking a URL, normalize it for validation:

- Remove URL fragments (`#...`) before HTTP checks.
- For NuGet package pages (`https://www.nuget.org/packages/<id>`), treat trailing slash as optional and prefer checking the canonical form with trailing slash.

### Check each URL

For every unique URL, run a HEAD request and always do a GET fallback for ambiguous results (especially 404/405/429/5xx). Use a browser-like user agent and allow redirects.

```powershell
try {
    $headers = @{ 'User-Agent' = 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) DeadLinkDetector/1.0' }
    $r = Invoke-WebRequest -Uri '<URL>' -Method Head -TimeoutSec 20 -MaximumRedirection 10 -Headers $headers -ErrorAction Stop -UseBasicParsing
    $r.StatusCode
} catch {
    if ($_.Exception.Response) { $_.Exception.Response.StatusCode.value__ } else { 'ERROR' }
}
```

- Treat status codes **200–399** as **alive**.
- Treat status code **410** as **dead**.
- Treat status code **451** as **dead**.
- Treat status codes **401, 403, 405, 429** and connection errors as **unknown / unverifiable** (do not mark as dead).
- Treat other inconclusive responses, including unresolved **5xx** responses, as **unknown / unverifiable**, not dead.
- Treat **404 as dead only when both HEAD and GET return 404** and the URL is not in a known false-positive category.
- Skip `localhost`, `127.0.0.1`, `example.com`, and placeholder/sample URLs.

Treat these as **unverifiable** without marking them dead (record with reason in `Status`):

- `community.dataminer.services` (`LOGIN-GATED`)
- `aka.dataminer.services` (`SHORTLINK-UNVERIFIED`)
- `www.nuget.org/packages/*` (`BOT-PROTECTED`)
- `*.b2clogin.com` (`AUTH-ENDPOINT`)
- `api.dataminer.services/api/key-catalog/*` (`METHOD-SPECIFIC-ENDPOINT`)

Treat these as placeholders/examples and do not check (or classify as dead):

- URLs with private/local hosts or addresses: `10.x.x.x`, `172.16.x.x`-`172.31.x.x`, `192.168.x.x`, `169.254.x.x`, `*.local`, `intranet`, `hostname`, `node_address`, `x.x.x.x`.
- URLs that contain obvious placeholders such as `[ALARMID]`, `<...>`, `{...}`, `mydomain`, `example`.

Batch the checks in groups of 20 to avoid overwhelming the terminal.

When a URL is classified as unverifiable by host/category rules, do not spend network calls on it.

### Return results in chat

Do **not** create or update any file.
Return the results directly in the chat window and include **only** real dead links (the equivalent of the existing `## Dead links` section).

Use this exact output format:

```markdown
## Dead links

Number of broken links: <number of confirmed dead-link occurrences>

| File | Line | URL | Status |
|------|------|-----|--------|
| `path/to/file.md` | 42 | https://example.com/broken | 404 |
```

Rules:

- Include only links classified as dead (`404` confirmed by both HEAD and GET, `410`, or `451`).
- Exclude alive links, unverifiable links, and excluded/placeholder/example links from the final output.
- List every occurrence of a dead link (same URL may appear in multiple files).
- Sort dead links by file path, then line number.
- If no dead links are found, output exactly:

  ```markdown
  ## Dead links

  No dead links were found in this scope.
  ```

### Confirm

The count is the number of reported occurrences, not the number of unique URLs. If none were found, use the no-dead-links message above and confirm the count is zero afterward. Never claim a complete clean scan if collection or validation was interrupted; explicitly report the incomplete scope.
