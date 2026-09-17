---
metadata_version: 1
uid: LogicActionClearLengthInfo
description: "Describe the DataMiner connector development topic clear length info, including its purpose, behavior, implementation guidance, and relevant constraints."
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

# clear length info

This action can be executed on responses only.

This action can be used when the header or the trailer need to be adjusted. If a length parameter gets new info, for example, then this action must be executed on the response.

## Attributes

### On@id

Specifies the ID(s) of the responses(s) of which the length info must be cleared.

## Examples

```xml
<Action id="1">
   <On id="501">response</On>
   <Type>clear length info</Type>
</Action>
```
