---
metadata_version: 1
uid: Protocol.Params.Param.Interprete.Others.Other.Display
description: "Reference the DataMiner connector protocol schema entry for Display element, including its documented structure, attributes, values, and constraints."
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

# Display element

When the value of the parameter referenced with the Protocol.Params.Param.Interprete.Others.Other@id attribute matches the incoming symbol, the contents of the Protocol.Params.Param.Interprete.Others.Other.Display tag will be shown.

## Type

string

## Parent

[Other](xref:Protocol.Params.Param.Interprete.Others.Other)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[state](xref:Protocol.Params.Param.Interprete.Others.Other.Display-state)|[EnumDisplayState](xref:Protocol-EnumDisplayState)||If set to “disabled”, the parameter will be displayed in gray.|
