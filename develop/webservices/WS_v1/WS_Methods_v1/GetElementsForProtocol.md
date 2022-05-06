---
uid: GetElementsForProtocol
---

# GetElementsForProtocol

Use this method to retrieve the list of all the elements based on a particular protocol.

## Input

| Item            | Format | Description                                          |
|-----------------|--------|------------------------------------------------------|
| connection      | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| protocolName    | String | The name of the protocol.                            |
| protocolVersion | String | The protocol version.                                |

## Output

| Item | Format | Description |
|--|--|--|
| GetElementsForProtocolResult | Array of [DMAElement](xref:DMAElement) | The list of all the elements based on the specified protocol. |
