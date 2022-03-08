---
uid: Configuring_GQI_feeds
---

# Configuring query (GQI) data feeds

From DataMiner 10.0.13 onwards, a special type of data feed is available, using the Generic Query Interface. This “Queries” data item allows you to construct a query in order to tap into the wealth of data available in your DataMiner System.

## Creating a query

You can create a query as follows:

1. In edit mode, select the dashboard component for which you want to use a query as a data input. At present, this is support for Bar chart, Pie chart, State and Table components.

1. In the data pane, select *Queries* and click the + icon to add a new query.

1. Specify a name for the query.

   > [!NOTE]
   > From DataMiner 10.1.0/10.1.1 onwards, specifying a name is optional. However, note that this is still recommended, as a name can help clarify what the purpose of the query is.

1. In the drop-down box below this, select the data source you want to use. See [Query data sources](#query-data-sources).

1. Select an operator. This step is optional; if you do not select an operator, the entire data set will be used. See [Query operators](#query-operators).

1. Drag the configured query to the component in order to use it.

## Query data sources

When you create a query, you can use one or more of the data sources detailed below.

### Get alarms

Available from DataMiner 10.2.0/10.1.9 onwards. Retrieves the alarms in the DataMiner System. Several columns, such as *Element Name*, *Parameter Description*, *Value* and *Time*, are included by default. Others can be added with a *Select* operation (see [Query operators](#query-operators)).

### Get DCF connections

Available from DataMiner 10.2.0/10.1.6 onwards. Retrieves a list of the DCF connections in the DataMiner System. For each connection, this includes the source and destination element ID and interface ID, the ID of the connection, any properties on interfaces, any parameters that interfaces are linked to, and an *IsInternal* column that indicates whether the connection is internal or external.

> [!NOTE]
> DCF connections are returned for each active element. As external connections are configured both on the source element and the destination element, each external connection will therefore be listed twice if both elements are active. If both the source element and the destination element of an external connection are stopped, the connection will not be listed. If only the source element or the destination element is stopped, the connection will be listed once.

> [!TIP]
> See also: [DataMiner Connectivity Framework](xref:DCF#dataminer-connectivity-framework)

### Get elements

Retrieves the elements in the DataMiner System.

### Get parameter table by alias

Retrieves a parameter table from the Elasticsearch database using the specified alias.

### Get parameter table by ID

Retrieves the selected parameter table from the element with the specified DataMiner ID and element ID.

From DataMiner 10.2.0/10.1.5 onwards, a *Use feed* checkbox is available that allows you to retrieve a parameter table from an existing feed in the dashboard.

From DataMiner 10.2.0/10.2.1 onwards, an *Update data* option is available in the *Settings* pane if you use this data source. When you enable this, the component will automatically refresh the data when changes are detected.

### Get parameters for element where

Retrieves the selected parameters for the specified protocol or the parameters linked to the specified profile definition. Note that if parameters are displayed based on a specific protocol, it is not possible to combine a table parameter with other parameters, and only column parameters from the same table can be displayed in the same query. 

From DataMiner 10.2.0/10.1.5 onwards, if a protocol and version have been specified, a *Use feed* checkbox is available that allows you to also retrieve parameters from an existing feed in the dashboard.

### Get services

Retrieves the services in the DataMiner System.

### Get view relations

Available from DataMiner 10.2.0/10.1.4 onwards. Retrieves a list of the DataMiner objects that are direct children of views in the DMS. The list includes the following columns:

- *View ID*: The ID of the view containing the object.

- *Child ID*: The ID of the object.

- *Depth*: The level of the object in the tree view in relation to the root view.

Select the *Recursive* option for this data source to also include objects that are not directly included in a view, e.g. child objects of objects within the view.

### Get views

Available from DataMiner 10.2.0/10.1.4 onwards. Retrieves a list of the views in the DMS. By default, only the columns *View ID* and *Name* are included, but you can include additional columns using a *Select* operator.

### Start from

Available from DataMiner 10.1.0/10.1.1 onwards. If another query has already been configured in the dashboard, this data source allows you to start from that query and then refine it further. However, note that if the query you start from is modified, the new query that makes use of it will not be updated unless it is also modified or the dashboard is refreshed.

> [!NOTE]
> By default, only a limited number of columns will be displayed in the dashboard for certain data sources. For example, for a parameter table, only the first 10 columns are displayed by default. In such a case, you can use the *Select* operator to display other columns or more columns than this default (see [Query operators](#query-operators)).

## Query operators

When you create a query, you can use the operators detailed below.

### Aggregate

Allows you to aggregate data from the data source. After you have selected this option, first select the aggregation column, and the method that should be used. Depending on the type of data available in the selected column, different methods are available, e.g. Average, Count, Distinct Count, Maximum, Median, Minimum, Percentile 90/95/98 or Standard deviation.

You can then further filter the result by applying another operator. An additional *Group by* operator is available for this, which will display the result of the aggregation operation for each different item in the column selected in the *Group by column* box.

> [!NOTE]
> From DataMiner 10.1.0/10.1.3 onwards, exception values are not taken into account, except for the Count and Distinct Count methods.

### Column manipulations

Creates a new column based on existing columns. When you select this option, you also need to select a manipulation method:

If you choose the *Concatenate* method, you will need to select several columns and then specify the format that should be used to concatenate the content of those columns, using placeholders in the format {0}, {1}, etc. to refer to those columns.

If you choose the *Regexmatch* method, you will need to select a column and specify a regular expression, so that the new column will only contain the items from the selected column that match the regular expression.

For both manipulation methods, you will also need to specify the name for the new column. When the column manipulation operation is fully configured, you can further fine-tune the result by applying another operator.

### Filter

Filters the data set. When you select this option, select the column to filter, specify the filter method (e.g. equals, greater than, etc.) and the value to use as a filter. The available filter methods depend on the type of data in the selected column. Once the filter has been fully configured, you can refine the results by applying another operator, e.g. an additional filter.

From DataMiner 10.2.0/10.1.3 onwards, instead of specifying an exact filter value, you can select *Use feed* to use one of the available feeds in the dashboard as the column filter. Depending on the type of data in the feed, you will then need to specify the following information:

- *Feed*: The name of the feed that should provide the data. If only one feed is available, it will automatically be selected.

- *Type*: The type of data that needs to be selected. If the feed only provides one type of data, it will automatically be selected.

- *Property*: The property by which the column will be filtered (depending on the type of data).

From DataMiner 10.1.11 onwards, an additional option, *Return no rows when feed is empty*, is available. When you select this option, in case the feed is empty, an empty table will be returned instead of the entire table.

> [!NOTE]
> - Index feeds are only supported from DataMiner 10.2.0/10.1.5 onwards.
> - If the *regex* or *not regex* filter method is used, and *Use feed* is selected, from DataMiner 10.1.2/10.1.5 onwards, if the feed contains multiple values, these are combined with an "or" operator.

### Join

Joins two tables together. When you select this option, in the *Type* drop-down box, you will first need to select how the tables should be joined. Then you will need to select another data source (optionally refined with one or more operators) in order to specify the table you want the first table to be joined with. Optionally, you can also specify a condition to determine when rows should be joined. For instance, if one table contains elements with a custom property that details a booking ID and the other lists bookings, you could add the condition that the property in the first table must match the ID in the second table.

The *Inner* type of join only includes rows if they match the condition. *Left* displays all rows from the first table (i.e. the table on the left) and only the matching rows from the other table. *Right* does the opposite. *Outer* displays first the non-matching rows from the left table, then the matching rows from both tables, then the non-matching rows from the right table.

### Select

Displays the selected columns only. When you have selected the columns to display, you can apply another operator to refine the query.

From DataMiner 10.1.0\[CU1\]/10.1.3 onwards, up and down arrow buttons in the list of columns allow you to modify the order in which the columns are loaded. Click an arrow button to make a column switch places with the column below or above it in the list. Press Ctrl while clicking an arrow button to make the column switch places with the previous or next selected column instead.

From DataMiner 10.2.0/10.1.5 onwards, a *Use feed* checkbox is available that allows you to add parameters from an existing feed in the dashboard to the selectable items.

### Top X

Displays the top or bottom items of a specific column, with X being the number of items to display. When you select this option, you will need to specify the column from which items should be displayed and the number of items that should be displayed. By default, the top items are displayed. To display the bottom items instead, select the *Ascending* checkbox.

> [!NOTE]
> From DataMiner 10.1.0/10.1.3 onwards, exception values are not taken into account by this operator.

## Importing a query

From DataMiner 10.1.4 onwards, you can import a query from a different dashboard in the DMS. To do so:

1. In the data pane, select *Queries* and click the import icon (to the right of the + icon).

1. In the dialog box, select the dashboard from which you want to import the query and the query itself, and specify a name for the query in your dashboard.

1. Click *Import*. The query will now be available for use in the data pane.

## Notes on GQI queries

Please note the following regarding query data input:

- When a query has been created, the columns from the table that results from the query are available as individual data items in the data pane, so that you can use them to filter or group a component.

- It is not possible to retrieve data from a stopped element.

- From DataMiner 10.1.0/10.1.3 onwards, dynamic units will automatically be used when applicable for the retrieved data if this is enabled in the dashboard settings. This means that parameter units will change dynamically based on their value and protocol definition. You can override the behavior configured for the dashboard in the settings for the component.

- From DataMiner 10.2.0/10.1.4 onwards, if a row is selected in a table component that uses a query feed, any view, service or element linked to that row is also exposed as a feed. In practice, this means that a feed will be available in the *feeds* section of the data pane that will change based on the selection in the table.

- From DataMiner 10.2.0/10.1.5 onwards, you can link GQI nodes that require a time range selection to a time range feed by selecting the *From feed* checkbox.
