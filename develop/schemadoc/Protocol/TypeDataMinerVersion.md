---
metadata_version: 1
uid: Protocol-TypeDataMinerVersion
description: "Reference the DataMiner connector protocol schema entry for TypeDataMinerVersion simple type, including its documented structure, attributes, values, and."
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

# TypeDataMinerVersion simple type

Represents a DataMiner version.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***string restriction***|||
|&nbsp;&nbsp;Pattern|`([0-9]+\.){3}[0-9]+( - [0-9]{5})`||
