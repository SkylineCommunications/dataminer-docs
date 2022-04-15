---
uid: GetTrendDataSimplifiedForParameter
---

# GetTrendDataSimplifiedForParameter

Use this method to retrieve the trend data of a particular parameter.

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
| GetTrendDataSimplifiedForParameterResult | [DMATrendData](xref:DMATrendData) | The trend data of the specified parameter. |
