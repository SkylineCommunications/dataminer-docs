---
uid: GetAlarmsV2
---

# GetAlarmsV2

Retrieves a number of filtered alarms, along with the alarm cache status.

## Input

| Item             | Format | Description                                                               |
|------------------|--------|---------------------------------------------------------------------------|
| connection       | String | The connection ID. See [ConnectApp](xref:ConnectApp).                     |
| filter           | [DMAAlarmFilterV2](xref:DMAAlarmFilterV2) | The filter that the alarms must match. |

## Output

| Item | Format | Description |
|--|--|--|
| GetAlarmsResult | Array of [DMAAlarm](xref:DMAAlarm) | The alarms matching the specified filter object, as well as the alarm cache status. |
