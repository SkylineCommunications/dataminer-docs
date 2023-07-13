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

> [!NOTE]
> When you set the value of a date or datetime parameter, from DataMiner 10.3.8/10.4.0 onwards, you must pass the value as a Unix timestamp in milliseconds. In earlier DataMiner versions, the value must be passed as an OLE Automation date.

## Output

None.
