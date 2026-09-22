---
metadata_version: 1
uid: Protocol.Params.Param.Dependencies
description: "Reference the DataMiner connector protocol schema entry for Dependencies element, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
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
