---
metadata_version: 1
uid: Protocol.Actions.Action.Type-id
description: "Use the Action Type id attribute to identify the related directory, parameter, or increment value required by specific action types."
---

# id attribute

If Action/Type is "read file", this attribute specifies the ID of the parameter containing the directory in which the file can be found.

If Action/Type is "replace", this attribute specifies the ID of the parameter that contains the ID of the parameter that has to be put in the command/response.

If Action/Type is "increment", this attribute specifies the ID of the parameter that holds the increment value.

## Content Type

unsignedInt

## Parent

[Type](xref:Protocol.Actions.Action.Type)
