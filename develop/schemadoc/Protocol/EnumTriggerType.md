---
metadata_version: 1
uid: Protocol-EnumTriggerType
description: "Reference the DataMiner connector protocol schema entry for EnumTriggerType simple type, including its documented structure, attributes, values, and const."
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

# EnumTriggerType simple type

Specifies the trigger type.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***string restriction***|||
|&nbsp;&nbsp;Enumeration|action|When the trigger goes off, the action(s) specified in Protocol.Triggers.Trigger.Content will be executed.|
|&nbsp;&nbsp;Enumeration|trigger|When the trigger goes off, the trigger(s) specified in Protocol.Triggers.Trigger.Content will be activated.|
