---
uid: GetPagesForProtocol
---

# GetPagesForProtocol

Use this method to retrieve all the pages for a specified protocol.

## Input

| Item            | Format | Description                                                                      |
|-----------------|--------|----------------------------------------------------------------------------------|
| Connection      | String | The connection ID. See [ConnectApp](xref:ConnectApp) . |
| ProtocolName    | String | The name of the protocol                                                         |
| ProtocolVersion | String | The protocol version                                                             |

## Output

| Item                       | Format                                                                                        | Description                          |
|----------------------------|-----------------------------------------------------------------------------------------------|--------------------------------------|
| GetPagesForProtocol­Result | Array of DMAProtocolPage (see [DMAProtocolPage](xref:DMAProtocolPage)) | The pages of the specified protocol. |

