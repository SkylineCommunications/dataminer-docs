---
metadata_version: 1
uid: Protocol.Params.Param.Measurement.Discreets.Discreet.Display
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

Specifies the string to be displayed when the value of the parameter matches the contents of the Protocol.Params.Param.Measurement.Discreets.Discreet.Value tag.

## Type

[TypeNonEmptyString](xref:Protocol-TypeNonEmptyString)

## Parent

[Discreet](xref:Protocol.Params.Param.Measurement.Discreets.Discreet)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[state](xref:Protocol.Params.Param.Measurement.Discreets.Discreet.Display-state)|[EnumDisplayState](xref:Protocol-EnumDisplayState)||When Protocol.Params.Param.Interprete.Exceptions.Exception is used the same state needs to be placed in the write parameter.|
