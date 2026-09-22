---
metadata_version: 1
uid: Protocol.Params.Param.SNMP.TrapMappings.TrapMapping-value
description: "Reference the DataMiner connector protocol schema entry for value attribute, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# value attribute

Specifies an alarm value.

## Content Type

string

## Parent

[TrapMapping](xref:Protocol.Params.Param.SNMP.TrapMappings.TrapMapping)

## Remarks

This attribute contains an alarm value, specified in the same way as the alarm value in the mapAlarm attribute of the Protocol.Params.Param.SNMP.TrapOID tag.

## Examples

```xml
<TrapMapping bindingMatch="2:1096" severity="Warning" value="Trap 1096 entered with binding 1 = [1]"/>
<TrapMapping bindingMatch="2:1097|1?98" severity="Minor" value="Trap 1097 entered with binding 1 = [1]"/>
<TrapMapping bindingMatch="2:109*" severity="Major" value="Trap 109* entered with binding 1 = [1]"/>
```
