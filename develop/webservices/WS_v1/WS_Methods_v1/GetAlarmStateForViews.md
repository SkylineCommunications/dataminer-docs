---
uid: GetAlarmStateForViews
---

# GetAlarmStateForViews

Use this method to retrieve the current alarm states of a number of views.

## Input

| Item       | Format           | Description                                          |
|------------|------------------|------------------------------------------------------|
| connection | String           | The connection ID. See [ConnectApp](xref:ConnectApp). |
| viewIDs    | Array of integer | The list of view IDs.                                |

## Output

| Item                         | Format          | Description                                      |
|------------------------------|-----------------|--------------------------------------------------|
| GetAlarmStateForViewsResult | Array of string | The current alarm states of the specified views. |
