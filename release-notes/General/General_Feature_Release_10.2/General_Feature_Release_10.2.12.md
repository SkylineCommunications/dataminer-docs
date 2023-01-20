---
uid: General_Feature_Release_10.2.12
---

# General Feature Release 10.2.12

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.2.12](xref:Cube_Feature_Release_10.2.12).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

#### Failover: Decommissioning a Failover setup while the server hosting the offline Agent is unavailable [ID_33827]

<!-- MR 10.2.0 [CU9] - FR 10.2.12 -->

It is now possible to decommission a Failover setup while the server hosting the offline Agent is unavailable.

> [!NOTE]
> When you try to decommission a Failover setup while the offline agent is missing, in Cube's *Failover Config* window, a warning will be displayed.

## Other features

#### Dashboards app: Parameter feeds that list EPM parameters now allow items to be preselected [ID_34554] [ID_34588]

<!-- MR 10.3.0 - FR 10.2.12 -->

When an EPM feed is used to feed EPM identifiers to a parameter feed, it is now possible to configure filters that will preselect certain items in the parameter feed.

#### Failover: A reverse proxy will now be used to re-route HTTP traffic from the offline Agent to the online Agent [ID_34606]

<!-- MR 10.2.0 [CU9] - FR 10.2.12 -->

In a Failover setup, a reverse proxy will now be hosted in IIS in order to re-route HTTP traffic from the offline Agent to the online Agent. After a switch has occurred, the proxy will be disabled in the online Agent and enabled on the offline Agent.

This feature requires the Application Request Routing (ARR) module to be installed on IIS. When you upgrade to version 10.2.12 / 10.2.0 [CU9], it will automatically be installed if it has not yet been installed earlier.

> [!NOTE]
> If you manually uninstall ARR, it will not be reinstalled automatically during the next upgrade. In order to force the upgrade process to reinstall it, remove the ARR entry from the `C:\Skyline DataMiner\Upgrades\UpgradeActions\ExecutableEvents.xml` file.

#### Dashboards app: Items selected in a parameter feed listing EPM parameters will now be saved in the URL of the dashboard [ID_34622]

<!-- MR 10.3.0 - FR 10.2.12 -->

The parameters and indices selected in a parameter feed listing EPM parameters will now be saved in the URL of the dashboard.

As a result, the same items will automatically be selected again after you refresh the page.

#### Dashboards app: Parameter indices selected in a parameter feed listing EPM parameters can now be fed to other components [ID_34629]

<!-- MR 10.3.0 - FR 10.2.12 -->

After selecting column parameter indices in a parameter feed listing EPM parameters, you can now feed those selected indices to other components.

#### Service & Resource Management: Check for duplicate function names when creating/editing resources [ID_34648]

<!-- MR 10.2.0 [CU9] - FR 10.2.12 -->

When you create or edit a resource, from now on, a check will be performed to determine whether the function instance name is already being used for another resource within the same main element. If the function instance name already exists, you will not be able to save the resource and a *DuplicateFunctionName* error will be added to the *SLFunctionManager.txt* log file. In that error, you will find the ID and the name of the existing resource with that same function instance name.

An *InitializeFunctionResourceFailed* error will also be added to the *SLResourceManager.txt* log file.

#### Dashboards app: Parameter feeds listing EPM parameters now allow parameter grouping [ID_34705]

<!-- MR 10.3.0 - FR 10.2.12 -->

It is now possible to group parameters in a parameter feed that lists EPM parameters.

## Changes

### Enhancements

#### Security enhancements [ID_33520] [ID_34723]

A number of security enhancements have been made.

#### Dashboards app / Low-Code Apps - Service definition component: Enhancements made with regard to function nodes displaying the number of Process Automation tokens in queue or in progress [ID_33888]

<!-- MR 10.3.0 - FR 10.2.12 -->
<!-- Not added to MR 10.3.0 -->

When a Process Automation definition is added to the Service definition component, all function nodes will display the number of tokens currently in queue or in progress. The algorithm behind this feature has now been enhanced.

Also, due to a filter issue, in some cases, nodes could display an incorrect number of tokens.

#### SLLogCollector now also retrieves information from Elasticsearch [ID_34213]

