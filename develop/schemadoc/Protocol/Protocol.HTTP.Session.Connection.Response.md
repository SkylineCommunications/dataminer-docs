---
metadata_version: 1
uid: Protocol.HTTP.Session.Connection.Response
description: "Reference the DataMiner connector protocol schema entry for Response element, including its documented structure, attributes, values, and constraints."
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

# Response element

Defines the response to the HTTP request you defined in ../Connection/Request.

## Parent

[Connection](xref:Protocol.HTTP.Session.Connection)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[statusCode](xref:Protocol.HTTP.Session.Connection.Response-statusCode)|unsignedInt||Specifies the ID of the parameter in which the HTTP status-line has to be stored.|

## Children

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[Headers](xref:Protocol.HTTP.Session.Connection.Response.Headers)|[0, 1]|Specifies the response headers of which you want to store the contents in a parameter.|
|&nbsp;&nbsp;[Content](xref:Protocol.HTTP.Session.Connection.Response.Content)||The pid attribute of this element specifies the ID of the parameter in which you want the contents of the response to be stored.|
