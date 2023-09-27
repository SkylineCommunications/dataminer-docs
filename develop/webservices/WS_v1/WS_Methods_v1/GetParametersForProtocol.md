---
uid: GetParametersForProtocol
---

# GetParametersForProtocol

Use this method to retrieve the data of all the parameters of a particular protocol.

## Input

| Item                   | Format  | Description                                                                      |
|------------------------|---------|----------------------------------------------------------------------------------|
| connection             | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| protocolName           | String  | The name of the protocol                                                         |
| protocolVersion        | String  | The protocol version                                                             |
| includeWriteParameters | Boolean | Indicates whether write parameters should be included.                           |

## Output

| Item | Format | Description |
|--|--|--|
| GetParametersForProtocolResult | Array of [DMAParameter](xref:DMAParameter) | The data of all the parameters of the specified protocol. |
