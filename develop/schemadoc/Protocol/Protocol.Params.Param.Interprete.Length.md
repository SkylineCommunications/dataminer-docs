---
metadata_version: 1
uid: Protocol.Params.Param.Interprete.Length
description: "Reference the DataMiner connector protocol schema entry for Length element, including its documented structure, attributes, values, and constraints."
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

# Length element

Specifies the exact length of the parameter (in bytes).

## Type

unsignedInt

## Parent

[Interprete](xref:Protocol.Params.Param.Interprete)

## Remarks

If you set Protocol.Params.Param.Interprete.LengthType to “fixed”, use this tag to specify the exact length of the parameter (in bytes).

## Examples

```xml
<Length>5</Length>
```
