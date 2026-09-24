---
metadata_version: 1
uid: Protocol.Triggers
description: "Consult the DataMiner connector protocol schema reference for the Triggers element, which contains the uniquely identified triggers defined in a protocol."
---

# Triggers element

Contains the triggers defined in the protocol.

## Parent

[Protocol](xref:Protocol)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Trigger](xref:Protocol.Triggers.Trigger)|[0, *]|Defines a trigger.|

## Constraints

|Type|Description|Selector|Fields|
|--- |--- |--- |--- |
|Unique |The ID of a trigger must be unique. |Trigger |@id |
|Unique |The name of a trigger must be unique. |Trigger |dis:Name |
