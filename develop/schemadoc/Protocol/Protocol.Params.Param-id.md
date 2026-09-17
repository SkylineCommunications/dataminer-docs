---
metadata_version: 1
uid: Protocol.Params.Param-id
description: "Reference the DataMiner connector protocol schema entry for id attribute, including its documented structure, attributes, values, and constraints."
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

# id attribute

Specifies the ID of the parameter.

## Content Type

[TypeParamId](xref:Protocol-TypeParamId)

## Parent

[Param](xref:Protocol.Params.Param)

## Remarks

Normal parameters should have an ID in the following range: 1-64000. Spectrum parameters should have an ID in the following range: 1-50000.

> [!CAUTION]
> Never change parameter IDs in existing protocols. This would severely affect alarms, trend displays, Visio files, etc.
