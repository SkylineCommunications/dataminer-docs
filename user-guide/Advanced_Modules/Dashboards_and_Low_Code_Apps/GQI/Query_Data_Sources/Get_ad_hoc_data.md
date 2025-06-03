---
uid: Get_ad_hoc_data
---

# Get ad hoc data

Available from DataMiner 10.3.0/10.2.4 onwards. The *Get ad hoc data* data source retrieves external data based on an Automation script that is compiled as a library. The data can for example be retrieved from a CSV file, a MySQL database, or an API endpoint. If no such Automation script has been configured, this option is not available.

> [!TIP]
> See: [Configuring an ad hoc data source in a query](xref:Configuring_an_ad_hoc_data_source_in_a_query)

## Updates

[Real-time updates](xref:Query_updates) are available for this data source from DataMiner 10.4.4/10.5.0 onwards<!-- RN 38643 -->. To have real-time updates, the [IGQIUpdateable interface](xref:GQI_IGQIUpdateable) must be implemented in the ad hoc data source.

For a more detailed explanation on the different ways you can have a query result updated automatically, refer to [query updates](xref:Query_updates#query-update-support).

> [!IMPORTANT]
> When implementing real-time updates, be aware that you are operating in a multithreaded environment. The lifecycle events of an ad hoc data source (e.g., GetNextPage, OnStopUpdates, etc.) may be triggered concurrently with your real-time update logic.
>
> To ensure correctness and prevent race conditions, you must implement appropriate thread-safety measures (e.g., synchronization or locking mechanisms) when accessing shared resources or modifying internal state.
