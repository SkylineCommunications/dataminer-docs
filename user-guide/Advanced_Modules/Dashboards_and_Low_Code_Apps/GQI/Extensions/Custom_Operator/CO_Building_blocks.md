---
uid: CO_Building_blocks
---

# Building blocks

A custom operator implements predefined interfaces that can be considered building blocks as they add the desired functionality to the operator.

At least **one of the following interfaces is required** for the class to be detected by GQI as a custom operator:

- **IGQIColumnOperator**

  The *IGQIColumnOperator* interface is used to create, rename, and add columns. This interface has one method:

  | **Method** | **Parameters** | **Returns** | **Description** |
  |--|--|--|--|
  | HandleColumns | GQIEditableHeader | - | The GQI will request the implementation to handle the columns. |

- **IGQIRowOperator**

  The *IGQIRowOperator* interface is used to read and update cells within each row. This interface has one method:

  | **Method** | **Parameters** | **Returns** | **Description** |
  |--|--|--|--|
  | HandleRow | GQIEditableRow | - | The GQI will request the implementation to handle the row. |

The following **optional interfaces** can be implemented to add additional functionality:

- **IGQIInputArguments**

  The *IGQIInputArguments* interface is used to request additional information from the user while configuring the data source. This interface has the following methods:

  | **Method** | **Parameters** | **Returns** | **Description** |
  |--|--|--|--|
  | GetInputArguments | - | GQIArgument[] | Asks the user for additional information during data source configuration. |
  | OnArgumentsProcessed | [OnArgumentsProcessedInputArgs](xref:GQI_OnArgumentsProcessedInputArgs) | OnArgumentsProcessedOutputArgs | Indicates that the arguments have been processed. The processed arguments can be found in the *OnArgumentsProcessedInputArgs*. |

  > [!IMPORTANT]
  > GQI does not validate the input arguments. For example, a user can input an SQL query as a text input argument, and GQI will forward it to the custom data source implementation without validation.

- **IGQIOptimizableOperator**

  The *IGQIOptimizableOperator* interface is used to optimize your custom operator based on other operators in a query.

  Some common use cases include:

  - Combining multiple operators into a single, more efficient operation.

  - Forwarding certain operators to improve performance.

  This interface has one method:

  | **Method** | **Parameters** | **Returns** | **Description** |
  |--|--|--|--|
  | Optimize | IGQIOperatorNode<br>IGQICoreOperator | IGQIQueryNode | Intercepts how subsequent operators should be handled. Given the current query node and the next operator, it should return the resulting query node. |

  > [!TIP]
  > We recommend forwarding operators whenever possible as this enables the core framework to perform significant optimizations.

  > [!IMPORTANT]
  >
  > - The `Optimize` method may not be called if there are no supported subsequent operators.
  > - The `Optimize` method will be called each time there is a new next operator.

  > [!NOTE]
  > Currently, the `Optimize` method only triggers for filter operators (`IGQIFilterOperator`) and (from DataMiner 10.4.0/10.4.1 onwards<!-- RN 37806 -->) sort operators (`IGQISortOperator`).

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

To combine functionality from a subsequent operator, you can modify your custom operator logic and then return the current node.

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

To forward any operator, i.e. to give it more priority than your own custom operator, you can call the `Forward(IGQICoreOperator)` on the current `IGQIOperatorNode`.

```csharp
public IGQIOperatorNode Optimize(IGQIOperatorNode currentNode, IGQICoreOperator nextOperator)
{
    return currentNode.Forward(nextOperator);
}
```

##### Conditionally forward filters

You will rarely be able to unconditionally forward filter operators. You only want to forward them when they do not depend on anything your custom operator does.

To achieve this, you can use the `OptimizeForFilter(IGQIFilterOperator, params IGQIColumn[])` helper method on a query node.
Given a filter operator and an array of columns that are affected by your custom operator, it will try to forward the filter or append it otherwise.

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

> [!WARNING]
> Make sure to include **all** affected columns.
> If you forget any, the optimized query may produce incorrect results.
> Affected columns should always include:
>
> - Any new columns that will be added by your custom operator
> - Any columns that may have their values changed by your custom operator
