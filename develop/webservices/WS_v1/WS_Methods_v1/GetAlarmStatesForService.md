---
uid: GetAlarmStatesForService
---

# GetAlarmStatesForService

Use this method to retrieve the relative duration (in percent) of every alarm severity for the specified service during the specified timespan (available from DataMiner 9.5.8 onwards).

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID | Integer | The DataMiner Agent ID. |
| serviceID | Integer | The service ID. |
| utcStartTime | Long integer | The start time of the timespan for which the alarm states should be retrieved, in UTC format (milliseconds since midnight January 1, 1970 GMT). |
| utcEndTime | Long integer | The end time of the timespan for which the alarm states should be retrieved, in UTC format (milliseconds since midnight January 1, 1970 GMT). |

## Output

| Item | Format | Description |
|--|--|--|
| GetAlarmStatesForServiceResult | [DMAAlarmStateData](xref:DMAAlarmStateData) | An array listing the relative duration of each alarm state. |
