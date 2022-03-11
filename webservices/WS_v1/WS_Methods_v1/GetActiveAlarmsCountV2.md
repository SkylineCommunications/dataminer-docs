---
uid: GetActiveAlarmsCountV2
---

# GetActiveAlarmsCountV2

Use this method to retrieve the number of active alarms along with the alarm cache status.

Available from DataMiner 10.0.7 onwards.

## Input

| Item       | Format | Description                                          |
|------------|--------|------------------------------------------------------|
| Connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |

## Output

| Item                          | Format                       | Description                                                           |
|-------------------------------|------------------------------|-----------------------------------------------------------------------|
| GetActiveAlarms­CountV2Result | DMAAlarmCountAnd­CacheStatus | The total number of active alarms, as well as the alarm cache status. |
