---
uid: GetMatrixConnections
---

# GetMatrixConnections

Use this method to retrieve the connected crosspoints of a matrix.

Available from DataMiner version 9.5.1 onwards.

## Input

| Item        | Format  | Description                                                                      |
|-------------|---------|----------------------------------------------------------------------------------|
| Connection  | String  | The connection ID. See [ConnectApp](xref:ConnectApp) . |
| DmaID       | Integer | The DataMiner Agent ID.                                                          |
| ElementID   | Integer | The element ID.                                                                  |
| ParameterID | Integer | The matrix parameter ID.                                                         |

## Output

| Item               | Format                                                                                                     | Description                                                   |
|--------------------|------------------------------------------------------------------------------------------------------------|---------------------------------------------------------------|
| GetParameterResult | Array of DMAMatrixConnec­tion (See [DMAMatrixConnection](xref:DMAMatrixConnection)) | An array containing the connections for the specified matrix. |

