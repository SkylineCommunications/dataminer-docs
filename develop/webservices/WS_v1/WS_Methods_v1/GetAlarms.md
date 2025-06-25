---
uid: GetAlarms
---

# GetAlarms

Use this method to retrieve alarms matching a DMAAlarmFilterV2 object.

<!-- Available from DataMiner 9.5.6 onwards. -->

## Input

| Item             | Format | Description                                                               |
|------------------|--------|---------------------------------------------------------------------------|
| connection       | String | The connection ID. See [ConnectApp](xref:ConnectApp).                     |
| filter           | [DMAAlarmFilterV2](xref:DMAAlarmFilterV2) | The filter that the alarms must match. |

## Output

| Item | Format | Description |
|--|--|--|
| GetAlarmsResult | Array of [DMAAlarm](xref:DMAAlarm) | The alarms matching the specified filter object. |
