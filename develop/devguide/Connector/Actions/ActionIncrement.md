---
metadata_version: 1
uid: LogicActionIncrement
description: "Describe the DataMiner connector development topic increment, including its purpose, behavior, implementation guidance, and relevant constraints."
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

# increment

This action can be executed on parameters only.

This action increments the specified parameter with the specified value.

## Attributes

### On@id

Specifies the ID(s) of the parameter(s) that need to be incremented.

### Type@value

(optional): The increment value. Default: 1.

## Examples

```xml
<Action id="104">
  <On id="104">parameter</On>
  <Type value="10">increment</Type>
</Action>
```
