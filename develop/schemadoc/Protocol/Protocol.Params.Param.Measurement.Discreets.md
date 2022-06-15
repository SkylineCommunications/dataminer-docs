---
uid: Protocol.Params.Param.Measurement.Discreets
---

# Discreets element

Contains the displayed value(s) of the parameter.

## Parent

[Measurement](xref:Protocol.Params.Param.Measurement)

## Attributes

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Type|Required|Description|
|--- |--- |--- |--- |
|[dependencyId](xref:Protocol.Params.Param.Measurement.Discreets-dependencyId)|[TypeParamId](xref:Protocol-TypeParamId)||If the discrete values of the parameter depend on the current state of another parameter, the ID of that other parameter can be specified using this attribute.|
|[matrixLayout](xref:Protocol.Params.Param.Measurement.Discreets-matrixLayout)|||Configures the layout of the matrix.|

## Children

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Discreet](xref:Protocol.Params.Param.Measurement.Discreets.Discreet)|[0, *]|Specifies a value and a text string. The latter will be displayed on the user interface if the former matches the value of the parameter.|

## Constraints

|Type|Description|Selector|Fields|
|--- |--- |--- |--- |
|Unique |No duplicate values must occur in the discrete value list. |Discreet |dis:Value, @dependencyValues |
|Unique |No duplicate values must occur in the discrete display value list. |Discreet |dis:Display, @dependencyValues |

## Remarks

For every value, page button or button to be displayed, a separate Protocol.Params.Param.Measurement.Discreets.Discreet tag has to be specified (see [Protocol.Params.Param.Measurement.Discreets.Discreet](xref:Protocol.Params.Param.Measurement.Discreets.Discreet)). In Data Display, the values will be displayed in the order in which they are specified in the Protocol.Params.Param.Measurement.Discreets tag.

Note that in general, for parameters of type "read", if discrete entries (Discreets) are defined and the (raw) value of the parameter can be mapped to a Discreet/Value value, it will be displayed as the corresponding Discreet/Display value (after the defined exception values are first checked).

For parameters of type "write", note the following usage remarks:

|Measurement type|Usage|
|--- |--- |
|discreet|Represents a number of discrete entries.|
|togglebutton|Special case of "discreet" with exactly two values to be visualized as a toggle button.|
|button|Holds one entry per button on the same row. The value is the string that will be set.|
|pagebutton|Holds one entry per page button on the same row. The value is the name of the Data Display page to open.|
|matrix|For an NxM matrix, values must be 1…N for inputs, (N+1)…(N+M) for outputs.|
|string, analog, number, discreet|Each of these can have a single discrete entry marked as "disabled". This will display a check box next to the normal value editor.|
