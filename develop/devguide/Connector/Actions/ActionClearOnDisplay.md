---
metadata_version: 1
uid: LogicActionClearOnDisplay
description: "Describe the DataMiner connector development topic clear on display, including its purpose, behavior, implementation guidance, and relevant constraints."
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

# clear on display

This action can be executed on parameters only.

This action clears the displayed value of the parameter. Consequently, in the user interface, the value will be displayed as "Not initialized".

This action is normally used in combination with the "clear" action, which clears the value in memory.

## Attributes

### On@id

Specifies the ID(s) of the parameter(s) of which the displayed value needs to be cleared.

## Examples

```xml
<Action id="1">
   <On id="1">parameter</On>
   <Type>clear on display</Type>
</Action>
```
