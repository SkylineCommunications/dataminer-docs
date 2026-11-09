---
name: add-description
description: 'Use when asked to Add desc or add a metadata description to the current DataMiner Docs page or a supplied Markdown file.'
argument-hint: 'Optional page path; defaults to the current page'
---

# Add a description

1. Use the supplied page path or current editor page. Ask for a page if neither is available.
1. Read the complete page and its YAML front matter to identify its subject and focus keyword.
1. Add or update only the `description` field in the YAML front matter, preserving the `uid` and other metadata. Follow these guidelines:

   - Use an active voice and make it actionable.
   - Include a call to action.
   - Use the focus keyword.
   - Show specifications when possible.
   - Make sure it matches the content of the page.
   - Do not use colons.
   - Enclose the description in double quotes.
   - Make sure the description is between 100 and 155 characters long.

1. Count the characters in the description value, excluding the surrounding quotes, and revise until it is within the inclusive 100-155 character range.
1. Verify that the front matter remains valid YAML, escaping embedded double quotes if necessary, and summarize the change.
