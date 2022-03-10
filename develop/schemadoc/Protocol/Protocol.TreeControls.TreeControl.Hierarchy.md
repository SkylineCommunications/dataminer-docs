---
uid: Protocol.TreeControls.TreeControl.Hierarchy
---

# Hierarchy element

Defines the relationship between the (visible) tables.

## Parent

[TreeControl](xref:Protocol.TreeControls.TreeControl)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[path](xref:Protocol.TreeControls.TreeControl.Hierarchy-path)|[TypeCommaSeparatedNumbers](xref:Protocol-TypeCommaSeparatedNumbers)||When no advanced hierarchy is needed, you can use this attribute to define the table links.|

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Table](xref:Protocol.TreeControls.TreeControl.Hierarchy.Table)|[0, *]|Specifies the table links.|

## Remarks

Rows from these tables will become items in the tree.
