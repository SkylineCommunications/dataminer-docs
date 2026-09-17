---
metadata_version: 1
uid: Protocol.Actions.Action.Type-startoffset
description: "Reference the DataMiner connector protocol schema entry for startoffset attribute, including its documented structure, attributes, values, and constraints."
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

# startoffset attribute

If Action/Type is "read file", this attribute specifies the ID of the parameter containing the start offset (i.e., the number of bytes to skip before starting to read the file).

If Action/Type is "stuffing", this attribute specifies the (fixed) start position that delimits the part of the data block in which stuffing has to be performed.

## Content Type

unsignedInt

## Parent

[Type](xref:Protocol.Actions.Action.Type)
