---
metadata_version: 1
uid: LogicActionSave
description: "Describe the DataMiner connector development topic save, including its purpose, behavior, implementation guidance, and relevant constraints."
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

# save

This action can be executed on parameters only.

This action allows you to save the value of a certain parameter. When DataMiner is restarted, the saved parameter will display its last known value.

## Attributes

### On@id

The ID of the parameter(s) that need to be saved.

## Examples

```xml
<Action id="1101">
  <On id="1001">parameter</On>
  <Type>save</Type>
</Action>
```
