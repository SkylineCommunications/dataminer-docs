---
uid: Protocol.Params.Param.CRC.Type-byteoffset
description: "Use the byteoffset attribute in a DataMiner protocol to add an offset to every byte before DataMiner calculates the CRC."
---

# byteoffset attribute

Allows you to add an offset to every single byte of the CRC.

## Content Type

int

## Parent

[Type](xref:Protocol.Params.Param.CRC.Type)

## Remarks

Can be used in combination with all possible CRC types.

## Examples

```xml
<Param>
   <CRC>
      <Type byteoffset="2">
```
