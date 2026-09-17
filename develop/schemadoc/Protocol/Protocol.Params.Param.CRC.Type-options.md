---
metadata_version: 1
uid: Protocol.Params.Param.CRC.Type-options
description: "Reference the DataMiner connector protocol schema entry for options attribute, including its documented structure, attributes, values, and constraints."
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

# options attribute

Specifies additional options, separated by semicolons (”;”).

## Content Type

string

## Parent

[Type](xref:Protocol.Params.Param.CRC.Type)

## Remarks

The following options are available:

### ONES COMPLEMENT

Each bit of the calculated CRC will be inverted.

Example: AAAA will become 5555

### OR TOTALOFFSET

The totaloffset value will not be added but “OR”-ed.
