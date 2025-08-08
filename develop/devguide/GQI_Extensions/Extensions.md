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
> - [API reference](xref:GQI_GenIfRowMetadata)
> - [Best practices for developing GQI extensions](xref:GQI_Extensions_Best_Practices)
> - [GQI extensions logging](xref:GQI_Extensions_Logging)

## Managing dependencies for GQI extensions

GQI extensions use the Automation engine to create DLL libraries, which are then loaded by GQI to add functionalities like ad hoc data sources and custom operators.

When creating these GQI extensions, you will need to ensure that all necessary DLL libraries are available. From DataMiner 10.5.0 [CU2]/10.5.5 onwards (when using the [GQI DxM](xref:GQI_DxM))<!--RN 42468-->, GQI automatically searches for any missing dependencies in the `C:\Skyline DataMiner\Scripts\Libraries` folder. This helps GQI extension scripts locate the required Automation script libraries at runtime.

> [!NOTE]
> If the Automation script library you are referencing has its own dependencies, make sure to include these dependencies in your GQI extension scripts as well.
