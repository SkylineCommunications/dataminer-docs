---
uid: GetTableForParameter
---

# GetTableForParameter

Use this method to retrieve all the rows from a table parameter.

## Input

| Item | Format | Description |
|--|--|--|
| connection   | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID        | Integer | The DataMiner Agent ID. |
| elementID    | Integer | The element ID. |
| parameterID  | Integer | The parameter ID. |
| includeCells | Boolean | If true, all column values will be included in the result. If false, only the primary key and the display key will be included. |

## Output

| Item | Format | Description |
|--|--|--|
| GetTableForParameterResult | Array of [DMAParameterTableRow](xref:DMAParameterTableRow) | All the rows of the specified table parameter. |
