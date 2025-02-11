---
uid: Protocol.GeneralParameters
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
