---
uid: GetDashboardsForService
---

# GetDashboardsForService

Use this method to retrieve the dashboards applicable for a specified service.

## Input

| Item       | Format  | Description                                          |
|------------|---------|------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                              |
| serviceID  | Integer | The service ID.                                      |

## Output

| Item | Format | Description |
|--|--|--|
| GetDashboardsForServiceResult | Array of [DMADashboard](xref:DMADashboard) | The dashboards applicable for the specified service. |
