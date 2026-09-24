---
metadata_version: 1
uid: Protocol.Params.Param.SNMP.TrapMappings.TrapMapping-severity
description: "Learn how the severity attribute assigns a DataMiner alarm severity to a matched SNMP trap or suppresses the alarm in a DataMiner connector protocol."
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
