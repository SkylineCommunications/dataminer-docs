---
uid: General_Feature_Release_10.1.4
---

# General Feature Release 10.1.4

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## New features

### DMS core functionality

#### Deletion history of services and service templates \[ID_28664\]

From now on, each time a service or a service template is deleted, a service history record will be written to the database. Each record will contain the following information:

- A unique record ID
- The ID of the service (template) that was deleted
- The name of the service (template) that was deleted
- The time at which the service (template) was deleted
- The time at which the service (template) was created.

The service history records can be retrieved using the existing HistoryHelper:

```csharp
var historyHelper = new HistoryHelper(engine.SendSLNetMessages);
var recordsPastDay = ServiceDeletionHistoryExposers.ServiceDeletedAt.GreaterThan(DateTime.UtcNow.AddDays(-1));
var historyRecords = historyHelper.ServiceDeletionHistory.Read(recordsPastDay);
```

> [!NOTE]
>
> - Service history records are stored in ElasticSearch. This means, that an ElasticSearch database has to be available for this feature to work.
> - If you want the service history records to be included in a DataMiner backup, select the *Include service history data in backup* option. In case of a full backup, this option will be selected by default.

#### SLAnalytics - Automatic incident tracking: Grouping on generic alarm, element, service and view properties \[ID_28820\]

Automatic incident tracking attempts to group alarms that belong to the same incident. To do so, by default, it takes into account the following alarm properties:

- The parameter associated with the alarm
- The service associated with the alarm
- The element associated with the alarm, the IDP location of this element, and the view(s) in which this element is located
- The polling IP address of the element associated with the alarm (only in case of a timeout alarm)

From now on, automatic incident tracking can also take into account any alarm, element, service or view property.

- The properties that have to be taken into account must be configured in the analytics configuration file. See “Configuration” below.
- The alarm properties that have to be taken into account need to have the *Update alarms on value changed* option activated in DataMiner Cube.
- The element, service and view properties that have to be taken into account need to have the *Make this property available for alarm filtering* option activated in DataMiner Cube.

Alarms are grouped as soon as they have the same value for one of the configured alarm, service or view properties, the same focus value and approximately the same timestamp. However, in case of grouping on element property, a threshold needs to be set and alarms will only be grouped when a certain amount of elements with the given property value are in alarm. In other words, alarms on elements with the same property value will be grouped when the proportion of elements in alarm among all elements with that property value is greater than the configured threshold.

##### Configuration

If you want automatic incident tracking to take into account a certain alarm, element, view or service property, you will need to add that property to the \<Value>\</Value> tag in the following section of the \[DataMiner installation folder\]\\analytics\\configuration.xml file.

```xml
<item type="skyline::dataminer::analytics::workers::configuration::XMLConfigurationProperty&lt;class std::vector&lt;class std::shared_ptr&lt;class skyline::dataminer::analytics::workers::configuration:: IGenericPropertyVisitorConfiguration&gt;,class std::allocator&lt;class std::shared_ptr&lt;class skyline::dataminer::analytics::workers::configuration:: IGenericPropertyVisitorConfiguration&gt; &gt; &gt; &gt;">
  <Value>
    [One <item> tag per property that has to be taken into account. See below.]
  </Value>
  <Accessibility>2</Accessibility>
  <Name>GenericProperties</Name>
</item>
```

> [!NOTE]
> After editing this configuration file, SLAnalytics needs to be restarted.

To add an element property, add the following \<item> tag inside the \<value> tag. Make sure to replace \[PROPERTY_NAME\] with the name of the element property and \[THRESHOLD\] with the desired threshold (see above).

```xml
<item type="skyline::dataminer::analytics::workers::configuration::GenericElementPropertyVisitorConfiguration">
  <enable>true</enable>
  <threshold>[THRESHOLD]</threshold>
  <name>[PROPERTY_NAME]</name>
</item>
```

To add an alarm property, add the following \<item> tag inside the \<value> tag. Make sure to replace \[PROPERTY_NAME\] with the name of the alarm property.

```xml
<item type="skyline::dataminer::analytics::workers::configuration::GenericAlarmPropertyVisitorConfiguration">
  <enable>true</enable>
  <name>[PROPERTY_NAME]</name>
</item>
```

To add a view property, add the following \<item> tag inside the \<value> tag. Make sure to replace \[PROPERTY_NAME\] with the name of the view property.

```xml
<item type="skyline::dataminer::analytics::workers::configuration::GenericViewPropertyVisitorConfiguration">
  <enable>true</enable>
  <name>[PROPERTY_NAME]</name>
</item>
```

To add a service property, add the following \<item> tag inside the \<value> tag. Make sure to replace \[PROPERTY_NAME\] with the name of the service property.

```xml
<item type="skyline::dataminer::analytics::workers::configuration::GenericServicePropertyVisitorConfiguration">
  <enable>true</enable>
  <name>[PROPERTY_NAME]</name>
</item>
```

#### LogHelper API: New FlushToDatabaseAfterUpsert option \[ID_28837\]

The LogHelper API now has a FlushToDatabaseAfterUpsert option.

