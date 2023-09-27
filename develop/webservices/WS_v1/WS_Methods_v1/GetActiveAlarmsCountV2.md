---
uid: GetActiveAlarmsCountV2
---

# GetActiveAlarmsCountV2

Use this method to retrieve the number of active alarms along with the alarm cache status.

Available from DataMiner 10.0.7 onwards.

## Input

| Item       | Format | Description                                          |
|------------|--------|------------------------------------------------------|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |

## Output

| Item                          | Format                       | Description                                                           |
|-------------------------------|------------------------------|-----------------------------------------------------------------------|
| GetActiveAlarmsCountV2Result | DMAAlarmCountAndCacheStatus | The total number of active alarms, as well as the alarm cache status. |