<!-- MR 10.2.0 [CU9] - FR 10.2.12 -->

On systems with an Elasticsearch database, SLLogCollector will now also retrieve information that can help debug issues from that database.

#### Cassandra Cluster: Default replication strategy when migrating to Cassandra Cluster has been changed to 'NetworkTopologyStrategy' [ID_34417]

<!-- MR 10.2.0 [CU9] - FR 10.2.12 -->

When migrating to Cassandra Cluster or when setting up a Cassandra Cluster configuration from scratch, the default replication strategy will now be *NetworkTopologyStrategy*.

The replication strategy *SimpleStrategy* will be used when installing a new DataMiner Agent with a single Cassandra node.

#### GQI: Enhanced performance when retrieving table data [ID_34441]

<!-- MR 10.3.0 - FR 10.2.12 -->

Because of a number of enhancements, overall performance has increased when retrieving table data by means of a GQI query.

#### Failover: SLDataMiner will no longer be able to reclaim the virtual IP address when the agent goes offline [ID_34458]

<!-- MR 10.2.0 [CU9] - FR 10.2.12 -->

When, in the *DMS.xml* file, the *bruteForceToOffline* option is specified in the `<Failover>` element, SLDataMiner will not be notified when the agent's state goes from online to offline. Up to now, this could lead to SLDataMiner reclaiming the virtual IP address as it was not aware of any state change. Both agents would then incorrectly have the same virtual IP address.

From now on, when the *bruteForceToOffline* option is specified in the *DMS.xml* file, SLDataMiner will be asked to set the agent's state to offline and to not reclaim the virtual IP address before it has been released.

#### Dashboards app - Line & area chart: Non-trended parameters will now automatically be removed when the component is linked to a parameter feed [ID_34499]

<!-- MR 10.3.0 - FR 10.2.12 -->

When a parameter feed is linked to a *Line & area chart" component, from now on, non-trended parameters will now automatically be removed from the chart.

#### Dashboards app / Low-Code Apps: Improved multiple sort in the Table component [ID_34526]

<!-- MR 10.3.0 - FR 10.2.12 -->

When, in the Dashboards app or a low-code app, you apply multiple sort orders in a *Table* component, multiple sort operators will now be appended to the GQI query that feeds data to the component. This way sorting is done server-side, which will improve performance.

#### QA Device Simulator renamed to Skyline Device Simulator [ID_34530] [ID_34555]

<!-- MR 10.3.0 - FR 10.2.12 -->

The *QA Device Simulator* tool has been renamed to *Skyline Device Simulator* and now targets Microsoft .NET Framework 4.8.

Also, the following command-line parameters have been added:

| Parameters | Function |
|------------|----------|
| `/packetloss <packet loss %>`<br>`/delayms <delay ms>`<br>`/delaypct <delay % of packets>` | Specifying packet loss and packet delay parameters on startup. |
| `/dbmaxvaloid <max nbr of entries per OID>` | Configuring the number of entries loaded in memory per OID when working with database simulations. |

> [!CAUTION]
> This tool is provided "As Is" with no representation or warranty whatsoever. Skyline Communications will not provide any maintenance or support for this tool.

#### Preventing multiple SLScripting processes from simultaneously compiling the same DLL [ID_34532]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

On systems with multiple SLScripting processes, in some cases, these processes could incorrectly compile the same DLL at the same time. As a result, elements would then throw `Compilation failed` errors and would not execute their QActions.

Now, an inter-process lock has been added to make sure only one thread and process can build a given DLL.

Moreover, when a QAction is being compiled, other elements will wait for 5 minutes. They will then throw an exception and an element restart will be required. This timeout will make sure that, if something unexpectedly would go wrong, there is still a chance to recover from the situation without having to restart DataMiner.

#### Dashboards app / Low-Code Apps - Line & area chart: Group label will no longer be displayed when grouping is set to 'All together' [ID_34544]

<!-- MR 10.3.0 - FR 10.2.12 -->

In case a *Line & area chart* component displays trending for multiple parameters, the *Group by* setting allows you to specify how the graphs should be grouped. From now on, group titles will no longer be displayed when you set *Group by* to "All together".

#### SLElement: Enhanced alarm locking [ID_34561]

