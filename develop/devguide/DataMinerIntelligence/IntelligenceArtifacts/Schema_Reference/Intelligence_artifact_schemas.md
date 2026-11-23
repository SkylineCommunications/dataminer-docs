---
uid: Intelligence_artifact_schemas
description: "Choose a DataMiner Intelligence artifact schema version and understand compatibility, version defaults, and validation before deployment."
---

# Intelligence artifact schemas

Intelligence artifacts contain YAML frontmatter followed by a Markdown body. The artifact type and schema version determine the metadata contract. Use the version-specific references below for the complete fields and body limits for agents, skills, and script, GQI, and DOM tools.

For a template-based example, see [Getting started with Intelligence artifacts](xref:Creating_Intelligence_artifacts).

## Frontmatter and versions

Start the file with a `---` delimiter and close its YAML frontmatter with another `---` on its own line. The remaining content is the Markdown body.

```yaml
---
name: incident-summary
description: Summarize verified incident information.
version: 1.0.0
schema-version: '1.0'
---
```

Two optional fields apply to every artifact type:

- `version` identifies the artifact revision. Use `MAJOR.MINOR.PATCH`, with non-negative 32-bit integers and no leading zeros. Prerelease and build suffixes are not supported. If omitted, the default is `1.0.0`.
- `schema-version` identifies the metadata contract, not the artifact revision or NuGet package version. Use a quoted `major.minor` value. If omitted, loading treats it as `1.0`.

## Schema versions

| Schema version | Changes | Reference |
|--|--|--|
| 1.0 | Defines agent, skill, script tool, ad hoc data source tool, and DOM tool metadata. Also the fallback when `schema-version` is omitted. | [Schema 1.0](xref:Intelligence_artifact_schema_1_0) |
| 1.1 | Adds the optional agent `agents` list for delegation. Other artifact fields are unchanged. | [Schema 1.1](xref:Intelligence_artifact_schema_1_1) |

Use schema 1.1 when authoring delegation metadata. Check that the installed SDK and target Assistant support the selected schema; a schema newer than the validator's supported version is rejected. A schema version is not an SDK or Assistant release number.

Each schema version has its own complete reference. Select the page matching the artifact's declared `schema-version` rather than assuming that the latest documented fields are available in every version.

## Validation and deployment

Build the Intelligence SDK project to validate its artifacts. The `Skyline.DataMiner.Intelligence.Schema` library also exposes `ContextArtifactSchemaService.Validate` for tooling that needs field-level feedback. It returns errors and warnings separately; callers determine how to surface them.

Validation does not rewrite the artifact. Assistant deployment preparation can normalize names, supply missing versions, and upgrade an older schema in memory without modifying the stored file or incrementing its artifact version. Do not assume that loading an artifact upgrades its source file.

Check references, backing source contracts, permissions, and representative invocation results separately. Schema validity alone does not establish runtime capability.
