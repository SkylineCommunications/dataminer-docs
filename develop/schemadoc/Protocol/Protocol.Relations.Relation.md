---
metadata_version: 1
uid: Protocol.Relations.Relation
description: "Reference the DataMiner connector protocol schema entry for Relation element, including its documented structure, attributes, values, and constraints."
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

# Relation element

Defines a relation between tables.

## Parent

[Relations](xref:Protocol.Relations)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[options](xref:Protocol.Relations.Relation-options)|string||Defines a number of options.|
|[path](xref:Protocol.Relations.Relation-path)|[TypeSemicolonSeparatedNumbers](xref:Protocol-TypeSemicolonSeparatedNumbers)|Yes|Specifies the IDs of the tables that are linked to each other.|
|[name](xref:Protocol.Relations.Relation-name)|string||Specifies the name of the relation.|
