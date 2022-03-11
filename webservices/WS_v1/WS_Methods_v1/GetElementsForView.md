---
uid: GetElementsForView
---

# GetElementsForView

Use this method to retrieve the list of child items (elements and/or services) in a particular view.

## Input

| Item            | Format  | Description                                                        |
|-----------------|---------|--------------------------------------------------------------------|
| Connection      | String  | The connection ID. See [ConnectApp](xref:ConnectApp).               |
| ViewID          | Integer | The view ID.                                                       |
| IncludeSubViews | Boolean | Whether subviews of the specified view should be included in the search.  |
| IncludeServices | Boolean | Whether services in the specified view should also be included. |

## Output

| Item | Format | Description |
|--|--|--|
| GetElementsForView­Result | Array of [DMAElement](xref:DMAElement) | The list of all the child items in the specified view. |
