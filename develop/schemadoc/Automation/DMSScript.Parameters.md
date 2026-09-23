---
metadata_version: 1
uid: DMSScript.Parameters
description: "Reference the DataMiner Automation script schema entry for Parameters element, including its documented structure, attributes, values, and constraints."
content_type: schema
applies_to:
  - DataMiner
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
