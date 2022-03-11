---
uid: DMSScript.Script.Exe.Param
---

# Param element

Specifies a parameter.

## Type

string

## Parent

[Exe](xref:DMSScript.Script.Exe)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[protocol](xref:DMSScript.Script.Exe.Param-protocol)|positiveInteger||Specifies the ID of the dummy script variable that is referred to.|
|[type](xref:DMSScript.Script.Exe.Param-type)|string||Specifies the type of data this parameter holds.|

## Remarks

Used with script actions of type "assigndummy", "csharp", "get", "script", "set".
