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

If you do not specify the noset attribute, or you set it to “false”, sequences will be taken into account when the parameter gets a new value.

- If, for a parameter, you specified sequence “*:10” with “noset” set to “false”, the incoming value will be divided by 10 before storing the value in the parameter, and will be multiplied by 10 when the parameter is displayed on the user interface.

If you set “noset” to “true”, sequences will not be taken into account when the parameter gets a new value.

- If, for a parameter, you specified sequence “*:10” with “noset” set to “true”, the incoming value will not be divided by 10 before the value is stored in the parameter. However, it will be multiplied by 10 when the parameter is displayed on the user interface.

## Examples

```xml
<Sequence noset="false">+:50;*:id:200</Sequence>
```
