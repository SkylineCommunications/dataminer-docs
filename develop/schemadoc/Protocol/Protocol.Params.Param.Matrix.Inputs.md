---
metadata_version: 1
uid: Protocol.Params.Param.Matrix.Inputs
description: "Reference the DataMiner connector protocol schema entry for Inputs element, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
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
