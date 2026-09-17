---
metadata_version: 1
uid: LogicActionGo
description: "Describe the DataMiner connector development topic go, including its purpose, behavior, implementation guidance, and relevant constraints."
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

# go

This action can be executed on parameters only.

This action tells DataMiner to automatically re-enter the last value into the specified parameter. All triggers linked to this write parameter will then go off.

This action can be used to, for example, reset a write parameter when its value and the value of the associated read parameter are different, for example because of a power failure on the device.

## Attributes

### On@id

Specifies the ID(s) of the parameter(s).

## Examples

```xml
<Action id="1">
  <On id="1">parameter</On>
  <Type>go</Type>
</Action>
```
