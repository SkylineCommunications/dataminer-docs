---
agent: 'agent'
description: 'This prompt is used to search for dead links in Mermaid diagrams'
---

# Dead Links in Mermaid Diagrams

## Instructions

1. Go through the repository and list all Mermaid diagrams that contain hyperlinks.
1. Check any of those hyperlinks to see if they are dead.
1. For every dead link found, list the file, the line number, the inaccessible URL, and the status code.

   Use this exact output format:

   ```markdown
 
   Number of broken links: <Number of broken links>

   | File | Line | URL | Status |
   |------|------|-----|--------|
   | `path/to/file.md` | 42 | https://example.com/broken | 404 |
   ```
