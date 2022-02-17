---
uid: Protocol.PortSettings.LocalIPport.Disabled
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
