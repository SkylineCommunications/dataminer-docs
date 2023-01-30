---
uid: Protocol.TreeControls.TreeControl
---

# TreeControl element

Defines a tree control.

## Parent

[TreeControls](xref:Protocol.TreeControls)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[parameterId](xref:Protocol.TreeControls.TreeControl-parameterId)|[TypeParamId](xref:Protocol-TypeParamId)|Yes|Specifies the parameter ID of the tree control.|
|[readOnly](xref:Protocol.TreeControls.TreeControl-readOnly)|[EnumTrueFalse](xref:Protocol-EnumTrueFalse)||If set to "true", disables all the write parameters in the tree control.|

## Children

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[ExtraDetails](xref:Protocol.TreeControls.TreeControl.ExtraDetails)|[0, 1]|Defines additional tree item information to be displayed in the details section of the tree control layout.|
|&nbsp;&nbsp;[ExtraTabs](xref:Protocol.TreeControls.TreeControl.ExtraTabs)|[0, 1]|Contains additional tab definitions in the tree control.|
|&nbsp;&nbsp;[HiddenColumns](xref:Protocol.TreeControls.TreeControl.HiddenColumns)|[0, 1]|Specifies the columns to be hidden.|
|&nbsp;&nbsp;[Hierarchy](xref:Protocol.TreeControls.TreeControl.Hierarchy)|[0, 1]|Defines the relationship between the (visible) tables.|
|&nbsp;&nbsp;[ReadonlyColumns](xref:Protocol.TreeControls.TreeControl.ReadonlyColumns)|[0, 1]|Used to hide write controls for certain table columns.|
|&nbsp;&nbsp;[OverrideDisplayColumns](xref:Protocol.TreeControls.TreeControl.OverrideDisplayColumns)|[0, 1]|Used to override the display key or the index of a row by a different column of the same table.|
|&nbsp;&nbsp;[OverrideIconColumns](xref:Protocol.TreeControls.TreeControl.OverrideIconColumns)|[0, 1]|By specifying a column in this element, you can apply a custom icon based on a cell value in a row.|

## Remarks

> [!NOTE]
> The root table of a tree control always has to be displayed. From DataMiner 7.5.7 onwards, a position no longer needs to be added; you only need to specify RTDisplay = true.
