---
uid: GetTrendStatisticsForService
---

# GetTrendStatisticsForService

Use this method to retrieve the trend statistics for a specified service. Available from DataMiner 9.5.8 onwards.

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID | Integer | The DataMiner Agent ID. |
| serviceID | Integer | The service ID. |
| filter | String | Optional parameter name filter supporting regular expressions. |
| trendingSpanType | String | The trending span type: *LastHour*, *LastDay*, *LastWeek*, *LastMonth*, *LastYear*, *CustomAmountHours* or *Custom*. |
| customAmountHours | Integer | The custom amount of hours for the trend span in case TrendSpan is set to *CustomAmountHours*. |
| utcCustomStartTime | Long integer | The custom start time of the trend span in case TrendingSpanType is set to *Custom*. |
| utcCustomEndTime | Long integer | The custom end time of the trend span in case TrendingSpanType is set to *Custom*. |

## Output

| Item | Format | Description |
|--|--|--|
| GetTrendStatisticsForServiceResponse | Array of DMATrendDataStatisticsService | A list of the parameters that have trending enabled within the specified service, with their trend statistics. |
