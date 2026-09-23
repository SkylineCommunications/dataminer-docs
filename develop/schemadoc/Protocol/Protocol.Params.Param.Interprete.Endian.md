---
metadata_version: 1
uid: Protocol.Params.Param.Interprete.Endian
description: "Reference the DataMiner connector protocol schema entry for Endian element, including its documented structure, attributes, values, and constraints."
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
