---
uid: DMSScript.Script.Exe.Value
---

# Value element

Specifies a value.

## Type

string

When used with script actions of type "assigndummy", the specified value should contain either the Agent ID and element ID formatted as "agentID/elementID" or the element name.

When used with script actions of type "csharp", the value specifies the C# code to execute.

When used with script actions of type "settemplate", the value specifies the template name.

When used with script actions of type "clearmemory", the value specifies the memory file ID.

When used with script actions of type "goto", the value specifies the label to transfer execution to.

When used with script actions of type "label", the value specifies the label.

When used with script actions of type "set", the value specifies the value to set.

When used with script actions of type "ui", the value specifies the UI.

## Parent

[Exe](xref:DMSScript.Script.Exe)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[ref](xref:DMSScript.Script.Exe.Value-ref)|string||Refers to an item. The item that is referred to depends on the type of script action.|
|[offset](xref:DMSScript.Script.Exe.Value-offset)|double||Specifies the offset to use.|

## Remarks

Used with script actions of type "assigndummy",  "csharp", "settemplate", "clearmemory", "get", "goto", "label", "set", "ui".
