---
uid: Protocol.Params.Param.Matrix.Outputs.Mappings
description: "Use the Mappings element in a DataMiner protocol to link output table columns to their corresponding matrix control columns."
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

|Type|Description|Selector|Fields|
|--- |--- |--- |--- |
|Unique |No duplicate values must occur for the name attribute. |Mapping |@name |
