---
metadata_version: 1
uid: Protocol.PortSettings.Type.DefaultValue
description: "Learn how the DefaultValue element under PortSettings Type selects UDP/IP, TCP/IP, or Serial as the default port type."
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
