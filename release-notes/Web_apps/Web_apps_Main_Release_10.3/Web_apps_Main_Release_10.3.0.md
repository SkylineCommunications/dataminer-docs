---
uid: Web_apps_Main_Release_10.3.0
---

# DataMiner Web Applications Main Release 10.3.0 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

## Highlights

#### Dashboards app - Node edge graph: Option to visualize the direction of the edges [ID_32519]

<!-- MR 10.3.0 - FR 10.2.4 -->

When configuring a node edge graph, it is now possible to have the graph visualize the direction of the edges.

To do so, enable the *Visualize directions* setting and select one of the following options:

| Option | Description |
|--------|-------------|
| Flow (default) | The direction is visualized by means of animated edges. |
| Arrows         | The direction is visualized by means of arrows drawn on the edges. If you select this option, you can also specify the exact position of the arrows on the edges. |

#### Dashboards app: GQI now supports external data [ID_32656] [ID_32659] [ID_32930] [ID_33795]

<!-- MR 10.3.0 - FR 10.2.4
RN 33795: MR 10.3.0 - FR 10.2.8 -->

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

  | Method | Input arguments | Output arguments | Description |
  |--|--|--|--|
  | GetColumns  |  | GQIColumn\[\] | The GQI will request the columns. |
  | GetNextPage | GetNextPageInputArgs | GQIPage | The GQI will request data. |

- **IGQIInputArguments**: This interface can be used to have the user specify an argument, for example the CSV file from which data should be parsed, or a filter that should be applied. This interface has the following methods:

  | Method | Input arguments | Output arguments | Description |
  |--|--|--|--|
  | GetInputArguments    | \- | GQIArgument\[\] | Asks for additional information from the user when the data source is configured. |
  | OnArgumentsProcessed | OnArgumentsProcessedInputArgs | OnArgumentsProcessedOutputArgs | Event to indicate that the arguments have been processed. |

  > [!NOTE]
  > The GQI does not validate the input arguments specified by the user. For example, a user can input an SQL query as a string input argument, and the content of the string argument will be forwarded to the ad hoc data source implementation without validation.

- **IGQIOnInit**: This interface is called when the data source is initialized, for example when the data source is selected in the query builder or when a dashboard using a query with ad hoc data is opened. It can for instance be used to connect to a database. This interface has one method:

  | Method | Input arguments | Output arguments | Description |
  |--|--|--|--|
  | OnInit | OnInitInputArgs | OnInitOutputArgs | Indicates that an instance of the class has been created. |

- **IGQIOnPrepareFetch**: This interface is used to implement optimizations when data is retrieved. This can for instance be used to limit the retrieved data. This interface has one method:

  | Method | Input arguments | Output arguments | Description |
  |--|--|--|--|
  | OnPrepareFetch | OnPrepareFetchInputArgs | OnPrepareFetchOutputArgs | Indicated that the GQI has processed the query. |

- **IGQIOnDestroy**: This interface is called when the instance object is destroyed, which happens when the session is closed, e.g. in case of inactivity or when all the necessary data has been retrieved. It can for instance be used to end the connection with a database. This interface has one method:

  | Method | Input arguments | Output arguments | Description |
  |--|--|--|--|
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

  | Property | Type | Required | Description |
  |--|--|--|--|
  | Name | String | Yes | The column name. |
  | Type | GQIColumnType | Yes | The type of data in the column. *GQIColumnType* is an enum that contains the following values: *String*, *Int*, *DateTime*, *Boolean* or *Double*. |

- **GQIPage**, with the following properties:

  | Property | Type | Required | Description |
  |--|--|--|--|
  | Rows | GQIRow\[\] | Yes | The rows of the page. |
  | HasNextPage | Boolean | No | *True* if additional pages can be retrieved, *False* if the current page is the last page. |

- **GQIRow**, with the following properties:

  | Property | Type | Required | Description |
  |--|--|--|--|
  | Cells | GQICell\[\] | Yes | The cells of the row. |

- **GQICell**, with the following properties:

  | Property | Type | Required | Description |
  |--|--|--|--|
  | Value | Object | No | The value of the cell. |
  | DisplayValue | String | No | The display value of the cell. |

  > [!NOTE]
  > The type of value of a cell must match the type of the corresponding column.

- **GQIArgument**: This is an abstract class, with the derived types *GQIStringArgument* and *GQIDoubleArgument*, and with the following properties:

  | Property | Type | Required | Description |
  |--|--|--|--|
  | Name | String | Yes | The name of the input argument. |
  | IsRequired | Boolean | No | Indicates whether the argument is required. |

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

#### DataMiner Low-Code Apps [ID_33002] [ID_33040] [ID_33208]

<!-- MR 10.3.0 - FR 10.2.5
RN 33208: MR 10.3.0 - FR 10.2.6 -->

