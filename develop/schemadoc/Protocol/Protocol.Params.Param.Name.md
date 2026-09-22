---
metadata_version: 1
uid: Protocol.Params.Param.Name
description: "Reference the DataMiner connector protocol schema entry for Name element, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# Name element

Specifies the name of the parameter.

## Type

[TypeNonEmptyString](xref:Protocol-TypeNonEmptyString)

## Parent

[Param](xref:Protocol.Params.Param)

## Remarks

In this mandatory tag, you must specify the name of the parameter. Typically, the parameter name refers to the technical name of the parameter, while the parameter description provides a more common name or description.

Although it is possible that the value of this tag is used in alarm notifications, typically the parameter description will be used. See [Protocol.Params.Param.Description](xref:Protocol.Params.Param.Description).

> [!NOTE]
> The name must be unique throughout the protocol.
