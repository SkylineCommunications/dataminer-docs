---
uid: Protocol.Chains.SearchChain.Tabs.Tab.Fields.Field
---

# Field element

Defines a field to be included in this tab of the search chain.

## Parent

[Fields](xref:Protocol.Chains.SearchChain.Tabs.Tab.Fields)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[Display](xref:Protocol.Chains.SearchChain.Tabs.Tab.Fields.Field.Display)|[0, 1]||
|&nbsp;&nbsp;[Substitutions](xref:Protocol.Chains.SearchChain.Tabs.Tab.Fields.Field.Substitutions)|[0, 1]|Defines possible substitutions to be applied to the field content.|
|&nbsp;&nbsp;[Validation](xref:Protocol.Chains.SearchChain.Tabs.Tab.Fields.Field.Validation)|[0, 1]||

## Attributes

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Type&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Required|Description|
|--- |--- |--- |--- |
|[columnPid](xref:Protocol.Chains.SearchChain.Tabs.Tab.Fields.Field-columnPid)|unsignedInt|Yes|Specifies the column parameter ID of a column of the table referred to by the tablePid attribute of the enclosing Tab, or a column of a table that is linked with this table.|
|[name](xref:Protocol.Chains.SearchChain.Tabs.Tab.Fields.Field-name)|[TypeNonEmptyString](xref:Protocol-TypeNonEmptyString)|Yes|Specifies the name of the search field.|
