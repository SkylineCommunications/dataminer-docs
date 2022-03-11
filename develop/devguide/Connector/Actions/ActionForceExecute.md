---
uid: LogicActionForceExecute
---

# force execute

Can only be executed on a group.

This action will place the specified group at the front of the queue for immediate execution. If a group of pair is being executed, the execution of that group will be interrupted.

> [!CAUTION]
> Only use this action on a group of pairs, never in a timer, as this “force execute” group is only called when another group is being executed or when the queue is not empty. “force execute” is used with a trigger before/after command/response to execute the “force execute” group, for example with new settings before continuing the execution of the group that was being executed.

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
