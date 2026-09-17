---
metadata_version: 1
uid: Protocol-TypeTriggerOnId
description: "Reference the DataMiner connector protocol schema entry for TypeTriggerOnId simple type, including its documented structure, attributes, values, and const."
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

# TypeTriggerOnId simple type

Specifies the valid values for the Trigger/On/Id tag.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***Union***|||
|&nbsp;&nbsp;unsignedInt|||
|&nbsp;&nbsp;***string restriction***|||
|&nbsp;&nbsp;&nbsp;&nbsp;Enumeration|each|Will be used as the default trigger for items for which no other trigger is triggering on that item. Can be used with values "command", "response", "pair" and "group".|
