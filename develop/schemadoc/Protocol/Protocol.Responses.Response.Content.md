---
metadata_version: 1
uid: Protocol.Responses.Response.Content
description: "Reference the DataMiner connector protocol schema entry for Content element, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# Content element

Specifies the consecutive parameters that together form the response that is expected from the data source.

## Parent

[Response](xref:Protocol.Responses.Response)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[optional](xref:Protocol.Responses.Response.Content-optional)|string||Specifies that no error will occur if they are not found in the response received from the device.|

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Param](xref:Protocol.Responses.Response.Content.Param)|[0, *]|Specifies the ID of the parameter that you want to include in the response.|
