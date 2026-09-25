---
metadata_version: 1
uid: Protocol.PortSettings.BusAddress.Disabled
description: "Learn how the Disabled element under BusAddress controls whether users can change the bus address in the DataMiner user interface."
---

# Disabled element

Specifies whether the bus address can be modified in the DataMiner user interface.

## Type

[EnumTrueFalse](xref:Protocol-EnumTrueFalse)

## Parent

[BusAddress](xref:Protocol.PortSettings.BusAddress)

## Remarks

Contains one of the following predefined values:

|Value|Description
|--- |--- |
|true|Users will not be able to modify the setting in the DataMiner user interface.|
|false|Users will be able to modify the setting in the DataMiner user interface.|

> [!NOTE]
> If you set `Disabled` to "true" for a GPIB connection, this will be ignored.<!-- RN 12883 -->
