---
metadata_version: 1
uid: Protocol.Groups.Group.Content-multipleGet
description: "Reference the DataMiner connector protocol schema entry for multipleGet attribute, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
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
