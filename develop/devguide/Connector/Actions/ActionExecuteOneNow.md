---
uid: LogicActionExecuteOneNow
description: "Use the 'execute one now' action to queue a group ahead of timer-scheduled groups in case it is not in the execution queue yet."
---

# execute one now

This action can only be executed on a group.

This action first checks if the specified group is already in the queue. If it is, nothing will happen. If it is not in the queue yet, this action will add the specified group to the end of the group execution queue, but before groups scheduled by a timer.

## Attributes

### On@id

Specifies the ID(s) of the group(s) to add to the group execution queue.

## Examples

```xml
<Action id="1">
  <On id="1">group</On>
  <Type>execute one now</Type>
</Action>
```

## Related actions

- [execute](xref:LogicActionExecute)
