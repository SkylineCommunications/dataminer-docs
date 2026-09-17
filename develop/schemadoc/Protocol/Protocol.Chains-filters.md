---
metadata_version: 1
uid: Protocol.Chains-filters
description: "Reference the DataMiner connector protocol schema entry for filters attribute, including its documented structure, attributes, values, and constraints."
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

# filters attribute

Determines the layout of the filters.

## Content Type

[EnumChainsFilters](xref:Protocol-EnumChainsFilters)

## Parent

[Chains](xref:Protocol.Chains)

## Remarks

Possible values: horizontal (= default if not specified) or vertical. In most integrations, `filters="vertical"` is used.
