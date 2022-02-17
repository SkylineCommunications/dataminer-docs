---
uid: LogicActionAddToExecute
---

# add to execute

This action can only be executed on a group.

The action will place the specified group at the very end of the group execution queue, after the timer actions.

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
