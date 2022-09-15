---
uid: GetActiveAlarmCountForElementV2
---

# GetActiveAlarmCountForElementV2

Use this method to retrieve the number of active alarms on an element along with the alarm cache status.

Available from DataMiner 10.0.7 onwards.

## Input

| Item       | Format  | Description                                          |
|------------|---------|------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                              |
| elementID  | Integer | The element ID.                                      |

## Output

| Item | Format | Description |
|--|--|--|
| GetActiveAlarmCountForElementV2Result | DMAAlarmCountDataAndCacheStatus | An array listing the alarm count for each severity level, as well as the alarm cache status. |
