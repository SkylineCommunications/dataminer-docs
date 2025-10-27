---
uid: Creating_GQI_query
---

# Creating a GQI query

The "Queries" data item allows you to construct a query in order to tap into the wealth of data available in your DataMiner System using the Generic Query Interface.

> [!TIP]
> See also: [Building Queries with DataMiner Generic Query Interface (GQI)](https://www.youtube.com/watch?v=S6U9xERPrL8) ![Video](~/dataminer/images/video_Duo.png)

## Creating a query

1. In edit mode, select the component for which you want to use a query as a data input.

1. In the *Data* pane, select *Queries* and click the + icon to add a new query.

   > [!TIP]
   > If the DataMiner Assistant module has been deployed in your system, at this point you can [let DataMiner Assistant create a query for you](#letting-dataminer-assistant-create-a-query).

1. Specify a name for the query.

   > [!NOTE]
   > From DataMiner 10.2.0 [CU2]/10.2.5 onwards, a query must have a unique name. If you edit an existing query that has no name, you will need to specify a unique name for it. Prior to this, starting from DataMiner 10.1.0/10.1.1, a query name is optional but highly recommended.

1. In the drop-down box below this, select the data source you want to use. For a detailed overview of all available data sources, see [Query data sources](xref:Query_data_sources).

   > [!IMPORTANT]
   > It is also possible to configure an ad hoc data source in a query. For more information, see [Ad hoc data sources](xref:GQI_Ad_hoc_data_sources).

1. Select an operator. This step is optional; if you do not select an operator, the dataset will be returned untouched. See [Query operators](xref:Query_operators).

1. Add more operators if necessary until your query is fully configured.

   - From DataMiner 10.4.0 [CU13]/10.5.0 [CU1]/10.5.4 onwards<!--RN 42127-->, you can insert new operators anywhere in the sequence, including between existing operators, by clicking the "+" button.

   - From DataMiner 10.4.0 [CU13]/10.5.0 [CU1]/10.5.4 onwards<!--RN 42127-->, you can rearrange operators by dragging and dropping them to a different position on the same level. If an operator turns red after being moved, this indicates that it cannot be used at that location and the query has become invalid. The *Then sort by* operator is a child node of the *Sort by* operator, so if you move a *Sort by* node, all its *Then sort by* child nodes will move with it<!--RN 42229-->.

1. Drag the configured query to the component in order to use it.

> [!NOTE]
>
> - From DataMiner 10.1.4 onwards, you can import a query from a different dashboard in the DMS. For more information, see [Importing a query](xref:Importing_a_query)
> - Using the Data Aggregator module, you can schedule GQI queries to run periodically at fixed times, dates, or intervals. For more information, see [Data Aggregator](xref:Data_Aggregator_DxM).

## Duplicating a query

From DataMiner 10.3.0 [CU10]/10.4.1 onwards, you can duplicate a query. To do so, click the "..." button next to the query in the *Data* pane and then select *Duplicate*.

## Letting DataMiner Assistant create a query

From DataMiner 10.4.0 [CU13]/10.5.0 [CU1]/10.5.4 onwards<!--RN 42234-->, you can use the DataMiner Assistant [natural language to GQI feature](xref:NL2GQI) to automatically create a GQI query based on a request in natural language.

To do so, in a system where DataMiner Assistant has been deployed, when you click the "+" button to add a query, type your request in the textbox and click **Generate query**. DataMiner Assistant will then create the desired GQI query and generate a relevant query name.

![NL2GQI](~/dataminer/images/NL2GQI.png)<br>*Natural language to GQI feature in DataMiner 10.5.4*

> [!TIP]
> For more information about how to deploy this feature, see [DataMiner Assistant DxM](xref:Assistant_DxM).

> [!IMPORTANT]
> DataMiner Assistant can make mistakes. We recommend manually checking the resulting queries and correcting or extending them to your liking when necessary. However, keep in mind that typing a new request and clicking the button a second time will override the query, causing all manual changes to be lost.

## Notes on GQI queries

Please note the following regarding query data input:

- All created queries are listed in alphabetical order in the *Queries* section of the *Data* pane. Immediately after a query is created, it may appear last in the list, but it will be displayed in alphabetical order after you collapse and expand the *Queries* section or reopen the app. Prior to DataMiner 10.4.0 [CU14]/10.5.0 [CU2]/10.5.5<!--RN 42452-->, queries are listed in the order they have been created.

- When a query has been created, the columns from the table that results from the query are available as individual data items in the *Data* pane, so that you can use them to filter or group a component.

- It is not possible to retrieve data from a stopped element.

- From DataMiner 10.1.0/10.1.3 onwards, dynamic units will automatically be used when applicable for the retrieved data if this is enabled in the dashboard settings. This means that parameter units will change dynamically based on their value and protocol definition. You can override the behavior configured for the dashboard in the settings for the component.

- From DataMiner 10.2.0/10.1.4 onwards, if a row is selected in a table component that uses a query data source, any view, service, or element linked to that row is also exposed as a data source. In practice, this means that a data source will be available in the *Components* or *Feeds* section of the *Data* pane (depending on your DataMiner version) that will change based on the selection in the table.

  ![Selected rows](~/dataminer/images/Selected_Rows.png)<br>*Data pane in DataMiner 10.4.12*

- From DataMiner 10.2.0/10.1.5 onwards, you can link GQI nodes that require a time range selection to a time range component by selecting the *From data* checkbox. Prior to DataMiner 10.3.0 [CU21]/10.4.0 [CU9]/10.4.12<!--RN 41141-->, this setting is called "*From feed*".

- From DataMiner 10.3.0 [CU9]/10.3.12 onwards<!--RN 37505-->, the culture used in your GQI query matches the client culture of the web app. Prior to DataMiner 10.3.0 [CU9]/10.3.12, the invariant culture is used.

- From DataMiner 10.3.0 [CU18]/10.4.0 [CU6]/10.4.9 onwards<!--RN 40370-->, a maximum of 30 GQI queries can be added to a dashboard, and a maximum of 200 GQI queries can be added to a low-code app. Once this limit has been reached, no additional GQI queries can be added, imported, or duplicated until one or multiple queries have been removed.
