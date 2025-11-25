---
uid: GetTrendStatisticsForParameter
---

# GetTrendStatisticsForParameter

Use this method to retrieve the trend statistics for a specified parameter.

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
| ParameterName  | String | The name of the parameter. |
| ElementName    | String | The name of the element. |
| Unit           | String | The parameter unit. |
| DisplayMinimum | String | The minimum value. |
| DisplayAverage | String | The average value. |
| DisplayMaximum | String | The maximum value. |
