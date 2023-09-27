---
uid: GetServicesForView
---

# GetServicesForView

Use this method to retrieve the data of all services in a particular view.

## Input

| Item            | Format  | Description                                                                      |
|-----------------|---------|----------------------------------------------------------------------------------|
| connection      | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| viewID          | Integer | The view ID.                                                                     |
| includeSubViews | Boolean | Indicates whether services from subviews are included.                           |

## Output

| Item | Format | Description |
|--|--|--|
| GetServicesForViewResult | Array of [DMAElement](xref:DMAElement) | The data of the services in the specified view. |
