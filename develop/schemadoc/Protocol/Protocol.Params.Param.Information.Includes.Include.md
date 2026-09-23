---
metadata_version: 1
uid: Protocol.Params.Param.Information.Includes.Include
description: "Reference the DataMiner connector protocol schema entry for Include element, including its documented structure, attributes, values, and constraints."
content_type: schema
applies_to:
  - DataMiner
---

# Include element

Specifies additional information to be displayed in the tooltip.

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

Information specified in Protocol.Params.Param.Information.Include tags will appear underneath the contents of the Protocol.Params.Param.Information.Subtext tag.
