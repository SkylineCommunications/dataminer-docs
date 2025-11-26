---
uid: Protocol.PortSettings.TimeoutTimeElement
---

# TimeoutTimeElement element

Specifies settings related to the element timeout.

## Parent

[PortSettings](xref:Protocol.PortSettings)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[DefaultValue](xref:Protocol.PortSettings.TimeoutTimeElement.DefaultValue)|[0, 1]|Specifies the default element timeout value (in ms).|
|&nbsp;&nbsp;[Disabled](xref:Protocol.PortSettings.TimeoutTimeElement.Disabled)|[0, 1]|Specifies whether the element timeout time for this connection can be configured via the DataMiner user interface.|

## Remarks

> [!NOTE]
>
> - If an element has multiple connections, it will go into timeout as soon as one of the connections times out.<!-- RN 16909 --> If a particular connection should not influence the overall timeout state of an element, clear the *Include timeout* option for that connection when you create or edit the element in Cube.
> - Currently, DataMiner only takes into account the value specified for the main connection. It uses this value for all connections.
