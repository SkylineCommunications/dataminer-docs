---
metadata_version: 1
uid: Protocol.Topology.Cell
description: "Reference the DataMiner connector protocol schema entry for Cell element, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
lifecycle: active
applies_to:
  - DataMiner
version: unknown
owner: unknown
review_status: needs_update
review_date: 2026-09-17
compatibility:
  uid: stable
  url: stable
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
