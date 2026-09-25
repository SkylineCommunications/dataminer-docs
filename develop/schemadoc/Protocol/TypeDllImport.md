---
metadata_version: 1
uid: Protocol-TypeDllImport
description: "Use the TypeDllImport simple type to validate one or more semicolon-separated DLL file names in the DataMiner connector protocol schema."
---

# TypeDllImport simple type

Represents a dllImport value.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***string restriction***|||
|&nbsp;&nbsp;Pattern|`([^\/:*?"><|;]+\.dll)(;[^\/:*?"><|;]+\.dll)*`||
