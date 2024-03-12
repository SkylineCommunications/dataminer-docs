---
uid: CO_Building_blocks
---

# Building blocks of a custom operator

A custom operator implements predefined interfaces that can be considered building blocks as they add the desired functionality to the operator.

The [*IGQIRowOperator*](xref:GQI_IGQIDataSource) and [*IGQIColumnOperator*](xref:GQI_IGQIDataSource) interfaces are used to identify the class as a custom operator. At least one of them should be implemented for the class to be detected by GQI as a custom operator.

All other interfaces add additional functionality.

## Interfaces in the ad hoc data script

The available interfaces are:

- [IGQIColumnOperator](xref:GQI_IGQIColumnOperator)

- [IGQIRowOperator](xref:GQI_IGQIRowOperator)

- [IGQIInputArguments](xref:GQI_IGQIInputArguments)

- [IGQIOnDestroy](xref:GQI_IGQIOnDestroy)

- [IGQIOnInit](xref:GQI_IGQIOnInit)

- [IGQIOptimizableOperator](xref:GQI_IGQIOptimizableOperator)

## Objects in the ad hoc data script

To build the custom operator, you can use the following objects:

- [GQIArgument](xref:GQI_GQIArgument)

- [GQIDMS](xref:GQI_GQIDMS)

- [GQIEditableHeader](xref:GQI_GQIEditableHeader)

- [GQIEditableRow](xref:GQI_GQIEditableRow)