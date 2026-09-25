---
metadata_version: 1
uid: Protocol.Params.Param.Interprete.Rounding
description: "Learn how the Rounding element selects how DataMiner rounds a processed parameter value, with down as the default in a DataMiner connector protocol."
---

# Rounding element

<!-- RN 13519 -->

Specifies how the parameter value is rounded.

Default: down.

## Type

[EnumRounding](xref:Protocol-EnumRounding)

## Parent

[Interprete](xref:Protocol.Params.Param.Interprete)

## Examples

```xml
<Interprete>
   <RawType>unsigned number</RawType>
   <LengthType>fixed</LengthType>
   <Length>4</Length>
   <Type>double</Type>
   <Rounding>halfToInfinity</Rounding>
</Interprete>
```
