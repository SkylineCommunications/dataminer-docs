---
metadata_version: 1
uid: DMSScript.Memory
description: "Reference the DataMiner Automation script schema entry for Memory element, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaAutomationScript
lifecycle: active
applies_to:
  - DataMiner
version: unknown
owner: unknown
review_status: needs_update
review_date: 2026-09-17
compatibility:
  uid: stable
  url: stable
---

# Memory element

Contains the memory files.

## Parent

[DMSScript](xref:DMSScript)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***Sequence***|[0, *]||
|&nbsp;&nbsp;[File](xref:DMSScript.Memory.File)||Defines a memory file.|

## Constraints

|Type|Description|Selector|Fields
|--- |--- |--- |--- |
|Unique |The ID must be unique. |Memory |@id |
