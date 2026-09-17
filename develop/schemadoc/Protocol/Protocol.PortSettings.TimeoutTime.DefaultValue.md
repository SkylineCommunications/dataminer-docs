---
metadata_version: 1
uid: Protocol.PortSettings.TimeoutTime.DefaultValue
description: "Reference the DataMiner connector protocol schema entry for DefaultValue element, including its documented structure, attributes, values, and constraints."
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

# DefaultValue element

Specifies the default timeout value.

## Type

|Item|Facet value|Description|
|--- |--- |--- |
|***unsignedInt restriction***|||
|&nbsp;&nbsp;Min exclusive|10||
|&nbsp;&nbsp;Max exclusive|120000||

## Parent

[TimeoutTime](xref:Protocol.PortSettings.TimeoutTime)

## Remarks

The value is a number of milliseconds.

## Examples

```xml
<TimeoutTime>
    <DefaultValue>10000</DefaultValue>
</TimeoutTime>
```
