---
uid: Protocol.Topologies.Topology.Cell
---

# Cell element

Specifies a cell within a CPE topology.

> [!TIP]
> See also: [EPM topology configuration](xref:EPMManagerTopology)

## Parent

[Topology](xref:Protocol.Topologies.Topology)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[detailColumns](xref:Protocol.Topologies.Topology.Cell-detailColumns)|string||*** No documentation available yet ***|
|[listColumns](xref:Protocol.Topologies.Topology.Cell-listColumns)|string||*** No documentation available yet ***|
|[name](xref:Protocol.Topologies.Topology.Cell-name)|string|Yes|Specifies the name of the cell.|
|[options](xref:Protocol.Topologies.Topology.Cell-options)|string||Specifies a number of options (**Deprecated**).|
|[table](xref:Protocol.Topologies.Topology.Cell-table)|string|Yes|Specifies the table parameter to which the cell is linked.|

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Link](xref:Protocol.Topologies.Topology.Cell.Link)|[0, *]||
