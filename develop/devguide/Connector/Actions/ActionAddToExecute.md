---
uid: LogicActionAddToExecute
---

# add to execute

This action can only be executed on a group.

This action will add the specified group to the end of the group execution queue, after groups scheduled by a timer.

## Attributes

### On@id

Specifies the ID(s) of the group(s) to add to the group execution queue.

## Examples

```xml
<Action id="1">
   <On id="1">group</On>
   <Type>add to execute</Type>
</Action>
```

## Related actions

- [execute one](xref:LogicActionExecuteOne)
