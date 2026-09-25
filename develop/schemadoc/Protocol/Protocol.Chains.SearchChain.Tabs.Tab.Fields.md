---
metadata_version: 1
uid: Protocol.Chains.SearchChain.Tabs.Tab.Fields
description: "Learn how the Fields element contains the uniquely named fields included in a search chain tab in a DataMiner connector protocol."
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
