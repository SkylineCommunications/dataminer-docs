---
metadata_version: 1
uid: Protocol-EnumParamInformationInclude
description: "Reference the DataMiner connector protocol schema entry for EnumParamInformationInclude simple type, including its documented structure, attributes, value."
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

# EnumParamInformationInclude simple type

Specifies the type of parameter information to include.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***string restriction***|||
|&nbsp;&nbsp;Enumeration|range|The range of the parameter.|
|&nbsp;&nbsp;Enumeration|steps|The step size of the parameter.|
|&nbsp;&nbsp;Enumeration|time|A time stamp that refers to the last known change or the last time the parameter was changed by its write parameter (if any).|
|&nbsp;&nbsp;Enumeration|units|The unit of the parameter.|
