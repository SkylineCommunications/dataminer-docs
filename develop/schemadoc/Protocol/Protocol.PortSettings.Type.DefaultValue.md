---
metadata_version: 1
uid: Protocol.PortSettings.Type.DefaultValue
description: "Reference the DataMiner connector protocol schema entry for DefaultValue element, including its documented structure, attributes, values, and constraints."
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

# DefaultValue element

Specifies the default port type.

## Type

[EnumPortTypes](xref:Protocol-EnumPortTypes)

## Parent

[Type](xref:Protocol.PortSettings.Type)

## Remarks

Contains one of the following predefined values:

|Value|Description
|--- |--- |
|udp|The port type “UDP/IP” will be selected by default.|
|ip|The port type “TCP/IP” will be selected by default.|
|rs232|The port type “Serial” will be selected by default.|
