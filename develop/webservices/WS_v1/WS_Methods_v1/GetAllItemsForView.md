---
uid: GetAllItemsForView
---

# GetAllItemsForView

Use this method to retrieve all items (elements, services, service templates, redundancy groups or redundancy group templates) for the specified view.

## Input

| Item            | Format  | Description                                          |
|-----------------|---------|------------------------------------------------------|
| connection      | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| viewID          | Integer | The ID of the view.                                  |
| includeSubViews | Boolean | Indicates whether subviews should be included.       |

## Output

| Item | Format | Description |
|--|--|--|
| GetAllItemsForViewResult | Array of [DMAElement](xref:DMAElement) | The information regarding the items present in the view. For services/service templates or redundancy groups/redundancy group templates, the type property of the DMAElement object is “service” or “redundancy group” respectively. |
