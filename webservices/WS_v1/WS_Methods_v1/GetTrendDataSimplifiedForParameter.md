---
uid: GetTrendDataSimplifiedForParameter
---

# GetTrendDataSimplifiedForParameter

Use this method to retrieve the trend data of a particular parameter.

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
| GetTrendDataSimplifiedForParameterResult | [DMATrendData](xref:DMATrendData) | The trend data of the specified parameter. |
