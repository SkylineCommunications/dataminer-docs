---
metadata_version: 1
uid: Protocol.Actions
description: "Learn how the Actions element contains uniquely identified and named actions in a DataMiner connector protocol."
---

# Actions element

Contains the actions defined in this protocol.

## Parent

[Protocol](xref:Protocol)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Action](xref:Protocol.Actions.Action)|[0, *]|Defines an action.|

## Constraints

|Type|Description|Selector|Fields|
|--- |--- |--- |--- |
|Unique |The ID of an action must be unique. |Action |@id |
|Unique |The name of an action must be unique. |Action |dis:Name |
