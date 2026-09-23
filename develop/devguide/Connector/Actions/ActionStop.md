---
metadata_version: 1
uid: LogicActionStop
description: "Describe the DataMiner connector development topic stop, including its purpose, behavior, implementation guidance, and relevant constraints."
content_type: conceptual
applies_to:
  - DataMiner
---

# stop

This action can be executed on timers only.

This action stops the specified timers.

## Attributes

### On@id

Specifies the ID(s) of the timer(s) to stop.

## Examples

```xml
<Action id="1">
   <On id="1">timer</On>
   <Type>stop</Type>
</Action>
```
