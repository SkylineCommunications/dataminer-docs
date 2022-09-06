---
uid: General_Feature_Release_10.1.3
---

# General Feature Release 10.1.3

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## New features

### DMS core functionality

#### Failover: PowerShell scripts can now be triggered when a Failover agent claims or releases a virtual IP address \[ID_28236\]

When a Failover agent claims or releases a virtual IP address, the following PowerShell scripts will now be triggered (if they exist):

- C:\\Skyline DataMiner\\Tools\\VIPAcquired.ps1
- C:\\Skyline DataMiner\\Tools\\VIPReleased.ps1

> [!NOTE]
>
> - The VIPAcquired script will also be triggered when the online agent starts, but the VIPReleased script will not be triggered when the offline agent starts.
> - The content of the Failover scripts can be read and modified using the FailoverScriptManagerHelper.

#### Elasticsearch: Multi-cluster offload \[ID_28295\]\[ID_28384\]\[ID_28473\]

It is now possible to have data offloaded to multiple Elasticsearch clusters, i.e. a main cluster and a number of replicated clusters.

Read actions are sent to the main cluster only, while write, delete and other modifying actions are sent to the main cluster as well as to all replicated clusters.

When an error occurs on one of the replicated clusters, a single alarm will be generated, indicating that there is a chance that not all data was replicated. If subsequent errors occur on the replicated clusters, no new similar alarms will be generated until after the DMA has been restarted.

##### Configuration

The configuration of the Elasticsearch clusters can be stored in a new DBConfiguration.xml file, located in the C:\\Skyline DataMiner\\Database folder. This configuration file takes priority over the existing Db.xml file when it comes to Elasticsearch.

At DataMiner startup, when the DBConfiguration.xml file exists and an Elasticsearch connection is defined in the Db.xml file, the Elasticsearch connection is commented out in the Db.xml file and an additional comment is added, indicating that the Elasticsearch configuration is taken from the DBConfiguration.xml file instead.

> [!NOTE]
>
> - The cluster with the lowest “priorityOrder” value is considered the main cluster. All other clusters are considered the replicated clusters.
> - The DBConfiguration.xml file is not synchronized among the DMAs in a DMS.

#### Message throttling configuration in MaintenanceSettings.xml \[ID_28335\]

It is now possible to fine-tune message throttling, i.e. a mechanism that avoids an excessive number of parameter update messages getting sent to a client at the same time, using the following settings in *MaintenanceSettings.xml*:

- *MessageThrottlingThreshold*: Time interval in ms. The default and minimum value is 250. If two updates for the same parameter are received within this interval, message throttling is activated. The first of the parameter updates is sent immediately, but messages for the same parameter that come after this are throttled until no more parameter updates have been received for this same time interval. Once the throttling has stopped, the last update is also sent after at most this time interval.

- *MessageThrottlingPeriodicUpdate*: Time interval in ms. The default value is 1000, and the value must always be at least twice the *MessageThrottlingThreshold* value. If there is a steady flow of updates for the same parameter, and message throttling is activated, a periodic update is sent after this interval.

Example:

```xml
<MaintenanceSettings>
  ...
  <SLNet>
    ...
    <MessageThrottlingThreshold>250</MessageThrottlingThreshold>
    <MessageThrottlingPeriodicUpdate>1000</MessageThrottlingPeriodicUpdate>
    ...
  </SLNet>
  ...
</MaintenanceSettings>
```

#### Failover: Connecting to the online agent using a DNS record with 2 IP addresses \[ID_28634\]

It is now possible to connect to the online agent in a Failover setup when that setup only has a single DNS record containing 2 IP addresses (i.e. one for the online agent and one for the offline agent).

#### DataMiner Object Model: Event messages \[ID_28635\]

Every DomManager can now send out the following event messages:

| Event message                            | Description                                                       |
|------------------------------------------|-------------------------------------------------------------------|
| DomSectionDefinitionsChangedEventMessage | Generated when a SectionDefinition is created, updated or deleted |
| DomDefinitionsChangedEventMessage        | Generated when a DomDefinition is created, updated or deleted     |
| DomInstancesChangedEventMessage          | Generated when a DomInstance is created, updated or deleted       |
| DomTemplatesChangedEventMessage          | Generated when a DomTemplate is created, updated or deleted       |

Since multiple DomManager instances can send out the above-mentioned event messages (each with their own unique module ID), the ModuleEventSubscriptionFilter\<T>(string moduleId) subscription filter can be used to return events of type T sent by the DomManager with ID moduleId.

#### DataMiner Object Model: EnableInformationEvents property \[ID_28703\]

If you want an information event to be generated for every create, read, update or delete action performed on a DOM object, in the DomManager settings, you can now enable the EnableInformationEvents property.

Default value: false

#### DataMiner Object Model - DomManager: DomInstance history \[ID_28709\]

A DomManager now keeps track of the DomInstance history. A DomInstance change will now be created after each successful create, read, update or delete action performed on a DOM object.

Changes to FieldValues will be stored in DomFieldValueChange objects containing the following items:

| Item              | Description                                                      |
|-------------------|------------------------------------------------------------------|
| FieldDescriptorId | The ID of the Field descriptor                                   |
| CrudType          | Whether this change is a create, update or delete                |
| ValueBefore       | The value before the change (will be null when this is a create) |
| ValueAfter        | The value after the change (will be null when this is a delete)  |

Per DomInstance section, those DomFieldValueChange objects will be bundled in a DomSectionChange object containing the following items:

| Item              | Description                          |
|-------------------|--------------------------------------|
| SectionId         | The ID of the section                |
| FieldValueChanges | The list of FieldValueChange objects |

