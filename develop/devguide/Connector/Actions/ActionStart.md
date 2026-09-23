---
metadata_version: 1
uid: LogicActionStart
description: "Use the start action to start one or more timers identified by their IDs in a DataMiner connector definition."
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
