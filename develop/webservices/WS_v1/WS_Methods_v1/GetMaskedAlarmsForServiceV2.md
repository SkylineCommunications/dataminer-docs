---
uid: GetMaskedAlarmsForServiceV2
---

# GetMaskedAlarmsForServiceV2

Use this method to retrieve the list of all the masked alarms of a particular service, as well as the alarm cache status.

## Input

| Item       | Format  | Description                                           |
|------------|---------|-------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                               |
| serviceID  | Integer | The service ID.                                       |

## Output

| Item | Format | Description |
|--|--|--|
| GetMaskedAlarmsForServiceV2Result | Array of [DMAAlarm](xref:DMAAlarm) | The list of all the masked alarms of the specified service, as well as the alarm cache status. |
