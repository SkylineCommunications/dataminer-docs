---
uid: Protocol.Chains.SearchChain.Display.Visibility
---

# Visibility element

Configures search chain visibility settings.

## Parent

[Display](xref:Protocol.Chains.SearchChain.Display)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[default](xref:Protocol.Chains.SearchChain.Display.Visibility-default)|||Specifies the default visibility when none of the conditions are met (Default: true).|

## Children

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Standalone](xref:Protocol.Chains.SearchChain.Display.Visibility.Standalone)|[1, *]|Specifies the values the specified parameter must have to toggle the visibility to the opposite setting of the one defined in the default attribute.|
