---
uid: GetActiveAlarmCountForServiceV2
---

# GetActiveAlarmCountForServiceV2

Use this method to retrieves the number of active alarms on a service along with the alarm cache status.

Available from DataMiner 10.0.7 onwards.

## Input

| Item       | Format  | Description                                          |
|------------|---------|------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                              |
| serviceID  | Integer | The service ID.                                      |

## Output

| Item | Format | Description |
|--|--|--|
| GetActiveAlarmCountForServiceV2Result | DMAAlarmCountDataAndCacheStatus | An array listing the alarm count for each severity level, along with the alarm cache status. |
