---
metadata_version: 1
uid: Protocol.PortSettings.Databits.Value
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

Using one or more Value elements, you can specify the different values that users are allowed to enter.

## Type

unsignedInt

## Parent

[Databits](xref:Protocol.PortSettings.Databits)

## Remarks

- The value specified in the DefaultValue tag does not have to be specified in a Value tag.
- When no Value tags are specified, users will only be allowed to enter the value specified in the DefaultValue tag.

## Examples

In the following example, the user can enter the values 7 and 8:

```xml
<Value>7</Value>
<Value>8</Value>
```
