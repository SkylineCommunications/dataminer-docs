---
uid: GetTrendStatisticsForService
---

# GetTrendStatisticsForService

Use this method to retrieve the trend statistics for a specified service. Available from DataMiner 9.5.8 onwards.

## Input

| Item               | Format       | Description                                                                                                                                                                                                                                                                                                       |
|--------------------|--------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Connection         | String       | The connection ID. See [ConnectApp](xref:ConnectApp) .                                                                                                                                                                                                                                  |
| DmaID              | Integer      | The DataMiner Agent ID.                                                                                                                                                                                                                                                                                           |
| ServiceID          | Integer      | The service ID.                                                                                                                                                                                                                                                                                                   |
| Filter             | String       | Optional parameter name filter supporting regular expressions.                                                                                                                                                                                                                                                    |
| TrendingSpanType   | String       | The trending span type: *LastHour*, *LastDay*, *LastWeek*, *LastMonth*, *LastYear*, *CustomAmountHours* or *Custom*. |
| CustomAmountHours  | Integer      | The custom amount of hours for the trend span in case TrendSpan is set to *CustomAmountHours*.                                                                                                                                                                                         |
| UtcCustomStartTime | Long integer | The custom start time of the trend span in case TrendingSpanType is set to *Custom*.                                                                                                                                                                                                   |
| UtcCustomEndTime   | Long integer | The custom end time of the trend span in case TrendingSpanType is set to *Custom*.                                                                                                                                                                                                     |

## Output

| Item                                  | Format                                  | Description                                                                                                    |
|---------------------------------------|-----------------------------------------|----------------------------------------------------------------------------------------------------------------|
| GetTrendStatisticsFor­ServiceResponse | Array of DMATrendData­StatisticsService | A list of the parameters that have trending enabled within the specified service, with their trend statistics. |

