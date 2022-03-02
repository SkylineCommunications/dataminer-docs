---
uid: GetHistogramSnapshotForView
---

# GetHistogramSnapshotForView

Use this method to retrieve a snapshot of trend data for a specified protocol parameter in the form of a histogram.

## Input

| Item            | Format  | Description                                                                                                 |
|-----------------|---------|-------------------------------------------------------------------------------------------------------------|
| Connection      | String  | The connection ID. See [ConnectApp](xref:ConnectApp).                                                       |
| ViewID          | Integer | The ID of the view.                                                                                         |
| IncludeSubViews | Boolean | Indicates whether subviews should be included.                                                              |
| ProtocolName    | String  | The name of the protocol.                                                                                   |
| ProtocolVersion | String  | The version of the protocol.                                                                                |
| ParameterID     | Integer | The ID of the parameter.                                                                                    |
| TableIndex      | String  | The table index. This field must be specified for table column parameters; otherwise it must be left empty. |
| IntervalAmount  | Integer | The number of intervals used in the histogram.                                                              |
| AsPercentages   | Boolean | Indicates whether the histogram should use percentages (= true) or absolute frequencies (= false).          |

## Output

| Item | Format | Description |
|--|--|--|
| GetHistogramSnapshotForViewResult | Array of DMATrendData (see [DMATrendData](xref:DMATrendData)) | The histogram for the specified protocol parameter. |

> [!NOTE]
> The DMATrendData array includes an array of timestamps of type “long”. These values should be divided by 1000 to get the correct boundary values.
