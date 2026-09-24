---
metadata_version: 1
uid: Protocol.Chains.Chain.Display.Visibility
description: "Learn how the Visibility element combines a default setting with parameter-based conditions for chain visibility in a DataMiner connector protocol."
---

# Visibility element



## Parent

[Display](xref:Protocol.Chains.Chain.Display)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[default](xref:Protocol.Chains.Chain.Display.Visibility-default)|||Specifies the default visibility when none of the conditions are met (Default: true).|

## Children

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Standalone](xref:Protocol.Chains.Chain.Display.Visibility.Standalone)|[1, *]|Specifies the values the specified parameter must have to toggle the visibility to the opposite setting of the one defined in the default attribute.|
