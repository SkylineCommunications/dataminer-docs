---
metadata_version: 1
uid: Protocol.Topology.Cell
description: "Reference the DataMiner connector protocol schema entry for Cell element, including its documented structure, attributes, values, and constraints."
content_type: schema
applies_to:
  - DataMiner
---

# Cell element

Specifies a cell within an EPM topology.

## Parent

[Topology](xref:Protocol.Topology)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[name](xref:Protocol.Topology.Cell-name)|string|Yes|Specifies the name of the cell.|
|[options](xref:Protocol.Topology.Cell-options)|string||Specifies a number of options (**Deprecated**).|
|[table](xref:Protocol.Topology.Cell-table)|string|Yes|Specifies the table parameter to which the cell is linked.|

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Link](xref:Protocol.Topology.Cell.Link)|[0, *]|Specifies how a cell in an EPM topology is linked to another cell in that topology, using foreign key relations (which can also be inside the same table).|
