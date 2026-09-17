---
metadata_version: 1
uid: DMSScript.Script.Exe.MemoryPos
description: "Reference the DataMiner Automation script schema entry for MemoryPos element, including its documented structure, attributes, values, and constraints."
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
