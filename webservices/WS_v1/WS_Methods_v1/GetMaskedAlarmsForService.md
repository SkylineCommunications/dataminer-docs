---
uid: GetMaskedAlarmsForService
---

# GetMaskedAlarmsForService

Use this method to retrieve the list of all the masked alarms of a particular service.

## Input

| Item       | Format  | Description                                                                      |
|------------|---------|----------------------------------------------------------------------------------|
| Connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp) . |
| DmaID      | Integer | The DataMiner Agent ID.                                                          |
| ServiceID  | Integer | The service ID.                                                                  |

## Output

| Item                             | Format                                                                   | Description                                                 |
|----------------------------------|--------------------------------------------------------------------------|-------------------------------------------------------------|
| GetMaskedAlarms­ForServiceResult | Array of DMAAlarm (see [DMAAlarm](xref:DMAAlarm)) | The list of all the masked alarms of the specified service. |