With the DataMiner Low-Code Apps (also known as the "Application Framework"), you can create custom low-code applications that interact with data from a DataMiner System or an external source.

These applications can be created on the root web page of a DataMiner System and can be organized into sections. To place an application in one or more specific sections, open the App.info.json file in the correct application folder (C:\\Skyline DataMiner\\applications\\APP_ID) and add the section names to the Sections array.

> [!NOTE]
> The “Low-Code Apps” license is required to use or access the DataMiner Low-Code Apps.

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

#### Low-Code Apps: Data input via URL [ID_34261]

<!-- MR 10.3.0 - FR 10.2.11 -->

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

## Other new features

#### Jobs app: Name, Start Time and End Time fields in default job section can now be set read-only [ID_31485] [ID_31506]

<!-- MR 10.3.0 - FR 10.2.1 -->

In the default job section, the *Name*, *Start Time*, and *End Time* fields can now be set read-only.

#### Ticketing app: System name will now be checked for illegal characters [ID_31496]

<!-- MR 10.3.0 - FR 10.2.1 -->

From now on, the system name of a ticket will no longer be allowed to start with an underscore character or contain one of the following characters: . # \* , " '

When the system name contains one of these illegal characters, an error message will appear.

#### Jobs app: Fields will automatically be set to 'not required' when hidden [ID_31513]

<!-- MR 10.3.0 - FR 10.2.1 -->

From now on, when you hide a job field, you will receive a message that it will automatically be set to “not required”.

> [!NOTE]
> When you unhide a hidden field, it will remain set to “not required”.

#### Dashboards app - GQI: Element, service and view data sources now also return an 'In timeout' column [ID_31671]

<!-- MR 10.3.0 - FR 10.2.1 -->

The element, service and view data sources now return an additional “In timeout” column.

| Data source | Meaning of “True” in “In timeout” column |
|--|--|
| Element | The (replication) element is in timeout. |
| Service | One of the elements in the service is in timeout. |
| View | The enhancing element, one of the first-level child elements or one of the recursive child views is in timeout. |

#### Dashboards app: Default index filter for parameter feed component [ID_32595]

<!-- MR 10.3.0 - FR 10.2.4 -->

It is now possible to add a default index filter to a parameter feed component. This way, it's not necessary to apply your filter to the component again whenever the dashboard is refreshed.

This new option is available as an advanced setting that is not displayed by default. To be able to configure it, you therefore first need to add the *showAdvancedSettings=true* option to the dashboard URL. In the *Data* pane of the dashboard edit mode, a new *Parameter table filters* section will then become available. You can configure the default filter in this section and then drag it to a component to apply it.

#### Dashboards app - GQI: Linking feeds to arguments of external data sources [ID_32658]

<!-- MR 10.3.0 - FR 10.2.5 -->

When you build a GQI query that uses an external data source, it is now possible to link feeds to arguments of that external source.

#### Dashboards app: User groups can now be selected in dashboard security [ID_32681]

<!-- MR 10.3.0 - FR 10.2.4 -->

When you configure who can view or edit a specific dashboard, it is now possible to select entire user groups instead of only individual users. Groups are indicated with a different icon to make the difference clear. In the selection box, they are listed together with individual users. Natural sorting is applied, with individual users being sorted by full name and groups being sorted by group name.

#### Dashboards - Data panel: Enhanced element selection [ID_32769]

<!-- MR 10.3.0 - FR 10.2.5 -->

A number of enhancements have been made to the *Elements* section of the Data panel.

Up to now, when you switched to edit mode, the first 10,000 elements would be loaded. From now on, the elements will be loaded in batches and a “Load more” button will allow you to load in the next batch.

Also, there is now an element search box as well as a number of element filter options:

- a view filter to only show elements in a particular view (and its subviews),
- a protocol filter to only show elements running a particular protocol,
- an *EPM managers* checkbox to only show EPM Manager elements, and
- a *Spectrum analyzers* checkbox to only show Spectrum elements.

#### Dashboards app: New sidebar icons to list private and shared dashboards [ID_32854]

<!-- MR 10.3.0 - FR 10.2.7 -->

In the sidebar, next to the *All dashboards* and *Recent dashboards* icons, there are now two new icons:

- *Private dashboards*, and
- *Shared dashboards*.

The first icon will only be available when there are private dashboards, the second icon will only be available when the DataMiner Agent is connected to the cloud and there are shared dashboards.

#### Dashboards app - Service definition component: Arrows will now automatically be drawn when a Process Automation definition was added [ID_32960]

<!-- MR 10.3.0 - FR 10.2.5 -->

When a Process Automation definition is added to the Service definition component, the component will now automatically draw the necessary arrows to indicate the connections between the different blocks/nodes in the diagram.

#### Dashboards app: Using the script output of an interactive Automation script as a feed [ID_32977]

