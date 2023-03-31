---
uid: General_Feature_Release_10.1.2
---

# General Feature Release 10.1.2

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## New features

### DMS core functionality

#### New Cassandra cluster feature \[ID_23210\]\[ID_23975\]\[ID_25945\]\[ID_26144\]\[ID_26475\]\[ID_27080\] \[ID_27520\]\[ID_27615\]\[ID_27648\]\[ID_27694\]\[ID_28406\]

A Cassandra cluster is now supported as the general database for a DataMiner System. While previously it was already possible to use a separate Cassandra cluster for each DataMiner node, this new feature allows all DataMiner nodes in a cluster to connect to the same Cassandra cluster.

##### Installation and configuration

To switch to using one Cassandra cluster for your DMS, follow the procedure below:

1. Make sure the Cassandra cluster software is installed on each DMA. A [standalone installer](xref:Standalone_Cassandra_Cluster_Installer) is available for this.

1. [Install Elasticsearch](xref:Installing_Elasticsearch_via_DataMiner) on each DMA in the cluster if you have not done so already.

1. Migrate the database data to the Cassandra cluster. See [Migrating the general database to a DMS Cassandra cluster](xref:Migrating_the_general_database_to_a_DMS_Cassandra_cluster).

    > [!NOTE]
    > We recommend that DataMiner is stopped before the migration is started. While it is possible to run the migration while DataMiner is running, any data that is stored in the source database during the migration may not be migrated to the target database.

1. In DataMiner Cube, go to System Center \> Database and select *CassandraCluster* in the Database box. Then specify the name, DB server and credentials to connect to the Cassandra cluster.

##### DB.xml changes

In the file *DB.xml*, the new database type “CassandraCluster” is now supported for the general (previously known as local) database. While previously, information in this file related to the general database was not synced in a cluster, if this database type is used, *DB.xml* is now completely synchronized throughout the cluster.

##### Cluster health monitoring

If a Cassandra node goes down or when a node is down when DataMiner starts up, an alarm will be generated in the Alarm Console. This alarm also indicates how much the health of the cluster is affected by the node being down, as this depends on multiple factors, including the cluster size and replication factor.

##### Limitations

- .dmimport packages created on a DMS using a Cassandra Cluster do not contain any database data, and it is not possible to import database data from such packages in such a DMS.
- If the Cassandra cluster feature is used, alarm and information event information is always migrated to Elasticsearch. It is not possible to use this feature without enabling indexing on alarms.

> [!NOTE]
> If a database of type Cassandra cluster is used, the soft-launch feature NewAverageTrending is automatically enabled. For more information, see <https://community.dataminer.services/documentation/average-trending-calculation/>.

#### DataMiner Object Model \[ID_28096\]\[ID_28392\]\[ID_28460\]

The DataMiner Object Model (DOM) is a collection of generic objects and a generic DomManager that can be used to perform a series of operations.

##### Object overview

| Object            | Description                                                                                             |
|-------------------|---------------------------------------------------------------------------------------------------------|
| SectionDefinition | Object that defines the data that should be present in a Section of a DomInstance.                      |
| DomDefinition     | Object that groups DomInstances and defines what Section-Definitions should be used by these instances. |
| DomInstance       | Object that contains the FieldValues in the Sections for the SectionDefinitions.                        |
| DomTemplate       | Simple object that has a pre-filled DomInstance object, which can be used as a template.                |

If, for example, you want to build a system that will store the time that employees spend on tasks, you can do the following:

1. Create a SectionDefinition with four FieldDescriptors:

    SectionDefinition (Name = “PunchInfoSectionDefinition”)

    - FieldDescriptor 1: Name = “Task ID” & Type = “Guid”
    - FieldDescriptor 2: Name = “Username” & Type = “String”
    - FieldDescriptor 3: Name = “Start time” & Type = “DateTime”
    - FieldDescriptor 4: Name = “Stop time” & Type = “DateTime”

