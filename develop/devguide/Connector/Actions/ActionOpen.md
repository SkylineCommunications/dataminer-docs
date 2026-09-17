---
metadata_version: 1
uid: LogicActionOpen
description: "Describe the DataMiner connector development topic open, including its purpose, behavior, implementation guidance, and relevant constraints."
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

# open

This action must be executed on protocol.

This action opens the port of which the connection number is specified in the nr attribute of the Type tag.

> [!NOTE]
> Only applicable to serial connectors.

## Attributes

### Type@nr

(optional): Specifies the connection number.

Default: 0.

## Examples

```xml
<Action id="40001">
  <On>protocol</On>
  <Type nr="1">open</Type>
</Action>
```
