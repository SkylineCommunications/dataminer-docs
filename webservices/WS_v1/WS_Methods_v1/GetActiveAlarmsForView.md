---
uid: GetActiveAlarmsForView
---

# GetActiveAlarmsForView

Use this method to retrieve all the active alarms of a particular view.

## Input

| Item       | Format  | Description                                          |
|------------|---------|------------------------------------------------------|
| Connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| ViewID     | Integer | The view ID.                                         |

## Output

| Item | Format | Description |
|--|--|--|
| GetActiveAlarmsFor­ViewResult | Array of [DMAAlarm](xref:DMAAlarm) | The active alarms of the specified view. |
