---
uid: GetTrendDataForTableParameter
---

# GetTrendDataForTableParameter

Use this method to retrieve the trend data for a parameter from within a particular timespan by primary key.

With this method, real-time data is only retrieved in case no average trending is available. To retrieve real-time data in case there is average trending, use [GetTrendDataForTableParameterV2](xref:GetTrendDataForTableParameterV2).

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID | Integer | The DataMiner Agent ID. |
| elementID | Integer | The element ID. |
| parameterID | Integer | The parameter ID. |
| tableIndex | String | The primary key. |
| utcStartTime | Long integer | The start time of the timespan for which alarm state changes should be retrieved, in UTC format (milliseconds since midnight January 1, 1970 GMT). |
| utcEndTime | Long integer | The end time of the timespan for which alarm state changes should be retrieved, in UTC format (milliseconds since midnight January 1, 1970 GMT). |

## Output

| Item | Format | Description |
|--|--|--|
| GetTrendDataForTableParameterResult | [DMATrendData](xref:DMATrendData) | The trend data for the specified primary key within the specified timespan. |
