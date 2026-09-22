---
metadata_version: 1
uid: LogicActionExecuteNext
description: "Describe the DataMiner connector development topic execute next, including its purpose, behavior, implementation guidance, and relevant constraints."
area: develop
content_type: conceptual
authority: unknown
authority_source: unknown
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# execute next

This action can only be executed on a group.

This action will add the specified group to the start of the group execution queue, right after the group that is currently being executed.

## Attributes

### On@id

Specifies the ID(s) of the group(s) to add to the group execution queue.

## Examples

```xml
<Action id="1">
  <On id="1">group</On>
  <Type>execute next</Type>
</Action>
```

## Related actions

- [execute one top](xref:LogicActionExecuteOneTop)
