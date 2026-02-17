---
uid: GQI_Custom_Operator
---

# Custom operators

Each custom operator for GQI is defined in an **automation script library** by a **C# class** that implements specific [interfaces](xref:CO_Building_blocks). Every time GQI needs to use the custom operator, it will create a new instance of that class and call the relevant [lifecycle](xref:CO_Life_cycle) methods.

> [!NOTE]
> When transforming data, the custom operator is **applied on row level**. This means a custom operator **cannot** be used to do any of the following:
>
> - Adding additional rows
> - Applying custom aggregation

Custom operators are supported from DataMiner 10.3.0 [CU10]/10.4.1 onwards.<!-- RN 37840 --> Prior to this, starting from DataMiner 10.2.7/10.3.0, this feature is available in preview if the [*GenericInterface* soft-launch option](xref:Overview_of_Soft_Launch_Options#genericinterface) is enabled.
