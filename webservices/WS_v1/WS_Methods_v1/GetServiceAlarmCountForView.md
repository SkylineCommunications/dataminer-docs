---
uid: GetServiceAlarmCountForView
---

# GetServiceAlarmCountForView

Use this method to retrieve the services with the largest/smallest number of alarms for each alarm severity for the specified view.

## Input

| Item         | Format       | Description                                                                                                                                    |
|--------------|--------------|------------------------------------------------------------------------------------------------------------------------------------------------|
| Connection   | String       | The connection ID. See [ConnectApp](xref:ConnectApp) .                                                               |
| ViewID       | Integer      | The view ID.                                                                                                                                   |
| Limit        | Integer      | The number of services with the most/least alarms that should be retrieved.                                                                    |
| SortASC      | Boolean      | Indicates whether the services with the largest or the smallest number of alarms should be retrieved.                                          |
| UtcStartTime | Long integer | The start time of the timespan for which the alarm count should be retrieved, in UTC format (milliseconds since midnight January 1, 1970 GMT). |
| UtcEndTime   | Long integer | The end time of the timespan for which the alarm count should be retrieved, in UTC format (milliseconds since midnight January 1, 1970 GMT).   |

## Output

| Item                               | Format                         | Description                                                                      |
|------------------------------------|--------------------------------|----------------------------------------------------------------------------------|
| GetServiceAlarmCount­ForViewResult | Array of DMATop­AlarmCountData | The services with the largest/smallest number of alarms for each alarm severity. |

