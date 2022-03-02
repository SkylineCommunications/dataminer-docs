---
uid: GetAllItemsForView
---

# GetAllItemsForView

Use this method to retrieve all items (elements, services, service templates, redundancy groups or redundancy group templates) for the specified view.

## Input

| Item            | Format  | Description                                          |
|-----------------|---------|------------------------------------------------------|
| Connection      | String  | The connection ID. See [ConnectApp](xref:ConnectApp) . |
| ViewID          | Integer | The ID of the view.                                  |
| IncludeSubViews | Boolean | Indicates whether subviews should be included.       |

## Output

| Item                      | Format                                                                                 | Description                                                                                                                                                                                                                              |
|---------------------------|----------------------------------------------------------------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| GetAllItemsForView­Result | Array of DMAElement objects (see [DMAElement](xref:DMAElement)) | The information regarding the items present in the view.<br> For services/service templates or redundancy groups/redundancy group templates, the type property of the DMAElement object is “service” or “redundancy group” respectively. |

