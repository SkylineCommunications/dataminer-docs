---
uid: GetMatrixInputsForOutputLabel
---

# GetMatrixInputsForOutputLabel

Use this method to retrieve the inputs of a matrix output, using the label of the output.

Available from DataMiner version 9.5.1 onwards.

## Input

| Item        | Format  | Description                                                                      |
|-------------|---------|----------------------------------------------------------------------------------|
| Connection  | String  | The connection ID. See [ConnectApp](xref:ConnectApp) . |
| DmaID       | Integer | The DataMiner Agent ID.                                                          |
| ElementID   | Integer | The element ID.                                                                  |
| ParameterID | Integer | The matrix parameter ID.                                                         |
| OutputLabel | String  | The label of the output.                                                         |

## Output

| Item                                 | Format                                                                                                     | Description                                                   |
|--------------------------------------|------------------------------------------------------------------------------------------------------------|---------------------------------------------------------------|
| GetMatrixInputsFor­OutputLabelResult | Array of DMAMatrixConnec­tion (See [DMAMatrixConnection](xref:DMAMatrixConnection)) | An array containing the connections for the specified output. |

