---
uid: GetAlarmStateForViews
---

# GetAlarmStateForViews

Use this method to retrieve the current alarm states of a number of views.

## Input

| Item       | Format           | Description                                          |
|------------|------------------|------------------------------------------------------|
| Connection | String           | The connection ID. See [ConnectApp](xref:ConnectApp) . |
| ViewIDs    | Array of integer | The list of view IDs.                                |

## Output

| Item                         | Format          | Description                                      |
|------------------------------|-----------------|--------------------------------------------------|
| GetAlarmStateForViews­Result | Array of string | The current alarm states of the specified views. |

