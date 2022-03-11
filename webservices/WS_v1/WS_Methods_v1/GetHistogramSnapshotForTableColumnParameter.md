---
uid: GetHistogramSnapshotForTableColumnParameter
---

# GetHistogramSnapshotForTableColumnParameter

Use this method to retrieve a snapshot of trend data for a specified table column parameter in the form of a histogram.

## Input

| Item           | Format          | Description                                                                                        |
|----------------|-----------------|----------------------------------------------------------------------------------------------------|
| Connection     | String          | The connection ID. See [ConnectApp](xref:ConnectApp).                                              |
| DmaID          | Integer         | The DataMiner Agent ID.                                                                            |
| ElementID      | Integer         | The element ID.                                                                                    |
| ParameterID    | Integer         | The parameter ID.                                                                                  |
| Filters        | Array of string | Any filters applied to the table column parameter.                                                 |
| IntervalAmount | Integer         | The number of intervals used in the histogram.                                                     |
| AsPercentage   | Boolean         | Indicates whether the histogram should use percentages (= true) or absolute frequencies (= false). |

## Output

| Item | Format | Description |
|--|--|--|
| GetHistogramSnapshotFor­TableColumnParameterResult | Array of [DMATrendData](xref:DMATrendData) | The histogram for the specified table column parameter. |

> [!NOTE]
> The DMATrendData array includes an array of timestamps of type “long”. These values should be divided by 1000 to get the correct boundary values.