<!-- MR 10.2.0 [CU12] - FR 10.2.12 -->

Alarm locking in the SLElement process has been enhanced.

#### Web Services API: Enhanced methods [ID_34557]

<!-- MR 10.2.0 [CU9] - FR 10.2.12 -->

The following methods used to add attachments to bookings, jobs and tickets have now been replaced by newer, more secure methods:

| Old method           | New method             |
|----------------------|------------------------|
| AddBookingAttachment | AddBookingAttachmentV2 |
| AddJobAttachment     | AddJobAttachmentV2     |
| AddTicketAttachment  | AddTicketAttachmentV2  |

Also, the *ContinueAutomationScript* method now has an additional `info` parameter that can be used to provide more information about the variables passed in the `values` parameter (e.g. information to help resolve the file paths).

#### Dashboards app / Low-Code Apps: Enhanced performance of selection boxes [ID_34577]

<!-- MR 10.3.0 - FR 10.2.12 -->

Because of a number of enhancements, overall performance has increased when opening selection boxes, especially when they contain a large number of items.

#### SLLogCollector now also collects network information [ID_34582] [ID_34675]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

SLLogCollector packages will now also include the following additional files containing network information:

| File | Contents |
|------|----------|
| Logs\Network Information\ipconfig.exe _all.txt            | The output of an `ipconfig /all` command.           |
| Logs\Network Information\route.exe print.txt              | The output of a `route print` command.              |
| Logs\Network Information\netsh.exe winhttp show proxy.txt | The output of a `netsh winhttp show proxy` command. |

#### Problem when sending an NT_SNMP_GET request containing ':tablev2' and an instance [ID_34604]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

When an *NT_SNMP_GET* request contained a MultipleGetBulk (`:tablev2`) and an instance, the instance would incorrectly be ignored.

#### Dashboards app: Upload size of PDF files will now be validated [ID_34620]

<!-- MR 10.3.0 - FR 10.2.12 -->

When PDF files are uploaded via the WebAPI (e.g. when a PDF report is generated), an error will now be thrown when the batch size exceeds 10 MB or the total file size exceeds 1 GB.

#### Behavioral change points stored in both Cassandra and Elasticsearch [ID_34621]

<!-- MR 10.3.0 - FR 10.2.12 -->

If an Elasticsearch database is available, the behavioral change points detected in trend data by the Behavioral Anomaly Detection feature will now be stored both in the Cassandra database and the Elasticsearch database. Otherwise, they will be stored in Cassandra only like before.

This will support faster and more flexible change point querying via GQI in future releases.

#### Dashboards app / Low-Code Apps - Visual Overview component: Enhancements with regard to WebSocket/polling settings and user access to visual overviews [ID_34624]

<!-- MR 10.3.0 - FR 10.2.12 -->

A number of enhancements have been made to the visual overview component, especially with regard to the WebSocket/polling settings and the algorithm that checks whether users have access to the visual overviews retrieved by the component.

#### Dashboards app: Reports will no longer contain visual replacements [ID_34632]

<!-- MR 10.3.0 - FR 10.2.12 -->

Missing information in dashboards is no longer indicated by means of a visual replacement. In PDF reports they are now replaced by a short message.

#### Dashboards app: Jobs and Dashboards app now support PDF module [ID_34634]

<!-- MR 10.3.0 - FR 10.2.12 -->

The PDF module is now available in the Jobs and Dashboards app. From now on, you can e.g. export dashboards to PDF.

#### HTTP elements will now resend a request after receiving ERROR_WINHTTP_SECURE_FAILURE [ID_34644]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU21]/10.2.0 [CU9] - Feature Release Version 10.2.12 -->

When an HTTP element received an ERROR_WINHTTP_SECURE_FAILURE after sending an HTTP request, up to now, it would go into timeout.

From now on, when an HTTP element receives an ERROR_WINHTTP_SECURE_FAILURE after sending an HTTP request, it will resend the request for a number of times, taking into account the number of retries specified in the element's port settings.

#### Dashboards app: PDF and share button will now be hidden in edit mode [ID_34653]

<!-- MR 10.3.0 - FR 10.2.12 -->

