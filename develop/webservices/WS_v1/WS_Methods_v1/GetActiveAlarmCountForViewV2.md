---
uid: GetActiveAlarmCountForViewV2
---

# GetActiveAlarmCountForViewV2

Use this method to retrieve the number of active alarms on a view along with the alarm cache status.

Available from DataMiner 10.0.7 onwards.

## Input

| Item       | Format  | Description                                          |
|------------|---------|------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| viewID     | Integer | The view ID.                                         |

## Output

| Item | Format | Description |
|--|--|--|
| GetActiveAlarmCountForViewResult | DMAAlarmCountDataAndCacheStatus | An array listing the alarm count for each severity level, along with the alarm cache status. |
