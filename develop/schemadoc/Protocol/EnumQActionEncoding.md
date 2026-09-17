---
metadata_version: 1
uid: Protocol-EnumQActionEncoding
description: "Reference the DataMiner connector protocol schema entry for EnumQActionEncoding simple type, including its documented structure, attributes, values, and c."
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

# EnumQActionEncoding simple type

Specifies the language used in the QAction.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***string restriction***|||
|&nbsp;&nbsp;Enumeration|jscript|JScript|
|&nbsp;&nbsp;Enumeration|vbscript|VBScript|
|&nbsp;&nbsp;Enumeration|csharp|C#|

> [!NOTE]
> JScript and VBScript are [no longer supported](xref:Software_support_life_cycles#dataminer-functionality-evolution-and-retirement).
