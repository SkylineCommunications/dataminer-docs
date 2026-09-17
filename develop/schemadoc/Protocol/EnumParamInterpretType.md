---
metadata_version: 1
uid: Protocol-EnumParamInterpretType
description: "Reference the DataMiner connector protocol schema entry for EnumParamInterpretType simple type, including its documented structure, attributes, values, an."
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

# EnumParamInterpretType simple type

Specifies the interpretation type.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***string restriction***|||
|&nbsp;&nbsp;Enumeration|double|The parameter value will be processed as a number.|
|&nbsp;&nbsp;Enumeration|high nibble|The parameter value will be processed as the high nibble (i.e., first four bits) of a byte.|
|&nbsp;&nbsp;Enumeration|string|The parameter value will be processed as an ASCII string.|
