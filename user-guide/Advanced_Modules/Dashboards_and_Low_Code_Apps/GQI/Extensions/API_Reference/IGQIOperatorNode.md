---
uid: GQI_IGQIOperatorNode
---

# IGQIOperatorNode interface

## Definition

- Namespace: `Skyline.DataMiner.Analytics.GenericInterface`
- Assembly: `SLAnalyticsTypes.dll`

An interface that represents any **operator node** in a query.

## Implements

- [IGQIQueryNode](xref:GQI_IGQIQueryNode)

## Properties

| Name | Type | Description |
| ---- | ---- | ----------- |
| Parent | [IGQIQueryNode](xref:GQI_IGQIQueryNode) | The previous query node the comes before this operator node. |
| Operator | [IGQICoreOperator](xref:GQI_IGQICoreOperator) | A handle to the core operator of this query node. |

## Methods

### IGQIQueryNode Forward(IGQICoreOperator nextOperator)

Forwards any operator unconditionally. This means prepending the given operator to this node.

This is functionally equivalent to `Parent.Append(nextOperator).Append(this)`.

#### Parameters

- [IGQICoreOperator](xref:GQI_IGQICoreOperator) `nextOperator`: The operator to forward.

#### Returns

The resulting query node.

### IGQIQueryNode OptimizeForFilter(IGQIFilterOperator filterOperator, params IGQIColumn[] affectedColumns)

Tries to forward the given filter operator if it does not depend on the affected columns. Otherwise appends the filter to this node.

#### Parameters

- [IGQIFilterOperator](xref:GQI_IGQIColumn) `filterOperator`: The filter operator to optimize.
- [IGQIColumn](xref:GQI_IGQIColumn)[] `affectedColumns`: The columns on which a filter cannot be forwarded.

#### Returns

The resulting query node.
