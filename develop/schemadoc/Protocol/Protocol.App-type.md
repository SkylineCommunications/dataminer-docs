---
metadata_version: 1
uid: Protocol.App-type
description: "Reference the DataMiner connector protocol schema entry for type attribute, including its documented structure, attributes, values, and constraints."
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

# type attribute

Specifies the name of the DataMiner app.

## Content Type

[TypeNonEmptyString](xref:Protocol-TypeNonEmptyString)

## Parent

[App](xref:Protocol.App)

## Examples

```xml
<App type="IP Network Manager"/>
```
