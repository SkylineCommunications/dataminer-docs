---
metadata_version: 1
uid: Protocol.Params.Param.Matrix.Outputs
description: "Learn how the Outputs element connects an outputs table and its column mappings to a matrix control in a DataMiner connector protocol."
---

# Outputs element

Contains the linking between the outputs table and the matrix control.

## Parent

[Matrix](xref:Protocol.Params.Param.Matrix)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[tablePid](xref:Protocol.Params.Param.Matrix.Outputs-tablePid)|[TypeParamId](xref:Protocol-TypeParamId)|Yes|Specifies the ID of the outputs table.|

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Mappings](xref:Protocol.Params.Param.Matrix.Outputs.Mappings)||Specifies the linking between the columns of the outputs table and the matrix control.|
