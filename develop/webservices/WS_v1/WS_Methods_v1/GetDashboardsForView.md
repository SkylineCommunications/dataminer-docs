---
uid: GetDashboardsForView
---

# GetDashboardsForView

Use this method to retrieve the dashboards applicable for a specified view.

## Input

| Item       | Format  | Description                                          |
|------------|---------|------------------------------------------------------|
| Connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| ViewID     | Integer | The view ID.                                         |

## Output

| Item | Format | Description |
|--|--|--|
| GetDashboardsFor­ViewResult | Array of [DMADashboard](xref:DMADashboard) | The dashboards applicable for the specified view. |
