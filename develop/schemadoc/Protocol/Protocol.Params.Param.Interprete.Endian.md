---
uid: Protocol.Params.Param.Interprete.Endian
description: "Use the Endian element in a DataMiner protocol to control byte-order reversal for unsigned numbers, which defaults to little-endian processing."
---

# Endian element

Specifies whether DataMiner must reverse the byte order (only relevant in case of unsigned numbers).

## Type

[EnumParamInterpretEndian](xref:Protocol-EnumParamInterpretEndian)

## Parent

[Interprete](xref:Protocol.Params.Param.Interprete)

## Remarks

By default, little-endian is used.

## Examples

```xml
<Endian>big</Endian>
```
