---
metadata_version: 1
uid: Protocol.Chains.SearchChain.Tabs
description: "Reference the DataMiner connector protocol schema entry for Tabs element, including its documented structure, attributes, values, and constraints."
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

# Tabs element

Contains all tab definitions of this search chain.

## Parent

[SearchChain](xref:Protocol.Chains.SearchChain)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Tab](xref:Protocol.Chains.SearchChain.Tabs.Tab)|[1, *]|Defines a tab.|

## Constraints

|Type|Description|Selector|Fields|
|--- |--- |--- |--- |
|Unique |The name of a tab must be unique within a search chain. |child::* |@name |
