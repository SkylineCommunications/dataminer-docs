---
uid: LogicActionForceExecute
---

# force execute

This action can only be executed on a group.

This action will execute the specified group as soon as possible.

The ongoing content item (Action, Pair, Param, Session, or Trigger) of the ongoing group, if any, will finish.
Then the group you want to "force execute" will be executed in its entirety.
When done, the remaining items of the originally ongoing group will resume their execution.

Note that if some "force execute" actions were previously called and not yet executed, those will still have priority over potential new "force execute" action executions.

If no group was being executed, the "force execute" group will be added to the start of the group execution queue instead.

## Attributes

### On@id

Specifies the ID(s) of the group(s) to force execute/add to the group execution queue.

## Examples

```xml
<Action id="1">
  <On id="1">group</On>
  <Type>force execute</Type>
</Action>
```