1. Create a DomDefinition (Name = PunchInfoDomDefinition) that contains a link to the PunchInfoSectionDefinition.

Employees will now be able to log their time spent by creating a new DomInstance

- that is linked to the PunchInfoDomDefinition, and
- that has one Section linked to the PunchInfoSectionDefinition, which contains a FieldValue for each FieldDescriptor.

##### DomManager

A DomManager manages the create/read/update/delete actions performed on the DOM objects, which are stored in an Elasticsearch index.

DomManagers run in SLNet and are created/started the first time they are called. Note that a ModuleSettings object must first be created before a DomManager can be created. This object contains a module ID and information on how the manager should behave.

Create, read, update and delete calls on a DomManager can be initiated using a DomHelper in a script or an application.

### DMS Security

#### DataMiner Cube - System Center: New Planned Maintenance app permissions \[ID_28164\] \[ID_28541\]

In the *Users/Groups* section of *System Center*, it is now possible to configure the following new user permissions.

| User permission | Description                                                   |
|-----------------|---------------------------------------------------------------|
| UI available    | Permission to view the Planned Maintenance (PLM) app in Cube. |
| Add/Edit        | Permission to add or edit items in the PLM app.               |
| Delete          | Permission to delete items in the PLM app.                    |
| Configure       | Permission to configure the PLM app.                          |

#### DataMiner Cube - System Center: Renamed user permissions \[ID_28439\]

In the *Users/Groups* section of *System Center*, the following has been changed:

- The *Allow access to Mobile UI* permission has been renamed to *DataMiner Cube mobile access*, and has been moved from the *Modules \> System configuration \> Mobile Gateway* section to the *General* section.
- All “local database” references have been renamed to “general database”.

### DMS Protocols

#### Enhanced (direct) view column option 'view' \[ID_28448\]

The following (direct) view column option has been enhanced.

```xml
view=linkedPid:elementkeycolumnpid:remotedatatablepid:remotedatacolumnidx
```

This option can be configured in three different ways. See the table below. In the examples, table 11000 is a (direct) view on table 1000.

| Type of filtering | Example | Description |
|--|--|--|
| Local filtering | view=:1004:1000:1 | The elementkeycolumnpid refers to another column of the same table. Each row will be requested from the element referred to by the DMAID/EID found in parameter 1004. |
| Foreign key filtering | view=1003:1105:1000:2 | The elementkeycolumnpid refers to a column of the table linked by the foreign key found in parameter 1003. Each row will be requested from the element referred to by the DMAID/EID found in parameter 1105, which is linked via the foreign key in parameter 1003. |
| No filtering | view=:1401:1000:1 | The elementkeycolumnpid refers to a column of another table, which is not linked to the local table (no linkedPid is provided). Each row will be requested from the elements referred to by the DMAID/EID items found in column 1401. Note: If the remote elements contain duplicate keys, then this can cause data to be overwritten. |

### DMS Cube

#### Visual Overview: New icons added to DataMiner stencils \[ID_27571\]

##### New icons

The following additional icons are now available in the DataMiner stencils:

- General input
- General output
- OT
- OR
- Multiplexer
- Demultiplexer
- Modulator
- Demodulator
- North-south deployment
- Augmented
- East-west LSO
- Virtual machine
- MPLS
- Bespoke
- DNS
- Platform services
- OS
- AWS Direct Connect
- Kubernetes
- Elastic
- Paas
- Iaas
- Saas
- Infrastructure
- Applications.2
- Single source of truth
- Consistency
- Dynamics
- File management
- Synchronized
- Easy access
- End-to-End View
- User-definable
- Intuitive UI
- Full support
- Single sign-on
- Advanced access control
- Simplify Processes
- Sophisticated services
- Level up your service quality
- Graphical user interface
- Access information
- Plug ’n play creation
- Inspect
- OTT
- Encoder
- Close Caption Encoder

##### Renamed icons

