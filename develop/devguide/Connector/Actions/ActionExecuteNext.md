---
uid: LogicActionExecuteNext
---

# execute next

This action can only be executed on a group.

This action will add the specified group to the start of the group execution queue, right after the group that is currently being executed.

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

## Related Actions
- [execute one top](xref:LogicActionExecuteOneTop)
