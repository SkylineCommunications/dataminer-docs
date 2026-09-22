---
metadata_version: 1
uid: Protocol.Actions.Action.Type-returnValue
description: "Reference the DataMiner connector protocol schema entry for returnValue attribute, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# returnValue attribute

If Action/Type is "read file", this attribute specifies the ID of the parameter in which to store the retrieved file content.

If Action/Type is "wmi", this attribute specifies the ID of the parameter containing the returned values (if "table" is set to "true", this ID should be the ID of a parameter of type "array").

## Content Type

string

## Parent

[Type](xref:Protocol.Actions.Action.Type)
