---
uid: DMSScript.Script.Exe.Type
---

# Type element

Specifies the state to which the dummy element has to be set.

## Type

When used with script actions of type "settemplate" one of the following values:

- alarm
- trending

When used with script action of type "get" or "set", the only possible value is "memory".

When used with script actions of type "if", the value is "conditions".

When used with script actions of type "changestate", one of the following values:

- start
- stop
- restart
- pause
- mask
- unmask

## Parent

[Exe](xref:DMSScript.Script.Exe)

## Remarks

Used with script actions of type "settemplate", "get", "if", "set", "changestate".
