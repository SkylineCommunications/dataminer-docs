---
uid: General_Main_Release_10.2.0_CU12
---

# General Main Release 10.2.0 CU12 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### SLElement: Enhanced alarm locking [ID_34561]

<!-- MR 10.2.0 [CU12] - FR 10.2.12 -->

Alarm locking in the SLElement process has been enhanced.

#### Enhanced parameter locking in SLElement [ID_34688]

<!-- MR 10.2.0 [CU12] - FR 10.3.1 [CU0] -->

In SLElement, a number of enhancements have been made with regard to parameter locking.

#### Security enhancements [ID_34894]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

A number of security enhancements have been made.

#### Elasticsearch: 'Request Entity Too Large (413)' errors will now be prevented when writing data in bulk [ID_34937]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

When data was written to Elasticsearch in bulk, up to now, DataMiner would throw a `Request Entity Too Large (413)` error when the amount of data exceeded the 100 MB limit.

From now on, DataMiner will detect when too much data is being sent in a single request and will split up the data into smaller parts.

#### SLLogCollector: Multiple instances can now be run simultaneously [ID_35204]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

Multiple instances of the SLLogCollector tool can now be run simultaneously.

#### Exporting and importing DELT packages containing element and alarm data is now supported on DataMiner Systems with a clustered database [ID_35213]

<!-- MR 10.2.0 [CU12] - FR 10.3.2 [CU0] -->

From now on, exporting and importing DELT packages containing element and alarm data is also supported on DataMiner Systems with a clustered database.

> [!NOTE]
> Exporting and importing DELT packages containing trend data is not yet supported on DataMiner Systems with a clustered database.

#### DataMiner Cube - Visual Overview: Leading spaces removed from port information fields [ID_35334]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

Leading spaces have been removed from the following port information fields:

- BusAddress
- ElementTimeoutTime
- NrOfRetries
- PollingIP
- SlowPoll
- TimeoutTime

### Fixes

#### DataMiner Taskbar Utility: Problem when stopping DataMiner [ID_34790]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

Up to now, when you right-clicked the *DataMiner Taskbar Utility* system tray icon and selected *Stop DataMiner* while keeping the SHIFT button pressed, the *SLWatchdog* process would incorrectly also be stopped. In a Failover setup, this would prevent the backup agent from acquiring the virtual IP address.

Also, after DataMiner had been stopped, up to now, the *SLXml*, *SLLog* and *SLDataGateway* processes would incorrectly start up again.

#### Problem with SLElement when a trend template was being assigned [ID_34824]

<!-- MR 10.2.0 [CU12] - FR 10.3.1 -->

In some cases, an error could occur in SLElement when a trend template was being assigned.

#### Alarm templates: Parameters exported to DVE child elements could have incorrect alarm limits [ID_34996]

<!-- MR 10.2.0 [CU12] - FR 10.3.2 -->

When a parameter was exported as a standalone parameter to a DVE child element, in some cases, the alarm limits could be incorrect when the type of alarm monitoring was set to either *Relative* or *Absolute*.

Also, LED bar controls would either not display or not update their alarm limits.

#### Problem with SLLog when logging large entries regarding failed Elasticsearch query requests/responses [ID_35037]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

Up to now, an error could occur in SLLog when adding large entries regarding failed Elasticsearch query requests/responses.

#### SLDataGateway would leak memory when offloading average trend data for DVE elements [ID_35167]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

The SLDataGateway process would leak memory when offloading average trend data for DVE elements.

#### Service & Resource Management: Setting a new function file to active would incorrectly not cause the function DVEs of elements using a production version of the protocol to be updated [ID_35178]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

When a new function file was set to active, up to now, the function DVEs of elements using a production version of the protocol in question would incorrectly not be updated.

#### DataMiner Cube - ListView component: Problem with custom property columns and date columns [ID_35218]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

When, in an *ListView* component, you hovered over a cell value in a custom property column or a date column, no tooltip would appear.

Also, the filter box above a custom property column would incorrectly always be empty.

#### DataMiner Cube - Alarm Console: Multiple values in property columns would incorrectly not be separated by any separator [ID_35239]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

If, in the Alarm Console, property columns are added for service or view properties, and an alarm affects more than one service or view, this can result in property columns containing multiple property values.

In the *PropertyConfiguration.xml* file, for each relevant property you can configure a *contentSeparator* tag. The separator specified in that tag will then be used to separate the values of that property.

Up to now, when a *contentSeparator* tag was left empty, the values of the property in question would incorrect not be separated by any separator. From now on, when that tag is empty, the values of the property in question will by default be separated by commas.

