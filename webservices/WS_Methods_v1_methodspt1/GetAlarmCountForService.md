---
uid: GetAlarmCountForService
---

# GetAlarmCountForService

Use this method to retrieve the number of alarms for every alarm severity for the specified service during the specified timespan (available from DataMiner 9.5.8 onwards).

## Input

| Item         | Format       | Description                                                                                                                                    |
|--------------|--------------|------------------------------------------------------------------------------------------------------------------------------------------------|
| Connection   | String       | The connection ID. See [ConnectApp](xref:ConnectApp) .                                                                                           |
| DmaID        | Integer      | The DataMiner Agent ID.                                                                                                                        |
| ServiceID    | Integer      | The service ID.                                                                                                                                |
| UtcStartTime | Long integer | The start time of the timespan for which the alarm count should be retrieved, in UTC format (milliseconds since midnight January 1, 1970 GMT). |
| UtcEndTime   | Long integer | The end time of the timespan for which the alarm count should be retrieved, in UTC format (milliseconds since midnight January 1, 1970 GMT).   |

## Output

| Item                           | Format            | Description                                               |
|--------------------------------|-------------------|-----------------------------------------------------------|
| GetAlarmCountForSer­viceResult | DMAAlarmCountData | An array listing the alarm count for each severity level. |

