---
metadata_version: 1
uid: Protocol.GeneralParameters.GeneralParameter
description: "Learn how the GeneralParameter element enables or disables loading for a selected general parameter group in a DataMiner connector protocol."
---

# GeneralParameter element

Configures a general parameter group.

## Parent

[GeneralParameters](xref:Protocol.GeneralParameters)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[group](xref:Protocol.GeneralParameters.GeneralParameter-group)|[EnumGeneralParameterGroupType](xref:Protocol-EnumGeneralParameterGroupType)|Yes|Specifies the general parameter group.|
|[enabled](xref:Protocol.GeneralParameters.GeneralParameter-enabled)|[EnumTrueFalse](xref:Protocol-EnumTrueFalse)|Yes|When set to false, the specified general parameter group will not be loaded.|
