---
uid: GetDashboardsForElement
---

# GetDashboardsForElement

Use this method to retrieve the dashboards applicable for a specified element.

## Input

| Item       | Format  | Description                                          |
|------------|---------|------------------------------------------------------|
| Connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| DmaID      | Integer | The DataMiner Agent ID.                              |
| ElementID  | Integer | The element ID.                                      |

## Output

| Item | Format | Description |
|--|--|--|
| GetDashboardsFor­ElementResult | Array of DMADashboard (see [DMADashboard](xref:DMADashboard)) | The dashboards applicable for the specified element. |
