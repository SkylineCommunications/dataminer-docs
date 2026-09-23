---
metadata_version: 1
uid: Protocol.Params.Param.Interprete.Alignment
description: "Reference the DataMiner connector protocol schema entry for Alignment element, including its documented structure, attributes, values, and constraints."
---

# Alignment element

Used to retrieve BCD numbers from an incoming stream.

## Type

[EnumParamInterpretAlignment](xref:Protocol-EnumParamInterpretAlignment)

## Parent

[Interprete](xref:Protocol.Params.Param.Interprete)

## Remarks

When a Protocol.Params.Param.Interprete.Bits tag is defined in a group, only a couple of bits will be used from each byte. When a read bit parameter, with its rawtype set to “bcd”, is assigned to that group and exists of multiple bytes, the Alignment tag can be needed to specify the exact starting position of the first BCD.

## Examples

```xml
<Alignment>left</Alignment>
```
