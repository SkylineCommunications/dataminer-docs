---
metadata_version: 1
uid: DMSScript.Script.Exe.MemoryPos
description: "Reference the DataMiner Automation script schema entry for MemoryPos element, including its documented structure, attributes, values, and constraints."
content_type: schema
applies_to:
  - DataMiner
---

# MemoryPos element

Specifies the memory position to get or set.

## Type

string

## Parent

[Exe](xref:DMSScript.Script.Exe)

## Remarks

Format "memory file ID:position of the item to retrieve or set" e.g., "2:100".

## Examples

```xml
<MemoryPos>2:4</MemoryPos>
```
