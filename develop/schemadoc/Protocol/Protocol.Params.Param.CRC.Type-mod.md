---
uid: Protocol.Params.Param.CRC.Type-mod
description: "Use the mod attribute in a DataMiner protocol to apply a modulo operation after DataMiner calculates the CRC."
---

# mod attribute

Specifies that a modulo operation has to be performed on the CRC after it has been calculated.

## Content Type

unsignedInt

## Parent

[Type](xref:Protocol.Params.Param.CRC.Type)

## Examples

```xml
<Param>
   <CRC>
      <Type mod="95">
        ...
```
