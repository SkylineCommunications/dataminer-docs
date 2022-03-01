---
uid: GetInformationEventsSorted
---

# GetInformationEventsSorted

Use this method to retrieve the information events for a specified timespan, sorted according to a particular alarm state, start index and count filter, and ordered by a particular Alarm Console column.

## Input

| Item         | Format       | Description                                                                                     |
|--------------|--------------|-------------------------------------------------------------------------------------------------|
| Connection   | String       | The connection ID. See [ConnectApp](xref:ConnectApp) .                                            |
| UtcStartTime | Long integer | The start time of the period for which information events are retrieved.                        |
| UtcEndTime   | Long integer | The end time of the period for which information events are retrieved.                          |
| Index        | Integer      | The point from which to start returning information events.                                     |
| Count        | Integer      | The number of information events to be returned.                                                |
| OrderBy      | String       | The Alarm Console column(s) by which to order the information events (separated by semicolons). |

## Output

| Item                              | Format                                                                   | Description                                                          |
|-----------------------------------|--------------------------------------------------------------------------|----------------------------------------------------------------------|
| GetInformationEvents­SortedResult | Array of DMAAlarm (see [DMAAlarm](xref:DMAAlarm)) | The information events for the indicated period, sorted as required. |

