---
uid: ConnectMatrixCrosspointForLabels
---

# ConnectMatrixCrosspointForLabels

Use this method to connect or disconnect a matrix crosspoint by specifying the input and output labels.

<!-- Available from DataMiner version 9.5.1 onwards. -->

## Input

| Item        | Format  | Description                                                    |
|-------------|---------|----------------------------------------------------------------|
| connection  | String  | The connection ID. See [ConnectApp](xref:ConnectApp).          |
| dmaID       | Integer | The DataMiner Agent ID.                                        |
| elementID   | Integer | The element ID.                                                |
| parameterID | Integer | The matrix parameter ID.                                       |
| inputLabel  | String  | The label of the input.                                        |
| outputLabel | String  | The label of the output.                                       |
| connect     | Boolean | Indicates whether the connection should be created or removed. |

## Output

None.
