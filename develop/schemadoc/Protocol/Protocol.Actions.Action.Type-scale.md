---
metadata_version: 1
uid: Protocol.Actions.Action.Type-scale
description: "Reference the DataMiner connector protocol schema entry for scale attribute, including its documented structure, attributes, values, and constraints."
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

# scale attribute

If Action/Type is "set info", this attribute specifies the scale to be set on the parameter.

Expected format: `lowdata;highdata;low;high` (for example: scale="0;65535;-10;10").

## Content Type

string

## Parent

[Type](xref:Protocol.Actions.Action.Type)
