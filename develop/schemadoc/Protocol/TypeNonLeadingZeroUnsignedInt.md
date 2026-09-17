---
metadata_version: 1
uid: Protocol-TypeNonLeadingZeroUnsignedInt
description: "Reference the DataMiner connector protocol schema entry for TypeNonLeadingZeroUnsignedInt simple type, including its documented structure, attributes, val."
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

# TypeNonLeadingZeroUnsignedInt simple type

Specifies an unsigned integer value that has no leading zeros.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***unsignedInt restriction***|||
|&nbsp;&nbsp;Pattern|`[123456789]\d*|0`||
