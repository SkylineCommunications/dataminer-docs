---
metadata_version: 1
uid: Protocol.Params.Param.CrossDriverOptions.CrossDriverOption.PIDTranslation
description: "Reference the DataMiner connector protocol schema entry for PIDTranslation element, including its documented structure, attributes, values, and constraint."
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

# PIDTranslation element

Maps a column parameter ID from the remote protocol to this protocol.

## Parent

[CrossDriverOption](xref:Protocol.Params.Param.CrossDriverOptions.CrossDriverOption)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[local](xref:Protocol.Params.Param.CrossDriverOptions.CrossDriverOption.PIDTranslation-local)|unsignedInt|Yes|Specifies the parameter ID of the column in this protocol.|
|[remote](xref:Protocol.Params.Param.CrossDriverOptions.CrossDriverOption.PIDTranslation-remote)|unsignedInt|Yes|Specifies the parameter ID of the column in the remote protocol.|
