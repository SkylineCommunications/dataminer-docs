---
metadata_version: 1
uid: LogicActionPow
description: "Describe the DataMiner connector development topic pow, including its purpose, behavior, implementation guidance, and relevant constraints."
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

# pow

This action can be executed on parameters only.

This action raises the value by the exponent.

## Attributes

### On@id

Specifies the ID(s) of the parameter(s) on which the action needs to be performed.

### Type@value

The exponent.

Default: 1.

## Examples

```xml
<Action id="1">
  <On id="5000">parameter</On>
  <Type value="1">pow</Type>
</Action>
```
