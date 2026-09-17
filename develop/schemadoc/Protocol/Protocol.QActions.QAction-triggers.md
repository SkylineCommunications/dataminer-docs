---
metadata_version: 1
uid: Protocol.QActions.QAction-triggers
description: "Reference the DataMiner connector protocol schema entry for triggers attribute, including its documented structure, attributes, values, and constraints."
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

# triggers attribute

Specifies the IDs of the parameters that will cause the QAction to be executed each time their value changes.

> [!TIP]
> See also: [Change-based event handling](xref:InnerWorkingsChangeBasedEventHandling)

## Content Type

[TypeSemicolonSeparatedNumbers](xref:Protocol-TypeSemicolonSeparatedNumbers)

## Parent

[QAction](xref:Protocol.QActions.QAction)

## Remarks

Multiple values have to be separated by semicolons (”;”).
