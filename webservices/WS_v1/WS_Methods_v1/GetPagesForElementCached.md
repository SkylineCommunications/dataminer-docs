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
| Connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| DmaID | Integer | The DataMiner Agent ID. |
| ElementID | Integer | The element ID. |
| Index | Integer | The point from which to start returning Data Display pages. |
| Count | Integer | The number of Data Display pages to be returned. |
| OrderBy | String | The field(s) by which to order the Data Display pages (separated by semicolons). |
| CacheDateUTC | Long integer | If you enter a timestamp in UTC format (milliseconds since midnight January 1, 1970 GMT), then the method will return only Data Display pages that were added or changed since that particular point in time. If you enter -1, there will be no date check. |

## Output

| Item | Format | Description |
|--|--|--|
| GetPagesForElement­CachedResult | [DMACache](xref:DMACache) | The Data Display pages added or changed since the specified point in time. |

> [!NOTE]
> In this case, the DMACache object (see [DMACache](xref:DMACache)) will contain an array of DMAElementPage objects (see [DMAElementPage](xref:DMAElementPage)).