- If you set this option to true (i.e. the default setting), then the LogHelper will wait for the database to respond after writing log entries to the database.
- If you set this option to false, then the LogHelper will not wait for the database to respond after writing log entries to the database.

> [!NOTE]
> If you set this option to false, there are no guarantees that all log entries will get stored in the database, especially in case of e.g. connection issues or exceptions.

#### Masked alarms will no longer be automatically unmasked when cleared \[ID_29007\]\[ID_29138\]

Up to now, when a masked alarm was cleared, it would automatically be unmasked. From now on, when a masked alarm is cleared, it will stay masked as long as the element associated with the alarm is masked.

In DataMiner Cube, the mask status (“Masked” or “Not masked”) will now be indicated in the Alarm Console column “Extra status”, which will not be visible by default.

> [!NOTE]
> This change will cause a small increase in latency when retrieving alarms from the database.

#### Cache for SNMP inform messages \[ID_29034\]

To handle situations where inform messages are sent out again while they have already been acknowledged by DataMiner, DataMiner will now by default keep the latest 20 inform messages per SNMP entity in a cache, so that it can check whether an incoming inform message has already been processed, and discard it if this is the case.

In the *DataMiner.xml* file, you can customize how many inform messages are stored in the cache. To do so, set the *informCacheSize* attribute of the *SNMP* tag to the number of inform messages that should be stored. For example:

```xml
<DataMiner>
   ...
   <SNMP informCacheSize="25" />
   ...
</DataMiner>
```

> [!NOTE]
>
> - If you set *informCacheSize* to 0, the cache will be disabled.
> - Only inform messages are stored in this cache, not traps.
> - When an inform message is discarded, this is logged in *SLSNMPManager.txt* on information level 3.

### DMS Security

#### DataMiner Cube - System Center: User permissions for 'Live Sharing' and 'Cloud Connected Agents' features have been reorganized \[ID_29004\]

In the *Users/Groups* section of *System Center*, the user permissions for the Live Sharing and Cloud Connected Agents features, which are currently still in soft launch, have been reorganized.

Under *General \> Live sharing*, you can now find the following user permissions:

- UI Available
- Share
- Edit
- Unshare

Under *System configuration \> Cloud gateway*, you can now find the following user permissions:

- Connect to cloud
- Disconnect from cloud
- Configure gateway service

> [!NOTE]
>
> - The user permissions listed under *Live sharing* are included in the *Power users* preset and higher.
> - The user permissions under *Cloud gateway* are included in the *Administrators (read-only access to Security)* preset and higher.
> - The *Account linking* permission, which was added in DataMiner feature release version 10.1.3, has been removed.

### DMS Protocols

#### New 'FlushPerDatagram' option for smart-serial UDP connections \[ID_28999\]

When configuring the port settings of a smart-serial UDP connection, it is now possible to specify a *FlushPerDatagram* option.

When this option is set to true, any datagram received on the connection will be forwarded to SLProtocol, which will then store it in the response parameter.

Example:

```xml
...
<PortSettings>
    <FlushPerDatagram>true</FlushPerDatagram>
</PortSettings>
...
```

### DMS Cube

#### Visual Overview: KPI stencil and Button stencil have been restyled \[ID_28691\]

The KPI stencil and the Button stencil have been restyled.

##### KPI stencil

- Apart from being restyled, the following shapes have also been renamed:

    | Old name             | New name           |
    |----------------------|--------------------|
    | kpi-noIcon-v         | kpi-noIconV        |
    | kpi-noIcon-h         | kpi-noIconH        |
    | param-normal         | list-normal        |
    | param-normal-compact | list-compact       |
    | param-combi-compact  | list-combi-compact |
    | param-multi          | list-multi         |
    | param-combi          | list-combi-compact |

- A KPI and its associated icon can now be displayed in two different ways:

    | Shape     | Description                                                    |
    |-----------|----------------------------------------------------------------|
    | kpi-icon  | Focus on the parameter alarm state, with an icon on top of it. |
    | kpi-icon2 | Fixed background (dark blue), with an icon on top of it.       |

    > [!NOTE]
    > Make sure to replace the icon by one that suits the requirements.
    >
    > All available icons can be found in the Icons stencil.

- The master shapes of which the name starts with “kpi-” can now show the element icon with the alarm state (\_showElement) and an icon that can be clicked to navigate to the alarm overview of the linked element (\_showAlarm).

- The write icon in the top-right corner of a shape has been changed from a black triangle to a cogwheel.

##### Button stencil

- The style of the toggle buttons now matches the style of the toggle button in DataMiner Cube.

- All other buttons have had their rounding style adapted in order to match that of the buttons found on the Data pages of element cards.

    > [!NOTE]
    > It is advised to add an ellipsis (...) to the text on a button if user interaction is required after clicking the button in question.

> [!NOTE]
> The toggle buttons now use the theme accent color. This means that you will need an additional Options shape data field on page level with, for example, the following value: *#000000=ThemeForeground\|#FF0000=ThemeAccentColor\|#FFFFFF=ThemeBackground*

#### Visual Overview: New icon added to Icons stencils \[ID_28696\]

The following icon has been added to the Icons stencil:

- Alarms

