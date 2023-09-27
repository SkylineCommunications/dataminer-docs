---
uid: GetActiveAlarmsForElementV2
---

# GetActiveAlarmsForElementV2

Use this method to retrieve all the active alarms of a particular element along with the alarm cache status.

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
| GetActiveAlarmsForElementV2Result | Array of [DMAAlarm](xref:DMAAlarm) | The active alarms of the specified element, as well as the alarm cache status. |
