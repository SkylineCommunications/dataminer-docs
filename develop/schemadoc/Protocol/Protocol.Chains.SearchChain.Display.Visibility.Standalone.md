---
uid: Protocol.Chains.SearchChain.Display.Visibility.Standalone
---

# Standalone element

Contains Value children that define a value that the parameter referred to in the Standalone@pid attribute must have to toggle the visibility to the opposite setting of the one defined in the Visibility@default attribute.

## Parent

[Visibility](xref:Protocol.Chains.SearchChain.Display.Visibility)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[pid](xref:Protocol.Chains.SearchChain.Display.Visibility.Standalone-pid)|[TypeParamId](xref:Protocol-TypeParamId)|Yes|Refers to the trigger parameter.|

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Value](xref:Protocol.Chains.SearchChain.Display.Visibility.Standalone.Value)|[1, *]|Specifies one of the possible values the specified parameter must have to toggle the visibility to the opposite setting of the one defined in the default attribute.|
