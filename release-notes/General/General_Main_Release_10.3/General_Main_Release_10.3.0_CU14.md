---
uid: General_Main_Release_10.3.0_CU14
---

# General Main Release 10.3.0 CU14 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Security enhancements [ID_37345] [ID_38904]

<!-- RN 37345: MR 10.3.0 [CU14] - FR 10.3.11 -->
<!-- RN 38904: MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

A number of security enhancements have been made.

#### APIGateway now runs on .NET 8 and allows you to enable kernel response buffering [ID_38710]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

APIGateway has been upgraded. It now runs on Microsoft .NET 8.

This service now allows you to enable kernel response buffering, which should improve throughput and responsiveness over high-latency connections. This setting is disabled by default. To enable it, do the following:

1. In the `C:\Program Files\Skyline Communications\DataMiner APIGateway\` folder of the DataMiner Agent, create a JSON file named *appsettings.custom.json*.
1. Open this JSON file, and add the following content:

   ```json
   { "HostingOptions": { "EnableKernelResponseBuffering": true } }
   ```

#### New SLTimeToLive.txt log file containing all changes made to the TTL settings [ID_38851]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

In the `C:\Skyline DataMiner\Logging\SLTimeToLive` folder, you can now find a new *SLTimeToLive.txt* log file, listing all changes made to the TTL settings in Cube's *System Center > System settings > Time to live* page.

> [!NOTE]
> The contents of this folder will not be deleted during either a DataMiner restart or a DataMiner upgrade. However, in the *SLTimeToLive.txt* file, the oldest entries will be removed when the maximum log file size is exceeded.

#### SLLogCollector: Enhancements [ID_38966]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

SLLogCollector now uses Microsoft .NET 4.8.0.

Also, an number of enhancements have been made to improve overall exception handling and to prevent the tool from timing out on servers without internet access.

#### SLLogCollector: Enhancements [ID_38975]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

From now on, SLLogCollector will also log when it was not able to find any DataMiner processes or include memory dumps.

Also, it will no longer attempt to read log files when it was not able to find the `C:\Skyline DataMiner\` folder.

#### Protocols: Enhanced performance when filling an array using the QActionTableRow objects in a QAction [ID_39017]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

Because of a number of enhancements, overall performance has increased when filling an array using the `QActionTableRow` objects in a QAction.

#### Service & Resource Management: Enhanced performance when starting the Resource Manager module [ID_39037]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

Because of a number of enhancements, overall performance has increased when starting the Resource Manager module, especially on systems with a large number of permanent bookings.

#### SLAnalytics: Enhanced performance when processing database operations [ID_39109]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

Because of a number of enhancements, overall performance of SLAnalytics has increased when processing database operations, especially small insert or update operations.

#### SLNet: Enhanced task processing [ID_39131]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

Because of a number of enhancements, overall processing of tasks in SLNet has been optimized.

#### MySql.Data.dll updated to version 8.3.0 [ID_39152]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

The *MySql.Data.dll* file, stored in the `C:\Skyline DataMiner\Files` and `C:\Skyline DataMiner\Files\x64` folders, has been updated from version 6.9.12 to version 8.3.0.

The connection string will now include `allowloadlocalinfile=True` as this required setting needs to be enabled on both the client side and the server side of the database connection.

#### No more DataMiner startup beep [ID_39176]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

The DataMiner startup beep has been removed.

On virtual machines, beep commands are bypassed, and on physical machines, this beep would cause a delay of 1.25 seconds during startup.

### Fixes

#### Databases: Problem when starting a migration from MySQL to Cassandra [ID_37589]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.1 -->

When you started a migrating from a MySQL database to a Cassandra database, an error could occur when the connection to the MySQL database took a long time to get established.

#### Correlation: Alarm buckets would not get cleaned up when alarms were cleared before the end of the time frame specified in the 'Collect events for ... after first event, then evaluate conditions and execute actions' setting [ID_38292]

<!-- MR 10.3.0 [CU14]/10.4.0 [CU2] - FR 10.4.5 -->

Up to now, when alarms were cleared before the end of the time frame specified in the *Collect events for ... after first event, then evaluate conditions and execute actions* correlation rule setting, the alarm buckets would not get cleaned up.

From now on, when a correlation rule is configured to use the *Collect events for ... after first event, then evaluate conditions and execute actions* trigger mechanism, all alarm buckets will be properly cleaned up so that no lingering buckets are left.

#### Automatic incident tracking: Incomplete or empty alarm groups after DataMiner startup [ID_38441]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

After a DataMiner startup, in some cases, certain alarm groups would either be incomplete or empty due to missing remote base alarms.

#### Not possible to delete a service created via an SRM booking when it had been assigned a name that was already being used [ID_38914]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

When a service created via an SRM booking got into an error state because it had been assigned a name that was already being used by another object, it would not be possible to delete it as it would be considered invalid.

#### Service & Resource Management: Problem when the function manager was not able to read the functions.xml file in C:\\Skyline DataMiner\\ServiceManager [ID_38925]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

Up to now, in some cases, a run-time error could occur when the function manager was not able to read the *functions.xml* file in `C:\Skyline DataMiner\ServiceManager`.

From now on, if an error occurs when the function manager was not able to read that file, an entry will be added to the *SLFunctionManager.txt* log file, and if the error occurred because the file was locked by another process, the log entry will include the name of the process.

#### Protocols: Compliancies element would not get parsed correctly when it contained comments [ID_39085]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

Up to now, the `<Compliancies>` element of a *protocol.xml* file would not get parsed correctly when it contains HTML comments.

As a result, DataMiner would fail to open the protocol and create elements with it.

#### Visual Overview: 'Connection could not be fully established' error when viewing visual overviews in a web app [ID_39133]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

When you opened a visual overview in a web app, in some cases, a `Connection could not be fully established` error would appear.

#### No emails could be sent as long as SLASPConnection was not fully initialized [ID_39137]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

Up to now, an error would occur when a DataMiner module (e.g. Automation, Scheduler, etc.) tried to send an email while *SLASPConnection* was still initializing. From now on, all DataMiner modules will be able to send emails, even when *SLASPConnection* is still initializing.

#### SNMP: Timeout time of commands would incorrectly be doubled when using SNMP++ [ID_39164]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

When SNMP++ was being used to communicate with a device, commands would incorrectly have their configured timeout time doubled.

#### Problem with SLProtocol when processing a matrix parameter update [ID_39178]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

In some cases, an error could occur in SLProtocol when processing a matrix parameter update.
