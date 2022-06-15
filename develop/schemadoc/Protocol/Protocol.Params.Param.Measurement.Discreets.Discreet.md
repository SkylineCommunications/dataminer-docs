---
uid: Protocol.Params.Param.Measurement.Discreets.Discreet
---

# Discreet element

Specifies a value and a text string. The latter will be displayed on the user interface if the former matches the value of the parameter.

## Parent

[Discreets](xref:Protocol.Params.Param.Measurement.Discreets)

## Attributes

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Type|Required|Description|
|--- |--- |--- |--- |
|[dependencyValues](xref:Protocol.Params.Param.Measurement.Discreets.Discreet-dependencyValues)|string||When the parameter depends on the current value of another parameter, dependencyValues can be used to specify whether the discreet value should be available.|
|[displayIconAndLabel](xref:Protocol.Params.Param.Measurement.Discreets.Discreet-displayIconAndLabel)|[EnumTrueFalse](xref:Protocol-EnumTrueFalse)||Specifies whether to show only the icon (false) or to show the icon together with the display value of the discrete entry (true).|
|[export](xref:Protocol.Params.Param.Measurement.Discreets.Discreet-export)|string||Specifies the parameter values that have to be exported.|
|[iconRef](xref:Protocol.Params.Param.Measurement.Discreets.Discreet-iconRef)|[EnumIcons](xref:Protocol-EnumIcons)||Specifies the key of the icon as defined in the Icons.xml file.|
|[options](xref:Protocol.Params.Param.Measurement.Discreets.Discreet-options)|string||Specifies the options to be used.|

## Children

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[Display](xref:Protocol.Params.Param.Measurement.Discreets.Discreet.Display)||Specifies the string to be displayed when the value of the parameter matches the contents of the Protocol.Params.Param.Measurement.Discreets.Discreet.Value tag.|
|&nbsp;&nbsp;[Value](xref:Protocol.Params.Param.Measurement.Discreets.Discreet.Value)||Specifies when the discrete value has to be displayed.|
|&nbsp;&nbsp;[Tooltip](xref:Protocol.Params.Param.Measurement.Discreets.Discreet.Tooltip)|[0, 1]|Specifies the tooltip to be displayed when the mouse pointer hovers over the icon displayed in a table cell containing the discrete parameter value to which it is linked.|
