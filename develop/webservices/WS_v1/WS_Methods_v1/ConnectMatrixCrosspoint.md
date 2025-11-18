---
uid: ConnectMatrixCrosspoint
---

# ConnectMatrixCrosspoint

Use this method to connect or disconnect a matrix crosspoint by specifying the (1-based) input and output indexes.

## Input

| Item        | Format  | Description                                                    |
|-------------|---------|----------------------------------------------------------------|
| connection  | String  | The connection ID. See [ConnectApp](xref:ConnectApp).          |
| dmaID       | Integer | The DataMiner Agent ID.                                        |
| elementID   | Integer | The element ID.                                                |
| parameterID | Integer | The matrix parameter ID.                                       |
| input       | Integer | The input index (1-based).                                     |
| output      | Integer | The output index (1-based).                                    |
| connect     | Boolean | Indicates whether the connection should be created or removed. |

## Output

None.
