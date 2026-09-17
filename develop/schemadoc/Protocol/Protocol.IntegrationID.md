---
metadata_version: 1
uid: Protocol.IntegrationID
description: "Reference the DataMiner connector protocol schema entry for IntegrationID element, including its documented structure, attributes, values, and constraints."
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

# IntegrationID element

Specifies the integration ID.

## Type

|Item|Facet value|Description|
|--- |--- |--- |
|***string restriction***|||
|&nbsp;&nbsp;Pattern|`^DMS-DRV-[0-9]+$`||

## Parent

[Protocol](xref:Protocol)