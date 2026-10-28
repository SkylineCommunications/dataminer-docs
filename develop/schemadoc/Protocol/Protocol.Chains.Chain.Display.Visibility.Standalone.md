---
uid: Protocol.Chains.Chain.Display.Visibility.Standalone
description: "Use the Standalone element in a DataMiner protocol to map parameter values to the opposite of the configured default chain visibility."
---

# Standalone element

Specifies the values the specified parameter must have to toggle the visibility to the opposite setting of the one defined in the default attribute.

## Parent

[Visibility](xref:Protocol.Chains.Chain.Display.Visibility)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[pid](xref:Protocol.Chains.Chain.Display.Visibility.Standalone-pid)|[TypeParamId](xref:Protocol-TypeParamId)|Yes||

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Value](xref:Protocol.Chains.Chain.Display.Visibility.Standalone.Value)|[1, *]|Specifies one of the possible values the specified parameter must have to toggle the visibility to the opposite setting of the one defined in the default attribute.|
