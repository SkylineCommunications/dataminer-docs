---
metadata_version: 1
uid: Protocol.Relations.Relation-path
description: "Reference the DataMiner connector protocol schema entry for path attribute, including its documented structure, attributes, values, and constraints."
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

# path attribute

Specifies the IDs of the tables that are linked to each other.

## Content Type

[TypeSemicolonSeparatedNumbers](xref:Protocol-TypeSemicolonSeparatedNumbers)

## Parent

[Relation](xref:Protocol.Relations.Relation)

## Examples

```xml
<Relation path="100;200;300;400;500"/>
```
