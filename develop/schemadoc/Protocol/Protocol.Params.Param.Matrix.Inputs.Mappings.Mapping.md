---
metadata_version: 1
uid: Protocol.Params.Param.Matrix.Inputs.Mappings.Mapping
description: "Reference the DataMiner connector protocol schema entry for Mapping element, including its documented structure, attributes, values, and constraints."
content_type: schema
applies_to:
  - DataMiner
---

# Mapping element

Specifies the link between the column and the matrix column.

## Type

[TypeParamId](xref:Protocol-TypeParamId)

## Parent

[Mappings](xref:Protocol.Params.Param.Matrix.Inputs.Mappings)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[type](xref:Protocol.Params.Param.Matrix.Inputs.Mappings.Mapping-type)|[EnumMatrixMappingType](xref:Protocol-EnumMatrixMappingType)|Yes|Specifies the type of value of the mapping.|
|[name](xref:Protocol.Params.Param.Matrix.Inputs.Mappings.Mapping-name)|[EnumMatrixInputsMappingNameType](xref:Protocol-EnumMatrixInputsMappingNameType)|Yes|Specifies the mapping type.|

## Constraints

|Type|Description|Selector|Fields
|--- |--- |--- |--- |
|Unique |No duplicate values must occur for the name attribute. |Mapping |@name |
