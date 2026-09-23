---
metadata_version: 1
uid: LogicActionStopCurrentGroup
description: "Describe the DataMiner connector development topic stop current group, including its purpose, behavior, implementation guidance, and relevant constraints."
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
