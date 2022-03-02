---
uid: GetServicesForView
---

# GetServicesForView

Use this method to retrieve the data of all services in a particular view.

## Input

| Item            | Format  | Description                                                                      |
|-----------------|---------|----------------------------------------------------------------------------------|
| Connection      | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| ViewID          | Integer | The view ID.                                                                     |
| IncludeSubViews | Boolean | Indicates whether services from subviews are included.                           |

## Output

| Item | Format | Description |
|--|--|--|
| GetServicesFor­ViewResult | Array of [DMAElement](xref:DMAElement) | The data of the services in the specified view. |
