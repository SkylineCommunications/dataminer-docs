---
uid: Protocol.Groups
---

# Groups element

Contains the groups defined in the protocol.

## Parent

[Protocol](xref:Protocol)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Group](xref:Protocol.Groups.Group)|[0, *]|Defines a group.|

## Constraints

|Type|Description|Selector|Fields|
|--- |--- |--- |--- |
|Unique |The ID of a group must be unique. |Group |@id |
|Unique |The name of a group must be unique. |Group |Name |
