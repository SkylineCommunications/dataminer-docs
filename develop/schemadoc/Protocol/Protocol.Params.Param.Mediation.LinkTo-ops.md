---
metadata_version: 1
uid: Protocol.Params.Param.Mediation.LinkTo-ops
description: "Reference the DataMiner connector protocol schema entry for ops attribute, including its documented structure, attributes, values, and constraints."
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

# ops attribute

Specifies one or more conversion operations separated by semicolons (`;`).

## Content Type

string

## Parent

[LinkTo](xref:Protocol.Params.Param.Mediation.LinkTo)

## Remarks

Supported operations:

| Operation | Description |
|-----------|-------------|
| *         | Factor      |
| /         | Devision    |
| -         | Minus       |
| +         | Offset      |
| %         | Remainder   |

## Examples

```xml
<LinkTo pid="176" protocol="Philips DVS3810" ops="*:1024;+:5" />
```
