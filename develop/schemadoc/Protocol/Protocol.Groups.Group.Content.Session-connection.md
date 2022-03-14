---
uid: Protocol.Groups.Group.Content.Session-connection
---

# connection attribute

If you want to execute only a specific connection within a certain session, then use the connection attribute to specify the connection.

## Content Type

unsignedInt

## Parent

[Session](xref:Protocol.Groups.Group.Content.Session)

## Remarks

*Feature introduced in DataMiner 8.5.7 (RN 9928).*

## Examples

```xml
<Group id="8">
	<Content>
    	<Session connection="1">8</Session>
	</Content>
</Group>
```