The DomSectionChange objects will be stored in a HistoryChange object, which contains the metadata of the change. That metadata can then be used for filtering purposes:

| Item         | Description                                                      |
|--------------|------------------------------------------------------------------|
| ID           | A unique Guid (Filterable)                                       |
| SubjectId    | The ID of the DomInstance (Filterable)                           |
| Time         | The UTC time at which the change was done (Filterable)           |
| FullUsername | The name of the user who initiated the change (Filterable)       |
| DmaId        | The ID of the DMA on which the change was initiated (Filterable) |
| Changes      | The list of DomSectionChange objects                             |

The changes can be retrieved and filtered using the DomHelper. See the following examples:

```csharp
var filter = HistoryChangeExposers.SubjectID.Equal(domInstance.ID.ToFileFriendlyString());
```

```csharp
var history = domHelper.DomInstanceHistory.Read(filter);
```

> [!NOTE]
>
> - If the history storage were to work incorrectly, this will not affect the create, read, update or delete actions performed on the DomInstances. An error will be logged each time a history object could not be saved. A notice will only be generated once every hour.
> - It is not possible to manually create, update or delete history objects.
> - All history changes related to a DomInstance will automatically be deleted when that DomInstance is deleted.
> - History data is stored in a separate index per module (chistory_dominstance\_\*module id\*).

#### DataMiner Object Model - DomManager: Add attachments to DomInstances \[ID_28739\]

It is now possible to add attachments to DomInstance objects. See the examples below.

```csharp
var domHelper new DomHelper(engine.SendSLNetMessages, PermissionTestModuleId);
var fileBytes = File.ReadAllBytes("path");
// Adding an attachment
domHelper.DomInstances.Attachments.Add(domInstanceId, "filename", fileBytes);
// Get the names of all attachments
domHelper.DomInstances.Attachments.GetFileNames(domInstanceId);
// Get the content of an attachment
domHelper.DomInstances.Attachments.Get(domInstanceId, "filename");
// Delete an attachment
domHelper.DomInstances.Attachments.Delete(domInstanceId, "filename");
```

> [!NOTE]
>
> - The maximum size of the attachments is determined by the Documents.MaxSize setting, located in the MaintenanceSettings.xml file. Default: 20 Mb. Trying to upload a larger file will result in a DataMinerException.
> - If a DomInstance is deleted, all its attachments will physically be deleted from disk. They will not be recoverable.
> - Manipulating DomInstance attachments requires the same user permissions as normal DomInstance management operations: Read permission to view and download attachments and Edit permission to add and delete attachments.
> - All DomInstance attachments are synchronized throughout the DataMiner System. To include them in a backup, select the “All documents located on this DMA” backup option.

### DMS Security

#### Elasticsearch: Security now by default disabled on new installations \[ID_28598\]

From now on, when you install an Elasticsearch database, security will be disabled by default (basic authentication and TLS).

#### DataMiner Cube - System Center: Account linking user permission added \[ID_28643\]

In preparation for the cloud connected Agents feature (currently still in soft launch), the user permission *Account linking* has been added in the Users /Groups section of System Center, under *Modules* > *System configuration* > *Cloud sharing*. This user permission determines whether users can link a DataMiner account to a cloud account, which is necessary to be able to share items in the cloud or stop sharing items in the cloud.

### DMS Cube

#### Launching DataMiner Cube on a specific host using the cube:// protocol \[ID_28160\]

Using the cube:// protocol, it is now possible to launch a DataMiner Cube on a specific host. All existing URL arguments are supported.

Examples:

- cube://mydma?element=MyElement
- cube://10.11.12.13?view=12

#### DataMiner Cube start window: Grouping, rearranging and filtering tiles \[ID_28346\]

In the DataMiner Cube start window, tiles representing DataMiner Systems or DataMiner Agents can now be grouped, rearranged and filtered.

- To create a new group, drag a tile out of its current group.
- To name or rename a group, click above the group and enter the (new) name.
- To move a tile to another position (or another group), drag it to its new position.
- To filter the tiles, hover over the looking glass and enter a search string in the search box. Alternatively, you can also start typing a search string without going to the search box.

    > [!NOTE]
    > When a search does not yield any results, you can click the plus icon or press ENTER to add the host name or IP address you were looking for.

> [!NOTE]
>
> - The start window now has keyboard support. Use the arrow keys to move from one tile to the next, and press ENTER to launch.
> - The start window can now be resized. When you resize and/or reposition the window, its new size and position will be saved.

#### Visual Overview: TableRowFilter option of ParameterControlOptions data item now supports FullFilter syntax \[ID_28531\]

When defining a table control in Visual Overview, it is now possible to use FullFilter syntax when configuring the *TableRowFilter* option in the *ParameterControlOptions* data item.

Example:

| Shape data field        | Value                                            |
|-------------------------|--------------------------------------------------|
| Element                 | MyTableElement                                   |
| ParameterControl        | 1000                                             |
| ParameterControlOptions | TableRowFilter:FULLFILTER=(PK == 0) OR (DK == 1) |

#### Service & Resource Management - Services app: Existing connections between node interfaces can now be edited on the service diagram using drag and drop \[ID_28597\]

In the service diagram, it is now possible to change the end points of connections between service definition node interfaces using drag and drop.

1. Select an existing connection. Its “from” and “to” interfaces will be highlighted.
2. Click the endpoint you want to change and drag it onto another endpoint while keeping the mouse button pressed.
3. Release the mouse button. The connection will now have changed. Its source point will be the same as before, but its endpoint will have changed.

#### DataMiner Cube start window: Opening a Cube instance without closing the start window \[ID_28608\]

