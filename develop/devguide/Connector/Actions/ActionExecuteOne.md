---
uid: LogicActionExecuteOne
---

# execute one

Can only be executed on a group.

This action checks if the specified group is present in the queue. If it is, nothing will happen. If it is not, then the group is added at the very end of the queue, after the timer actions.

## Attributes

### On@id

Specifies the ID(s) of the group(s).

## Examples

```xml
<Action id="1">
  <On id="1">group</On>
  <Type>execute one</Type>
</Action>
```
