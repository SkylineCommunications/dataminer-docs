---
metadata_version: 1
uid: Protocol.Chains.SearchChain.Tabs.Tab.Fields
description: "Reference the DataMiner connector protocol schema entry for Fields element, including its documented structure, attributes, values, and constraints."
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

# Fields element

Contains the definition of the fields to be included in this search tab.

## Parent

[Tab](xref:Protocol.Chains.SearchChain.Tabs.Tab)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Field](xref:Protocol.Chains.SearchChain.Tabs.Tab.Fields.Field)|[0, *]||

## Constraints

|Type|Description|Selector|Fields|
|--- |--- |--- |--- |
|Unique |The name of a field must be unique within a tab. |child::* |@name |
