---
uid: GetHistogramTrendDataForParameter
---

# GetHistogramTrendDataForParameter

Use this method to retrieve a snapshot of trend data for a specified parameter.

## Input

| Item | Format | Description |
|--|--|--|
| Connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| DmaID | Integer | The DataMiner Agent ID. |
| ElementID | Integer | The element ID. |
| ParameterID | Integer | The parameter ID. |
| TableIndex | String | The (optional) table index |
| TrendingSpanType | String | The trending span type: *LastHour*, *LastDay*, *LastWeek*, *LastMonth*, *LastYear*. |
| IntervalAmount | Integer | The number of intervals used in the histogram. |
| AsPercentage | Boolean | Indicates whether the histogram should use percentages (= true) or absolute frequencies (= false). |

## Output

| Item | Format | Description |
|--|--|--|
| GetHistogramTrendData­ForParameterResult | Array of [DMATrendData](xref:DMATrendData) | The trend data for the specified parameter. |

> [!NOTE]
> The DMATrendData array includes an array of timestamps of type “long”. These values should be divided by 1000 to get the correct boundary values.
