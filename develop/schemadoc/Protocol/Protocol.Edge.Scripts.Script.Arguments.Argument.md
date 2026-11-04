---
uid: Protocol.Edge.Scripts.Script.Arguments.Argument
description: "Use an Argument element in a DataMiner protocol to define an input value passed to an Edge script when it starts."
---

# Argument element

Specifies an input argument that will be passed to the script when it is started.

## Parent

[Arguments](xref:Protocol.Edge.Scripts.Script.Arguments)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[SettingRef](xref:Protocol.Edge.Scripts.Script.Arguments.Argument.SettingRef)||Specifies the setting whose value has to be used as the value of this argument.|

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[name](xref:Protocol.Edge.Scripts.Script.Arguments.Argument-name)|[TypeNonEmptyString](xref:Protocol-TypeNonEmptyString)|Yes|Specifies the name under which the argument value is made available to the script. The script can use this name to retrieve the value.|
