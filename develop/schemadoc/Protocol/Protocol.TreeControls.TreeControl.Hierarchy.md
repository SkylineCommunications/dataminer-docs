---
metadata_version: 1
uid: Protocol.TreeControls.TreeControl.Hierarchy
description: "Consult the DataMiner connector protocol schema reference for the Hierarchy element, which defines relationships between visible tables in a tree control."
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
