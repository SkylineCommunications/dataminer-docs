---
uid: Protocol.Params.Param.SNMP.OID
---

# OID element

Specifies the OID.

## Type

string

## Parent

[SNMP](xref:Protocol.Params.Param.SNMP)

## Attributes

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Type|Required|Description|
|--- |--- |--- |--- |
|[id](xref:Protocol.Params.Param.SNMP.OID-id)|[TypeParamId](xref:Protocol-TypeParamId)||Specifies the ID of the parameter holding the (partial) OID.|
|[ipid](xref:Protocol.Params.Param.SNMP.OID-ipid)|[TypeParamId](xref:Protocol-TypeParamId)||Specifies the ID of the parameter holding the IP address that needs to be used to poll this SNMP parameter.|
|[options](xref:Protocol.Params.Param.SNMP.OID-options)|string||Specifies a number of options (separated by semicolons).|
|[skipDynamicSNMPGet](xref:Protocol.Params.Param.SNMP.OID-skipDynamicSNMPGet)|[EnumTrueFalse](xref:Protocol-EnumTrueFalse)||Specifies that the evaluation of a certain parameter is skipped if it needs to be retrieved via a dynamic SNMP Get.|
|[type](xref:Protocol.Params.Param.SNMP.OID-type)|[EnumOIDType](xref:Protocol-EnumOIDType)||Specifies how the OID is constructed.|
