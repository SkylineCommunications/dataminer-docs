---
uid: DMSScript.Script.Exe
---

# Exe element

Defines a script action.

## Parent

[Script](xref:DMSScript.Script)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[id](xref:DMSScript.Script.Exe-id)|positiveInteger|Yes|Specifies the unique ID of the parameter script variable.|
|[type](xref:DMSScript.Script.Exe-type)||Yes|Specifies the action type.|
|[destvar](xref:DMSScript.Script.Exe-destvar)|string||Specifies the destination variable.|

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***Choice***|||
|&nbsp;&nbsp;[Condition](xref:DMSScript.Script.Exe.Condition)|[0, *]|Specifies a condition.|
|&nbsp;&nbsp;[Destination](xref:DMSScript.Script.Exe.Destination)|[0, 1]|Specifies the destination|
|&nbsp;&nbsp;[Include](xref:DMSScript.Script.Exe.Include)|[0, 1]|Specifies an item to be included.|
|&nbsp;&nbsp;[MemoryPos](xref:DMSScript.Script.Exe.MemoryPos)|[0, 1]|Specifies the memory position to get or set.|
|&nbsp;&nbsp;[Message](xref:DMSScript.Script.Exe.Message)||Specifies the message.|
|&nbsp;&nbsp;[Param](xref:DMSScript.Script.Exe.Param)|[0, *]|Specifies a parameter.|
|&nbsp;&nbsp;[Protocol](xref:DMSScript.Script.Exe.Protocol)|[0, 1]|Specifies a dummy script variable.|
|&nbsp;&nbsp;[Script](xref:DMSScript.Script.Exe.Script)|[0, 1]|Specifies the name of the script.|
|&nbsp;&nbsp;[ScriptSuccess](xref:DMSScript.Script.Exe.ScriptSuccess)|[0, 1]|Specifies whether the script execution is considered successful (TRUE) or failed (FALSE).|
|&nbsp;&nbsp;[Template](xref:DMSScript.Script.Exe.Template)|[0, 1]|Specifies the name of the template.|
|&nbsp;&nbsp;[Timeout](xref:DMSScript.Script.Exe.Timeout)|[0, 1]|Specifies the timeout value.|
|&nbsp;&nbsp;[Type](xref:DMSScript.Script.Exe.Type)|[0, 1]|Specifies the state to which the dummy element has to be set.|
|&nbsp;&nbsp;[Value](xref:DMSScript.Script.Exe.Value)|[0, 1]|Specifies a value.|
