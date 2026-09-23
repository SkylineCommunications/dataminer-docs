---
metadata_version: 1
uid: Protocol.Params.Param.SNMP.TrapMappings.TrapMapping-severity
description: "Reference the DataMiner connector protocol schema entry for severity attribute, including its documented structure, attributes, values, and constraints."
content_type: schema
applies_to:
  - DataMiner
---

# severity attribute

Specifies a DataMiner severity level.

## Content Type

string

## Parent

[TrapMapping](xref:Protocol.Params.Param.SNMP.TrapMappings.TrapMapping)

## Remarks

You can also specify “NoAlarm” (or “NoTrap”) to indicate that no alarm should be generated.

The severity level information will always overwrite previously assigned severity levels.

## Examples

```xml
<TrapMapping bindingMatch="1:1" severity="Normal"/>
<TrapMapping bindingMatch="*" severity="NoTrap"/>
```
