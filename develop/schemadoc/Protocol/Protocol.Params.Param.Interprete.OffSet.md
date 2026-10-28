---
uid: Protocol.Params.Param.Interprete.OffSet
description: "Use the OffSet element in a DataMiner protocol to provide the value added by an OffSet operation in an Interprete sequence."
---

# OffSet element

In case the `Sequence` element contains `OffSet`" as an operation, the offset to be added can be specified using the `OffSet` element.

## Type

unsignedInt

## Parent

[Interprete](xref:Protocol.Params.Param.Interprete)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[id](xref:Protocol.Params.Param.Interprete.OffSet-id)|[TypeParamId](xref:Protocol-TypeParamId)||Specifies the ID of the parameter that holds the offset value.|

## Examples

```xml
<Interprete>
   <RawType>signed number</RawType>
   <LengthType>fixed</LengthType>
   <Length>1</Length>
   <Type>double</Type>
   <OffSet>128</OffSet>
   <Sequence noset="true">OffSet</Sequence>
</Interprete>
```
