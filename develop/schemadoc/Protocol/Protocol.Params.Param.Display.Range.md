---
uid: Protocol.Params.Param.Display.Range
---

# Range element

Defines the parameter value range.

## Parent

[Display](xref:Protocol.Params.Param.Display)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***Sequence***|||
|&nbsp;&nbsp;[Low](xref:Protocol.Params.Param.Display.Range.Low)|[0, 1]|Specifies the lower limit of the range, i.e. the minimum value of the parameter.|
|&nbsp;&nbsp;[High](xref:Protocol.Params.Param.Display.Range.High)|[0, 1]|Specifies the upper limit of the value range, i.e. the maximum value of the parameter.|

## Remarks

> [!NOTE]
> Defining a range on a parameter is useful for the following reasons:
>
> - It makes it possible to show a slider for write parameters.
> - The range is shown in the tooltip.
> - The range information is used by DataMiner to generate better trend graphs.
> - The range information is used when defining alarm thresholds.
> - The range information is used by UI components such as parameters of measurement type "analog".
> - The range information is used by the Analytics component of DataMiner for more accurate trend/alarm prediction.

> [!IMPORTANT]
> When you use the [time](xref:Protocol.Params.Param.Measurement.Type-options) option, you should either specify both the low and high intervals if a range is required, or specify neither. Otherwise, Cube will not be able to correctly display the tooltip and slider within the expected ranges.
