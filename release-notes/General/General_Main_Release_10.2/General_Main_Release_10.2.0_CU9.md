---
uid: General_Main_Release_10.2.0_CU9
---

# General Main Release 10.2.0 CU9

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Security enhancements [ID_33520]

A number of security enhancements have been made.

#### Failover: Decommissioning a Failover setup while the server hosting the offline Agent is unavailable [ID_33827]

<!-- MR 10.2.0 [CU9] - FR 10.2.12 -->

It is now possible to decommission a Failover setup while the server hosting the offline Agent is unavailable.

> [!NOTE]
> When you try to decommission a Failover setup while the offline Agent is missing, in Cube's *Failover Config* window, a warning will be displayed.

#### SLReset will no longer remove VersionHistory.txt and the HTTPS configuration [ID_34194]

<!-- MR 10.2.0 [CU9] - FR 10.2.10 -->

From now on, the factory reset tool *SLReset.exe* will no longer remove the following items:

- the *VersionHistory.txt* file
- the HTTPS configuration stored in the *MaintenanceSettings.xml* file.

#### SLLogCollector now also retrieves information from Elasticsearch [ID_34213]

<!-- MR 10.2.0 [CU9] - FR 10.2.12 -->

On systems with an Elasticsearch database, SLLogCollector will now also retrieve information that can help debug issues from that database.

#### Cassandra Cluster: Default replication strategy when migrating to Cassandra Cluster has been changed to 'NetworkTopologyStrategy' [ID_34417]

<!-- MR 10.2.0 [CU9] - FR 10.2.12 -->

When migrating to Cassandra Cluster or when setting up a Cassandra Cluster configuration from scratch, the default replication strategy will now be *NetworkTopologyStrategy*.

The replication strategy *SimpleStrategy* will be used when installing a new DataMiner Agent with a single Cassandra node.

#### Visual Overview: New toggle buttons added to Buttons stencil [ID_34426]

<!-- MR 10.2.0 [CU9] - FR 10.2.12 [CU0] -->

The Buttons stencil now contains the following additional buttons:

- *tb-var-l* (button on left side, text on right side, logic based on session variable, configurable session variable scope)
- *tb-var-r* (button on right side, text on left side, logic based on session variable, configurable session variable scope)

Other changes made to the Buttons stencil:

- Buttons *abtn-automation* and *lbtn-automation* have been combined into one button *btn-automation*.
- Button *btn-popup* now has configurable window settings.

#### Failover: SLDataMiner will no longer be able to reclaim the virtual IP address when the agent goes offline [ID_34458]

<!-- MR 10.2.0 [CU9] - FR 10.2.12 -->

When, in the *DMS.xml* file, the *bruteForceToOffline* option is specified in the `<Failover>` element, SLDataMiner will not be notified when the agent's state goes from online to offline. Up to now, this could lead to SLDataMiner reclaiming the virtual IP address as it was not aware of any state change. Both agents would then incorrectly have the same virtual IP address.

From now on, when the *bruteForceToOffline* option is specified in the *DMS.xml* file, SLDataMiner will be asked to set the agent's state to offline and to not reclaim the virtual IP address before it has been released.

#### Preventing multiple SLScripting processes from simultaneously compiling the same DLL [ID_34532]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

On systems with multiple SLScripting processes, in some cases, these processes could incorrectly compile the same DLL at the same time. As a result, elements would then throw `Compilation failed` errors and would not execute their QActions.

Now, an inter-process lock has been added to make sure only one thread and process can build a given DLL.

Moreover, when a QAction is being compiled, other elements will wait for 5 minutes. They will then throw an exception and an element restart will be required. This timeout will make sure that, if something unexpectedly would go wrong, there is still a chance to recover from the situation without having to restart DataMiner.

#### Enhanced performance of the DataMiner startup routine [ID_34545]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR TBD -->

Because of a number of enhancements, overall performance of the DataMiner startup routine has increased.

#### Web Services API: Enhanced methods [ID_34557]

<!-- MR 10.2.0 [CU9] - FR 10.2.12 -->

The following methods used to add attachments to bookings, jobs and tickets have now been replaced by newer, more secure methods:

| Old method           | New method             |
|----------------------|------------------------|
| AddBookingAttachment | AddBookingAttachmentV2 |
| AddJobAttachment     | AddJobAttachmentV2     |
| AddTicketAttachment  | addTicketAttachmentV2  |

Also, the *ContinueAutomationScript* method now has an additional `info` parameter that can be used to provide more information about the variables passed in the `values` parameter (e.g. information to help resolve the file paths).

#### SLLogCollector now also collects network information [ID_34582] [ID_34675]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

