---
metadata_version: 1
uid: Protocol.Chains.SearchChain.Tabs.Tab-name
description: "Reference the DataMiner connector protocol schema entry for name attribute, including its documented structure, attributes, values, and constraints."
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

# name attribute

Specifies the unique name of the tab within this search chain.

## Content Type

string

## Parent

[Tab](xref:Protocol.Chains.SearchChain.Tabs.Tab)

## Remarks

This attribute is optional. If this attribute is not present, the description of the referred table (via the tablePid attribute) is used.