---
metadata_version: 1
uid: Protocol.ParameterGroups
description: "Learn how to use the ParameterGroups element to define the DCF interfaces exposed by the connector in a DataMiner connector protocol."
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
