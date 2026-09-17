---
metadata_version: 1
uid: Protocol.Params.Param.CRC.Type-totaloffset
description: "Reference the DataMiner connector protocol schema entry for totaloffset attribute, including its documented structure, attributes, values, and constraints."
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

# totaloffset attribute

Specifies an offset value to be added to the CRC after it has been calculated.

## Content Type

unsignedInt

## Parent

[Type](xref:Protocol.Params.Param.CRC.Type)

## Remarks

> [!NOTE]
> The totaloffset attribute is executed after the mod attribute. See also [Internal calculation sequence](xref:Protocol.Params.Param.CRC.Type#internal-calculation-sequence).

## Examples

```xml
<Param>
  <CRC>
     <Type totaloffset="32">
     ...
```
