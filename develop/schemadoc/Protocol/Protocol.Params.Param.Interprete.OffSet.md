---
metadata_version: 1
uid: Protocol.Params.Param.Interprete.OffSet
description: "Reference the DataMiner connector protocol schema entry for OffSet element, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
lifecycle: active
applies_to:
  - DataMiner
version: unknown
owner: unknown
review_status: needs_update
review_date: 2026-09-17
compatibility:
  uid: stable
  url: stable
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
