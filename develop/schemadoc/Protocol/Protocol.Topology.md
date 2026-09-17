---
metadata_version: 1
uid: Protocol.Topology
description: "Reference the DataMiner connector protocol schema entry for Topology element, including its documented structure, attributes, values, and constraints."
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

# Topology element

Defines a topology. In this element, you can specify several Cell elements, each representing a cell in the diagram displayed in the EPM Manager.

## Parent

[Protocol](xref:Protocol)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Cell](xref:Protocol.Topology.Cell)|[0, *]|Specifies a cell within an EPM topology.|

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[name](xref:Protocol.Topology-name)|string||Specifies the name of the topology.|
