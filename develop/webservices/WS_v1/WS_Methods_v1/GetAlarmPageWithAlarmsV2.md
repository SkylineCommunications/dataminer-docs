---
uid: GetAlarmPageWithAlarmsV2
---

# GetAlarmPageWithAlarmsV2

Use this method to retrieve the alarm page details, including limited alarms, along with the alarm cache status.

Available from DataMiner 10.0.7 onwards.

## Input

| Item             | Format | Description                                                                                                  |
|------------------|--------|--------------------------------------------------------------------------------------------------------------|
| Connection       | String | The connection ID. See [ConnectApp](xref:ConnectApp).                                                         |
| filter           | [DMAAlarmFilterV2](xref:DMAAlarmFilterV2)  | The filter that the alarms must match. |

## Output

| Item | Format | Description |
|--|--|--|
| GetAlarmPageWithAlarmsV2Result | Array of [DMAAlarm](xref:DMAAlarm) | The alarms matching the filter on the page, as well as the alarm cache status. |
