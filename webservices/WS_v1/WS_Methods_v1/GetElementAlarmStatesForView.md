---
uid: GetElementAlarmStatesForView
---

# GetElementAlarmStatesForView

Use this method to retrieve the relative duration (in percent) of each alarm severity for the elements in the specified view.

## Input

| Item | Format | Description |
|--|--|--|
| Connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| ViewID | Integer | The view ID. |
| Limit | Integer | The number of elements that should be included. |
| SortASC | Boolean | Indicates whether the info should be retrieved for the elements that were in an alarm state for the longest time or for the shortest time. |
| UtcStartTime | Long integer | The start time of the timespan for which the alarm durations should be retrieved, in UTC format (milliseconds since midnight January 1, 1970 GMT). |
| UtcEndTime | Long integer | The end time of the timespan for which the alarm durations should be retrieved, in UTC format (milliseconds since midnight January 1, 1970 GMT). |

## Output

| Item | Format | Description |
|--|--|--|
| GetElementAlarmStates­ForViewResult | Array of [DMATopAlarmCountData](xref:DMATopAlarmCountData) | The relative duration (double) of each alarm severity for the elements within the specified limitations. |
