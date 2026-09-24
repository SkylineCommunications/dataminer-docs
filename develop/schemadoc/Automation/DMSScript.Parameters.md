---
metadata_version: 1
uid: DMSScript.Parameters
description: "Use the Parameters element to contain an automation script's parameter variables and ensure that each ScriptParameter ID is unique."
---

# Parameters element

Contains the parameter script variables defined in the script.

## Parent

[DMSScript](xref:DMSScript)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[ScriptParameter](xref:DMSScript.Parameters.ScriptParameter)|[0, *]|Defines a parameter script variable. Parameter script variables are typically used to get input from the outside world, e.g., from an operator.|

## Constraints

|Type|Description|Selector|Fields
|--- |--- |--- |--- |
|Unique |The ID must be unique. |Parameters |@id |
