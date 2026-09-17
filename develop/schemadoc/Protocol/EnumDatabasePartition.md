---
metadata_version: 1
uid: Protocol-EnumDatabasePartition
description: "Reference the DataMiner connector protocol schema entry for EnumDatabasePartition simple type, including its documented structure, attributes, values, and."
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

# EnumDatabasePartition simple type

Specifies the database partitioning.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***string restriction***|||
|&nbsp;&nbsp;Enumeration|hour|Hour|
|&nbsp;&nbsp;Enumeration|day|Day|
|&nbsp;&nbsp;Enumeration|month|Month|
|&nbsp;&nbsp;Enumeration|year|Year|
|&nbsp;&nbsp;Enumeration|infinite|Infinite (Elastic only)|
