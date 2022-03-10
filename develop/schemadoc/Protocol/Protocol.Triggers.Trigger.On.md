---
uid: Protocol.Triggers.Trigger.On
---

# On element

Defines what will set off the trigger.

## Type

[EnumTriggerOn](xref:Protocol-EnumTriggerOn)

## Parent

[Trigger](xref:Protocol.Triggers.Trigger)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[id](xref:Protocol.Triggers.Trigger.On-id)|[TypeTriggerOnId](xref:Protocol-TypeTriggerOnId)||Specifies the ID of the parameter, command, response, etc.|

## Remarks

Used together with Protocol.Triggers.Trigger.Time, in which you define the exact moment at which the trigger has to go off.

Protocol.Triggers.Trigger.On is always used when defining a trigger, except when the trigger has to be activated by another trigger. In that case, the moment at which the trigger has to go off will already be defined in the initializing trigger. Protocol.Triggers.Trigger.Time will then also be empty.
