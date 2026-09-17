---
metadata_version: 1
uid: Protocol-TypeParamId
description: "Reference the DataMiner connector protocol schema entry for TypeParamId simple type, including its documented structure, attributes, values, and constrain."
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

# TypeParamId simple type

Defines the range of possible parameter IDs. Note: Additional restrictions apply depending on the type of protocol.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***Union***|||
|&nbsp;&nbsp;***unsignedInt restriction***|||
|&nbsp;&nbsp;&nbsp;&nbsp;Pattern|`[123456789]\d*|0`||
|&nbsp;&nbsp;&nbsp;&nbsp;Min inclusive|0||
|&nbsp;&nbsp;&nbsp;&nbsp;Max inclusive|64299||
|&nbsp;&nbsp;***unsignedInt restriction***|||
|&nbsp;&nbsp;&nbsp;&nbsp;Pattern|`[123456789]\d*`||
|&nbsp;&nbsp;&nbsp;&nbsp;Min inclusive|70000||
|&nbsp;&nbsp;&nbsp;&nbsp;Max inclusive|99999||
|&nbsp;&nbsp;***unsignedInt restriction***|||
|&nbsp;&nbsp;&nbsp;&nbsp;Pattern|`[123456789]\d*`||
|&nbsp;&nbsp;&nbsp;&nbsp;Min inclusive|1000000||
|&nbsp;&nbsp;&nbsp;&nbsp;Max inclusive|9999999||
