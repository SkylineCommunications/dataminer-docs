---
metadata_version: 1
uid: Protocol.Params.Param.CRC.Type-totaloffset
description: "Learn how to use the totaloffset attribute to add an offset after the modulo stage of a CRC calculation in a DataMiner connector protocol."
---

# totaloffset attribute

Specifies an offset value to be added to the CRC after it has been calculated.

## Content Type

unsignedInt

## Parent

[Type](xref:Protocol.Params.Param.CRC.Type)

## Remarks

> [!NOTE]
> The totaloffset attribute is executed after the mod attribute. See also [Internal calculation sequence](xref:Protocol.Params.Param.CRC.Type#internal-calculation-sequence).

## Examples

```xml
<Param>
  <CRC>
     <Type totaloffset="32">
     ...
```
