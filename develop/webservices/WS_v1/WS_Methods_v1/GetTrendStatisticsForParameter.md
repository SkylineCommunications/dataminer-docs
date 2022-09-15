---
uid: GetTrendStatisticsForParameter
---

# GetTrendStatisticsForParameter

Use this method to retrieve the trend statistics for a specified parameter. Available from DataMiner 9.5.8 onwards.

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID | Integer | The DataMiner Agent ID. |
| elementID | Integer | The element ID. |
| parameterID | Integer | The parameter ID. |
| tableIndex | String | The (optional) table index (which, if specified, must be the display column). |
| trendingSpanType | String | The trending span type: *LastHour*, *LastDay*, *LastWeek*, *LastMonth*, *LastYear*, *CustomAmountHours* or *Custom*. |
| customAmountHours | Integer | The custom amount of hours for the trend span in case TrendSpan is set to *CustomAmountHours*. |
| utcCustomStartTime | Long integer | The custom start time of the trend span in case TrendingSpanType is set to *Custom*. |
| utcCustomEndTime | Long integer | The custom end time of the trend span in case TrendingSpanType is set to *Custom*. |

## Output

| Item | Format | Description |
|--|--|--|
| GetTrendStatisticsForParameterResponse | Array | The parameter name and element name, the unit used for the parameter, and the minimum, average and maximum trend values. |
