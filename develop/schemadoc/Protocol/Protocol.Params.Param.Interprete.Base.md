---
uid: Protocol.Params.Param.Interprete.Base
description: "Use the Base element in a DataMiner protocol to select the numeral system used to interpret parameter values, from base 2 through base 36."
---

# Base element

Specifies the numeral system (decimal, hexadecimal, etc.).

## Type

unsignedInt

## Parent

[Interprete](xref:Protocol.Params.Param.Interprete)

## Remarks

Contains a number between 2 and 36. Default: 10

> [!NOTE]
> In case of base 36, the letters “a” through “z” (or “A” through “Z”) are assigned the values 10 through 35.

## Examples

```xml
<Base>10</Base>
```
