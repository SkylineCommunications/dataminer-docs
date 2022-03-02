---
uid: GetTableForParameterCached
---

# GetTableForParameterCached

Use this method to retrieve the rows from a table parameter added or changed since a particular point in time.

> [!NOTE]
> Using this method, you can e.g. request table rows in batches in order to minimize loading time.

## Input

| Item | Format | Description |
|--|--|--|
| Connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| DmaID | Integer | The DataMiner Agent ID. |
| ElementID | Integer | The element ID. |
| ParameterID | Integer | The parameter ID. |
| IncludeCells | Boolean | If true, all column values will be included in the result. If false, only the primary key and the display key will be included. |
| Index | Integer | The point from which to start returning table rows. |
| Count | Integer | The number of table rows to be returned. |
| OrderBy | String | The field(s) by which to order the table rows (separated by semicolons). |
| CacheDateUTC | Long integer | If you enter a timestamp in UTC format (milliseconds since midnight January 1, 1970 GMT), then the method will return only rows that were added or changed since that particular point in time. If you enter -1, there will be no date check. |

## Output

| Item | Format | Description |
|--|--|--|
| GetTableForParameterCachedResult | [DMACache](xref:DMACache) | The table rows added or changed since the specified point in time. |

> [!NOTE]
> In this case, the DMACache object (see [DMACache](xref:DMACache)) will contain an array of DMAParameterTableRow objects (see [DMAParameterTableRow](xref:DMAParameterTableRow)).
