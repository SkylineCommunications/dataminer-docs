---
uid: GetActiveAlarmsForService
---

# GetActiveAlarmsForService

Use this method to retrieve all the active alarms of a particular service.

## Input

| Item       | Format  | Description                                          |
|------------|---------|------------------------------------------------------|
| Connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp) . |
| DmaID      | Integer | The DataMiner Agent ID.                              |
| ServiceID  | Integer | The service ID.                                      |

## Output

| Item                             | Format                                                                   | Description                                 |
|----------------------------------|--------------------------------------------------------------------------|---------------------------------------------|
| GetActiveAlarmsFor­ServiceResult | Array of DMAAlarm (see [DMAAlarm](xref:DMAAlarm)) | The active alarms of the specified service. |