#### Information event generated when a context menu of a table is used \[ID_28753\]

When, in DataMiner Cube, you open a context menu of a table and select an option from it, from now on, an information event will be generated similar to the one that is generated when you set a parameter.

This information event will contain the following data:

- **Parameter description**: The full display name of the context menu parameter. Format: *\<TableName>\_ContextMenu*

- **Parameter value**: A value in the following format:

  `Set by <user> to <command display value>`

  If there are dependency values, the value will have the following format:

  `Set by <user> to <command display value>: “<dependency 1>”; “<dependency 2>”`

#### DataMiner Cube - Visual Overview: Parameter value will now be cleared from the shape text when the dynamic part of its Parameter shape data field changes \[ID_28901\]

When a dynamic part of a Parameter shape data field changes, from now on, the existing parameter value will by default be cleared from the shape text.

If you do not want this to happen, then add ClearValueOnSubscriptionChange=False in the shape’s Options data field:

| Shape data field | Value                                |
|------------------|--------------------------------------|
| Options          | ClearValueOnSubscriptionChange=False |

#### DataMiner Cube will now use Chromium to handle SAML authentication \[ID_28922\]

In order to support a wider range of identity providers (e.g. Azure AD), DataMiner Cube will now use Chromium instead of Internet Explorer when handling SAML authentication.

> [!NOTE]
> DataMiner Cube clients will now automatically download the CefSharp package from the DataMiner Agent they connect to.

#### Alarm Console: New option to allow a history tab to show alarms associated with an enhanced service deleted in the selected time frame \[ID_28942\]

Up to now, when you created a history tab with a service filter, it was only possible to select one of the active enhanced services. Now, it is also possible to select one of the enhanced services that has been deleted in the selected time frame (e.g. “last hour”).

When, in the filter section, you selected “Service” and you want to be able to select an enhanced service that has been deleted in the selected time frame, then click the *Load deleted services* option, and select the deleted service from the list. That way, you will be able to create a history tab that lists the alarms associated with an enhanced service that has been deleted in the selected time frame.

#### Sidebar: New help button to open DataMiner Dojo menu \[ID_28990\]

At the bottom of the sidebar, you can now click a help button that will open a menu containing links to the following pages on DataMiner Dojo:

| Menu command    | Page on DataMiner Dojo                                      |
|-----------------|-------------------------------------------------------------|
| Blog            | <https://community.dataminer.services/blog/>                |
| Questions       | <https://community.dataminer.services/questions/>           |
| Learning        | <https://community.dataminer.services/learning/>            |
| Resources       | <https://community.dataminer.services/documentation/>       |
| Suggest feature | <https://community.dataminer.services/feature-suggestions>  |

#### Schedule configuration of BPA tests \[ID_29000\]

On the *Agents* > *BPA* page in System Center, you can now schedule when a BPA test should run. In the drop-down box in the *Schedule* column, you can select to run a test at different intervals, e.g. daily or every 12 hours.

#### New Surveyor setting: Collapse DVE elements beneath their main element \[ID_29021\]

The new Surveyor setting “Collapse DVE elements beneath their main element” now allows you to specify how DVE child elements are displayed.

By default, this setting is disabled, and DVE child elements are displayed in the same way as other elements.

- If you set this to “All DVEs”, DVE child elements will be displayed on the level below the parent elements in the tree structure, so that you can collapse and expand the list of child elements.
- If you set this to “Only function DVEs”, this will only happen for function DVEs.

### DMS Reports & Dashboards

#### Dashboards app: New Views data source for generic query interface \[ID_28707\]\[ID_28877\]

The generic query interface now features a new *Views* data source, which can be used to retrieve all the views in the DataMiner System. For each view, the View ID and Name columns are retrieved by default. The following columns can also be retrieved by means of an additional column filter:

- Parent view ID
- Last modified
- Last modified by
- Enhanced element ID
- Custom view property columns

#### Dashboards app - GQI: New 'View relations' data source \[ID_28797\]\[ID_28877\]

In the Generic Query Interface, a new “View relations” data source is now available. It contains all DataMiner objects that are part of a view.

Each row in this data source has the following columns:

| Column   | Description                                                                 |
|----------|-----------------------------------------------------------------------------|
| View ID  | The ID of the view.                                                         |
| Child ID | The ID of the DataMiner object in the view.                                 |
| Depth    | The level of the DataMiner object in the view tree in relation to the root. |

When you set the *Recursive* option to true, the table will not only contain all direct relationships (i.e. between a parent item and a child item), but also all indirect relationships (e.g. between a grandparent item and a grandchild item).

#### Dashboards app: Existing GQI queries stored in Queries.json will now automatically be copied to the correct dashboard files during a DataMiner upgrade \[ID_28816\]

As from DataMiner main release version 10.1.0 and feature release version 10.1.3, GQI queries are stored in the dashboards instead of a separate Queries.json file, located in the C:\\Skyline DataMiner\\Generic Interface\\ folder.

When you upgrade to DataMiner main release version 10.2.0 or feature release version 10.1.4, any existing GQI queries that are still stored in the Queries.json file will now automatically be copied to the correct dashboard files.

