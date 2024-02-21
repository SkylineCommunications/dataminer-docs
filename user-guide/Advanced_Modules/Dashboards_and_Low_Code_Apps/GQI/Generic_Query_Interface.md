---
uid: Generic_Query_Interface
---

# Generic Query Interface (GQI)

From DataMiner 10.0.13 onwards, the Generic Query Interface (GQI) allows you to access and analyze various types of data, whether sourced from your DataMiner System or external sources.

To begin using GQI, you need to [create a GQI query](xref:Creating_GQI_query) within the edit mode of a dashboard or low-code app.

This query configuration process involves selecting your desired data source, which can be either one of the [query data sources](xref:Query_data_sources) provided by DataMiner or an [ad hoc data source](xref:Configuring_an_ad_hoc_data_source_in_a_query) that you define. Optionally, you can also choose a [query operator](xref:Query_operators) to refine your query further.

From DataMiner 10.3.0 [CU10]/10.4.1 onwards<!-- RN 37840 -->, a [custom operator](xref:GQI_Custom_Operator) is available. In earlier DataMiner versions (starting from 10.2.7/10.3.0), the custom operator is available in soft launch.

From DataMiner 10.3.10/10.4.0 onwards<!-- RN 36789 -->, some queries also support [real-time updates](xref:Query_updates).

> [!TIP]
> You can also schedule GQI queries to run periodically at fixed times, dates, or intervals using the [Data Aggregator module](xref:Data_Aggregator_DxM).
