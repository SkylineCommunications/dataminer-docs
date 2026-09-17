---
metadata_version: 1
uid: Protocol.Params.Param.Length.Content.Param
description: "Reference the DataMiner connector protocol schema entry for Param element, including its documented structure, attributes, values, and constraints."
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

# Param element

Specifies a parameter of the command/response to be included in the length calculation.

## Type

unsignedInt

## Parent

[Content](xref:Protocol.Params.Param.Length.Content)

## Remarks

The length only involves the parameters defined in this tag.

> [!NOTE]
> The first parameter of the command/response has ID 0.
