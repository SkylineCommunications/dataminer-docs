---
uid: GetAlarmStateTimelineForElement
---

# GetAlarmStateTimelineForElement

Use this method to retrieve the alarm state timeline for a particular element.

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID | Integer | The DataMiner Agent ID. |
| elementID | Integer | The element ID. |
| utcStartTime | Long integer | The start time of the time span for which alarm state changes should be retrieved, in UTC format (milliseconds since midnight January 1, 1970 GMT). |
| utcEndTime | Long integer | The end time of the time span for which alarm state changes should be retrieved, in UTC format (milliseconds since midnight January 1, 1970 GMT). |
| maxPoints | Integer | The maximum number of alarm state changes that should be returned. |

## Output

| Item | Format | Description |
|--|--|--|
| GetAlarmStateTimelineForElementResult | [DMATimeline](xref:DMATimeline) | An array of alarm state changes along with the start time and end time of the time span in which they occur. |
