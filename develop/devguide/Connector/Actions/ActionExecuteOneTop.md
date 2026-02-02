---
uid: LogicActionExecuteOneTop
---

# execute one top

This action can only be executed on a group.

This action first checks if the specified group is already in the queue. If it is, nothing will happen.
If it is not already in the queue, this action will add the specified group to the start of the group execution queue, right after the group that is currently being executed.

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

## Related Actions
- [execute next](xref:LogicActionExecuteNext)
