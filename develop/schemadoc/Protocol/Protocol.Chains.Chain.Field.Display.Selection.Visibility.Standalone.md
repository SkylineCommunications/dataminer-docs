---
metadata_version: 1
uid: Protocol.Chains.Chain.Field.Display.Selection.Visibility.Standalone
description: "Learn how the Standalone element maps trigger values to the opposite of default field selection visibility in a DataMiner connector protocol."
---

# Standalone element

Configures the values the referenced parameter should have in order to switch the visibility to the opposite setting of the one defined in the Visibility@default attribute.

## Parent

[Visibility](xref:Protocol.Chains.Chain.Field.Display.Selection.Visibility)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[pid](xref:Protocol.Chains.Chain.Field.Display.Selection.Visibility.Standalone-pid)|[TypeParamId](xref:Protocol-TypeParamId)|Yes|Refers to the trigger parameter.|

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Value](xref:Protocol.Chains.Chain.Field.Display.Selection.Visibility.Standalone.Value)|[1, *]|Each Value tag defines a value the parameter referred to in the Standalone@pid attribute must have to toggle the visibility to the opposite setting of the one defined in the Visibility@default attribute.|
