---
uid: Protocol.Params.Param.SNMP
---

# SNMP element

Specifies SNMP related functionality for this parameter.

## Parent

[Param](xref:Protocol.Params.Param)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[options](xref:Protocol.Params.Param.SNMP-options)|string||Specifies a dynamic get or set community string for a particular connection.|

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[Enabled](xref:Protocol.Params.Param.SNMP.Enabled)|[0, 1]|Specifies whether DataMiner is allowed to interrogate the SNMP Agent.|
|&nbsp;&nbsp;[Factor](xref:Protocol.Params.Param.SNMP.Factor)|[0, 1]|Specifies that all values will be divided by the specified factor.|
|&nbsp;&nbsp;[InvalidResponseHandling](xref:Protocol.Params.Param.SNMP.InvalidResponseHandling)|[0, 1]|Specifies the invalid response handling strategy.|
|&nbsp;&nbsp;[OID](xref:Protocol.Params.Param.SNMP.OID)|[0, 1]|Specifies the OID.|
|&nbsp;&nbsp;[TrapMappings](xref:Protocol.Params.Param.SNMP.TrapMappings)|[0, 1]|Specifies trap mappings.|
|&nbsp;&nbsp;[TrapOID](xref:Protocol.Params.Param.SNMP.TrapOID)|[0, 1]|Specifies the SNMP traps DataMiner has to capture via this parameter.|
|&nbsp;&nbsp;[Type](xref:Protocol.Params.Param.SNMP.Type)|[0, 1]|Specifies the SNMP type.|

## Remarks

Only used in protocols for elements that are SNMP-compliant.

In case of such an element, DataMiner will interrogate the SNMP agent specified in Protocol.Params.Param.SNMP.OID or capture traps defined in Protocol.Params.Param.SNMP.TrapOID.
