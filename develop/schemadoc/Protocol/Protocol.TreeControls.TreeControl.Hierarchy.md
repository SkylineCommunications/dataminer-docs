---
metadata_version: 1
uid: Protocol.TreeControls.TreeControl.Hierarchy
description: "Reference the DataMiner connector protocol schema entry for Hierarchy element, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
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
