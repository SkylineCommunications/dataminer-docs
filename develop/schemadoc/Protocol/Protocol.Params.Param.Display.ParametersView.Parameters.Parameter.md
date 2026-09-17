---
metadata_version: 1
uid: Protocol.Params.Param.Display.ParametersView.Parameters.Parameter
description: "Reference the DataMiner connector protocol schema entry for Parameter element, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
lifecycle: active
applies_to:
  - DataMiner
version: unknown
owner: unknown
review_status: needs_update
review_date: 2026-09-17
compatibility:
  uid: stable
  url: stable
---

# Parameter element

If you use the Protocol.Params.Param.Display.ParametersView tag to display a parameter as a chart, then add a Parameter tag inside the Protocol.Params.Param.Display.ParametersView.Parameters tag for every parameter holding a value to be displayed.

## Parent

[Parameters](xref:Protocol.Params.Param.Display.ParametersView.Parameters)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[id](xref:Protocol.Params.Param.Display.ParametersView.Parameters.Parameter-id)|[TypeParamId](xref:Protocol-TypeParamId)|Yes|Specifies the ID of the parameter.|
|[options](xref:Protocol.Params.Param.Display.ParametersView.Parameters.Parameter-options)|string||*Not yet implemented.*|
|[tableIndex](xref:Protocol.Params.Param.Display.ParametersView.Parameters.Parameter-tableIndex)|string||Specifies the row index (in case the “id” attribute refers to a table parameter).|

## Remarks

For an example, see [ParametersView](xref:Protocol.Params.Param.Display.ParametersView)

> [!NOTE]
> Only specify parameters of type “double”.




