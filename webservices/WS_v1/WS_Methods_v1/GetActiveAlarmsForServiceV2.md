---
uid: GetActiveAlarmsForServiceV2
---

# GetActiveAlarmsForServiceV2

Use this method to retrieve all the active alarms of a particular service along with the alarm cache status.

Available from DataMiner 10.0.7 onwards.

## Input

| Item       | Format  | Description                                          |
|------------|---------|------------------------------------------------------|
| Connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| DmaID      | Integer | The DataMiner Agent ID.                              |
| ServiceID  | Integer | The service ID.                                      |

## Output

| Item | Format | Description |
|--|--|--|
| GetActiveAlarmsFor­ServiceV2Result | Array of [DMAAlarm](xref:DMAAlarm) | The active alarms of the specified service, as well as the alarm cache status. |
