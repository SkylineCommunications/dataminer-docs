---
uid: Protocol.Groups.Group.Content-multipleGet
description: "Use the multipleGet attribute in a DataMiner protocol to combine all group parameters into one SNMP Get operation."
---

# multipleGet attribute

If "true", all parameters will be read in one SNMP Get operation.

## Content Type

[EnumTrueFalse](xref:Protocol-EnumTrueFalse)

## Parent

[Content](xref:Protocol.Groups.Group.Content)

## Remarks

> [!NOTE]
>
> - If one parameter causes an error, none of the parameters will receive data. This will result in “no such name” errors.
> - The multipleGet option cannot be used with parameters of type “Array”.