In the DataMiner stencils, the following existing icons have been renamed:

| Old name            | New name          |
|---------------------|-------------------|
| no Access           | No Access.2       |
| dmcube_cubemobile   | DM Cube Mobile    |
| IP alt              | IP.2              |
| Rotate 2            | Rotate            |
| Rotate alt          | Rotate.2          |
| service manager.262 | Service Manager.2 |
| SLA alt             | SLA.2             |
| th                  | Apps              |
| Virtual-Machine     | Virtual Machine   |

##### Capital Case

All icon names are now in capital case.

#### Visual Overview: Support for saving page and card variables \[ID_28434\]

It is now possible to have page variables and card variables saved across sessions.

To do so, place the following prefix before the variable name: *\_\_saved\_*

The variable is then saved in a separate .dat file located in the following folder on the client machine: C:\\Users\\{Username}\\AppData\\Roaming\\Skyline\\DataMiner. When a variable is saved, if a user reopens a card with that variable, the variable will be set to the last saved value.

#### Visual Overview - ChildrenFilter: Using a regular expression to filter by name \[ID_28445\]

In a shape data field of type ChildrenFilter, it is now possible to filter by service name, view name or child element name.

To do so, in the ChildrenFilter data field of the child shape, add “Name=” following by a regular expression:

| Shape data field | Value           |
|------------------|-----------------|
| ChildrenFilter   | Name=\<myRegex> |

If you add this type of filter to a template shape, only objects of which the name matches the regular expression will use that particular template shape.

#### Service & Resource Management - Services app: Visualization and configuration of the node interfaces of service profile definitions and service profile instances \[ID_28508\]

In the *Profiles* tab of the *Services* app, it is now also possible to visualize and fully configure the node interfaces of service profile definitions and service profile instances.

Also, it is now possible to select a profile instance for every node interface of a service profile instance node.

#### System Center - Agents: BPA test management \[ID_28516\]

In the *Agents* section of *System Center*, the new *BPA* tab now allows you to view and run the Best Practices Analyzer (BPA) tests available on your DataMiner System.

This growing list of tests will allow you to check hardware and software requirements in order to guarantee an optimal and smooth DataMiner operation.

### DMS Reports & Dashboards

#### Dashboards app - Bar chart component: Enhancements \[ID_28461\]

A number of enhancements have been made to the bar chart component.

##### Two additional chart layouts

There are now four chart layouts to choose from:

| Chart layout                                         | Description                                                                |
|------------------------------------------------------|----------------------------------------------------------------------------|
| Absolute                                             | Shows the absolute value.                                                  |
| Relative per category (new)                          | Shows the value as a percentage of all the variables within that category. |
| Relative per variable (previously called “Relative”) | Shows the value as a percentage of the variable across all categories.     |
| Relative total                                       | Shows the value as a percentage of the total sum of all values.            |

##### Stacked bars

If you select the *Stack bars* option, the bars in the graph will be displayed one on top of the other instead of one next to the other.

> [!NOTE]
> This option will be especially useful in combination with the “Relative per category” chart layout.

##### Additional highlighting possibilities

Apart from highlighting all bars belonging to a specific variable, you can now also highlight a single category by hovering over the label of the category or by hovering over empty space in a stacked bar chart.

### DMS Automation

#### Interactive Automation scripts will now take into account timeouts set in the engine.Timeout property of the executed script \[ID_28405\]

From now on, interactive Automation scripts will also take into account any timeout set in the engine.Timeout property of the executed script

#### Interactive Automation scripts: Lazy loading of tree view items \[ID_28528\]

It is now possible to configure that a tree view item in interactive Automation scripts will only be loaded when a user expands the item by clicking the arrow in front of it.

To activate this so-called lazy loading for a particular tree view item, set its SupportsLazy-Loading property to true. An arrow will appear in front of the tree view item (even if it does not have any child items).

> [!NOTE]
> If you want to check whether a tree view node is collapsed or expanded, use the GetExpanded method of the UIResults class.

