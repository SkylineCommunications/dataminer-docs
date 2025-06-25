---
uid: CO_Building_blocks
---

# Building blocks of a custom operator

A custom operator implements predefined interfaces that can be considered building blocks as they add the desired functionality to the operator.

The [*IGQIRowOperator*](xref:GQI_IGQIRowOperator) and [*IGQIColumnOperator*](xref:GQI_IGQIColumnOperator) interfaces are used to identify the class as a custom operator. At least one of them should be implemented for the class to be detected by GQI as a custom operator.

All other interfaces add additional functionality.

## Interfaces in a custom operator

The available interfaces are:

- [IGQIColumnOperator](xref:GQI_IGQIColumnOperator): Makes it possible to manipulate the columns.

- [IGQIRowOperator](xref:GQI_IGQIRowOperator): Makes it possible to manipulate the rows.

- [IGQIInputArguments](xref:GQI_IGQIInputArguments): Retrieves input from the user through input arguments.

- [IGQIOnDestroy](xref:GQI_IGQIOnDestroy): Can be implemented to clean up resources after it has been used (available from DataMiner 10.4.5/10.5.0 onwards<!-- RN 38959 -->).

- [IGQIOnInit](xref:GQI_IGQIOnInit): Provides a way to initialize the custom operator with access to dependencies like the DMS (available from DataMiner 10.4.5/10.5.0 onwards<!-- RN 38959 -->).

- [IGQIOptimizableOperator](xref:GQI_IGQIOptimizableOperator): Used in order to optimize the custom operator based on other operators in a query.