It is now possible to connect to a DMA without closing the start window. To do so, in the start window, click a tile while holding the CTRL button.

This will allow you to open multiple instances of DataMiner Cube, each connected to a different DMA.

> [!NOTE]
> If you press ENTER while holding the CTRL button, a Cube instance will open and connect to the DMA specified in the currently selected tile.

#### DataMiner Cube: Option to return to the start window after logging out \[ID_28648\]

When you log out of DataMiner Cube, the login window appears. In that window, you can now click the *Back to start window* button to return to the DataMiner Cube start window.

#### DataMiner Cube - Alarm Console: Translations added for two new reasons mentioned in Value column of group alarms generated by Automatic incident tracking \[ID_28676\]

When automatic incident tracking is activated, active alarms that are related to the same incident will automatically be grouped into a new alarm, and the Value column of such an alarm will show the reason why the alarms underneath it were grouped.

Translations have now been added for two new reasons:

- View group
- Custom property group (which will be formatted as “\<propertyName> group: \<value>”)

#### EPM: Chain grouping & automatic selection of single filter values \[ID_28751\]\[ID_28834\]\[ID_28846\]

In DataMiner Cube, EPM chains with the same value in the protocol’s Chain@groupingName element attribute (see example below) will now be grouped under that value in the EPM manager card (side panel and tabs) and in the chains selection box located in the topology sidebar.

Also, it is now possible to specify one filter value per chain that should be selected by default in filter boxes that contain only that specific value.

##### Example of a Protocol.Chains.Chain element with a group name and a default filter value

See the following example. The chain named “MyChain” will be part of the group named “MyChainGroup”, and if the filter named “MyField” only has one value, it will automatically be selected when you open the chain in the CPE manager or the topology tab in the sidebar.

```xml
<Protocol>
  <Chains>
    <Chain name="MyChain" defaultSelectionField="MyField" groupingName="MyChainGroup">
      ...
    </Chain>
  </Chains>
</Protocol>
```

> [!NOTE]
>
> - Each chain can only be part of a single chain group.
> - Chains that are not part of a group will be displayed as top-level tabs (on the same level as the group tabs).

#### Settings window: 'Surveyor' section renamed to 'Sidebar' & New 'Launch EPM card on filter selection' setting added \[ID_28788\]

In the user settings tab of the *Settings* window, the *Surveyor* section has been renamed to *Sidebar*.

Also, in that section, the existing Surveyor settings have now been grouped under the title “Surveyor”, and a new *Launch EPM card on filter selection* setting has been added under the title “Topology”. When you enable this new setting, an EPM card will automatically be launched after selecting an item in a topology tab filter.

### DMS Reports & Dashboards

#### Dashboards app: Parameter table filters \[ID_28539\]

In line chart components, it is now possible to configure a parameter table filter that will allow you to filter out specific rows.

Currently, two types of filters can be configured: VALUE and FULLFILTER. Built-in Intellisense will help you construct the filter.

Examples:

- value=PK == 1
- value=DK==Izegem
- value=518==5;value=522>=10
- fullfilter=(value=PK ==1 or value=PK ==2)
- fullfilter=((value=PK \> 36) and (value=518 in_range 1/5 )) or (VALUE=DK == Brus\*)

> [!NOTE]
>
> - Currently, only line chart components support the use of parameter table filters.
> - Parameter table filters can only be configured when you have started the Dashboards app with the *showAdvancedSettings* URL parameter set to true.
> - When you update a filter, you have to re-add it to the component.

#### Dashboards app - GQI: Exception values will now be processed as discrete values \[ID_28570\]

In GQI operators, up to now, exception values were processed as regular values. From now on, they will be processed as discrete values. As a result, the TopX operator and the following aggregation methods will no longer take them into account:

- Average
- Max
- Min
- Percentile
- Standard deviation
- Sum

> [!NOTE]
>
> - The *Count* and *Distinct count* aggregation methods will take exception values into account.
> - Exception values will not be taken into account when calculating the minimum and maximum value for columns using GenIfColumnFetch-Requests.

#### Dashboards app - Bar chart component: Negative values & Dynamic axis labels \[ID_28617\]

The bar chart component now supports negative values.

Also, the number of axis labels displayed will now depend on the size of the chart. Up to now, a fixed number of axis labels would be displayed.

#### Dashboards app - State component: Alignment setting \[ID_28633\]

The layout pane of a State component now has an additional setting that allows you to align its contents (left/center/right).

Also, in the components pane on the left, the *States* section has now been renamed to *States and values*.

#### Dashboards app - Table component: GQI query result can now be export to a CSV file \[ID_28637\]

When a table component displays the result of a GQI query, it is now possible to export that result to a CSV file.

To do so, click the ellipsis icon in the upper-right corner and select *Export to CSV*.

By default, the CSV file will be named “Query XXX” (XXX being the name of the query). If necessary, the name of the query can be changed in the *Queries* section in the table component’s data panel.

The first line of the CSV file will contain the names of the columns. The subsequent lines will contain the data, each line being a row of the query result. This data will contain the display values, not the raw values. This means that parameter values will contain units and that discrete values will be replaced by their corresponding display value.

By default, all rows of the query result will be exported. If you want to export only a subset, first select the rows to be exported and then click *Export to CSV*.

If you only want to export specific columns, you can drag those columns from the data panel onto the component before you export the data.

#### Dashboards app - Line chart component: Trend graph will now display the actual name of a profile parameter \[ID_28657\]

When, in the Dashboards app, you add a profile parameter to a line chart component, from now on, the label of its trend line will now display the actual name of the profile parameter instead of the name of the underlying parameter that is associated with it.

