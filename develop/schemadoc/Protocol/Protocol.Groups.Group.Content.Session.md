---
uid: Protocol.Groups.Group.Content.Session
---

# Session element

Specifies the ID of an HTTP session to be included in the group.

## Type

[TypeNonLeadingZeroUnsignedInt](xref:Protocol-TypeNonLeadingZeroUnsignedInt)

## Parent

[Content](xref:Protocol.Groups.Group.Content)

## Attributes

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Type|Required|Description|
|--- |--- |--- |--- |
|[connection](xref:Protocol.Groups.Group.Content.Session-connection)|unsignedInt||If you want to execute only a specific connection within a certain session, then use the connection attribute to specify the connection.|
|[next](xref:Protocol.Groups.Group.Content.Session-next)|unsignedInt||Specifies the number of milliseconds DataMiner has to wait after having received the response of the last executed session before executing the next session.|

## Examples

```xml
<Group id="8">
	<Content>
    	<Session>8</Session>
	</Content>
</Group>
```
