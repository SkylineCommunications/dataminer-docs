---
uid: GetMaskedAlarms
---

# GetMaskedAlarms

Use this method to retrieve the list of all the masked alarms.

## Input

| Item       | Format | Description                                          |
|------------|--------|------------------------------------------------------|
| Connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |

## Output

| Item | Format | Description |
|--|--|--|
| GetMaskedAlarmsResult | Array of [DMAAlarm](xref:DMAAlarm) | The list of all the masked alarms. |
