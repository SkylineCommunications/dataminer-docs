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

## Output

None.
