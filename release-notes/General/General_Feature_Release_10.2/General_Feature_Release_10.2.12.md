---
uid: General_Feature_Release_10.2.12
---

# General Feature Release 10.2.12 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.2.12](xref:Cube_Feature_Release_10.2.12).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Failover: SLDataMiner will no longer be able to reclaim the virtual IP address when the agent goes offline [ID_34458]

<!-- MR 10.2.0 [CU9] - FR 10.2.12 -->

When, in the *DMS.xml* file, the *bruteForceToOffline* option is specified in the `<Failover>` element, SLDataMiner will not be notified when the agent's state goes from online to offline. Up to now, this could lead to SLDataMiner reclaiming the virtual IP address as it was not aware of any state change. Both agents would then incorrectly have the same virtual IP address.

From now on, when the *bruteForceToOffline* option is specified in the *DMS.xml* file, SLDataMiner will be asked to set the agent's state to offline and to not reclaim the virtual IP address before it has been released.

#### Preventing multiple SLScripting processes from simultaneously compiling the same DLL [ID_34532]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

On systems with multiple SLScripting processes, in some cases, these processes could incorrectly compile the same DLL at the same time. As a result, elements would then throw `Compilation failed` errors and would not execute their QActions.

Now, an inter-process lock has been added to make sure only one thread and process can build a given DLL.

Moreover, when a QAction is being compiled, other elements will wait for 5 minutes. They will then throw an exception and an element restart will be required. This timeout will make sure that, if something unexpectedly would go wrong, there is still a chance to recover from the situation without having to restart DataMiner.

#### SLElement: Enhanced alarm locking [ID_34561]

<!-- MR 10.3.0 - FR 10.2.12 -->

Alarm locking in the SLElement process has been enhanced.

#### Web Services API: Enhanced methods [ID_34557]

<!-- MR 10.2.0 [CU9] - FR 10.2.12 -->

The following methods used to add attachments to bookings, jobs and tickets have now been replaced by newer, more secure methods:

| Old method           | New method             |
|----------------------|------------------------|
| AddBookingAttachment | AddBookingAttachmentV2 |
| AddJobAttachment     | AddJobAttachmentV2     |
| AddTicketAttachment  | addTicketAttachmentV2  |

Also, the *ContinueAutomationScript* method now has an additional `info` parameter that can be used to provide more information about the variables passed in the `values` parameter (e.g. information to help resolve the file paths).

#### SLLogCollector now also collects network information [ID_34582]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

SLLogCollector packages will now also include the following additional files containing network information:

| File | Contents |
|------|----------|
| Logs\Network Information\ipconfig.exe _all.txt | The output of an `ipconfig /all` command. |
| Logs\Network Information\route.exe print.txt   | The output of a `route print` command.    |

### Fixes

#### Problem with SLDataMiner when editing an element [ID_34329]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

In some rare cases, an error could occur in SLDataMiner when you edited an element.

#### Standalone DVE parameter partially included in an service would incorrectly not affect service state severity [ID_34493]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

When a parameter of a DVE element exported as a standalone parameter was partially included in a service, in some cases, the service state could be incorrect.

#### Web apps - Visual Overview: Not possible to execute parameter set actions [ID_34496]

<!-- MR 10.2.0 [CU9] - FR 10.2.12 -->

In Visio pages displayed in web apps, it would not be possible to execute parameter set actions.

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

#### Problem with SLElement when rows were deleted from a table with an open subscription [ID_34578]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

In some rare cases, an error could occur in SLElement when rows were deleted from a table with an open subscription.

#### DataMiner Maps: Loading screen would incorrectly stay visible after the map had been loaded [ID_34587]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

When DataMiner Maps v1 was used with Google Maps as provider, in some cases, the *Loading Google Maps...* screen would incorrectly stay visible after the map had been loaded.

#### Problem when recording a GQI query [ID_34608]

<!-- MR 10.2.0 [CU9] - FR 10.2.12 -->

GQI recording is a debugging feature that allows you to save GQI communication and replay it in a lab environment.

When you had enabled this feature, in some rare cases, an error could occur when a GQI query was stored in memory while being executed.
