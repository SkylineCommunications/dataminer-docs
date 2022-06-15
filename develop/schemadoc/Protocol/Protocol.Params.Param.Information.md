---
uid: Protocol.Params.Param.Information
---

# Information element

Specifies additional information about the parameter.

## Parent

[Param](xref:Protocol.Params.Param)

## Children

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[AlarmDescription](xref:Protocol.Params.Param.Information.AlarmDescription)|[0, 1]|Specifies an alarm description.|
|&nbsp;&nbsp;[Category](xref:Protocol.Params.Param.Information.Category)|[0, 1]|Specifies a category.|
|&nbsp;&nbsp;[CorrectiveAction](xref:Protocol.Params.Param.Information.CorrectiveAction)|[0, 1]|Specifies a corrective action.|
|&nbsp;&nbsp;[Includes](xref:Protocol.Params.Param.Information.Includes)|[0, 1]|Contains one or more Protocol.Params.Param.Information.Include tags to indicate that you want additional information to be displayed in the tooltip.|
|&nbsp;&nbsp;[Subtext](xref:Protocol.Params.Param.Information.Subtext)|[0, 1]|Specifies the actual content of the tooltip.|
|&nbsp;&nbsp;[Text](xref:Protocol.Params.Param.Information.Text)|[0, 1]|Specifies the title of the tooltip.|

## Remarks

DataMiner will show this additional information in tooltip windows.

> [!NOTE]
> Typically, only parameters of type "read" or "read bit" will have a Protocol.Params.Param.Information tag. In some cases, however, also parameters of type "write" or "write bit" have one.
