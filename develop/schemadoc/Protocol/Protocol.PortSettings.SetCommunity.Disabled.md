---
metadata_version: 1
uid: Protocol.PortSettings.SetCommunity.Disabled
description: "Reference the DataMiner connector protocol schema entry for Disabled element, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# Disabled element

Specifies whether the SetCommunity string can be modified in the DataMiner user interface.

## Type

[EnumTrueFalse](xref:Protocol-EnumTrueFalse)

## Parent

[SetCommunity](xref:Protocol.PortSettings.SetCommunity)

## Remarks

Contains one of the following predefined values:

|Value|Description
|--- |--- |
|true|Users will not be able to modify the setting in the DataMiner user interface.|
|false|Users will be able to modify the setting in the DataMiner user interface.|
