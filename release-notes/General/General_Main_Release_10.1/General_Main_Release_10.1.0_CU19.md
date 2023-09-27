---
uid: General_Main_Release_10.1.0_CU19
---

# General Main Release 10.1.0 CU19

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### DataMiner Taskbar Utility: Enhanced installation of app packages [ID_33969]

<!-- MR 10.1.0 [CU19]/10.2.0 [CU7] - FR 10.2.10 -->

Using the DataMiner Taskbar Utility, it is now possible to install all possible types of app packages. To install an app, you can either double-click the .dmapp file or right-click the Taskbar Utility icon, click *Upgrade* and select the app from the list.

Also, the *SLAppPackageInstaller.txt* log file will now keep track of all actions performed and issues encountered during the installation of an app.

> [!NOTE]
> After you have launched an upgrade, the upgrade process displayed in DataMiner Taskbar Utility may lag behind and DataMiner Taskbar Utility may use a considerable amount of memory. This is a known issue. See [Taskbar Utility performance issue while Agents are being upgraded](xref:KI_Taskbar_Utility_performance_issue_while_agents_are_being_upgraded).
>
> To prevent his issue, stay on the upgrade summary tab until the upgrade has finished, and then close DataMiner Taskbar Utility to have the memory cleared. Note also that this issue is related to the Taskbar Utility only and does not affect the upgrade process.

#### Enhanced performance when an SNMP element using multi-threaded timers is polling multiple sources simultaneously [ID_34143]

<!-- MR 10.1.0 [CU19]/10.2.0 [CU7] - FR 10.2.10 -->

Because of a number of enhancements, overall performance has increased when an SNMP element using multi-threaded timers is polling multiple sources simultaneously.

#### Cassandra: Alarms indicating that the cluster is down will no longer be repeated as long as the status of the cluster remains the same [ID_34209]

<!-- MR 10.1.0 [CU19]/10.2.0 [CU7] - FR 10.2.10 -->

When the Cassandra database was down, up to now, the alarms indicating that the cluster is not in a healthy state would be repeated every 40 seconds. From now on, those alarms will no longer be repeated as long as the status of the cluster remains the same.

#### Enhanced logging of issues occurring when parsing a compliance cache file entry [ID_34212]

<!-- MR 10.0.0 [CU22]/10.1.0 [CU19]/10.2.0 [CU7] - FR 10.2.10 -->

When an issue occurred when parsing a compliance cache file entry, up to now, a log entry of type "error" would be added to the SLDataMiner.txt log file.

From now on, when an issue occurs when parsing a compliance cache file entry, the following log entry of type "info" will be added to the SLDataMiner.txt log file instead:

```txt
Warning: <function> is unable to parse compliance cache file entry at line <line number>. <line content>
```

#### SLProtocol: Enhanced performance when reading element data [ID_34241]

<!-- MR 10.1.0 [CU19]/10.2.0 [CU7] - FR 10.2.10 -->

Because of a number of enhancements, overall performance of SLProtocol has increased when reading element data.

#### DataMiner Upgrade: Obsolete 'SNMP Simulation Generator' files removed from upgrade packages [ID_34250]

<!-- MR 10.1.0 [CU19]/10.2.0 [CU7] - FR 10.2.10 -->

All files related to the obsolete *SNMP Simulation Generator* tool have been removed from the DataMiner upgrade packages. This tool was replaced by the *QA Device Simulator* tool.

> [!NOTE]
> When you run an upgrade package on a system that contains this obsolete tool, it will automatically be removed.

#### Enhanced performance when starting up elements on systems using a MySQL or Microsoft SQL Server database [ID_34265]

<!-- MR 10.1.0 [CU19]/10.2.0 [CU7] - FR 10.2.10 -->

Because of a number of enhancements, overall performance has increased when starting up elements on systems using a MySQL or Microsoft SQL Server database, especially elements containing large amounts of data.

#### Newtonsoft.Json DLL updated to version 13.0.1 [ID_34558]

<!-- MR 10.1.0 [CU19]/10.2.0 [CU7] - FR 10.2.10 -->

Due to a high-severity vulnerability, the Newtonsoft.Json DLL file located in the `C:\Skyline DataMiner\ProtocolScripts` folder has been updated to version 13.0.1.

