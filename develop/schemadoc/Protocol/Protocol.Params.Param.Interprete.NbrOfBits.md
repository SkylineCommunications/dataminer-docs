---
metadata_version: 1
uid: Protocol.Params.Param.Interprete.NbrOfBits
description: "Reference the DataMiner connector protocol schema entry for NbrOfBits element, including its documented structure, attributes, values, and constraints."
content_type: schema
applies_to:
  - DataMiner
---

# NbrOfBits element

Specifies the number of bits needed.

## Type

unsignedInt

## Parent

[Interprete](xref:Protocol.Params.Param.Interprete)

## Remarks

When this number exceeds the number of bits used in a byte, the Protocol.Params.Param.Interprete.Endian tag can be set to “big” to make DataMiner reverse the bits when processing them.

## Examples

```xml
<NbrOfBits>6</NbrOfBits>
```
