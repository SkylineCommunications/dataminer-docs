---
uid: Protocol.GeneralParameters
---

# GeneralParameters element

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

## Remarks

*Feature introduced in DataMiner 9.0.1 (RN 12263).*
