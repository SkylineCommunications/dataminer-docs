---
uid: LogicActionExecuteOneNow
---

# execute one now

Can only be executed on a group.

This action checks if the specified group is in the queue. If it is, nothing will happen. If it is not, then the group is added to the queue after other explicitly added groups, but before groups scheduled by a timer.

## Attributes

### On@id

Specifies the ID(s) of the group(s).

## Examples

```xml
<Action id="1">
  <On id="1">group</On>
  <Type>execute one now</Type>
</Action>
```
