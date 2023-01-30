---
uid: GetMaskedAlarmsForView
---

# GetMaskedAlarmsForView

Use this method to retrieve the list of all the masked alarms of a particular view.

## Input

| Item       | Format  | Description                                                                      |
|------------|---------|----------------------------------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| viewID     | Integer | The view ID.                                                                     |

## Output

| Item | Format | Description |
|--|--|--|
| GetMaskedAlarmsForViewResult | Array of [DMAAlarm](xref:DMAAlarm) | The list of all the masked alarms of the specified view. |
