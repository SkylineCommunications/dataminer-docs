---
uid: Protocol.Params.Param.Interprete.Sequence-noset
---

# noset attribute

When set to “true”, sequences will not be taken into account when the parameter gets a new value.

## Content Type

[EnumTrueFalse](xref:Protocol-EnumTrueFalse)

## Parent

[Sequence](xref:Protocol.Params.Param.Interprete.Sequence)

## Remarks

- On read parameters, always use this attribute with the value set to `true`.
- On write parameters, always  use this attribute with the value set to `true` and with the opposite math operation compared to the corresponding read parameter.

Example

- Read parameter: `<Sequence noset=”true”>div:100</Sequence>`
- Write parameter: `<Sequence noset=”true”>factor:100</Sequence> or <Sequence noset=”true”>*:100</Sequence>`

## Examples

```xml
<Sequence noset="true">+:50;*:id:200</Sequence>
```
