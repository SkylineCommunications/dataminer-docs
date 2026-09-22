---
metadata_version: 1
uid: Protocol-TypeTrueOrSemicolonSeparatedNumbers
description: "Reference the DataMiner connector protocol schema entry for TypeTrueOrSemicolonSeparatedNumbers simple type, including its documented structure, attribute."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# TypeTrueOrSemicolonSeparatedNumbers simple type

Represents the value "true" or a semicolon-separated list of numbers.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***string restriction***|||
|&nbsp;&nbsp;Pattern|`true|\d+(;\d+)*;?`||
