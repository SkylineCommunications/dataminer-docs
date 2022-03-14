---
uid: GetScatterDataForServices
---

# GetScatterDataForServices

Use this method to retrieve the data to create a scatter chart for an array of services.

## Input

| Item | Format | Description |
|--|--|--|
| Connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| XAxisInfo.Type | String | Determines what is displayed by the X-axis of the scatter chart: *ALARM_COUNT*, *ALARM_STATE* or *PARAMETER_VALUE* |
| YAxisInfo.Type | String | Determines what is displayed by the Y-axis of the scatter chart: *ALARM_COUNT*, *ALARM_STATE* or *PARAMETER_VALUE* |
| Filter.FilterBy | String | Determines what the service are filtered by: *VIEW*, *PROTOCOL* or *VIEW_AND_PROTOCOL*. |
| Filter.ViewID | Integer | The view ID for which service data should be retrieved. |
| Filter.ProtocolName | String | The protocol ID of the protocol for which service data should be retrieved. |
| Filter.ProtocolVersion | String | The protocol version of the protocol for which service data should be retrieved. |
| Filter.Limit | Integer | The maximum number of services for which data should be retrieved. |
| Filter.StartTimeUTC | Long integer | The start time (in UTC) of the timespan for which data should be retrieved. |
| Filter.EndTimeUTC | Long integer | The end time (in UTC) of the timespan for which data should be retrieved. |
| Filter.IncludeSubViews | Boolean | Indicates whether data should also be retrieves for elements in subviews of the specified view. |

## Output

| Item | Format | Description |
|--|--|--|
| GetScatterDataForSer­vicesResult | Array of XValues, YValues and Labels | The values for the X- and Y-axis of the scatter chart and the corresponding labels |
