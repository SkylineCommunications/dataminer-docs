---
uid: GetElementsForServiceSorted
---

# GetElementsForServiceSorted

Use this method to retrieve a specific number of service child items (elements and/or services).

> [!NOTE]
> Using this method, you can e.g. request service child items in batches in order to minimize loading time.

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID | Integer | The DataMiner Agent ID. |
| serviceID | Integer | The service ID. |
| includeServices | Boolean | Whether child services of the specified service should be included. |
| startsWith | String | If you enter a piece of text in this field, the method will only return service child items of which the name starts with that piece of text. |
| index | Integer | The point from which to start returning child items. |
| count | Integer | The number of child items to be returned. |
| orderBy | String | The field(s) by which to order the child items (separated by semicolons). |

## Output

| Item | Format | Description |
|--|--|--|
| GetElementsForServiceSortedResult | Array of [DMAElement](xref:DMAElement) | The requested number of service child items, sorted as specified. |
