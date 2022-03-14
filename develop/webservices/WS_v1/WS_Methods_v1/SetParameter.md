---
uid: SetParameter
---

# SetParameter

Use this method to update a particular parameter.

## Input

| Item           | Format  | Description                                                                                                 |
|----------------|---------|-------------------------------------------------------------------------------------------------------------|
| Connection     | String  | The connection ID. See [ConnectApp](xref:ConnectApp).                            |
| DmaID          | Integer | The DataMiner Agent ID.                                                                                     |
| ElementID      | Integer | The element ID.                                                                                             |
| ParameterID    | Integer | The parameter ID.                                                                                           |
| TableIndex     | String  | The table index. This field must be specified for table column parameters; otherwise it must be left empty. |
| ParameterValue | String  | The new value of the parameter.                                                                             |

## Output

None.
