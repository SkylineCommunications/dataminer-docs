---
metadata_version: 1
uid: Protocol.Topologies.Topology
description: "Consult the DataMiner connector protocol schema reference for the Topology element, which defines the cells represented in an EPM element diagram."
---

# Topology element

Defines a topology.

> [!TIP]
> See also: [EPM topology configuration](xref:EPMManagerTopology)

## Parent

[Topologies](xref:Protocol.Topologies)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[name](xref:Protocol.Topologies.Topology-name)|string||Specifies the name of the topology.|

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Cell](xref:Protocol.Topologies.Topology.Cell)|[0, *]|Specifies a cell within an EPM topology.|

## Remarks

Contains several Cell tags, each representing a cell in the diagram displayed in the EPM element.
