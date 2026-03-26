---
uid: GetTableForParameterCached
---

# GetTableForParameterCached

Use this method to retrieve the rows from a table parameter added or changed since a particular point in time.

> [!NOTE]
> Using this method, you can e.g., request table rows in batches in order to minimize loading time.

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
| cacheDateUTC | Long integer | If you enter a timestamp in UTC format (milliseconds since midnight January 1, 1970 GMT), then the method will return only rows that were added or changed since that particular point in time. If you enter -1, there will be no date check. |

## Output

| Item | Format | Description |
|--|--|--|
| GetTableForParameterCachedResult | [DMACache](xref:DMACache) | The table rows added or changed since the specified point in time. |

> [!NOTE]
> In this case, the [DMACache](xref:DMACache) object will contain an array of [DMAParameterTableRow](xref:DMAParameterTableRow) objects.
