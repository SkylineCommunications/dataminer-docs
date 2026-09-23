---
metadata_version: 1
uid: Protocol-EnumTriggerType
description: "Review the allowed values for the EnumTriggerType simple type and what each value represents in DataMiner connector protocols."
---

# EnumTriggerType simple type

Specifies the trigger type.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***string restriction***|||
|&nbsp;&nbsp;Enumeration|action|When the trigger goes off, the action(s) specified in Protocol.Triggers.Trigger.Content will be executed.|
|&nbsp;&nbsp;Enumeration|trigger|When the trigger goes off, the trigger(s) specified in Protocol.Triggers.Trigger.Content will be activated.|
