---
uid: General_Main_Release_10.3.0_highlights
---

# General Main Release 10.3.0 – Highlights - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes related to DataMiner Cube, see [DataMiner Cube 10.3.0](xref:Cube_Main_Release_10.3.0).

## Highlights

### DMS core functionality

#### BREAKING CHANGE: GetSpectrumTrendTraceDataMessage will now always require a time range [ID_31402] [ID_32016]

<!-- MR 10.3.0 - FR 10.2.2 -->

When a GetSpectrumTrendTraceDataMessage was used to retrieve spectrum data, up to now, it was possible to pass an optional time range (i.e. RangeStart and RangeEnd) next to an ID (i.e. RecordID). From now on, passing a time range next to an ID will be mandatory.

#### DataMiner Object Models: Defining a TLL for DomTemplates, DomInstances and DomInstance history [ID_32662]

<!-- MR 10.3.0 - FR 10.2.6 -->

It is now possible to define a "time to live" property for the following types of DomManager objects:

| Object type                        | Property              |
|------------------------------------|-----------------------|
| DomInstance                        | DomInstanceTtl        |
| DomTemplate                        | DomTemplateTtl        |
| HistoryChange (DomInstanceHistory) | DomInstanceHistoryTtl |

Times are defined as TimeSpan objects. By default, these will be set to TimeSpan.Zero, i.e. no TTL. When, for a particular type of object, the TTL is set to e.g. 1 year, those objects will be automatically removed when they were last modified more than a year ago.

Example:

```csharp
var moduleSettings = new ModuleSettings("example")
{
    DomManagerSettings = new DomManagerSettings()
    {
        TtlSettings = new TtlSettings()
        {
            DomTemplateTtl = TimeSpan.Zero,                 // No TTL
            DomInstanceHistoryTtl = TimeSpan.FromDays(365), // 1 Year
            DomInstanceTtl = TimeSpan.FromDays(730)         // 2 Years
        }
    }
};
```

> [!NOTE]
> TTL settings are checked every 30 minutes. When you configure a very short TTL (e.g. 15 minutes), keep in mind that the objects in question will only be removed during the next cleanup cycle.

### DMS Security

#### SLSSH: Enhanced HMAC, cypher and key exchange algorithm support [ID_32664] [ID_32786]

<!-- RN 32664: MR 10.3.0 - FR 10.2.4
RN 32786: MR 10.3.0 - FR 10.2.5 -->

SLSSH now supports the following additional HMAC, cyphers and key exchange algorithms:

- HMAC-SHA2-512
- AES256CRT
- ECDHSHA2NISTP384
- ECDHSHA2NISTP521

DataMiner now supports the encryption methods detailed below (in order of preference).

##### HMACs

- HMAC-SHA2-512
- HMAC-SHA2-256
- HMAC-SHA1
- HMAC-MD5

##### Key exchange algorithms

- ecdh-sha2-nistp521
- ecdh-sha2-nistp384
- ecdh-sha2-nistp256
- diffie-hellman-group14-sha1
- diffie-hellman-group1-sha1
- diffie-hellman-group-exchange-sha1

##### Ciphers

- Aes-256-CTR
- Aes-128-CTR
- Aes-128-CBC
- 3des-CBC

#### SLSSH: Enhanced host key verification algorithm support [ID_33132]

<!-- MR 10.3.0 - FR 10.2.6 -->

When acting as an SSH client, DataMiner now supports the following host key verification algorithms (in order of preference):

- ecdsa-sha2-nistp521 (new)
- ecdsa-sha2-nistp384 (new)
- ecdsa-sha2-nistp256 (new)
- ssh-rsa
- ssh-dss

### DMS Protocols

#### Timers: Specifying an interval between two consecutive ping packets [ID_34463] [ID_34549]

<!-- MR 10.3.0 - FR 10.2.11 -->

When you configure a timer to automatically send ping requests to a device, you can now use either the `interval` option or the `intervalPid` option to specify the interval in ms between two consecutive ping packets.

- `interval`: With this option, you can specify a fixed interval in ms between two consecutive ping packets. This should be used when the device does not respond to all ping requests when they are sent without any interval.

- `intervalPID`: Instead of specifying a fixed interval value ("interval=x"), it is also possible to specify a dynamic value stored in a parameter. Note that if you specify both a fixed and a dynamic value, the latter will take precedence.

    The value in the referred parameters must not be 0 or uninitialized. Otherwise, 0, the hard-coded value on the timer, or the last valid value will be used by default. The referred parameters must be of numeric type.

> [!NOTE]
> These options are only relevant when *amountPackets* or *amountPacketsPID* is used. These are currently only supported in conjunction with the *threadPool* option. When *threadPool* is not used, only one ping request will be sent.

### DMS Web Services

#### Web Services API v1: New methods to manage service templates [ID_31612]

<!-- MR 10.3.0 - FR 10.2.1 -->

Using the following methods, it will now be possible to manage service templates via the web services API:

- CreateServiceTemplate
- DeleteServiceTemplate
- GetServiceTemplate
- UpdateServiceTemplate

### DMS web apps

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

#### Low-code apps: Data input via URL [ID_34261]

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

### DMS Service & Resource Management

#### Replacing system functions by uploading an XML file [ID_32264]

<!-- MR 10.3.0 - FR 10.2.3 -->

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

#### Modified AbsoluteQuarantinePriority behavior and several new SRM features [ID_32654]

<!-- MR 10.3.0 - FR 10.2.4 -->

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

#### Functions.xml file: Assigning a function type to a function [ID_32851]

<!-- MR 10.3.0 - FR 10.2.5 -->

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

#### BREAKING CHANGE: Removing a Resource or ResourcePool object will now always require a valid ID [ID_33836]

<!-- MR 10.3.0 - FR 10.2.9 -->

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