The *PDF* and *Share* option in the Dashboards app are now no longer visible in edit mode. Additionally, you can now pin the *Share dashboards* action in the settings menu of the Dashboards app.

#### Factory reset tool: '-cleanclustereddatabase' option will now only remove the tables, keyspaces and indices defined in db.xml from the existing databases [ID_34672]

<!-- MR 10.2.0 [CU9] - FR 10.2.12 -->

Up to now, the *SLReset.exe* option *-cleanclustereddatabases* would remove all keyspaces and indices from the Cassandra cluster and Elasticsearch databases. From now on, this option will only remove the tables, keyspaces and indices defined in the *DB.xml* file from the databases (clusters as well as single-node Cassandra databases on remote machines).

#### SLLogCollector now has a default log configuration that will be used by the SupportAssistant DxM [ID_34709]

<!-- MR 10.3.0 - FR 10.2.12 -->

The SLLogCollector tool now has a default log configuration that will be used by the SupportAssistant DxM.

#### SLMessageBroker log file entries will now mention the NATS server to which the NATS client is connected [ID_34719]

<!-- MR 10.2.0 [CU9] - FR 10.2.12 -->

When a NATS client had reconnected when DataMiner was running, up to now, the log files would not specify the NATS server that client had reconnected to. From now on, SLMessageBroker log file entries will contain the *connectedUrl* and state information.

Also, extended logging will now be available when an asynchronous request times out.

#### Service & Resource Management: GetResources methods not using filter elements have now been marked as obsolete [ID_34720]

<!-- MR 10.3.0 - FR 10.2.12 -->

In *ResourceManagerHelper* and *IResourceManagerHelper*, the following methods not using filter elements have now been marked as obsolete:

```csharp
IEnumerable<Resource> GetResources(IEnumerable<Resource> filters);
Resource[] GetResources(params Resource[] filters);
```

The following method should now be used instead:

```csharp
Resource[] GetResources(FilterElement<Resource> filter);
```

For example, you can now use the following call to retrieve all resources:

```csharp
var allResources = resourceManagerHelper.GetResources(new TRUEFilterElement<Resource>());
```

### Fixes

#### Problem with SLDataMiner when editing an element [ID_34329]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

In some rare cases, an error could occur in SLDataMiner when you edited an element.

#### Web apps: Problem with email address boxes [ID_34421]

<!-- MR 10.2.0 [CU10] - FR 10.2.12 -->

When you entered an address in an email address box and then selected something else on the page without pressing *ENTER* or *TAB*, the email address box would incorrectly expand and show a list of suggestions.

#### Dashboards app: 'Line & area chart' component would display capacity usage incorrectly when bookings overlapped [ID_34465]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

When, in the Dashboards app, resource capacity was displayed using a *Line & area chart* component, in some cases, capacity usage would incorrectly be doubled when bookings overlapped.

#### Standalone DVE parameter partially included in an service would incorrectly not affect service state severity [ID_34493]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

When a parameter of a DVE element exported as a standalone parameter was partially included in a service, in some cases, the service state could be incorrect.

#### Web apps - Visual Overview: Not possible to execute parameter set actions [ID_34496]

<!-- MR 10.2.0 [CU9] - FR 10.2.12 -->

In Visio pages displayed in web apps, it would not be possible to execute parameter set actions.

#### Elasticsearch: Alarm trees of a cleared alarm could incorrectly be moved to a closed alarm index as one single tree [ID_34502]

<!-- MR 10.2.0 [CU9] - FR 10.2.12 -->

When an alarm is cleared, in Elasticsearch, its entire alarm tree is moved from the active alarm index to a closed alarm index.

In some cases, when there were different alarm trees on different agents (trees sharing the same root alarm ID but each with a different DataMiner ID), all those alarms would incorrectly be moved to one single tree.

#### Monitoring app: Problem when trying to open the web UI of a device [ID_34503]

<!-- MR 10.2.0 [CU9] - FR 10.2.12 -->

When, in the Monitoring app, you tried to open the web UI of a device, a `No parameters available` error would appear.

#### Web apps - Visual Overview: New values would incorrectly be added to listboxes each time those listboxes got updated [ID_34515]

