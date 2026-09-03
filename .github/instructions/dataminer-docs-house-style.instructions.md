---
description: "Guidelines for writing and structuring DataMiner documentation, ensuring consistency, clarity, and user-focused technical content."
applyTo: "**/*.md"
---

# DataMiner Docs house style

When creating or editing documentation pages, apply the following rules.

## General

- Use US English.
- Follow Markdown conventions from `/contributing/CTB_Markdown_Syntax.md`.
- Use sentence case in headers.
- Use a formal but simple technical style that helps users find information quickly.
- Address the reader directly with `you` and avoid third-person references to the user.
- For cross-references to pages within this repository, use DocFX `xref` links instead of hard links to local Markdown files.
- Only use backticks for references to code, file paths, or user input, not for emphasis.
- Format direct UI references in italics, using bold only for intentional emphasis, such as an introductory UI label followed by a colon.
- Use plain text in headers, avoiding italics, bold, or other formatting.
- When referring to changes introduced by a specific release note, make sure both the Main Release version and Feature Release version introducing the changes are mentioned on the page.

## Procedure formatting

- Write procedures as numbered lists.
- Use one logical action per numbered step.
- Keep instruction lines short and easy to scan.
- Put the result of a step on an indented line below that step.
- If a step contains an image, indent it correctly so list numbering does not restart.

## Alert blocks

- Only use the following alert types: `> [!NOTE]`, `> [!TIP]`, `> [!IMPORTANT]`, `> [!CAUTION]`, and `> [!WARNING]`. No other alert type (e.g., `> [!ALERT]`) is supported. Before adding or editing an alert, verify the type against `/contributing/CTB_Markdown_Syntax.md`.
- Never place two or more alert blocks of the same type directly after one another. Combine their content into a single alert block using a bulleted list instead.
- Avoid long alert blocks. If an alert block would be long, move its content to a regular text section instead.
- Avoid using several alert blocks in a row. If a more readable alternative exists, weave the content of some or all of the alerts into the regular text instead.
- Use `> [!CAUTION]` only for information about the possible negative consequences of an action.
- Use `> [!WARNING]` only for information about actions that could have far-reaching, dangerous consequences, such as breaking the DataMiner software.
- Use `> [!IMPORTANT]` for information a user must notice that has no direct negative or dangerous consequence.

## AI-friendly writing

- Use descriptive alt text for images.
- Ensure each page has a `description` value in its metadata/front matter, and ensure it is between 100 and 155 characters.
- Always make sure the text is structured logically, with meaningful headers that clearly indicate what each subsection is about.
- Make content as future-proof as possible, for instance by adding DataMiner version info where relevant, or by rephrasing text about new features to make sure it doesn't become outdated almost immediately.
- Give preference to a bulleted list or regular text over a table when either would be equally clear, since tables can be harder to interpret correctly.
- Only use a table when it is clearly the most user-friendly option for the content.

## Punctuation

- Use single quotation marks in headers.
- Use single quotation marks to indicate quoted material within a quotation (i.e., a nested quote); otherwise, use double quotation marks.
- Use `e.g.,` instead of `e.g.`.
- Use `i.e.,` instead of `i.e.`.
- Avoid em dashes.
- When referring to a menu option in the UI that contains an ellipsis (`...`) at the end, leave out the ellipsis.
