---
metadata_version: 1
uid: Protocol.Params.Param.Measurement.Threshold
description: "Reference the DataMiner connector protocol schema entry for Threshold element, including its documented structure, attributes, values, and constraints."
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

# Threshold element

Specifies a threshold.

## Type

double

## Parent

[Measurement](xref:Protocol.Params.Param.Measurement)

## Remarks

This element only has to be specified if Protocol.Params.Param.Measurement.Type is set to “threshold digital”.

In some cases, when only two states are allowed (e.g., "On" and "Off") but the parameter value lies within a range of values, a turnover point has to be defined (i.e., when value "On" is changed to "Off" and vice versa). This turnover point can be defined here. The actual "On" and "Off" values are defined as discrete entries.

## Examples

- A value lower than 30 will be interpreted as "Off".
- A value equal to or greater than 30 will be interpreted as "On".

```xml
<Threshold>30</Threshold>
```
