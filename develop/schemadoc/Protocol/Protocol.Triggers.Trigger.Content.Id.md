---
metadata_version: 1
uid: Protocol.Triggers.Trigger.Content.Id
description: "Reference the DataMiner connector protocol schema entry for Id element, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
lifecycle: active
applies_to:
  - DataMiner
version: unknown
owner: unknown
review_status: needs_update
review_date: 2026-09-17
compatibility:
  uid: stable
  url: stable
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
