---
uid: Protocol.Chains.Chain
---

# Chain element

Each Protocol.Chains.Chain child represents a different topology view of an EPM or Service Overview Manager element.

> [!TIP]
> See also: [EPM chains and fields configuration](xref:EPMManagerChainsAndFields)

## Parent

[Chains](xref:Protocol.Chains)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[defaultSelectionField](xref:Protocol.Chains.Chain-defaultSelectionField)|[TypeNonEmptyString](xref:Protocol-TypeNonEmptyString)||Specifies the name of the field for which default selection should be applied.|
|[groupingName](xref:Protocol.Chains.Chain-groupingName)|[TypeNonEmptyString](xref:Protocol-TypeNonEmptyString)||Specifies the name of the group to which this chain belongs.|
|[name](xref:Protocol.Chains.Chain-name)|string|Yes|Specifies the name of the chain, which is used as the name of the corresponding tab page in DataMiner.|
|[options](xref:Protocol.Chains.Chain-options)|string||Specifies a number of options (separated by semicolons).|
|[topology](xref:Protocol.Chains.Chain-topology)|string||Contains the name defined in the name attribute of Protocol.Topologies.Topology (only Service Overview Manager). See [name](xref:Protocol.Topologies.Topology-name).|

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***Choice***|||
|&nbsp;&nbsp;***Sequence***|[0, 1]||
|&nbsp;&nbsp;&nbsp;&nbsp;[Display](xref:Protocol.Chains.Chain.Display)||Configures chain display settings.|
|&nbsp;&nbsp;&nbsp;&nbsp;[Field](xref:Protocol.Chains.Chain.Field)|[0, *]|Each field in a chain is a possible block in the drill-down diagram displayed on the visual pages of an EPM element.|
