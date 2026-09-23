---
metadata_version: 1
uid: Protocol.GeneralParameters
description: "Reference the DataMiner connector protocol schema entry for GeneralParameters element, including its documented structure, attributes, values, and constra."
content_type: schema
applies_to:
  - DataMiner
---

# GeneralParameters element

<!-- RN 12263 -->

Specifies which general parameter groups should be loaded or not.

## Parent

[Protocol](xref:Protocol)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[GeneralParameter](xref:Protocol.GeneralParameters.GeneralParameter)|[0, *]|Configures a general parameter group.|

## Constraints

|Type|Description|Selector|Fields|
|--- |--- |--- |--- |
|Unique |There must not be multiple GeneralParameterGroup children with the same group type. |GeneralParameter |@group |
