---
metadata_version: 1
uid: DMSScript.Script.Exe.MemoryPos
description: "Use the MemoryPos element to identify the memory file and item position that a get or set action accesses in an automation script."
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
