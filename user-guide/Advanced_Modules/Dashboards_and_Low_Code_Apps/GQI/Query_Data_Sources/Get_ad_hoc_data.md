---
uid: Get_ad_hoc_data
---

# Get ad hoc data

Available from DataMiner 10.3.0/10.2.4 onwards. The *Get ad hoc data* data source retrieves external data based on an Automation script that is compiled as a library. The data can for example be retrieved from a CSV file, a MySQL database, or an API endpoint. If no such Automation script has been configured, this option is not available.

> [!TIP]
> See: [Configuring an ad hoc data source in a query](xref:Configuring_an_ad_hoc_data_source_in_a_query)

## Updates

[Real-time updates](xref:Query_updates) are available for this data source from DataMiner 10.4.4/10.5.0 onwards<!-- RN 38643 -->. To have real-time updates, the ad hoc data sources requires implementing the [IGQIUpdateable interface](xref:GQI_IGQIUpdateable).

Refer to [query updates](xref:Query_updates#query-update-support) for a more detailed explanation on the different ways you can have your query result updated automatically.
