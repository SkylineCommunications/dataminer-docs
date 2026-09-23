---
metadata_version: 1
uid: Protocol-EnumTriggerTime
description: "Review the allowed values for the EnumTriggerTime simple type and what each value represents in DataMiner connector protocols."
---

# EnumTriggerTime simple type

Specifies the time the trigger is triggered.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***string restriction***|||
|&nbsp;&nbsp;Enumeration|after||
|&nbsp;&nbsp;Enumeration|after startup||
|&nbsp;&nbsp;Enumeration|before||
|&nbsp;&nbsp;Enumeration|change||
|&nbsp;&nbsp;Enumeration|change after response||
|&nbsp;&nbsp;Enumeration|link file change||
|&nbsp;&nbsp;Enumeration|succeeded||
|&nbsp;&nbsp;Enumeration|timeout||
|&nbsp;&nbsp;Enumeration|timeout after retries|Specifies that the trigger will go off after the last retry.<!-- RN 8573 -->|
