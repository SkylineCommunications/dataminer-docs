---
uid: Protocol.ParameterGroups
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