### DMS Mobile apps

#### Jobs app: Jobs will now be retrieved via web sockets \[ID_28285\]

In the Jobs app, jobs will now be retrieved via web sockets.

As a result, all updates and deletions will now be received automatically.

#### Throttling will now be enabled on all SLNet connections \[ID_28442\]

All web applications\* will now connect to SLNet with the “AllowMessageThrottling” attribute.

*\*Monitoring, new Dashboards, legacy Dashboards, Maps, Web Services APIs, etc.*

### DMS Service & Resource Management

#### Triggering an Automation script to reconfigure running bookings after a ProfileInstance was changed \[ID_28186\]

It is now possible to have an Automation script triggered when a profile instance update affects running bookings. That script can then reconfigure the bookings.

##### Configuring the script

The script to reconfigure the bookings can be set on the ProfileManagerConfiguration. See the example below.

```csharp
var profileHelper = new ProfileHelper(engine.SendSLNetMessages);
var config = profileHelper.Config.Get();
config.UpdateBookingConfigByReferenceScript = "scriptname";
profileHelper.Config.Set(config);
```

This configuration is automatically synchronized among the agents in the DMS. Updating the configuration does not require a DMA restart to take effect.

The script will be triggered using a new OnSrmBookingsUpdatedByReference entrypoint. See the example below.

- ProfileInstanceId will contain the ID of the ProfileInstance that was updated.

- reservationIds will contain the IDs of all running ReservationInstances that were reconfigured because of the update.

  This list does not have to include the IDs of the ReservationInstances that, although they did not reference the ProfileInstance, had usages quarantined because the update caused an overbooking.

  ```csharp
  public class Script
  {
      [AutomationEntryPoint(AutomationEntryPointType.Types.OnSrmBookingsUpdatedByReference)]
      public void RunEntryPoint(Engine engine, Guid profileInstanceId, List<Guid> reservationIds)
      {
      }
  }
  ```

##### New errors

The UpdateAndApply call for a ProfileInstance can now return a number of additional errors.

When calling UpdateAndApply without forcing quarantine (i.e. with forceQuarantine set to false):

- If no instances need to be quarantined, the update will be applied and the following warning will be returned:

  - A warning of type ProfileInstanceChangeCausedBookingReconfiguration, listing the running reservations that were reconfigured because of the update.

- If instances need to be quarantined, the update will not proceed and the following errors will be returned:

  - An error with reason ReservationsMustMovedToQuarantine, listing the reservations that need to be quarantined as well as the usages.
  - An error with reason ReservationsMustBeReconfigured, listing the bookings that will be affected by the ProfileInstance update.

When calling UpdateAndApply and forcing quarantine (i.e. with forceQuarantine set to true), the update will proceed and the following TraceData will be returned:

- A warning of type ReservationInstancesMovedToQuarantine, listing the reservations and the usages that were quarantined.
- A warning of type ProfileInstanceChangeCausedBookingReconfiguration, listing the reservations that were reconfigured because of the update.

##### New RequiredProfileInstanceReconfiguration property

A new RequiredProfileInstanceReconfiguration property has been added to the ServiceReservationInstance class. When a ProfileInstance has been updated, all ReservationInstances referencing this ProfileInstance in any of their usages will have this property set to true. This way, solutions can keep track of the bookings that have been reconfigured in case the custom script was interrupted.

See the following example on how to filter on this property:

```csharp
var rmHelper = new ResourceManagerHelper();
rmHelper.RequestResponseEvent += (sender, args) => args.responseMessage = engine.SendSLNetSingleResponseMessage(args.requestMessage);
var filter = ServiceReservationInstanceExposers.RequiredProfileReconfiguration.Equal(true);
var instancesThatRequiredReconfig = rmHelper.GetReservationInstances(filter);
```

##### Additional information

