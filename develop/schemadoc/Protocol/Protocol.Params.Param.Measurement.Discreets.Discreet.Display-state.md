---
metadata_version: 1
uid: Protocol.Params.Param.Measurement.Discreets.Discreet.Display-state
description: "Reference the DataMiner connector protocol schema entry for state attribute, including its documented structure, attributes, values, and constraints."
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

# state attribute

When Protocol.Params.Param.Interprete.Exceptions.Exception is used the same state needs to be placed in the write parameter.

## Content Type

[EnumDisplayState](xref:Protocol-EnumDisplayState)

## Parent

[Display](xref:Protocol.Params.Param.Measurement.Discreets.Discreet.Display)

## Examples

```xml
<Display state="disabled">Default Sweep Width</Display>
```
