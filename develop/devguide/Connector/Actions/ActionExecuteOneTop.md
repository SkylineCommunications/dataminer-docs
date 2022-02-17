---
uid: LogicActionExecuteOneTop
---

# execute one top

Can only be executed on a group.

This action checks if the specified group is in the queue. If it is, nothing will happen. If it is not, then the group is added at the front of the queue.

## Attributes

### On@id

Specifies the ID(s) of the group(s).

## Examples

```xml
<Action id="1">
  <On id="1">group</On>
  <Type>execute one top</Type>
</Action>
```
