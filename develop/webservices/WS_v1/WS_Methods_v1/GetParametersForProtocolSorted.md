---
uid: GetParametersForProtocolSorted
---

# GetParametersForProtocolSorted

Use this method to retrieve specific number of parameters for a specified protocol.

> [!NOTE]
> Using this method, you can e.g. request parameters in batches in order to minimize loading time.

## Input

| Item                   | Format  | Description                                                                      |
|------------------------|---------|----------------------------------------------------------------------------------|
| connection             | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| protocolName           | String  | The name of the protocol                                                         |
| protocolVersion        | String  | The protocol version                                                             |
| includeWriteParameters | Boolean | Indicates whether write parameters should be included.                           |
| index                  | Integer | The point from which to start returning parameters.                              |
| count                  | Integer | The number of parameters to be returned.                                         |
| orderBy                | String  | The field(s) by which to order the parameters (separated by semicolons).         |

## Output

| Item | Format | Description |
|--|--|--|
| GetParametersForProtocolSortedResult | Array of [DMAParameter](xref:DMAParameter) | The parameters for the specified protocol, sorted as requested. |
