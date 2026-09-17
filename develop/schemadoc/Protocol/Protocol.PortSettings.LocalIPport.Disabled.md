---
metadata_version: 1
uid: Protocol.PortSettings.LocalIPport.Disabled
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

Specifies whether the local port number can be configured via the DataMiner user interface.

## Type

[EnumTrueFalse](xref:Protocol-EnumTrueFalse)

## Parent

[LocalIPport](xref:Protocol.PortSettings.LocalIPport)

## Remarks

Contains one of the following predefined values:

|Value|Description
|--- |--- |
|true|Users will not be able to modify the setting in the DataMiner user interface.|
|false|Users will be able to modify the setting in the DataMiner user interface.|

> [!NOTE]
> A default value for the local IP port must also be specified in the protocol (via the LocalIPport.DefaultValue tag) in order for the user interface to visualize this setting.
