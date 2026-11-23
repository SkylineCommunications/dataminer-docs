---
uid: Protocol.Chains.SearchChain.Tabs.Tab.Display.Visibility
description: "Use the Visibility element in a DataMiner protocol to combine a default setting with trigger conditions for search tab visibility."
---

# Visibility element

Configures chain tab visibility settings.

## Parent

[Display](xref:Protocol.Chains.SearchChain.Tabs.Tab.Display)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[default](xref:Protocol.Chains.SearchChain.Tabs.Tab.Display.Visibility-default)|||Specifies the default visibility when none of the conditions are met (default: true).|

## Children

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Standalone](xref:Protocol.Chains.SearchChain.Tabs.Tab.Display.Visibility.Standalone)|[1, *]|Configures the values the referenced parameter should have in order to switch the visibility to the opposite setting of the one defined in the Visibility@default attribute.|
