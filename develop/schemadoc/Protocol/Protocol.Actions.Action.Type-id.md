---
metadata_version: 1
uid: Protocol.Actions.Action.Type-id
description: "Reference the DataMiner connector protocol schema entry for id attribute, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# id attribute

If Action/Type is "read file", this attribute specifies the ID of the parameter containing the directory in which the file can be found.

If Action/Type is "replace", this attribute specifies the ID of the parameter that contains the ID of the parameter that has to be put in the command/response.

If Action/Type is "increment", this attribute specifies the ID of the parameter that holds the increment value.

## Content Type

unsignedInt

## Parent

[Type](xref:Protocol.Actions.Action.Type)
