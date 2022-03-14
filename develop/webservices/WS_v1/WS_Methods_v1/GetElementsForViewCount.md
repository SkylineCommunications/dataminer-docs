---
uid: GetElementsForViewCount
---

# GetElementsForViewCount

Use this method to count the number of child items (elements and/or services) in a particular view.

## Input

| Item            | Format  | Description                                                        |
|-----------------|---------|--------------------------------------------------------------------|
| Connection      | String  | The connection ID. See [ConnectApp](xref:ConnectApp).               |
| ViewID          | Integer | The view ID.                                                       |
| IncludeSubViews | Boolean | Whether the subviews of the specified view should be included in the search.  |
| IncludeServices | Boolean | Whether the services in the specified view should be included. |

## Output

| Item                           | Format  | Description                                      |
|--------------------------------|---------|--------------------------------------------------|
| GetElementsForView­CountResult | Integer | The number of child items in the specified view. |
