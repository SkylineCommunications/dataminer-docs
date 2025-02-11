---
uid: GetTableRowForParameter
---

# GetTableRowForParameter

Use this method to retrieve one specific row of a particular table parameter.

## Input

| Item        | Format  | Description                                           |
|-------------|---------|-------------------------------------------------------|
| connection  | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID       | Integer | The DataMiner Agent ID.                               |
| elementID   | Integer | The element ID.                                       |
| parameterID | Integer | The parameter ID.                                     |
| tableIndex  | String  | The table index.                                      |

## Output

| Item | Format | Description |
|--|--|--|
| GetTableRowForParameterResult | [DMAParameterTableRow](xref:DMAParameterTableRow) | The specified table parameter row. |
