---
metadata_version: 1
uid: Protocol.AlarmLevelLinks
description: "Learn how the AlarmLevelLinks element contains unique links that aggregate alarms from elements or table rows in a DataMiner connector protocol."
---

# AlarmLevelLinks element

Contains a number of `<AlarmLevelLink>` child elements.

## Parent

[Protocol](xref:Protocol)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[AlarmLevelLink](xref:Protocol.AlarmLevelLinks.AlarmLevelLink)|[0, *]|Defines an alarm level link.|

## Constraints

|Type|Description|Selector|Fields|
|--- |--- |--- |--- |
|Unique |The ID of an alarm level link must be unique. |AlarmLevelLink |@id |
