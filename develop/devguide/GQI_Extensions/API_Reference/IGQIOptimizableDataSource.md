---
uid: GQI_IGQIOptimizableDataSource
---

# IGQIOptimizableDataSource interface

Available from DataMiner 10.3.3/10.4.0 onwards<!-- RN 35389 -->.

> [!NOTE]
> This interface is only used by the GQI framework in the lifecycle for ad hoc data sources from DataMiner 10.5.0 [CU2]/10.5.5 onwards when using the [GQI DxM](xref:GQI_DxM)<!-- RN42528 -->.

## Definition

- Namespace: `Skyline.DataMiner.Analytics.GenericInterface`
- Assembly: `SLAnalyticsTypes.dll`

The *IGQIOptimizableDataSource* interface can be used to optimize an ad hoc data source based on operators added to a query.

Common optimizations include:

- Inspecting the properties of an operator to make data retrieval more efficient.
- Removing or replacing an operator to implement the same operation more efficiently in the ad hoc data source.

> [!WARNING]
> Optimizing an operator should **never change the functional behavior of the query**. If an ad hoc data source removes or alters an operator, it is responsible for keeping the final result functionally equivalent.

> [!TIP]
> You can implement this interface to forward sort operations to an underlying database to improve performance.

## Methods

### IGQIQueryNode Optimize(IGQIDataSourceNode currentNode, IGQICoreOperator nextOperator)

Called when an optimizable operator is appended directly to the ad hoc data source. Given the current query node that represents the ad hoc data source and the next operator, it should return the resulting query node.

> [!TIP]
> Learn more about when this method is called within an [ad hoc data source](xref:Ad_hoc_Life_cycle#optimize).

> [!IMPORTANT]
>
> - The `Optimize` method may not be called if there are no supported subsequent operators.
> - The `Optimize` method will be called each time the next operator changes.

> [!NOTE]
> Currently, the `Optimize` method only triggers for filter operators (`IGQIFilterOperator`) and (from DataMiner 10.4.0/10.4.1 onwards<!-- RN 37806 -->) sort operators (`IGQISortOperator`).

#### Parameters

- [IGQIDataSourceNode](xref:GQI_IGQIDataSourceNode) `currentNode`: A reference to the current node.

- [IGQICoreOperator](xref:GQI_IGQICoreOperator) `nextOperator`: A reference to the next operator.

#### See also

- The [ad hoc data source lifecycle](xref:Ad_hoc_Life_cycle).
- The [IGQIOptimizableOperator](xref:GQI_IGQIOptimizableOperator) to optimize custom operators.
- Example: [Optimizing sort operations](xref:GQI_Ad_hoc_Optimizing_sort_operations).
