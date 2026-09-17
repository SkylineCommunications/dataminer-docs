---
metadata_version: 1
uid: Protocol.Params.Param.Display.ParametersView
description: "Reference the DataMiner connector protocol schema entry for ParametersView element, including its documented structure, attributes, values, and constraint."
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

# ParametersView element

Allows displaying a parameter as a chart.

## Parent

[Display](xref:Protocol.Params.Param.Display)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[options](xref:Protocol.Params.Param.Display.ParametersView-options)|string||A pipe-separated list of options.|
|[type](xref:Protocol.Params.Param.Display.ParametersView-type)|[EnumParametersViewType](xref:Protocol-EnumParametersViewType)|Yes|Specifies the chart type.|

## Children

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Parameters](xref:Protocol.Params.Param.Display.ParametersView.Parameters)|[0, 1]|If you use */Protocol/Params/Param/Display/ParametersView* to display a parameter as a chart, then here you have to define the parameters holding the actual values to be displayed.|

## Remarks

The parameters holding the actual values to be displayed have to be specified in Protocol.Params.Param.Display.ParametersView.Parameters.

> [!NOTE]
> If you use this tag, make sure to set Protocol.Params.Param.Measurement.Type to “Chart”.
