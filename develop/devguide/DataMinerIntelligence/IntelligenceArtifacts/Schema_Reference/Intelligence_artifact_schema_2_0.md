---
uid: Intelligence_artifact_schema_2_0
description: "Reference the schema 2.0 YAML fields, kebab-case names, body limits, and validation rules for DataMiner Intelligence artifacts."
---

# Schema 2.0

This reference describes Intelligence artifact schema 2.0. Intelligence files require DataMiner 10.7.1 or later. Schema 2.0 additionally requires the DataMiner web upgrade package for 10.7.2 on DataMiner 10.7.1, or a full DataMiner 10.7.2 installation or later. Compared with the 1.x schemas, it uses kebab-case names for declared frontmatter fields and adds the optional agent `user-facing` visibility field.

For compatibility and deployment behavior, see [Intelligence artifact schemas](xref:Intelligence_artifact_schemas).

## Version fields

These version fields apply to every artifact type:

- `version`: Artifact revision in `MAJOR.MINOR.PATCH` format, using non-negative 32-bit integers without leading zeros. Prerelease and build suffixes are not supported. Defaults to `1.0.0` when omitted.
- `schema-version`: Use `'2.0'` for this contract and declare it explicitly. If it is omitted in a legacy artifact, loading interprets the artifact as schema 1.0, not 2.0. Check that the installed SDK validator and target Assistant support 2.0 before using it.

## Artifact types and body limits

In an Intelligence SDK project, the folder determines the artifact type:

| Artifact | Folder | Body purpose | Maximum body length |
|--|--|--|--|
| Agent | `Agents` | Behavior, supported tasks, and boundaries. | 32,768 characters |
| Skill | `Skills` | Reusable knowledge or procedures. | No schema-defined limit |
| Script tool | `Scripts` | Instructions for using an automation script. | 8,192 characters |
| Ad hoc data source tool | `AdHoc` | Instructions for querying a GQI source. | 8,192 characters |
| DOM tool | `Dom` | Instructions for retrieving DOM data. | 8,192 characters |

## Common validation rules

- Required fields must be present and non-empty. The exception is `columns[].discretes[].value`, which must be present but can be an empty string.
- Scalar fields require scalar values, object fields require mappings, and lists require the documented entry shape. Optional fields can be omitted or null; optional lists can be empty.
- Names are trimmed before validation. Skill and tool names use kebab-case: lowercase letters or digits separated by single hyphens, with no leading or trailing hyphen. Agent names do not require kebab-case but cannot contain control characters.
- `description` and input argument `example` values have a maximum length of 1,024 characters wherever those fields are supported.
- Boolean fields accept YAML boolean values. Prefer `true` and `false` for clarity.
- Unknown fields produce warnings and are retained. A warning does not mean that the runtime uses an unknown field.
- Malformed YAML, cyclic aliases, nesting beyond 64 levels, and alias expansion beyond 100,000 nodes are rejected.

## Agent fields

| Field | Required | Shape and constraints |
|--|--|--|
| `name` | Yes | Scalar; maximum 128 characters; no control characters. |
| `description` | No | Scalar description. |
| `tools` | No | List of tool identifiers. |
| `skills` | No | List of skill identifiers. |
| `agents` | No | Delegation targets; list of non-empty GUID strings. |
| `user-facing` | No | Boolean visibility metadata. Defaults to `true` when omitted. |

Tool references identify Intelligence tool artifacts, not the names of backing automation scripts or data sources. Verify that the identifiers resolve to the intended artifacts. Delegation target availability, reserved agents, self-delegation, and active delegation cycles are checked by the Assistant service, not by the field schema.

The `user-facing` field controls whether clients show an agent in agent selectors. It does not prevent direct chat or delegation, and it cannot be changed for DataMiner-provided agents.

## Skill fields

| Field | Required | Shape and constraints |
|--|--|--|
| `name` | Yes | Kebab-case scalar; maximum 64 characters. |
| `description` | Yes | Non-empty scalar description. |

Put reusable instructions in the body. A skill describes knowledge or a procedure; it does not by itself expose a callable tool.

## Script tool fields

| Field | Required | Shape and constraints |
|--|--|--|
| `name` | Yes | Kebab-case scalar; maximum 128 characters. |
| `description` | No | Scalar description. |
| `script-name` | No | Scalar identity of the backing automation script. |
| `sync` | No | Boolean. |
| `requires-user-validation` | No | Boolean. |
| `input-arguments` | No | List of mappings with the fields below. |
| `input-arguments[].name` | Yes, per entry | Non-empty scalar input identity. |
| `input-arguments[].description` | No | Scalar description of the value to supply. |
| `input-arguments[].example` | No | Scalar example; quote serialized input values. |

