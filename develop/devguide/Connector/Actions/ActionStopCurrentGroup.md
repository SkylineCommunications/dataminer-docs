---
metadata_version: 1
uid: LogicActionStopCurrentGroup
description: "Use the stop current group action to halt the running group when it contains pairs, except for SNMP groups with multipleGet enabled."
---

# stop current group

This action must be executed on protocol.

This action, which only affects groups containing pairs, will stop the execution of the group being processed.

> [!NOTE]
> This action cannot be used to stop an SNMP group of which multipleGet is set to true.

## Examples

```xml
<Action id="1">
   <On>protocol</On>
   <Type>stop current group</Type>
</Action>
```
