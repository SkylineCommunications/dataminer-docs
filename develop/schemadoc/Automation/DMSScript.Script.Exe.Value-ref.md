---
uid: DMSScript.Script.Exe.Value-ref
---

# ref attribute

Refers to an item. The item that is referred to depends on the type of script action.

## Content Type

string

When used with script actions of type "assigndummy",  "settemplate" or "set", the value specifies a script variable.

When used with script action of type "clearmemory", the value specifies the ID of the memory.

## Parent

[Value](xref:DMSScript.Script.Exe.Value)

## Remarks

Used with script actions of type "assigndummy",  "csharp", "settemplate", "clearmemory", "get", "goto", "label", "set", "ui".
