---
uid: GetTableForParameterSorted
---

# GetTableForParameterSorted

Use this method to retrieve a specific number of rows from a table parameter.

> [!NOTE]
> Using this method, you can e.g. request table rows in batches in order to minimize loading time.

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID | Integer | The DataMiner Agent ID. |
| elementID | Integer | The element ID. |
| parameterID | Integer | The parameter ID. |
| includeCells | Boolean | If true, all column values will be included in the result. If false, only the primary key and the display key will be included. |
| index | Integer | The point from which to start returning table rows. |
| count | Integer | The number of table rows to be returned. |
| orderBy | String | The field(s) by which to order the table rows (separated by semicolons). |

## Output

| Item | Format | Description |
|--|--|--|
| GetTableForParameterSortedResult | Array of [DMAParameterTableRow](xref:DMAParameterTableRow) | The table rows for the specified parameter, sorted as requested. |
