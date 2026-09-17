---
metadata_version: 1
uid: Protocol.Params.Param.CRC.Type
description: "Reference the DataMiner connector protocol schema entry for Type element, including its documented structure, attributes, values, and constraints."
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

# Type element

Defines the CRC calculation algorithm.

## Type

[EnumParamCRCType](xref:Protocol-EnumParamCRCType)

## Parent

[CRC](xref:Protocol.Params.Param.CRC)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[byteoffset](xref:Protocol.Params.Param.CRC.Type-byteoffset)|int||Allows to add an offset to every single byte of the CRC.|
|[groupbytes](xref:Protocol.Params.Param.CRC.Type-groupbytes)|string||Specifies the number of bytes on which to perform the operation.|
|[mod](xref:Protocol.Params.Param.CRC.Type-mod)|unsignedInt||Specifies that a modulo operation has to be performed on the CRC after it has been calculated.|
|[off](xref:Protocol.Params.Param.CRC.Type-off)|int||Specifies an offset value to be added to the calculated CRC.|
|[options](xref:Protocol.Params.Param.CRC.Type-options)|string||Specifies additional options, separated by semicolons (”;”).|
|[totaloffset](xref:Protocol.Params.Param.CRC.Type-totaloffset)|unsignedInt||Specifies an offset value to be added to the CRC after it has been calculated.|

## Remarks

One of the following values can be specified:

- 2COMP
- CODAN
- CRC
- CRC-CCITT
- CRC-16
- EXOR
- FLETCHER
- LSB AFTER SUBTRACT
- LSB AFTER SUM
- MODBUS
- RCDS
- REST
- SUBTRACT
- SUM

### Internal calculation sequence

1. Byteoffset
1. CRC (with groupbytes and off attributes if specified)
1. Mod
1. Totaloffset (added or ‘OR’-ed, depending on the ‘OR TOTALOFFSET’ option)
1. Ones complement
