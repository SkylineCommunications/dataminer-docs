---
uid: SetParameterRow
---

# SetParameterRow

Use this method to update a particular parameter row.

The advantage of using this method instead of *SetParameter* is that only one update is necessary to set all the new values of the row, instead of an update for each new value.

## Input

| Item             | Format  | Description                                                                      |
|------------------|---------|----------------------------------------------------------------------------------|
| connection       | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID            | Integer | The DataMiner Agent ID.                                                          |
| elementID        | Integer | The element ID.                                                                  |
| tableIndex       | String  | The table index.                                                                 |
| parameterSets    | DMAParameterSets | Array consisting of the column parameter IDs and the corresponding new values. |

> [!NOTE]
> When you set the value of a date or datetime parameter, from DataMiner 10.3.8/10.4.0 onwards, you must pass the value as a Unix timestamp in milliseconds. In earlier DataMiner versions, the value must be passed as an OLE Automation date.

## Output

None.
