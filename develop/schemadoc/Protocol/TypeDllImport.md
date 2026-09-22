---
metadata_version: 1
uid: Protocol-TypeDllImport
description: "Reference the DataMiner connector protocol schema entry for TypeDllImport simple type, including its documented structure, attributes, values, and constra."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# TypeDllImport simple type

Represents a dllImport value.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***string restriction***|||
|&nbsp;&nbsp;Pattern|`([^\/:*?"><|;]+\.dll)(;[^\/:*?"><|;]+\.dll)*`||
