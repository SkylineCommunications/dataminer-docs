---
metadata_version: 1
uid: Protocol.Params.Param.Replication.Element
description: "Reference the DataMiner connector protocol schema entry for Element element, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# Element element

Specifies the DataMiner Agent ID/element ID of the replicated element.

## Type

string

## Parent

[Replication](xref:Protocol.Params.Param.Replication)

## Attributes

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Type|Required|Description|
|--- |--- |--- |--- |
|[dynamic](xref:Protocol.Params.Param.Replication.Element-dynamic)|unsignedInt||Specifies the ID of the parameter that holds the element ID (DMA ID/element ID) of the element from which the parameter should be replicated.|
