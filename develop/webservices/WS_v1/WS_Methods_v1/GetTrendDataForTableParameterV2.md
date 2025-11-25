---
uid: GetTrendDataForTableParameterV2
---

# GetTrendDataForTableParameterV2

Use this method to retrieve the trend data for a parameter from within a particular time span by primary key.

Unlike the *GetTrendDataForTableParameter* method, this method allows you to select if real-time data should be retrieved, if available. With *GetTrendDataForTableParameter*, real-time data is only retrieved in case no average trending is available.

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID | Integer | The DataMiner Agent ID. |
| elementID | Integer | The element ID. |
| parameterID | Integer | The parameter ID. |
| tableIndex | String | The primary key. |
| utcStartTime | Long integer | The start time of the time span for which alarm state changes should be retrieved, in UTC format (milliseconds since midnight January 1, 1970 GMT). |
| utcEndTime | Long integer | The end time of the time span for which alarm state changes should be retrieved, in UTC format (milliseconds since midnight January 1, 1970 GMT). |
| isRealTime | Boolean | Indicates whether real-time data should be retrieved, if available. |

## Output

| Item | Format | Description |
|--|--|--|
| GetTrendDataForTableParameterV2Result | [DMATrendData](xref:DMATrendData) | The trend data for the specified primary key within the specified time span. |
