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
   > From DataMiner 10.2.0 [CU2]/10.2.5 onwards, a query must have a unique name. If you edit an existing query that has no name, you will need to specify a unique name for it. Prior to this, starting from DataMiner 10.1.0/10.1.1, a query name is optional but highly recommended.

1. In the drop-down box below this, select the data source you want to use. See [Query data sources](#query-data-sources).

1. Select an operator. This step is optional; if you do not select an operator, the entire data set will be used. See [Query operators](#query-operators).

1. Drag the configured query to the component in order to use it.

## Query data sources

When you create a query, you can use one or more of the data sources detailed below.

> [!NOTE]
> Custom properties that are marked as read-only, e.g. the *System Name* and *System Type* alarm properties, can be retrieved with a GQI query from DataMiner 10.2.0 \[CU6]/10.2.9 onwards. In addition, from DataMiner 10.2.10/10.3.0 onwards, the *System Name* and *System Type* data are available as a feed with the *Use feed* option (depending on the data source, as mentioned below).

### Get alarms

Available from DataMiner 10.2.0/10.1.9 onwards. Retrieves the alarms in the DataMiner System. Several columns, such as *Element Name*, *Parameter Description*, *Value* and *Time*, are included by default. Others can be added with a *Select* operation (see [Query operators](#query-operators)).

### Get ad hoc data/custom data

Available from DataMiner 10.3.0/10.2.4 onwards. Retrieves external data based on an Automation script that is compiled as a library. The data can for example be retrieved from a CSV file, a MySQL database, or an API endpoint. If no such Automation script has been configured, this option is not available.

### Get trend data patterns

Available from DataMiner 10.3.3/10.4.0 onwards. Retrieves all pattern matching tags created in the DataMiner System. <!-- RN 35027 -->

### Get trend data pattern events

Available from DataMiner 10.3.3/10.4.0 onwards. Retrieves all pattern occurrences detected in the DataMiner System. The data includes time range metadata on each row, with the start and end time of the event in question. When a table row is selected, the time range will be available as a feed in the *feeds* section of the data pane.<!-- RN 35027 -->

### Get behavioral change events

Available from DataMiner 10.3.3/10.4.0 onwards. Retrieves all behavioral anomalies detected in the DataMiner System. The data includes time range metadata on each row, with the start and end time of the event in question. When a table row is selected, the time range will be available as a feed in the *feeds* section of the data pane. <!-- RN 35027 -->

#### Configuring an external data source in a query

This is the most basic procedure to use an external data source in a query:

1. In the Automation app, add a script containing a new class that implements the *IGQIDatasource* interface (see [Interfaces](#interfaces-in-the-ad-hoc-data-script)).

   > [!NOTE]
   > All object types needed to create an ad hoc data source can be found within *SLAnalyticsTypes.dll*, which is located in the folder *C:\Skyline DataMiner\Files*.

1. Above the class, add the *GQIMetaData* attribute in order to configure the name of the data source as displayed in the Dashboards app.

   For example (see [Example ad hoc data script](#example-ad-hoc-data-script) for a full example):

   ```csharp
   using Skyline.DataMiner.Analytics.GenericInterface;

   [GQIMetaData(Name = "People")]
   public class MyDataSource : IGQIDataSource
   {
   ...
   }
   ```

   > [!NOTE]
   > This is the name that will be shown to the user when they select the data in the Dashboards app. If you do not configure this name, the name of the class is displayed instead, which may not be very user-friendly.

1. Compile the script as a library (see [Compiling a C# code block as a library](xref:Compiling_a_CSharp_code_block_as_a_library). You can use the same name as defined in the *GQIMetaData* attribute, or a different name. If there are different data sources for which the same name is defined in the *GQIMetaData* attribute, the library name is appended to the metadata name.

1. Validate and save the script. It is important that you do this after you have compiled the script as a library, as otherwise the compiler will detect errors.

1. In the Dashboards app, configure a query and select the data source *Get ad hoc data* or *Get custom data*, depending on your DataMiner version.

1. In the *Data source* drop-down box, select the name of your ad hoc data source.

Depending on how the script is configured, there can be additional configuration possibilities. You can for instance use the *IGQIInputArguments* interface in the script to define that a specific argument is required, for instance to filter the displayed data. For more information, refer to the sections below.

> [!NOTE]
> From DataMiner 10.2.5/10.3.0 onwards, you can link the arguments of an ad hoc data source to an existing feed in the Dashboards app. Depending on the linked feed, more information may need to be specified. For example, if you link to an existing query feed with a table listing elements, in the *Type* box, you will then need to select whether you want to use a specific data type (e.g. elements) or query rows. Then you will need to select the property you want to use. In most cases, you can select the property in a drop-down list, except if *Type* is set to *Query rows* or *Script output*, in which case you will have to specify the value yourself. For query rows, when you start typing the value, DataMiner will propose any matching values it can find.

#### Interfaces in the ad hoc data script

An ad hoc data source is represented as a class that implements predefined interfaces. The interfaces you can use are detailed below.

##### IGQIDataSource

This is the only required interface. It must be implemented for the class to be detected by GQI as a data source. This interface has the following methods:

| Method      | Input arguments      | Output arguments | Description                       |
| ----------- | -------------------- | ---------------- | --------------------------------- |
| GetColumns  | -                    | GQIColumn[]      | The GQI will request the columns. |
| GetNextPage | GetNextPageInputArgs | GQIPage          | The GQI will request data.        |

##### IGQIInputArguments

This interface can be used to have the user specify an argument, for example the CSV file from which data should be parsed, or a filter that should be applied. This interface has the following methods:

| Method               | Input arguments               | Output arguments               | Description                                                                       |
| -------------------- | ----------------------------- | ------------------------------ | --------------------------------------------------------------------------------- |
| GetInputArguments    | -                             | GQIArgument[]                  | Asks for additional information from the user when the data source is configured. |
| OnArgumentsProcessed | OnArgumentsProcessedInputArgs | OnArgumentsProcessedOutputArgs | Event to indicate that the arguments have been processed.                         |

> [!NOTE]
> The GQI does not validate the input arguments specified by the user. For example, a user can input an SQL query as a string input argument, and the content of the string argument will be forwarded to the ad hoc data source implementation without validation.

##### IGQIOnInit

This interface is called when the data source is initialized, for example when the data source is selected in the query builder or when a dashboard using a query with ad hoc data is opened. It can for instance be used to connect to a database. This interface has one method:

| Method | Input arguments | Output arguments | Description |
|--------|-----------------|------------------|-------------|
| OnInit | OnInitInputArgs | OnInitOutputArgs | Indicates that an instance of the class has been created. |

##### IGQIOnPrepareFetch

This interface is used to implement optimizations when data is retrieved. This can for instance be used to limit the retrieved data. This interface has one method:

| Method | Input arguments | Output arguments | Description |
|--------|-----------------|------------------|-------------|
|OnPrepareFetch | OnPrepareFetchInputArgs | OnPrepareFetchOutputArgs | Indicated that the GQI has processed the query. |

##### IGQIOnDestroy

This interface is called when the instance object is destroyed, which happens when the session is closed, e.g. in case of inactivity or when all the necessary data has been retrieved. It can for instance be used to end the connection with a database. This interface has one method:

| Method | Input arguments | Output arguments | Description |
|--------|-----------------|------------------|-------------|
| OnDestroy | OnDestroyInputArgs | OnDestroyOutputArgs | Indicates that the GQI will close the session. |

#### Life cycle of queries with ad hoc data

All methods discussed above are called at some point during the GQI life cycle, depending on whether a query is created or fetched, and depending on whether they have been implemented.

The following flowchart illustrates the GQI life cycle when a query is created:

![GQI query creation life cycle](~/user-guide/images/GQICreateQuery.png)

The following flowchart illustrates the GQI life cycle when a query is fetched:

![GQI query fetching life cycle](~/user-guide/images/GQIFetchQuery.png)

#### Objects in the ad hoc data script

To build the ad hoc data source, you can use the objects detailed below.

##### GQIColumn

This is an abstract class, with the derived types *GQIStringColumn*, *GQIBooleanColumn*, *GQIIntColumn*, *GQIDateTimeColumn* and *GQIDoubleColumn*, and with the following properties:

| Property | Type          | Required | Description                                                                                                                            |
| -------- | ------------- | -------- | -------------------------------------------------------------------------------------------------------------------------------------- |
| Name     | String        | Yes      | The column name.                                                                                                                       |
| Type     | GQIColumnType | Yes      | The type of data in the column. *GQIColumnType* is an enum that contains the following values: String, Int, DateTime, Boolean or Double. |

##### GQIPage

This object has the following properties:

| Property    | Type     | Required | Description                                                                            |
| ----------- | -------- | -------- | -------------------------------------------------------------------------------------- |
| Rows        | GQIRow[] | Yes      | The rows of the page.                                                                  |
| HasNextPage | Boolean  | No       | True if additional pages can be retrieved, False if the current page is the last page. |

##### GQIRow

This object has the following properties:

| Property | Type      | Required | Description           |
| -------- | --------- | -------- | --------------------- |
| Cells    | GQICell[] | Yes      | The cells of the row. |

##### GQICell

This object has the following properties:

| Property     | Type   | Required | Description                    |
| ------------ | ------ | -------- | ------------------------------ |
| Value        | Object | No       | The value of the cell.         |
| DisplayValue | String | No       | The display value of the cell. |

> [!NOTE]
> The type of value of a cell must match the type of the corresponding column.

##### GQIArgument

This is an abstract class with the following properties:

| Property   | Type    | Required | Description                                 |
| ---------- | ------- | -------- | ------------------------------------------- |
| Name       | String  | Yes      | The name of the input argument.             |
| IsRequired | Boolean | No       | Indicates whether the argument is required. |

The following derived types are supported from DataMiner 10.3.0/10.2.4 onwards:

- `GQIStringArgument`
- `GQIDoubleArgument`

In addition, the following derived types are supported from DataMiner 10.3.0/10.2.7 onwards:

- `GQIBooleanArgument`
- `GQIDateTimeArgument`
- `GQIIntArgument`
- `GQIStringDropdownArgument`
- `GQIStringListArgument`

#### Example ad hoc data script

Below you can find an example script that forwards dummy data to the GQI. The name of the data source, as defined in the *GQIMetaData* attribute, will be “People”.

First the *IGQIDataSource* interface is implemented, then *GetColumns* is used to define the custom columns for the data source. In this case, there are 5 columns. The *GetNextPage* method then returns the actual data to the GQI. In this case these are 3 rows, defined as an array of cells. For each cell, a display value can also be defined. In this case, this is done for the cells within the *Height* column to indicate the unit of measure. The *HasNextPage* property is set to *False* to indicate that no additional pages need to be fetched.

The optional *IGQIInputArguments* interface is also implemented in the example, in this case to allow the user to add an input argument indicating the minimum age for the records that will be retrieved. The argument is indicated as required, so the user will have to specify it to be able to configure the query. The argument value is retrieved with *OnArgumentsProcessedInputArgs* and used to filter the returned data.

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using Skyline.DataMiner.Analytics.GenericInterface;

[GQIMetaData(Name = "People")]
public class MyDataSource : IGQIDataSource, IGQIInputArguments
{
    private GQIDoubleArgument _argument = new GQIDoubleArgument("Age") { IsRequired = true };
    private double _minimumAge;

    public GQIColumn[] GetColumns()
    {
        return new GQIColumn[]
        {
            new GQIStringColumn("Name"),
            new GQIIntColumn("Age"),
            new GQIDoubleColumn("Height (m)"),
            new GQIDateTimeColumn("Birthday"),
            new GQIBooleanColumn("Likes apples")
        };
    }

    public GQIArgument[] GetInputArguments()
    {
        return new GQIArgument[] { _argument };
    }

    public OnArgumentsProcessedOutputArgs OnArgumentsProcessed(OnArgumentsProcessedInputArgs args)
    {
        _minimumAge = args.GetArgumentValue(_argument);
        return new OnArgumentsProcessedOutputArgs();
    }

    public GQIPage GetNextPage(GetNextPageInputArgs args)
    {
        var rows = new List<GQIRow>() {
            new GQIRow(
                new GQICell[]
                    {
                        new GQICell() { Value = "Alice" },
                        new GQICell() { Value = 32 },
                        new GQICell() { Value = 1.74, DisplayValue = "1.74 m" },
                        new GQICell() { Value = new DateTime(1990, 5, 12) },
                        new GQICell() { Value = true }
                    }),
            new GQIRow(
                new GQICell[]
                    {
                        new GQICell() { Value = "Bob" },
                        new GQICell() { Value = 22 },
                        new GQICell() { Value = 1.85, DisplayValue = "1.85 m" },
                        new GQICell() { Value = new DateTime(2000, 1, 22) },
                        new GQICell() { Value = true }
                    }),
            new GQIRow(
                new GQICell[]
                    {
                        new GQICell() { Value = "Carol" },
                        new GQICell() { Value = 27 },
                        new GQICell() { Value = 1.67, DisplayValue = "1.67 m" },
                        new GQICell() { Value = new DateTime(1995, 10, 3) },
                        new GQICell() { Value = false }
                    })
            };

        var filteredRows = rows.Where(row => (int)row.Cells[1].Value > _minimumAge).ToArray();

        return new GQIPage(filteredRows)
        {
            HasNextPage = false
        };
    }
}
```

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
>
> - From DataMiner 10.3.3/10.4.0 onwards, after an aggregation operation, you can apply multiple *GroupBy* operations.
> - From DataMiner 10.1.0/10.1.3 onwards, exception values are not taken into account, except for the Count and Distinct Count methods. <!-- RN35355 -->

### Column manipulations

Creates a new column based on existing columns. When you select this option, you also need to select a manipulation method:

If you choose the *Concatenate* method, you will need to select several columns and then specify the format that should be used to concatenate the content of those columns, using placeholders in the format {0}, {1}, etc. to refer to those columns.

If you choose the *Regexmatch* method, you will need to select a column and specify a regular expression, so that the new column will only contain the items from the selected column that match the regular expression.

For both manipulation methods, you will also need to specify the name for the new column. When the column manipulation operation is fully configured, you can further fine-tune the result by applying another operator.

### Filter

Filters the data set. When you select this option, select the column to filter, specify the filter method (e.g. equals, greater than, etc.) and the value to use as a filter. The available filter methods depend on the type of data in the selected column. Once the filter has been fully configured, you can refine the results by applying another operator, e.g. an additional filter.

From DataMiner 10.2.0/10.1.3 onwards, instead of specifying an exact filter value, you can select *Use feed* to use one of the available feeds in the dashboard as the column filter. Depending on the type of data in the feed, you will then need to specify the following information:

- *Feed*: The name of the feed that should provide the data. If only one feed is available, it will automatically be selected.

- *Type*: The type of data that needs to be selected. If the feed only provides one type of data, it will automatically be selected. The type *Query rows* (available from DataMiner 10.2.0 [CU2]/10.2.4 onwards) allows you to link the filter to rows from another query, if a compatible query is available.

- *Property*: The property by which the column will be filtered (depending on the type of data).

  If *Type* is set to *Query rows*, instead of a property, you can select the columns from the table containing the query rows. However, note that you will only be able to select columns that are compatible with the type of column you are filtering.

From DataMiner 10.2.10/10.3.0 onwards, an additional option, *When feed is empty, show* is available, which allows you to select what should be shown in case the field is empty: nothing, empty values only, or the full table ("*everything*"). Prior to this, from DataMiner 10.1.11 onwards, instead the option *Return no rows when feed is empty* is available. When you select this option, in case the feed is empty, an empty table will be returned instead of the entire table.

> [!NOTE]
>
> - Index feeds are only supported from DataMiner 10.2.0/10.1.5 onwards.
> - If the *regex* or *not regex* filter method is used, and *Use feed* is selected, from DataMiner 10.1.2/10.1.5 onwards, if the feed contains multiple values, these are combined with an "or" operator.

### Join

Joins two tables together. When you select this option, in the *Type* drop-down box, you will first need to select how the tables should be joined. Then you will need to select another data source (optionally refined with one or more operators) in order to specify the table you want the first table to be joined with. Optionally, you can also specify a condition to determine when rows should be joined. For instance, if one table contains elements with a custom property that details a booking ID and the other lists bookings, you could add the condition that the property in the first table must match the ID in the second table.

The *Inner* type of join only includes rows if they match the condition. *Left* displays all rows from the first table (i.e. the table on the left) and only the matching rows from the other table. *Right* does the opposite. *Outer* displays first the non-matching rows from the left table, then the matching rows from both tables, then the non-matching rows from the right table.

From DataMiner 10.3.3/10.4.0 onwards, the *Row by row* option allows you to first execute the query for the first table, and then execute the query for the other table for each row that matches the join condition. This option is only available if you add the `showAdvancedSettings=true` option to the dashboard URL. If the *Row by row* option is not enabled, the join will execute both tables once and directly combine their results. <!-- RN 35565 + 35057 -->

> [!NOTE]
> The *Row by row* option is only supported for *Inner* and *Left* type of joins.

### Select

Displays the selected columns only. When you have selected the columns to display, you can apply another operator to refine the query.

From DataMiner 10.1.0\[CU1\]/10.1.3 onwards, up and down arrow buttons in the list of columns allow you to modify the order in which the columns are loaded. Click an arrow button to make a column switch places with the column below or above it in the list. Press Ctrl while clicking an arrow button to make the column switch places with the previous or next selected column instead.

From DataMiner 10.2.0/10.1.5 onwards, a *Use feed* checkbox is available that allows you to add parameters from an existing feed in the dashboard to the selectable items.

### Sort

Available from dataMiner 10.2.11/10.3.0 onwards. Sorts the data based on a specific column. When you select this operator, you will need to select the column to sort by. By default, sorting happens in descending order. To sort in ascending order instead, select the *Ascending* checkbox.

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
