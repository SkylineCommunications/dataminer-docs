---
uid: GetElementsLiteForViewSorted
---

# GetElementsLiteForViewSorted

Use this method to retrieve a list of a number of elements from a specified view. Optionally, services and redundancy groups can also be included.

This method is a faster alternative to the method [GetElementsForViewSorted](xref:GetElementsForViewSorted), as it retrieves only basic information about the elements.

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| viewID | Integer | The view ID. |
| includeSubViews | Boolean | Whether the subviews of the specified view should be included in the search. |
| includeServices | Boolean | Whether the services in the specified view should also be included. |
| includeRedundancyGroups | Boolean | Whether the redundancy groups in the specified view should also be included. |
| startsWith | String | If, in this field, you enter a piece of text, then the method will only return elements of which the name starts with that piece of text. |
| query | String | If, in this field, you enter a piece of text, the method will only return items of which the protocol name or item name contains that piece of text. |
| index | Integer | The point from which to start returning child items. |
| count | Integer | The number of child items to be returned. |
| orderBy | String | The field(s) by which to order the child items (separated by semicolons). |

## Output

| Item | Format | Description |
|--|--|--|
| GetElementsLiteForViewSortedResult | Array of [DMAElementLite](xref:DMAElementLite) | A list with basic info about certain elements in the specified view. |
