---
uid: Protocol.Groups.Group
---

# Group element

Defines a group.

## Parent

[Groups](xref:Protocol.Groups)

## Attributes

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Type|Required|Description|
|--- |--- |--- |--- |
|[connection](xref:Protocol.Groups.Group-connection)|unsignedInt||Specifies the connection to be used (used in case multiple connections are defined).|
|[connectionPID](xref:Protocol.Groups.Group-connectionPID)|unsignedInt||Allows to dynamically select an HTTP connection by referring to the connection by means of a parameter ID.|
|[id](xref:Protocol.Groups.Group-id)|[TypeObjectId](xref:Protocol-TypeObjectId)|Yes|The unique group ID.|
|[ping](xref:Protocol.Groups.Group-ping)|[EnumTrueFalse](xref:Protocol-EnumTrueFalse)||Specifies whether this is the group to be used when testing the connection in the element wizard.|

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[Condition](xref:Protocol.Groups.Group.Condition)|[0, 1]|Specifies a condition that must be met in order for the group to execute.|
|&nbsp;&nbsp;[Content](xref:Protocol.Groups.Group.Content)|[0, 1]|Contains the items that have to be executed consecutively when the group is executed.|
|&nbsp;&nbsp;[Description](xref:Protocol.Groups.Group.Description)|[0, 1]|Specifies the group description.|
|&nbsp;&nbsp;[Name](xref:Protocol.Groups.Group.Name)|[0, 1]|Specifies the name of the group.|
|&nbsp;&nbsp;[Type](xref:Protocol.Groups.Group.Type)|[0, 1]|Specifies the group type.|

## Remarks

Groups are used e.g. to perform actual device polling.

In a group, you can assemble different parameters, command/response pairs or actions. When a group is executed, all parameters, pairs or actions included in the group will be executed one after the other.


