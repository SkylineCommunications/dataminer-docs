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
| Connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| DmaID | Integer | The DataMiner Agent ID. |
| ElementID | Integer | The element ID. |
| ParameterID | Integer | The parameter ID. |
| TableIndex | String | The (optional) table index (which, if specified, must be the display column). |
| TrendingSpanType | String | The trending span type: *LastHour*, *LastDay*, *LastWeek*, *LastMonth*, *LastYear*. |

## Output

| Item | Format | Description |
|--|--|--|
| GetTrendDataFor­ParameterResult | [AnalogTrendDataResponseMessage](xref:AnalogTrendDataResponseMessage) | The trend data of the specified parameter. |
