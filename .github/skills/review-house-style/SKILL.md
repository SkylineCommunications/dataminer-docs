---
name: review-house-style
description: "Use when asked to Review a DataMiner Docs page or section for house style, Markdown syntax, image alt text, metadata descriptions, and logical structure."
argument-hint: "Provide one or more file paths, or paste the page/section text to review."
---
# Review house style

Review a documentation page or section and report whether it follows the house style. Use the supplied paths or text, or the current editor page/selection. Ask for a target if none is available.

## Scope and standards
- Enforce all rules defined in `/.github/instructions/dataminer-docs-house-style.instructions.md`. Read that file before reviewing, and treat it as the single source of truth for house style rules.
- Review Markdown and structure against `/contributing/CTB_Markdown_Syntax.md`.
- Review against US English usage.

## Approach
1. If the user has not already selected a mode, use the available question tool to ask whether to apply the changes directly or list the issues in chat. Do not edit before the user chooses the apply mode.
2. Read the provided page/section content and related front matter.
3. Check each rule in the scope list.
4. Prioritize issues that affect readability, consistency, and navigation first.
5. Follow the requested output mode:
   - If the user asks to apply changes directly, edit the relevant files.
   - Otherwise, list each issue with line number and correction suggestion.

## Constraints
- Do not invent repository conventions beyond the house style instructions and referenced CTB syntax guidance.
- Do not rewrite the whole page unless the user explicitly asks for a full rewrite.
- Keep feedback concise, actionable, and specific.
- If no line number can be determined, explicitly state that the location is approximate and reference the nearest heading.

## Output format
For a bare `Review` request, first ask using the available question tool:
- "Do you want me to apply the changes directly, or list the issues in chat?"

Then respond based on the user's choice:

- **If applying directly**:
  - Make the edits.
  - Summarize what was changed in a concise bullet list.

- **If listing in chat**:
  - List every issue in this format:
    - `Line <number>`: `<issue>`
      - `Suggestion:` `<how to correct it>`