#### Dashboards app - GQI: Records in views, services and elements data sources now contain metadata that will allow views, services and elements to act as feeds \[ID_28891\]\[ID_28940\]

All records in the views, services and elements data sources will now contain metadata that will allow a view, a service or an element to act as a feed when a table row referring to that view, service or element is selected.

#### Dashboards app - GQI: Importing a query from another dashboard into the current dashboard \[ID_28907\]\[ID_29022\]

It is now possible to import queries from another dashboard into the current dashboards.

1. In the *Queries* section of the *Data* pane, click the *Import* button.

2. In the *Import Query* window,

    - select the dashboard containing the query,
    - select the query,
    - if necessary, change the name of the query, and
    - click *Import*.

> [!NOTE]
> If you import a query that uses other queries, all those queries will be merged into one single query that will then be imported into the current dashboard.

### DMS Mobile apps

#### HTML5 apps that require an Elasticsearch will now redirect users to an error page when that database is unavailable \[ID_28767\]

When you log on to an app that requires an Elasticsearch database, you will now be redirected to an error page when that database is unavailable.

### DMS Service & Resource Management

#### ProfileDefinitions & ProfileInstances: Hiding parameters \[ID_28792\]

A ParameterSettings property has been added to the ProfileDefinition and ProfileInstance classes. Currently, this property can be used to configure whether a parameter should be displayed or not by setting the IsHidden property (which, by default, is false).

ProfileDefinition example:

```csharp
var profileDefinition = new ProfileDefinition()
{
    ID = Guid.NewGuid(),
    Name = "ProfileDefinition name",
    ParameterIDs = { profileParameter },
    ParameterSettings = new Dictionary<Guid, ParameterSettings>()
    {
        {profileParameter, new ParameterSettings() { IsHidden = false }}
    }
};
```

ProfileInstance example:

```csharp
var profileInstance = new ProfileInstance
{
    ID = Guid.NewGuid(),
    Name = $"ProfileInstance name",
    AppliesToID = profileDefinitionId,
    Values = new []
    {
        new ProfileParameterEntry
        {
            Parameter = new ProfileParameter()
            {
                ID = profileParameter
            },
            ParameterSettings = new ParameterSettings()
            {
                IsHidden = true
            }
        }
    }
};
```

#### ServiceDefinitions of type 'ProcessAutomation' \[ID_28799\]

The ServiceDefinition object now has a ServiceDefinitionType property, which can be used to distinguish ProcessAutomation ServiceDefinitions from default ServiceDefinitions.

The default value of ServiceDefinitionType is “Default”.

Example:

```csharp
// Creating a ServiceDefinition with the "ProcessAutomation" type
var serviceDefinition = new ServiceDefinition()
{
    Name = "some name",
    ServiceDefinitionType = ServiceDefinitionType.ProcessAutomation,
}
// Filtering on "ServiceDefinitionType"
var filter = ServiceDefinitionExposers.ServiceDefinitionType.Equal((int) ServiceDefinitionType.ProcessAutomation);
serviceManagerHelper.GetServiceDefinitions(filter);
```

#### Option to remember which view a function DVE was in when it got deactivated \[ID_28884\]

It is now possible for a function DVE that gets deactivated to remember the view it was in. That way, when it gets reactivated again afterwards, it can be placed in the same view as before.

Since this feature will prevent views of inactive function DVEs from being removed from the views.xml file, it can make the views.xml file grow extensively. Therefore, it is disabled by default and has to be enabled manually in the MaintenanceSettings.xml file. See the example below.

```xml
<MaintenanceSettings>
  <SLNet>
    <KeepFunctionDveViewsOnDisable>true</KeepFunctionDveViewsOnDisable>
  </SLNet>
</MaintenanceSettings>
```

> [!NOTE]
> When a resource is removed, all associated entries will be removed from the views.xml file.

#### ServiceResourceUsageDefinition now has an IsContributing flag \[ID_28904\]

The ServiceResourceUsageDefinition object now has an IsContributing flag, which can be used to indicate that the resource is being used is a contributing resource.

Example:

```csharp
// Setting the flag
var reservationInstance = new ServiceReservationInstance(new TimeRangeUtc(DateTime.UtcNow.AddHours(1), TimeSpan.FromHours(1)));
reservationInstance.ResourcesInReservationInstance.Add(new ServiceResourceUsageDefinition(resource.ID)
{
    IsContributing = true
});
```

#### EligibleResourceContext can now contain a flag to indicate whether LinkerTableEntries should be filled in or not \[ID_28933\]

When requesting EligibleResources, it is now possible for the EligibleResourceContext to indicate whether the LinkerTableEntries property of the Resources should be filled in or not.

Example:

```csharp
var context = new EligibleResourceContext()
{
    TimeRange = _reservationTimeRange,
    RequiredCapacities = new List<MultiResourceCapacityUsage>()
    {
        new MultiResourceCapacityUsage(_capacityParameterId, 1),
    },
    FillLinkerTableEntries = true
};
resourceManagerHelper.GetEligibleResources(context);
```

> [!NOTE]
> As filling in the LinkerTableEntries can have a negative impact on the overall performance, the LinkerTableEntries flag will by default be set to false.

