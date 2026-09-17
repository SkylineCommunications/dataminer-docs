---
metadata_version: 1
uid: Protocol.PortSettings.Retries.Disabled
description: "Reference the DataMiner connector protocol schema entry for Disabled element, including its documented structure, attributes, values, and constraints."
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

# Disabled element

Specifies whether the maximum number of retries can be modified in the DataMiner user interface.

## Type

[EnumTrueFalse](xref:Protocol-EnumTrueFalse)

## Parent

[Retries](xref:Protocol.PortSettings.Retries)

## Remarks

Contains one of the following predefined values:

|Value|Description
|--- |--- |
|true|Users will not be able to modify the setting in the DataMiner user interface.|
|false|Users will be able to modify the setting in the DataMiner user interface.|
