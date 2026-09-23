---
metadata_version: 1
uid: Protocol-TypeTrueOrSemicolonSeparatedNumbers
description: "Reference the DataMiner connector protocol schema entry for TypeTrueOrSemicolonSeparatedNumbers simple type, including its documented structure, attribute."
content_type: schema
applies_to:
  - DataMiner
---

# TypeTrueOrSemicolonSeparatedNumbers simple type

Represents the value "true" or a semicolon-separated list of numbers.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***string restriction***|||
|&nbsp;&nbsp;Pattern|`true|\d+(;\d+)*;?`||
