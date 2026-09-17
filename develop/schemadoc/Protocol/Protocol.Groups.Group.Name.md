---
metadata_version: 1
uid: Protocol.Groups.Group.Name
description: "Reference the DataMiner connector protocol schema entry for Name element, including its documented structure, attributes, values, and constraints."
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

# Name element

Specifies the name of the group.

## Type

[TypeNonEmptyString](xref:Protocol-TypeNonEmptyString)

## Parent

[Group](xref:Protocol.Groups.Group)

## Remarks

This name could, for example, refer to the information that will be requested from the data source.

## Examples

```xml
<Name>Name of the group</Name>
```
