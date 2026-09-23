---
metadata_version: 1
uid: Protocol.Params.Param.Matrix.Inputs.Mappings.Mapping
description: "Learn how the Mapping element links an input table column to a matrix column and defines its mapping role and value type in a DataMiner connector protocol."
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
