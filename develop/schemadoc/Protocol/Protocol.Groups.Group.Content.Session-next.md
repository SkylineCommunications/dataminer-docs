---
metadata_version: 1
uid: Protocol.Groups.Group.Content.Session-next
description: "Reference the DataMiner connector protocol schema entry for next attribute, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
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

# next attribute

Specifies the number of milliseconds DataMiner has to wait after having received the response of the last executed session before executing the next session.

## Content Type

unsignedInt

## Parent

[Session](xref:Protocol.Groups.Group.Content.Session)

## Remarks

If the last item in the group contains this attribute, it will also cause a delay before the next group is executed.

## Examples

```xml
<Session next="1000">1</Session>
```
