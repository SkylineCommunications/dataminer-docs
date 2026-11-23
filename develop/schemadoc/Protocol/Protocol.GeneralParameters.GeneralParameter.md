---
uid: Protocol.GeneralParameters.GeneralParameter
description: "Use the GeneralParameter element in a DataMiner protocol to enable or disable loading for a selected general parameter group."
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
