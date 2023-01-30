---
uid: GetElementsLiteForView
---

# GetElementsLiteForView

Use this method to retrieve a list of all the elements from a specified view. Optionally, services and redundancy groups can also be included.

This method is a faster alternative to the method [GetElementsForView](xref:GetElementsForView), as it retrieves only basic information about the elements.

## Input

| Item                     | Format  | Description                                                                 |
|--------------------------|---------|-----------------------------------------------------------------------------|
| connection               | String  | The connection ID. See [ConnectApp](xref:ConnectApp).                      |
| viewID                   | Integer | The view ID.                                                                |
| includeSubViews          | Boolean | Whether the subviews of the specified view should be included in the search. |
| includeServices          | Boolean | Whether the services in the specified view should also be included.          |
| includeRedundancyGroups | Boolean | Whether the redundancy groups in the specified view should also be included. |

## Output

| Item | Format | Description |
|--|--|--|
| GetElementsLiteForViewResult | Array of [DMAElementLite](xref:DMAElementLite) | A list with basic info about all the elements in the specified view. |
