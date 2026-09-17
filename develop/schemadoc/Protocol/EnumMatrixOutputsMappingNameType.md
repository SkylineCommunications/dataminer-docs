---
metadata_version: 1
uid: Protocol-EnumMatrixOutputsMappingNameType
description: "Reference the DataMiner connector protocol schema entry for EnumMatrixOutputsMappingNameType simple type, including its documented structure, attributes."
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

# EnumMatrixOutputsMappingNameType simple type

List of options that can be used as type in the matrix mapping.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***string restriction***|||
|&nbsp;&nbsp;Enumeration|index|Indicates the index of the output.|
|&nbsp;&nbsp;Enumeration|label|Indicates the label of the output.|
|&nbsp;&nbsp;Enumeration|state|Indicates the state of the output.|
|&nbsp;&nbsp;Enumeration|lock|Indicates the lock state of the output.|
|&nbsp;&nbsp;Enumeration|page|Indicates the page on which the output is located.|
|&nbsp;&nbsp;Enumeration|connectedInput|Indicates the input on which the output is connected.|
|&nbsp;&nbsp;Enumeration|tooltip|Indicates the tooltip of the output which is shown on the crosspoint.|
|&nbsp;&nbsp;Enumeration|lockOverride|Indicates the lock override of the output. This can be used to (un)set a crosspoint while locked.|
