---
uid: General_Main_Release_10.1.0_CU21
---

# General Main Release 10.1.0 CU21

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Security enhancements [ID_33520]

A number of security enhancements have been made.

#### Preventing multiple SLScripting processes from simultaneously compiling the same DLL [ID_34532]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

On systems with multiple SLScripting processes, in some cases, these processes could incorrectly compile the same DLL at the same time. As a result, elements would then throw `Compilation failed` errors and would not execute their QActions.

Now, an inter-process lock has been added to make sure only one thread and process can build a given DLL.

Moreover, when a QAction is being compiled, other elements will wait for 5 minutes. They will then throw an exception and an element restart will be required. This timeout will make sure that, if something unexpectedly would go wrong, there is still a chance to recover from the situation without having to restart DataMiner.

#### Enhanced performance of the DataMiner startup routine [ID_34545]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR TBD -->

Because of a number of enhancements, overall performance of the DataMiner startup routine has increased.

#### SLLogCollector now also collects network information [ID_34582] [ID_34675]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

SLLogCollector packages will now also include the following additional files containing network information:

| File | Contents |
|------|----------|
| Logs\Network Information\ipconfig.exe _all.txt            | The output of an `ipconfig /all` command.           |
| Logs\Network Information\route.exe print.txt              | The output of a `route print` command.              |
| Logs\Network Information\netsh.exe winhttp show proxy.txt | The output of a `netsh winhttp show proxy` command. |

#### HTTP elements will now resend a request after receiving ERROR_WINHTTP_SECURE_FAILURE [ID_34644]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU21]/10.2.0 [CU9] - Feature Release Version 10.2.12 -->

When an HTTP element received an ERROR_WINHTTP_SECURE_FAILURE after sending an HTTP request, up to now, it would go into timeout.

From now on, when an HTTP element receives an ERROR_WINHTTP_SECURE_FAILURE after sending an HTTP request, it will resend the request for a number of times, taking into account the number of retries specified in the element's port settings.

#### Cassandra: Enhanced querying of trend data [ID_34659]

<!-- Main Release Version 10.1.0 [CU21]/10.2.0 [CU9] - Feature Release Version TBD -->

A number of enhancements have been made with regard to querying trend data against a Cassandra database.

### Fixes

#### Problem with SLDataMiner when editing an element [ID_34329]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

In some rare cases, an error could occur in SLDataMiner when you edited an element.

#### Dashboards app: 'Line & area chart' component would display capacity usage incorrectly when bookings overlapped [ID_34465]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

When, in the Dashboards app, resource capacity was displayed using a *Line & area chart* component, in some cases, capacity usage would incorrectly be doubled when bookings overlapped.

#### DataMiner Cube - Trending: Y axis of trend graph would incorrectly show duplicate values [ID_34492]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

When a trend graph showed a constant value, due to a rounding issue, the Y axis would incorrectly show duplicate values.

#### Standalone DVE parameter partially included in an service would incorrectly not affect service state severity [ID_34493]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

When a parameter of a DVE element exported as a standalone parameter was partially included in a service, in some cases, the service state could be incorrect.

#### Monitoring app: Problem when trying to open the web UI of a device [ID_34504]

<!-- MR 10.1.0 [CU21] - FR TBD -->

When, in the Monitoring app, you tried to open the web UI of a device, a `No parameters available` error would appear.

#### Enabling conditional monitoring for a parameter would incorrectly cause iStatus -17 data points to be offloaded even when the trend data of that parameter had been excluded from offloads [ID_34540]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

When, in an alarm template, you enabled conditional monitoring for a parameter, the iStatus -17 data points would incorrectly also be offloaded to the offload database when, in the trend template linked to that parameter, its trend data had been excluded from offloads.

#### Not all data would be cleaned up after deleting elements in bulk on systems with a MySQL or Microsoft SQL Server database [ID_34542]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU21]/10.2.0 [CU9] - Feature Release Version 10.2.12 -->

When, on systems with a MySQL or Microsoft SQL Server database, elements had been deleted in bulk (e.g. via an Automation script), in some cases, real-time trending, average trending, alarms, information events and certain reporter caching tables would incorrectly not be cleaned up.

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

#### Visual Overview: Dynamically generated shapes sorted by custom property value would not be displayed in the correct order [ID_34617]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

When a large number of shapes generated based on child items in a view were sorted by a custom property value, in some rare cases, those shapes would not be displayed in the correct order.

#### Web apps: Read-only text in input boxes would incorrectly not be displayed in bold type when using Mozilla Firefox [ID_34641]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

When you had opened a DataMiner web app in Mozilla Firefox, read-only text in input boxes would incorrectly not be displayed in bold type.

#### Mediation protocols: 'Recursion detected in the mediation links tree' error [ID_34736]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU21]/10.2.0 [CU9] - Feature Release Version 10.2.12 -->

When a mediation protocol contained a *Params.Param.Mediation.LinkTo* element that pointed to a protocol that had the same *ElementType* value as the one specified in the *baseFor* attribute of its *Protocol* element, then the following error would be logged in the *SLDataMiner.txt* log file:

```txt
Recursion detected in the mediation links tree
```

As this error was caused by an internal lookup issue that had no effect whatsoever with regard to mediation layer functionality, from now on, it will no longer be logged.

#### An error could occur in the hosting process when a connection had been closed [ID_34786]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

When a connection had been closed, in some cases, an error could occur in the hosting process.
