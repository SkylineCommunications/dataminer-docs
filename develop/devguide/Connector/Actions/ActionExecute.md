---
uid: LogicActionExecute
---

# execute

Can only be executed on a group.

This action will add the specified group to the group execution queue, after the last group, but before the timer actions.

## Attributes

### On@id

Specifies the ID(s) of the group(s).

## Examples

```xml
<Action id="1">
  <On id="1">group</On>
  <Type>execute</Type>
</Action>
```
