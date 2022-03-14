---
uid: GetParametersForProtocol
---

# GetParametersForProtocol

Use this method to retrieve the data of all the parameters of a particular protocol.

## Input

| Item                   | Format  | Description                                                                      |
|------------------------|---------|----------------------------------------------------------------------------------|
| Connection             | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| ProtocolName           | String  | The name of the protocol                                                         |
| ProtocolVersion        | String  | The protocol version                                                             |
| includeWriteParameters | Boolean | Indicates whether write parameters should be included.                           |

## Output

| Item | Format | Description |
|--|--|--|
| GetParametersFor­ProtocolResult | Array of [DMAParameter](xref:DMAParameter) | The data of all the parameters of the specified protocol. |
