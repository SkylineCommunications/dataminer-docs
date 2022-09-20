---
uid: General_Main_Release_10.3.0_new_features_2
---

# General Main Release 10.3.0 – New features (part 2) - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes related to DataMiner Cube, see [DataMiner Cube 10.3.0](xref:Cube_Main_Release_10.3.0).

## New features

### DMS web apps

#### Jobs app: Name, Start Time and End Time fields in default job section can now be set read-only \[ID_31485\] \[ID_31506\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.1 -->

In the default job section, the *Name*, *Start Time*, and *End Time* fields can now be set read-only.

#### Ticketing app: System name will now be checked for illegal characters \[ID_31496\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.1 -->

From now on, the system name of a ticket will no longer be allowed to start with an underscore character or contain one of the following characters: . # \* , " '

When the system name contains one of these illegal characters, an error message will appear.

#### Jobs app: Fields will automatically be set to 'not required' when hidden \[ID_31513\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.1 -->

From now on, when you hide a job field, you will receive a message that it will automatically be set to “not required”.

> [!NOTE]
> When you unhide a hidden field, it will remain set to “not required”.

#### Dashboards app - GQI: Element, service and view data sources now also return an 'In timeout' column \[ID_31671\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.1 -->

The element, service and view data sources now return an additional “In timeout” column.

| Data source | Meaning of “True” in “In timeout” column                                                                        |
|-------------|-----------------------------------------------------------------------------------------------------------------|
| Element     | The (replication) element is in timeout.                                                                        |
| Service     | One of the elements in the service is in timeout.                                                               |
| View        | The enhancing element, one of the first-level child elements or one of the recursive child views is in timeout. |

#### Dashboards app - Node edge graph: Option to visualize the direction of the edges \[ID_32519\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.4 -->

When configuring a node edge graph, it is now possible to have the graph visualize the direction of the edges.

To do so, enable the *Visualize directions* setting and select one of the following options:

| Option         | Description                                                                                                                                                           |
|----------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Flow (default) | The direction is visualized by means of animated edges.                                                                                                               |
| Arrows         | The direction is visualized by means of arrows drawn on the edges. If you select this option, you can also specify the exact position of the arrows on the edges. |

#### Dashboards app: Default index filter for parameter feed component \[ID_32595\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.4 -->

It is now possible to add a default index filter to a parameter feed component. This way, it's not necessary to apply your filter to the component again whenever the dashboard is refreshed.

This new option is available as an advanced setting that is not displayed by default. To be able to configure it, you therefore first need to add the *showAdvancedSettings=true* option to the dashboard URL. In the *Data* pane of the dashboard edit mode, a new *Parameter table filters* section will then become available. You can configure the default filter in this section and then drag it to a component to apply it.

#### Dashboards app: GQI now supports external data \[ID_32656\] \[ID_32659\] \[ID_32930\] \[ID_33795\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.4
RN 33795: Main Release Version 10.3.0 - Feature Release Version 10.2.8 -->

It is now possible to configure the Generic Query Interface to retrieve external data, so that dashboard users can use a query data source based on data that is for example retrieved from a CSV file, a MySQL database, or an API endpoint. This is configured through a DataMiner Automation script that is compiled as a library. The GQI will make use of this library to load the external data.

##### Configuring an external data source in a query

This is the most basic procedure to use an external data source in a query:

1. In the Automation app, add a script containing a new class that implements the *IGQIDatasource* interface (see below for more detailed info).

