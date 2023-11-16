---
uid: LogicActions
---

# Actions

An action defines something that must be performed. It is activated by a trigger. An action can also be part of a group.

Many different types of actions are defined (e.g. an action exists to copy the value of a parameter to another parameter, read a file from a directory, add a group to the group execution queue, increment the value of a parameter, etc.).

Actions are typically executed when a trigger goes off. Multiple actions can be linked to one trigger.

An action always consists of a combination of "On" and "Type":

- "On" represents where the action needs to be executed. See [Protocol.Actions.Action.On](xref:Protocol.Actions.Action.On)
- "Type" represents what needs to be done. See [Protocol.Actions.Action.Type](xref:Protocol.Actions.Action.Type)

The following [overview](xref:LogicActionsOverview) lists all available actions and provides more information about how to use these.

> [!NOTE]
>
> - For more information on how to define an action in a protocol, see [Protocol.Actions.Action](xref:Protocol.Actions.Action).
> - An example protocol "SLC SDF Actions - On Parameters" is available in the [Protocol Development Guide Companion Files](https://community.dataminer.services/documentation/protocol-development-guide-companion-files/) illustrating actions on parameters.
