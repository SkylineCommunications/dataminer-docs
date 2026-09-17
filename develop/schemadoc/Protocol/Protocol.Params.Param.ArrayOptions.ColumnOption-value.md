---
metadata_version: 1
uid: Protocol.Params.Param.ArrayOptions.ColumnOption-value
description: "Reference the DataMiner connector protocol schema entry for value attribute, including its documented structure, attributes, values, and constraints."
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

# value attribute

The interpretation of this value attribute depends on the value of the type attribute:

## Content Type

string

## Parent

[ColumnOption](xref:Protocol.Params.Param.ArrayOptions.ColumnOption)

## Remarks

|If type is ...|then value is ...
|--- |--- |
|concatenation|the enumeration of the columns to be concatenated.|
|autoincrement|the offset for the automatic increment of the indexes.|
