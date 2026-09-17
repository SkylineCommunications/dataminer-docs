---
metadata_version: 1
uid: Protocol.Responses
description: "Reference the DataMiner connector protocol schema entry for Responses element, including its documented structure, attributes, values, and constraints."
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

# Responses element

Contains all responses defined in the protocol.

## Parent

[Protocol](xref:Protocol)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Response](xref:Protocol.Responses.Response)|[0, *]|Specifies a response that DataMiner can expect after having sent a specific command to the device.|

## Constraints

|Type|Description|Selector|Fields|
|--- |--- |--- |--- |
|Unique |The ID of a response must be unique. |Response |@id |
|Unique |The name of a response must be unique. |Response |dis:Name |
