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
> - Prior to DataMiner 9.5.6, if an element has multiple connections, it will not go into timeout state as long as one of the connections is still communicating properly. From DataMiner 9.5.6 (RN 16909) onwards, this is no longer the case: as soon as one of the connections times out, the element will go into timeout.
>
>   Users can clear the Include timeout option for a particular connection while creating or editing an element to ensure that this connection does not influence the overall timeout state of the element.
>
> - Currently, DataMiner only takes into account the value specified for the main connection. It uses this value for all connections.
