---
metadata_version: 1
uid: Protocol.Actions.Action.Type-nr
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

If Action/Type is "read file", this attribute specifies the number of bytes to be read.

If Action/Type is "replace", this attribute specifies the (0-based) position of the parameter in the command/response.

If Action/Type is "set", "set and get with wait", "set with wait", "open", "close", "lock", "unlock", "priority lock" or "priority unlock", this attribute specifies the (0-based) connection ID.

## Content Type

string

## Parent

[Type](xref:Protocol.Actions.Action.Type)
