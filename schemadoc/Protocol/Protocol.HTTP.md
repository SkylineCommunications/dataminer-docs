---
uid: Protocol.HTTP
---

# HTTP element

Contains the configuration of the HTTP-specific features in a protocol.

## Parent

[Protocol](xref:Protocol)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Session](xref:Protocol.HTTP.Session)|[0, *]|Represents a particular HTTP session.|

## Constraints

|Type|Description|Selector|Fields|
|--- |--- |--- |--- |
|Unique |The ID of a session must be unique. |Session |@id |
|Unique |The name of a session must be unique. |Session |@name |

## Examples

```xml
<HTTP>
	<Session id="1" loginMethod="credentials" userName="Administrator" password="MyAdminPw" proxyServer="proxy.mycorp.be" proxyUser="MyProxyUser" proxypassword="MyProxyPw">
		<Connection id="1">
			<Request verb="GET" url="/foobar.html">
				<Parameters>
					<Parameter key="foo">bar</Parameter>
					<Parameter key="lorem" pid="23"></Parameter>
				</Parameters>
				<Headers>
					<Header key="Accept-Encoding">gzip, deflate</Header>
					<Header key="Accept">application/xml</Header>
				</Headers>
			</Request>
			<Response statusCode="25">
				<Headers>
					<Header key="Connection" pid="15"></Header>
				</Headers>
				<Content pid="19"></Content>
			</Response>
		</Connection>
	</Session>
</HTTP>
```
