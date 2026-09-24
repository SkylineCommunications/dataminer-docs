---
metadata_version: 1
uid: Protocol.Chains.SearchChain.Tabs
description: "Learn how the Tabs element contains the uniquely named tab definitions for a search chain in a DataMiner connector protocol."
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
