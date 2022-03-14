---
uid: Protocol.Actions.Action.Type
---

# Type element

Defines, together with [On](xref:Protocol.Actions.Action.On), how the action is executed.

## Type

[EnumActionType](xref:Protocol-EnumActionType)

## Parent

[Action](xref:Protocol.Actions.Action)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[allowed](xref:Protocol.Actions.Action.Type-allowed)|string||If Type is "stuffing": If the byte specified in the "value" attribute is followed by one of the characters specified in this attri­bute, then it will not be repeated.|
|[arguments](xref:Protocol.Actions.Action.Type-arguments)|string||If Type is "wmi", this attribute specifies the names of the columns to be returned (separated by semicolons).|
|[endoffset](xref:Protocol.Actions.Action.Type-endoffset)|unsignedInt||If Type is "stuffing", this attribute specifies the (fixed) end position that delimits the part of the data block in which stuffing has to be performed.|
|[id](xref:Protocol.Actions.Action.Type-id)|unsignedInt||If Type is "read file", this attribute specifies the ID of the parameter containing the directory in which the file can be found. If Type is "replace", this attribute specifies the ID of the parameter that contains the ID of the parameter that has to be put in the command/response. If Type is "increment", this attribute specifies the ID of the parameter that holds the increment value.|
|[nr](xref:Protocol.Actions.Action.Type-nr)|string||If Type is "read file", this attribute specifies the number of bytes to be read. If Type is "replace", this attribute specifies the 0-based position of the parameter in the command/response. If Type is "set", this attribute sepcifies the connection. If Type is "set next", this attribute sepcifies the ID of the parameter containing the value to be set.|
|[options](xref:Protocol.Actions.Action.Type-options)|string||This attribute allows defining different options depending on the type of action.|
|[reschedule](xref:Protocol.Actions.Action.Type-reschedule)|[EnumTrueFalse](xref:Protocol-EnumTrueFalse)||If Type is "restart timer and this attribute is set to “true”, then the timer will immediately start again. Feature introduced in DataMiner 8.5.4 (RN 9189).|
|[returnValue](xref:Protocol.Actions.Action.Type-returnValue)|string||If Type is "read file", this attribute specifies the ID of the parameter in which to store the retrieved file content. If Type is "wmi", this attribute specifies the ID of the parameter containing the returned values (if "table" is set to "true", this ID should be the ID of a parameter of type "array").|
|[regex](xref:Protocol.Actions.Action.Type-regex)|[TypeNonEmptyString](xref:Protocol-TypeNonEmptyString)||If Type is "aggregate", this attribute allows to specify the regular expression to use for filtering.|
|[scale](xref:Protocol.Actions.Action.Type-scale)|string||If Type is "set info", this attribute specifies the scale to be set on the parameter.|
|[script](xref:Protocol.Actions.Action.Type-script)|string||If Type is "wmi", this attribute specifies the WMI class (e.g. Win32_PerfRawData_PerfOS_Memory).|
|[sequence](xref:Protocol.Actions.Action.Type-sequence)|string||If Type is "set info", this attribute specifies the sequence to be set on the parameter.|
|[startoffset](xref:Protocol.Actions.Action.Type-startoffset)|unsignedInt||If Type is "read file", this attribute specifies the ID of the parameter containing the start offset (i.e. the number of bytes to skip before starting to read the file). If Type is "stuffing", this attribute specifies the (fixed) start position that delimits the part of the data block in which stuffing has to be performed.|
|[value](xref:Protocol.Actions.Action.Type-value)|string||If Type is "stuffing", this attribute specifies the actual stuffing character, i.e. the byte that has to be repeated.|

## Remarks

> [!NOTE]
> For an overview of which attributes are supported on which action, refer to <xref:LogicActionsOverview>.
