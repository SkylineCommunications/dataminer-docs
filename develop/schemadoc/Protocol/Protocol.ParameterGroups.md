---
metadata_version: 1
uid: Protocol.ParameterGroups
description: "Reference the DataMiner connector protocol schema entry for ParameterGroups element, including its documented structure, attributes, values, and constrain."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# ParameterGroups element

Defines the DataMiner Connectivity Framework (DCF) interfaces.<!-- RN 5663 -->

## Parent

[Protocol](xref:Protocol)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Group](xref:Protocol.ParameterGroups.Group)|[0, *]|Defines a parameter group.|

## Constraints

|Type|Description|Selector|Fields|
|--- |--- |--- |--- |
|Unique |The ID of a parameter group must be unique. |Group |@id |

## Remarks

Contains groups with a unique ID and a specific type.
