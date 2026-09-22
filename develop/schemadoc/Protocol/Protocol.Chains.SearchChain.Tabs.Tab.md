---
metadata_version: 1
uid: Protocol.Chains.SearchChain.Tabs.Tab
description: "Reference the DataMiner connector protocol schema entry for Tab element, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# Tab element

Defines a tab.

## Parent

[Tabs](xref:Protocol.Chains.SearchChain.Tabs)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[tablePid](xref:Protocol.Chains.SearchChain.Tabs.Tab-tablePid)|unsignedInt|Yes|Specifies the table parameter ID of the table for which a search Tab will be defined.|
|[name](xref:Protocol.Chains.SearchChain.Tabs.Tab-name)|string||Specifies the name of the search tab.|

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[Display](xref:Protocol.Chains.SearchChain.Tabs.Tab.Display)|[0, 1]||
|&nbsp;&nbsp;[Fields](xref:Protocol.Chains.SearchChain.Tabs.Tab.Fields)||Contains the definition of the fields to be included in this search tab.|
