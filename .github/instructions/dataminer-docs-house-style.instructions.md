---
description: "Guidelines for writing and structuring DataMiner documentation, ensuring consistency, clarity, and user-focused technical content."
applyTo: "**/*.md"
---

# DataMiner Docs house style

When creating or editing documentation pages, apply the following rules.

- Use US English.
- Follow Markdown conventions from `/contributing/CTB_Markdown_Syntax.md`.
- Use `e.g.,` instead of `e.g.`.
- Use `i.e.,` instead of `i.e.`.
- Use sentence case in headers.
- Use descriptive alt text for images.
- Ensure each page has a `description` value in its metadata/front matter.
- Use a formal but simple technical style that helps users find information quickly.
- Address the reader directly with `you` and avoid third-person references to the user.
- Keep a logical structure with meaningful headers.
- For cross-references to pages within this repository, use DocFX `xref` links instead of hard links to local Markdown files.
- Use backticks for references to code, file paths, and user input, but not for emphasis.
- Do not place two note blocks immediately after one another. When that would occur, combine the content into a single note block that uses a bulleted list.

## Procedure formatting

- Write procedures as numbered lists.
- Use one logical action per numbered step.
- Keep instruction lines short and easy to scan.
- Put the result of a step on an indented line below that step.
- If a step contains an image, indent it correctly so list numbering does not restart.

## UI references

- Format direct UI references in italics.
- Use bold only when intentional emphasis is needed, for example an introductory UI label followed by a colon.
