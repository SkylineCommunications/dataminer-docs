---
metadata_version: 1
uid: Protocol.Params.Param.Database.Connection.Type
description: "Reference the DataMiner connector protocol schema entry for Type element, including its documented structure, attributes, values, and constraints."
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

# Type element

Specifies the connection type.

## Type

|Item|Facet value|Description|
|--- |--- |--- |
|***string restriction***|||
|&nbsp;&nbsp;Enumeration|DirectConnection|A direct connection is used to push data.|
|&nbsp;&nbsp;Enumeration|SLProtocol|Interaction with the logger table is done via SLProtocol.|

## Parent

[Connection](xref:Protocol.Params.Param.Database.Connection)

## Remarks

Refer to [Defining a logger table of type DirectConnection with a primary key](xref:AdvancedLoggerTablesDefiningDirectConnectionTable) for more information.
