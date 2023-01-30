---
uid: GetActiveAlarmsForView
---

# GetActiveAlarmsForView

Use this method to retrieve all the active alarms of a particular view.

## Input

| Item       | Format  | Description                                          |
|------------|---------|------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| viewID     | Integer | The view ID.                                         |

## Output

| Item | Format | Description |
|--|--|--|
| GetActiveAlarmsForViewResult | Array of [DMAAlarm](xref:DMAAlarm) | The active alarms of the specified view. |
