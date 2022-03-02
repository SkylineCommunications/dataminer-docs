---
uid: GetMaskedAlarmsForServiceV2
---

# GetMaskedAlarmsForServiceV2

Use this method to retrieve the list of all the masked alarms of a particular service, as well as the alarm cache status.

Available from DataMiner 10.0.7 onwards.

## Input

| Item       | Format  | Description                                                                      |
|------------|---------|----------------------------------------------------------------------------------|
| Connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp) . |
| DmaID      | Integer | The DataMiner Agent ID.                                                          |
| ServiceID  | Integer | The service ID.                                                                  |

## Output

| Item                               | Format                                                                   | Description                                                                                    |
|------------------------------------|--------------------------------------------------------------------------|------------------------------------------------------------------------------------------------|
| GetMaskedAlarms­ForServiceV2Result | Array of DMAAlarm (see [DMAAlarm](xref:DMAAlarm)) | The list of all the masked alarms of the specified service, as well as the alarm cache status. |

