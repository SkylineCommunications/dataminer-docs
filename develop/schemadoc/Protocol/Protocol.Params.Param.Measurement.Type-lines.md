---
metadata_version: 1
uid: Protocol.Params.Param.Measurement.Type-lines
description: "Reference the DataMiner connector protocol schema entry for lines attribute, including its documented structure, attributes, values, and constraints."
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

# lines attribute

Specifies the number of lines that will be displayed.

## Content Type

unsignedInt

## Parent

[Type](xref:Protocol.Params.Param.Measurement.Type)

## Remarks

Only to be specified in case of measurement type String.

> [!NOTE]
> When read parameters with multiple lines are displayed in the details pane of an EPM element, this attribute can be used to determine how many lines are displayed. See [details](xref:Protocol.Chains.Chain.Field-options#details).<!-- RN 10826 -->

## Examples

```xml
<Measurement>
    <Type lines="3">string</Type>
</Measurement>
```
