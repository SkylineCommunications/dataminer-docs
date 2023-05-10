---
uid: Query_data_sources
---

# Query data sources

When you create a query, you can use one or more of the data sources detailed below.

> [!NOTE]
>
> - Some data sources can be linked to a feed. From DataMiner 10.3.5/10.4.0 onwards<!--  RN 35837 -->, a link icon is displayed to the right of a selection box if using a feed is possible. Click this icon to select the feed. In earlier DataMiner versions, a *Use feed* checkbox is available for this instead.
> - Custom properties that are marked as read-only, e.g. the *System Name* and *System Type* alarm properties, can be retrieved with a GQI query from DataMiner 10.2.0 \[CU6]/10.2.9 onwards. In addition, from DataMiner 10.2.10/10.3.0 onwards, the *System Name* and *System Type* data are available as a feed (depending on the data source, as mentioned below).

## Get alarms

Available from DataMiner 10.2.0/10.1.9 onwards. Retrieves the alarms in the DataMiner System. Several columns, such as *Element Name*, *Parameter Description*, *Value* and *Time*, are included by default. Others can be added with a *Select* operation (see [Query operators](xref:Query_operators)).

## Get ad hoc data/custom data

Available from DataMiner 10.3.0/10.2.4 onwards. Retrieves external data based on an Automation script that is compiled as a library. The data can for example be retrieved from a CSV file, a MySQL database, or an API endpoint. If no such Automation script has been configured, this option is not available.

> [!TIP]
> See: [Configuring an external data source in a query](xref:Configuring_an_external_data_source_in_a_query)

## Get trend data patterns

Available from DataMiner 10.3.3/10.4.0 onwards. Retrieves all pattern matching tags created in the DataMiner System. <!-- RN 35027 -->

## Get trend data pattern events

Available from DataMiner 10.3.3/10.4.0 onwards. Retrieves all pattern occurrences detected in the DataMiner System. The data includes time range metadata on each row, with the start and end time of the event in question. When a table row is selected, the time range will be available as a feed in the *feeds* section of the data pane.<!-- RN 35027 -->

## Get behavioral change events

Available from DataMiner 10.3.3/10.4.0 onwards. Retrieves all behavioral anomalies detected in the DataMiner System. The data includes time range metadata on each row, with the start and end time of the event in question. When a table row is selected, the time range will be available as a feed in the *feeds* section of the data pane. <!-- RN 35027 -->

## Get DCF connections

Available from DataMiner 10.2.0/10.1.6 onwards. Retrieves a list of the DCF connections in the DataMiner System. For each connection, this includes the source and destination element ID and interface ID, the ID of the connection, any properties on interfaces, any parameters that interfaces are linked to, and an *IsInternal* column that indicates whether the connection is internal or external.

> [!NOTE]
> DCF connections are returned for each active element. As external connections are configured both on the source element and the destination element, each external connection will therefore be listed twice if both elements are active. If both the source element and the destination element of an external connection are stopped, the connection will not be listed. If only the source element or the destination element is stopped, the connection will be listed once.

> [!TIP]
> See also: [DataMiner Connectivity Framework](xref:DCF#dataminer-connectivity-framework)

## Get elements

Retrieves the elements in the DataMiner System. From DataMiner 10.3.3/10.4.0 onwards, *Get elements* also returns alarm states. <!-- RN 35464 -->

## Get parameter table by alias

Retrieves a parameter table from the Elasticsearch database using the specified alias.

## Get object manager instances

Retrieves [DOM instances](xref:DomInstance).

## Get parameter table by ID

Retrieves the selected parameter table from the element with the specified DataMiner ID and element ID.

From DataMiner 10.2.0/10.1.5 onwards, you can retrieve a parameter table from an existing feed in the dashboard. Prior to DataMiner 10.3.5/10.4.0<!--  RN 35837 -->, you can do so using the *Use feed* checkbox. In more recent DataMiner versions, you can instead click the link icon to the right of the relevant selection box.

From DataMiner 10.2.0/10.2.1 onwards, an *Update data* option is available in the *Settings* pane if you use this data source. When you enable this, the component will automatically refresh the data when changes are detected.

## Get parameter relations

Available from DataMiner 10.3.3/10.4.0 onwards. Retrieves the parameter relationships that are stored in a model managed by the DataMiner Extension Module *ModelHost*. <!-- RN 35443 -->

> [!NOTE]
> *Get parameter relations* is only available when the *ModelHost* DxM is running.

## Get parameters for element where

Retrieves the selected parameters for the specified protocol or the parameters linked to the specified profile definition. Note that if parameters are displayed based on a specific protocol, it is not possible to combine a table parameter with other parameters, and only column parameters from the same table can be displayed in the same query.

From DataMiner 10.2.0/10.1.5 onwards, if a protocol and version have been specified, you can retrieve parameters from an existing feed in the dashboard. Prior to DataMiner 10.3.5/10.4.0<!--  RN 35837 -->, you can do so using the *Use feed* checkbox. In more recent DataMiner versions, you can instead click the link icon to the right of the relevant selection box.

## Get services

Retrieves the services in the DataMiner System. From DataMiner 10.3.3/10.4.0 onwards, *Get services* also returns alarm states. <!-- RN 35464 -->

## Get view relations

Available from DataMiner 10.2.0/10.1.4 onwards. Retrieves a list of the DataMiner objects that are direct children of views in the DMS. The list includes the following columns:

- *View ID*: The ID of the view containing the object.

- *Child ID*: The ID of the object.

- *Depth*: The level of the object in the tree view in relation to the root view.

Select the *Recursive* option for this data source to also include objects that are not directly included in a view, e.g. child objects of objects within the view.

## Get views

Available from DataMiner 10.2.0/10.1.4 onwards. Retrieves a list of the views in the DMS. By default, only the columns *View ID* and *Name* are included, but you can include additional columns using a *Select* operator.

## Start from

Available from DataMiner 10.1.0/10.1.1 onwards. If another query has already been configured in the dashboard, this data source allows you to start from that query and then refine it further. However, note that if the query you start from is modified, the new query that makes use of it will not be updated unless it is also modified or the dashboard is refreshed.

> [!NOTE]
> By default, only a limited number of columns will be displayed in the dashboard for certain data sources. For example, for a parameter table, only the first 10 columns are displayed by default. In such a case, you can use the *Select* operator to display other columns or more columns than this default (see [Query operators](xref:Query_operators)).