Script input argument entries do not define a `type` field. Derive argument identities and formats from the backing script's XML definition and code. Schema validation does not verify that the script exists, that inputs bind correctly, or that execution is authorized. Do not expose an operator-interactive script as a non-interactive tool.

## Ad hoc data source tool fields

| Field | Required | Shape and constraints |
|--|--|--|
| `name` | Yes | Kebab-case scalar; maximum 128 characters. |
| `description` | No | Scalar description. |
| `data-source` | No | YAML string containing the serialized JSON reference for the backing GQI implementation, not its display name. |
| `columns` | No | List of [column mappings](#column-fields). |
| `input-arguments` | No | List of mappings with the fields below. |
| `input-arguments[].name` | Yes, per entry | Non-empty scalar input identity. |
| `input-arguments[].type` | Yes, per entry | One of the input types below. |
| `input-arguments[].description` | No | Scalar description. |
| `input-arguments[].example` | No | Scalar example. |

Input types are case-insensitive: `string`, `int`, `int32`, `double`, `float`, `boolean`, `bool`, `datetime`, and `dropdown`.

The official item template's `data-source` JSON contains `DataSourceInterface`, `ScriptName`, `LibraryName`, `TypeFullName`, and `TypeName`. Preserve the exact reference supplied by GQI for the deployed implementation and store it as a string, for example by enclosing the JSON in YAML single quotes. These properties identify the implementation, not its input argument values. See [Authoring tools](xref:Adding_tools_to_an_intelligence_agent) for the JSON structure and field explanations.

Match arguments and columns to the source declarations, including optional and conditional arguments. Source resolution and comparison with live GQI columns are service-side checks, not schema rules.

## DOM tool fields

| Field | Required | Shape and constraints |
|--|--|--|
| `name` | Yes | Kebab-case scalar; maximum 128 characters. |
| `description` | No | Scalar description. |
| `module` | Yes | Non-empty scalar module identity. |
| `definition` | Yes | Non-empty scalar definition identity. |
| `columns` | No | List of [column mappings](#column-fields). |

Resolve module and definition identities against the target DOM model. These fields being non-empty does not prove that the model exists.

## Column fields

Ad hoc data source and DOM tools share this column metadata:

| Field | Required | Shape and constraints |
|--|--|--|
| `name` | Yes, per column | Non-empty scalar column identity. |
| `type` | No | One of the column types below. |
| `description` | No | Scalar description. |
| `strict-discretes` | No | Boolean. |
| `discretes` | No | List of mappings describing discrete values. |
| `discretes[].value` | Yes, per entry | Scalar; an empty string is allowed. |
| `discretes[].display-value` | No | Scalar display label. |
| `numeric` | No | Mapping with the fields below. |
| `numeric.kind` | Yes, when `numeric` is supplied | `Int`, `Long`, or `Double`; case-sensitive. |
| `numeric.unit` | No | Scalar unit. |
| `numeric.min`, `numeric.max`, `numeric.step` | No | Decimal values without exponents or thousands separators. |
| `numeric.decimals` | No | 32-bit integer without leading zeros. |

Column types are case-insensitive: `string`, `int`, `int32`, `int64`, `double`, `number`, `boolean`, `datetime`, `date`, `timeSpan`, `dropdown`, `domInstanceId`, and `domDefinitionId`.

A column type can be omitted for live GQI backfill. Numeric values must fit in a .NET decimal. Use quoted decimal strings such as `'0.5'` when you need to preserve their exact YAML representation.

## Migration from schema 1.x

Assistant deployment preparation can migrate schema 1.x artifacts to schema 2.0 in memory without changing the stored file or the artifact `version`. The migration renames the following declared fields:

| Schema 1.x field | Schema 2.0 field |
|--|--|
| `userFacing` | `user-facing` |
| `scriptName` | `script-name` |
| `inputArguments` | `input-arguments` |
| `requiresUserValidation` | `requires-user-validation` |
| `dataSource` | `data-source` |
| `columns[].strictDiscretes` | `columns[].strict-discretes` |
| `columns[].discretes[].displayValue` | `columns[].discretes[].display-value` |

The migration applies renames only at the locations declared by the schema. Extension fields, user-defined argument names, and arbitrary dictionaries keep their original spelling. If both spellings of a field are present at the same location, migration fails. Legacy spellings are otherwise unknown fields in schema 2.0 and produce warnings without affecting runtime behavior.
