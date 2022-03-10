---
uid: Protocol.Responses.Response.Content
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
