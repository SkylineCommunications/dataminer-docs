---
metadata_version: 1
uid: Protocol.Chains.SearchChain.Tabs.Tab.Fields
description: "Reference the DataMiner connector protocol schema entry for Fields element, including its documented structure, attributes, values, and constraints."
content_type: schema
applies_to:
  - DataMiner
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
