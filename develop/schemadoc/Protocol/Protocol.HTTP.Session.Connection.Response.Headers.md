---
metadata_version: 1
uid: Protocol.HTTP.Session.Connection.Response.Headers
description: "Reference the DataMiner connector protocol schema entry for Headers element, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# Headers element

Specifies the response headers of which you want to store the contents in a parameter.

## Parent

[Response](xref:Protocol.HTTP.Session.Connection.Response)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Header](xref:Protocol.HTTP.Session.Connection.Response.Headers.Header)|[1, *]|Specifies that the contents of a particular response header has to be stored in a parameter.|
