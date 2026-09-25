---
metadata_version: 1
uid: DMSScript.Memory
description: "Use the Memory element to contain an automation script's memory files and ensure that every file ID is unique within the collection."
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
