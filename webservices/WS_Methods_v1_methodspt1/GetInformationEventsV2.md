---
uid: GetInformationEventsV2
---

# GetInformationEventsV2

Use this method to retrieve the information events for a specified timespan, as well as the alarm cache status.

Available from DataMiner 10.0.7 onwards.

## Input

| Item         | Format       | Description                                                              |
|--------------|--------------|--------------------------------------------------------------------------|
| Connection   | String       | The connection ID. See [ConnectApp](xref:ConnectApp) .                     |
| UtcStartTime | Long integer | The start time of the period for which information events are retrieved. |
| UtcEndTime   | Long integer | The end time of the period for which information events are retrieved.   |

## Output

| Item                          | Format                                                                   | Description                                                                         |
|-------------------------------|--------------------------------------------------------------------------|-------------------------------------------------------------------------------------|
| GetInformationEvents­V2Result | Array of DMAAlarm (see [DMAAlarm](xref:DMAAlarm)) | The information events for the indicated period, as well as the alarm cache status. |

