---
uid: Protocol.Groups.Group.Content.Param-next
---

# next attribute

Specifies the number of milliseconds DataMiner has to wait before reading the next parameter.

## Content Type

unsignedInt

## Parent

[Param](xref:Protocol.Groups.Group.Content.Param)

## Remarks

- If the last item in the group contains this attribute, it will also cause a delay before the next group is executed.

- Only applicable in case of single GETs.

- When this is applied on a table parameter with the [partialSNMP](xref:Protocol.Params.Param.SNMP.OID-options#partialsnmp) OID option active, it will also cause the delay to be applied between the execution of the different partial row gets, because this is considered to be the next get to execute.

- From DataMiner 10.1.0 [CU15]/10.2.0 [CU3]/10.2.6 onwards<!-- starting from RN 33197 until RN 39430-->, this attribute does not work correctly. For more information, see [Param next attribute not working](xref:KI_Param_next_not_working).