## Changes

### Enhancements

#### Improved performance when writing trend data in Cassandra \[ID_27777\]

Performance has improved when writing trend data in the Cassandra database, both for single Cassandra nodes and Cassandra clusters.

#### Improved performance when writing data to file offload storage \[ID_28294\]

Performance has improved when data is written to the file offload storage while the Cassandra or Elasticsearch database is down.

#### Improved performance when writing and deleting data on single Cassandra node \[ID_28376\]

Performance has improved for all write and delete queries on single Cassandra nodes (not Cassandra clusters). This applies to all data handled by the SLDataGateway process, including alarms, trending, element data, etc.

#### Improved performance when deleting element data in database \[ID_28424\]

Performance has improved when deleting element data in a Cassandra or SQL database.

#### Cassandra: Enhanced method for restoring a Cassandra database backup \[ID_28485\]

From now on, a Cassandra database backup will be restored in the following way onto a DataMiner Agent with an existing Cassandra database:

1. Reset Cassandra to its factory default settings.
2. Delete the existing Cassandra data folder.
3. Restore the backup.

To restore a Cassandra database backup on a DataMiner Failover system with a Cassandra database, you will now have to proceed as follows:

1. End the DataMiner failover configuration as well as the Cassandra failover configuration.
2. Clear/reset the backup agent.
3. Restore the Cassandra database backup onto one of the two agents.
4. Set up the DataMiner Failover system again.

#### DataMiner Cube: Enhanced performance when opening cards \[ID_28743\]

Due to a number of enhancements, overall performance has increased when opening cards in DataMiner Cube.

#### SLDMS: Enhanced processing of DMS_SECURITY_NO_FORWARD messages \[ID_28796\]

Due to a number of enhancements, the way in which SLDMS processes DMS_SECURITY_NO_FORWARD messages has been optimized.

#### DataMiner Cube - Visual Overview: Unselecting a table row with the SingleSelection option enabled will now also clear the session variable \[ID_28848\]

In situations involving a table with columns that have a SelectionSetVar option configured and an embedded table control in Visual Overview with a SingleSelection option specified in its ParameterControlOptions data field, up to now, the session variable would not be updated when the selection was cleared.

From now on, the session variable will be cleared when you click the selected table row while holding down the CTRL key.

#### DataMiner Cube: SurveyorSearchText session variable will now be cleared when the advanced search tab is closed \[ID_28851\]

With the SurveyorSearchText session variable, you can configure a shape to display the most recently used search entry in the Surveyor, or to trigger a search in the Surveyor with a particular search entry.

From now on, this session variable will be cleared when the advanced search tab is closed.

#### DataMiner Cube - Services app: Enhanced performance when fetching profile definitions and profile instances \[ID_28870\]

Due to a number of enhancements, overall performance has increased when fetching profile definitions and profile instances in the Services app.

#### Size of C:\\Skyline DataMiner\\Logging\\MiniDump folder limited to 1 GB or 100 files \[ID_28879\]

The size of the C:\\Skyline DataMiner\\Logging\\MiniDump folder is now limited to 1 GB or 100 files (whichever is larger).

When a new ZIP file is created when the folder size is at its limit, the oldest ZIP file(s) in the folder will automatically be deleted.

#### SLNet connections for BPA tests will no longer be logged in SLClient.txt \[ID_28890\]

From now on, by default, SLNet connections set up for BPA tests will no longer be logged in SLClient.txt.

#### Cassandra: Logging will now include health status transitions and failed queries \[ID_28913\]

Cassandra health status transitions and failed queries will now also be logged in the SLDBConnection.txt log file.

#### DataMiner Cube: EPM card enhancements \[ID_28931\]

In DataMiner Cube, a number of general enhancements have been made to EPM cards.

#### DataMiner Cube: Enhanced performance during startup due to optimized creation of virtual function icons \[ID_28936\]

At startup, DataMiner Cube retrieves all virtual functions of all protocols and creates icons to graphically indicate the existence of those functions. Due to an optimization of this icon creation process, overall performance has increased during startup.

#### Failover: Non-existing PowerShell script will no longer result in an error being logged \[ID_28943\]

When a Failover agent claims or releases a virtual IP address, a PowerShell script will be triggered if it exists.

Up to now, when that script did not exist, an error would be logged. From now on, a notice with log level 1 will be logged instead.

#### Dashboards app - Line chart component: Grouping now also supported when using parameter filters \[ID_28977\]

When, in a line chart component, you had configured a parameter table filter, up to now, the parameters or parameter indices specified in that parameter table filter would not be taken into account when you created trend groups.

From now on, grouping is fully supported when using parameter filters.

#### Jobs app: PDF configuration & preview \[ID_28994\]

In the Jobs app, clicking the PDF button will now open a pop-up window where you can view a preview of the PDF and configure its settings. You can specify the PDF title and subject, select whether your company information, your company logo, and/or page numbers should be included, and customize the PDF width.

#### DataMiner Cube - Alarm Console: Enhanced performance when updating the source values of a Correlation base alarm \[ID_29020\]

Due to a number of enhancements, overall performance has increased when updating the source values of a Correlation base alarm.

