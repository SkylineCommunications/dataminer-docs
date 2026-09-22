---
metadata_version: 1
uid: Protocol.Params.Param.Dashboard.DashboardOptions.DashboardOption
description: "Reference the DataMiner connector protocol schema entry for DashboardOption element, including its documented structure, attributes, values, and constrain."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# DashboardOption element

Specifies how the button panel is displayed.

## Type

unsignedInt

## Parent

[DashboardOptions](xref:Protocol.Params.Param.Dashboard.DashboardOptions)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[type](xref:Protocol.Params.Param.Dashboard.DashboardOptions.DashboardOption-type)||Yes|Specifies whether the value denotes a column index or a parameter ID.|
|[name](xref:Protocol.Params.Param.Dashboard.DashboardOptions.DashboardOption-name)||Yes|Specifies the name of the option.|

## Remarks

Contains a numeric value that either denotes a parameter ID or column index (depending on the value specified in the type attribute).
