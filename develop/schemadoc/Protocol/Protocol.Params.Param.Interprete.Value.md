---
uid: Protocol.Params.Param.Interprete.Value
description: "Use the Value element in a DataMiner protocol to set the fixed content of a parameter that uses a fixed length and value."
---

# Value element

In case of a parameter with a fixed length and a fixed value, set the `Protocol.Params.Param.Interprete.LengthType` tag to `fixed` and use this `Value` tag to specify the fixed value.

## Type

string

## Parent

[Interprete](xref:Protocol.Params.Param.Interprete)

## Examples

```xml
<Interprete>
   ...
   <LengthType>fixed</LengthType>
   <Value>abc</Value>
   ...
</Interprete>
```
