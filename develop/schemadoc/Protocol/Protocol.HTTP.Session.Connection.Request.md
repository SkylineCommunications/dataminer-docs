---
uid: Protocol.HTTP.Session.Connection.Request
---

# Request element

Defines the HTTP request to be sent.

## Parent

[Connection](xref:Protocol.HTTP.Session.Connection)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[pid](xref:Protocol.HTTP.Session.Connection.Request-pid)|unsignedInt||Replaces the url attribute. The parameter value will be used as URL.|
|[verb](xref:Protocol.HTTP.Session.Connection.Request-verb)|[EnumHttpRequestVerb](xref:Protocol-EnumHttpRequestVerb)||Specifies the verb to be used in the HTTP request.|
|[url](xref:Protocol.HTTP.Session.Connection.Request-url)|string||Specifies the URL of the request.|

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***Choice***|[0, 1]||
|&nbsp;&nbsp;***Sequence***|||
|&nbsp;&nbsp;&nbsp;&nbsp;[Headers](xref:Protocol.HTTP.Session.Connection.Request.Headers)|||
|&nbsp;&nbsp;&nbsp;&nbsp;***Choice***|||
|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Data](xref:Protocol.HTTP.Session.Connection.Request.Data)|[0, 1]||
|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Parameters](xref:Protocol.HTTP.Session.Connection.Request.Parameters)|[0, 1]||
|&nbsp;&nbsp;***Sequence***|||
|&nbsp;&nbsp;&nbsp;&nbsp;[Data](xref:Protocol.HTTP.Session.Connection.Request.Data)|||
|&nbsp;&nbsp;&nbsp;&nbsp;[Headers](xref:Protocol.HTTP.Session.Connection.Request.Headers)|[0, 1]||
|&nbsp;&nbsp;***Sequence***|||
|&nbsp;&nbsp;&nbsp;&nbsp;[Parameters](xref:Protocol.HTTP.Session.Connection.Request.Parameters)|||
|&nbsp;&nbsp;&nbsp;&nbsp;[Headers](xref:Protocol.HTTP.Session.Connection.Request.Headers)|[0, 1]||
