---
agent: 'agent'
description: 'This prompt is used to search for dead links in Mermaid diagrams'
---

# Dead Links in Mermaid Diagrams

## Instructions

1. Go through the repository and list all Mermaid diagrams that contain hyperlinks.
1. Check any of those hyperlinks to see if they are dead.

<!--    - Treat status codes **200–399** as **alive**.
   - Treat status code **410** as **dead**.
   - Treat status code **451** as **dead**.
   - Treat status codes **401, 403, 405, 429** and connection errors as **unknown / unverifiable** (do not mark as dead).
   - Treat **404 as dead only when both HEAD and GET return 404** and the URL is not in a known false-positive category. -->

1. For every dead link found, list the file, the line number, the inaccessible URL, and the status code.

   Use this exact output format:

   ```markdown
 
   | File | Line | URL | Status |
   |------|------|-----|--------|
   | `path/to/file.md` | 42 | https://example.com/broken | 404 |
   ```
