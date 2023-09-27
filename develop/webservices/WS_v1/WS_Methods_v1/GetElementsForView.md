---
uid: GetElementsForView
---

# GetElementsForView

Use this method to retrieve the list of child items (elements and/or services) in a particular view.

## Input

| Item            | Format  | Description                                                        |
|-----------------|---------|--------------------------------------------------------------------|
| connection      | String  | The connection ID. See [ConnectApp](xref:ConnectApp).               |
| viewID          | Integer | The view ID.                                                       |
| includeSubViews | Boolean | Whether subviews of the specified view should be included in the search.  |
| includeServices | Boolean | Whether services in the specified view should also be included. |

## Output

| Item | Format | Description |
|--|--|--|
| GetElementsForViewResult | Array of [DMAElement](xref:DMAElement) | The list of all the child items in the specified view. |
