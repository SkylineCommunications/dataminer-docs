---
name: add-rn
description: 'Use when asked to Add RN followed by any release note ID. Retrieve the RN from SkylineApi, check version-specific soft-launch exclusions, and publish it in the correct release-note files.'
argument-hint: 'Release note ID'
---

# Add a release note

1. Use the release note ID from the request. Ask for it only if it was not supplied.

1. Retrieve the release note by ID from SkylineApi through the Collaboration MCP Server. Discover the release-note retrieval tool if necessary. If retrieval fails or the server is unavailable, report the problem, provide the setup instructions below, and stop rather than inventing content.

1. Check if the release note is linked to one of the soft-launch options listed on the page `/dataminer/Reference/Soft-launch_options/Overview_of_Soft_Launch_Options.md`. Make sure to check the release version.

1. If it is linked to one of the soft launch options, return the soft launch option it is linked to in the chat using the following specified syntax, and abort the process. Do not continue to the next step.

   ```markdown
   RN <RELEASE_NOTE_ID> is linked to soft launch option [<SOFT_LAUNCH_OPTION>](<Link to the soft launch option>).
   It will not be documented in the release notes.
   ```

1. If the release note is not linked to any of the existing soft launch options, document it in the correct Markdown file(s) under `release-notes`.

   - Read `.github/instructions/release-notes-writing.instructions.md` and the applicable repository instructions before editing.
   - Use the retrieved product/component, release versions, and category to select every applicable file and section. Inspect nearby entries and previous releases for the correct format. Do not guess missing versions or destinations; ask if they cannot be determined.
   - Search for the RN ID first to avoid duplicate entries. Preserve unrelated release notes and metadata.
   - If a required release file does not exist, ask for the missing release-cycle details or confirmation before creating it. Use [new-files-for-release](../new-files-for-release/SKILL.md) when a full release-cycle scaffold is requested.
1. Verify the RN ID, category, version coverage, and formatting in every changed file. Summarize the files updated or explain why no change was needed.

## Collaboration MCP setup

This server is available only to Skyline employees.

1. In VS Code, press Ctrl+Shift+P and select *MCP: List Servers*.
1. If the server is not listed, select *+ Add Server*, then *HTTP*.
1. Enter `https://collaboration-mcp-server.thankfulsea-26bd4902.westeurope.azurecontainerapps.io/mcp` and select *Global*.
