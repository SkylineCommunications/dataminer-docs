---
metadata_version: 1
uid: Protocol.Params.Param.Matrix.Outputs.Mappings
description: "Reference the DataMiner connector protocol schema entry for Mappings element, including its documented structure, attributes, values, and constraints."
---

# Mappings element

Specifies the linking between the columns of the outputs table and the matrix control.

## Parent

[Outputs](xref:Protocol.Params.Param.Matrix.Outputs)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Mapping](xref:Protocol.Params.Param.Matrix.Outputs.Mappings.Mapping)|[5, *]|Specifies the link between the column and the matrix column.|

## Constraints

|Type|Description|Selector|Fields
|--- |--- |--- |--- |
|Unique |No duplicate values must occur for the name attribute. |Mapping |@name |
