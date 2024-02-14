---
uid: GQI_IGQIQueryNode
---

# IGQIQueryNode interface

## Definition

- Namespace: `Skyline.DataMiner.Analytics.GenericInterface`
- Assembly: `SLAnalyticsTypes.dll`

Represents a **node** in a query. This interface is used to handle query optimizations. A node can be either a data source node or an operator node.

## Derived types

- IGQIDataSourceNode
- [IGQIOperatorNode](xref:GQI_IGQIOperatorNode)

## Methods

### IGQIQueryNode Append(IGQICoreOperator nextOperator)

Appends any operator to this query node.

#### Parameters

- [IGQICoreOperator](xref:GQI_IGQICoreOperator) `nextOperator`: The operator to append.

#### Returns

The resulting query node.
