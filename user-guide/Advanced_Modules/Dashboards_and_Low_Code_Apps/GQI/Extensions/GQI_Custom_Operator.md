---
uid: GQI_Custom_Operator
---

# Custom operators

Out of the box, GQI offers basic operators for filtering, sorting, aggregating, etc. but there are infinitely more operations you may want to perform on your data. For these scenarios, you can define a custom operator to do any of the following:

- Add, remove and rename columns
- Transform data by changing cell values, display values and metadata
- Filter out rows based on custom conditions
- Optimizing the behavior of downstream operators

> [!NOTE]
> When transforming data, the custom operator is applied on row-level. This means a custom operator **cannot** be used to do any of the following:
>
> - Add additional rows
> - Apply custom aggregations

Custom operators are supported from DataMiner 10.3.0 [CU10]/10.4.1 onwards.<!-- RN 37840 --> Prior to this, starting from DataMiner 10.2.7/10.3.0, this feature is available in preview if the [*GenericInterface* soft-launch option](xref:Overview_of_Soft_Launch_Options#genericinterface) is enabled.

## What is a custom operator

A custom operator is an operator that you can define yourself to extend query functionality. Each operator is defined in an **automation script library** by a **C# class** that implements specific [interfaces](xref:CO_Building_blocks).

Every time GQI requires needs to use the custom operator, it will create a new instance of that class and call the relevant [life cycle](xref:CO_Life_cycle)) methods.

## How to define a custom operator

A custom operator is defined in exactly the same way as an ad hoc data source. See [how to define an ad hoc data source](xref:Configuring_an_ad_hoc_data_source_in_a_query#how-to-define-an-ad-hoc-data-source).

> [!TIP]
> See also: [Best practices for developing GQI extensions](xref:GQI_Extensions_Best_Practices).
