---
uid: GetAlarmStateTimelineForParameter
---

# GetAlarmStateTimelineForParameter

Use this method to retrieve the alarm state timeline for a particular parameter.

Available from DataMiner version 9.5.1 onwards.

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID | Integer | The DataMiner Agent ID. |
| elementID | Integer | The element ID. |
| parameterID | Integer | The parameter ID. |
| tableIndex | String | The table index. This field must be specified for table column parameters; otherwise it must be left empty. |
| utcStartTime | Long integer | The start time of the timespan for which alarm state changes should be retrieved, in UTC format (milliseconds since midnight January 1, 1970 GMT). |
| utcEndTime | Long integer | The end time of the timespan for which alarm state changes should be retrieved, in UTC format (milliseconds since midnight January 1, 1970 GMT). |
| maxPoints | Integer | The maximum number of alarm state changes that should be returned. |

## Output

| Item | Format | Description |
|--|--|--|
| GetAlarmStateTimelineForParameterResult | [DMATimeline](xref:DMATimeline) | An array of alarm state changes along with the start time and end time of the timespan in which they occur. |
