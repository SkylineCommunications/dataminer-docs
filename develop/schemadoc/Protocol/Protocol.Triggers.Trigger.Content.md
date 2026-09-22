---
metadata_version: 1
uid: Protocol.Triggers.Trigger.Content
description: "Reference the DataMiner connector protocol schema entry for Content element, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# Content element

Specifies the actions to be executed, or triggers to be activated the moment the trigger goes off.

## Parent

[Trigger](xref:Protocol.Triggers.Trigger)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Id](xref:Protocol.Triggers.Trigger.Content.Id)|[0, *]|Specifies the ID of the action to be executed or the trigger to be activated when this trigger goes off.|

## Remarks

Must contain at least one Protocol.Triggers.Trigger.Content.Id element. See [Id](xref:Protocol.Triggers.Trigger.Content.Id).

> [!NOTE]
> Do not include more than 10 items.
