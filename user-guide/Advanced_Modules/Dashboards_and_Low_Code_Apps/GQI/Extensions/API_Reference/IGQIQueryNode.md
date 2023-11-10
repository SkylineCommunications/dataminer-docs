---
uid: GQI_IGQIQueryNode
---

# IGQIQueryNode Interface

## Definition

Namespace: `Skyline.DataMiner.Analytics.GenericInterface`  
Assembly: `SLAnalyticsTypes.dll`

Represents a **node** in a query. This interface is used to handle query optimizations. A node can either be a data source node or an operator node.

## Derived types

- IGQIDataSourceNode
- [IGQIOperatorNode](xref:GQI_IGQIOperatorNode)

## Methods

### IGQIQueryNode Append(IGQICoreOperator nextOperator)

Append any operator to this query node.

#### Parameters

- [IGQICoreOperator](xref:GQI_IGQICoreOperator) `nextOperator`: the operator to append

#### Returns

The resulting query node.
