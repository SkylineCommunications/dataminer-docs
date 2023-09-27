---
uid: GetMatrixInputsForOutputLabel
---

# GetMatrixInputsForOutputLabel

Use this method to retrieve the inputs of a matrix output, using the label of the output.

Available from DataMiner version 9.5.1 onwards.

## Input

| Item        | Format  | Description                                                                      |
|-------------|---------|----------------------------------------------------------------------------------|
| connection  | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID       | Integer | The DataMiner Agent ID.                                                          |
| elementID   | Integer | The element ID.                                                                  |
| parameterID | Integer | The matrix parameter ID.                                                         |
| outputLabel | String  | The label of the output.                                                         |

## Output

| Item | Format | Description |
|--|--|--|
| GetMatrixInputsForOutputLabelResult | Array of [DMAMatrixConnection](xref:DMAMatrixConnection) | An array containing the connections for the specified output. |
