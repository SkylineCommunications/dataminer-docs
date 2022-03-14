---
uid: GetTrendDataForParameterByName
---

# GetTrendDataForParameterByName

Use this method to retrieve the trend data of a particular parameter by parameter name.

## Input

| Item | Format | Description |
|--|--|--|
| Connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| ElementName | String | The element name. |
| ParameterName | String | The parameter name. |
| TableIndex | String | The (optional) table index (which, if specified, must be the display column). |
| TrendingSpanType | String | The trending span type: *LastHour*, *LastDay*, *LastWeek*, *LastMonth*, *LastYear*. |

## Output

| Item | Format | Description |
|--|--|--|
| GetTrendDataForParameterByNameResult | [AnalogTrendDataResponseMessage](xref:AnalogTrendDataResponseMessage) | The trend data of the specified parameter. |
