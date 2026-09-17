---
metadata_version: 1
uid: Protocol.Params.Param.Display.Trending
description: "Reference the DataMiner connector protocol schema entry for Trending element, including its documented structure, attributes, values, and constraints."
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

# Trending element

Specifies the formula to be used for the average trending data of this parameter. By default, the average over a 5 minute timespan is stored.

## Parent

[Display](xref:Protocol.Params.Param.Display)

## Attributes

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Type|Required|Description|
|--- |--- |--- |--- |
|[logarithmic](xref:Protocol.Params.Param.Display.Trending-logarithmic)|[EnumTrueFalse](xref:Protocol-EnumTrueFalse)||Set this attribute to "true" if you want to set the trend graph of the parameter to a logarithmic scale.|

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Type](xref:Protocol.Params.Param.Display.Trending.Type)|[0, 1]|Specifies the formula used to determine the average trending data.|

## Remarks

Can be added for both analog and discreet parameters.
