---
uid: Protocol.Params.Param.Interprete.OffSet
---

# OffSet element

In case the Sequence tag contains "OffSet " as an operation, to offset to be added can be specified using this tag.

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
