---
uid: GetInformationEventsSortedV2
---

# GetInformationEventsSortedV2

Use this method to retrieve the information events for a specified timespan, sorted according to a particular alarm state, start index, count filter and orderBy, as well as the alarm cache status.

Available from DataMiner 10.0.7 onwards.

## Input

| Item         | Format       | Description                                                                                     |
|--------------|--------------|-------------------------------------------------------------------------------------------------|
| connection   | String       | The connection ID. See [ConnectApp](xref:ConnectApp).                                           |
| utcStartTime | Long integer | The start time of the period for which information events are retrieved.                        |
| utcEndTime   | Long integer | The end time of the period for which information events are retrieved.                          |
| index        | Integer      | The point from which to start returning information events.                                     |
| count        | Integer      | The number of information events to be returned.                                                |
| orderBy      | String       | The Alarm Console column(s) by which to order the information events (separated by semicolons). |

## Output

| Item | Format | Description |
|--|--|--|
| GetInformationEventsSortedV2Result | Array of [DMAAlarm](xref:DMAAlarm) | The information events for the indicated period, sorted as required, as well as the alarm cache status. |
