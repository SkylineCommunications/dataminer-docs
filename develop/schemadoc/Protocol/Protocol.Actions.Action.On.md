---
uid: Protocol.Actions.Action.On
---

# On element

Defines, together with [Type](xref:Protocol.Actions.Action.Type), how this action is executed.

> [!NOTE]
> Not all Protocol.Actions.Action.Type values can be used in combination with the different Protocol.Actions.Action.On types. See [Possible combinations of “On” and “Type”](xref:LogicActionsOverview).

## Type

[EnumActionOn](xref:Protocol-EnumActionOn)

## Parent

[Action](xref:Protocol.Actions.Action)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[id](xref:Protocol.Actions.Action.On-id)|[TypeSemicolonSeparatedNumbers](xref:Protocol-TypeSemicolonSeparatedNumbers)||The ID of the parameter, command, response, etc. In case the "id" attribute is not present, the trigger will apply to all items of the type specified in /Protocol/Actions/Action/On.|
|[nr](xref:Protocol.Actions.Action.On-nr)|string||If Action/Type is "reverse", this attribute specifies the (0-based) position(s) of the parameter(s) in the command/response. If Action/Type is "set next", this attribute specifies the (1-based) position(s) of the pair(s) in the group.|

## Remarks

The following table gives an overview of the actions that can be used with the different On values:

|On|Action|
|--- |--- |
|command|crc, length, make, read, replace, replace data, stuffing|
|group|add to execute, execute, execute next, execute one, execute one top, execute one now, force execute, set|
|pair| set next, timeout|
|parameter| aggregate, append, append data, change length, clear, clear on display, copy, copy reverse, go, increment, multiply, normalize, pow, read, replace data, reverse, run actions, save, set, set and get with wait, set info, set with wait|
|protocol|close, lock/unlock, merge, open, priority lock/priority unlock, read file, sleep, stop current group, swap column, wmi|
|response|clear, clear length info, crc, length, read, read stuffing, replace, replace data, stuffing|
|timer|restart timer, reschedule, start, stop|

For more information, refer to <xref:LogicActions>.
