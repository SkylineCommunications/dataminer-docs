---
metadata_version: 1
uid: Protocol.AlarmLevelLinks
description: "Reference the DataMiner connector protocol schema entry for AlarmLevelLinks element, including its documented structure, attributes, values, and constrain."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
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
