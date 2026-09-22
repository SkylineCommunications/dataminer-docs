---
metadata_version: 1
uid: DMSScript.Parameters.ScriptParameter
description: "Reference the DataMiner Automation script schema entry for ScriptParameter element, including its documented structure, attributes, values, and constraint."
area: develop
content_type: schema
authority: reference
authority_source: SchemaAutomationScript
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# ScriptParameter element

Defines a parameter script variable. Parameter script variables are typically used to get input from the outside world, e.g., from an operator.

## Parent

[Parameters](xref:DMSScript.Parameters)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[id](xref:DMSScript.Parameters.ScriptParameter-id)|unsignedInt|Yes|Specifies the unique ID of the parameter script variable.|
|[type](xref:DMSScript.Parameters.ScriptParameter-type)|string|Yes|Specifies the parameter type.|
|[values](xref:DMSScript.Parameters.ScriptParameter-values)|string|Yes|Specifies the name of the memory file that holds the values to choose from.|

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Description](xref:DMSScript.Parameters.ScriptParameter.Description)||Specifies the name of the parameter script variable.|

## Remarks

At runtime, retrieve the value of a script parameter with `IEngine.GetScriptParam` by name or ID. The returned [ScriptParam](xref:Skyline.DataMiner.Automation.ScriptParam) is supplied by DataMiner; do not construct it in application code. Its `Value` is a string. For the behavior when C# code accesses an undefined or empty value, see [RunTimeFlags.AllowUndef](xref:Skyline.DataMiner.Automation.RunTimeFlags.AllowUndef).
