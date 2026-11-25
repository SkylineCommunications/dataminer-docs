---
uid: Protocol.HTTP.Session.Connection.Response
description: "Use the Response element in a DataMiner protocol to configure where to store an HTTP response status, headers, and body."
---

# Response element

Defines the response to the HTTP request you defined in  the `Connection.Request` element.

## Parent

[Connection](xref:Protocol.HTTP.Session.Connection)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[statusCode](xref:Protocol.HTTP.Session.Connection.Response-statusCode)|unsignedInt||Specifies the ID of the parameter where the HTTP status line has to be stored.|

## Children

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[Headers](xref:Protocol.HTTP.Session.Connection.Response.Headers)|[0, 1]|Specifies the response headers of which you want to store the contents in a parameter.|
|&nbsp;&nbsp;[Content](xref:Protocol.HTTP.Session.Connection.Response.Content)||The `pid` attribute of this element specifies the ID of the parameter where you want the contents of the response to be stored.|
