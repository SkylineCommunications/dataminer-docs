---
metadata_version: 1
uid: Protocol.Params.Param.Matrix.MatrixOptions.MatrixOption
description: "Learn how the MatrixOption element defines one matrix appearance or behavior setting and its value type in a DataMiner connector protocol."
---

# MatrixOption element

Specifies specific options for the look or behavior of the matrix.

## Type

string

## Parent

[MatrixOptions](xref:Protocol.Params.Param.Matrix.MatrixOptions)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[type](xref:Protocol.Params.Param.Matrix.MatrixOptions.MatrixOption-type)|[EnumMatrixMatrixOptionType](xref:Protocol-EnumMatrixMatrixOptionType)|Yes|Specifies the type of value of the matrix option.|
|[name](xref:Protocol.Params.Param.Matrix.MatrixOptions.MatrixOption-name)|[EnumMatrixMatrixOptionNameType](xref:Protocol-EnumMatrixMatrixOptionNameType)|Yes|Specifies the matrix option type.|

## Constraints

|Type|Description|Selector|Fields
|--- |--- |--- |--- |
|Unique |No duplicate values must occur for the name attribute. |MatrixOption |@name |