<!-- MR 10.3.0 - FR 10.2.5 -->

When building a GQI query, you can now also use the script output of an interactive Automation script as a feed.

#### Dashboards app - Service definition component: Function shapes will now reflect the function type [ID_32995]

<!-- MR 10.3.0 - FR 10.2.5 -->

When a Process Automation definition is added to the Service definition component, the added function shapes will now reflect the function type (UserTask, ScriptTask, ResourceTask, Gateway, NoneStartEvent, TimeStartEvent or EndEvent).

#### Dashboards app - Service definition component: Function nodes will now display the number of Process Automation tokens in queue or in progress [ID_33025]

<!-- MR 10.3.0 - FR 10.2.5 -->

When a Process Automation definition is added to the Service definition component, all function nodes will now display the number of tokens currently in queue or in progress.

The token counters will be updated every 10 seconds.

#### Web apps - Data table component: Search box [ID_33385]

<!-- MR 10.3.0 - FR 10.2.7 -->

When you hover over a data table component (e.g. a GQI table), a search box will now appear in the bottom-right corner. When you enter a search string, a case-insensitive client-side search will be performed.

#### Web apps: Dashboards, app pages and app panels now all have a 'Fit to view' setting [ID_33401]

<!-- MR 10.3.0 - FR 10.2.7 -->

In the Dashboards app and the Low-Code Apps, dashboards, app pages, and app panels now all have a “Fit to view” setting that, when enabled, will make sure the items in question are automatically adapted to fit the screen.

#### Web apps - Data table component: Sorting, grouping and filtering options [ID_33403] [ID_33433] [ID_33454]

<!-- MR 10.3.0 - FR 10.2.7 -->

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

#### Web apps - Data table component: Copy cell/row/column/table [ID_33440]

<!-- MR 10.3.0 - FR 10.2.7 -->

When you right-click a non-empty cell in a data table component (e.g. a GQI table), you can now choose to copy the cell value, the entire row, the entire column or the entire table.

If you choose to copy the entire row or the entire table, the data will be copied in CSV format.

> [!NOTE]
>
> - If you copy a cell or an entire column, the values will not be enclosed in double quotes.
> - If you copy an entire row or an entire table, the values will be enclosed in double quotes.
> - If a value contains double quotes, they will be escaped upon copying.

#### Dashboards app: Service Definition component now supports both types of Process Automation service definitions [ID_33615]

<!-- MR 10.3.0 - FR 10.2.8 -->

The Service Definition component now supports both types of Process Automation service definitions:

- Skyline Process Automation
- Custom Process Automation

#### Dashboards app / Low-Code Apps - Service Definition component: Text displayed on Process Automation service definition node will now be the value of that node's Label property [ID_33754]

<!-- MR 10.3.0 - FR 10.2.9 -->

Up to now, when a Service Definition component displayed a service definition of type "Skyline Process Automation" or "Custom Process Automation", the name of the associated function definition would be displayed on the nodes. From now on, the text displayed on a particular node will be the value of that node's *Label* property. Only when no *Label* property could be found will the name of the associated function definition be displayed instead.

#### DataMiner web apps updated to Angular 13 [ID_33869]

<!-- MR 10.3.0 - FR 10.2.9 -->

The DataMiner mobile apps that use Angular (e.g. Low-Code Apps, Dashboards, Monitoring, Ticketing, Jobs, and Automation) now use Angular 13 instead of Angular 12.

#### GQI: Improved performance when retrieving data [ID_33873] [ID_33890] [ID_33935]

<!-- MR 10.3.0 - FR 10.2.9 -->

Several improvements have been implemented to increase performance when GQI data is requested. At present, the most noticeable change this results in is an increase of the page size when all GQI data is requested. Up to now, when all GQI data was requested, the page size was always set to 50. From now on, the page size will be set to a number between 50 and 1000 based on the number of columns that are retrieved (max. 3000 cells).

#### Dashboards app - GQI: Line & area chart component is now able to visualize GQI query results as a single line [ID_33879]

<!-- MR 10.3.0 - FR 10.2.9 -->

The Line & area chart component is now able to visualize GQI query results as a single line.

1. Add GQI query data to the chart component.

1. In the component settings tab:

   - Select the query.

   - Select the X axis column.

   - Select the Y axis column.

1. In the component layout, adapt the style of the chart.

> [!NOTE]
> If you want the component to show a classic trend chart, make sure the query result is sorted by the X axis column.

#### Dashboards: An EPM feed can now be used to feed EPM identifiers to a parameter feed [ID_33977]

<!-- MR 10.3.0 - FR 10.2.11 -->

An EPM feed can now be used to feed EPM identifiers to a parameter feed.

#### Dashboards / Low-Code Apps: Parameter table component brought in line with Table component [ID_34132]

<!-- MR 10.3.0 - FR 10.2.10 -->

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

