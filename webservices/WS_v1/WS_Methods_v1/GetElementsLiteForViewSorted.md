---
uid: GetElementsLiteForViewSorted
---

# GetElementsLiteForViewSorted

Use this method to retrieve a list of a number of elements from a specified view. Optionally, services and redundancy groups can also be included.

This method is a faster alternative to the method *GetElementsForViewSorted*, as it retrieves only basic information about the elements.

## Input

| Item | Format | Description |
|--|--|--|
| Connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| ViewID | Integer | The view ID. |
| IncludeSubViews | Boolean | Whether the subviews of the specified view should be included in the search. |
| IncludeServices | Boolean | Whether the services in the specified view should also be included. |
| includeRedundancy­Groups | Boolean | Whether the redundancy groups in the specified view should also be included. |
| StartsWith | String | If, in this field, you enter a piece of text, then the method will only return elements of which the name starts with that piece of text. |
| Query | String | If, in this field, you enter a piece of text, the method will only return items of which the protocol name or item name contains that piece of text. |
| Index | Integer | The point from which to start returning child items. |
| Count | Integer | The number of child items to be returned. |
| OrderBy | String | The field(s) by which to order the child items (separated by semicolons). |

## Output

| Item | Format | Description |
|--|--|--|
| GetElementsLiteFor­ViewSortedResult | Array of DMAElement­Lite (See [DMAElementLite](xref:DMAElementLite)) | A list with basic info about certain elements in the specified view. |
