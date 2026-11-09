---
name: publish-known-issue
description: "Use when asked to Add KI followed by a draft known issue, or publish a known issue with its Known_issues overview and toc.yml entries."
argument-hint: "Paste the draft known issue and any missing release/version details"
user-invocable: true
---

# Publish a known issue

Turn the draft known issue supplied in the request into a publication-ready page that matches the existing DataMiner Docs structure. Ask for the draft only if it is missing.

## Constraints

- Only edit the known issue page and the related navigation files.
- Do not invent missing product facts, affected versions, fix versions, or dates.
- If the draft is missing required details, ask for clarification before editing.
- Follow the wording and section structure used by nearby known issue pages.
- Keep US English and sentence casing.

## Required output

When you receive a draft, produce these changes:

1. Create the known issue page in `dataminer/Troubleshooting/Known_issues/`.
2. Ensure the page has valid front matter with a unique `uid`.
3. Add the page entry in `dataminer/Troubleshooting/Known_issues/Known_issues.md`.
4. Add the page to `dataminer/Troubleshooting/toc.yml`.

## Approach

1. Read `.github/instructions/dataminer-docs-house-style.instructions.md` and inspect a few existing known issue pages to match their tone, headings, and section order.
2. Convert the draft into the same style, keeping only verified facts.
3. Use a stable file name and matching unique `uid` based on the issue title, without spaces or special characters. Check for an existing page for the same issue before creating a duplicate.
4. Update the overview table with the new issue in the correct release section.
5. Update `toc.yml` so the page is discoverable.
6. Verify that all xrefs and filenames line up.

## Expected page structure

Use the closest existing pattern, typically:

- `## Affected versions`
- `## Cause`
- `## Fix`
- `## Workaround`
- `## Description`

## Output format

Return a concise summary of:

- files changed
- key content added
- any unanswered questions or missing source details
