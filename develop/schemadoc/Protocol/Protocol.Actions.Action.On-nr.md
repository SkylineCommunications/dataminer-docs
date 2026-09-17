---
metadata_version: 1
uid: Protocol.Actions.Action.On-nr
description: "Reference the DataMiner connector protocol schema entry for nr attribute, including its documented structure, attributes, values, and constraints."
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

# nr attribute

If Action/Type is "reverse", this attribute specifies the (0-based) position(s) of the parameter(s) in the command/response.

If Action/Type is "set next", this attribute specifies the (1-based) position(s) of the pair(s) in the group.

## Content Type

string

## Parent

[Action](xref:Protocol.Actions.Action.On)

## Remarks

Separate multiple positions with semicolons.
