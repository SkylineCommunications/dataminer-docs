---
uid: Protocol.Params.Param.SNMP.OID-id
---

# id attribute

Specifies the ID of the parameter holding the (partial) OID.

## Content Type

[TypeParamId](xref:Protocol-TypeParamId)

## Parent

[OID](xref:Protocol.Params.Param.SNMP.OID)

## Remarks

Can be used when using type "complete", "composed" or "wildcard". Refer to the type attribute for more information.

In case of `options=subtable`, “id” has to contain the ID of the parameter holding the instance filter for the table.

## Examples

In the following examples, the asterisk in the OID tag will be replaced by the contents of parameter 215:

```xml
<OID id="215">1.3.6.1.4.1.1773.*</OID>
<OID id="215">*</OID>
```
