---
uid: GetElementsLiteForView
---

# GetElementsLiteForView

Use this method to retrieve a list of all the elements from a specified view. Optionally, services and redundancy groups can also be included.

This method is a faster alternative to the method *GetElementsForView*, as it retrieves only basic information about the elements. See [GetElementsForView](xref:GetElementsForView).

## Input

| Item                     | Format  | Description                                                                 |
|--------------------------|---------|-----------------------------------------------------------------------------|
| Connection               | String  | The connection ID. See [ConnectApp](xref:ConnectApp) .                        |
| ViewID                   | Integer | The view ID.                                                                |
| IncludeSubViews          | Boolean | Whether or not to also search the subviews of the specified view.           |
| IncludeServices          | Boolean | Whether or not to also include the services in the specified view.          |
| includeRedundancy­Groups | Boolean | Whether or not to also include the redundancy groups in the specified view. |

## Output

| Item                          | Format                                                                                      | Description                                                          |
|-------------------------------|---------------------------------------------------------------------------------------------|----------------------------------------------------------------------|
| GetElementsLiteFor­ViewResult | Array of DMAElement­Lite (See [DMAElementLite](xref:DMAElementLite)) | A list with basic info about all the elements in the specified view. |