#### Dashboards app: State component now also supports protocol data and indices \[ID_28688\]

The state component now supports all possible data types, including protocol data and indices.

Also, the Layout pane of this component has been enhanced.

#### Dashboards app - GQI: Availability of the database will first be checked before querying an Elasticsearch database \[ID_28742\]

From now on, when GQI queries are about to fetch data from an Elasticsearch database, the availability of that database will first be checked.

#### Dashboards app: Service Definition components now accept services as data sources \[ID_28746\]

In the Dashboards app, service definition components now accept services as data sources.

When you drag a service onto a service definition component, by default, the component will display the service definition and the bookings of that service.

If necessary, you can apply a filter by specifying a time range. If you do not specify a time range, the component will display the current booking.

> [!NOTE]
> From now on, it is no longer possible to filter a service definition component when its data source is either a booking or a service definition.

#### Dashboards app - GQI: Support for dynamic units \[ID_28761\]\[ID_28831\]

A GQI query based on the *Get parameter table by ID* or *Get parameters for elements* where data sources will now, by default, inherit the dashboard’s *Use dynamic units* setting.

If necessary, you can override this automatic inheritance by selecting the component’s *Override dynamic units* setting.

> [!NOTE]
> From now on, when a GQI query does not use dynamic units, by default, parameter values will be displayed using a thin space as thousand separator.

#### Dashboards app - GQI: Using a feed as a column filter \[ID_28770\]

When building a GQI query, it is now possible to use a feed as a column filter.

Instead of providing a fixed value to filter a specific column, you can now select the *From feed* option and configure a filter by specifying the following items:

| Filter item | Description                                                                                                                |
|-------------|----------------------------------------------------------------------------------------------------------------------------|
| Feed        | The name of the feed that will provide the data. If only one feed is available, it will automatically be selected.         |
| Type        | The type of data that needs to be selected. If the feed only provides one type of data, it will automatically be selected. |
| Property    | The property by which the column will be filtered (depending on the type of data).                                         |

Example: If the column in question has to be filtered using the element name found in the URL of the dashboard, then you can set *Feed* to “URL”, *Type* to “Elements” and *Property* to “Name”.

### DMS Automation

#### Interactive Automation scripts: Enhanced file selector \[ID_28628\]

A number of enhancements have been made to the file selector used in interactive Automation scripts.

### DMS Service & Resource Management

#### DVE element will only be updated when certain properties of the FunctionResource are updated \[ID_28450\]

Up to now, each time you updated a FunctionResource, the DVE element would also be updated. From now on, the DVE element will only be updated when one of the following properties of the FunctionResource is updated:

- DmaID
- ElementID
- MainDVEDmaID
- MainDVEElementID
- FunctionName
- FunctionGUID
- PK
- LinkerTableEntries

#### MinReservationStart and MaxReservationCeiling checks have been removed \[ID_28575\]

The MinimumReservationStart and MaximumReservationCeiling checks have been removed.

This means that the start and stop times of ReservationInstances and ReservationDefinitions no longer need to be between the MinimumReservationStart and MaximumReservationCeiling.

Also, the following ResourceManagerErrorData reasons have now all been marked as obsolete:

- BulkAddingFirstOrLastToOLateOrTooEarly
- EndsAfterMaximumReservationCeiling
- StartsBeforeMinimumReservationStart
- ReservationDefinitionMinimumReservationStart
- ReservationDefinitionMaximumReservationCeiling

### DMS tools

#### SLNetClientTest: Viewing and editing SLNet configuration options with regard to NATS \[ID_28683\]

In the SLNetClientTest program, it is now possible to view and edit the following SLNet configuration options with regard to NATS, which are stored in the MaintenanceSettings.xml file:

- NATSDisasterCheck
- NATSResetWindow
- NATSRestartTimeout

> [!WARNING]
> The DataMiner SLNetClientTest program is an advanced system administration tool that should be used with extreme care (C:\\Skyline DataMiner\\Files\\SLNetClientTest.exe).

## Changes

### Enhancements

#### Correlation: Enhanced performance when clearing base alarms \[ID_28201\]

Due to a number of enhancements, overall performance has increased when simultaneously clearing a large number of correlation base alarms.

#### Dashboards app - GQI: Column selection enhancements \[ID_28202\]

When building a GQI query, it is now possible to click the up and down arrows on the right to make a column swap places with the column above or below it.

Also, by clicking the up and down arrows while holding the CTRL key, you can make a column swap places with the nearest selected column above or below it.

> [!NOTE]
>
> - Columns marked as a datasource’s default columns will be selected by default.
> - When a column selector node with values is reloaded (e.g. when an existing query is opened), the selected columns will be displayed before the unselected ones.

#### SLAnalytics will now keep track of configuration changes \[ID_28223\]

From now on, SLAnalytics will keep track of all changes made to its configuration settings.

Each DMA will keep a local configuration history, which will not be synchronized with the other DMAs in the DMS.

#### Service & Resource Management: Enhanced performance when executing the start actions of a ReservationInstance \[ID_28525\]

Due to a number of enhancements, overall performance has increased when executing the start actions of a ReservationInstance.

#### DataMiner Cube - Alarm Console: Enhanced performance when loading alarms into a sliding window \[ID_28537\]

Due to a number of enhancements, overall performance has increased when loading alarms into a sliding window, especially on systems with large alarm trees.

#### BPA tests can now indicate execute conditions \[ID_28576\]

The BPA interface has been extended with an ExecutionConditions property.

This way, BPA test writers can expose one or more conditions that need to be fulfilled before the BPA can be run. If the conditions are not met, the BPA will return “NoIssues” with the reason “This BPA does not apply for this DataMiner Agent”.