- If triggering the configured script fails, a notice will be generated with the following text:

  ```txt
  Failed to run script to reconfigure bookings after updating ProfileInstance because an exception occurred. See SLProfileManager.txt logging for more details.
  ```

- When the UpdateBookingConfigByReferenceScript is not configured (i.e. when the setting is empty or null in the profile manager configuration):

  - No attempt will be made to trigger a script.
  - The RequiredProfileInstanceReconfiguration property will not be set to true on the instances.
  - No additional error or warning will be returned in the calls.

### DMS tools

#### SLNetClientTest: Viewing and deleting trend data patterns \[ID_28098\]

In the SLNetClientTest program, it is now possible to view and delete trend data patterns.

> [!WARNING]
> The DataMiner SLNetClientTest program is an advanced system administration tool that should be used with extreme care (C:\\Skyline DataMiner\\Files\\SLNetClientTest.exe).

## Changes

### Enhancements

#### DataMiner Cube - Alarm templates: Hysteresis values can now be lower than the polling interval \[ID_28207\]

In the Alarm template editor, it is possible to configure hysteresis values for a monitored parameter. From now on, you will be able to enter hysteresis values that are lower than the polling interval of the parameter or the protocol. This will allow hysteresis to also work correctly for protocols in which SNMP traps are defined.

> [!NOTE]
>
> - In general, it remains recommended to specify hysteresis values that are greater than the polling interval of the parameter. Only for parameters updated via SNMP traps or smart-serial parameters should you consider specifying hysteresis intervals that are lower than the polling interval.
> - Up to now, when you entered a hysteresis value that was lower than the polling interval, an error message would be displayed. From now on, a warning message will be displayed instead.

#### DataMiner Cube - Data Display: Enhanced performance when loading the default page after opening a card \[ID_28255\]

Due to a number of enhancements, overall performance has increased when loading the default page after opening a card.

#### DataMiner Maps: Style attribute of TableSourceInfo tags will now by default be set 'markers' \[ID_28313\]

In a map configuration file, the style attribute of a TableSourceInfo tag can be set to either “markers” or “lines”.

From now on, if this attribute is not specified, it will by default be set to “markers”.

#### DataMiner Cube - Protocols & Templates: Signed enhanced service protocols \[ID_28338\]

In the Protocol & Templates app, it is now also possible to have signed enhanced service protocols.

#### DataMiner Cube - Services app & Visual Overview: Enhanced performance when refreshing service definition diagrams \[ID_28340\]

Due to a number of enhancements, overall performance has increased when refreshing service definition diagrams, both in the Services app and in Service Manager components embedded in visual overviews.

#### Dashboards app - Pivot table component: Indices from different tables in different elements with identical names will be displayed on the same row \[ID_28344\]

Up to now, when a pivot table component displayed indices on the same row, they were mapped in memory based on primary key. So, when you had indices from different tables in different elements with identical names, those indices would be displayed on different rows because, in memory, they had different primary keys.

From now on, the display keys will also be taken into account. As a result, indices from different tables in different elements with identical names will be displayed on the same row, regardless of their primary key.

> [!NOTE]
> For this to work, the pivot table should show the indices as rows and all other types as columns. Otherwise, the indices will be split up in separate levels.

#### DataMiner Cube - Service & Resource Management: Enhanced error messages \[ID_28351\]

Up to now, when you left a name empty, one of two different error messages could appear. These messages have now been consolidated into one single error message.

#### Log level of '!! No link found for ...' errors has been lowered from 0 to 5 \[ID_28353\]

Up to now, when SLElement tried to resolve a relation path in an element, it would throw a “!! No link found for ...” error with log level 0 and log type “Error”. As this error occurs very frequently in case of virtual functions, its log level has now been lowered from 0 to 5.

#### SLAnalytics: All log entries will now by default have log level 0 \[ID_28361\]

All log entries generated by SLAnalytics will now by default have log level 0.

#### Jobs app: No longer possible to start a job data migration when no Elasticsearch database is available \[ID_28385\]