SLLogCollector packages will now also include the following additional files containing network information:

| File | Contents |
|------|----------|
| Logs\Network Information\ipconfig.exe _all.txt            | The output of an `ipconfig /all` command.           |
| Logs\Network Information\route.exe print.txt              | The output of a `route print` command.              |
| Logs\Network Information\netsh.exe winhttp show proxy.txt | The output of a `netsh winhttp show proxy` command. |

#### Failover: A reverse proxy will now be used to re-route HTTP traffic from the offline Agent to the online Agent [ID_34606]

<!-- MR 10.2.0 [CU9] - FR 10.2.12 -->

In a Failover setup, a reverse proxy will now be hosted in IIS in order to re-route HTTP traffic from the offline Agent to the online Agent. After a switch has occurred, the proxy will be disabled in the online Agent and enabled on the offline Agent.

This feature requires the Application Request Routing (ARR) module to be installed on IIS. When you upgrade to version 10.2.12 / 10.2.0 [CU9], it will automatically be installed if it has not yet been installed earlier.

> [!NOTE]
> If you manually uninstall ARR, it will not be reinstalled automatically during the next upgrade. In order to force the upgrade process to reinstall it, remove the ARR entry from the `C:\Skyline DataMiner\Upgrades\UpgradeActions\ExecutableEvents.xml` file.

#### HTTP elements will now resend a request after receiving ERROR_WINHTTP_SECURE_FAILURE [ID_34644]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU21]/10.2.0 [CU9] - Feature Release Version 10.2.12 -->

When an HTTP element received an ERROR_WINHTTP_SECURE_FAILURE after sending an HTTP request, up to now, it would go into timeout.

From now on, when an HTTP element receives an ERROR_WINHTTP_SECURE_FAILURE after sending an HTTP request, it will resend the request for a number of times, taking into account the number of retries specified in the element's port settings.

#### Service & Resource Management: Check for duplicate function names when creating/editing resources [ID_34648]

<!-- MR 10.2.0 [CU9] - FR 10.2.12 -->

When you create or edit a resource, from now on, a check will be performed to determine whether the function instance name is already being used for another resource within the same main element. If the function instance name already exists, you will not be able to save the resource and a *DuplicateFunctionName* error will be added to the *SLFunctionManager.txt* log file. In that error, you will find the ID and the name of the existing resource with that same function instance name.

An *InitializeFunctionResourceFailed* error will also be added to the *SLResourceManager.txt* log file.

#### Cassandra: Enhanced querying of trend data [ID_34659]

<!-- Main Release Version 10.1.0 [CU21]/10.2.0 [CU9] - Feature Release Version TBD -->

A number of enhancements have been made with regard to querying trend data against a Cassandra database.

#### Factory reset tool: '-cleanclustereddatabase' option will now only remove the tables, keyspaces and indices defined in db.xml from the existing databases [ID_34672]

<!-- MR 10.2.0 [CU9] - FR 10.2.12 -->

Up to now, the *SLReset.exe* option *-cleanclustereddatabases* would remove all keyspaces and indices from the Cassandra cluster and Elasticsearch databases. From now on, this option will only remove the tables, keyspaces and indices defined in the *DB.xml* file from the databases (clusters as well as single-node Cassandra databases on remote machines).

#### SLMessageBroker log file entries will now mention the NATS server to which the NATS client is connected [ID_34719]

<!-- MR 10.2.0 [CU9] - FR 10.2.12 -->

When a NATS client had reconnected when DataMiner was running, up to now, the log files would not specify the NATS server that client had reconnected to. From now on, SLMessageBroker log file entries will contain the *connectedUrl* and state information.

Also, extended logging will now be available when an asynchronous request times out.

### Fixes

#### Ticketing app: Problem with ticket domains incorrectly marked as masked [ID_33449]

<!-- MR 10.2.0 [CU9] - FR 10.2.7 -->

If, in the Ticketing app, you tried to edit a ticket of a domain linked to an element, in some cases, that domain would incorrectly be marked as "masked".

#### Problem with SLDataMiner when editing an element [ID_34329]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

In some rare cases, an error could occur in SLDataMiner when you edited an element.

#### Dashboards app: 'Line & area chart' component would display capacity usage incorrectly when bookings overlapped [ID_34465]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

When, in the Dashboards app, resource capacity was displayed using a *Line & area chart* component, in some cases, capacity usage would incorrectly be doubled when bookings overlapped.

#### Web apps: List box items not displayed correctly in embedded visual overviews [ID_34474]

<!-- MR 10.2.0 [CU9] - FR 10.2.11 -->

In an embedded visual overview, in some cases, list box items would not be displayed correctly.