#### SLWatchDog will no longer try to restart NAS and NATS when they are disabled \[ID_28585\]

From now on, SLWatchDog will no longer try to restart NAS and NATS when the services are disabled. Also, when there is an active “NAS/NATS has stopped, restarting...” alarm, it will automatically be cleared after a short time.

#### DataMiner Cube - Service & Resource Management: Enhanced performance when opening Cube \[ID_28603\]

Due to a number of enhancements, overall performance has increased when opening Cube, especially in SRM environments.

#### BPA tests will now be executed by helper processes \[ID_28613\]

Up to now, BPA tests were executed from within the SLNet process. They will now be executed by helper processes instead.

#### Dashboards app: Optimized rendering of GQI query results in PDF reports \[ID_28622\]

In the Automation, Correlation and Scheduler modules, you can generate a report based on a dashboard from the new Dashboards app.

Due to a number of enhancements, the way in which tables that display GQI query results are rendered in PDF reports has now been optimized. When the *Stack components* option is enabled, tables showing results from different queries will even be rendered in such a way that all result sets are displayed one after the other.

#### Failover: Heartbeat checks will now be logged in the debug logging \[ID_28627\]

In a Failover setup, heartbeat checks will now be logged in the debug logging.

#### Alarm Console: Enhanced performance when dragging the history slider \[ID_28639\]

Due to a number of enhancements made to the mechanism used to retrieve alarms from the database, overall performance has increased when dragging the history slider in the Alarm Console.

#### Cassandra: Enabling TLS on database connection \[ID_28646\]\[ID_28827\]

It is now possible to enable TLS on Cassandra database connections.

To enable TLS for a particular Cassandra database, do the following:

1. Enable TLS in the settings of the Cassandra database.
2. Enable TLS in the settings of that database in Db.xml. See the following example:

    ```xml
    <DataBase active="true" local="true" type="Cassandra">
      <DBServer>10.10.10.10</DBServer>
      <UID>myUserId</UID>
      <PWD>myPassword</PWD>
      <DB>SLDMADB</DB>
      <TLSEnabled>true</TLSEnabled>
    </DataBase>
    ```

3. Make sure DataMiner is able to use TCP port 7001.

> [!NOTE]
> Currently, the above-mentioned procedure only enables TLS on the database connection. It does not enable client authentication.

#### BPA tests will now also be forwarded to offline agents \[ID_28658\]

Up to now, when a BPA test could not be run on an offline agent, it would not be forwarded to that agent. Now, BPA tests will be forwarded to all agents, and clients will be notified when an offline agent is not capable of running a test.

#### When the same BPA test is uploaded again, it will be updated \[ID_28668\]

Up to now, when a BPA test was uploaded, no check would be performed to determine whether it was already present on the system.

From now on, when a BPA test is uploaded, a check will be performed:

- If a BPA test is found with the same name under the same DLL, the test will be updated, but the GUID and the schedule will be left unchanged.
- If a BPA test is found with the same name under a different DLL, an error will be thrown.

#### SLAnalytics - Alarm Focus: Enhanced performance \[ID_28689\]

Due to a number of enhancements, overall performance has increased when fetching the alarm history.

#### Dashboards app - GQI: Changing the column order by using a column filter \[ID_28693\]

It is now possible to change the column order by using a column filter. The order of the selected columns in the column filter will now be used to construct the resulting table. By default, the order of the columns is determined by the data source.

Also, the following issue was fixed. When a row filter was used on a column that was not included in the default column set, in some cases, an additional column would incorrectly be added to the default column set.

#### Enhanced performance when a large number of Cube clients are connected to the same DMA \[ID_28695\]

Due to a number of enhancements, overall performance has increased when a large number of Cube clients are connected to the same DataMiner Agent.

#### Dashboards app - Table components: Enhancements with regard to resizing \[ID_28733\]

A number of enhancements have been made to the table components, especially with regard to the resizing of those components.

#### DataMiner Cube - SNMP forwarding: Setting the code page to be used \[ID_28745\]

When configuring an SNMP manager in DataMiner Cube, it is now possible to set the code page to be used.

Default code page: UTF-8

#### Dashboards app: GQI queries now synchronized in cluster \[ID_28756\]\[ID_28765\]

Queries created with the generic query interface in the Dashboards app will now be synchronized across all DMAs in a cluster.

#### Last test results can now be retrieved for any type of BPA test \[ID_28759\]

Previously, it was only possible to retrieve the last results of scheduled BPA tests that had run in the background. From now on, it is possible to retrieve the last results of any type of BPA test, scheduled or non-scheduled.

#### DataMiner Cube - Profiles app: Enhancements \[ID_28768\]

A number of enhancements have been made to the Profiles app. Overall performance has increased when loading profiles, and paging of profile parameters and profile definitions is now supported.

#### Dashboards app: Profile parameters can now also be included when grouping parameters on component level \[ID_28786\]

Up to now, when parameters were grouped in a line chart, trend statistics or parameter state component, profile parameters would not be included.

From now on, due to a number of enhancements, it is also possible to include profile parameters when grouping parameters on component level.

#### DataMiner Cube - Profiles app: A warning will now appear when no value is assigned to a mandatory parameter \[ID_28787\]

When, in the Profiles app, you indicate that a profile parameter is mandatory, if that parameter does not have a value assigned, a warning will now appear, saying that it is recommended to assign a value to mandatory parameters.

#### Dashboards app: GQI queries are now stored in the dashboards \[ID_28791\]

Up to now, GQI queries were stored in a separate JSON file. From now on, they will be stored in the dashboards.

