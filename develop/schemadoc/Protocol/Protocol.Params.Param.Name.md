---
uid: Protocol.Params.Param.Name
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
