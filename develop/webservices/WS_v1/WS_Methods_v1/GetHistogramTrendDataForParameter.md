---
uid: GetHistogramTrendDataForParameter
---

# GetHistogramTrendDataForParameter

Use this method to retrieve a snapshot of trend data for a specified parameter.

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID | Integer | The DataMiner Agent ID. |
| elementID | Integer | The element ID. |
| parameterID | Integer | The parameter ID. |
| tableIndex | String | The (optional) table index |
| trendingSpanType | String | The trending span type: *LastHour*, *LastDay*, *LastWeek*, *LastMonth*, *LastYear*. |
| intervalAmount | Integer | The number of intervals used in the histogram. Obsolete. This field is no longer supported. |
| asPercentage | Boolean | Indicates whether the histogram should use percentages (= true) or absolute frequencies (= false). |

## Output

| Item | Format | Description |
|--|--|--|
| GetHistogramTrendDataForParameterResult | Array of [DMATrendData](xref:DMATrendData) | The trend data for the specified parameter. |

> [!NOTE]
> The DMATrendData array includes an array of timestamps of type “long”. These values should be divided by 1000 to get the correct boundary values.