From now on, it will no longer be possible to start a job data migration when no Elasticsearch database is available.

#### FileInfoManager: Enhancements & debug UI in SLNetClientTest tool \[ID_28409\]

A number of enhancements have been made to FileInfoManager.

Also, under *Advanced \> Apps \> FileInfo*, the DataMiner SLNetClientTest tool now offers a read-only UI to debug FileInfoManager.

> [!WARNING]
> The DataMiner SLNetClientTest program is an advanced system administration tool that should be used with extreme care (C:\\Skyline DataMiner\\Files\\SLNetClientTest.exe).

#### SLReset will now reset the backup agent to its factory settings when it is taken out of a  Failover configuration \[ID_28456\]

When the two DMAs in a Failover configuration were taken out of that configuration, up to now, the backup agent had to be cleaned manually. From now on, SLReset will automatically reset the backup agent to its factory settings.

#### Dashboards app: Service definition component has a new icon \[ID_28501\]

The service definition component has a new icon.

#### Enhanced performance when updating parameters \[ID_28515\]

Due to a number of enhancements, overall performance has increased when updating parameters.

#### Restricting the size of the C:\\Skyline DataMiner\\Logging\\WatchDog\\Notifications folder \[ID_28548\]

When a run-time error occurs, SLWatchdog stores a number of files in the C:\\Skyline DataMiner\\Logging\\WatchDog\\Notifications folder of the DataMiner Agent.

From now on, additional measures will be taken to prevent this folder from taking too much disk space. For example, files compressed into an errors.zip file will now be removed after the zip file has been created. Also, the oldest files will now be deleted each time the total size of the folder exceeds 1 GB.

#### Enhancements made to BPA test infrastructure and the StandaloneBpaExecutor tool \[ID_28556\]

A number of enhancements have been made to the BPA test infrastructure and the StandaloneBpaExecutor tool.

#### New icons added to Icons.xml file \[ID_28566\]

A set of 6 new colored LED icons has been added to the file Icons.xml, located in the folder C:\\Skyline DataMiner\\Protocols.

#### TypeForwarding added to make sure libraries compiled against DataMiner versions prior to 10.1.1 will continue working \[ID_28675\]

In DMS version 10.1.1, a number of extension methods were moved from the QActionHelperBaseClasses library to the SLManagedScripting library.

Typeforwarding has now been added to make sure that libraries that still expect the types to be present in the QActionHelperBaseClasses DLL file will continue working when compiled against DataMiner versions prior to 10.1.1.

### Fixes

#### Failover: An agent taken out of a Failover setup would incorrectly keep on trying to connect to the database of the other agent \[ID_27803\]

When a DataMiner Agent was taken out of a Failover setup, in some cases, it would incorrectly keep on trying to connect to the database of the other agent.

#### Problem with SLASPConnection when a timeout occurred while retrieving an alarm history \[ID_28163\]

When a timeout occurred while retrieving an alarm history, in some cases, an error could occur in the SLASPConnection process.

#### SLAnalytics: Problem at startup \[ID_28258\]

In some cases, an error could occur in SLAnalytics at startup.

#### Secondary element ports would handle headers and trailers incorrectly \[ID_28271\]

When more than one connection were defined, in some cases, the secondary connections would not be able to handle headers and trailers correctly. This was due to the fact that the port cookie of the main port was incorrectly being used for all header and trailer information.

#### Problem when trying to activate data offload to a database \[ID_28276\]

When, in the *Database* section of *System Center*, you clicked the *Offload* tab, selected the *Activate this database* option, and then clicked *Save*, in some cases, this change would not be saved.

#### Dashboards app: Trend statistics components would not show any content when part of a PDF report \[ID_28286\]

In a PDF report, in some cases, trend statistics components would not show any content.

#### DataMiner Cube - Automation app: A change to a dashboard configuration in an Automation script would not cause the Save button to be activated \[ID_28287\]

