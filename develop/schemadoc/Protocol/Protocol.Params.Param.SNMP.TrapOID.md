---
uid: Protocol.Params.Param.SNMP.TrapOID
---

# TrapOID element

Specifies the SNMP traps DataMiner has to capture via this parameter.

## Type

string

## Parent

[SNMP](xref:Protocol.Params.Param.SNMP)

## Attributes

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Type|Required|Description|
|--- |--- |--- |--- |
|[checkBindings](xref:Protocol.Params.Param.SNMP.TrapOID-checkBindings)|string||Specifies basic filtering on the trap bindings.|
|[ipid](xref:Protocol.Params.Param.SNMP.TrapOID-ipid)|string||Specifies the ID of the parameter holding IP addresses.|
|[mapAlarm](xref:Protocol.Params.Param.SNMP.TrapOID-mapAlarm)|string||Allows an alarm to be generated when a trap is received.|
|[setBindings](xref:Protocol.Params.Param.SNMP.TrapOID-setBindings)|string||Specifies that the value of a certain binding should be set as the value of another parameter.|
|[type](xref:Protocol.Params.Param.SNMP.TrapOID-type)|[EnumTrapOIDType](xref:Protocol-EnumTrapOIDType)||Specifies how the trap OID is constructed.|

## Remarks

Contains an OID (possibly containing a wildcard).
