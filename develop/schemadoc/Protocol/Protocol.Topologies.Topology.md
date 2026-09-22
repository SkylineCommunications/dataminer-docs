---
metadata_version: 1
uid: Protocol.Topologies.Topology
description: "Reference the DataMiner connector protocol schema entry for Topology element, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
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
