---
uid: DMSScript.Parameters.ScriptParameter
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
