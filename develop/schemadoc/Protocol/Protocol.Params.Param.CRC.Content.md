---
metadata_version: 1
uid: Protocol.Params.Param.CRC.Content
description: "Reference the DataMiner connector protocol schema entry for Content element, including its documented structure, attributes, values, and constraints."
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

# Content element

Specifies the parameters of the command/response to be included in the CRC calculation.

## Parent

[CRC](xref:Protocol.Params.Param.CRC)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Param](xref:Protocol.Params.Param.CRC.Content.Param)|[0, *]|Specifies a parameter of the command/response to be included in the CRC calculation.|

## Remarks

The operation defined in Protocol.Params.Param.CRC.Type will only be performed on the parameters defined in Protocol.Params.Param.CRC.Content.

The first parameter of the command/response has ID 0.
