---
metadata_version: 1
uid: Protocol.HTTP.Session.Connection.Response.Content
description: "Reference the DataMiner connector protocol schema entry for Content element, including its documented structure, attributes, values, and constraints."
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

# Content element

The pid attribute of this element specifies the ID of the parameter in which you want the contents of the response to be stored.

## Parent

[Response](xref:Protocol.HTTP.Session.Connection.Response)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[pid](xref:Protocol.HTTP.Session.Connection.Response.Content-pid)|unsignedInt|Yes|Specifies the ID of the parameter in which you want the contents of the response to be stored.|