#### 'Register DataMiner as Service32.bat' removed from the C:\\Skyline DataMiner\\Tools folder \[ID_28808\]

The “Register DataMiner as Service32.bat” file has been deprecated. It has been removed from the C:\\Skyline DataMiner\\Tools folder.

#### Cassandra Cluster: Default table compaction settings have been enhanced \[ID_28866\]

A number of enhancements have been made to the default Cassandra Cluster table compaction settings.

### Fixes

#### DataMiner Cube - Alarm Console: Problem with 'unread alarms' counter \[ID_28063\]

In some cases, the number of unread alarms displayed in the header of an alarm tab would be incorrect, especially on history tabs, on filtered tabs or when e.g. masking an alarm immediately after it was set to read.

#### DataMiner Cube: Problem when connecting to a large system with alarm storm prevention enabled \[ID_28127\]

When, on a large DataMiner System, alarm storm prevention was enabled, in some cases, Cube could freeze when you tried to connect.

#### Notice will now be generated when an error occurs after disabling and enabling the data offload configuration \[ID_28220\]

When the data offload configuration was disabled and enabled again, in some rare cases, an error can occur. If so, from now on, the following notice will be generated for database parameter 64599 and added to the SLElement.txt log file:

```txt
Central DataBase Offload threads aren't closed in a timely fashion. Potential issues with offloading rate data can occur. Disabling and enabling offload rate settings is advised.
```

#### Jobs app: Clicking Time \> Now in the date picker would set the time in an incorrect time zone \[ID_28274\]

When you clicked *Time \> Now* in the date picker while creating a new job, in some cases, the time would incorrectly be set in the time zone of the server instead of that of the client.

Also, a number of other issues regarding time zone settings were fixed.

#### Dashboards app - GQI: Problem when filtering out columns used in a join condition \[ID_28423\]

In some cases, it would no longer be possible to filter out columns that were used in a join condition. Doing so would result in a “Column not found” exception.

#### DataMiner Cube - Automation: Not possible to save a script after modifying an if/then block \[ID_28532\]

When, in an Automation scripts, you had changed the actions in an if/then block, in some cases, the *Save script* button would incorrectly not get activated. As a result, you were not able to save the modified script.

#### DataMiner Cube - Scheduler app: Problem when editing a script event in the timeline \[ID_28542\]

When editing a script event in the timeline of the Scheduler app, in some cases, an incorrect parameter would be passed to the DataMiner Agent, causing the Stop parameter on the scheduled action to get the value START instead of STOP.

#### Dashboards app: Problems when moving dashboards \[ID_28543\]

When, in the Dashboards app, you moved a dashboard to the currently active folder, in some cases, an error could occur when you tried to open the dashboard that was moved.

Also, when you manually entered the location to which a dashboard had to be moved, in some cases, that location would incorrectly not be saved when you pressed the ENTER key once. Only when you pressed the ENTER key a second time would the location be saved.

#### DMS Alerter: Settings window too small to fit all settings \[ID_28550\]

When, in DMS Alerter, you opened the settings window, in some cases, the window could be too small to fit all settings.

#### Dashboards app: Duplicated dashboard would incorrectly use the default theme \[ID_28552\]

When you duplicated a dashboard, the newly created dashboard would incorrectly use the default dashboard theme instead of the theme used by the original dashboard.

#### DataMiner Cube - Alarm Grouping: Problem when changing the polling IP address of an element associated with an alarm \[ID_28563\]

When the polling IP address of an element with a timeout alarm was changed, in some rare cases, the timeout alarm would incorrectly be linked to the old IP address instead of the new one. This would then lead to an incorrect grouping of alarms.

#### DataMiner Cube - Trending: Problem with percentile line \[ID_28565\]

When you added an additional trend line to an existing trend graph with one parameter, and then removing the original parameter, in some cases, the percentile line would no longer be visible.

#### Dashboards app - Bar chart component: Problem when selecting a time span without alarms \[ID_28569\]

When, while configuring a bar chart component that showed data from a view, you specified a time span during which no alarms had occurred, in some cases, an error could be thrown.

Now, an empty chart will be shown instead.

#### Service & Resource Management: ReservationInstance was incorrectly marked as interrupted when created with a start time before the Resource Manager was initialized \[ID_28571\]

When a ReservationInstance was created with a start time in the past, before the Resource Manager was initialized, that ReservationInstance would incorrectly be marked as interrupted.

#### Service & Resource Management: DecimalQuantity property of CapacityUsageParameterValue incorrectly saved without decimals \[ID_28582\]

When the DecimalQuantity property of the CapacityUsageParameterValue of a Profile-Instance was specified, in some cases, the decimals would be lost was the ProfileInstance was saved in the Elasticsearch database.

#### Problem when adding data to an Elastic logger table \[ID_28587\]

Up to now, when data was added to an Elasticsearch logger table, in some cases, an attempt would incorrectly also be made to add the same data to a non-existing Cassandra logger table.

#### Memory leak in SLPort when writing data to Stream Viewer \[ID_28605\]

In some cases, the SLPort process could leak memory when data was written to Stream Viewer via a smart-serial connection over UDP/TCP.

#### Failover: Offline agent would not be informed of changes made to BPA test configurations \[ID_28624\]

In a Failover setup, up to now, the offline agent would not be aware of any changes made to the configuration of a BPA test. From now on, the BPAManager will correctly inform that agent of all changes made to BPA test configurations.

#### Dashboards app - GQI: Problem when creating new queries due to file locking issue \[ID_28636\]

Due to a file locking issue, in some cases, it would not be possible to create new queries.

#### Db.xml: Problem when the \<DBServer> element of an Elasticsearch database configuration contained multiple IP addresses separated by spaces \[ID_28649\]