<!-- MR 10.3.0 - FR 10.2.10 -->

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

<!-- MR 10.3.0 - FR 10.2.10 -->

Using an EPM feed, it is now possible to link *System Name* and *System Type* to the GQI query you are building.

#### Dashboards / Low-Code Apps: Checkboxes to select discrete values in column filter Table component [ID_34234]

<!-- MR 10.3.0 - FR 10.2.9 -->

When you configure a column filter for a Table component in a dashboard or low-code app, you can now select checkboxes to filter on discrete values.

#### GQI: Using GQI query columns to filter a 'State' component [ID_34235]

<!-- MR 10.3.0 - FR 10.2.10 -->

It is now possible to use GQI query columns to filter a *State* component.

#### GQI: Query columns of type 'string' can now be filtered using 'Equals' and 'NotEquals' [ID_34246]

<!-- MR 10.3.0 - FR 10.2.10 -->

Query columns of type "string" can now be filtered using *Equals* and *NotEquals*.

#### Dashboards app / Low-Code Apps: 'Return no rows when feed is empty' option replaced by a triple-state option [ID_34280]

<!-- MR 10.3.0 - FR 10.2.10 -->

Up to now, when configuring the filter of a GQI data feed, you could enable the *Return no rows when feed is empty* option to indicate that, when the feed was empty, you wanted an empty table to be returned instead of the entire table.

Now, this option has been replaced by a triple-state option. You can now indicate that, when the feed is empty, you want

- to have an empty table returned,
- to have the entire table returned, or
- to have the table filtered on empty values.

#### Dashboards app: Filtering a parameter feed that lists EPM parameters [ID_34287]

<!-- MR 10.3.0 - FR 10.2.11 -->

When an EPM identifier from an EPM feed is fed to a parameter feed, it will now be possible to drag multiple parameters onto the parameter feed in order to use them as filters.

#### Web apps - Interactive Automation script components: Minor enhancements [ID_34373]

<!-- MR 10.3.0 - FR 10.2.11 -->

A number of minor enhancements have been made to the interactive Automation script components with regard to font styles, button styles, text alignment and button and checkbox height.

#### Dashboards app / Low-Code Apps: GQI queries now support sort operators [ID_34414] [ID_34528] [ID_34479]

<!-- MR 10.3.0 - FR 10.2.11 -->

In dashboards and low-code apps, you can now add sort operators to GQI queries.

After selecting a data source, do the following:

1. Select a *Sort* operator.
1. Select the column to sort on.
1. Select *Ascending* if you want to sort in ascending order instead of descending order.

#### Dashboards app / Low-Code Apps: An eye icon will now appear when you make a modification to a GQI table [ID_34445]

<!-- MR 10.3.0 - FR 10.2.11 -->

When you make one of the following modifications to a GQI table, an eye icon will now appear in the header of the table component.

- Change the sorting
- Apply a grouping
- Change the order of the columns
- Change the width of the columns
- Apply a column filter (using the context menu that appears when right-clicking a column header)

This eye icon will make you aware that the table is no longer identical to the one that was loaded originally. Clicking it will reset all modifications.

#### DataMiner web apps updated to Angular 14 [ID_34447]

<!-- MR 10.3.0 - FR 10.2.11 -->

The DataMiner mobile apps that use Angular (e.g. Low-Code Apps, Dashboards, Monitoring, Ticketing, Jobs, and Automation) now use Angular 14 instead of Angular 13.

#### Dashboards app / Low-Code Apps: Enhanced filtering by protocol [ID_34453]

<!-- MR 10.3.0 - FR 10.2.11 -->

From now on, when you add a protocol filter to a component without specifying any particular version(s), that filter will return all data related to that protocol irrespective of protocol version. If you want the data in the component to be filtered by a specific version of the protocol in question, you can select that version from the protocol filter box.

#### GQI: New 'IsActive' column added to 'Get alarms' data source [ID_34455]

<!-- MR 10.3.0 - FR 10.2.11 -->

A new *IsActive* column has been added to *Get alarms* data source. This column will be set to true when the alarm is an active alarm.

#### Dashboards app / Low-Code Apps: Improved multiple sort in the Table component [ID_34526]

<!-- MR 10.3.0 - FR 10.2.12 -->

When, in the Dashboards app or a low-code app, you apply multiple sort orders in a *Table* component, multiple sort operators will now be appended to the GQI query that feeds data to the component. This way sorting is done server-side, which will improve performance.

#### Dashboards app: Parameter feeds that list EPM parameters now allow items to be preselected [ID_34554] [ID_34588]

<!-- MR 10.3.0 - FR 10.2.12 -->

When an EPM feed is used to feed EPM identifiers to a parameter feed, it is now possible to configure filters that will preselect certain items in the parameter feed.

#### Dashboards app: Items selected in a parameter feed listing EPM parameters will now be saved in the URL of the dashboard [ID_34622]

