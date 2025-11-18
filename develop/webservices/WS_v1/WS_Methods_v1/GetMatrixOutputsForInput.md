---
uid: GetMatrixOutputsForInput
---

# GetMatrixOutputsForInput

Use this method to retrieve the outputs of a matrix input, using a 1-based index.

## Input

| Item        | Format  | Description                                           |
|-------------|---------|-------------------------------------------------------|
| connection  | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID       | Integer | The DataMiner Agent ID.                               |
| elementID   | Integer | The element ID.                                       |
| parameterID | Integer | The matrix parameter ID.                              |
| input       | Integer | The input index (1-based).                            |

## Output

| Item | Format | Description |
|--|--|--|
| GetMatrixOutputsForInputResult | Array of [DMAMatrixConnection](xref:DMAMatrixConnection) | An array containing the connections for the specified input. |
