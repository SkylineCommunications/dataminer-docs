---
metadata_version: 1
uid: Protocol.Actions.Action.Type-scale
description: "Use the Action Type scale attribute with set info actions to define the lowdata, highdata, low, and high scale values for a parameter."
---

# scale attribute

If Action/Type is "set info", this attribute specifies the scale to be set on the parameter.

Expected format: `lowdata;highdata;low;high` (for example: scale="0;65535;-10;10").

## Content Type

string

## Parent

[Type](xref:Protocol.Actions.Action.Type)
