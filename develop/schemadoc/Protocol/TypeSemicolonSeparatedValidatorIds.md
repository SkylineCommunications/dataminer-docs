---
metadata_version: 1
uid: Protocol-TypeSemicolonSeparatedValidatorIds
description: "Reference the DataMiner connector protocol schema entry for TypeSemicolonSeparatedValidatorIds simple type, including its documented structure, attributes."
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

# TypeSemicolonSeparatedValidatorIds simple type

Represents a semicolon-separated list of validator IDs.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***string restriction***|||
|&nbsp;&nbsp;Pattern|`^(\d+\.\d+\.\d+)(;(\d+\.\d+\.\d+))*$`||
