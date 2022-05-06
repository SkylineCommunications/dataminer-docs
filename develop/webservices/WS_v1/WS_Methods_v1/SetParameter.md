---
uid: SetParameter
---

# SetParameter

Use this method to update a particular parameter.

## Input

| Item           | Format  | Description                                                                                                 |
|----------------|---------|-------------------------------------------------------------------------------------------------------------|
| connection     | String  | The connection ID. See [ConnectApp](xref:ConnectApp).                            |
| dmaID          | Integer | The DataMiner Agent ID.                                                                                     |
| elementID      | Integer | The element ID.                                                                                             |
| parameterID    | Integer | The parameter ID.                                                                                           |
| tableIndex     | String  | The table index. This field must be specified for table column parameters; otherwise it must be left empty. |
| parameterValue | String  | The new value of the parameter.                                                                             |

## Output

None.
