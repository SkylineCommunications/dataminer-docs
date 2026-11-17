---
name: check-known-issues
description: "Use when asked to Check KI, check known issues, or find which unresolved known issues have been fixed in the meantime. Reads the Collaboration task and release note IDs stored in comments and reports proposed updates."
argument-hint: "Optional: one known issue page or uid; otherwise all unresolved known issues"
user-invocable: true
---

# Check unresolved known issues

Find unresolved known issues that now have a fix, using the Collaboration task and release note IDs stored as HTML comments in the known issue pages. This skill is read-only unless the user explicitly asks to apply the proposed changes.

## ID comment convention

Known issue pages in `dataminer/Troubleshooting/Known_issues/` store the related Collaboration data as HTML comments in the `## Fix` section:

- `<!-- Task 12345 -->`: the Collaboration task that tracks the fix.
- `<!-- RN 12345 -->`: the release note that documents the fix, including a release note that was created for a fix that is not released yet.

Existing fixed issues already use `<!-- RN 12345 -->` after the fix version. Ignore spacing differences (`<!--RN 12345-->`).

## Approach

1. Read the table(s) in `dataminer/Troubleshooting/Known_issues/Known_issues.md`. Unresolved known issues are the rows with an empty *Resolved in* column. If the user named a page or uid, check only that issue.
1. For each unresolved issue, open its page and collect all `Task <ID>` and `RN <ID>` comments. Also note the *Affected versions* and *Fix* sections.
1. Retrieve the data from SkylineApi through the Collaboration MCP server. Use the tool-search tool first if the tools are not available yet. Typical tools: get task by ID, get task relationships, get release note by ID. If the server is unavailable, report the failure with the setup steps from [add-rn](../add-rn/SKILL.md) and stop.
   - For an `RN` ID: retrieve the release note and note its release versions and whether those releases are already published.
   - For a `Task` ID: retrieve the task and note its status and resolution, and check its relationships for linked release notes. A linked release note that is not yet in the page is treated like an `RN` ID.
   - If a release note is linked to a soft-launch option listed in `dataminer/Reference/Soft-launch_options/Overview_of_Soft_Launch_Options.md`, report that the fix is not generally available yet.
1. Classify each issue:
   - **Fixed and released**: a release note with fix versions exists, and the release is published (search the RN ID in `release-notes`).
   - **Fix planned**: a release note or task exists, but there is no published release yet or the task is still open.
   - **No change**: the task is still open and has no release note.
   - **Missing IDs**: the page has no `Task` or `RN` comment. Search for candidate tasks using keywords from the title (read-only) and list them, but never assume a match.
   - **Needs manual review**: contradictory data, a closed task without release note, and so on.
1. Report the results in a table, grouped by classification:

   | Issue | IDs checked | Status | Fix versions | Proposed action |
   | -- | -- | -- | -- | -- |

1. Never edit files without confirmation. If the user asks to apply the changes, do so for **Fixed and released** issues only, following [publish-known-issue](../publish-known-issue/SKILL.md) and the style of existing fixed known issues:
   - In the page, replace "No fix is available yet." with all fix versions from the release note (Main Release, Feature Release, and CU versions where applicable, e.g., "10.7.0/10.6.11"), keeping the `<!-- RN <ID> -->` comment.
   - In `Known_issues.md`, fill in *Resolved in* with all those versions, using the same notation as the other rows (Main Release before Feature Release).
   - Keep the existing row order.

## Constraints

- Do not invent fix versions, dates, or IDs. Use only data returned by SkylineApi or the release notes in this repository.
- Do not update Collaboration data.
- Do not commit or push.
- Fix versions in the table and page must match the published release notes.

## Output format

Return the results table, the list of issues that miss IDs, and (if changes were applied) the files changed.