#### DataMiner Cube - Trending: Y axis of trend graph would incorrectly show duplicate values [ID_34492]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

When a trend graph showed a constant value, due to a rounding issue, the Y axis would incorrectly show duplicate values.

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

#### DataMiner Cube - Spectrum Analysis: Problem with measurement point option 'Invert spectrum' [ID_34552]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

When you had selected the *Invert spectrum* option while configuring a measurement point, in some cases, that option would incorrectly not be applied.

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

#### DataMiner Cube - Data Display: Parameter controls displaying a write parameter of type DateTime would incorrectly not take into account the format of the current culture as defined in the regional settings of DataMiner Cube [ID_34575]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

A parameter control displaying a write parameter of type DateTime would incorrectly not take into account the format of the current culture as defined in the regional settings of DataMiner Cube. As a result, the read and write parameters would be formatted differently.

#### Problem with SLElement when rows were deleted from a table with an open subscription [ID_34578]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

In some rare cases, an error could occur in SLElement when rows were deleted from a table with an open subscription.

#### DataMiner Maps: Loading screen would incorrectly stay visible after the map had been loaded [ID_34587]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

When DataMiner Maps v1 was used with Google Maps as provider, in some cases, the *Loading Google Maps...* screen would incorrectly stay visible after the map had been loaded.

#### Trending: Problem when duplicating table parameters with different values [ID_34591]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

When duplicating a table parameter in the legend of a trend graph, the graph would not be displayed if the duplicate parameter did not have the same index value as the original parameter.

#### Trending: Table would be cleared of all data after refreshing [ID_34592]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

When triggering a refresh of a trend chart, the data and axes on the line chart would disappear for a short period of time without first verifying whether there was any new incoming data. If the incoming data equals null, the graph should not be redrawn and should remain visible.

#### Problem when sending an NT_SNMP_GET request containing ':tablev2' and an instance [ID_34604]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

When an *NT_SNMP_GET* request contained a MultipleGetBulk (`:tablev2`) and an instance, the instance would incorrectly be ignored.

#### Problem when recording a GQI query [ID_34608]

<!-- MR 10.2.0 [CU9] - FR 10.2.12 -->

GQI recording is a debugging feature that allows you to save GQI communication and replay it in a lab environment.

When you had enabled this feature, in some rare cases, an error could occur when a GQI query was stored in memory while being executed.

#### Visual Overview: Dynamically generated shapes sorted by custom property value would not be displayed in the correct order [ID_34617]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

When a large number of shapes generated based on child items in a view were sorted by a custom property value, in some rare cases, those shapes would not be displayed in the correct order.

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

#### DataMiner Cube - Alarm Console: Problem with visibility of correlation alarms in filtered alarm tabs [ID_34728]

<!-- MR 10.2.0 [CU9] - FR 10.2.12 -->

When a filtered alarm tab contained a correlation alarm, in some cases, this correlation alarm would incorrectly not disappear when it did no longer match the filter, especially when that filter was configured to hide alarms of type "Comment added", "Acknowledged" or "Released".

Also, when a correlation alarm did not match the filter, only the base alarms would be shown, but when the type of one of those base alarms changed to "Comment added", "Acknowledged" or "Released", that base alarm would incorrectly not disappear.

#### Mediation protocols: 'Recursion detected in the mediation links tree' error [ID_34736]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU21]/10.2.0 [CU9] - Feature Release Version 10.2.12 -->

When a mediation protocol contained a *Params.Param.Mediation.LinkTo* element that pointed to a protocol that had the same *ElementType* value as the one specified in the *baseFor* attribute of its *Protocol* element, then the following error would be logged in the *SLDataMiner.txt* log file:

```txt
Recursion detected in the mediation links tree
```

As this error was caused by an internal lookup issue that had no effect whatsoever with regard to mediation layer functionality, from now on, it will no longer be logged.

#### DataMiner Cube - Trending: Double-clicking a suggestion or alarm event created by SLAnalytics would open a trend graph showing "no data" [ID_34751]

<!-- MR 10.2.0 [CU9] - FR 10.2.12 -->

When, in the Alarm Console, you double-clicked a suggestion or alarm event created by SLAnalytics for a table parameter with advanced naming, in some cases, the trend graph would incorrectly show "no data".

#### An error could occur in the hosting process when a connection had been closed [ID_34786]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

When a connection had been closed, in some cases, an error could occur in the hosting process.

#### Certain antivirus software products could incorrectly flag SLSpiHost.exe as malicious [ID_34942]

<!-- MR 10.2.0 [CU9] - FR 10.2.12 [CU0] -->

In some cases, certain antivirus software products could incorrectly flag SLSpiHost.exe as malicious.
