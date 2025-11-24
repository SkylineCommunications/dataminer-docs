---
uid: Protocol.PortSettings.BusAddress.Disabled
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