1. Above the class, add the *GQIMetaData* attribute in order to configure the name of the data source as displayed in the Dashboards app.

   For example (see [Example script](#example-script) for a full example):

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

1. [Compile the script as a library](https://docs.dataminer.services/user-guide/Advanced_Modules/Automation/Using_CSharp/Compiling_a_CSharp_code_block_as_a_library.html#compiling-the-library). You can use the same name as defined in the *GQIMetaData* attribute, or a different name. If there are different data sources for which the same name is defined in the *GQIMetaData* attribute, the library name is appended to the metadata name.

1. Validate and save the script. It is important that you do this *after* you have compiled the script as a library, as otherwise the compiler will detect errors.

1. In the Dashboards app, configure a query and select the data source *Get ad hoc data*.

1. In the *Data source* drop-down box, select the name of your ad hoc data source.

Depending on how the script is configured, there can be additional configuration possibilities. You can for instance use the *IGQIInputArguments* interface in the script to define that a specific argument is required, for instance to filter the displayed data. For more information, refer to the sections below.

##### Interfaces

An ad hoc data source is represented as a class that implements predefined interfaces. The interfaces you can use are detailed below.

- **IGQIDataSource**: This is the only **required** interface. It must be implemented for the class to be detected by GQI as a data source. This interface has the following methods:

    | Method    | Input arguments       | Output arguments | Description                       |
    |-------------|-----------------------|------------------|-----------------------------------|
    | GetColumns  |                       | GQIColumn\[\]    | The GQI will request the columns. |
    | GetNextPage | GetNextPageInputArgs | GQIPage          | The GQI will request data.        |

- **IGQIInputArguments**: This interface can be used to have the user specify an argument, for example the CSV file from which data should be parsed, or a filter that should be applied. This interface has the following methods:

    | Method              | Input arguments                | Output arguments                | Description                                                                       |
    |-----------------------|--------------------------------|---------------------------------|-----------------------------------------------------------------------------------|
    | GetInputArguments    | \-                             | GQIArgument\[\]                 | Asks for additional information from the user when the data source is configured. |
    | OnArgumentsProcessed | OnArgumentsProcessedInputArgs | OnArgumentsProcessedOutputArgs | Event to indicate that the arguments have been processed.                         |

    > [!NOTE]
    > The GQI does not validate the input arguments specified by the user. For example, a user can input an SQL query as a string input argument, and the content of the string argument will be forwarded to the ad hoc data source implementation without validation.

- **IGQIOnInit**: This interface is called when the data source is initialized, for example when the data source is selected in the query builder or when a dashboard using a query with ad hoc data is opened. It can for instance be used to connect to a database. This interface has one method:

    | Method | Input arguments | Output arguments | Description                                               |
    |----------|-----------------|------------------|-----------------------------------------------------------|
    | OnInit   | OnInitInputArgs | OnInitOutputArgs | Indicates that an instance of the class has been created. |

- **IGQIOnPrepareFetch**: This interface is used to implement optimizations when data is retrieved. This can for instance be used to limit the retrieved data. This interface has one method:

    | Method       | Input arguments          | Output arguments          | Description                                     |
    |----------------|--------------------------|---------------------------|-------------------------------------------------|
    | OnPrepareFetch | OnPrepareFetchInputArgs | OnPrepareFetchOutputArgs | Indicated that the GQI has processed the query. |

- **IGQIOnDestroy**: This interface is called when the instance object is destroyed, which happens when the session is closed, e.g. in case of inactivity or when all the necessary data has been retrieved. It can for instance be used to end the connection with a database. This interface has one method:

    | Method  | Input arguments     | Output arguments     | Description                                    |
    |-----------|---------------------|----------------------|------------------------------------------------|
    | OnDestroy | OnDestroyInputArgs | OnDestroyOutputArgs | Indicates that the GQI will close the session. |

##### Life cycle

All methods discussed above are called at some point during the GQI life cycle, depending on whether a query is created or fetched, and depending on whether they have been implemented.

The following flowchart illustrates the GQI life cycle when a query is created:

![GQI query creation life cycle](~/user-guide/images/GQICreateQuery.png)

The following flowchart illustrates the GQI life cycle when a query is fetched:

![GQI query fetching life cycle](~/user-guide/images/GQIFetchQuery.png)

##### Objects

To build the ad hoc data source, you can use the objects detailed below.

- **GQIColumn**: This is an abstract class with the derived types *GQIStringColumn*, *GQIBooleanColumn*, *GQIIntColumn*, *GQIDateTimeColumn* and *GQIDoubleColumn* and with the following properties::

    | Property | Type           | Required | Description                                                                                                                                                                                                                                                                                                                                  |
    |------------|----------------|----------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | Name       | String         | Yes      | The column name.                                                                                                                                                                                                                                                                                                                             |
    | Type       | GQIColumnType | Yes      | The type of data in the column. *GQIColumnType* is an enum that contains the following values: *String*, *Int*, *DateTime*, *Boolean* or *Double*. |

- **GQIPage**, with the following properties:

    | Property  | Type       | Required | Description                                                                                                                                              |
    |-------------|------------|----------|----------------------------------------------------------------------------------------------------------------------------------------------------------|
    | Rows        | GQIRow\[\] | Yes      | The rows of the page.                                                                                                                                    |
    | HasNextPage | Boolean    | No       | *True* if additional pages can be retrieved, *False* if the current page is the last page. |

- **GQIRow**, with the following properties:

    | Property | Type        | Required | Description           |
    |------------|-------------|----------|-----------------------|
    | Cells      | GQICell\[\] | Yes      | The cells of the row. |

- **GQICell**, with the following properties:

    | Property   | Type   | Required | Description                    |
    |--------------|--------|----------|--------------------------------|
    | Value        | Object | No       | The value of the cell.         |
    | DisplayValue | String | No       | The display value of the cell. |

    > [!NOTE]
    > The type of value of a cell must match the type of the corresponding column.

- **GQIArgument**: This is an abstract class, with the derived types *GQIStringArgument* and *GQIDoubleArgument*, and with the following properties:

    | Property | Type    | Required | Description                                 |
    |------------|---------|----------|---------------------------------------------|
    | Name       | String  | Yes      | The name of the input argument.             |
    | IsRequired | Boolean | No       | Indicates whether the argument is required. |

##### Example script

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

#### Dashboards app - GQI: Linking feeds to arguments of external data sources \[ID_32658\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.5 -->

When you build a GQI query that uses an external data source, it is now possible to link feeds to arguments of that external source.

#### Dashboards app: User groups can now be selected in dashboard security \[ID_32681\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.4 -->

When you configure who can view or edit a specific dashboard, it is now possible to select entire user groups instead of only individual users. Groups are indicated with a different icon to make the difference clear. In the selection box, they are listed together with individual users. Natural sorting is applied, with individual users being sorted by full name and groups being sorted by group name.

#### Dashboards - Data panel: Enhanced element selection \[ID_32769\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.5 -->

A number of enhancements have been made to the *Elements* section of the Data panel.

Up to now, when you switched to edit mode, the first 10,000 elements would be loaded. From now on, the elements will be loaded in batches and a “Load more” button will allow you to load in the next batch.

Also, there is now an element search box as well as a number of element filter options:

- a view filter to only show elements in a particular view (and its subviews),
- a protocol filter to only show elements running a particular protocol,
- an *EPM managers* checkbox to only show EPM Manager elements, and
- a *Spectrum analyzers* checkbox to only show Spectrum elements.

#### Dashboards app: New sidebar icons to list private and shared dashboards \[ID_32854\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.7 -->

In the sidebar, next to the *All dashboards* and *Recent dashboards* icons, there are now two new icons:

- *Private dashboards*, and
- *Shared dashboards*.

The first icon will only be available when there are private dashboards, the second icon will only be available when the DataMiner Agent is connected to the cloud and there are shared dashboards.

#### Dashboards app - Service definition component: Arrows will now automatically be drawn when a Process Automation definition was added \[ID_32960\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.5 -->

When a Process Automation definition is added to the Service definition component, the component will now automatically draw the necessary arrows to indicate the connections between the different blocks/nodes in the diagram.

#### Dashboards app: Using the script output of an interactive Automation script as a feed \[ID_32977\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.5 -->

When building a GQI query, you can now also use the script output of an interactive Automation script as a feed.

#### Dashboards app - Service definition component: Function shapes will now reflect the function type \[ID_32995\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.5 -->

When a Process Automation definition is added to the Service definition component, the added function shapes will now reflect the function type (UserTask, ScriptTask, ResourceTask, Gateway, NoneStartEvent, TimeStartEvent or EndEvent).

#### DataMiner Low-Code Apps \[ID_33002\] \[ID_33040\] \[ID_33208\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.5
RN 33208: Main Release Version 10.3.0 - Feature Release Version 10.2.6 -->

With the DataMiner Low-Code Apps (also known as the "Application Framework"), you can create custom low-code applications that interact with data from a DataMiner System or an external source.

These applications can be created on the root web page of a DataMiner System and can be organized into sections. To place an application in one or more specific sections, open the App.info.json file in the correct application folder (C:\\Skyline DataMiner\\applications\\APP_ID) and add the section names to the Sections array.

> [!NOTE]
> The “Low-code Apps” license is required to use or access the DataMiner Low-Code Apps.

##### Pages and panels

Pages and panels are the basic building blocks of an application. On a page or a panel, or even between pages and panels, data can be fed between components to create dynamic visualizations. Pages and panels can also each have a header bar with different buttons that are used to execute actions via events. Each button can have a customized icon and label.

The application sidebar allows you to navigate between the different pages, which can each have a label and an icon. It is also possible to hide pages. That way they will not appear in the sidebar and will only be accessible via actions.

Panels are used to group data on a page. They can be displayed on the left side of a page, on the right side of a page or as a popup, and can be shown or hidden via actions that are executed when an event occurs. Panels can be reused on different pages.

##### Events and actions

In an application, you can configure actions that will be executed each time one of the following events occur:

- A new page is loaded.
- A (header bar) button is clicked.

At present, the following actions can be configured:

| Action | Description |
|--|--|
| Launch a script | Launch an Automation script with a specific configuration and a specific number of inputs (which can be linked to feeds like e.g. the Query Row feed). |
| Navigate to a URL | Navigate to a specific URL (in a new tab). |
| Open a page | Open a (hidden) page in the same application. |
| Open a panel | Open a panel on the current page. Panels can appear on the left side of a page, on the right side of the page or as a popup. |
| Close a panel | Close a panel that was open on the current page. |
| Open an app | Navigate to another application. |
| Execute component action | Execute a component action. E.g. select an item in a table, create a new instance, etc. |

By default, actions are executed asynchronously. However, it is also possible to configure chains of actions that should be executed synchronously, i.e. only when the preceding action was executed successfully.

Also, by combining different actions into one, you can create complex behavior. For example, open a page, open a panel and launch an Automation script that updates parameters displayed on that panel while it is being opened. This complex action can then be linked to e.g. a header bar button.

##### Versioning

The DataMiner Low-Code Apps include a versioning system that allows different versions of the same application to exist simultaneously. These different versions can be accessed via the versions panel of the application, which also allows the versions to be edited.

When you create a new application, a first draft version of that application is created. That version can then be published, i.e. made accessible to end users. Each time the published version of an application is edited, a new draft version will be created. Draft versions are meant to be used as prototypes for testing purposes.

Per application, there can be up to 15 versions: 14 draft versions and one published version. When a 16th version is created, the oldest draft version will automatically be deleted. The published version will never be deleted. As there can be only one published version, whenever you publish a version, the previously published version will automatically be demoted to draft version.

##### Security

The Low-Code Apps have two levels of security:

- on DataMiner level, user permissions control access to the Low-Code Apps in general, and
- on application level, user permissions control access to specific applications.

Access to the Low-Code Apps is controlled by the following user permissions that can be configured per user or user group:

- View applications
- Add new applications
- Edit applications
- Delete applications
- Publish applications

> [!NOTE]
> Users without “View applications” permission do not have access to the Low-Code Apps. Even if they have been granted some of the other user permissions, they will not be able to perform any action whatsoever within the Low-Code Apps.

Access to a specific application can be configured in the application itself. Per application, you can define a list of users with view and/or edit permission. By default, no restrictions will be applied, meaning that everyone will be allowed to view and edit the application.

#### Dashboards app - Service definition component: Function nodes will now display the number of Process Automation tokens in queue or in progress \[ID_33025\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.5 -->

When a Process Automation definition is added to the Service definition component, all function nodes will now display the number of tokens currently in queue or in progress.

The token counters will be updated every 10 seconds.

#### Web apps - Data table component: Search box \[ID_33385\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.7 -->

When you hover over a data table component (e.g. a GQI table), a search box will now appear in the bottom-right corner. When you enter a search string, a case-insensitive client-side search will be performed.

#### Web apps: Dashboards, app pages and app panels now all have a 'Fit to view' setting \[ID_33401\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.7 -->

In the Dashboards app and the Low-Code Apps, dashboards, app pages, and app panels now all have a “Fit to view” setting that, when enabled, will make sure the items in question are automatically adapted to fit the screen.

#### Web apps - Data table component: Sorting, grouping and filtering options \[ID_33403\] \[ID_33433\] \[ID_33454\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.7 -->

When you right-click a column header of a data table component (e.g. a GQI table), you will now be presented with a number of sorting, grouping and filtering options.

- To sort by the column in question, select a sort order (e.g. A \> Z, Z \> A, etc.).

- To group by the column in question, select *Group*.

- To filter the data in the table, construct a single or composite condition depending on the column type:

    | Column type | Filter option |
    |-------------|---------------|
    | String/GUID | One or more of the following conditions (combined with OR):<br> - contains some text (case insensitive)<br> - does not contains some text (case insensitive)<br> - matches a regular expression<br> - does not match a regular expression<br> - equals some text (case insensitive)<br> - does not equal some text (case insensitive) |
    | Numeric/DateTime | One or more ranges (combined with OR) |
    | Boolean | True or false |

    > [!NOTE]
    >
    > - You can specify multiple column filters. If you do, they will be combined with AND.
    > - Column filters can be used in combination with the component’s search box.
    > - Grouping and column filters are not persistent. When you leave the page, all grouping and filtering will be cleared.

#### Web apps - Data table component: Copy cell/row/column/table \[ID_33440\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.7 -->

When you right-click a non-empty cell in a data table component (e.g. a GQI table), you can now choose to copy the cell value, the entire row, the entire column or the entire table.

If you choose to copy the entire row or the entire table, the data will be copied in CSV format.

> [!NOTE]
>
> - If you copy a cell or an entire column, the values will not be enclosed in double quotes.
> - If you copy an entire row or an entire table, the values will be enclosed in double quotes.
> - If a value contains double quotes, they will be escaped upon copying.

#### Dashboards app: Service Definition component now supports both types of process automation service definitions \[ID_33615\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.8 -->

The Service Definition component now supports both types of process automation service definitions:

- Skyline Process Automation
- Custom Process Automation

#### Dashboards app / Low-Code Apps - Service Definition component: Text displayed on process automation service definition node will now be the value of that node's Label property [ID_33754]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

Up to now, when a Service Definition component displayed a service definition of type "Skyline Process Automation" or "Custom Process Automation", the name of the associated function definition would be displayed on the nodes. From now on, the text displayed on a particular node will be the value of that node's *Label* property. Only when no *Label* property could be found will the name of the associated function definition be displayed instead.

#### DataMiner web apps updated to Angular 13 [ID_33869]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

The DataMiner mobile apps that use Angular (e.g. Low-Code Apps, Dashboards, Monitoring, Ticketing, Jobs, and Automation) now use Angular 13 instead of Angular 12.

#### GQI: Improved performance when retrieving data [ID_33873] [ID_33890] [ID_33935]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

Several improvements have been implemented to increase performance when GQI data is requested. At present, the most noticeable change this results in is an increase of the page size when all GQI data is requested. Up to now, when all GQI data was requested, the page size was always set to 50. From now on, the page size will be set to a number between 50 and 1000 based on the number of columns that are retrieved (max. 3000 cells).

#### Dashboards app - GQI: Line & area chart component is now able to visualize GQI query results as a single line \[ID_33879\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

The “Line & area chart” component is now able to visualize GQI query results as a single line.

1. Add GQI query data to the chart component.

1. In the component settings tab:

   - Select the query.

   - Select the X axis column.

   - Select the Y axis column.

1. In the component layout, adapt the style of the chart.

> [!NOTE]
> If you want the component to show a classic trend chart, make sure the query result is sorted by the X axis column.

#### Dashboards / Low-Code Apps: Parameter table component brought in line with Table component [ID_34132]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.10 -->

The *Parameter table* component of dashboards and low-code apps has now been adjusted to be more like that generic *Table* component. In addition to improving consistency between these components, this also makes the *Parameter table* component more user-friendly:

- The horizontal scrollbar is now permanently displayed, while previously you had to scroll all the way to the bottom of the table to see it.
- The table will load more easily, improving performance of the dashboard or app especially with large tables.

Moreover, the additional features of the *Table* component will now also be available for the *Parameter table* component:

- Grouping on one or multiple columns.
- Sorting based on multiple columns.
- Filtering on multiple columns via the column header context menu.
- Filtering using the search box below the table.
- Resizing columns.
- Dragging and dropping columns to change the column order.

> [!NOTE]
> This change does not affect the *Parameter table* component as viewed on mobile devices.

#### GQI: columnInfo object of data source columns of type 'discrete' will now contain the possible values [ID_34179]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.10 -->

For each of the following GQI data source columns of type "discrete", the possible values will now be available in their columnInfo object:

| Data source              | Columns |
|--------------------------|---------|
| AlarmAdapter             | Alarm severity<br>Alarm type<br>Alarm status<br>Alarm source<br>Alarm user status |
| BookingAdapter           | Booking status |
| ChangePointAdapter       | Change type<br>Alarm severity |
| DCFInterfaceAdapter      | Interface type |
| LiteElementInfoAdapter   | Element state |
| TicketingAdapter         | All (custom) enum columns |
| DOMInstanceAdapter       | State<br>All custom enum fields |
| ParameterTableAdapter    | All parameters of type "discrete" |
| PaProcessAdapter         | PaProcess state<br>PaProcess activity<br>PaProcess start event type |
| PaTokenAdapter           | PaToken status<br>PaToken error state<br>PaToken sub process type<br>PaToken type |
| PatternOccurrenceAdapter | Pattern type |

#### GQI - EPM feed: Linking 'System Name' and 'System Type' to the query [ID_34222]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.10 -->

Using an EPM feed, it is now possible to link *System Name* and *System Type* to the GQI query you are building.

#### Dashboards / Low-Code Apps: Checkboxes to select discrete values in column filter Table component [ID_34234]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

When you configure a column filter for a Table component in a dashboard or low-code app, you can now select checkboxes to filter on discrete values.

#### GQI: Using GQI query columns to filter a 'State' component [ID_34235]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.10 -->

It is now possible to use GQI query columns to filter a *State* component.

#### GQI: Query columns of type 'string' can now be filtered using 'Equals' and 'NotEquals' [ID_34246]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.10 -->

Query columns of type "string" can now be filtered using *Equals* and *NotEquals*.

#### Low-code apps: Data input via URL [ID_34261]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.11 -->

Low-code apps can now be provided with data (e.g. element data, parameter data, view data, etc.) via URL query parameters.

To do so, add a URL query parameter with key *data*. The value should be a URL-encoded JSON object with the following structure:

- *v*: version number (currently always 1)
- *components*: an array of component input objects

```json
{
   v: <version-number>;
   components: <component-data>;
}
```

The component input objects (component-data) have the following structure:

```json
{
   cid: <component-id>,
   select: <data>
}
```

In the following example, the URL selects one default element on the initial page:

- component ID = 1
- element ID = 1/6

```txt
https://<dma>/<app-id>?data=%7B%22v%22:1,%22components%22:%5B%7B%22cid%22:1,%22select%22:%7B%22elements%22:%5B%221%2F6%22%5D%7D%5D%7D%7D
```

#### Dashboards app / Low-code apps: 'Return no rows when feed is empty' option replaced by a triple-state option [ID_34280]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.10 -->

Up to now, when configuring the filter of a GQI data feed, you could enable the *Return no rows when feed is empty* option to indicate that, when the feed was empty, you wanted an empty table to be returned instead of the entire table.

Now, this option has been replaced by a triple-state option. You can now indicate that, when the feed is empty, you want

- to have an empty table returned,
- to have the entire table returned, or
- to have the table filtered on empty values.

#### Dashboards app / Low-code apps: GQI queries now support sort operators [ID_34414]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.11 -->

In dashboards and low-code apps, you can now add sort operators to GQI queries.

After selecting a data source, do the following:

1. Select a *Sort* operator.
1. Select the column to sort on.
1. Select *Ascending* if you want to sort in ascending order instead of descending order.

### DMS Service & Resource Management

#### Retrieving bookings in a paged way and sorted by property \[ID_31982\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.5 -->

It is now possible to retrieve bookings in a paged way and sorted by one of the following properties:

- CreatedAt
- CreatedBy
- Description
- LastModifiedAt
- LastModifiedBy

> [!NOTE]
> Depending on the configuration of the Elasticsearch database, DataMiner Agents running one of the following DataMiner versions may potentially not be able to sort by the above-mentioned properties.
>
> - v10.0.0 (CU10)
> - v10.1.0 (CU0)
> - v10.1.1 (CU0)

#### ProfileInstances: New parameter property 'InheritIsHidden' \[ID_32131\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.3 -->

In the ParameterSettings property of a profile instance, you can now use the “InheritIsHidden” property to indicate whether a profile instance should inherit the “IsHidden” property of a profile parameter. This property is false by default.

A few examples:

- If a parameter of profile definition A is hidden, and you want profile instance A to inherit the “IsHidden” setting of that parameter, then set “InheritIsHidden” to true.
- If a parameter of profile definition A is hidden, and you want profile instance B to not inherit the “IsHidden” setting of that parameter, then set “InheritIsHidden” to false and “IsHidden” to true.

#### Replacing system functions by uploading an XML file \[ID_32264\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.3 -->

It is now possible to replace the system protocol functions by uploading an XML file using the ProtocolFunctionHelper. See the following example.

```csharp
var pfHelper = new ProtocolFunctionHelper(engine.SendSLNetMessages);
var xmlContent = File.ReadAllText("...");
pfHelper.ReplaceActiveSystemFunctionDefinitions(xmlcontent);
```

> [!NOTE]
>
> - If the uploaded file is not a valid XML file, a DataMinerException will be thrown and the system functions will not be replaced.
> - Each function in the XML file must have a valid ID. Functions without a valid ID will be ignored.

#### ResourceUsageInfoManager \[ID_32512\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.5 -->

SLNet now includes a ResourceUsageInfoManager, which will keep track of the Resources being used by ReservationInstances. Each time a change is detected as to Resource usage, this manager will send out a ResourceUsageStatusEventMessage containing the DMA ID and a list of UpdatedResourceUsageStatuses.

A ResourceUsageStatus contains a ResourceId and a list of UsingReservationInstances. That list will contain a ReservationInstanceUsageDetails object for every ReservationInstance that is using the Resource. Currently, the object only contains a ReservationInstanceId property.

Normally, a ResourceUsageStatusEventMessage will be sent out the moment a Resource is being used in an ongoing reservation or when a ReservationInstance using that resource ends. When a Resource is no longer used in any reservation, an event will be sent out with a ResourceUsageStatus containing an empty list.

ResourceUsageStatus objects can be retrieved by means of a GetResourceUsageStatusList (FilterElement\<Resource> filter) call on the ResourceManagerHelper. This call will return all status objects for the resources that match the filter and that are currently being used by ongoing reservations.

#### ReservationInstances now have a ReservationInstanceType \[ID_32624\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.4 -->

When configuring a ReservationInstance, you now have to specify a ReservationInstanceType:

- Default
- Process Automation
- Custom Process Automation

> [!NOTE]
>
> - In case of a ServiceReservationInstance, the type of the instance must be identical to the type of the ServiceDefinition. Otherwise, the ResourceManager will throw a “ServiceDefinitionTypeDoesNotMatch” error.
> - A new exposer has been added to allow filter ReservationInstanceType.

#### Modified AbsoluteQuarantinePriority behavior and several new SRM features \[ID_32654\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.4 -->

Several changes to the SRM framework have been introduced:

- Modified *AbsoluteQuarantinePriority* behavior.
- New *ConcurrencyUsageType* property for ResourceUsageDefinition
- Possibility to book complete resource capacity
- Possibility to include elements in bookings

##### Modified AbsoluteQuarantinePriority behavior

The behavior of the *AbsoluteQuarantinePriority* property has been modified. Up to now, if this property was set to true for a booking instance, all overlapping booking instances using the same resources were forced into quarantine. Now this property will only determine the priority of the booking when a quarantine is needed.

To implement a quarantine, overbooked capacity is now removed from bookings according to the following order of priority:

1. Bookings that are already in the quarantined state.
1. Bookings for which *AbsoluteQuarantinePriority* is not specified or false.
1. Bookings that are in a "Pending" state.
1. Bookings with the latest start time.
1. Booking of which the name comes last alphabetically.
1. Bookings of which the GUID comes last alphabetically.

The image below illustrates a situation where the quarantine behavior has changed. Previously, booking A would have been quarantined, as it uses resource 1. Now this will no longer happen as the capacity is actually not overbooked.

![Quarantine behavior example](~/release-notes/images/32654_1.png)

The following image also illustrates the modified behavior. If booking B does not have *AbsoluteQuarantinePriority* set to true, its capacity will be moved, as it has a later start time. If *AbsoluteQuarantinePriority* is set to true, the overbooking will be resolved by moving the capacity from booking A.

![Quarantine behavior example](~/release-notes/images/32654_2.png)

##### New ConcurrencyUsageType property for ResourceUsageDefinition

A ResourceUsageDefinition now has the property *ConcurrencyUsageType*, which can have the following values:

- *ConcurrencyUsageType.Default*: The default value. The ResourceUsageDefinition takes one concurrency of the resource.
- *ConcurrencyUsageType.All*: The ResourceUsageDefinition takes all the concurrency of the resource.
- *ConcurrencyUsageType.None*: The ResourceUsageDefinition does not take any concurrency of the resource.

Resource usage can only overlap with a ResourceUsageDefinition with *ConcurrencyUsageType.All* if it is set to *ConcurrencyUsageType.None*. This limitation is also in place for a single booking: if a booking has a resource with complete concurrency and another resource with 1 concurrency, the booking will be quarantined because it requests more concurrency than is available. If a complete concurrency usage is quarantined to resolve a concurrency conflict (as determined by the priority defined on booking level), it will be moved in its entirety – there is no option to only move part of the concurrency to quarantine.

The actual concurrency of a ResourceUsageDefinition with *ConcurrencyUsageType.All* is determined at runtime, as the *MaxConcurrency* value of the resource at the moment when it is needed, e.g. when *GetEligibleResources* is called or when quarantine checks are done to add or update a booking instance or resource.

Code example:

```csharp
var booking = new ReservationInstance(new TimeRangeUtc(DateTime.UtcNow, DateTime.UtcNow.AddHours(10)))
{
    Name = "Booking 123",
    ID = Guid.NewGuid()
};

var resourceUsage = new ResourceUsageDefinition(resourceId)
{
    ConcurrencyUsageType = ConcurrencyUsageType.All
};

booking.ResourcesInReservationInstance.Add(resourceUsage);
```

##### Booking complete resource capacity

It is now possible to book all the capacities of a resource for their complete value, by setting the *UsesCompleteCapacity* property for the ResourceUsageDefinition to true. If the resource has more than one capacity defined, this will reserve all capacities. By default, this property is set to false.

No other usage can overlap in case complete capacity is used. This limitation is also in place for a single booking: if a booking has a resource with complete capacity and another resource with 100 capacity, the booking will be quarantined because it requests more capacity than is available. If a complete capacity usage is quarantined to resolve a conflict (as determined by the priority defined on booking level), it will be moved in its entirety.

The actual capacity in case *UsesCompleteCapacity* is true is determined at runtime, e.g. when *GetEligibleResources* is called or when quarantine checks are done to add or update a booking instance or resource.

Code example:

```csharp
var booking = new ReservationInstance(new TimeRangeUtc(DateTime.UtcNow, DateTime.UtcNow.AddHours(10)))
{
    Name = "Booking 123",
    ID = Guid.NewGuid()
};

var resourceUsage = new ResourceUsageDefinition(_resource.ID)
{
    UsesCompleteCapacity = true
};

booking.ResourcesInReservationInstance.Add(resourceUsage);
```

##### Including elements in bookings

It is now possible to define an ElementUsageDefinition to include an element in a booking. When the element is included, ResourceUsageDefinitions will automatically be added for all the resources linked to the element. These resources will have the new *IsAutoGenerated* property set to true.

ElementUsageDefinition has three properties:

- *ElementUsageImpact*: Determines if the element can be used in overlapping bookings. If set to *None*, overlapping bookings can use the same element. If set to *Full* (the default value), no overlapping bookings can use the same element, even if they have impact *None*. If the *AddOrUpdateReservationInstances* call fails because there are overlapping bookings using the same element with *Full* impact, no changes will be saved and an error of type *ElementUsageOverflow* will be returned.

- *IncludeCapacityBehavior*: Can be set to *All* or *None*. If this is set to *All*, the generated ResourceUsageDefinitions will have the *UsesCompleteCapacity* property set to true.

- IncludeConcurrencyBehavior: Can be set to *All* or *None*. If this is set to *All*, the generated ResourceUsageDefinitions will have the *ConcurrencyUsageType* property set to *ConcurrencyUsageType.All*.

Code example:

```csharp
var booking = new ReservationInstance(new TimeRangeUtc(DateTime.UtcNow, DateTime.UtcNow.AddHours(10)))
{
    Name = "Booking 123",
    ID = Guid.NewGuid()
};

var elementUsage = new ElementUsageDefinition(new ElementID(123,456))
{
    ElementUsageImpact = ElementUsageImpact.Full,
    IncludeCapacityBehavior = IncludeCapacityBehavior.All,
    IncludeConcurrencyBehavior = IncludeConcurrencyBehavior.All
};

booking.ObjectUsages.Add(elementUsage);
```

The following resources are added when an element is included in a booking:

- Resources that reference the element with the *DmaID* and *ElementID* properties.
- Function resources that have the referenced element as their parent element (based on *MainDveDmaId* and *MainDveElementId* properties).
- Virtual function resources linked to the element (based on *PhysicalDeviceDmaId* and *PhysicalDeviceElementId* properties).

Whenever the booking is updated or a relevant resource is created or updated, the element usage is automatically updated. Any changes you do to auto-generated usage will be overwritten by the core software. When the auto-generated usage is updated, the TraceData of the *AddOrUpdateResource* call will contain ResourceManagerInfoData of type ResourceUsagesGeneratedForReservationInstances.

The deletion of resources in auto-generated bookings is blocked in the same way as deletion of resources that were not added automatically is blocked.

This new feature has an *ElementUsages* exposer, which can be used to filter bookings that include a certain element. For example:

```csharp
var elementToSearchFor = new ElementID(123, 789);
var filter = ReservationInstanceExposers.ElementUsages.Contains(elementToSearchFor.ToString());
var bookings = rmHelper.GetReservationInstances(filter);
```

#### ResourceManagerEventMessage: New LostInterestReservationInstances property \[ID_32801\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.5 -->

When, for example, a table is populated with ReservationInstances using ResourceManagerEventMessages with a SubscriptionFilter, you can now use the LostInterestReservationInstances property to retrieve the IDs of the ReservationInstances that no longer match the current filter after an update.

> [!NOTE]
> This list will only contain ReservationInstances to which the user has access.
> To retrieve the IDs of the ReservationInstances to which the user no longer has access, you can call the GetHiddenReservationInstances method.

#### Functions.xml file: Assigning a function type to a function \[ID_32851\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.5 -->

It is now possible to assign a function type to each function defined in a functions.xml file.

A function can be assigned one of the following types:

- UserTask
- ScriptTask
- ResourceTask
- Gateway
- NoneStartEvent
- TimeStartEvent
- EndEvent

Default function type: NULL

Example:

```xml
<Functions>
  <Function id="..." name="..." maxInstances="..." profile="...">
    ...
    <FunctionType>UserTask</FunctionType>
  </Function>
  ...
</Functions>
```

> [!NOTE]
> If you add a \<FunctionType> element inside a \<Function> element, it must be the last child element inside the \<Function> element.

#### Subscribing to ResourceUsageStatusEvents for specific resources \[ID_32979\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.6 -->

From now on, it is possible to only receive ResourceUsageEventMessages for a specific resource. Using ResourceUsageStatusEventExposers, you can now filter by ResourceId.

#### ReservationInstanceType and ServiceDefinitionType: New values 'ResourceScheduling' and 'ResourceOrchestration' \[ID_33390\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.7 -->

ReservationInstanceType and ServiceDefinitionType can now be set to the following additional values:

- ResourceScheduling
- ResourceOrchestration

#### BREAKING CHANGE: Removing a Resource or ResourcePool object will now always require a valid ID \[ID_33836\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

Up to now, it was possible to delete Resource and ResourcePool objects in a filtered way by passing an “incomplete” object to the associated remove method of the ResourceManagerHelper. Moreover, passing an empty list or NULL would remove all resources on the system. This will no longer be possible.

From now on, it will only be possible to remove Resource objects by ID or name (case sensitive) and ResourcePool objects by ID.

When DataMiner detects a remove request that contains an object with an empty ID (and an empty name in case of a request to remove a Resource object, one of the following messages will be added to the ResourceManager.txt log file (type: info):

- In case of a request to remove a Resource object:

    ```txt
    Detected a resource delete request that contained at least one object without an ID. Deleting resources with resource object filters is not supported anymore.
    ```

- In case of a request to remove a ResourcePool object:

    ```txt
    Detected a resource pool delete request that contained at least one object without an ID. Deleting resource pools with object filters is not supported anymore.
    ```

> [!NOTE]
> From now on, the log entries added when creating or deleting resources or resource pools will no longer contain the IDs of all objects that were created or deleted. Instead, they will only contain the IDs of the first 10 objects that were created or deleted.

### DMS Mobile Gateway

#### Additional logging after sending a 'send SMS' request to an SMSEagle device \[ID_32785\] \[ID_32911\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.5 -->

When an HTTP request of type “send SMS” is sent to an SMSEagle device, the following information will now be logged in the SLGSMGateway log file:

- The response message and code (level “debug”).

    Example:

    ```txt
    Response of sending SMS 'This is a test' to '+324799789789' - Status: HTTP/1.1 200 OK (200) - Response data: OK; ID=25464
    ```

- The response itself as well as the error string retrieved from the HTTP engine used by SLGSMGateway (level “info”) when the response does not start with “OK;”.

    Example:

    ```txt
    Sending the SMS 'This is a test' to '+324799789789' may have failed. Received response: '' (HTTP/1.1 200 OK/200). Error info: 'Error : 12029. [ERROR_WINHTTP_CANNOT_CONNECT]'
    ```

### DMS tools

#### Standalone Elasticsearch Cluster Installer: New RepoPath setting \[ID_33055\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.6 -->

The optional RepoPath configuration setting (which corresponds with the Path.Repo Elasticsearch setting) allows you to define a snapshot path. For a cluster, this should be a shared file location. If this setting is not filled in, it will be commented out in the Elasticsearch configuration.

When you run the installer with the “generate” option (run-stand-alone -g), the sample configuration will now include a \<RepoPath> element and a \<DiscoveryHosts> element. See the following example:

```xml
<ElasticConfiguration xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <ElasticYamlSettings>
    <ClusterName>DMS</ClusterName>
    <NodeName>DataMinerBestMiner</NodeName>
    <DataPath>C:\ProgramData\Elasticsearch</DataPath>
    <RepoPath>C:\ProgramData\RepoPath</RepoPath>
    <NetworkHost>0.0.0.0</NetworkHost>
    <NetworkPublishHost>0.0.0.0</NetworkPublishHost>
    <DiscoveryHosts>
      <string>"IP1"</string>
      <string>"IP2"</string>
    </DiscoveryHosts>
    <MinimumMasterNodes>1</MinimumMasterNodes>
    <MasterNode>true</MasterNode>
    <DataNode>true</DataNode>
  </ElasticYamlSettings>
  <InstallerDependenciesDirectory>unspecified</InstallerDependenciesDirectory>
  <ElasticTargetDirectory>C:\Program Files\Elasticsearch</ElasticTargetDirectory>
</ElasticConfiguration>
```

#### QA Device Simulator: Help link now directs users to the QA Device Simulator help pages on <https://docs.dataminer.services/> [ID_33680]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.7 -->

In the UI of the QA Device Simulator, the help link now directs users to the QA Device Simulator help pages on <https://docs.dataminer.services/>.

> [!CAUTION]
> This tool is provided “As Is” with no representation or warranty whatsoever. Skyline Communications will not provide any maintenance or support for this tool.
