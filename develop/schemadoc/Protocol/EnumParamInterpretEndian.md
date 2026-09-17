---
metadata_version: 1
uid: Protocol-EnumParamInterpretEndian
description: "Reference the DataMiner connector protocol schema entry for EnumParamInterpretEndian simple type, including its documented structure, attributes, values."
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

# EnumParamInterpretEndian simple type

Specifies the endianness.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***string restriction***|||
|&nbsp;&nbsp;Enumeration|big|The bytes will be reversed.|
|&nbsp;&nbsp;Enumeration|little|The bytes will not be reversed.|
