---
metadata_version: 1
uid: LogicActionStart
description: "Describe the DataMiner connector development topic start, including its purpose, behavior, implementation guidance, and relevant constraints."
area: develop
content_type: conceptual
authority: unknown
authority_source: unknown
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# start

This action can be executed on timers only.

This action starts the specified timers.

## Attributes

### On@id

Specifies the ID(s) of the timer(s) to start.

## Examples

```xml
<Action id="1">
   <On id="1">timer</On>
   <Type>start</Type>
</Action>
```
