---
uid: Protocol.Chains.Chain.Field
---

# Field element

Each field in a chain is a possible block in the drill-down diagram displayed on the visual pages of an EPM element.

> [!TIP]
> See also: [EPM chains and fields configuration](xref:EPMManagerChainsAndFields)

## Parent

[Chain](xref:Protocol.Chains.Chain)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[displayTable](xref:Protocol.Chains.Chain.Field-displayTable)|string||*TBD*|
|[name](xref:Protocol.Chains.Chain.Field-name)|string|Yes|Specifies the name of the block in the drill-down diagram.|
|[options](xref:Protocol.Chains.Chain.Field-options)|string||Specifies a number of options.|
|[pid](xref:Protocol.Chains.Chain.Field-pid)|[TypeParamId](xref:Protocol-TypeParamId)|Yes|Specifies the parameter ID of the parameter to which the block is linked.|

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[DiagramPids](xref:Protocol.Chains.Chain.Field.DiagramPids)|[0, 1]|Specifies the IDs of the (read) parameters to be shown in the diagram box.|
|&nbsp;&nbsp;[DiagramSorting](xref:Protocol.Chains.Chain.Field.DiagramSorting)|[0, 1]|Specifies the diagram item sort order.|
|&nbsp;&nbsp;[DiagramTitleFormat](xref:Protocol.Chains.Chain.Field.DiagramTitleFormat)|[0, 1]|Specifies a custom title for the diagram box.|
|&nbsp;&nbsp;[Display](xref:Protocol.Chains.Chain.Field.Display)|[0, 1]||
