---
uid: Protocol.Params.Param.Measurement
---

# Measurement element

Specifies how the parameter has to be displayed on the user interface (depending on the parameter type).

## Parent

[Param](xref:Protocol.Params.Param)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[Discreets](xref:Protocol.Params.Param.Measurement.Discreets)|[0, 1]|Contains the displayed value(s) of the parameter.|
|&nbsp;&nbsp;[Threshold](xref:Protocol.Params.Param.Measurement.Threshold)|[0, 1]|Specifies a threshold.|
|&nbsp;&nbsp;[Type](xref:Protocol.Params.Param.Measurement.Type)||Specifies how the parameter has to be displayed on the user interface.|

## Remarks

This tag must always contain a Protocol.Params.Param.Measurement.Type tag, and can optionally contain a Protocol.Params.Param.Measurement.Discreets tag (depending on the contents of the Protocol.Params.Param.Measurement.Type tag).
