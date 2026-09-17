---
metadata_version: 1
uid: Protocol.RCA.Protocol.Link
description: "Reference the DataMiner connector protocol schema entry for Link element, including its documented structure, attributes, values, and constraints."
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

# Link element

Defines an RCA chain by defining relations.

## Parent

[Protocol](xref:Protocol.RCA.Protocol)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[path](xref:Protocol.RCA.Protocol.Link-path)|string||Specifies a semicolon-separated list of parameter IDs that defines the flow of the RCA chain.|
|[valueFilter](xref:Protocol.RCA.Protocol.Link-valueFilter)|string||Specifies a filter.|
