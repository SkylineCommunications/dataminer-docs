---
uid: Protocol.Params.Param.SNMP.OID-ipid
---

# ipid attribute

Specifies the ID of the parameter holding the IP address that needs to be used to poll this SNMP parameter.

## Content Type

[TypeParamId](xref:Protocol-TypeParamId)

## Parent

[OID](xref:Protocol.Params.Param.SNMP.OID)

## Remarks

If, for the SNMP parameter, polling has to be performed on an alternative IP address, then, in the `ipid` attribute, specify the ID of the parameter holding the alternative IP address.

If you do not specify a port, the default port will be the port defined on the element connection.<!-- RN 10802 -->
