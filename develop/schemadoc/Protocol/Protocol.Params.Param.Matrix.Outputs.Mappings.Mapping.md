---
metadata_version: 1
uid: Protocol.Params.Param.Matrix.Outputs.Mappings.Mapping
description: "Reference the DataMiner connector protocol schema entry for Mapping element, including its documented structure, attributes, values, and constraints."
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

# Mapping element

Specifies the link between the column and the matrix column.

## Type

[TypeParamId](xref:Protocol-TypeParamId)

## Parent

[Mappings](xref:Protocol.Params.Param.Matrix.Outputs.Mappings)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[type](xref:Protocol.Params.Param.Matrix.Outputs.Mappings.Mapping-type)|[EnumMatrixMappingType](xref:Protocol-EnumMatrixMappingType)|Yes|Specifies the type of value of the mapping.|
|[name](xref:Protocol.Params.Param.Matrix.Outputs.Mappings.Mapping-name)|[EnumMatrixOutputsMappingNameType](xref:Protocol-EnumMatrixOutputsMappingNameType)|Yes|Specifies the mapping type.|
