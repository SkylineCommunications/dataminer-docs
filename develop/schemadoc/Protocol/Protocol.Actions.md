---
metadata_version: 1
uid: Protocol.Actions
description: "Reference the DataMiner connector protocol schema entry for Actions element, including its documented structure, attributes, values, and constraints."
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
