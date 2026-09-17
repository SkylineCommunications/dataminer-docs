---
metadata_version: 1
uid: Protocol-TypeQActionOptions
description: "Reference the DataMiner connector protocol schema entry for TypeQActionOptions simple type, including its documented structure, attributes, values, and co."
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

# TypeQActionOptions simple type

Specifies the QAction options string.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***Union***|||
|&nbsp;&nbsp;[EnumQActionOption](xref:Protocol-EnumQActionOption)|||
|&nbsp;&nbsp;***string restriction***|||
|&nbsp;&nbsp;&nbsp;&nbsp;Pattern|`^(binary(?:;)?|debug(?:;)?|group(?:;)?|(precompile(?:;)?|queued(?:;)?|(dllName=[^;]+(?:;)?)))+\z`||
