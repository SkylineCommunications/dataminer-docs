---
uid: GetTrendDataForTableParameterV2
---

# GetTrendDataForTableParameterV2

Use this method to retrieve the trend data for a parameter from within a particular timespan by primary key.

Unlike the *GetTrendDataForTableParameter* method, this method allows you to select if real-time data should be retrieved, if available. With *GetTrendDataForTableParameter*, real-time data is only retrieved in case no average trending is available.

Available from DataMiner 9.6.12 onwards.

## Input

| Item | Format | Description |
|--|--|--|
| Connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| DmaID | Integer | The DataMiner Agent ID. |
| ElementID | Integer | The element ID. |
| ParameterID | Integer | The parameter ID. |
| TableIndex | String | The primary key. |
| UtcStartTime | Long integer | The start time of the timespan for which alarm state changes should be retrieved, in UTC format (milliseconds since midnight January 1, 1970 GMT). |
| UtcEndTime | Long integer | The end time of the timespan for which alarm state changes should be retrieved, in UTC format (milliseconds since midnight January 1, 1970 GMT). |
| IsRealTime | Boolean | Indicates whether real-time data should be retrieved, if available. |

## Output

| Item | Format | Description |
|--|--|--|
| GetTrendDataForTable­ParameterV2Result | [DMATrendData](xref:DMATrendData) | The trend data for the specified primary key within the specified timespan. |
