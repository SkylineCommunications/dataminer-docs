---
uid: GetElementsForView
---

# GetElementsForView

Use this method to retrieve the list of child items (elements and/or services) in a particular view.

## Input

| Item            | Format  | Description                                                        |
|-----------------|---------|--------------------------------------------------------------------|
| Connection      | String  | The connection ID. See [ConnectApp](xref:ConnectApp) .               |
| ViewID          | Integer | The view ID.                                                       |
| IncludeSubViews | Boolean | Whether or not to also search the subviews of the specified view.  |
| IncludeServices | Boolean | Whether or not to also include the services in the specified view. |

## Output

| Item                      | Format                                                                         | Description                                            |
|---------------------------|--------------------------------------------------------------------------------|--------------------------------------------------------|
| GetElementsForView­Result | Array of DMAElement (see [DMAElement](xref:DMAElement)) | The list of all the child items in the specified view. |

