---
metadata_version: 1
uid: Protocol.ParameterGroups.Group-id
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

Specifies the unique ID of the parameter group.

## Content Type

unsignedInt

## Parent

[Group](xref:Protocol.ParameterGroups.Group)

## Remarks

> [!NOTE]
> A parameter group cannot have an ID equal to 100 000 or higher. The IDs in the range 100 000 - 199 999 are reserved for DCF dynamic interfaces.<!-- RN 13161 -->
