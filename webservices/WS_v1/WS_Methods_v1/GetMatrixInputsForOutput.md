---
uid: GetMatrixInputsForOutput
---

# GetMatrixInputsForOutput

Use this method to retrieve the inputs of a matrix output, using a 1-based index.

Available from DataMiner version 9.5.1 onwards.

## Input

| Item        | Format  | Description                                                                      |
|-------------|---------|----------------------------------------------------------------------------------|
| Connection  | String  | The connection ID. See [ConnectApp](xref:ConnectApp) . |
| DmaID       | Integer | The DataMiner Agent ID.                                                          |
| ElementID   | Integer | The element ID.                                                                  |
| ParameterID | Integer | The matrix parameter ID.                                                         |
| Output      | Integer | The output index (1-based).                                                      |

## Output

| Item                            | Format                                                                                                     | Description                                                   |
|---------------------------------|------------------------------------------------------------------------------------------------------------|---------------------------------------------------------------|
| GetMatrixInputsFor­OutputResult | Array of DMAMatrixConnec­tion (See [DMAMatrixConnection](xref:DMAMatrixConnection)) | An array containing the connections for the specified output. |

