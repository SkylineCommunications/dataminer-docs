---
metadata_version: 1
uid: LogicActionExecuteOne
description: "Describe the DataMiner connector development topic execute one, including its purpose, behavior, implementation guidance, and relevant constraints."
area: develop
content_type: conceptual
authority: unknown
authority_source: unknown
lifecycle: active
applies_to:
  - DataMiner
version: unknown
owner: unknown
review_status: needs_update
review_date: 2026-09-17
compatibility:
  uid: stable
  url: stable
---

# execute one

This action can only be executed on a group.

This action first checks if the specified group is already in the queue. If it is, nothing will happen. If it is not already in the queue, this action will add the specified group to the end of the group execution queue, after groups scheduled by a timer.

## Attributes

### On@id

Specifies the ID(s) of the group(s) to add to the group execution queue.

## Examples

```xml
<Action id="1">
  <On id="1">group</On>
  <Type>execute one</Type>
</Action>
```

## Related actions

- [add to execute](xref:LogicActionAddToExecute)
