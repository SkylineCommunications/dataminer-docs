---
uid: GetTrendDataForParameterByName
---

# GetTrendDataForParameterByName

Use this method to retrieve the trend data of a particular parameter by parameter name.

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| elementName | String | The element name. |
| parameterName | String | The parameter name. |
| tableIndex | String | The (optional) table index (which, if specified, must be the display column). |
| trendingSpanType | String | The trending span type: *LastHour*, *LastDay*, *LastWeek*, *LastMonth*, *LastYear*. |

## Output

| Item | Format | Description |
|--|--|--|
| GetTrendDataForParameterByNameResult | [AnalogTrendDataResponseMessage](xref:AnalogTrendDataResponseMessage) | The trend data of the specified parameter. |
