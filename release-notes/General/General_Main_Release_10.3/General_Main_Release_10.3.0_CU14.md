---
uid: General_Main_Release_10.3.0_CU14
---

# General Main Release 10.3.0 CU14

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Main Release 10.3.0 CU14](xref:Cube_Main_Release_10.3.0_CU14).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.3.0 CU14](xref:Web_apps_Main_Release_10.3.0_CU14).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Security enhancements [ID 37345] [ID 38904]

<!-- RN 37345: MR 10.3.0 [CU14] - FR 10.3.11 -->
<!-- RN 38904: MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

A number of security enhancements have been made.

#### APIGateway now runs on .NET 8 and allows you to enable kernel response buffering [ID 38710]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

APIGateway has been upgraded. It now runs on Microsoft .NET 8.

This service now allows you to enable kernel response buffering, which should improve throughput and responsiveness over high-latency connections. This setting is disabled by default. To enable it, do the following:

1. In the `C:\Program Files\Skyline Communications\DataMiner APIGateway\` folder of the DataMiner Agent, create a JSON file named *appsettings.custom.json*.
1. Open this JSON file, and add the following content:

   ```json
   { "HostingOptions": { "EnableKernelResponseBuffering": true } }
   ```

#### New SLTimeToLive.txt log file containing all changes made to the TTL settings [ID 38851]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

In the `C:\Skyline DataMiner\Logging\SLTimeToLive` folder, you can now find a new *SLTimeToLive.txt* log file, listing all changes made to the TTL settings in Cube's *System Center > System settings > Time to live* page.

> [!NOTE]
> The contents of this folder will not be deleted during either a DataMiner restart or a DataMiner upgrade. However, in the *SLTimeToLive.txt* file, the oldest entries will be removed when the maximum log file size is exceeded.

#### SLLogCollector: Enhancements [ID 38966]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

SLLogCollector now uses Microsoft .NET 4.8.0.

Also, an number of enhancements have been made to improve overall exception handling and to prevent the tool from timing out on servers without internet access.

#### SLLogCollector: Enhancements [ID 38975]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

From now on, SLLogCollector will also log when it was not able to find any DataMiner processes or include memory dumps.

Also, it will no longer attempt to read log files when it was not able to find the `C:\Skyline DataMiner\` folder.

#### Protocols: Enhanced performance when filling an array using the QActionTableRow objects in a QAction [ID 39017]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

Because of a number of enhancements, overall performance has increased when filling an array using the `QActionTableRow` objects in a QAction.

#### Service & Resource Management: Enhanced performance when starting the Resource Manager module [ID 39037]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

Because of a number of enhancements, overall performance has increased when starting the Resource Manager module, especially on systems with a large number of permanent bookings.

#### SLAnalytics: Enhanced performance when processing database operations [ID 39109]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

Because of a number of enhancements, overall performance of SLAnalytics has increased when processing database operations, especially small insert or update operations.

#### SLNet: Enhanced task processing [ID 39131]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

Because of a number of enhancements, overall processing of tasks in SLNet has been optimized.

#### MySql.Data.dll updated to version 8.3.0 [ID 39152]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

The *MySql.Data.dll* file, stored in the `C:\Skyline DataMiner\Files` and `C:\Skyline DataMiner\Files\x64` folders, has been updated from version 6.9.12 to version 8.3.0.

The connection string will now include `allowloadlocalinfile=True` as this required setting needs to be enabled on both the client side and the server side of the database connection.

#### No more DataMiner startup beep [ID 39176]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

The DataMiner startup beep has been removed.

On virtual machines, beep commands are bypassed, and on physical machines, this beep would cause a delay of 1.25 seconds during startup.

#### OpenSearch: Enhanced performance when fetching alarm distribution data during DataMiner startup [ID 39177]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

Because of a number of enhancements, on systems using an OpenSearch database, overall performance has increased when fetching alarm distribution data during DataMiner startup.

#### Enhanced performance when executing an NT_SNMP_RAW_SET notify type on multiple sources simultaneously [ID 39213]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

Because of a number of enhancements, overall performance has increased when executing an `NT_SNMP_RAW_SET` notify type on multiple sources simultaneously.

#### GQI: Maximum number of concurrent queries has been increased from 20 to 100 [ID 39293]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

The maximum number of concurrent GQI queries has now been increased from 20 to 100.

### Fixes

#### Databases: Problem when starting a migration from MySQL to Cassandra [ID 37589]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.1 -->

When you started a migrating from a MySQL database to a Cassandra database, an error could occur when the connection to the MySQL database took a long time to get established.

#### Correlation: Alarm buckets would not get cleaned up when alarms were cleared before the end of the time frame specified in the 'Collect events for ... after first event, then evaluate conditions and execute actions' setting [ID 38292]

<!-- MR 10.3.0 [CU14]/10.4.0 [CU2] - FR 10.4.5 -->

Up to now, when alarms were cleared before the end of the time frame specified in the *Collect events for ... after first event, then evaluate conditions and execute actions* correlation rule setting, the alarm buckets would not get cleaned up.

From now on, when a correlation rule is configured to use the *Collect events for ... after first event, then evaluate conditions and execute actions* trigger mechanism, all alarm buckets will be properly cleaned up so that no lingering buckets are left.

#### DataMiner Cube: 'Search for alarms' would list alarms with timestamps according to the local time zone of the client computer [ID 38899]

<!-- MR 10.3.0 [CU14]/10.4.0 [CU2] - FR 10.4.4 -->

Up to now, when you opened a new alarm tab, and did a search using the *Search for alarms* box, the alarms matching the search criterion would incorrectly show timestamps according to the local time zone of the client computer.

From now on, when you use the *Search of alarms* box, the alarms matching the search criterion will show timestamps according to the server time, i.e. the local time zone of the DataMiner Agent to which the Cube client is connected.

#### Not possible to delete a service created via an SRM booking when it had been assigned a name that was already being used [ID 38914]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

When a service created via an SRM booking got into an error state because it had been assigned a name that was already being used by another object, it would not be possible to delete it as it would be considered invalid.

#### Service & Resource Management: Problem when the function manager was not able to read the functions.xml file in C:\\Skyline DataMiner\\ServiceManager [ID 38925]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

Up to now, in some cases, a runtime error could occur when the function manager was not able to read the *functions.xml* file in `C:\Skyline DataMiner\ServiceManager`.

From now on, if an error occurs when the function manager was not able to read that file, an entry will be added to the *SLFunctionManager.txt* log file, and if the error occurred because the file was locked by another process, the log entry will include the name of the process.

#### Protocols: Compliancies element would not get parsed correctly when it contained comments [ID 39085]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

Up to now, the `<Compliancies>` element of a *protocol.xml* file would not get parsed correctly when it contains HTML comments.

As a result, DataMiner would fail to open the protocol and create elements with it.

#### Visual Overview: 'Connection could not be fully established' error when viewing visual overviews in a web app [ID 39133]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

When you opened a visual overview in a web app, in some cases, a `Connection could not be fully established` error would appear.

#### No emails could be sent as long as SLASPConnection was not fully initialized [ID 39137]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

Up to now, an error would occur when a DataMiner module (e.g. Automation, Scheduler, etc.) tried to send an email while *SLASPConnection* was still initializing. From now on, all DataMiner modules will be able to send emails, even when *SLASPConnection* is still initializing.

#### SNMP: Timeout time of commands would incorrectly be doubled when using SNMP++ [ID 39164]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

When SNMP++ was being used to communicate with a device, commands would incorrectly have their configured timeout time doubled.

#### Problem with SLProtocol when processing a matrix parameter update [ID 39178]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

In some cases, an error could occur in SLProtocol when processing a matrix parameter update.

#### The 'Communication Info' table would incorrectly not get loaded into the element [ID 39181]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

When, in a connector, you had used the following `<Connections>` syntax, in some cases, the *Communication Info* table would incorrectly not get loaded into the element.

Example of the `<Connections>` syntax that caused the *Communication Info* table to not get loaded into the element:

```xml
<Connections>
   <Connection id="0" name="IPDRData">
      <SmartSerial>
      ...
      </SmartSerial>
   </Connection>
</Connections>
```
