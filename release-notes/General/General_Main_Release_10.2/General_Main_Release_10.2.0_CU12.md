---
uid: General_Main_Release_10.2.0_CU12
---

# General Main Release 10.2.0 CU12

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

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

#### SLSNMPAgent log entries will now include the alarm ID [ID_35404]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

When an entry is added to the *SLSNMPAgent.txt* log file, in most cases, that entry will now include the alarm ID.

Example:

- Old format: `Received ACK from SNMP Manager SNMP - LFR`

- New format: `Received ACK from SNMP Manager SNMP - LFR for alarm 239/4270232`

#### Service & Resource Management: Enhanced performance when changing active function files [ID_35424]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

Because of a number of enhancements, overall performance has increased when changing an active function file.

Also, in the Cube UI, users will receive more concise feedback regarding the impact of the change. Up to now, they would receive a list of all items affected by the change. From now on, the list of affected items will only show up to 10 affected items per object type.

#### Automation: Enhanced memory usage [ID_35502]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

Because of a number of enhancements, overall memory usage of the SLAutomation process has improved.

#### Web apps: Enhanced performance when opening a web app [ID_35549]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

Because DataMiner web apps will now be passed to client machines as compressed files, overall performance has increased when opening a web app.

#### DataMiner Cube - Alarm Console: No longer possible to enable the 'Automatic incident tracking' option for a history tab [ID_35556]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

From now on, it is no longer possible to enable the *Automatic incident tracking* option for a history tab.

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

#### Some agents in the cluster would incorrectly remove the run-time hosting agent info they had stored for another agent [ID_35287]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

When run-time connections were being set up between agents or when a midnight sync was being executed, some agents in the DataMiner cluster would incorrectly remove the run-time hosting agent information they had stored for another agent in the same cluster.

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

#### Problem when connecting to Azure AD via a proxy [ID_35382]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

When a DataMiner Agent connected to Azure Active Directory was sealed off from the internet but had access to a proxy, users would not be able to log in due to SLDataMiner failing to use the proxy to connect to Azure Active Directory.

In case a DataMiner Agent has to connect to Azure AD via a proxy, then that proxy has to be configured by means of the following netsh command:

```txt
netsh winhttp set proxy <proxyaddress> <bypasslist>
```

#### Cassandra: TTL setting of spectrum trace data would not be applied correctly [ID_35385]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

In a Cassandra database, the "time to live" (TTL) setting of spectrum trace data would not be applied correctly. As a result, this type of data would never be removed.

#### DataMiner Cube - Data Display: Problem with the alarm bubble-up feature in a tree control containing EPM objects [ID_35396]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

When a tree control contained EPM objects, in some cases, the alarm bubble-up feature would not work correctly.

#### Dashboards app & Low-Code Apps - Line & area chart component: Problems when visualizing resource availability [ID_35408]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

When, in a dashboard or a low-code app, a *Line & area chart* component was used to visualize the capacity usage over time of a resource, it would incorrectly take into account bookings that had been canceled. Also, when two or more bookings ended at the same, it would not show the capacity usage in a correct way, and when there was no booking in the selected time range, it would show an error.

In the latter case, it will now instead show a flat line indicating that the resource is not being used.

#### DataMiner Cube - EPM: Read and write visualization of single-value EPM parameters would incorrectly be displayed both [ID_35416]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

On Data pages, in some cases, the read and write visualization of single-value EPM parameters would incorrectly be displayed both.

From now on, each EPM parameter will only be displayed once. If a write parameter is available, it will be combined with the read parameter.

#### DataMiner Cube - Spectrum analysis: Presets would not be loaded when opening a spectrum element while connected to a heavily loaded DMA [ID_35421]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

When you opened a spectrum element in a DataMiner Cube that was connected to a heavily loaded DataMiner Agent, the presets would not be loaded.

#### SLDataGateway would not correctly return errors when querying SLA logger tables in a Cassandra Cluster [ID_35440]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

SLDataGateway would not correctly return errors when querying SLA logger tables in a Cassandra Cluster, causing an error to occur in SLProtocol.

#### Problem when sending northbound SNMP inform messages in chronological order [ID_35441]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

When northbound SNMP inform messages were being sent in chronological order, an error could occur when sending those messages suddenly stopped.

#### Low-Code Apps: Problem when creating a new draft version [ID_35446]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

When, in a draft version of a low-code app, you opened the version panel and created a new draft, the previous draft version would incorrectly loaded instead of the published version.

#### DataMiner Cube - DCF: Problem when trying to delete a DCF connection in the Properties window of an element [ID_35449]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

When you tried to remove a DCF connection in the *Properties* window of an element, an exception would be thrown and the connection would not be removed when the destination element was stopped or paused.

#### Dashboards app: Time range feeds would trigger components more often than required [ID_35460]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

Time range feeds would trigger components more often than required, causing them to send an excessive number of requests.

#### DataMiner Cube - Visual Overview: Problem when re-arranging dynamically positioned shapes [ID_35462]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

When, in a Visio drawing, shapes have been positioned dynamically, you can re-arrange those shapes manually by switching to *Arrange* mode and re-arranging the shapes using drag-and-drop. In some cases, after you had re-arranged a number of shapes, a *NullReferenceException* could be thrown.

#### DataMiner Cube - Visual Overview: Problem when right-clicking a dynamically positioned shape [ID_35463]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

When, in a Visio drawing, you were re-arranging dynamically positioned shapes, an exception could be thrown when you right-clicked a shape to access its context menu.

#### Automation: 'engine.RunClientProgram' overload with two parameters would incorrectly always be run synchronously [ID_35476]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

An `engine.RunClientProgram` overload with two parameters, of which the second one controls whether the method is run either synchronously or asynchronously, would incorrectly always be run synchronously.

```csharp
RunClientProgram(String applicationPath, bool waitForCompletion)
```

#### DataMiner Cube - Alarm templates: Trending column in baseline editor would no longer show any icons [ID_35488]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

When, while configuring an alarm template, you opened the baseline editor and selected the *Automatically update the baseline values* option, the *Trending* column would no longer show an icon when average trending was disabled for the parameter in question.

#### Business Intelligence: Problem when correcting outages on an SLA with a week-based window [ID_35503]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

When outages on an SLA with a week-based window were corrected, the *History Statistics Table* that started in the first 9 weeks of every year would incorrectly not get updated.

#### DataMiner Cube - Service templates: Open service card would not be updated when the service template was re-applied [ID_35537]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

When you updated an re-applied a service template while a card of a service created based on that particular service template was open, the data shown on the open service card would incorrectly not be updated.

#### DataMiner Cube - Alarm Console: Alarm counters would start to show negative values when you enabled the 'Automatic incident tracking' option of an active alarms tab while a quick filter was applied [ID_35547]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

When you enabled the *Automatic incident tracking* option of an active alarms tab while a quick filter was applied, in some cases, the alarm counters in the footer bar would incorrectly start to show negative values.

#### Problem with SLPort when an element with a serial connection was restarted [ID_35773]

<!-- MR 10.2.0 [CU12]/10.3.0 [CU0] - FR 10.3.3 [CU1] -->

In some cases, an error could occur in SLPort when an element with a serial connection was restarted.