If, in Db.xml, the \<DBServer> element of an Elasticsearch database configuration contained multiple IP addresses separated by spaces, in some cases, an error could occur.

#### Problem when compiling QActions when 'System.xxxx' and 'Microsoft.xxx' DLL files could not be found in the Windows System Assemblies folders \[ID_28653\]

When a QAction was defined with dllImport=”System.xxxxx.dll” or dllImport=”Microsoft.xxxx.dll”, in some cases, the QAction would fail to compile when the referenced DLL file could not be found in the Windows System Assemblies folders.

Also, the compilation error would not be added to the log file.

#### NATS configuration file would incorrectly have an empty cluster tag \[ID_28663\]

In some cases, the NATS configuration file would incorrectly have an empty cluster tag.

#### Automation: Problem when ejecting of pre-compiled library \[ID_28665\]

In some cases, an exception could be thrown when a library DLL was ejected.

#### DataMiner Cube - Alarm Console: Memory usage would increase when a correlated alarm was cleared \[ID_28667\]

When a correlated alarm was cleared, overall memory usage would temporarily increase, which, in some rare cases, could lead to an “out of memory” exception.

#### Problem with SLSpectrum when a client disconnected \[ID_28669\]

In some cases, an error could occur in the SLSpectrum process when a client disconnected.

#### HTML5 apps: Problem when the SAML response from the identity provider contained line breaks \[ID_28671\]

When an HTML5 app (Dashboards, Monitoring, Job, Ticketing, etc.) received a SAML response from the identity provider, in some cases, an error could occur when that response contained line breaks.

#### Problem when retrieving trend data from a column of a view table that is based on another view table \[ID_28677\]

In some cases, it would not be possible to retrieve trend data from columns of a view table that was based on another view table.

When trend data has to be retrieved from a column of a view table that is based on another view table, another column in that same view table has to have the VIEWTABLEKEY option defined.

#### Correlation: Correlation rules would incorrectly be triggered by empty alarms \[ID_28680\]

In some cases, correlation rules would incorrectly be triggered by empty alarms, causing emails to be sent with unresolved placeholders.

#### Problem when subscribing to a direct view table based on a table from another driver with an ID identical to that of the direct view \[ID_28690\]

In some cases, a stack overflow could occur when a subscription was made to a direct view table based on a table from another driver with an ID identical to that of the direct view.

#### Uninstalling DataMiner Cube would not remove the EXE file \[ID_28704\]

When you uninstalled DataMiner Cube, in some cases, the EXE file would not be removed from the %localappdata%\\Skyline\\DataMiner\\DataMinerCube folder.

#### Problem in SLDataMiner if Protocol.xml.lnk file linked to unavailable path \[ID_28715\]

A problem could occur in the SLDataMiner process if a protocol production version Protocol.xml.lnk file linked to a path that could not be reached.

#### DataMiner Cube: Incorrect parameter information would be displayed in a card after it had been changed via an NT_UPDATE_DESCRIPTION_XML notify call in the protocol \[ID_28716\]

When, in DataMiner Cube, you opened a card, in some cases, parameter information like range, step size and description could be incorrect when that information had been changed via an NT_UPDATE_DESCRIPTION_XML notify call in the protocol.

#### Dashboards app: Component configuration changes would not get saved \[ID_28720\]

When, in the Dashboards app, you had made a change to the configuration of a component, in some cases, that change would not get saved.

#### DataMiner Cube - Services app: Capacity/capability value override would not be saved correct-ly \[ID_28721\]

When, in a service profile instance, you overrode the capacity of a parameter, the update would not be saved correctly when you had set the value to 0.

#### DataMiner Cube: Problem when opening an alarm card \[ID_28738\]

When, in DataMiner Cube, you opened an alarm card, in some cases, an exception could be thrown when the alarm duration was being calculated.

#### DataMiner Cube - Services app: Discard button would not be enabled after including or excluding a service profile definition parameter \[ID_28741\]

When, in the *Services* app, you included or excluded a service profile definition parameter in the *By node* tab, in some cases, the Discard button would incorrectly not be enabled.

#### DM Cube Scheduler: Problem when updating scheduler events \[ID_28748\]

When, in the Scheduler app, you made changes to an event, in some cases, although those changes would be saved correctly, they would immediately seem to get reverted in the UI. Only after closing the app and re-opening it again would you see the updated event in the UI.

#### DataMiner Cube - Alarm templates: Numeric baseline values would get parsed incorrectly \[ID_28750\]

When, in DataMiner Cube, you changed the baseline value of a numeric parameter, in some cases, that baseline value would get parsed incorrectly.

#### Domain groups and the users in those groups would be removed when the Active Directory server was unreachable \[ID_28758\]

When the domain server was not available, DataMiner would incorrectly remove all of the imported domain groups as well as the users in those groups.

#### Remote connections would incorrectly get removed from the local cache of a DMA when it lost its connection to another DMA \[ID_28760\]

When a DMA temporarily lost its connection to another DMA, in some cases, remote connections of other DMAs would incorrectly also get removed from its local cache.

#### DataMiner Cube desktop app: Problem when started with the '/Hostname=xyz' command line argument \[ID_28774\]

When you started the DataMiner Cube desktop app with the “/Hostname=xyz” command line argument, in some cases, an error could occur when its configuration file was empty or could not be found.

#### Dashboards app: Feeds section of edit pane’s Data tab would incorrectly list feeds using the component names \[ID_28779\]

When you added a feed component to a dashboard (e.g. a dropdown feed) and gave it a title, in the Feeds section of the edit pane’s Data tab, the feed would incorrectly have the name you gave to the component instead of the actual name of the feed.

