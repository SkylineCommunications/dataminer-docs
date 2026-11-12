---
uid: Protocol.Params.Param.Information.Includes.Include
description: "Learn how the obsolete Include element in a DataMiner protocol adds parameter range, unit, step size, or timestamp details to an information tooltip."
---

# Include element [obsolete]

Specifies additional information to be displayed in the tooltip.

> [!IMPORTANT]
> The `Includes` and `Include` tags are now obsolete. They were used by the legacy System Display application and are no longer used by DataMiner Cube.

## Type

[EnumParamInformationInclude](xref:Protocol-EnumParamInformationInclude)

## Parent

[Includes](xref:Protocol.Params.Param.Information.Includes)

## Remarks

Contains one of the following values:

|Value|Description|
|--- |--- |
|range|The range of the parameter.|
|units|The unit of the parameter.|
|steps|The step size of the parameter.|
|time|A time stamp that refers to one of the following: The last known change / The last time the parameter was changed by its write parameter (if any)|

Information specified in `Protocol.Params.Param.Information.Include` tags will appear underneath the contents of the `Protocol.Params.Param.Information.Subtext` tag.
