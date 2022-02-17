---
uid: Protocol.Params.Param.SNMP.OID-skipDynamicSNMPGet
---

# skipDynamicSNMPGet attribute

Specifies that the evaluation of a certain parameter is skipped if it needs to be retrieved via a dynamic SNMP Get.

## Content Type

[EnumTrueFalse](xref:Protocol-EnumTrueFalse)

## Parent

[OID](xref:Protocol.Params.Param.SNMP.OID)

## Remarks

Use this attribute to skip the evaluation of a certain parameter if it needs to be retrieved via a dynamic SNMP Get. See [options](xref:Protocol.Params.Param.Type-options).

*Feature introduced in DataMiner 8.0.1 (RN 5791).*

## Examples

```xml
<OID type="complete" ipid="201" skipDynamicSNMPGet="true">1.3.6.0</OID>
```
