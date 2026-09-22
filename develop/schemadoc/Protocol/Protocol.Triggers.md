---
metadata_version: 1
uid: Protocol.Triggers
description: "Reference the DataMiner connector protocol schema entry for Triggers element, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
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
