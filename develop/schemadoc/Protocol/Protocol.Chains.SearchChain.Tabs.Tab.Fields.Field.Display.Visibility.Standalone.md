---
metadata_version: 1
uid: Protocol.Chains.SearchChain.Tabs.Tab.Fields.Field.Display.Visibility.Standalone
description: "Reference the DataMiner connector protocol schema entry for Standalone element, including its documented structure, attributes, values, and constraints."
content_type: schema
applies_to:
  - DataMiner
---

# Standalone element

Configures the values the referenced parameter should have in order to switch the visibility to the opposite setting of the one defined in the Visibility@default attribute.

## Parent

[Visibility](xref:Protocol.Chains.SearchChain.Tabs.Tab.Fields.Field.Display.Visibility)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[pid](xref:Protocol.Chains.SearchChain.Tabs.Tab.Fields.Field.Display.Visibility.Standalone-pid)|[TypeParamId](xref:Protocol-TypeParamId)|Yes|Refers to the trigger parameter.|

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Value](xref:Protocol.Chains.SearchChain.Tabs.Tab.Fields.Field.Display.Visibility.Standalone.Value)|[1, *]|Each Value tag defines a value the parameter referred to in the Standalone@pid attribute must have to toggle the visibility to the opposite setting of the one defined in the Visibility@default attribute.|
