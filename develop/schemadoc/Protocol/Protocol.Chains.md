---
uid: Protocol.Chains
description: "Use the Chains element in a DataMiner protocol to contain topology and search chains shown as tabs for EPM or SOM elements."
---

# Chains element

Contains a number of `<Chain>` or `<SearchChain>` children, which are represented as tab pages in DataMiner.

> [!TIP]
> See also: [EPM chains and fields configuration](xref:EPMManagerChainsAndFields)

## Parent

[Protocol](xref:Protocol)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[filters](xref:Protocol.Chains-filters)|[EnumChainsFilters](xref:Protocol-EnumChainsFilters)||Determines the layout of the filters.|

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***Choice***|||
|&nbsp;&nbsp;[Chain](xref:Protocol.Chains.Chain)|[0, *]|Represents a different topology view of a CPE manager or Service Overview Manager (SOM) element.|
|&nbsp;&nbsp;[SearchChain](xref:Protocol.Chains.SearchChain)|[0, *]|Defines a search chain in a CPE environment.|

## Constraints

|Type|Description|Selector|Fields|
|--- |--- |--- |--- |
|Unique |The name of a chain or search chain must be unique. |child::* |@name |
