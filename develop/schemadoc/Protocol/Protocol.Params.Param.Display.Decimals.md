---
metadata_version: 1
uid: Protocol.Params.Param.Display.Decimals
description: "Reference the DataMiner connector protocol schema entry for Decimals element, including its documented structure, attributes, values, and constraints."
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

# Decimals element

Defines the number of decimals to be used to display the parameter value on the user interface.

## Type

unsignedInt

## Parent

[Display](xref:Protocol.Params.Param.Display)

## Remarks

In case the number of decimals is not specified, no rounding will occur. Only if scientific notation is used (see [scientificNotation](xref:Protocol.Params.Param.Measurement.Type-scientificNotation)), the absence of the Decimals tag will be interpreted as 0 decimals (RN 12600).

## Examples

```xml
<Decimals>2</Decimals>
```
