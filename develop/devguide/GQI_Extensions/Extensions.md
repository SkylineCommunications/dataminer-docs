---
uid: GQI_Extensions
---

# GQI extensions

There are currently two ways to extend the Generic Query Interface:

- An [ad hoc data source](xref:GQI_Ad_hoc_data_sources) is an external data source that can be used to create a GQI query. The *Get ad hoc data* data source retrieves external data based on an Automation script that is compiled as a library.

- A [custom operator](xref:GQI_Custom_Operator) (supported from DataMiner 10.3.0 [CU10]/10.4.1 onwards) can be created to perform specific tasks on data within a query. These tasks might be unique to your needs and cannot be done with the standard query operators available.

> [!TIP]
> See also:
>
> - [Extension libraries](xref:GQI_Extension_Libraries)
> - [API reference](xref:GQI_GenIfRowMetadata)
> - [Best practices for developing GQI extensions](xref:GQI_Extensions_Best_Practices)