<!-- MR 10.3.0 - FR 10.2.12 -->

The parameters and indices selected in a parameter feed listing EPM parameters will now be saved in the URL of the dashboard.

As a result, the same items will automatically be selected again after you refresh the page.

#### Dashboards app: Parameter indices selected in a parameter feed listing EPM parameters can now be fed to other components [ID_34629]

<!-- MR 10.3.0 - FR 10.2.12 -->

After selecting column parameter indices in a parameter feed listing EPM parameters, you can now feed those selected indices to other components.

#### Dashboards app: Reports will no longer contain visual replacements [ID_34632]

<!-- MR 10.3.0 - FR 10.2.12 -->

Missing information in dashboards is no longer indicated by means of a visual replacement. In PDF reports they are now replaced by a short message.

#### Dashboards app: Jobs and Dashboards app now support PDF module [ID_34634]

<!-- MR 10.3.0 - FR 10.2.12 -->

The PDF module is now available in the Jobs and Dashboards app. From now on, you can e.g. export dashboards to PDF.

#### Dashboards app: PDF and share button will now be hidden in edit mode [ID_34653]

<!-- MR 10.3.0 - FR 10.2.12 -->

The *PDF* and *Share* option in the Dashboards app are now no longer visible in edit mode. Additionally, you can now pin the *Share dashboards* action in the settings menu of the Dashboards app.

#### Dashboards app: Parameter feeds listing EPM parameters now allow parameter grouping [ID_34705]

<!-- MR 10.3.0 - FR 10.2.12 -->

It is now possible to group parameters in a parameter feed that lists EPM parameters.

## Changes

### Enhancements

#### Web apps: Enhancements with regard to the rendering of GQI tables [ID_33463]

<!-- MR 10.3.0 - FR 10.2.7 -->

A number of enhancements have been made with regard to the rendering of GQI tables.

#### Dashboards app / Low-Code Apps: Support for feed categories in components [ID_33719]

<!-- MR 10.3.0 - FR 10.2.9 -->

Up to now, components could only produce one feed for each data type. Now support has been added for different categories within a data type, so that components will be able to produce several feeds for the same data type. This will for example make it possible for a component to produce a query row feed with the categories "timeline item" and "timeline band".

#### GQI: Improved performance of column filter [ID_34014]

<!-- MR 10.3.0 - FR 10.2.9 -->

Instead of a client-side filter, a more efficient server-side filter is now used to filter columns of a table component showing GQI data in a dashboard or low-code app. This will greatly improve the filter performance. However, because this server-side filter does not support "OR" filters, it will no longer be possible to combine multiple conditions within the same filter.

#### Dashboards / Low-Code Apps: Table filter improvements [ID_34022]

<!-- MR 10.3.0 - FR 10.2.9 -->

If you used the search box below a table displaying GQI data to filter this data, up to now, this could cause a serious load on the server in case a large number of rows had to be retrieved. To prevent this, the following conditions will now be applied to determine if more data should be retrieved:

- If the table already has enough rows to fill the next page, no further data will be retrieved.
- If the condition above is not met, at least 250 rows will retrieved initially.
- If at least one record is found that matches the search filter, no more rows will be retrieved. You will then need to click a "Load more" button to retrieve more data.
- If 2000 additional records have been retrieved after you click "Load more", no more data will be retrieved until you click the button again.
- If you scroll through the results, additional data will be fetched until there are enough rows to fill the next page.

#### Dashboards app / Low-Code Apps: No more statistics and suggestions for conditional coloring of Table and Node edge component [ID_34037]

<!-- MR 10.3.0 - FR 10.2.9 -->
<!-- Part of this RN is still in soft launch and consequently has not been documented yet -->

To improve performance, in the *Layout* pane for a Table or Node edge component, no more statistics and suggestions will be shown for conditional coloring.

#### GQI: Initial support for nested tables [ID_34144]

<!-- MR 10.3.0 - FR 10.2.9 -->

Initial support has been added for GQI results with cells containing nested records. However, at present this is only used for the *Resources* data source, which still requires the *GenericInterface* [soft-launch option](xref:SoftLaunchOptions).

The following functionality is now available for nested tables:

- Checking the number of records in nested tables. If a column with nested tables is retrieved, you cannot inspect the nested tables themselves yet, but a display value will show the number of records they contain.
- Aggregation on a single nested table column. There is no support for grouping yet. The aggregated value of the nested cell will be shown in the parent record as an ordinary cell.
- Filtering of nested tables.
- Selecting columns from nested tables. These will be shown in the same list box as regular columns, but their name will be prefixed by the parent column name. For example, if the parent column is named "Capabilities" and the nested table column is named "Name", the column will be listed as "Capabilities.Name".

#### Dashboards app / Low-Code Apps: Conditional coloring layout configuration now uses numeric filter instead of numeric slider [ID_34174]

