---
uid: LogicActionExecuteNext
---

# execute next

Can only be executed on a group.

This action will add the specified group to the group execution queue, at the very front, right after the group that is currently being executed.

## Attributes

### On@id

Specifies the ID(s) of the group(s).

## Examples

```xml
<Action id="1">
  <On id="1">group</On>
  <Type>execute next</Type>
</Action>
```
