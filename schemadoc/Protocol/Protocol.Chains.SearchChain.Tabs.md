---
uid: Protocol.Chains.SearchChain.Tabs
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
