---
uid: Protocol.Params.Param.Dependencies
---

# Dependencies element

Allows you to link one or more parameters.

## Parent

[Param](xref:Protocol.Params.Param)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Id](xref:Protocol.Params.Param.Dependencies.Id)|[0, *]|Specifies the IDs of the parameters that are linked to this parameter.|

## Remarks

This is mostly used for situations in which clicking a button executes a command that includes several parameters. Execution of such a command will only proceed if all dependent parameters have a valid value.

Linked parameters must have their [RTDisplay](xref:Protocol.Params.Param.Display.RTDisplay) tag set to true.