<!-- MR 10.3.0 - FR 10.2.10 -->
<!-- Part of this RN is still in soft launch and consequently has not been documented yet -->

In the conditional coloring layout setting for Table and Node edge components, the numeric slider control has been replaced with a numeric filter. This has the following advantages:

- Full control over the boundaries. You can indicate whether the start and end should be in- or excluded.
- Possibility to not have a start or end boundary.
- More consistent with the free text filter.
- Easier to define a precise filter.

#### Dashboards app / Low-Code Apps: Conditional coloring layout filter configuration now shows discrete column values [ID_34182]

<!-- MR 10.3.0 - FR 10.2.10 -->
<!-- Part of this RN is still in soft launch and consequently has not been documented yet -->

In the conditional coloring layout setting for Table and Node edge components, discrete column values will now be displayed to make it easier to configure a filter.

#### GQI table column names will no longer include table names [ID_34302]

<!-- MR 10.3.0 - FR 10.2.10 -->

When a GQI table column inherits its name from a parameter of which the name includes the table name (between brackets), that table name will now be trimmed from the column name.

#### GQI: Enhanced performance of the ProfileInstance data source [ID_34320]

<!-- MR 10.3.0 - FR 10.2.11 -->

Because of a number of enhancements, overall performance has increased when running a GQI query using the ProfileInstance data source.

#### GQI: Enhanced performance when retrieving table data [ID_34441]

<!-- MR 10.3.0 - FR 10.2.12 -->

Because of a number of enhancements, overall performance has increased when retrieving table data by means of a GQI query.

#### Dashboards app - Line & area chart: Non-trended parameters will now automatically be removed when the component is linked to a parameter feed [ID_34499]

<!-- MR 10.3.0 - FR 10.2.12 -->

When a parameter feed is linked to a *Line & area chart" component, from now on, non-trended parameters will now automatically be removed from the chart.

#### Dashboards app - Parameter feed: 'Auto-select all' setting no longer available when using an EPM identifier feed as source [ID_34501]

<!-- MR 10.3.0 - FR 10.2.11 -->

When a parameter feed has an EPM identifier feed as source, from now on, the *Auto-select all* setting will no longer be available.

#### Dashboards app / Low-Code Apps - Line & area chart: Group label will no longer be displayed when grouping is set to 'All together' [ID_34544]

<!-- MR 10.3.0 - FR 10.2.12 -->

In case a *Line & area chart* component displays trending for multiple parameters, the *Group by* setting allows you to specify how the graphs should be grouped. From now on, group titles will no longer be displayed when you set *Group by* to "All together".

#### Dashboards app / Low-Code Apps: Enhanced performance of selection boxes [ID_34577]

<!-- MR 10.3.0 - FR 10.2.12 -->

Because of a number of enhancements, overall performance has increased when opening selection boxes, especially when they contain a large number of items.

#### Dashboards app: Upload size of PDF files will now be validated [ID_34620]

<!-- MR 10.3.0 - FR 10.2.12 -->

When PDF files are uploaded via the WebAPI (e.g. when a PDF report is generated), an error will now be thrown when the batch size exceeds 10 MB or the total file size exceeds 1 GB.

#### Dashboards app / Low-Code Apps - Visual Overview component: Enhancements with regard to WebSocket/polling settings and user access to visual overviews [ID_34624]

<!-- MR 10.3.0 - FR 10.2.12 -->

A number of enhancements have been made to the visual overview component, especially with regard to the WebSocket/polling settings and the algorithm that checks whether users have access to the visual overviews retrieved by the component.

#### GQI: Enhanced performance when retrieving DomInstances that have a DomBehaviorDefinition [ID_34853]

<!-- MR 10.3.0 - FR 10.3.1 -->

Because of a number of enhancements, overall performance has increased when retrieving DomInstances that have a DomBehaviorDefinition.

### Fixes

#### Dashboards app: Dashboard names would incorrectly be allowed to contain backslash characters [ID_31735]

<!-- MR 10.3.0 - FR 10.2.1 -->

Up to now, it would incorrectly be allowed to enter a name containing backslash characters when creating or renaming a dashboard. From now on, this will no longer be allowed.

#### Mobile apps: Clients would not immediately receive updates when items were added [ID_32042]

<!-- MR 10.3.0 - FR 10.2.2 -->

When new items were added in one client, in some cases, those items would not immediately appear in other clients. For example, when a user created a ticket for a particular domain, other users viewing the list of tickets for that same domain would not immediately have their ticket list updated.

#### Jobs app: No 'loading' indication when job sections were being loaded [ID_32616]

<!-- MR 10.3.0 - FR 10.2.4 -->

When configuring jobs, no “loading” indication would appear when job sections were being loaded.

#### Web services API: Problem with GetServiceTemplate [ID_32625]

