---
metadata_version: 1
uid: Protocol.Params.Param.Interprete.Others.Other.Value
description: "Reference the DataMiner connector protocol schema entry for Value element, including its documented structure, attributes, values, and constraints."
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

# Value element

Adds a numeric value to the parameter, which can be useful in case you want to show an alarm when this rare condition occurs.

## Type

integer >= 10

## Parent

[Other](xref:Protocol.Params.Param.Interprete.Others.Other)

## Examples

```xml
<Value>10</value>
```
