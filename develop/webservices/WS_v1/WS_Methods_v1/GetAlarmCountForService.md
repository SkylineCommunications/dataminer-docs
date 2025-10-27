---
uid: GetAlarmCountForService
---

# GetAlarmCountForService

Use this method to retrieve the number of alarms for every alarm severity for the specified service during the specified timespan.

<!-- Available from DataMiner 9.5.8 onwards. -->

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID | Integer | The DataMiner Agent ID. |
| serviceID | Integer | The service ID. |
| utcStartTime | Long integer | The start time of the timespan for which the alarm count should be retrieved, in UTC format (milliseconds since midnight January 1, 1970 GMT). |
| utcEndTime | Long integer | The end time of the timespan for which the alarm count should be retrieved, in UTC format (milliseconds since midnight January 1, 1970 GMT). |

## Output

| Item | Format | Description |
|--|--|--|
| GetAlarmCountForServiceResult | [DMAAlarmCountData](xref:DMAAlarmCountData) | An array listing the alarm count for each severity level. |
