---
metadata_version: 1
uid: Protocol-TimerTime
description: "Reference the DataMiner connector protocol schema entry for TimerTime simple type, including its documented structure, attributes, values, and constraints."
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

# TimerTime simple type

Specifies the timer time.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***Union***|||
|&nbsp;&nbsp;***string restriction***|||
|&nbsp;&nbsp;&nbsp;&nbsp;Enumeration|loop|Executes in a loop.|
|&nbsp;&nbsp;***unsignedInt restriction***|||
|&nbsp;&nbsp;&nbsp;&nbsp;Pattern|`[123456789]\d*`||
|&nbsp;&nbsp;&nbsp;&nbsp;Min inclusive|1||
|&nbsp;&nbsp;&nbsp;&nbsp;Max inclusive|2073600000||
