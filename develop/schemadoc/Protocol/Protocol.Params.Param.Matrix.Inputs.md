---
metadata_version: 1
uid: Protocol.Params.Param.Matrix.Inputs
description: "Learn how the Inputs element connects an inputs table and its column mappings to a matrix control in a DataMiner connector protocol."
---

# Inputs element

Contains the linking between the inputs table and the matrix control.

## Parent

[Matrix](xref:Protocol.Params.Param.Matrix)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[tablePid](xref:Protocol.Params.Param.Matrix.Inputs-tablePid)|[TypeParamId](xref:Protocol-TypeParamId)|Yes|Specifies the ID of the inputs table.|

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Mappings](xref:Protocol.Params.Param.Matrix.Inputs.Mappings)||Specifies the linking between the columns of the inputs table and the matrix control.|
