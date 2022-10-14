---
uid: General_Main_Release_10.2.0_CU9
---

# General Main Release 10.2.0 CU9 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

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

#### Dashboards app: 'Line & area chart' component would display capacity usage incorrectly when bookings overlapped [ID_34465]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

When, in the Dashboards app, resource capacity was displayed using a *Line & area chart* component, in some cases, capacity usage would incorrectly be doubled when bookings overlapped.

#### Web apps: List box items not displayed correctly in embedded visual overviews [ID_34474]

<!-- MR 10.2.0 [CU9] - FR 10.2.11 -->

In an embedded visual overview, in some cases, list box items would not be displayed correctly.

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

#### Problem when recording a GQI query [ID_34608]

<!-- MR 10.2.0 [CU9] - FR 10.2.12 -->

GQI recording is a debugging feature that allows you to save GQI communication and replay it in a lab environment.

When you had enabled this feature, in some rare cases, an error could occur when a GQI query was stored in memory while being executed.

#### Visual Overview: Dynamically generated shapes sorted by custom property value would not be displayed in the correct order [ID_34617]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

When a large number of shapes generated based on child items in a view were sorted by a custom property value, in some rare cases, those shapes would not be displayed in the correct order.

#### Dashboards app: Problem when creating a PDF preview of a dashboard containing an empty GQI table [ID_34635]

<!-- MR 10.2.0 [CU9] - FR 10.2.12 -->

When a PDF preview was made from a dashboard containing an empty GQI table (e.g. after selecting *Configure* in an email action of an Automation script), in the preview, that table would incorrectly not be empty. Instead, it would contain random cell values.

#### Web apps: Read-only text in input boxes would incorrectly not be displayed in bold type when using Mozilla Firefox [ID_34641]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

When you had opened a DataMiner web app in Mozilla Firefox, read-only text in input boxes would incorrectly not be displayed in bold type.

#### Web apps: Problem when creating large PDF files [ID_34663]

<!-- MR 10.2.0 [CU9] - FR 10.2.12 -->

When a large PDF file (e.g. a PDF report) was created in a web app, in some cases, an error could occur.
