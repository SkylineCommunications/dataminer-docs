---
uid: Exporting_a_query
keywords: export query, query JSON, GQI query, Data Aggregator
description: Export a GQI query to JSON so it can be shared, backed up, reused in dashboards and apps, or used with Data Aggregator.
---

# Exporting a GQI query

From DataMiner 10.4.0 [CU21]/10.5.0 [CU9]/10.5.12 onwards<!--RN 43800-->, you can export a query to JSON:

1. Click the "..." button next to the query in the *Data* pane and select *Export*.

   A pop-up window will appear, showing a preview of the query in JSON format.

1. In the *Export for* box, select the desired export format:

   - *Dashboards / Apps* (default): Exports the query as raw JSON for use in [dashboards and low-code apps](xref:Importing_a_query#importing-a-query-from-json). Available from DataMiner 10.5.0 [CU17]/10.6.0 [CU5]/10.6.8 onwards<!--RN 45630-->.

   - *Data Aggregator*: Exports the query to JSON format compatible with the [Data Aggregator module](xref:Data_Aggregator_queries#configuration-using-an-export).

1. Select *Download JSON* to download the query as a JSON file, or *Copy query* to copy the JSON object to your clipboard.

> [!NOTE]
> Prior to DataMiner 10.4.0 [CU21]/10.5.0 [CU9]/10.5.12, exporting a query is not supported in the user interface. To export a GQI query to a JSON file (for example, to have it executed by the Data Aggregator module), follow the instructions under [Configuring GQI queries for Data Aggregator](xref:Data_Aggregator_queries).
