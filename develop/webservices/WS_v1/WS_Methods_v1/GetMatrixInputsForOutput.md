---
uid: GetMatrixInputsForOutput
---

# GetMatrixInputsForOutput

Use this method to retrieve the inputs of a matrix output, using a 1-based index.

Available from DataMiner version 9.5.1 onwards.

## Input

| Item        | Format  | Description                                                                      |
|-------------|---------|----------------------------------------------------------------------------------|
| connection  | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID       | Integer | The DataMiner Agent ID.                                                          |
| elementID   | Integer | The element ID.                                                                  |
| parameterID | Integer | The matrix parameter ID.                                                         |
| output      | Integer | The output index (1-based).                                                      |

## Output

| Item | Format | Description |
|--|--|--|
| GetMatrixInputsForOutputResult | Array of [DMAMatrixConnection](xref:DMAMatrixConnection) | An array containing the connections for the specified output. |
