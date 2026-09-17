---
metadata_version: 1
uid: Protocol.Params.Param.Matrix
description: "Reference the DataMiner connector protocol schema entry for Matrix element, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
lifecycle: active
applies_to:
  - DataMiner
version: 10.3.1
owner: unknown
review_status: needs_update
review_date: 2026-09-17
compatibility:
  uid: stable
  url: stable
---

# Matrix element

If /Protocol/Params/Param/Type is set to "matrix", this will allow you to define the matrix control. Feature introduced in DataMiner 10.3.1/10.4.0 (RN 34661).

## Parent

[Param](xref:Protocol.Params.Param)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[Inputs](xref:Protocol.Params.Param.Matrix.Inputs)||Contains the linking between the inputs table and the matrix control.|
|&nbsp;&nbsp;[Outputs](xref:Protocol.Params.Param.Matrix.Outputs)||Contains the linking between the outputs table and the matrix control.|
|&nbsp;&nbsp;[MatrixOptions](xref:Protocol.Params.Param.Matrix.MatrixOptions)||Contains additional options related to how the matrix should behave and look.|
