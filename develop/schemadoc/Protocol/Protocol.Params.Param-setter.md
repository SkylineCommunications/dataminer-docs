---
uid: Protocol.Params.Param-setter
---

# setter attribute

Specifies whether the value of the write parameter will be copied to the corresponding read parameter (without the need to add a trigger or an action). 

Imagine a read-write parameter combination which uses the setter=true option, and a trigger which goes off when the value of the write parameter changes. Knowing that the write parameter also triggers a QAction, the order of execution is the following:
1. First the regular trigger(s) on the write parameter will be executed. Actions executed by these trigger(s) will not see the read parameter value yet adapted to the new write parameter value. The read parameter will still have the old value at this point.
2. Then the copy action will be executed to the read parameter.
3. Then the QAction(s) on the write parameter will be executed. The read parameter will have the same value as the write parameter at this point.

## Content Type

[EnumTrueFalse](xref:Protocol-EnumTrueFalse)

## Parent

[Param](xref:Protocol.Params.Param)

## Remarks

Default value: false.

> [!NOTE]
>
> - If the button is part of a table and no corresponding read parameter is present, the write parameter may execute its triggers or actions a second time.

## Examples

```xml
<Param id="1" setter="true">
```
