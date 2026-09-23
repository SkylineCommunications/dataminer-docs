---
metadata_version: 1
uid: Protocol.Actions.Action.On-id
description: "Use the Action On id attribute to identify the parameters, commands, responses, or other items targeted by a connector protocol action."
---

# id attribute

Specifies the ID of the parameter, command, response, etc.

## Content Type

[TypeSemicolonSeparatedNumbers](xref:Protocol-TypeSemicolonSeparatedNumbers)

## Parent

[Action](xref:Protocol.Actions.Action.On)

## Remarks

In case the `id` attribute is not present and the action is executed from a [Trigger](xref:Protocol.Triggers.Trigger), and the trigger's [On](xref:Protocol.Triggers.Trigger.On) type matches the action's [On](xref:Protocol.Actions.Action.On) type, the action will apply to the specific item that triggered it.
