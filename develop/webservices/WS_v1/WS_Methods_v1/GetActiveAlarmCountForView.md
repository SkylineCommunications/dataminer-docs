---
uid: GetActiveAlarmCountForView
---

# GetActiveAlarmCountForView

Use this method to retrieve the number of active alarms for a particular view.

## Input

| Item       | Format  | Description                                          |
|------------|---------|------------------------------------------------------|
| Connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| ViewID     | Integer | The view ID.                                         |

## Output

| Item                             | Format            | Description                                               |
|----------------------------------|-------------------|-----------------------------------------------------------|
| GetActiveAlarmCountForViewResult | [DMAAlarmCountData](xref:DMAAlarmCountData) | An array listing the alarm count for each severity level. |
