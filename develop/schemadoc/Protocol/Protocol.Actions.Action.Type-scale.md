---
metadata_version: 1
uid: Protocol.Actions.Action.Type-scale
description: "Reference the DataMiner connector protocol schema entry for scale attribute, including its documented structure, attributes, values, and constraints."
content_type: schema
applies_to:
  - DataMiner
---

# scale attribute

If Action/Type is "set info", this attribute specifies the scale to be set on the parameter.

Expected format: `lowdata;highdata;low;high` (for example: scale="0;65535;-10;10").

## Content Type

string

## Parent

[Type](xref:Protocol.Actions.Action.Type)
