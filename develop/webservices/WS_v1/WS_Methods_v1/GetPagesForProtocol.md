---
uid: GetPagesForProtocol
---

# GetPagesForProtocol

Use this method to retrieve all the pages for a specified protocol.

## Input

| Item            | Format | Description                                                                      |
|-----------------|--------|----------------------------------------------------------------------------------|
| connection      | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| protocolName    | String | The name of the protocol                                                         |
| protocolVersion | String | The protocol version                                                             |

## Output

| Item | Format | Description |
|--|--|--|
| GetPagesForProtocolResult | Array of [DMAProtocolPage](xref:DMAProtocolPage) | The pages of the specified protocol. |
