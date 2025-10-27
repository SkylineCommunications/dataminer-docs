---
uid: Data_Aggregator_queries
---

# Configuring GQI queries for Data Aggregator

Every GQI query you want to execute must be saved in a separate file in JSON format.

To get a correctly configured query, you can make use of the DataMiner Dashboards app:

1. In the DataMiner Dashboards app, [create a dashboard](xref:Creating_a_completely_new_dashboard), and then [create a query](xref:Creating_GQI_query).

1. Visualize this query on the dashboard, for example using the [Table component](xref:DashboardTable).

1. Press F12 to open the developer tools and go to the *Network* tab.

1. Press F5 to refresh the dashboard.

1. In the *Name* column of the *Network* tab, select the *OpenQuerySession* network call.

1. Go to the *Payload* subtab, and copy the value of *query* and *connection* by right-clicking these and selecting *Copy value*.

   ![Developer tools Network tab](~/dataminer/images/DataAggregatorCopyQuery.png)

1. Convert the query using the *ConvertQueryToProtoJson* web method:

   `POST https://dataminer.company.local/API/v1/Internal.asmx/ConvertQueryToProtoJson`

   > [!NOTE]
   > Replace `dataminer.company.local` with the hostname or IP address of your DataMiner Agent.

   with the following payload, depending on the DataMiner version:

   - From DataMiner **10.4.0 [CU6]/10.5.0 [CU4]/10.5.7** onwards:<!-- RN 42855 -->

     > ``` json
     > {
     >   "connection": "", // copied in previous step
     >   "options": { "Contract": 1 },
     >   "query": {} // copied in previous step
     > }
     > ```

     - Use `"Contract": 0` for queries that should be executed via CoreGateway and SLHelper.
     - Use `"Contract": 1` for queries that should be executed via the GQI DxM.

     The used contract should correspond to the [`UseGQIDxM`](xref:Data_Aggregator_settings#using-the-gqi-dxm-for-queries) setting.

   - In **earlier** DataMiner versions:

     > ``` json
     > {
     >   "connection": "", // copied in previous step
     >   "query": {} // copied in previous step
     > }
     > ```

1. From the received response, copy the value of *d:*.

   The copied value is a JSON-wrapped JSON string.

1. Unwrap the JSON string by replacing all instances of  `\"` with `"`, and all instances of `\\` with `\`.

1. Paste the copied JSON code into a new file and save it as a *.json* file.

1. Rename your *.json* file, place it in the correct folder, and modify the *Helper.json*. See [GQI queries](xref:Data_Aggregator_settings#gqi-queries) for detailed instructions.
