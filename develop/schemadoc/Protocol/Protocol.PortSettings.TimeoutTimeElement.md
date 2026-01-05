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

- If an element has multiple connections, it will go into timeout as soon as one of the connections times out.<!-- RN 16909 --> If a particular connection should not influence the overall timeout state of an element, clear the *Include timeout* option for that connection when you create or edit the element in Cube.
- Currently, DataMiner only takes into account the value specified for the main connection. It uses this value for all connections.
- This setting does not account for the number of retries. To ensure that the element has enough time to complete all retry attempts before declaring a timeout, you should therefore choose a value larger than **[Timeout of a single command](xref:Protocol.PortSettings.TimeoutTime) × ([Number of retries](xref:Protocol.PortSettings.Retries) + 1)**.