#### SLAnalytics will now add a log entry when it goes into or out of flood mode \[ID_29039\]

When SLAnalytics detects a sudden rise in the amount of data to be processed, it will temporarily halt all processing and go into flood mode. Up to now, when going into flood mode, it would generate an alarm of type “notice”. Now, instead of an alarm, it will add an entry to the SLAnalytics log file.

A similar entry will be added to the log file when SLAnalytics goes out of flood mode.

#### Dashboards app - GQI: Empty parameter values in query results will now be displayed as 'Not initialized' \[ID_29045\]

In GQI query results, from now on, empty parameter values will be displayed as “Not initialized”.

#### Improved error logging during upgrades \[ID_29066\]

Error logging during DataMiner upgrades has been improved, so that the logging contains more information in some specific cases.

#### Failover: Enhanced version check during synchronization \[ID_29077\]

When two agents in a Failover setup synchronize, their DataMiner versions are compared to make sure those versions are compatible. A number of enhancements have now been made to this version check.

#### DataMiner Cube: Improved layout when Alarm Console is displayed as overlay \[ID_29108\]

When the alarm bar is clicked once so that the Alarm Console is displayed as an overlay, a shadow effect will now indicate that is it shown above the rest of the Cube UI. In addition, the icons in the Cube sidebar will now no longer move when the Alarm Console is displayed as an overlay.

### Fixes

#### DELT export packages would incorrectly not contain logger table data stored in Elasticsearch \[ID_28413\]

When you exported an element containing a logger table that saved its data in an Elasticsearch database, in some cases, the export package would not contain the data that was saved in the Elasticsearch database.

#### SLAutomation would incorrectly be initialized twice \[ID_28416\]

In some cases, SLAutomation would incorrectly be initialized twice.

#### DataMiner Cube: Problem when navigating using breadcrumbs \[ID_28468\]

In some cases, the overall element state of a partially included element would incorrectly be visible in the breadcrumbs. Also, users would incorrectly be able to open the full element via the breadcrumbs, even when they did not have full access to that element.

And when they used the breadcrumbs to navigate to the element via the service child, the element would incorrectly be opened instead of the service.

#### Alarm templates: Problem when calculating the transition from one week to the next \[ID_28477\]

In some cases, an error could occur when, in the alarm template schedule, the transition from one week to the next was calculated.

#### Dashboards app would incorrectly display CPE dummy columns \[ID_28495\]

In an EPM Manager driver, it is possible to mark certain columns as dummy columns. Up to now, the Dashboards app would incorrectly display those dummy columns.

#### Problem when trying to take a backup of an Elasticsearch database while Elasticsearch security is enabled \[ID_28679\]

In some cases, an error could be thrown when trying to take a backup of an Elasticsearch database while Elasticsearch security was enabled.

#### Timetrace data would become incorrect when an element had been dynamically included in or excluded from a service \[ID_28777\]

When an element had dynamically been included in or excluded from a service while active alarms were present, in some cases, the alarm count for the service in timetrace would start to show an incorrect value.

Also, when an element was excluded from a service while it had active alarms, in some cases, SLDataGateway would incorrectly consider the alarm reference to have an impact on the service. When the alarm was cleared while the element was excluded, it would never be removed from the service alarm impact list. As a result, that list could keep growing, which would eventually lead to an overall decrease of the alarm handling performance.

#### DataMiner Cube: Element name and icon would be incorrectly be visible in the alarm card and the alarm details when you did not have explicit access to the element \[ID_28778\]

In some cases, alarms for an element that is partially included in a service would be visible in the Alarm Console even when you did not have explicit access to that element. Also, when you opened the alarm card or the alarm details of one of those alarms, the element icon, alarm state and name would be displayed.

From now on, this will no longer the case when you do not have access to the element itself. Also, you will no longer be able to an element card of an element to which you do not have explicit access.

#### DataMiner Cube - Trend templates: Problem with 'Allow offload database configuration' setting \[ID_28794\]

When, in a trend template, you changed the Allow offload database configuration setting, in some cases, the setting would not be applied correctly.

#### Problem when launching Automation scripts when switching elements in a redundancy group that contained DELT elements \[ID_28832\]

When Automation scripts were launched when switching elements in a redundancy group of which either the primary or backup elements were DELT elements, in some cases, it would not be possible to pass \<Any Primary> or \<Any backup> as dummies.

#### DataMiner Cube - Services app: UI selections would be lost after saving or discarding changes made to a service profile definition \[ID_28839\]

When, in the Services app, you saved or discarded changes made to a service profile definition, in some cases, the selections you made in the UI would be lost.

#### Element log file would not be properly restarted on element restart \[ID_28841\]

In some cases, the element log file would not be properly restarted on element restart.

#### Dashboards app: Sorting issues \[ID_28850\]

In the Dashboards app, in some cases, table columns would be naturally sorted by display value instead of raw value, resulting in an incorrect order when using dynamic units or a numeric format with spaces.

Also, in the GQI query builder, in some cases, the default columns would be sorted incorrectly when using the “Select columns” option.

#### Problem with SLAutomation when an interactive Automation script was communicating with a client app \[ID_28862\]

