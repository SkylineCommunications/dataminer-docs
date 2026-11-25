---
name: update-docs-with-rn
description: 'Use when asked to Update docs with a release note ID or assess RN documentation impact. Compare the published and original RN, then update the user or developer guide only where needed.'
argument-hint: 'Any release note number (e.g., 45557)'
---

# Update documentation with a release note

Decide whether a release note requires a user-guide or developer-guide update, and apply that update after approval from the user. This skill does not publish the release note itself.

## Workflow

1. **Look up the release note in the documentation.**
   - Ask the user for a release note number if not already provided (for example, `45557`).
   - Search `release-notes/` for the entry with that release note number.
   - If it cannot be found, continue with step 2 and rely on the original release note instead.

2. **Retrieve the original release note from SkylineApi.**
   - Use the Collaboration MCP Server to retrieve the original release note from SkylineApi (as published by the developer on collaboration.dataminer.services) for the same release note number. Discover the release-note retrieval tool if necessary.
   - The original release note sometimes contains more detail and background than the documented version, such as the developer's own description, the affected components, and the exact versions.
   - If the Collaboration MCP Server is not available or the release note cannot be retrieved, explicitly report the retrieval problem, tell the user that only the documented version is used if available, and provide the setup instructions below.
   - If neither version can be retrieved, ask the user to clarify or paste the release note content.

3. **Compare both versions and show them to the user.**
   - Show both the documented release note content (title and description) and the original release note content, so the user knows what the release note is about, before continuing with the analysis. If either version is unavailable, label it unavailable rather than fabricating a quote. If only the original is available, use its category and versions, explicitly noting that no documented category is available.
   - Base the analysis on the combined information from both versions. Where they differ, use the original release note for technical detail and the documented version for the wording and versions published in the docs.
   - Compare the release note categories. Release notes are categorized as bug fixes, new features, or enhancements. Treat the category in the documented release note as authoritative. A different category in the original release note means its developer-selected category was corrected during publication in the DataMiner Docs.
   - Explicitly point out any relevant information that is present in the original release note but missing from the documented version, or vice versa.
   - Explicitly point out a category difference, but do not treat it as a documentation discrepancy that needs to be corrected.

4. **Analyze the release note content.**
   - Identify every individual change, feature, enhancement, or bug fix listed.
   - Use the authoritative documented category as an important signal when determining documentation impact:
      - **Bug fixes** usually do not require a documentation update when they restore behavior that should already be documented. Assess them for exceptions: a bug fix requires an update if it introduces or changes a user or developer workflow, such as adding a button or another control to resolve the issue.
      - **New features** and **enhancements** are more likely to require a documentation update. Still assess the actual behavior rather than deciding from the category alone. Do not update the documentation for behind-the-scenes changes that only improve performance or implementation.
   - For each item, classify it as one of:
     - **User-facing change**: visible in the UI, changes a workflow/process, adds/removes/changes a functionality, changes default behavior, or otherwise something a user would notice.
     - **Developer-facing change**: affects APIs, SDKs, scripting, connectors, or other developer-oriented interfaces documented under `develop/`.
     - **Not documentation-relevant**: internal performance improvements, refactors, bug fixes that restore documented behavior (not new behavior), or purely internal/technical changes with no observable effect.
   - Performance improvements ("X is now faster") are **not** documentation-relevant unless they change how a user interacts with a feature.

5. **Cross-check existing documentation.**
   - For user-facing changes, search `dataminer/` for the relevant section(s).
   - For developer-facing changes, search `develop/` for the relevant section(s).
   - If the user has already pasted one or more relevant user guide/developer guide sections, use those directly instead of searching.
   - Determine whether the current text already reflects the new behavior, is silent on it, or contradicts it.

6. **Decide and report.**
   - For each item, state clearly whether a documentation update is required, and why.
   - Items with no impact are marked "no user documentation update required" (or "no developer documentation update required").
   - If a release note item is ambiguous or unclear, ask the user for clarification instead of guessing.

7. **If an update is required, propose it to the user for review.**
   - Integrate the change into the existing text rather than appending disconnected notes; match the surrounding tone, structure, and heading style.
   - Always mention the DataMiner version(s) (Main Release and Feature Release, when applicable) from which the new/changed behavior is available.
   - Keep the old way of working documented as well (for users on older, still-supported DataMiner versions), clearly distinguishing it from the new behavior by version.
   - Read and follow the house style rules in `.github/instructions/dataminer-docs-house-style.instructions.md` (sentence casing, US English, no em dashes, etc.).
   - Update the corresponding `toc.yml` only if a new page is created; prefer editing existing pages over creating new ones.
   - Do not remove or alter unrelated content.
   - Do not apply changes without the user's explicit approval.

## Output format

Start by quoting both the documented release note content (title and description) and the original release note retrieved from SkylineApi, so the user knows what the release note is about and can see any differences between the two versions.

Then, for each analyzed release note item, report:

- A short description of the change.
- The authoritative category and, if it differs, the original Collaboration category.
- Classification (user-facing / developer-facing / not relevant).
- Decision (update required / no update required) with brief reasoning.
- If updated: which file(s) were changed and a short summary of the change, including the version(s) mentioned.
- If clarification is needed: the specific question to resolve the ambiguity.

## Constraints

- Never guess at DataMiner version numbers; use only what is stated in the release note or explicitly provided by the user.
- Never remove documentation of older, still-supported behavior when adding new behavior.
- Do not invent functionality that isn't described in the release note.
- Only edit documentation files directly relevant to the analyzed release note.

## Collaboration MCP setup

This server is available only to Skyline employees.

1. In VS Code, press Ctrl+Shift+P and select *MCP: List Servers*.
1. If the server is not listed, select *+ Add Server*, then *HTTP*.
1. Enter `https://collaboration-mcp-server.thankfulsea-26bd4902.westeurope.azurecontainerapps.io/mcp` and select *Global*.
