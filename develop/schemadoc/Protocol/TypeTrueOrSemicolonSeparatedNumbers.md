---
metadata_version: 1
uid: Protocol-TypeTrueOrSemicolonSeparatedNumbers
description: "Use the TypeTrueOrSemicolonSeparatedNumbers simple type to accept true or a semicolon-separated number list in the DataMiner connector protocol schema."
---

# TypeTrueOrSemicolonSeparatedNumbers simple type

Represents the value "true" or a semicolon-separated list of numbers.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***string restriction***|||
|&nbsp;&nbsp;Pattern|`true|\d+(;\d+)*;?`||
