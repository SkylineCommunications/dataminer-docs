---
metadata_version: 1
uid: Protocol-TypeCamelCaseName
description: "Reference the DataMiner connector protocol schema entry for TypeCamelCaseName simple type, including its documented structure, attributes, values, and con."
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

# TypeCamelCaseName simple type

Represents a camel cased string.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***string restriction***|||
|&nbsp;&nbsp;Min length|2||
|&nbsp;&nbsp;Max length|160||
|&nbsp;&nbsp;Pattern|`([A-Z]([a-z]*))*`||
