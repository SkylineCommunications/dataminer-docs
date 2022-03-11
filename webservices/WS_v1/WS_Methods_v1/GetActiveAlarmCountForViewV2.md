---
uid: GetActiveAlarmCountForViewV2
---

# GetActiveAlarmCountForViewV2

Use this method to retrieve the number of active alarms on a view along with the alarm cache status.

Available from DataMiner 10.0.7 onwards.

## Input

| Item       | Format  | Description                                          |
|------------|---------|------------------------------------------------------|
| Connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| ViewID     | Integer | The view ID.                                         |

## Output

| Item                             | Format                           | Description                                                                                  |
|----------------------------------|----------------------------------|----------------------------------------------------------------------------------------------|
| GetActiveAlarmCountForViewResult | DMAAlarmCountData­AndCacheStatus | An array listing the alarm count for each severity level, along with the alarm cache status. |