#### Problem with CassandraBackup.exe when the configuration file of a general database of type 'Cassandra' had a DBServer element that contained multiple host addresses [ID_35253]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

When, in the configuration file of a general database of type "Cassandra", the `<DBServer>` element contained multiple host addresses, up to now, the *CassandraBackup.exe* tool would parse those host addresses incorrectly and would not take any database backup.

From now on, when the `<DBServer>` element contains multiple host addresses including that of the local database, the *CassandraBackup.exe* tool will take a backup of the local database.

#### SLDataGateway could end up with an excessive number of HealthMonitor.Refresh threads [ID_35286]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

In some cases, the SLDataGateway process could end up with an excessive number of *HealthMonitor.Refresh* threads.

#### DataMiner Cube - ListView component: Column filter boxes incorrectly had autocomplete enabled [ID_35296]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

In a *ListView* component, you can click the filter icon of a particular column and enter a filter in the box below the column header.

Up to now, those column filter boxes incorrectly had *autocomplete* enabled.

#### Dashboards app / Low-Code Apps - Node edge component: Edge overrides would incorrectly no longer be applied [ID_35298]

<!-- MR 10.2.0 [CU12] - FR 10.3.2 -->

When, in the settings of a node edge graph, you had configured edge overrides, these would incorrectly no longer be applied.

#### DataMiner Cube - Visual Overview: Problem after filtering bookings using a custom time range in ListView component or Resource Manager component [ID_35328]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

When, in a ListView component or a Resource Manager component showing a bookings timeline, you had filtered the bookings using a custom time range, performance issues could start to occur after a period of time.

#### DataMiner Cube - Visual Overview: Problem when editing a discrete parameter with a 'Sequence' tag displayed in a lite parameter control [ID_35356]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

When a discrete parameter with a `<Sequence>` tag was displayed in a lite parameter control, its current value would neither be displayed nor selected while being edited.

#### DataMiner Cube - Data Display: Problem with the alarm bubble-up feature in a tree control containing many-to-many relationships [ID_35367]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

When a tree control contained many-to-many relationships, up to now, the alarm bubble-up feature would not work correctly.

#### Cassandra: TTL setting of spectrum trace data would not be applied correctly [ID_35385]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

In a Cassandra database, the "time to live" (TTL) setting of spectrum trace data would not be applied correctly. As a result, this type of data would never be removed.

#### DataMiner Cube - Data Display: Problem with the alarm bubble-up feature in a tree control containing EPM objects [ID_35396]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

When a tree control contained EPM objects, in some cases, the alarm bubble-up feature would not work correctly.

#### Dashboards app & Low-code apps - Line & area chart component: Problems when visualizing resource availability [ID_35408]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

When, in a dashboard or a low-code app, a *Line & area chart* component was used to visualize the capacity usage over time of a resource, it would incorrectly take into account bookings that had been canceled. Also, when two or more bookings ended at the same, it would not show the capacity usage in a correct way, and when there was no booking in the selected time range, it would show an error.

In the latter case, it will now instead show a flat line indicating that the resource is not being used.

#### DataMiner Cube - Spectrum analysis: Presets would not be loaded when opening a spectrum element while connected to a heavily loaded DMA [ID_35421]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

When you opened a spectrum element in a DataMiner Cube that was connected to a heavily loaded DataMiner Agent, the presets would not be loaded.

#### SLDataGateway would not correctly return errors when querying SLA logger tables in a Cassandra Cluster [ID_35440]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

SLDataGateway would not correctly return errors when querying SLA logger tables in a Cassandra Cluster, causing an error to occur in SLProtocol.

#### DataMiner Cube - DCF: Problem when trying to delete a DCF connection in the Properties window of an element [ID_35449]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

When you tried to remove a DCF connection in the *Properties* window of an element, an exception would be thrown and the connection would not be removed when the destination element was stopped or paused.

#### DataMiner Cube - Visual Overview: Problem when re-arranging dynamically positioned shapes [ID_35462]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

When, in a Visio drawing, shapes have been positioned dynamically, you can re-arrange those shapes manually by switching to *Arrange* mode and re-arranging the shapes using drag-and-drop. In some cases, after you had re-arranged a number of shapes, a *NullReferenceException* could be thrown.

#### Automation: 'engine.RunClientProgram' overload with two parameters would incorrectly always be run synchronously [ID_35476]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

An `engine.RunClientProgram` overload with two parameters, of which the second one controls whether the method is run either synchronously or asynchronously, would incorrectly always be run synchronously.

```csharp
RunClientProgram(String applicationPath, bool waitForCompletion)
```
