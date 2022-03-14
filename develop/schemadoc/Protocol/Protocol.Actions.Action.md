---
uid: Protocol.Actions.Action
---

# Action element

Defines an action.

## Parent

[Actions](xref:Protocol.Actions)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[id](xref:Protocol.Actions.Action-id)|[TypeObjectId](xref:Protocol-TypeObjectId)|Yes|Specifies the unique action ID.|

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[Condition](xref:Protocol.Actions.Action.Condition)|[0, 1]|Specifies a condition that must be met in order for the action to execute.|
|&nbsp;&nbsp;[Name](xref:Protocol.Actions.Action.Name)|[0, 1]|Specifies the name of the action.|
|&nbsp;&nbsp;[On](xref:Protocol.Actions.Action.On)||Defines, together with [Type](xref:Protocol.Actions.Action.Type), how this action is executed.|
|&nbsp;&nbsp;[Type](xref:Protocol.Actions.Action.Type)||Defines, together with [On](xref:Protocol.Actions.Action.On), how the action is executed.|

## Remarks

For more information about actions, refer to <xref:LogicActions>.
