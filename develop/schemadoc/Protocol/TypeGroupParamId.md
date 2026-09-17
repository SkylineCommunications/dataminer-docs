---
metadata_version: 1
uid: Protocol-TypeGroupParamId
description: "Reference the DataMiner connector protocol schema entry for TypeGroupParamId simple type, including its documented structure, attributes, values, and cons."
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

# TypeGroupParamId simple type

Represents a group parameter ID.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***string restriction***|||
|&nbsp;&nbsp;Pattern|`(\b([0-9]{1,4}|[1-5][0-9]{4}|6[0-3][0-9]{3}|64[0-4][0-9]{2}|64500|[7-9][0-9]{4}|[1-9][0-9]{6})\b)+(\:(single|table|instance|getnext|tablev2))?$`||
