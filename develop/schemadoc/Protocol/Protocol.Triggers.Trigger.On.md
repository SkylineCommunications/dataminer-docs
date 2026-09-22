---
metadata_version: 1
uid: Protocol.Triggers.Trigger.On
description: "Reference the DataMiner connector protocol schema entry for On element, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
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
