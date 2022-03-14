---
uid: Protocol.Params.Param.Interprete.Type-trim
---

# trim attribute

Specifies whether to remove leading and/or trailing whitespace.

## Content Type

[EnumInterpretTypeTrim](xref:Protocol-EnumInterpretTypeTrim)

## Parent

[Type](xref:Protocol.Params.Param.Interprete.Type)

## Remarks

You can specify the following values. If you add both values, separate them by a semicolon (”;”).

- left: all leading whitespace will be removed
- right: all trailing whitespace will be removed.

## Examples

```xml
<Type trim="left;right">String</Type>
```