<!-- MR 10.3.0 - FR 10.2.4 -->

The GetServiceTemplate method would throw an exception when requesting a service template with Text inputs that had neither of the following options:

- Require a valid element name
- Allow 'N/A' to indicate empty value

#### Web Services API: Problem when opening the soap.asmx page [ID_32939]

<!-- MR 10.3.0 - FR 10.2.5 -->

In some cases, an exception could be thrown when you tried to open the following page: `http://DmaNameOrIpAddress/API/v1/soap.asmx`

#### Dashboards app: Selection in parameter feed would incorrectly be cleared whenever the linked EPM feed was updated [ID_33153]

<!-- MR 10.3.0 - FR 10.2.6 -->

When an EPM feed was linked to a parameter feed, in some cases, the current selection in the parameter feed would incorrectly be cleared whenever the EPM feed was updated.

#### Web apps: Only part of the value would be selected when moving the mouse pointer over a selection box that had the focus [ID_33379]

<!-- MR 10.3.0 - FR 10.2.7 -->

When you moved the mouse pointer over a selection box that had the focus, in some cases, only part of the value would be selected.

#### Dashboards app - GQI: Values of profile parameters without decimals defined would incorrectly be replaced by the maximum integer value [ID_33418]

<!-- MR 10.3.0 - FR 10.2.7 -->

When a profile parameter of type “number” had no decimals defined, its value would incorrectly be displayed as the maximum value that can be assigned to a parameter of type integer. From now on, when a profile parameter has no decimals defined, its value will be displayed as is, without decimals.

#### Ticketing app: Problem when trying to add a value to the State field of a ticket domain [ID_33537]

<!-- MR 10.3.0 - FR 10.2.7 -->

When you tried to add a new value to the State field of a ticket domain, the following error would be thrown when the change was saved:

```txt
Error trapped: Unable to cast object of type 'Skyline.DataMiner.Web.Common.v1.DMATicketFieldPossibleValue' to type 'Skyline.DataMiner.Web.Common.v1.DMATicketStateFieldPossibleState'.
```

#### Dashboards app: Dashboard would incorrectly scroll up when you selected a field in an EPM feed [ID_33650]

<!-- MR 10.3.0 - FR 10.2.8 -->

When, on a dashboard, an EPM feed was surrounded by other components, in some cases, the dashboard would incorrectly scroll up when you selected a field in the EPM feed.

#### GQI - Elasticsearch: Aggregated data did not have the number of decimals specified in the parameter info [ID_33712]

<!-- MR 10.3.0 - FR 10.2.11 -->

Aggregated data retrieved from an Elasticsearch database did not have the number of decimals specified in the parameter info.

#### Dashboards app / Low-Code Apps: Changes to the feed could incorrectly influence the time window of a state timeline component [ID_34148]

<!-- MR 10.3.0 - FR 10.2.10 -->

In some cases, changes to the feed linked to a state timeline component could reset the time window. From now on, linking a query filter to the timeline will no longer influence the time window. The filter will be applied and the current time window will be preserved.

Also, because of a number of enhancements, overall performance has increased when linking a query filter to a state timeline component.

#### Dashboards app / Low-Code Apps: Column filters in generic filter component incorrectly marked as incapable [ID_34273]

<!-- MR 10.3.0 - FR 10.2.10 -->

In the generic filter component, in some cases, column filters would be incorrectly marked as incapable when the filter assistance option was enabled.

#### Dashboards app / Low-Code Apps: Query column filters would not be applied correctly to table components [ID_34305]

<!-- MR 10.3.0 - FR 10.2.10 -->

when a dashboard, a low-code app page or low-code app panel was initialized, in some cases, query column filters would not be applied correctly to table components on that dashboard, page or panel.

#### Web apps - Interactive Automation scripts: Not possible to clear a selection box by selecting an empty option [ID_34315]

<!-- MR 10.3.0 - FR 10.2.11 -->

When an interactive Automation script was executed in a web app, it would incorrectly not be possible to clear a selection box by selecting an empty option.

#### Web Services API - CreateServiceTemplate: DataMinerID and ElementID incorrectly set to 0 instead of -1 [ID_34440]

<!-- MR 10.3.0 - FR 10.2.11 -->

When a service template was created using the *CreateServiceTemplate* method, the DataMinerID and ElementID of the newly created service template would incorrectly be set to 0 instead of -1.

#### Dashboards / Low-Code Apps: Changing a GQI query would not cause a table to get updated when column filters were applied [ID_34520]

<!-- MR 10.3.0 - FR 10.2.11 -->

When the GQI query linked to a table component was changed, the table would incorrectly not get updated when column filters were applied. The table would only get updated when you changed the column filters.

#### Mobile apps: Problem when trying to select an item in a drop-down box [ID_34742]

