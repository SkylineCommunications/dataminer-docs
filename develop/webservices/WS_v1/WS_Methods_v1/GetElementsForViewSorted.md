---
uid: GetElementsForViewSorted
---

# GetElementsForViewSorted

Use this method to retrieve a specific number of view child items (elements and/or services).

> [!NOTE]
> Using this method, you can e.g. request view child items in batches in order to minimize loading time.

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| viewID | Integer | The view ID. |
| includeSubViews | Boolean | Whether items in subviews should be included. |
| includeServices | Boolean | Whether services in the specified view should also be included. |
| startsWith | String | If, in this field, you enter a piece of text, then the method will only return view child items of which the name starts with that piece of text. |
| query | String | If, in this field, you enter a piece of text, then the method will only return view child items of which the protocol name or element name contains that piece of text. |
| index | Integer | The point from which to start returning child items. |
| count | Integer | The number of child items to be returned. |
| orderBy | String | The field(s) by which to order the child items (separated by semicolons). |

## Output

| Item | Format | Description |
|--|--|--|
| GetElementsForViewSortedResult | Array of [DMAElement](xref:DMAElement) | The child items in the specified view, sorted as requested. |
