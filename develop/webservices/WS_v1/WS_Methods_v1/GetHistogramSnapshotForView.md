---
uid: GetHistogramSnapshotForView
---

# GetHistogramSnapshotForView

Use this method to retrieve a snapshot of trend data for a specified protocol parameter in the form of a histogram.

## Input

| Item            | Format  | Description                                                                                                 |
|-----------------|---------|-------------------------------------------------------------------------------------------------------------|
| connection      | String  | The connection ID. See [ConnectApp](xref:ConnectApp).                                                       |
| viewID          | Integer | The ID of the view.                                                                                         |
| includeSubViews | Boolean | Indicates whether subviews should be included.                                                              |
| protocolName    | String  | The name of the protocol.                                                                                   |
| protocolVersion | String  | The version of the protocol.                                                                                |
| parameterID     | Integer | The ID of the parameter.                                                                                    |
| tableIndex      | String  | The table index. This field must be specified for table column parameters; otherwise it must be left empty. |
| intervalAmount  | Integer | The number of intervals used in the histogram. Obsolete. This field is no longer supported.                 |
| asPercentages   | Boolean | Indicates whether the histogram should use percentages (= true) or absolute frequencies (= false).          |

## Output

| Item | Format | Description |
|--|--|--|
| GetHistogramSnapshotForViewResult | Array of [DMATrendData](xref:DMATrendData) | The histogram for the specified protocol parameter. |

> [!NOTE]
> The DMATrendData array includes an array of timestamps of type “long”. These values should be divided by 1000 to get the correct boundary values.
