---
uid: GetElementsForViewCount
---

# GetElementsForViewCount

Use this method to count the number of child items (elements and/or services) in a particular view.

## Input

| Item            | Format  | Description                                                        |
|-----------------|---------|--------------------------------------------------------------------|
| connection      | String  | The connection ID. See [ConnectApp](xref:ConnectApp).               |
| viewID          | Integer | The view ID.                                                       |
| includeSubViews | Boolean | Whether the subviews of the specified view should be included in the search.  |
| includeServices | Boolean | Whether the services in the specified view should be included. |

## Output

| Item                           | Format  | Description                                      |
|--------------------------------|---------|--------------------------------------------------|
| GetElementsForViewCountResult | Integer | The number of child items in the specified view. |
