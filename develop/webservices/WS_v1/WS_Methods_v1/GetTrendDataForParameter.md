---
uid: GetTrendDataForParameter
---

# GetTrendDataForParameter

Use this method to retrieve the trend data of a particular parameter.

> [!NOTE]
> This method is deprecated. Use [GetTrendDataSimplifiedForParameter](xref:GetTrendDataSimplifiedForParameter) instead.

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID | Integer | The DataMiner Agent ID. |
| elementID | Integer | The element ID. |
| parameterID | Integer | The parameter ID. |
| tableIndex | String | The (optional) table index (which, if specified, must be the display column). |
| trendingSpanType | String | The trending span type: *LastHour*, *LastDay*, *LastWeek*, *LastMonth*, *LastYear*. |

## Output

| Item | Format | Description |
|--|--|--|
| GetTrendDataForParameterResult | [AnalogTrendDataResponseMessage](xref:AnalogTrendDataResponseMessage) | The trend data of the specified parameter. |
