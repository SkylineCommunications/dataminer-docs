---
uid: Protocol.HTTP.Session
---

# Session element

Represents a particular HTTP session.

## Parent

[HTTP](xref:Protocol.HTTP)

## Attributes

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Type|Required|Description|
|--- |--- |--- |--- |
|[id](xref:Protocol.HTTP.Session-id)|[TypeNonLeadingZeroUnsignedInt](xref:Protocol-TypeNonLeadingZeroUnsignedInt)|Yes|The unique session ID.|
|[ignoreTimeout](xref:Protocol.HTTP.Session-ignoreTimeout)|[EnumTrueFalse](xref:Protocol-EnumTrueFalse)||If the HTTP connection should ignore timeout for this session, set this attribute to true.|
|[keepAlive](xref:Protocol.HTTP.Session-keepAlive)|[EnumTrueFalse](xref:Protocol-EnumTrueFalse)||Specifies whether the session should be kept alive.|
|[loginMethod](xref:Protocol.HTTP.Session-loginMethod)|[EnumHttpLoginMethod](xref:Protocol-EnumHttpLoginMethod)||Specifies the authentication method to use.|
|[name](xref:Protocol.HTTP.Session-name)|[TypeNonEmptyString](xref:Protocol-TypeNonEmptyString)||Specifies the name of the session.|
|[password](xref:Protocol.HTTP.Session-password)|string||If you set loginMethod to "credentials", then use this attribute to specify the password.|
|[proxyPassword](xref:Protocol.HTTP.Session-proxyPassword)|string||If, in the proxyServer attribute, you specified a proxy server that requires authentication, then use this attribute to specify the password.|
|[proxyServer](xref:Protocol.HTTP.Session-proxyServer)|string||Use this attribute to specify the proxy server through which the connection has to be set up.|
|[proxyUser](xref:Protocol.HTTP.Session-proxyUser)|string||If, in the proxyServer attribute, you specified a proxy server that requires authentication, then use this attribute to specify the user name.|
|[timeout](xref:Protocol.HTTP.Session-timeout)|unsignedInt||Specifies that DataMiner must use this timeout value instead of the default one (or the one specified in the Session tag) when executing this connection of this session.|
|[userName](xref:Protocol.HTTP.Session-userName)|string||If you set loginMethod to “credentials”, then use this attribute to specify the user name.|

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Connection](xref:Protocol.HTTP.Session.Connection)|[0, *]|Specifies a connection. This typically contains a request and a response.|

## Constraints

|Type|Description|Selector|Fields|
|--- |--- |--- |--- |
|Unique |The ID of a connection must be unique. |Connection |@id |