When a dashboard configuration in an email action of an Automation script was changed, in some cases, the script would incorrectly not be considered changed. As a result, the user would not be able to save the changes.

#### Service & Resource Management: Exported protocol would show incorrect parameters after a new function file had been activated \[ID_28290\]

When a new function file was activated, which updated parameters for a particular function, in some cases, the exported protocol would incorrectly show the old parameters.

#### Problem when offloading data to SLDataGateway \[ID_28318\]

When offloading data to SLDataGateway, in some cases, a CPU leak could occur.

#### Interactive Automation scripts: Equals signs not accepted in UI block values \[ID_28324\]

In some cases, equals signs (“=”) could not be used in UI block values.

#### SLWatchDog was not able to detect problems occurring in SLSNMPAgent \[ID_28330\]

In some cases, the SLWatchdog process would not be able to detect problems occurring in the SLSNMPAgent process. From now on, SLSNMPAgent will register with SLWatchdog as soon as it is set to running.

#### DataMiner Maps: Problem when the autofit attribute of an OpenStreetMap layer was set to true \[ID_28336\]

When the autofit attribute of an OpenStreetMap layer was set to true, in some cases, automatic marker fitting could fail when the markers were loaded before the map view was fully visible.

#### DataMiner Cube: Clicking the alarm banner did not have any effect \[ID_28339\]

When, in DataMiner Cube, you logged out and then in again, clicking the alarm banner in the header would not have any effect.

The banner shows the number of new alarms, the color of the most severe among them, and service impact information. When you click the banner, the Alarm Console tab should open and the new alarm(s) should be selected.

#### DataMiner Cube: Problem when logging on to an SRM system \[ID_28342\]

When you logged on to a system running Service & Resource Management (SRM), in some cases, an error could occur in DataMiner Cube.

#### Problem when performing a DataMiner upgrade \[ID_28350\]

In some cases, an error could occur during a DataMiner upgrade.

#### Dashboards app: Problem with Stack components option when generating a PDF report \[ID_28362\]

In the Automation, Correlation and Scheduler modules, you can generate a report based on a dashboard from the new Dashboards app. Up to now, in some cases, it would not be possible to generate such a report when the *Stack components* option had not been selected.

#### Offload database configuration: Problem with OldStyle=true option \[ID_28366\]

In the Db.xml file, you can add the OldStyle=true option to the offload database configuration to revert to the behavior of older DataMiner versions, so that average trend information is offloaded regardless of whether parameter values have changed.

However, in some cases, when this option was specified, unchanged values of type string or discreet would incorrectly not be written to the offload database.

#### Dashboards app: Problem with line chart components when the theme did not contain any theme colors \[ID_28372\]

In some cases, an error could occur in the line chart component when the theme of that component did not contain any theme colors.

#### Child shapes automatically generated for elements in a service would be sorted incorrectly \[ID_28386\]

When child shapes automatically generated for elements in a service were sorted by name using a ChildrenSort data field, in some cases, the shapes would be sorted incorrectly.

From now on, child shapes sorted by name will be sorted by alias or, if no alias is found, by element name.

#### Dashboards app - GQI: Problem with the query builder \[ID_28415\]

In the Dashboards app, in some cases, errors could occur when building a query.

#### Router Control app: Problem with user permissions \[ID_28422\]

In some cases, users who had only been granted the *Modules \> Router Control \> UI Available* permission would incorrectly not be able to access the Router Control app.

#### Dashboards app: Error when deleting components \[ID_28426\]

When a dashboard component was deleted, in some cases, the following error could occur:

```txt
Cannot read property 'Data' of undefined'.
```

#### SLWatchDog would not log error messages when it failed to generate or clear alarm events \[ID_28435\]

When SLWatchDog was creating or clearing alarm events (e.g. alarm events reporting run-time errors), no error messages would be logged when a request to create or clear an alarm event failed. From now on, those errors will be logged in SLWatchDog2.txt.

