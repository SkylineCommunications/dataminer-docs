---
uid: GetTableRowForParameter
---

# GetTableRowForParameter

Use this method to retrieve one specific row of a particular table parameter.

## Input

| Item        | Format  | Description                                                                      |
|-------------|---------|----------------------------------------------------------------------------------|
| Connection  | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| DmaID       | Integer | The DataMiner Agent ID.                                                          |
| ElementID   | Integer | The element ID.                                                                  |
| ParameterID | Integer | The parameter ID.                                                                |
| TableIndex  | String  | The table index.                                                                 |

## Output

| Item | Format | Description |
|--|--|--|
| GetTableRowForParameterResult | [DMAParameterTableRow](xref:DMAParameterTableRow) | The specified table parameter row. |
