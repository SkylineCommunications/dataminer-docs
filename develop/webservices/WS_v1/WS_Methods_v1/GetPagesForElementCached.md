---
uid: GetPagesForElementCached
---

# GetPagesForElementCached

Use this method to retrieve the Data Display pages of a particular element added or changed since a particular point in time.

> [!NOTE]
> Using this method, you can e.g. request Data Display pages in batches in order to minimize loading time.

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID | Integer | The DataMiner Agent ID. |
| elementID | Integer | The element ID. |
| index | Integer | The point from which to start returning Data Display pages. |
| count | Integer | The number of Data Display pages to be returned. |
| orderBy | String | The field(s) by which to order the Data Display pages (separated by semicolons). |
| cacheDateUTC | Long integer | If you enter a timestamp in UTC format (milliseconds since midnight January 1, 1970 GMT), then the method will return only Data Display pages that were added or changed since that particular point in time. If you enter -1, there will be no date check. |

## Output

| Item | Format | Description |
|--|--|--|
| GetPagesForElementCachedResult | [DMACache](xref:DMACache) | The Data Display pages added or changed since the specified point in time. |

> [!NOTE]
> In this case, the [DMACache](xref:DMACache) object will contain an array of [DMAElementPage](xref:DMAElementPage) objects.
