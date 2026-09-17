---
metadata_version: 1
uid: Protocol-TypePingInterval
description: "Reference the DataMiner connector protocol schema entry for TypePingInterval simple type, including its documented structure, attributes, values, and cons."
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

# TypePingInterval simple type

Specifies the valid range for the ping interval setting (in ms).

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***unsignedInt restriction***|||
|&nbsp;&nbsp;Min inclusive|1000||
|&nbsp;&nbsp;Max inclusive|300000||
|&nbsp;&nbsp;Pattern|`^\d+000$`||
