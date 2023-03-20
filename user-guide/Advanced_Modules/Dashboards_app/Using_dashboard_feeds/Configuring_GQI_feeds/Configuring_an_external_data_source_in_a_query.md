---
uid: Configuring_an_external_data_source_in_a_query
---

# Configuring an external data source in a query

When you create a query, you can also use an external data source.

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

1. In the *Data source* dropdown box, select the name of your ad hoc data source.

Depending on how the script is configured, there can be additional configuration possibilities. You can for instance use the *IGQIInputArguments* interface in the script to define that a specific argument is required, for instance to filter the displayed data. For more information, refer to the sections below.

> [!NOTE]
> From DataMiner 10.2.5/10.3.0 onwards, you can link the arguments of an ad hoc data source to an existing feed in the Dashboards app. Depending on the linked feed, more information may need to be specified. For example, if you link to an existing query feed with a table listing elements, in the *Type* box, you will then need to select whether you want to use a specific data type (e.g. elements) or query rows. Then you will need to select the property you want to use. In most cases, you can select the property in a dropdown list, except if *Type* is set to *Query rows* or *Script output*, in which case you will have to specify the value yourself. For query rows, when you start typing the value, DataMiner will propose any matching values it can find.

## Interfaces in the ad hoc data script

An ad hoc data source is represented as a class that implements predefined interfaces. The interfaces you can use are detailed below.

From DataMiner 10.3.4/10.4.0 onwards, ad hoc data sources can retrieve data by means of DMS messages. <!-- RN 35701 -->

To do so, the [*IGQIDataSource* interface](#igqidatasource) must implement the [*IGQIOnInit* interface](#igqioninit), of which the `OnInit` method can als be used to initialize a data source:

```csharp
OnInitOutputArgs OnInit(OnInitInputArgs args)
```

When passed to the `OnInit` method, `OnInitInputArgs` will contain the following new property:

```csharp
GQIDMS DMS
```

> [!TIP]
> See also: [GQIDMS](#gqidms)

> [!IMPORTANT]
> DMS messages are subject to change without notice. If you can implement an alternative using the [built-in data sources](xref:Query_data_sourcess), we highly recommend that you do so instead.

### IGQIDataSource

This is the only required interface. It must be implemented for the class to be detected by GQI as a data source. This interface has the following methods:

| Method      | Input arguments      | Output arguments | Description                       |
| ----------- | -------------------- | ---------------- | --------------------------------- |
| GetColumns  | -                    | GQIColumn[]      | The GQI will request the columns. |
| GetNextPage | GetNextPageInputArgs | GQIPage          | The GQI will request data.        |

### IGQIInputArguments

This interface can be used to have the user specify an argument, for example the CSV file from which data should be parsed, or a filter that should be applied. This interface has the following methods:

| Method               | Input arguments               | Output arguments               | Description                                                                       |
| -------------------- | ----------------------------- | ------------------------------ | --------------------------------------------------------------------------------- |
| GetInputArguments    | -                             | GQIArgument[]                  | Asks for additional information from the user when the data source is configured. |
| OnArgumentsProcessed | OnArgumentsProcessedInputArgs | OnArgumentsProcessedOutputArgs | Event to indicate that the arguments have been processed.                         |

> [!NOTE]
> The GQI does not validate the input arguments specified by the user. For example, a user can input an SQL query as a string input argument, and the content of the string argument will be forwarded to the ad hoc data source implementation without validation.

### IGQIOnInit

This interface is called when the data source is initialized, for example when the data source is selected in the query builder or when a dashboard using a query with ad hoc data is opened. It can for instance be used to connect to a database. This interface has one method:

| Method | Input arguments | Output arguments | Description |
|--------|-----------------|------------------|-------------|
| OnInit | OnInitInputArgs | OnInitOutputArgs | Indicates that an instance of the class has been created. |

### IGQIOnPrepareFetch

This interface is used to implement optimizations when data is retrieved. This can for instance be used to limit the retrieved data. This interface has one method:

| Method | Input arguments | Output arguments | Description |
|--------|-----------------|------------------|-------------|
|OnPrepareFetch | OnPrepareFetchInputArgs | OnPrepareFetchOutputArgs | Indicated that the GQI has processed the query. |

### IGQIOnDestroy

This interface is called when the instance object is destroyed, which happens when the session is closed, e.g. in case of inactivity or when all the necessary data has been retrieved. It can for instance be used to end the connection with a database. This interface has one method:

| Method | Input arguments | Output arguments | Description |
|--------|-----------------|------------------|-------------|
| OnDestroy | OnDestroyInputArgs | OnDestroyOutputArgs | Indicates that the GQI will close the session. |

## Life cycle of queries with ad hoc data

All methods discussed above are called at some point during the GQI life cycle, depending on whether a query is created or fetched, and depending on whether they have been implemented.

The following flowchart illustrates the GQI life cycle when a query is created:

![GQI query creation life cycle](~/user-guide/images/GQICreateQuery.png)

The following flowchart illustrates the GQI life cycle when a query is fetched:

![GQI query fetching life cycle](~/user-guide/images/GQIFetchQuery.png)

## Objects in the ad hoc data script

To build the ad hoc data source, you can use the objects detailed below.

### GQIColumn

This is an abstract class, with the derived types *GQIStringColumn*, *GQIBooleanColumn*, *GQIIntColumn*, *GQIDateTimeColumn* and *GQIDoubleColumn*, and with the following properties:

| Property | Type          | Required | Description                                                                                                                            |
| -------- | ------------- | -------- | -------------------------------------------------------------------------------------------------------------------------------------- |
| Name     | String        | Yes      | The column name.                                                                                                                       |
| Type     | GQIColumnType | Yes      | The type of data in the column. *GQIColumnType* is an enum that contains the following values: String, Int, DateTime, Boolean or Double. |

### GQIPage

This object has the following properties:

| Property    | Type     | Required | Description                                                                            |
| ----------- | -------- | -------- | -------------------------------------------------------------------------------------- |
| Rows        | GQIRow[] | Yes      | The rows of the page.                                                                  |
| HasNextPage | Boolean  | No       | True if additional pages can be retrieved, False if the current page is the last page. |

### GQIRow

This object has the following properties:

| Property | Type      | Required | Description           |
| -------- | --------- | -------- | --------------------- |
| Cells    | GQICell[] | Yes      | The cells of the row. |

### GQICell

This object has the following properties:

| Property     | Type   | Required | Description                    |
| ------------ | ------ | -------- | ------------------------------ |
| Value        | Object | No       | The value of the cell.         |
| DisplayValue | String | No       | The display value of the cell. |

> [!NOTE]
> The type of value of a cell must match the type of the corresponding column.

### GQIArgument

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

### GQIDMS

Available from DataMiner 10.3.4/10.4.0 onwards. <!-- RN 35701 -->

The `GQIDMS` class contains the following methods, which can be used to request information in the form of `DMSMessage` objects:

| Method | Function |
|--------|----------|
| `DMSMessage SendMessage(DMSMessage message)` | Sends a request that expects a single response. |
| `DMSMessage[] SendMessages(params DMSMessage[] messages)` | Sends multiple requests at once, or sends a request that expects multiple responses. |

Generally, an ad hoc data source implementation will want to add a private field where it can store the `GQIDMS` object to be used later in other callbacks when columns and rows are created.

> [!IMPORTANT]
> DMS messages are subject to change without notice. If you can implement an alternative using the [built-in data sources](xref:Query_data_sources), we highly recommend that you do so instead.

## Example ad hoc data script

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
