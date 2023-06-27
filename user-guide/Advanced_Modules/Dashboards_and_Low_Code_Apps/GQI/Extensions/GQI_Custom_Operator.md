---
uid: GQI_Custom_Operator
---

# Configuring a custom operator for a query

> [!WARNING]
> This feature is currently still in preview. For more information, see [Soft-launch options](xref:SoftLaunchOptions).

The custom operator is available in soft launch from DataMiner 10.x.x onwards, if the soft-launch option *GenericInterface* is enabled.

At least **one of the following interfaces is required** for the class to be detected by GQI as a custom operator:

- IGQIColumnOperator

<!--more info here-->

- IGQIRowOperator

<!--more info here-->

The following **optional interfaces** add additional functionality:

- IGQIInputArguments

<!--more info here-->

- IGQIOptimizableOperator

<!--more info here-->