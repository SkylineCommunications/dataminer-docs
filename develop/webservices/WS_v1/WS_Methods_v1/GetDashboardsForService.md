---
uid: GetDashboardsForService
---

# GetDashboardsForService

Use this method to retrieve the dashboards applicable for a specified service.

## Input

| Item       | Format  | Description                                          |
|------------|---------|------------------------------------------------------|
| Connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| DmaID      | Integer | The DataMiner Agent ID.                              |
| ServiceID  | Integer | The service ID.                                      |

## Output

| Item | Format | Description |
|--|--|--|
| GetDashboardsFor­ServiceResult | Array of [DMADashboard](xref:DMADashboard) | The dashboards applicable for the specified service. |
