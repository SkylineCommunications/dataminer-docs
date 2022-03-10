---
uid: Protocol.AlarmLevelLinks.AlarmLevelLink
---

# AlarmLevelLink element

Defines an alarm level link.

## Parent

[AlarmLevelLinks](xref:Protocol.AlarmLevelLinks)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[destination](xref:Protocol.AlarmLevelLinks.AlarmLevelLink-destination)|string|Yes|Specifies the column parameter ID where the result of the alarm level needs to be set.|
|[filters](xref:Protocol.AlarmLevelLinks.AlarmLevelLink-filters)|[TypeNonEmptyString](xref:Protocol-TypeNonEmptyString)||Specifies the column parameter ID where the result of the alarm level needs to be set.|
|[id](xref:Protocol.AlarmLevelLinks.AlarmLevelLink-id)|unsignedInt|Yes|The unique ID of the AlarmLevelLink.|
|[remoteElement](xref:Protocol.AlarmLevelLinks.AlarmLevelLink-remoteElement)|[TypeNonEmptyString](xref:Protocol-TypeNonEmptyString)|Yes|Used to retrieve the alarm state of a different element.|

## Remarks

An alarm level link allows aggregating alarms from DataMiner elements or table rows at runtime.

Contains the source and the destination of the element in alarm and where the result needs to be placed. The source and destination are table columns.

The source and destination are table columns.
