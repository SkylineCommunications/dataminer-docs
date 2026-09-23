---
metadata_version: 1
uid: Protocol.ParameterGroups.Group.Params
description: "Learn how to use the Params element to list the parameters included in a parameter group without duplicate IDs in a DataMiner connector protocol."
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
