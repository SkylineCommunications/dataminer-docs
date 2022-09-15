---
uid: GetActiveAlarmsForServiceV2
---

# GetActiveAlarmsForServiceV2

Use this method to retrieve all the active alarms of a particular service along with the alarm cache status.

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
| GetActiveAlarmsForServiceV2Result | Array of [DMAAlarm](xref:DMAAlarm) | The active alarms of the specified service, as well as the alarm cache status. |
