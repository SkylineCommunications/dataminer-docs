---
uid: Creating_GQI_query
---

# Creating a GQI query

From DataMiner 10.0.13 onwards, a special type of data feed is available, using the Generic Query Interface. This “Queries” data item allows you to construct a query in order to tap into the wealth of data available in your DataMiner System.

> [!TIP]
> See also: [Building Queries with DataMiner Generic Query Interface (GQI)](https://community.dataminer.services/video/building-queries-with-dataminer-generic-query-interface-gqi/) ![Video](~/user-guide/images/video_Duo.png)

You can create a query as follows:

1. In edit mode, select the dashboard component for which you want to use a query as a data input. At present, this is supported for Bar chart, Pie chart, State, and Table components.

1. In the data pane, select *Queries* and click the + icon to add a new query.

1. Specify a name for the query.

   > [!NOTE]
   > From DataMiner 10.2.0 [CU2]/10.2.5 onwards, a query must have a unique name. If you edit an existing query that has no name, you will need to specify a unique name for it. Prior to this, starting from DataMiner 10.1.0/10.1.1, a query name is optional but highly recommended.

1. In the drop-down box below this, select the data source you want to use. For a detailed overview of all available data sources, see [Query data sources](xref:Query_data_sources).

   > [!IMPORTANT]
   > It is also possible to configure an ad hoc data source in a query. For more information, see [Configuring an ad hoc data source in a query](xref:Configuring_an_ad_hoc_data_source_in_a_query).

1. Select an operator. This step is optional; if you do not select an operator, the data set will be returned untouched. See [Query operators](xref:Query_operators).

1. Drag the configured query to the component in order to use it.

> [!NOTE]
>
> - From DataMiner 10.1.4 onwards, you can import a query from a different dashboard in the DMS. For more information, see [Importing a query](xref:Importing_a_query)
> - Using the Data Aggregator module, you can schedule GQI queries to run periodically at fixed times, dates, or intervals. For more information, see [Data Aggregator](xref:Data_Aggregator_DxM).

## Notes on GQI queries

Please note the following regarding query data input:

- When a query has been created, the columns from the table that results from the query are available as individual data items in the data pane, so that you can use them to filter or group a component.

- It is not possible to retrieve data from a stopped element.

- From DataMiner 10.1.0/10.1.3 onwards, dynamic units will automatically be used when applicable for the retrieved data if this is enabled in the dashboard settings. This means that parameter units will change dynamically based on their value and protocol definition. You can override the behavior configured for the dashboard in the settings for the component.

- From DataMiner 10.2.0/10.1.4 onwards, if a row is selected in a table component that uses a query feed, any view, service, or element linked to that row is also exposed as a feed. In practice, this means that a feed will be available in the *feeds* section of the data pane that will change based on the selection in the table.

- From DataMiner 10.2.0/10.1.5 onwards, you can link GQI nodes that require a time range selection to a time range feed by selecting the *From feed* checkbox.
