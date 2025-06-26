---
uid: GQI_IGQIOptimizableOperator
---

# IGQIOptimizableOperator interface

> [!TIP]
> Learn how to implement optimizations for a custom operator and avoid common pitfalls with this tutorial: [Optimizing your custom operator](xref:Custom_Operator_Tutorial).

## Definition

- Namespace: `Skyline.DataMiner.Analytics.GenericInterface`
- Assembly: `SLAnalyticsTypes.dll`

The *IGQIOptimizableOperator* interface is used to optimize a custom operator based on other operators in a query.

Some common use cases include:

- Combining multiple operators into a single, more efficient operation.

- Forwarding certain operators to improve performance.

## Methods

### IGQIQueryNode Optimize(IGQIOperatorNode currentNode, IGQICoreOperator nextOperator)

Intercepts how subsequent operators should be handled. Given the current query node and the next operator, it should return the resulting query node.

> [!TIP]
> Learn more about when this method is called within a [custom operator](xref:CO_Life_cycle#optimize).

> [!TIP]
> We recommend forwarding operators whenever possible as this enables the core framework to perform significant optimizations.

> [!IMPORTANT]
>
> - The `Optimize` method may not be called if there are no supported subsequent operators.
> - The `Optimize` method will be called each time there is a new next operator.

> [!NOTE]
> Currently, the `Optimize` method only triggers for filter operators (`IGQIFilterOperator`) and (from DataMiner 10.4.0/10.4.1 onwards<!-- RN 37806 -->) sort operators (`IGQISortOperator`).

#### Parameters

- [IGQIOperatorNode](xref:GQI_IGQIOperatorNode) `currentNode`: A reference to the current node.

- [IGQICoreOperator](xref:GQI_IGQICoreOperator) `nextOperator`: A reference to the next operator.

#### Examples

##### Append (default behavior)

To append an operator to a query node, you can call its `Append(IGQICoreOperator)` method.

```csharp
public IGQIOperatorNode Optimize(IGQIOperatorNode currentNode, IGQICoreOperator nextOperator)
{
    return currentNode.Append(nextOperator);
}
```

##### Combine operations

To combine functionality from a subsequent operator, you can modify the custom operator logic and then return the current node.

```csharp
public IGQIOperatorNode Optimize(IGQIOperatorNode currentNode, IGQICoreOperator nextOperator)
{
    // Configure this custom operator to also handle the functionality of the next operator
    ConfigureMyCustomLogicFor(nextOperator);

    // Return our current node that is now also responsible for the next operation
    return currentNode;
}
```

##### Unconditionally forward

To forward any operator, i.e. to give it more priority than another custom operator, you can call `Forward(IGQICoreOperator)` on the current `IGQIOperatorNode`.

```csharp
public IGQIOperatorNode Optimize(IGQIOperatorNode currentNode, IGQICoreOperator nextOperator)
{
    return currentNode.Forward(nextOperator);
}
```

##### Conditionally forward filters

You will rarely be able to unconditionally forward filter operators. You should only forward them when they do not depend on anything the custom operator does.

To achieve this, you can use the `OptimizeForFilter(IGQIFilterOperator, params IGQIColumn[])` helper method on a query node. Given a filter operator and an array of columns that are affected by the custom operator, it will try to forward the filter or append it otherwise.

```csharp
public IGQIOperatorNode Optimize(IGQIOperatorNode currentNode, IGQICoreOperator nextOperator)
{
    // Check if the next operator is a filter operator
    // If not, fall back to the default behavior
    if (!nextOperator.IsFilter(out filterOperator))
        return currentNode.Append(nextOperator);

    var affectedColumns = new IGQIColumn[] {
        _myNewColumn, // a new column added by the custom operator
        _myModifiedColumn, // an existing column the custom operator will modify
    };

    // Allow the GQI framework to forward the filterOperator if possible
    return currentNode.OptimizeForFilter(filterOperator, affectedColumns);
}
```

> [!CAUTION]
> Make sure to include **all** affected columns. If you forget any, the optimized query may produce incorrect results. Affected columns should always include:
>
> - Any new columns that will be added by the custom operator.
> - Any columns that may have their values changed by the custom operator.
