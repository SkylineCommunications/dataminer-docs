---
uid: GetActiveAlarmsForService
---

# GetActiveAlarmsForService

Use this method to retrieve all the active alarms of a particular service.

## Input

| Item       | Format  | Description                                          |
|------------|---------|------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                              |
| serviceID  | Integer | The service ID.                                      |

## Output

| Item | Format | Description |
|--|--|--|
| GetActiveAlarmsForServiceResult | Array of [DMAAlarm](xref:DMAAlarm) | The active alarms of the specified service. |