<!-- MR 10.2.0 [CU9] - FR 10.2.12 -->

In Visio pages displayed in web apps, new values would incorrectly be added to listboxes each time those listboxes got updated.

#### Enabling conditional monitoring for a parameter would incorrectly cause iStatus -17 data points to be offloaded even when the trend data of that parameter had been excluded from offloads [ID_34540]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

When, in an alarm template, you enabled conditional monitoring for a parameter, the iStatus -17 data points would incorrectly also be offloaded to the offload database when, in the trend template linked to that parameter, its trend data had been excluded from offloads.

#### Not all data would be cleaned up after deleting elements in bulk on systems with a MySQL or Microsoft SQL Server database [ID_34542]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU21]/10.2.0 [CU9] - Feature Release Version 10.2.12 -->

When, on systems with a MySQL or Microsoft SQL Server database, elements had been deleted in bulk (e.g. via an Automation script), in some cases, real-time trending, average trending, alarms, information events and certain reporter caching tables would incorrectly not be cleaned up.

#### Dashboards app: Parameter order in state components would change randomly and trend graphs would be displayed in an incorrect color [ID_34548]

<!-- MR 10.2.0 [CU9] - FR 10.2.12 -->

In some cases, the order of the parameters in a state component would change randomly.

Also, trend graphs would occasionally be displayed in an incorrect color.

#### Offload limit would not be taken into account when offloading files to a file cache [ID_34564]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

To have files offloaded to a file cache instead of to a database, in the *DB.xml* file, you can add a `<FileCache>` tag like the following.

However, up to now, the file cache offload limit (default: 10 GB) would incorrectly not be taken into account.

```xml
<DataBase active="true" local = "false">
    <FileCache enabled="true">
        <MaxSizeKB>10000</MaxSizeKB>
    </FileCache>
</DataBase>
```

#### Errors would be thrown when SNMP elements were created in bulk [ID_34573]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

When a series of SNMP elements was being created in quick succession, in some cases, SLSNMPManager would incorrectly send an NT_GET_PROTOCOL_INTERFACE request before an element had fully been registered in SLDataMiner. This then resulted in an error message thrown by SLDMS, SLDataMiner and SLSNMPManager, which the latter would log as `GetProtocolInterface failed for ...`.

#### Problem with SLElement when rows were deleted from a table with an open subscription [ID_34578]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

In some rare cases, an error could occur in SLElement when rows were deleted from a table with an open subscription.

#### DataMiner Maps: Loading screen would incorrectly stay visible after the map had been loaded [ID_34587]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

When DataMiner Maps v1 was used with Google Maps as provider, in some cases, the *Loading Google Maps...* screen would incorrectly stay visible after the map had been loaded.

#### DataMiner upgrade: 'File already exists' exception could be thrown when multiple actions took a backup of the same file [ID_34601]

<!-- MR 10.3.0 - FR 10.2.12 -->

When, during a DataMiner upgrade, multiple upgrade actions took a backup of the same file within the same second, in some cases, a `file already exists` exception could be thrown.

#### Problem when recording a GQI query [ID_34608]

<!-- MR 10.2.0 [CU9] - FR 10.2.12 -->

GQI recording is a debugging feature that allows you to save GQI communication and replay it in a lab environment.

When you had enabled this feature, in some rare cases, an error could occur when a GQI query was stored in memory while being executed.

#### Problem with SLDataGateway when importing a DELT element with a large number of Elasticsearch logger table entries [ID_34626]

<!-- MR 10.2.0 [CU9] - FR 10.2.12 -->

When a DELT element with more than 1,000 Elasticsearch logger table entries was being imported, in some cases, SLDataGateway would end up in an endless loop and start using a large amount of virtual memory.

#### Low-Code Apps: 'Read mode' setting of a form would incorrectly not be available when the form only contained DOM instance data [ID_34627]

<!-- MR 10.2.0 [CU9] - FR 10.2.12 -->

When a form only contained DOM instance data, the *Read mode* setting of the form would incorrect not be available.

#### Dashboards app: Problem when creating a PDF preview of a dashboard containing an empty GQI table [ID_34635]

<!-- MR 10.2.0 [CU9] - FR 10.2.12 -->

