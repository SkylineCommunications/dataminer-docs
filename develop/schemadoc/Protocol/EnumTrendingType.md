---
metadata_version: 1
uid: Protocol-EnumTrendingType
description: "Reference the DataMiner connector protocol schema entry for EnumTrendingType simple type, including its documented structure, attributes, values, and cons."
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

# EnumTrendingType simple type

Specifies the trending type.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***string restriction***|||
|&nbsp;&nbsp;Enumeration|average|Average value in the time span (default when no trending tag is present).|
|&nbsp;&nbsp;Enumeration|max|Maximum value in the time span.|
|&nbsp;&nbsp;Enumeration|min|Minimum value in the time span.|
|&nbsp;&nbsp;Enumeration|last|Last value in the time span.|
|&nbsp;&nbsp;Enumeration|sum|Sum of all the values in the time span. This cannot be used for discreet parameters.|
