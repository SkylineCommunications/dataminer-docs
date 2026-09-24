---
metadata_version: 1
uid: Protocol.Actions.Action.Type-nr
description: "Use the Action Type nr attribute to set a byte count, item position, or connection ID, depending on the connector protocol action type."
---

# nr attribute

If Action/Type is "read file", this attribute specifies the number of bytes to be read.

If Action/Type is "replace", this attribute specifies the (0-based) position of the parameter in the command/response.

If Action/Type is "set", "set and get with wait", "set with wait", "open", "close", "lock", "unlock", "priority lock" or "priority unlock", this attribute specifies the (0-based) connection ID.

## Content Type

string

## Parent

[Type](xref:Protocol.Actions.Action.Type)
