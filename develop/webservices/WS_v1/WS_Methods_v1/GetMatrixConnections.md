---
uid: GetMatrixConnections
---

# GetMatrixConnections

Use this method to retrieve the connected crosspoints of a matrix.

<!-- Available from DataMiner version 9.5.1 onwards. -->

## Input

| Item        | Format  | Description                                           |
|-------------|---------|-------------------------------------------------------|
| connection  | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID       | Integer | The DataMiner Agent ID.                               |
| elementID   | Integer | The element ID.                                       |
| parameterID | Integer | The matrix parameter ID.                              |

## Output

| Item               | Format                                                   | Description                                                   |
|--------------------|----------------------------------------------------------|---------------------------------------------------------------|
| GetParameterResult | Array of [DMAMatrixConnection](xref:DMAMatrixConnection) | An array containing the connections for the specified matrix. |
