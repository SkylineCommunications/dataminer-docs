---
uid: Protocol-TypeTriggerOnId
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
