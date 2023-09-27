---
uid: Protocol.Actions.Action.Type
---

# Type element

Defines, together with [On](xref:Protocol.Actions.Action.On), how the action is executed.

> [!NOTE]
> Not all Protocol.Actions.Action.Type values can be used in combination with the different Protocol.Actions.Action.On types. See [Possible combinations of “On” and “Type”](xref:LogicActionsOverview).

## Type

[EnumActionType](xref:Protocol-EnumActionType)

## Parent

[Action](xref:Protocol.Actions.Action)

## Attributes

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Type|Required|Description|
|--- |--- |--- |--- |
|[allowed](xref:Protocol.Actions.Action.Type-allowed)|string||If Action/Type is "stuffing": If the byte specified in the "value" attribute is followed by one of the characters specified in this attribute, then it will not be repeated.|
|[arguments](xref:Protocol.Actions.Action.Type-arguments)|string||If Action/Type is "wmi", this attribute specifies the names of the columns to be returned (separated by semicolons).|
|[endoffset](xref:Protocol.Actions.Action.Type-endoffset)|unsignedInt||If Action/Type is "stuffing", this attribute specifies the (fixed) end position that delimits the part of the data block in which stuffing has to be performed.|
|[id](xref:Protocol.Actions.Action.Type-id)|unsignedInt||If Action/Type is "read file", this attribute specifies the ID of the parameter containing the directory in which the file can be found. If Action/Type is "replace", this attribute specifies the ID of the parameter that contains the ID of the parameter that has to be put in the command/response. If Action/Type is "increment", this attribute specifies the ID of the parameter that holds the increment value.|
|[nr](xref:Protocol.Actions.Action.Type-nr)|string||If Action/Type is "read file", this attribute specifies the number of bytes to be read. If Action/Type is "replace", this attribute specifies the (0-based) position of the parameter in the command/response. If Action/Type is "set", "set and get with wait", "set with wait", "open", "close", "lock", "unlock", "priority lock" or "priority unlock", this attribute specifies the (0-based) connection ID.|
|[options](xref:Protocol.Actions.Action.Type-options)|string||This attribute allows defining different options depending on the type of action.|
|[reschedule](xref:Protocol.Actions.Action.Type-reschedule)|[EnumTrueFalse](xref:Protocol-EnumTrueFalse)||If Action/Type is "restart timer" and this attribute is set to “true”, then the timer will immediately start again. Feature introduced in DataMiner 8.5.4 (RN 9189).|
|[returnValue](xref:Protocol.Actions.Action.Type-returnValue)|string||If Action/Type is "read file", this attribute specifies the ID of the parameter in which to store the retrieved file content. If Action/Type is "wmi", this attribute specifies the ID of the parameter containing the returned values (if "table" is set to "true", this ID should be the ID of a parameter of type "array").|
|[regex](xref:Protocol.Actions.Action.Type-regex)|[TypeNonEmptyString](xref:Protocol-TypeNonEmptyString)||If Action/Type is "aggregate", this attribute allows to specify the regular expression to use for filtering.|
|[scale](xref:Protocol.Actions.Action.Type-scale)|string||If Action/Type is "set info", this attribute specifies the scale to be set on the parameter.|
|[script](xref:Protocol.Actions.Action.Type-script)|string||If Action/Type is "wmi", this attribute specifies the WMI class (e.g. Win32_PerfRawData_PerfOS_Memory).|
|[sequence](xref:Protocol.Actions.Action.Type-sequence)|string||If Action/Type is "set info", this attribute specifies the sequence to be set on the parameter.|
|[startoffset](xref:Protocol.Actions.Action.Type-startoffset)|unsignedInt||If Action/Type is "read file", this attribute specifies the ID of the parameter containing the start offset (i.e. the number of bytes to skip before starting to read the file). If Action/Type is "stuffing", this attribute specifies the (fixed) start position that delimits the part of the data block in which stuffing has to be performed.|
|[value](xref:Protocol.Actions.Action.Type-value)|string||If Action/Type is "stuffing", this attribute specifies the actual stuffing character, i.e. the byte that has to be repeated.|

## Remarks

> [!NOTE]
> For an overview of which attributes are supported on which action, refer to <xref:LogicActionsOverview>.
