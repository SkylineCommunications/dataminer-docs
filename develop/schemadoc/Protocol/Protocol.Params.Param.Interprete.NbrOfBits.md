---
metadata_version: 1
uid: Protocol.Params.Param.Interprete.NbrOfBits
description: "Learn how the NbrOfBits element sets the bit count used to process a parameter and supports big-endian reversal in a DataMiner connector protocol."
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
