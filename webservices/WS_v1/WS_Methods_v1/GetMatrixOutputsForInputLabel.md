---
uid: GetMatrixOutputsForInputLabel
---

# GetMatrixOutputsForInputLabel

Use this method to retrieve the outputs of a matrix input, using the label of the input.

Available from DataMiner version 9.5.1 onwards.

## Input

| Item        | Format  | Description                                                                      |
|-------------|---------|----------------------------------------------------------------------------------|
| Connection  | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| DmaID       | Integer | The DataMiner Agent ID.                                                          |
| ElementID   | Integer | The element ID.                                                                  |
| ParameterID | Integer | The matrix parameter ID.                                                         |
| Input       | Integer | The label of the input.                                                          |

## Output

| Item | Format | Description |
|--|--|--|
| GetMatrixOutputs­ForInputLabelResult | Array of [DMAMatrixConnection](xref:DMAMatrixConnection) | An array containing the connections for the specified input. |
