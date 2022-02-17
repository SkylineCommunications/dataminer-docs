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
> From DataMiner 9.0.0 (RN 12883) onwards, it is no longer possible to disable the Device Address field for a GPIB connection. If you do set Disabled to “true”, this will be disregarded in that case.