When an interactive Automation script was communicating with the client app, in some cases, an error could occur in SLAutomation.

#### Service & Resource Management: Problem when saving or updating a service profile definition after defining virtual function IDs \[ID_28868\]

Due to an incorrect ID check, in some cases, it would not be possible to create or update a service profile definition after defining virtual function IDs.

#### DataMiner Cube - Interactive Automation scripts: Multiple 'Continue' messages would be sent to the DataMiner Agent \[ID_28872\]

When an interactive Automation script was running, DataMiner Cube would incorrectly send multiple identical “Continue” messages to the DataMiner Agent. In some cases, this would cause an error in SLAutomation.

#### Dashboards app: Problem when embedding a GQI dashboard component \[ID_28874\]

When an individual GQI dashboard component was embedded into Visual Overview or a web page, in some cases, the URL of that component would not contain all necessary information to run a GQI query.

Also, when a feed was used as a column filter in a GQI query, that feed would initially not be used when the query was initialized.

#### DataMiner Cube - Visual Overview: Problem when pressing CTRL+TAB while an item inside a Visio page had the focus \[ID_28876\]

When you pressed CTRL+TAB while an item inside a Visio page had the focus, in some cases, an exception could be thrown.

#### DataMiner Cube - Services app: Incorrect service definition data was displayed after saving a new service definition \[ID_28882\]

When, in the Services app, you saved a newly created service definition, in some cases, the UI would still display data belonging to the service definition that was selected before.

#### Legacy Reporter: Service definition image in the 'Booking Details' report would exceed the width of the report \[ID_28886\]

In the legacy Reporter, the service definition image in the “Booking Details” report would exceed the width of the report. That image has now been assigned a maximum width.

#### Problem in SLElement when recalculating alarm statuses while retrieving view data \[ID_28892\]

In some cases, an error could occur in SLElement when recalculating the alarm status for virtual function impact changes while retrieving view data.

#### Dashboards app: The contents of PDF reports would incorrectly be uploaded to the DMA twice \[ID_28895\]

When a PDF report was generated in the Dashboards app, the contents of that report would incorrectly be uploaded to the DMA twice.

#### Failover: Problem with failing heartbeats when agents were unreachable \[ID_28900\]

When checking Failover agent connectivity through heartbeats, failures could be registered even when the heartbeats succeeded. In some cases, this could lead to “Failing Heartbeat Path” notices being toggled indefinitely.

#### Problem when saving a job or a DomInstance with a section that referred to a non-existing SectionDefinition \[ID_28908\]

When saving a job or a DomInstance containing a section that referred to a non-existing SectionDefinition, up to now, a NullReferenceException would be thrown.

From now on, an error will be stored in tracedata instead:

- an error of type JobError with reason SectionUsedInJobLinksToNonExistingSectionDefinition, or
- an error of type DomInstanceError with reason SectionUsedInDomInstanceLinksToNonExistingSectionDefinition.

#### Problem when a cell in a table included in a virtual function was invalidated while the state of the service that included the virtual function was being changed \[ID_28911\]

In some cases, an error could occur when a cell in a table that was included in a virtual function was invalidated while the state of the service that included the virtual function was being changed.

#### DataMiner would no longer be able to connect to Cassandra after running SLReset \[ID_28925\]

After running the SLReset tool, in some cases, DataMiner would no longer be able to connect to a Cassandra database.

#### DataMiner Cube: Problem when previewing a dashboard containing components running GQI queries \[ID_28939\]

When, in DataMiner Cube, you previewed a dashboard that contained components running GQI queries, in some cases, an error could be thrown.

#### DataMiner Cube: Scheduler permissions would not include the timeline \[ID_28944\]

Up to now, the user permissions that control access to the Scheduler app would incorrectly not control access to the timeline view.

The following table lists the timeline actions users will now be allowed to perform when they have been granted a particular Scheduler user permission.

| User permission                 | Action a user is allowed to perform              |
|---------------------------------|--------------------------------------------------|
| Modules \> Scheduler \> Add     | Drop events on the timeline.                     |
| Modules \> Scheduler \> Delete  | Delete events on the timeline.                   |
| Modules \> Scheduler \> Edit    | Edit or move events on the timeline.             |
| Modules \> Scheduler \> Execute | Manually start or stop an event on the timeline. |

#### DataMiner Cube: Profiles app would incorrectly try to load service profiles on a non-SRM system \[ID_28947\]

When opening the Profiles app, in some cases, it would incorrectly try to load service profiles on a non-SRM system.

#### Cassandra: Problem with file offload \[ID_28951\]

Due to a file offload problem, in some rare cases, data operations (e.g. parameter updates) executed during a Cassandra outage would not get pushed to the database after the outage.

#### Service & Resource Management: Problem with GetEligibleResources calls \[ID_28960\]

In some cases, a GetEligibleResources call could incorrectly return resources that were not available due to a concurrency overflow.

Also, in some cases, a GetEligibleResources call would not return resources that were available because the system would incorrectly think no more capacity was available.

#### DataMiner Cube: A 'debug.log' file would incorrectly be created when initializing the CefSharp library \[ID_28963\]