#### DataMiner Cube - Alarm Console: Alarms in alarm tab of type 'Active alarms linked to cards' would be filtered incorrectly when opening an EPM card \[ID_28780\]

When, in your Alarm Console, you had an alarm tab of type “Active alarms linked to cards”, in some cases, when you opened an EPM card, the alarms in that alarm tab would not be filtered correctly. Also, the name of the alarm tab would not be displayed correctly.

#### Re-installation of NAS/NATS services would fail \[ID_28781\]

When the NAS and NATS services had been deleted manually, in some cases, re-installing those services would fail.

#### Problems caused by DMS.xml containing multiple addresses referring to the same DataMiner Agent \[ID_28793\]

When a DMS.xml file contained multiple addresses referring to the same DataMiner Agent, up to now, this could lead to various problems, one of them being disconnects/reconnects of type “XXXX state has changed from XXX to XXXXX” in DataMiner Cube.

#### Invalid 'Failed to read out schedules: XML response was not in the correct format.' errors added to SLErrors.txt log file \[ID_28795\]

In some cases, a “Failed to read out schedules: XML response was not in the correct format.” error message would be added to the SLErrors.txt log file for every alarm template on the system that did not have a schedule defined.

#### Problem when a client using special SLNet connections tried to forward a request to another DataMiner Agent \[ID_28801\]

When clients using special SLNet connections tried to forward a request to another DataMiner Agent in the DataMiner System, in some cases, a “Not a DataMiner user: DOMAINNAME\\SYSTEM” exception would be thrown.

#### DataMiner Cube: Desktop app could no longer be installed from the landing page \[ID_28802\]

In some cases, it was no longer possible to install the DataMiner Cube desktop app from the DataMiner landing page.

#### Start time and end time in metadata of BPA test result would be incorrect \[ID_28805\]

In the metadata of a BPA test result, you can find the start time and end time of the test. In some cases, both would incorrectly have the same timestamp and the end time would be returned in local time instead of UTC.

#### Dashboards app: Problem when all data was removed from a table column parameter that acted as data source for a Gauge, Ring or State component \[ID_28806\]

When a Gauge, Ring or State component had a table column parameter as data source, in some cases, an error could be thrown when, in DataMiner Cube, all data was removed from that table.

#### Dashboards app: Saved GQI queries containing deprecated identifiers could no longer be rebuilt \[ID_28807\]

In some cases, saved GQI queries containing deprecated identifiers could no longer be rebuilt.

#### SyncInfo agent IP address file would incorrectly be updated with the current timestamp on DMA startup \[ID_28809\]

At DataMiner startup, the IP address entries in the C:\\Skyline DataMiner\\Files\\SyncInfo\\{DO_NOT_REMOVE_DC5A2A6C-4583-493C-A9CD-7AEBBF905D1E}.xml file would incorrectly be updated with the current timestamp. In some cases, this could cause IP addresses to re-appear in DMS.xml files across the DMS after starting up a stopped DataMiner Agent that still had those IP addresses listed as active.

#### Dashboards app - Line chart component: Problem with the 'Minimum visible gap size' setting \[ID_28810\]

When, while configuring a line chart component, you opened the selection box containing the values of the *Minimum visible gap size* setting, in some cases, that selection box would not be displayed correctly.

#### Trending - MySQL: parameterName column in Offload database contained incorrect data \[ID_28824\]

In some cases, the parameterName column in an offload database of type MySQL would contain incorrectly concatenated values. They would contain parameterName + chIndex instead of parameterName + displayKey.

#### HTML5 apps: Problem with internal API calls when fetching data \[ID_28830\]

When working with HTML5 apps like Ticketing or Jobs, in some cases, the internal API calls ObserveTickets, ObserveJobs and ObserveBookings could throw an exception when fetching data.

#### Problem with SLDataMiner when loading protocols \[ID_28833\]

In some cases, an error could occur in the SLDataMiner process when loading protocols.

#### DataMiner Cube - Alarm Console: Problem when deleting elements during an alarm storm \[ID_28836\]

When, during an alarm storm, you deleted an element, in some cases, the alarm storm prevention mechanism would incorrectly keep taking the alarms of that element into account.

Also, when, during an alarm storm, you deleted an element with a large number of alarms, in some cases, the alarm counter would start to show an incorrect value.

#### SLNet cache would throw exceptions when receiving NULL data \[ID_28859\]

In some cases, the SLNet cache would thrown exceptions when receiving NULL data. In DataMiner, those exceptions would then appear as alarms of type error.

From now on, the SLNet cache will ignore any NULL data it receives.

#### DataMiner Cube: Problem when opening the Bookings app while being connected to a system with a MySQL database \[ID_28861\]

When, in DataMiner Cube, you opened the Bookings app while being connected to a system with a MySQL database, in some cases, an error could be thrown.

#### DataMiner Cube: Configuration file of start window could get corrupt when the start window was closed when the file was being updated \[ID_28949\]

When the DataMiner Cube start window was closed while its configuration file was being updated, in some cases, that configuration file could get corrupt.

> [!NOTE]
> In the configuration file of the DataMiner Cube start window, the minimum log level can now be configured.
>
> Possible log levels: 0 = Verbose, 1 = Debug, 2 = Information, 3 = Warning, 4 = Error, 5 = Fatal

#### Client-server communication will no longer be encrypted by default \[ID_29046\]

From now on, client-server communication will no longer be encrypted by default.

#### Locking issues in SLNet, SLASPConnection and SLDMS \[ID_29050\]

In some cases, locking issues could occur in the SLNet, SLASPConnection and SLDMS processes.
