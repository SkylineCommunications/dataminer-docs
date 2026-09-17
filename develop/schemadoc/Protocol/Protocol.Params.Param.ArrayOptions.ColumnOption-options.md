---
metadata_version: 1
uid: Protocol.Params.Param.ArrayOptions.ColumnOption-options
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

Defines different options.

## Content Type

string

## Parent

[ColumnOption](xref:Protocol.Params.Param.ArrayOptions.ColumnOption)

## Remarks

In the *options* attribute, you can specify multiple values separated by a character of choice (a semicolon is recommended). This character has to be the first character in the value of the options attribute. If, for example, you want to separate the different options by a semicolon, the first character of the options value has to be a semicolon.

Refer to <xref:ColumnOptionOptionsOverview> for an overview of all the available options.
