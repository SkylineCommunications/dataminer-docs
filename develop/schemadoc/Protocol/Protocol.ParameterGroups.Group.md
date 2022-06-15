---
uid: Protocol.ParameterGroups.Group
---

# Group element

Defines a parameter group.

## Parent

[ParameterGroups](xref:Protocol.ParameterGroups)

## Attributes

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Type|Required|Description|
|--- |--- |--- |--- |
|[calculateAlarmState](xref:Protocol.ParameterGroups.Group-calculateAlarmState)|[TypeParamId](xref:Protocol-EnumTrueFalse)||Specifies whether to disable the interface state calculation.|
|[dynamicId](xref:Protocol.ParameterGroups.Group-dynamicId)|[TypeParamId](xref:Protocol-TypeParamId)||Specifies the ID of the table parameter.|
|[dynamicIndex](xref:Protocol.ParameterGroups.Group-dynamicIndex)|string||Specifies the display key, which can be used as a filter.|
|[dynamicUsePK](xref:Protocol.ParameterGroups.Group-dynamicUsePK)|[EnumTrueFalse](xref:Protocol-EnumTrueFalse)||Specifies whether the display key or the primary key should be used in the interface name (Default: false).|
|[id](xref:Protocol.ParameterGroups.Group-id)||Yes|Specifies the unique ID of the parameter group.|
|[isInternal](xref:Protocol.ParameterGroups.Group-isInternal)|[EnumTrueFalse](xref:Protocol-EnumTrueFalse)||Specifies whether this an internal interface.|
|[name](xref:Protocol.ParameterGroups.Group-name)|string||Specifies the name of the parameter group.|
|[type](xref:Protocol.ParameterGroups.Group-type)|[EnumParamGroupType](xref:Protocol-EnumParamGroupType)|Yes|Specifies the type of the interface.|

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Params](xref:Protocol.ParameterGroups.Group.Params)|[0, 1]|Specifies the parameters that are included in the group.|

## Remarks

The general parameters include tables that contain the element connectivity information:

- Interfaces (pid 65049)
- Interface properties (pid 65054)
- Connections (pid 65060)
- Connection properties (pid 65068)

A parameter group of type ‘in’, ‘out’ or ‘inout’ is interpreted as an interface that contains a set of parameters with an overall severity (saved in the Interfaces table). Several interfaces can be defined on an element, and these can be linked to other interfaces on the same and/or other elements connecting these elements (saved in the Connections table). A global convention is to always connect elements from input to output.

A connectivity chain can look like this:

**Interface 1 (in) -> Interface 2 (inout) -> ... (inout) -> Interface x (out)**

Interfaces can be part of different elements. Linked interfaces of the same element are considered “internal” connections.

Property information associated with interfaces and connections of specific elements can be saved in the Interface Properties table.

> [!NOTE]
>
> - When a group is defined like this, it acts as a prototype for the table in question.
> - When a group is defined like this, all rows that match the dynamicIndex filter in the table of which the parameter ID matches the ID specified in dynamicId will be considered part of the parameter group.
> - The name of the parameter group will be the name defined in the prototype, concatenated with the index of the row. If, for example, the table with parameter ID 6 contains a row with index (displaycolumn) “StreamData”, then the name of the parameter group will be “Port StreamData” and the group will contain all the columns with index “Dog”.
> - If you define a table with the ”;element option” property, parameter groups will be exported to the matching DVE element.
> - If you defined a table parameter that is a matrix, the connections table will automatically be filled with the crosspoints that are connected. Example: Parameter group 4 has all its inputs and outputs selected (*). You can also define if you only want a certain set via x,y filtering (x is the input filter and y is the output filter).
> - If you want to turn the inputs into interfaces, the type of the parameter group must be “in”, if you want to turn the outputs into interfaces, the type of the parameter group must be “out”, and if you want a combination, the type of the parameter group must be “inout”.
> - Parameter groups with dynamicId do not yet support tables with advanced naming.
> - When dynamicId and dynamicIndex are not present, there must be a Params tag with a number of Param subtags.
