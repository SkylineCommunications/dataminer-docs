---
uid: GetMaskedAlarmsV2
---

# GetMaskedAlarmsV2

Use this method to retrieve the list of all the masked alarms, as well as the alarm cache status.

## Input

| Item       | Format | Description                                           |
|------------|--------|-------------------------------------------------------|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |

## Output

| Item | Format | Description |
|--|--|--|
| GetMaskedAlarmsV2Result | Array of [DMAAlarm](xref:DMAAlarm) | The list of all the masked alarms, as well as the alarm cache status. |
