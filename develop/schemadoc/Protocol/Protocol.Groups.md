---
metadata_version: 1
uid: Protocol.Groups
description: "Reference the DataMiner connector protocol schema entry for Groups element, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
lifecycle: active
applies_to:
  - DataMiner
version: unknown
owner: unknown
review_status: needs_update
review_date: 2026-09-17
compatibility:
  uid: stable
  url: stable
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
