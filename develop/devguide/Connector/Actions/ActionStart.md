---
metadata_version: 1
uid: LogicActionStart
description: "Describe the DataMiner connector development topic start, including its purpose, behavior, implementation guidance, and relevant constraints."
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

# start

This action can be executed on timers only.

This action starts the specified timers.

## Attributes

### On@id

Specifies the ID(s) of the timer(s) to start.

## Examples

```xml
<Action id="1">
   <On id="1">timer</On>
   <Type>start</Type>
</Action>
```
