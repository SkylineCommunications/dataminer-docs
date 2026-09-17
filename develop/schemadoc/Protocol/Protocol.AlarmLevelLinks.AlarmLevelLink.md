---
metadata_version: 1
uid: Protocol.AlarmLevelLinks.AlarmLevelLink
description: "Reference the DataMiner connector protocol schema entry for AlarmLevelLink element, including its documented structure, attributes, values, and constraint."
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
