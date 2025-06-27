---
uid: GQI_Custom_Operator
---

# Custom operators

## About custom operators

Each custom operator for GQI is defined in an **Automation script library** by a **C# class** that implements specific [interfaces](xref:CO_Building_blocks). Every time GQI needs to use the custom operator, it will create a new instance of that class and call the relevant [life cycle](xref:CO_Life_cycle) methods.

> [!NOTE]
> When transforming data, the custom operator is **applied on row level**. This means a custom operator **cannot** be used to do any of the following:
>
> - Adding additional rows
> - Applying custom aggregation

Custom operators are supported from DataMiner 10.3.0 [CU10]/10.4.1 onwards.<!-- RN 37840 --> Prior to this, starting from DataMiner 10.2.7/10.3.0, this feature is available in preview if the [*GenericInterface* soft-launch option](xref:Overview_of_Soft_Launch_Options#genericinterface) is enabled.

## Defining a custom operator

A custom operator is defined in exactly the same way as an ad hoc data source. See [ad hoc data sources](xref:GQI_Ad_hoc_data_sources#defining-an-ad-hoc-data-source).

> [!TIP]
> See also: [Best practices for developing GQI extensions](xref:GQI_Extensions_Best_Practices).
