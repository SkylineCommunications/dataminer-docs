---
metadata_version: 1
uid: Protocol-TypeTriggerOnId
description: "Use the TypeTriggerOnId simple type to accept an unsigned ID or each as a default trigger target in the DataMiner connector protocol schema."
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
