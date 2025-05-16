---
uid: Functions.Function.Interfaces.Interface
---

# Interface element

Specifies an interface available on a function.

## Parent

[Interfaces](xref:Functions.Function.Interfaces)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[id](xref:Functions.Function.Interfaces.Interface-id)|integer|Yes|Specifies the unique GUID of the interface.|
|[name](xref:Functions.Function.Interfaces.Interface-name)|[TypeNonEmptyString](xref:Functions-TypeNonEmptyString)|Yes|Specifies the name of the interface.|
|[type](xref:Functions.Function.Interfaces.Interface-type)|[InputType](xref:Functions-TypeInputType)|Yes|Specifies the interface type, which can be *in*, *out*, or *inout*.|
|[profile](xref:Functions.Function.Interfaces.Interface-profile)|[guid](xref:Functions-TypeGuid)||The GUID of the profile corresponding to the interface.|
|[parameterGroupLink](xref:Functions.Function.Interfaces.Interface-parameterGroupLink)|integer||Links to a parameter group in the protocol to which the function is linked.|
|[broadcast](xref:Functions.Function.Interfaces.Interface-broadcast)|[EnumTrueFalseLowerCase](xref:Functions-EnumTrueFalseLowerCase)||When set to "true", this attribute indicates that there is no actual DCF connection, but the interface acts as a broadcaster to one or more receiving interfaces.|
