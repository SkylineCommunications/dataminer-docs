---
uid: Get_ad_hoc_data
---

# Get ad hoc data

When you create a GQI query, many built-in data sources are available to use. However, sometimes these are not enough. In that case, you can create an ad hoc data source to extend GQI with your own custom data source. Common scenarios include:

- Accessing data from external sources (database, CSV files, etc.)
- Accessing data from DataMiner for which no built-in data source exists yet
- Specialized performance optimizations (caching, data stitching, etc.)

An ad hoc data source retrieves external data based on an Automation script that is compiled as a library. The data can for example be retrieved from a CSV file, a MySQL database, or an API endpoint. If no such Automation script has been configured, this option is not available.

For more information on how you can create ad hoc data sources, see [Ad hoc data sources](xref:GQI_Ad_hoc_data_sources).

This query data source is available from DataMiner 10.3.0/10.2.4 onwards.

## Updates

[Real-time updates](xref:Query_updates) are available for this data source from DataMiner 10.4.4/10.5.0 onwards<!-- RN 38643 -->. To have real-time updates, the [IGQIUpdateable interface](xref:GQI_IGQIUpdateable) must be implemented in the ad hoc data source.

For a more detailed explanation on the different ways you can have a query result updated automatically, refer to [query updates](xref:Query_updates#query-update-support).

> [!IMPORTANT]
> When implementing real-time updates, be aware that you are operating in a multithreaded environment. The life cycle events of an ad hoc data source (e.g. *GetNextPage*, *OnStopUpdates*, etc.) may be triggered concurrently with your real-time update logic.
>
> To ensure correctness and prevent race conditions, you must implement appropriate thread-safety measures (e.g. synchronization or locking mechanisms) when accessing shared resources or modifying the internal state.
