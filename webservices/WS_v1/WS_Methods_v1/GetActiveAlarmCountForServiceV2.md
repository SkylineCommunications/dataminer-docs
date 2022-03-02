---
uid: GetActiveAlarmCountForServiceV2
---

# GetActiveAlarmCountForServiceV2

Use this method to retrieves the number of active alarms on a service along with the alarm cache status.

Available from DataMiner 10.0.7 onwards.

## Input

| Item       | Format  | Description                                          |
|------------|---------|------------------------------------------------------|
| Connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| DmaID      | Integer | The DataMiner Agent ID.                              |
| ServiceID  | Integer | The service ID.                                      |

## Output

| Item                                   | Format                           | Description                                                                                  |
|----------------------------------------|----------------------------------|----------------------------------------------------------------------------------------------|
| GetActiveAlarmCount­ForServiceV2Result | DMAAlarmCountData­AndCacheStatus | An array listing the alarm count for each severity level, along with the alarm cache status. |
