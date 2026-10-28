---
uid: Protocol.Triggers.Trigger.Content.Id
description: "Use the Id element under Trigger Content in a DataMiner protocol to identify an action to execute or a trigger to activate."
---

# Id element

Specifies the ID of the action to be executed or the trigger to be activated when this trigger goes off.

## Type

unsignedInt

## Parent

[Content](xref:Protocol.Triggers.Trigger.Content)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[else](xref:Protocol.Triggers.Trigger.Content.Id-else)|[EnumTrueFalse](xref:Protocol-EnumTrueFalse)||When a condition has been added to the trigger, the action of which the ID is specified in this attribute will be executed when the condition is not met.|
