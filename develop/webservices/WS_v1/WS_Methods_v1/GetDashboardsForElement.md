---
uid: GetDashboardsForElement
---

# GetDashboardsForElement

Use this method to retrieve the dashboards applicable for a specified element.

## Input

| Item       | Format  | Description                                          |
|------------|---------|------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                              |
| elementID  | Integer | The element ID.                                      |

## Output

| Item | Format | Description |
|--|--|--|
| GetDashboardsForElementResult | Array of [DMADashboard](xref:DMADashboard) | The dashboards applicable for the specified element. |
