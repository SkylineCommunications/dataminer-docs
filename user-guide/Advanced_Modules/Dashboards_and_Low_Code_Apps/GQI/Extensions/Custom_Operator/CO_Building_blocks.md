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
  | OnArgumentsProcessed | OnArgumentsProcessedInputArgs | OnArgumentsProcessedOutputArgs | Indicates that the arguments have been processed. The processed arguments can be found in the *OnArgumentsProcessedInputArgs*. |

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
  > Currently, the `Optimize` method only triggers for filter operators (typed `IGQIFilterOperator`).
