---
uid: GetElementsLiteForView
---

# GetElementsLiteForView

Use this method to retrieve a list of all the elements from a specified view. Optionally, services and redundancy groups can also be included.

This method is a faster alternative to the method *GetElementsForView*, as it retrieves only basic information about the elements. See [GetElementsForView](xref:GetElementsForView).

## Input

| Item                     | Format  | Description                                                                 |
|--------------------------|---------|-----------------------------------------------------------------------------|
| Connection               | String  | The connection ID. See [ConnectApp](xref:ConnectApp).                      |
| ViewID                   | Integer | The view ID.                                                                |
| IncludeSubViews          | Boolean | Whether the subviews of the specified view should be included in the search. |
| IncludeServices          | Boolean | Whether the services in the specified view should also be included.          |
| includeRedundancy­Groups | Boolean | Whether the redundancy groups in the specified view should also be included. |

## Output

| Item | Format | Description |
|--|--|--|
| GetElementsLiteFor­ViewResult | Array of DMAElement­Lite (See [DMAElementLite](xref:DMAElementLite)) | A list with basic info about all the elements in the specified view. |