In some cases, a “debug.log” file would incorrectly be created in the %LocalAppData%\\Skyline\\DataMiner\\DataMinerCube folder when the CefSharp library was initialized.

#### SLAnalytics - Automatic incident tracking: Incorrect error messages when the timer switched to the next hour while there are active alarms of type 'Property changed' \[ID_28968\]

When there were active alarms of type “Property changed” when the timer switched to the next hour, in some cases, automatic incident tracking would generate incorrect error messages.

#### Dashboards app: A 'debug.log' file would incorrectly be created when generating a PDF report via Automation \[ID_28969\]

In some cases, a “debug.log” file would incorrectly be created in the C:\\Skyline DataMiner\\Files folder when a PDF report was generated via Automation.

#### Problem with SLNet due to a NATS issue \[ID_28972\]

In some rare cases, a NATS issue could cause an error to occur in SLNet.

#### Problem with overall performance of SLNet connections \[ID_28976\]

In some cases, the overall performance of connections between SLNet and DataMiner clients would decrease.

#### DataMiner Cube - Alarm Console: Problem when some entries in an alarm tree matched an alarm filter while other entries did not \[ID_29011\]

When, in the same alarm tree, some entries matched an alarm filter while other entries did not, in some cases, that alarm would incorrectly not be shown.

#### Dashboards app: Problem when deleting GQI queries \[ID_29017\]

In some cases, it was not possible to delete GQI queries.

#### DataMiner landing page: Clicking the waffle icon did not open the sidebar \[ID_29050\]

When you clicked the waffle icon in the top-left corner of a DataMiner landing page (i.e. `https://<DmaAddress>/root/`), in some cases, the sidebar listing the available apps would not open.

#### Updating an element via a CSV export/import would not work properly when that element had an empty port type value \[ID_29052\]

When an element had an empty port type value, in some cases, trying to edit that element by exporting its data to a CSV file and then importing the updated CSV file would not work as expected.

#### DataMiner Cube: Problem when opening start window from the system tray \[ID_29054\]

In some rare cases, an exception could be thrown when opening the DataMiner Cube start window from the Windows system tray.

#### Problem when assigning an alarm template group to a DVE element \[ID_29063\]

When you assigned an alarm template group to a DVE element, no alarms would be generated.

#### DataMiner Cube start window: Configuration file would incorrectly be cleared \[ID_29080\]

When you closed the DataMiner Cube start window, in some rare cases, the configuration file of that start window would incorrectly be cleared.

#### ProtocolThread run-time error could occur when an element with a serial connection was paused \[ID_29083\]

In some cases, a ProtocolThread run-time error could occur when an element with a serial connection was paused.

#### Memory leak in SLXml when registered objects were removed \[ID_29091\]

In some cases, the SLXml process could leak memory when registered objects were removed.

#### Description of proactive cap detection setting in System Center corrected \[ID_29096\]

A typo has been corrected in the description for the proactive cap detection settings in System Center.

#### DataMiner Cube - Alarm Console: Incorrect alarm count when loading a history tab with an element filter while some alarms in the time range were still active \[ID_29106\]

When you loaded a history tab with an element filter while some of the alarms in the selected time range were still active, in some cases, the tab header would show an incorrect alarm count.

#### Failover: LDAP notification setting would incorrectly be ignored when synchronizing DataMiner.xml \[ID_29117\]

In a Failover setup, in some cases, the notification attribute of the LDAP element would incorrectly be ignored when synchronizing the DataMiner.xml file between the two Failover agents.

#### Dashboards app - Pivot table component: Index filter would be applied incorrectly \[ID_29133\]

When you applied an index filter in a pivot table component, in some cases, that filter would be applied incorrectly. Instead of the display key, the primary key would incorrectly be used.

#### DataMiner Cube: New DMS not saved in start window configuration \[ID_29151\]

When the Cube start window was not running in the system tray, and you added a DMS and then immediately connected to it, it could occur that the new DMS was not saved in the start window configuration.

#### SLAutomation: Problem when clearing the internal parameter cache \[ID_29165\]

In some cases, an error could occur in SLAutomation when its internal parameter cache was being cleared.

#### DataMiner Cube - Alarm Console: Incorrect 'Not a matrix update' notice in case of message throttling \[ID_29241\]

When message throttling was activated, in some cases, an incorrect “Not a matrix update” notice could appear in the Alarm Console when an element was restarted or when, after a DMA reconnection, initial table values were received while a table update was still being processed.

#### Failover: Exception thrown due to an issue caused by PowerShell \[ID_29263\]

On Failover systems, in some cases, a PowerShell problem could cause an exception to be thrown.

#### Cassandra: Problem creating the timetrace table when upgrading from an older DataMiner version \[ID_29319\]

In some cases, an error could occur when creating the timetrace table when upgrading from an older DataMiner version (e.g from version 10.0.0 to 10.1.4).

#### DataMiner Cube - Alarm Console: Correlation sources would no longer be updated \[ID_29330\]

When one of the sources of a correlation alarm (group) was updated, in some cases, the update would not be reflected in the Alarm Console. When you opened the correlation alarm (group), the previous alarm source would incorrectly still be shown.