For more information on the vulnerability, see [Improper Handling of Exceptional Conditions in Newtonsoft.Json](https://github.com/advisories/GHSA-5crp-9r3c-p9vr).

### Fixes

#### DataMiner Cube - Alarm Console: Problem when clearing alarm groups [ID_33550]

<!-- MR 10.1.0 [CU19]/10.2.0 [CU7] - FR TBD -->

Alarm groups would not get cleared automatically when the *AutoClear* option was set to false.

Also, in some cases, after clearing an alarm group, a clearable version of that alarm group would incorrectly remain visible in the Alarm Console, even when the *AutoClear* option was set to true.

#### Problem with SLAnalytics [ID_33850]

<!-- MR 10.1.0 [CU19]/10.2.0 [CU7] - FR 10.2.9 -->

In some cases, a problem could occur with the SLAnalytics process, causing the process to restart. This happened when the alarm repository was retrieved while the connection was being dropped.

#### Service & Resource Management: Files in C:\Skyline DataMiner\ResourceManager would not be locked properly when being read or updated during a midnight synchronization [ID_34104]

<!-- MR 10.1.0 [CU19]/10.2.0 [CU7] - FR 10.2.10 -->

Up to now, the files stored in the `C:\Skyline DataMiner\ResourceManager` folder would not be locked properly when being read or updated during a midnight synchronization. File locking has now been improved.

#### Visual Overview: SurveyorSearchText variable continued to show cleared search input [ID_34114]

<!-- MR 10.1.0 [CU19]/10.2.0 [CU7] - FR 10.2.9 -->

When the text in the Cube advanced search box was selected with Ctrl+A and then deleted, it could occur that the advanced search input was not cleared correctly, so that it continued to be shown by the *SurveyorSearchText* variable in Visual Overview.

#### SLNet could throw an OutOfMemoryException due to a memory leak [ID_34126]

<!-- MR 10.1.0 [CU19]/10.2.0 [CU7] - FR 10.2.10 -->

In some cases, SLNet could throw an OutOfMemoryException due to a memory leak.

#### Visual Overview: Connection highlight based on connection property not updated automatically [ID_34139]

<!-- MR 10.1.0 [CU19]/10.2.0 [CU7] - FR 10.2.9 -->

When a connection in Visual Overview was highlighted based on a connection property, and the connection property changed, it could occur that the highlight style was not automatically applied to the connection line, but only after the user triggered a redraw, for example by clicking the highlight.

#### DataMiner Cube - Alarm Console: Alarms would incorrectly be grouped when the 'Automatically group according to arrangement' was not selected [ID_34153]

<!-- MR 10.1.0 [CU19]/10.2.0 [CU7] - FR 10.2.10 -->

When, in the hamburger button in the top-left corner of the Alarm Console, the *Automatically group according to arrangement* setting was not selected, upon reconnecting DataMiner Cube, the alarms would incorrectly be grouped anyway.

#### Scheduled alarm templates would incorrectly not be updated when the system time changed [ID_34154]

<!-- MR 10.1.0 [CU19]/10.2.0 [CU7] - FR 10.2.10 -->

When the system time changed because of e.g. a clock resynchronization or a switch to or from daylight-saving time, up to now, the start time and end time of scheduled alarm templates would incorrectly not get updated.

#### Web apps: Long text strings without spaces displayed in read-only boxes were clipped instead of wrapped [ID_34193]

<!-- MR 10.1.0 [CU19]/10.2.0 [CU7] - FR 10.2.10 -->

In web apps (e.g. Jobs), long text strings without spaces displayed in read-only boxes would be clipped. From now on, those strings will be wrapped so that all text is visible.

#### Failover: Certain correlation rules would no longer work after a Failover switch [ID_34204]

<!-- MR 10.1.0 [CU19]/10.2.0 [CU7] - FR 10.2.10 -->

After a Failover switch, in some cases, certain correlation rules would no longer work.

#### DataMiner Cube - Services app: No services would be loaded the first time you opened the Services app [ID_34211]

<!-- MR 10.1.0 [CU19]/10.2.0 [CU7] - FR 10.2.10 -->

When you opened the *Services* app for the first time after opening DataMiner Cube, in some cases, no services would be loaded. The services would only be loaded when you closed the *Services* app and opened it again.

#### Web apps: App would incorrectly log in again after the user had logged out [ID_34227]

<!-- MR 10.1.0 [CU19]/10.2.0 [CU7] - FR 10.2.10 -->

After a user had logged out of a web app, in some cases, that app would incorrectly continue to send out network requests and try to automatically log itself in again.

#### Run-time error in SLProtocol when a group was launched while a poll group with option 'PartialSNMP' was waiting for incoming SNMP data [ID_34233]

<!-- MR 10.1.0 [CU19]/10.2.0 [CU7] - FR 10.2.10 -->

When, on one thread, a group other than a poll group was launched while, on another thread, a poll group with option "partialSNMP" was waiting for incoming SNMP data, in some cases, a run-time error could occur in SLProtocol.

#### Problem with SLProtocol when performing a 'replace data' action [ID_34255]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU19]/10.2.0 [CU7] - Feature Release Version 10.2.10 -->

In some cases, an error could occur in SLProtocol when performing a 'replace data' action that had to replace multiple bytes.

#### Dashboards app - Time range feed: Delete icons of custom quick pick buttons would incorrectly be displayed on top of the time range feed overlay [ID_34278]

<!-- MR 10.1.0 [CU19]/10.2.0 [CU7] - FR 10.2.10 -->

In some cases, the delete icons of custom quick pick buttons would incorrectly be displayed on top of the time range feed overlay.

#### Problem with SLElement when multiple foreign keys were being resolved [ID_34294]

<!-- MR 10.1.0 [CU19]/10.2.0 [CU7] - FR 10.2.10 -->

In some rare cases, an error could occur in SLElement when multiple foreign keys were being resolved.

#### Microsoft SQL Server: Query with offset, limit and where clause would return an incorrect result set [ID_34413]

<!-- MR 10.1.0 [CU19]/10.2.0 [CU7] - FR 10.2.10 [CU0] -->

When, on a system with a Microsoft SQL Server database, a query with an offset, a limit and a where clause was executed, the where clause would incorrectly be dropped. As a result, an incorrect result set would be returned.

Example of a query with an offset, a limit and a where clause:

``` SQL
select * from elementdata_162 where ieid = 5 limit 10,10
```
