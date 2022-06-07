---
uid: LogicActionForceExecute
---

# force execute

Can only be executed on a group.

"force execute" will make sure the group is executed as soon as possible.

The ongoing content item (Action, Pair, Param, Session, or Trigger) of the ongoing group (if any) will finish, then the group you want to "force execute" will be executed, and then the remaining items of the originally ongoing group will be executed.

Note that if some "force execute" actions were previously called and not yet executed, those will still have priority over potential new "force execute" action executions.

If no group was being executed, the "force execute" group will be added at the front of the queue.

## Attributes

### On@id

Specifies the ID(s) of the group(s).

## Examples

```xml
<Action id="1">
  <On id="1">group</On>
  <Type>force execute</Type>
</Action>
```
