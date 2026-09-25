---
metadata_version: 1
uid: Protocol.Chains.SearchChain.Tabs.Tab.Display.Visibility.Standalone
description: "Learn how the Standalone element maps trigger values to the opposite of default search tab visibility in a DataMiner connector protocol."
---

# Standalone element

Configures the values the referenced parameter should have in order to switch the visibility to the opposite setting of the one defined in the Visibility@default attribute.

## Parent

[Visibility](xref:Protocol.Chains.SearchChain.Tabs.Tab.Display.Visibility)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[pid](xref:Protocol.Chains.SearchChain.Tabs.Tab.Display.Visibility.Standalone-pid)|[TypeParamId](xref:Protocol-TypeParamId)|Yes|Refers to the trigger parameter.|

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Value](xref:Protocol.Chains.SearchChain.Tabs.Tab.Display.Visibility.Standalone.Value)|[1, *]|Specifies one of the possible values the specified parameter must have to toggle the visibility to the opposite setting of the one defined in the default attribute.|
