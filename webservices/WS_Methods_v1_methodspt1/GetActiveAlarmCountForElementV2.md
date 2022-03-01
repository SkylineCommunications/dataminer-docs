---
uid: GetActiveAlarmCountForElementV2
---

# GetActiveAlarmCountForElementV2

Use this method to retrieve the number of active alarms on an element along with the alarm cache status.

Available from DataMiner 10.0.7 onwards.

## Input

| Item       | Format  | Description                                          |
|------------|---------|------------------------------------------------------|
| Connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp) . |
| DmaID      | Integer | The DataMiner Agent ID.                              |
| ElementID  | Integer | The element ID.                                      |

## Output

| Item                                   | Format                           | Description                                                                                  |
|----------------------------------------|----------------------------------|----------------------------------------------------------------------------------------------|
| GetActiveAlarmCount­ForElementV2Result | DMAAlarmCountData­AndCacheStatus | An array listing the alarm count for each severity level, as well as the alarm cache status. |

