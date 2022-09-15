---
uid: GetDashboardsForView
---

# GetDashboardsForView

Use this method to retrieve the dashboards applicable for a specified view.

## Input

| Item       | Format  | Description                                          |
|------------|---------|------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| viewID     | Integer | The view ID.                                         |

## Output

| Item | Format | Description |
|--|--|--|
| GetDashboardsForViewResult | Array of [DMADashboard](xref:DMADashboard) | The dashboards applicable for the specified view. |
