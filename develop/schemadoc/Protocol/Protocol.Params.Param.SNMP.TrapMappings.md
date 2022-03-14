---
uid: Protocol.Params.Param.SNMP.TrapMappings
---

# TrapMappings element

Specifies trap mappings.

## Parent

[SNMP](xref:Protocol.Params.Param.SNMP)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[TrapMapping](xref:Protocol.Params.Param.SNMP.TrapMappings.TrapMapping)|[0, *]|Specifies a trap mapping.|

## Remarks

Use this section if the mapAlarm attribute of the Protocol.Params.Param.SNMP.TrapOID tag is too limited. If you want to make more advanced Alarm mappings, add one or more Protocol.Params.Param.SNMP.TrapMappings.TrapMapping elements to this Protocol.Params.Param.SNMP.TrapMappings tag.

> [!NOTE]
> It is possible to combine the Protocol.Params.Param.SNMP.TrapMappings tag with the mapAlarm attribute of the Protocol.Params.Param.SNMP.TrapOID tag.
