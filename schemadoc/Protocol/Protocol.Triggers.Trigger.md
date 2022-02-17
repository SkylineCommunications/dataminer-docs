---
uid: Protocol.Triggers.Trigger
---

# Trigger element

Defines a trigger.

## Parent

[Triggers](xref:Protocol.Triggers)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[id](xref:Protocol.Triggers.Trigger-id)|[TypeObjectId](xref:Protocol-TypeObjectId)|Yes|Specifies the unique trigger ID.|

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[Condition](xref:Protocol.Triggers.Trigger.Condition)|[0, 1]|Specifies a condition that must be met in order for the trigger to go off.|
|&nbsp;&nbsp;[Content](xref:Protocol.Triggers.Trigger.Content)||Specifies the actions to be executed, or triggers to be activated the moment the trigger goes off.|
|&nbsp;&nbsp;[Name](xref:Protocol.Triggers.Trigger.Name)|[0, 1]|Specifies the name of the trigger.|
|&nbsp;&nbsp;[On](xref:Protocol.Triggers.Trigger.On)|[0, 1]|Defines what will set off the trigger.|
|&nbsp;&nbsp;[Time](xref:Protocol.Triggers.Trigger.Time)|[0, 1]|Defines, together with /Protocol/Triggers/Trigger/On, the exact moment at which a trigger will go off.|
|&nbsp;&nbsp;[Type](xref:Protocol.Triggers.Trigger.Type)||Specifies what should happen when the trigger goes off.|

## Remarks

Triggers allow you to define the exact moment at which certain actions have to be executed. They can, for example, be used to set the exact time at which to perform a copy operation, to calculate a CRC, etc.