When a PDF preview was made from a dashboard containing an empty GQI table (e.g. after selecting *Configure* in an email action of an Automation script), in the preview, that table would incorrectly not be empty. Instead, it would contain random cell values.

#### Web apps: Read-only text in input boxes would incorrectly not be displayed in bold type when using Mozilla Firefox [ID_34641]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

When you had opened a DataMiner web app in Mozilla Firefox, read-only text in input boxes would incorrectly not be displayed in bold type.

#### Dashboards app - Line & area chart: No date information would be displayed when hovering over a trend graph while the legend was disabled [ID_34655]

<!-- MR 10.2.0 [CU9] - FR 10.2.12 -->

When you hovered over a trend graph while the legend was disabled, the trend value tooltips would incorrectly not show any date information.

#### Web apps: Problem when creating large PDF files [ID_34663]

<!-- MR 10.2.0 [CU9] - FR 10.2.12 -->

When a large PDF file (e.g. a PDF report) was created in a web app, in some cases, an error could occur.

#### DataMiner installer: Cassandra DevCenter would no longer be extracted [ID_34674]

<!-- MR 10.3.0 - FR 10.2.12 -->

Since Cassandra 3.7 was replaced by Cassandra 3.11 in DataMiner Installer 10.2, DevCenter would incorrectly no longer be extracted. From now on, it will again be extracted and a shortcut to the tool will be automatically created.

Also, if the *JAVA_HOME* environment variable is not defined, it will be set to the Java version that comes with Cassandra.

#### nats-account-server service could silently fail [ID_34698]

<!-- MR 10.2.0 [CU9] - FR 10.2.12 -->

In some cases, the *nats-account-server* service could silently fail. All functionality would stop although the process would keep running.

When that happened, the log file would report the following:

```txt
The NSC store encountered an error, shutting down ...
stopping account server
disconnected from NATS
stopping http server
http server stopped
error closing listener: close tcp [::]:9090: use of closed network connection
http stopped
closed JWT store
```

SLWatchDog will now periodically check the log file and, if it finds the above-mentioned entries:

- the *nats-account-server.exe* process will be terminated,
- the *nssm.exe* service wrapper will log this event in the *Windows Event Viewer*, and
- the *nats-account-server.exe* process will be restarted.

Also, SLNet will now by default limit the number of NAS log files in the same way as it limits the NATS log files: check the files every 15 minutes and keep the 10 most recent files.

#### Mediation protocols: 'Recursion detected in the mediation links tree' error [ID_34736]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU21]/10.2.0 [CU9] - Feature Release Version 10.2.12 -->

When a mediation protocol contained a *Params.Param.Mediation.LinkTo* element that pointed to a protocol that had the same *ElementType* value as the one specified in the *baseFor* attribute of its *Protocol* element, then the following error would be logged in the *SLDataMiner.txt* log file:

```txt
Recursion detected in the mediation links tree
```

As this error was caused by an internal lookup issue that had no effect whatsoever with regard to mediation layer functionality, from now on, it will no longer be logged.

#### Mobile apps: Problem when trying to select an item in a drop-down box [ID_34742]

<!-- MR 10.3.0 - FR 10.2.12 [CU0] -->

In some cases, it would incorrectly not be possible to select an item in a drop-down box when the items were grouped or when their actual value was not identical to the value that was displayed.

#### Skyline Device Simulator: 'no such object' would incorrectly be returned when requesting data from a simulation [ID_34746]

<!-- MR 10.3.0 - FR 10.2.12 -->

When you tried to request data from a simulation that was built with AutoBuildVersion 1.3, in some cases, "no such object" would incorrectly be returned.

> [!CAUTION]
> This tool is provided "As Is" with no representation or warranty whatsoever. Skyline Communications will not provide any maintenance or support for this tool.

#### An error could occur in the hosting process when a connection had been closed [ID_34786]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

When a connection had been closed, in some cases, an error could occur in the hosting process.

#### Certain antivirus software products could incorrectly flag SLSpiHost.exe as malicious [ID_34942]

<!-- MR 10.2.0 [CU9] - FR 10.2.12 [CU0] -->

In some cases, certain antivirus software products could incorrectly flag SLSpiHost.exe as malicious.
