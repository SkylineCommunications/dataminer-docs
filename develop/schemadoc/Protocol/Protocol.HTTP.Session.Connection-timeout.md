---
uid: Protocol.HTTP.Session.Connection-timeout
---

# timeout attribute

Specifies that DataMiner must use this timeout value instead of the default one (or the one specified in the [timeout](xref:Protocol.HTTP.Session-timeout) attribute of the [Session](xref:Protocol.HTTP.Session) tag) when executing this connection of this session.

## Content Type

unsignedInt

## Parent

[Connection](xref:Protocol.HTTP.Session.Connection)

## Remarks

The timeout value must be expressed in ms.

*Feature introduced in DataMiner 9.0.2 (RN 12542).*

## Examples

```xml
<Connection id="1" timeout="100">
	<Request verb="GET" url="/200">
	</Request>
	<Response statusCode="100">
		<Content pid="200"></Content>
	</Response>
</Connection>
```