<!-- MR 10.3.0 - FR 10.2.12 [CU0] -->

In some cases, it would incorrectly not be possible to select an item in a drop-down box when the items were grouped or when their actual value was not identical to the value that was displayed.

#### Dashboards app: Empty groups would incorrectly not be removed from parameter feeds listing EPM parameters [ID_34884]

<!-- MR 10.3.0 - FR 10.3.1 -->

When, in a parameter feed listing EPM parameters, the parameters were grouped, empty groups would incorrectly not be removed after switching to another EPM object.

#### Low-Code Apps: Problem with 'Close a panel' action [ID_34892]

<!-- MR 10.3.0 - FR 10.3.1 -->

When a *Close a panel* action was configured as a post action on a button component, in some cases, it would incorrectly not cause the panel to close.

#### Dashboards & Low-Code Apps: Decimal values would incorrectly not be allowed in range filters [ID_34897]

<!-- MR 10.3.0 - FR 10.3.1 -->

In some cases, a range filter in a query filter or a table column filter would incorrectly not allow decimal values.

> [!NOTE]
> When using a query filter with filter assistance enabled, the statistics will determine the number of decimals that can be used.

#### Dashboards & Low-Code Apps: Feed component selections would incorrectly be lost after applying a built-in theme [ID_34908]

<!-- MR 10.3.0 - FR 10.3.1 -->

When you applied a built-in theme, feed component selections would incorrectly be lost after refetching the data.

#### Dashboards & Low-Code Apps: Not possible to group the data in a timeline populated using a query with a query filter [ID_34932]

<!-- MR 10.3.0 - FR 10.3.1 -->

When a timeline was populated using a query with a query filter, it would incorrectly not be possible to group the data.

#### Low-Code Apps: Drop-down box containing an 'execute component' action would incorrectly be empty [ID_34953]

<!-- MR 10.3.0 - FR 10.2.12 [CU1] -->

When an *execute component* action had been configured, in some cases, when you tried to update that action, the drop-down box containing the action would incorrectly be empty.

#### Dashboards app & Low-Code Apps: Manually sorted GQI table would no longer feed row values [ID_34969]

<!-- MR 10.3.0 - FR 10.2.12 [CU1] -->

When you had manually changed the sorting order of a GQI table by clicking a column header, in some cases, the table would no longer feed the selected row values.

#### Dashboards app: Tables would lose their conditional coloring after being sorted or filtered [ID_34979]

<!-- MR 10.3.0 - FR 10.3.1 -->

When you sorted or filtered a table fed by e.g. a query filter, the table would incorrectly lose its conditional coloring.

#### Web apps: Problem when a trend graph displaying multiple parameters showed data that was partly in the future [ID_34982]

<!-- MR 10.3.0 - FR 10.3.1 -->

When a trend graph displaying multiple parameters showed data that was partly in the future, in some cases, an error could occur.

#### Dashboards app: Button to restore the initial view would incorrectly appear on all tables after sorting or filtering a table [ID_35003]

<!-- MR 10.3.0 - FR 10.3.2 -->

When, on a dashboard, you sorted or filtered a table, a button to restore the initial view would incorrectly appear on all tables on that dashboard. Also, when you clicked one of those buttons, they would all disappear. From now on, when you sort or filter a table on a dashboard, a button to restore the initial view will only appear on that particular table.

#### Monitoring app: Problem when opening the histogram page of a view [ID_35081]

<!-- MR 10.3.0 - FR 10.3.2 -->

When, in the *Monitoring* app, you selected a view and opened the histogram page, in some cases, a `Maximum call stack size exceeded` error would appear.

#### Dashboards app: Visual Overview component would not show any content when linked to a feed [ID_35130]

<!-- MR 10.3.0 - FR 10.3.2 -->

When a Visual Overview component was linked to a feed, in some cases, it would not show any content.

#### Dashboards app & low-code apps: Loading indicator would not appear when sorting, filtering or refreshing a table [ID_35238]

<!-- MR 10.3.0 - FR 10.3.2 -->

When you sorted or filtered a table by clicking a table header, or when an action triggered a refresh of the table data, in some cases, no loading indicator would appear.

#### GQI: Problem when fetching two queries using an external data source with a custom argument of which the ID was set to "Type" [ID_35242]

<!-- MR 10.3.0 - FR 10.3.3 -->

When two queries using an external data source with a custom argument of which the ID was set to "Type" had to be fetched, only one of the two queries would get fetched when the only difference between them was the value of the custom argument.

#### GQI: Metadata would incorrectly be removed when a custom operator was applied [ID_35283]

<!-- MR 10.3.0 - FR 10.3.2 -->

When, in a GQI query, a custom operator was applied, all metadata available on the rows would incorrectly be removed, causing feeds to no longer work as expected.

Also, when a column was renamed via a custom operator, the metadata available on that column would incorrectly be removed.
