---
uid: GetInformationEventsSorted
---

# GetInformationEventsSorted

Use this method to retrieve the information events for a specified timespan, sorted according to a particular alarm state, start index and count filter, and ordered by a particular Alarm Console column.

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
| GetInformationEventsSortedResult | Array of [DMAAlarm](xref:DMAAlarm) | The information events for the indicated period, sorted as required. |
