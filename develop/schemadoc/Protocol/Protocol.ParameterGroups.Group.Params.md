---
metadata_version: 1
uid: Protocol.ParameterGroups.Group.Params
description: "Reference the DataMiner connector protocol schema entry for Params element, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# Params element

Specifies the parameters that are included in the group.

## Parent

[Group](xref:Protocol.ParameterGroups.Group)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Param](xref:Protocol.ParameterGroups.Group.Params.Param)|[0, *]|Specifies a parameter that is included in the group.|

## Constraints

|Type|Description|Selector|Fields|
|--- |--- |--- |--- |
|Unique |The parameters referred to in a parameter group must not contain duplicate entries. |Param |@id |
