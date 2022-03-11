---
uid: ConnectMatrixCrosspoint
---

# ConnectMatrixCrosspoint

Use this method to connect or disconnect a matrix crosspoint by specifying the (1-based) input and output indexes.

Available from DataMiner version 9.5.1 onwards.

## Input

| Item        | Format  | Description                                                    |
|-------------|---------|----------------------------------------------------------------|
| Connection  | String  | The connection ID. See [ConnectApp](xref:ConnectApp).          |
| DmaID       | Integer | The DataMiner Agent ID.                                        |
| ElementID   | Integer | The element ID.                                                |
| ParameterID | Integer | The matrix parameter ID.                                       |
| Input       | Integer | The input index (1-based).                                     |
| Output      | Integer | The output index (1-based).                                    |
| Connect     | Boolean | Indicates whether the connection should be created or removed. |

## Output

None.
