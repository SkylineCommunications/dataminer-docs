---
agent: 'agent'
description: 'This prompt is used to add a description to the yaml front matter of the open page'
---

Can you add a description to the yaml front matter of this file, keeping in mind the following guidelines:

- Use an active voice and make it actionable
- Include a call to action
- Use the focus keyword
- Show specifications when possible
- Make sure it matches the content of the page
- Do not use colons
- Enclose the description in double quotes
- Make sure the description is between 100 and 155 characters long
- If this page already has `metadata_version: 1`, preserve every required metadata field and validate the complete front matter with `scripts/validate-documentation-metadata.ps1`
- Do not invent an owner, product applicability, version, or review date; use the exact `unknown`, `not_applicable`, or `unversioned` value defined by `contributing/CTB_Documentation_Metadata.md`
