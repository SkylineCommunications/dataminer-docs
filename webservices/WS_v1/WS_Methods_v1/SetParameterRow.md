---
uid: SetParameterRow
---

# SetParameterRow

Use this method to update a particular parameter row.

The advantage of using this method instead of *SetParameter* is that only one update is necessary to set all the new values of the row, instead of an update for each new value.

## Input

| Item             | Format  | Description                                                                      |
|------------------|---------|----------------------------------------------------------------------------------|
| Connection       | String  | The connection ID. See [ConnectApp](xref:ConnectApp) . |
| DmaID            | Integer | The DataMiner Agent ID.                                                          |
| ElementID        | Integer | The element ID.                                                                  |
| TableIndex       | String  | The table index.                                                                 |
| DMAParameterSets | Arry    | Array consisting of the column parameter IDs and the corresponding new values.   |

## Output

None.

