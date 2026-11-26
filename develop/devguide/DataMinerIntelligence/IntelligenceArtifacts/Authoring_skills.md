---
uid: Authoring_Intelligence_skills
description: "Author custom DataMiner Intelligence skills as files, including their metadata, instructions, and companion resources."
---

# Authoring skills

You can author a custom skill as a `SKILL.md` file and deploy it with an Intelligence project or place it in the Assistant context directory. Use this approach when you need source control, reusable companion resources, or deployment automation.

If you only want to create and manage skills through the native DataMiner Assistant app, see [Skills](xref:Intelligence_Skills).

## Skill file location

For custom skills managed directly on a DataMiner System, add each `SKILL.md` file to its own folder under:

```text
C:\ProgramData\Skyline Communications\DataMiner Assistant\Synced Documents\Context\Custom\Skills
```

These folders are automatically discovered and synchronized across the cluster.

## Skill components

A skill folder contains a `SKILL.md` file and can contain additional text-based companion resources:

```text
Skills/
|-- incident-reporting/
|   |-- SKILL.md
|   |-- additional-context.md
|   `-- templates/
|       `-- incident-summary.md
```

Resources are scoped to the skill folder and are not discovered automatically. Reference each resource from `SKILL.md` using a path relative to the skill folder.

## SKILL.md format

The file must contain YAML frontmatter with the required `name` and `description` fields, followed by the skill instructions in Markdown. Declare the schema explicitly.

```markdown
---
name: incident-reporting
description: Produce an incident summary from verified evidence and identify missing information.
version: 1.0.0
schema-version: '2.0'
---

# Incident reporting

Include the incident identity, observed impact, evidence, and unresolved questions.
Distinguish observations from assumptions. Do not invent causes or recovery results.
```

The following validation rules apply:

- `name` is required, must use lowercase letters, digits, and single hyphens, and can contain a maximum of 64 characters.
- `description` is required and can contain a maximum of 1,024 characters.
- The folder name must match the skill name.
- The Markdown body contains the instructions and has no schema-defined maximum length.

Validate the project before deployment. For all supported fields and schema versions, see the [Intelligence artifact schema reference](xref:Intelligence_artifact_schemas).
