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
| Connection             | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| ProtocolName           | String  | The name of the protocol                                                         |
| ProtocolVersion        | String  | The protocol version                                                             |
| includeWriteParameters | Boolean | Indicates whether write parameters should be included.                           |
| Index                  | Integer | The point from which to start returning parameters.                              |
| Count                  | Integer | The number of parameters to be returned.                                         |
| OrderBy                | String  | The field(s) by which to order the parameters (separated by semicolons).         |

## Output

| Item | Format | Description |
|--|--|--|
| GetParametersFor­ProtocolSortedResult | Array of [DMAParameter](xref:DMAParameter) | The parameters for the specified protocol, sorted as requested. |
