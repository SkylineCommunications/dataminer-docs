---
metadata_version: 1
uid: Protocol-TypeTrueOrSemicolonSeparatedNumbers
description: "Reference the DataMiner connector protocol schema entry for TypeTrueOrSemicolonSeparatedNumbers simple type, including its documented structure, attribute."
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

# TypeTrueOrSemicolonSeparatedNumbers simple type

Represents the value "true" or a semicolon-separated list of numbers.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***string restriction***|||
|&nbsp;&nbsp;Pattern|`true|\d+(;\d+)*;?`||
