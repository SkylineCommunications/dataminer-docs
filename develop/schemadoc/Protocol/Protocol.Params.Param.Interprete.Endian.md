---
metadata_version: 1
uid: Protocol.Params.Param.Interprete.Endian
description: "Learn how the Endian element controls byte-order reversal for unsigned numbers and defaults to little-endian processing in a DataMiner connector protocol."
---

# Endian element

Specifies whether DataMiner must reverse the byte order (only relevant in case of unsigned numbers).

## Type

[EnumParamInterpretEndian](xref:Protocol-EnumParamInterpretEndian)

## Parent

[Interprete](xref:Protocol.Params.Param.Interprete)

## Remarks

By default, Little Endian is used.

## Examples

```xml
<Endian>big</Endian>
```
