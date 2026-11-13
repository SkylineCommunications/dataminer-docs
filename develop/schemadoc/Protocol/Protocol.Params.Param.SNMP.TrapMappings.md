---
uid: Protocol.Params.Param.SNMP.TrapMappings
description: "Use the TrapMappings element in a DataMiner protocol to define advanced SNMP trap alarm mappings when the TrapOID mapAlarm attribute is insufficient."
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

Use this section if the `mapAlarm` attribute of the [Protocol.Params.Param.SNMP.TrapOID](xref:Protocol.Params.Param.SNMP.TrapOID) element is too limited. If you want to make more advanced alarm mappings, add one or more `Protocol.Params.Param.SNMP.TrapMappings.TrapMapping` elements to this `Protocol.Params.Param.SNMP.TrapMappings` element.

> [!NOTE]
> It is possible to combine the `Protocol.Params.Param.SNMP.TrapMappings` element with the `mapAlarm` attribute of the [Protocol.Params.Param.SNMP.TrapOID](xref:Protocol.Params.Param.SNMP.TrapOID) element.
