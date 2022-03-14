---
uid: Protocol.PortSettings.Baudrate
---

# Baudrate element

Allows to limit baud rate settings and to define a default value.

## Parent

[PortSettings](xref:Protocol.PortSettings)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***Sequence***|||
|&nbsp;&nbsp;[DefaultValue](xref:Protocol.PortSettings.Baudrate.DefaultValue)|[0, 1]|Specifies the default baud rate.|
|&nbsp;&nbsp;[Disabled](xref:Protocol.PortSettings.Baudrate.Disabled)|[0, 1]|Specifies whether the baud rate can be modified in the DataMiner user interface.|
|&nbsp;&nbsp;[Range](xref:Protocol.PortSettings.Baudrate.Range)|[0, 1]|Defines a range of possible baud rate settings.|
|&nbsp;&nbsp;[Value](xref:Protocol.PortSettings.Baudrate.Value)|[0, *]|Using one or more Value elements, you can specify the different values that users are allowed to enter.|

## Remarks

Typically, this information will correspond to the specifications received from the manufacturer.


