---
uid: Protocol.HTTP.Session.Connection
---

# Connection element

Specifies a connection. This typically contains a request and a response.

## Parent

[Session](xref:Protocol.HTTP.Session)

## Attributes

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Type|Required|Description|
|--- |--- |--- |--- |
|[id](xref:Protocol.HTTP.Session.Connection-id)|unsignedInt|Yes|The unique connection ID.|
|[ignoreTimeout](xref:Protocol.HTTP.Session.Connection-ignoreTimeout)|[EnumTrueFalse](xref:Protocol-EnumTrueFalse)||If the HTTP connection should ignore timeout, set this attribute to true.|
|[name](xref:Protocol.HTTP.Session.Connection-name)|string||Specifies the name of the connection.|
|[timeout](xref:Protocol.HTTP.Session.Connection-timeout)|unsignedInt||Specifies that DataMiner must use this timeout value instead of the default one (or the one specified in the Session tag) when executing this connection of this session.|

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[Request](xref:Protocol.HTTP.Session.Connection.Request)||Defines the HTTP request to be sent.|
|&nbsp;&nbsp;[Response](xref:Protocol.HTTP.Session.Connection.Response)||Defines the response to the HTTP request you defined in ../Connection/Request.|
