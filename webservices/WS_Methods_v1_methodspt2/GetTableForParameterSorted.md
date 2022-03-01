---
uid: GetTableForParameterSorted
---

# GetTableForParameterSorted

Use this method to retrieve a specific number of rows from a table parameter.

> [!NOTE]
> Using this method, you can e.g. request table rows in batches in order to minimize loading time.

## Input

| Item         | Format  | Description                                                                                                                     |
|--------------|---------|---------------------------------------------------------------------------------------------------------------------------------|
| Connection   | String  | The connection ID. See [ConnectApp](xref:ConnectApp) .                                                |
| DmaID        | Integer | The DataMiner Agent ID.                                                                                                         |
| ElementID    | Integer | The element ID.                                                                                                                 |
| ParameterID  | Integer | The parameter ID.                                                                                                               |
| IncludeCells | Boolean | If true, all column values will be included in the result. If false, only the primary key and the display key will be included. |
| Index        | Integer | The point from which to start returning table rows.                                                                             |
| Count        | Integer | The number of table rows to be returned.                                                                                        |
| OrderBy      | String  | The field(s) by which to order the table rows (separated by semicolons).                                                        |

## Output

| Item                              | Format                                                                                                        | Description                                                      |
|-----------------------------------|---------------------------------------------------------------------------------------------------------------|------------------------------------------------------------------|
| GetTableForParameter­SortedResult | Array of DMAParameter­TableRow (see [DMAParameterTableRow](xref:DMAParameterTableRow)) | The table rows for the specified parameter, sorted as requested. |

