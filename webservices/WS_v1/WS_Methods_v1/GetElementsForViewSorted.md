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
| Connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| ViewID | Integer | The view ID. |
| IncludeSubViews | Boolean | Whether items in subviews should be included. |
| IncludeServices | Boolean | Whether services in the specified view should also be included. |
| StartsWith | String | If, in this field, you enter a piece of text, then the method will only return view child items of which the name starts with that piece of text. |
| Query | String | If, in this field, you enter a piece of text, then the method will only return view child items of which the protocol name or element name contains that piece of text. |
| Index | Integer | The point from which to start returning child items. |
| Count | Integer | The number of child items to be returned. |
| OrderBy | String | The field(s) by which to order the child items (separated by semicolons). |

## Output

| Item | Format | Description |
|--|--|--|
| GetElementsForView­SortedResult | Array of [DMAElement](xref:DMAElement) | The child items in the specified view, sorted as requested. |