#### Problem during DataMiner startup when all nodes of an Elasticsearch database were down \[ID_28443\]

When an Elasticsearch database was configured in the Db.xml file, in some cases, an error could occur during DataMiner startup when all node of that database were down.

#### Dashboards app: Problem with charts in PDF reports \[ID_28449\]

In PDF reports, the alarm top component would not show the grid lines and the generic bar charts would not position properly due to a CSS issue.

#### DataMiner Cube - Profiles app: Pending change notification would not be removed after modifying a converter for a profile parameter link \[ID_28451\]

When, in the Profiles app, you modified a converter for a profile parameter link, in some cases, the “pending change” notification at the bottom of the app would not be removed.

#### DataMiner Cube - Visual Overview: Booking shape timers would not get updated every second when the shape was being displayed \[ID_28453\]

In a booking shape, timers can show remaining time, elapsed time, etc. However, in some cases, those timers would not get updated every second when the shape was being displayed.

#### DataMiner Cube - Failover: Default SLAnalytics settings would incorrectly always be used \[ID_28471\]

On a Failover system, SLAnalytics would incorrectly always use the default DataMiner Cube SLAnalytics settings. Any updates to those settings would be disregarded.

#### SLWatchDog would incorrectly try to restart NATS before it was started \[ID_28474\]

In some rare cases, SLWatchdog would incorrectly try to restart the NATS service before it was started.

#### Deserialization exceptions during file offload \[ID_28481\]

During a file offload, in some cases, a large number of deserialization exceptions could be written to the SLDBConnection.txt log file.

#### Dashboards app - Line chart component: Parameter header not displayed when only one parameter was selected \[ID_28486\]

When, in a line chart component, only one parameter was selected, in some cases, the parameter header would not be displayed.

#### Dashboards app - Line chart component: Problem with 'Expand legend initially' option \[ID_28487\]

When you refreshed a line chart component that had the “Expand legend initially” option selected, in some cases, the legend would incorrectly not be expanded.

#### DataMiner Cube - Service templates: Templated service incorrectly placed in the root view instead of the view containing the original view \[ID_28491\]

When you duplicated a service as a templated service, in some cases, the newly created templated service would incorrectly be placed in the root view instead of the view containing the original service.

#### Dashboards app: Some components would not be displayed when embedded \[ID_28492\]

In some cases, dashboards components would not be displayed when embedded in e.g. Visual Overview.

#### DataMiner Cube - Query Executor: Problem when a Cassandra database returned a collection object \[ID_28499\]

When, in DataMiner Cube’s Query Executor, you launched a query that retrieved data from a Cassandra database, in some cases, an incorrect result would be displayed when the query returned a collection object.

#### Dashboards app: Problem when trying to select a folder after manually removing it from the Location box of the Create dashboard window \[ID_28533\]

When, in the *Create dashboard* window, you selected a folder and then removed it manually from the *Location* box, in some cases, it would no longer be possible to select the same folder in the folder tree.

#### Dashboards app: Error messages would incorrectly be displayed multiple times \[ID_28544\]

When an error had been thrown in the Dashboards app, in some cases, multiple instances of the same error message would be displayed. From now on, each error message will only be displayed once.

#### DataMiner Cube - System Center: No offload files generated when offloading to a file instead of to a database \[ID_28568\]

When, in the *Database* section of *System Center*, you opted to offload database data to a file instead of a database, in some cases, no offload files would be generated.

#### Dashboards app: Problem when sharing a dashboard located in a folder \[ID_28610\]

When you wanted to share a dashboard using the Live Sharing Service, in some cases, a parsing error could occur when that dashboard was located in a dashboard folder.

#### DataMiner Cube - Profiles app: Production versions not listed in protocol list when adding a profile parameter \[ID_28687\]

When, in the Profiles app, you added a profile parameter, in some cases, the list of available protocols would incorrectly not list production versions.
