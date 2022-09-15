---
uid: GetMatrixOutputsForInputLabel
---

# GetMatrixOutputsForInputLabel

Use this method to retrieve the outputs of a matrix input, using the label of the input.

Available from DataMiner version 9.5.1 onwards.

## Input

| Item        | Format  | Description                                                                      |
|-------------|---------|----------------------------------------------------------------------------------|
| connection  | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID       | Integer | The DataMiner Agent ID.                                                          |
| elementID   | Integer | The element ID.                                                                  |
| parameterID | Integer | The matrix parameter ID.                                                         |
| input       | Integer | The label of the input.                                                          |

## Output

| Item | Format | Description |
|--|--|--|
| GetMatrixOutputsForInputLabelResult | Array of [DMAMatrixConnection](xref:DMAMatrixConnection) | An array containing the connections for the specified input. |
