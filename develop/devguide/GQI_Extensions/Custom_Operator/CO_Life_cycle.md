---
uid: CO_Life_cycle
---

# Life cycle of a custom operator

Whenever a custom operator is used, an instance of the associated C# class is created, and GQI will call the relevant life cycle methods that define its behavior.

The simplified diagram below shows in what order each GQI life cycle method is called.

> [!NOTE]
> In practice, the life cycle methods that will be called depend on various conditions. Refer to the [detailed life cycle overview](#detailed-life-cycle-overview) for a complete overview.

![Custom operator life cycle](~/dataminer/images/GQI_CustomOperatorLifeCycle.png)

## When is a custom operator instance created?

A new custom operator instance is created **every time** one of the following requests occur:

- A **capability request**, used to determine the query arguments used in the query builder.
- A **columns request**, used to determine which columns are available without fetching any data.
- A **new session request**, used to fetch and transform data.

The type of request also determines which life cycle methods are used.

## Detailed life cycle overview

The following life cycle methods exist for custom operators:

| Method | Interface | Required | Availability |
|--|--|--|--|
| [OnInit](#oninit) | [IGQIOnInit](xref:GQI_IGQIOnInit) | No | From DataMiner 10.4.5/10.5.0 onwards<!-- RN 38959 --> |
| [GetInputArguments](#getinputarguments) | [IGQIInputArguments](xref:GQI_IGQIInputArguments) | No | Always |
| [OnArgumentsProcessed](#onargumentsprocessed) | [IGQIInputArguments](xref:GQI_IGQIInputArguments) | No | Always |
| [HandleColumns](#handlecolumns) | [IGQIColumnOperator](xref:GQI_IGQIColumnOperator) | No | Always |
| [Optimize](#optimize) | [IGQIOptimizableOperator](xref:GQI_IGQIOptimizableOperator) | No | Always |
| [HandleRow](#handlerow) | [IGQIRowOperator](xref:GQI_IGQIRowOperator) | No | Always |
| [OnDestroy](#ondestroy) | [IGQIOnDestroy](xref:GQI_IGQIOnDestroy) | No | From DataMiner 10.4.5/10.5.0 onwards<!-- RN 38959 --> |

The life cycle methods that are called on a custom operator instance depend on the following conditions:

- The [interfaces](xref:CO_Building_blocks) that are implemented by the associated C# class.
- The type of GQI request for which the instance was [created](#when-is-a-custom-operator-instance-created).
- The operators used in the query.
- The result of previous life cycle methods.

The following diagram shows a complete overview of all possible life cycle paths.

![Custom operator life cycle](~/dataminer/images/GQI_CustomOperatorLifeCycle2.png)

### OnInit

Building block interface: [IGQIOnInit](xref:GQI_IGQIOnInit)

If implemented, `OnInit` is always the first life cycle method. It can provide references to dependencies like a logger or an SLNet connection and can be used to initialize resources that should be available during the lifetime of the custom operator instance.

> [!IMPORTANT]
> Resources that are initialized here should be cleaned up in the final [OnDestroy](#ondestroy) life cycle method.

> [!NOTE]
> When resources are only required to determine the columns, the initialization should instead be done in the [HandleColumns](#handlecolumns) life cycle method to avoid unnecessary resource allocations.

### GetInputArguments

Building block interface: [IGQIInputArguments](xref:GQI_IGQIInputArguments)

If implemented, the `GetInputArguments` method defines the arguments that can be used to configure the custom operator in a query.

Later, the arguments defined here will determine which argument values are available in the [OnArgumentsProcessed](#onargumentsprocessed) life cycle method.

### OnArgumentsProcessed

Building block interface: [IGQIInputArguments](xref:GQI_IGQIInputArguments)

If implemented, the `OnArgumentsProcessed` method gives access to the values of the arguments defined in the [GetInputArguments](#getinputarguments) life cycle method that were specified in the query.

### HandleColumns

Building block interface: [IGQIColumnOperator](xref:GQI_IGQIColumnOperator)

If implemented, the `HandleColumns` life cycle method allows you to transform the query columns by:

- Adding new columns
- Renaming existing columns
- Removing existing columns

This method can also be used to just provide access to the currently available columns.

> [!IMPORTANT]
> Avoid the implicit use of query columns in your custom operator by retrieving them explicitly via [query arguments](xref:GQI_IGQIInputArguments). This both informs users which columns are relevant and prevents unintended side effects when the query is optimized.

### Optimize

Building block interface: [IGQIOptimizableOperator](xref:GQI_IGQIOptimizableOperator)

If implemented, the `Optimize` life cycle method allows the custom operator to interpret downstream operators that are applied directly and makes it possible to adjust its behavior to improve query execution performance.

This life cycle method may be called multiple times for the same instance when the custom operator removes or reorders other operators.

### HandleRow

Building block interface: [IGQIRowOperator](xref:GQI_IGQIRowOperator)

If implemented, the `HandleRow` life cycle method defines how query rows will be transformed. It will be called exactly once for each row in the current query result, and for every row you can do any of the following:

- Get the row key
- Get or set the row metadata
- Get or set cell values and display values
- Remove the row from the query result

> [!NOTE]
> If the custom operator removed a column in the [HandleColumns](#handlecolumns) life cycle method, you can still access the associated cell value here.

### OnDestroy

Building block interface: [IGQIOnDestroy](xref:GQI_IGQIOnDestroy)

If implemented, `OnDestroy` is always the last life cycle method. It allows you to clean up any resources that were used during the lifetime of the custom operator instance.

> [!IMPORTANT]
> The `OnDestroy` life cycle method will **not** be called when the [OnInit](#oninit) life cycle method failed.
