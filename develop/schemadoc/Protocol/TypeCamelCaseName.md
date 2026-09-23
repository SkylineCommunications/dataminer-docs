---
metadata_version: 1
uid: Protocol-TypeCamelCaseName
description: "Use the TypeCamelCaseName simple type to validate camel-cased names from 2 to 160 characters in the DataMiner connector protocol schema."
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
