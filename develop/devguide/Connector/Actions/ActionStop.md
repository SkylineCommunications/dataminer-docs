---
metadata_version: 1
uid: LogicActionStop
description: "Use the stop action to stop one or more timers identified by their IDs in a DataMiner connector definition."
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
