---
metadata_version: 1
uid: Protocol.Params.Param.Interprete.Others.Other-id
description: "Reference the DataMiner connector protocol schema entry for id attribute, including its documented structure, attributes, values, and constraints."
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

# id attribute

Specifies the ID of the parameter to which the incoming symbol will be compared with.

## Content Type

[TypeParamId](xref:Protocol-TypeParamId)

## Parent

[Other](xref:Protocol.Params.Param.Interprete.Others.Other)

## Remarks

If the incoming symbol matches the referred parameter, the contents of the Protocol.Params.Param.Interprete.Others.Other.Display tag will be shown.

## Examples

```xml
<Other id="1115">
```
