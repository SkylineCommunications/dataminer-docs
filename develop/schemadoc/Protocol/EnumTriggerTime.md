---
metadata_version: 1
uid: Protocol-EnumTriggerTime
description: "Reference the DataMiner connector protocol schema entry for EnumTriggerTime simple type, including its documented structure, attributes, values, and const."
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

# EnumTriggerTime simple type

Specifies the time the trigger is triggered.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***string restriction***|||
|&nbsp;&nbsp;Enumeration|after||
|&nbsp;&nbsp;Enumeration|after startup||
|&nbsp;&nbsp;Enumeration|before||
|&nbsp;&nbsp;Enumeration|change||
|&nbsp;&nbsp;Enumeration|change after response||
|&nbsp;&nbsp;Enumeration|link file change||
|&nbsp;&nbsp;Enumeration|succeeded||
|&nbsp;&nbsp;Enumeration|timeout||
|&nbsp;&nbsp;Enumeration|timeout after retries|Specifies that the trigger will go off after the last retry.<!-- RN 8573 -->|
