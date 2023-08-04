---
uid: General_Main_Release_10.2.0_CU7
---

# General Main Release 10.2.0 CU7

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

#### Edge WebView2 now preferred when SAML authentication is used [ID_34162]

<!-- MR 10.2.0 [CU7] - FR 10.2.10 -->

When SAML authentication is used, Cube will now try to use the Edge WebView2 browser engine instead of CefSharp. It will only fall back to using CefSharp if WebView2 is not available.

This will prevent the following possible issues:

- The CefSharp browser engine version used by Cube is not updated frequently and therefore not always trusted by certain SAML identity provider websites, such as Microsoft Azure. This can cause a lengthy authentication procedure, even if the browser cache is enabled.
- The CefSharp browser engine needs to be downloaded from the DMA before a first authentication (on a new device). However, this is currently not supported for HTTPS-only setups.

#### DataMiner Cube: Enhanced editing of profile parameters [ID_34189]

<!-- MR 10.2.0 [CU7] - FR 10.2.10 -->

A number of enhancements have been made to the profile parameter edit boxes, especially with regard to the validation of discrete values.

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

#### DataMiner Cube - Resources app: Enhanced resource pool management [ID_34225]

<!-- MR 10.2.0 [CU7] - FR 10.2.10 -->
<!-- Fix with same ID -->

A number of enhancements have been made with regard to managing resource pools.

- Moving or copying a resource from one pool to another is only supported for existing, valid resources, and you need to have permission to edit resources to do this. It is also not possible to copy a resource to or from the "(uncategorized)" pool, as this pool is reserved for resources that are not in any other pool.

- It is now also possible to remove a resource from a pool.

    > [!NOTE]
    >
    > - Removing a resource from a pool does not delete the resource from the system. It only removes it from the selected pool. If the resource is not present in any other resource pool, it will be moved to the "(uncategorized)" pool.
    > - You can only remove valid, unmodified existing resources that are not in the "(uncategorized)" pool. You also need permission to edit resources to be able to do this.

- The *SelectedPool* session variable of the ReservationManager component will contain the GUIDs of all pools of the selected resource(s), separated by commas.

#### SLProtocol: Enhanced performance when reading element data [ID_34241]

<!-- MR 10.1.0 [CU19]/10.2.0 [CU7] - FR 10.2.10 -->

Because of a number of enhancements, overall performance of SLProtocol has increased when reading element data.

#### Automation: Extra information will now be added to the SLAutomation log file [ID_34248]

<!-- MR 10.2.0 [CU7] - FR 10.2.10 -->

The following information will now also be added to the SLAutomation log file:

- When a script started.
- When a script stopped and how long it took to execute it.

Examples:

```txt
2022/08/26 08:57:45.413|SLAutomation.exe 10.2.2234.873|23088|48272|CAutomation::Execute|INF|0|[FirstName LastName] Started executing script: 'testscript' (ID: 1)
```

```txt
2022/08/26 08:58:59.694|SLAutomation.exe 10.2.2234.873|23088|48272|CAutomation::Execute|INF|0|[FirstName LastName] Finished executing script: 'testscript' (ID: 1). Execution took 01m 14.280s.
```

#### DataMiner Upgrade: Obsolete 'SNMP Simulation Generator' files removed from upgrade packages [ID_34250]

<!-- MR 10.1.0 [CU19]/10.2.0 [CU7] - FR 10.2.10 -->

All files related to the obsolete *SNMP Simulation Generator* tool have been removed from the DataMiner upgrade packages. This tool was replaced by the *QA Device Simulator* tool.

> [!NOTE]
> When you run an upgrade package on a system that contains this obsolete tool, it will automatically be removed.

#### Dashboards app: Configuring themes in user settings now requires dashboard edit permission [ID_34260]

<!-- MR 10.2.0 [CU7] - FR 10.2.10 -->

In the user settings (*user icon > Settings*), from now on, you will only be able to configure themes when you have permission to edit dashboards.

#### Low-Code Apps: Header bar enhancements [ID_34264]

<!-- MR 10.2.0 [CU7] - FR 10.2.10 -->

A number of small enhancements have been made to the header bar of Low-Code Apps:

- Button text now supports both upper case and lower case.
- Buttons no longer have lines between them.

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

#### Jobs app: Corrected start time saved incorrectly [ID_34043]

<!-- MR 10.2.0 [CU7] - FR 10.2.9 -->

When, after receiving a message that it was not possible to save a job because of an invalid start time, you corrected the start time and tried to save the job again, that start time would get saved incorrectly.

#### DataMiner web apps / Visual Overview: Trending not displayed or displayed with incorrect coloring [ID_34101]

<!-- MR 10.2.0 [CU7] - FR 10.2.9 -->

If a visual overview was viewed in the web apps (e.g. the Monitoring or Dashboards app), it could occur that trend graphs in that visual overview were not displayed.
In addition, the coloring of the trend lines could be incorrect. Instead of the colors defined in the themes, the lines were shown in black.

#### Service & Resource Management: Files in C:\Skyline DataMiner\ResourceManager would not be locked properly when being read or updated during a midnight synchronization [ID_34104]

<!-- MR 10.1.0 [CU19]/10.2.0 [CU7] - FR 10.2.10 -->

Up to now, the files stored in the `C:\Skyline DataMiner\ResourceManager` folder would not be locked properly when being read or updated during a midnight synchronization. File locking has now been improved.

#### Visual Overview: SurveyorSearchText variable continued to show cleared search input [ID_34114]

<!-- MR 10.1.0 [CU19]/10.2.0 [CU7] - FR 10.2.9 -->

When the text in the Cube advanced search box was selected with Ctrl+A and then deleted, it could occur that the advanced search input was not cleared correctly, so that it continued to be shown by the *SurveyorSearchText* variable in Visual Overview.

#### Web apps - DOM: Sections inherited from a base behavior definition would not be shown [ID_34125]

<!-- MR 10.2.0 [CU7] - FR 10.2.10 -->

When a DOM definition using an extended behavior definition was assigned to a form component, any sections inherited from the base behavior definition would not be shown.

#### SLNet could throw an OutOfMemoryException due to a memory leak [ID_34126]

<!-- MR 10.1.0 [CU19]/10.2.0 [CU7] - FR 10.2.10 -->

In some cases, SLNet could throw an OutOfMemoryException due to a memory leak.

#### Dashboards app: Incorrect user validation in 'User access' section of 'Settings' tab [ID_34138]

<!-- MR 10.2.0 [CU7] - FR 10.2.10 -->

When editing a dashboard, you can go to *Settings > User access* and specify the users and/or user groups that are allowed to view or edit the dashboard in question. When you did not have permission to change security settings, the users and user groups you entered would not be validated correctly.

#### Visual Overview: Connection highlight based on connection property not updated automatically [ID_34139]

<!-- MR 10.1.0 [CU19]/10.2.0 [CU7] - FR 10.2.9 -->

When a connection in Visual Overview was highlighted based on a connection property, and the connection property changed, it could occur that the highlight style was not automatically applied to the connection line, but only after the user triggered a redraw, for example by clicking the highlight.

#### Cassandra cluster: No trending information shown for parameters of which the value had not changed for 10 days or more [ID_34149]

<!-- MR 10.2.0 [CU7] - FR 10.2.10 -->

On a system with a Cassandra cluster, no trending information would be shown for parameters of which the value had not changed for 10 days or more.

#### Automation: Invalid script changes would incorrectly be saved [ID_34150]

<!-- MR 10.2.0 [CU7] - FR 10.2.10 -->

When, in the *Automation* app, you made an invalid change in a script, closed the app and clicked *Yes* to confirm the changes, up to now, the invalid changes you made would incorrectly be saved. If the invalid change was an invalid script name change, then the script would even be deleted. From now on, it will only be possible to save valid changes.

#### DataMiner Cube - Alarm Console: Alarms would incorrectly be grouped when the 'Automatically group according to arrangement' was not selected [ID_34153]

<!-- MR 10.1.0 [CU19]/10.2.0 [CU7] - FR 10.2.10 -->

When, in the hamburger button in the top-left corner of the Alarm Console, the *Automatically group according to arrangement* setting was not selected, upon reconnecting DataMiner Cube, the alarms would incorrectly be grouped anyway.

#### Scheduled alarm templates would incorrectly not be updated when the system time changed [ID_34154]

<!-- MR 10.1.0 [CU19]/10.2.0 [CU7] - FR 10.2.10 -->

When the system time changed because of e.g. a clock resynchronization or a switch to or from daylight-saving time, up to now, the start time and end time of scheduled alarm templates would incorrectly not get updated.

#### GQI: 'Bookings' data source incorrectly contained two 'Last modified at' columns [ID_34170]

<!-- MR 10.2.0 [CU7] - FR 10.2.10 -->

The GQI data source "Bookings" did not contain a *Last modified by* column and contained two different *Last modified at* columns (one with timestamps adjusted to the timezone and another with unadjusted timestamps). The *Last modified at* column containing unadjusted timestamps has now been replaced by a *Last modified by* column.

Also, the *Created at* and *Last modified at* columns will no longer be selected by default.

#### DataMiner Cube - Profiles app: Data from a profile instance parameter entry could no longer be retrieved after updating the entry [ID_34192]

<!-- MR 10.2.0 [CU7] - FR 10.2.10 -->

When a parameter entry was updated in a profile instance, it would no longer be possible to retrieve the data from the updated entry. As a result, the UI was not able to reflect the changes made to the parameter entry in question.

#### Web apps: Long text strings without spaces displayed in read-only boxes were clipped instead of wrapped [ID_34193]

<!-- MR 10.1.0 [CU19]/10.2.0 [CU7] - FR 10.2.10 -->

In web apps (e.g. Jobs), long text strings without spaces displayed in read-only boxes would be clipped. From now on, those strings will be wrapped so that all text is visible.

#### Failover: Certain correlation rules would no longer work after a Failover switch [ID_34204]

<!-- MR 10.1.0 [CU19]/10.2.0 [CU7] - FR 10.2.10 -->

After a Failover switch, in some cases, certain correlation rules would no longer work.

#### Dashboards app: Problem when trying to access a shared dashboard created in a previous version [ID_34210]

<!-- MR 10.2.0 [CU7] - FR 10.2.10 -->

When you tried to access a shared dashboard created in a previous version, the migration of the dashboard could get stuck because the Web API was unable to write the current Dashboards app version to the `C:\Skyline DataMiner\WebPages\dashboard\appversion.json` file.

#### DataMiner Cube - Services app: No services would be loaded the first time you opened the Services app [ID_34211]

<!-- MR 10.1.0 [CU19]/10.2.0 [CU7] - FR 10.2.10 -->

When you opened the *Services* app for the first time after opening DataMiner Cube, in some cases, no services would be loaded. The services would only be loaded when you closed the *Services* app and opened it again.

#### DataMiner Cube - Resources app: Problem when updating a resource that was added to multiple pools [ID_34225]

<!-- MR 10.2.0 [CU7] - FR 10.2.10 -->
<!-- Enhancement with same ID -->

Since DataMiner version 10.1.5/10.2.0, when you updated a resource that was added to multiple pools, after the update, it would incorrectly only be added anymore to the pool you had selected. It would no longer be added to the other pools.

#### Web apps: App would incorrectly log in again after the user had logged out [ID_34227]

<!-- MR 10.1.0 [CU19]/10.2.0 [CU7] - FR 10.2.10 -->

After a user had logged out of a web app, in some cases, that app would incorrectly continue to send out network requests and try to automatically log itself in again.

#### Run-time error in SLProtocol when a group was launched while a poll group with option 'PartialSNMP' was waiting for incoming SNMP data [ID_34233]

<!-- MR 10.1.0 [CU19]/10.2.0 [CU7] - FR 10.2.10 -->

When, on one thread, a group other than a poll group was launched while, on another thread, a poll group with option "partialSNMP" was waiting for incoming SNMP data, in some cases, a run-time error could occur in SLProtocol.

#### Problem with SLProtocol when performing a 'replace data' action [ID_34255]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU19]/10.2.0 [CU7] - Feature Release Version 10.2.10 -->

In some cases, an error could occur in SLProtocol when performing a 'replace data' action that had to replace multiple bytes.

#### Low-Code Apps: Header bar font color would incorrectly not be aligned with the theme color of the app [ID_34267]

<!-- MR 10.2.0 [CU7] - FR 10.2.10 -->

In some cases, the header bar font color would incorrectly not be aligned with the theme color of the app.

#### Web apps - Query builder: Hovering over an arrow to change the column order in the select node would select an incorrect arrow [ID_34268]

<!-- MR 10.2.0 [CU7] - FR 10.2.10 -->

In the select node of the query builder, you can change the column order by clicking up and down arrows. Up to now, when you hovered over one of those arrows, in some cases, the incorrect arrow would be selected.

#### Dashboards app - Time range feed: Delete icons of custom quick pick buttons would incorrectly be displayed on top of the time range feed overlay [ID_34278]

<!-- MR 10.1.0 [CU19]/10.2.0 [CU7] - FR 10.2.10 -->

In some cases, the delete icons of custom quick pick buttons would incorrectly be displayed on top of the time range feed overlay.

#### Web apps - EPM feed: Overlay would unexpectedly close when the mouse pointer moved away from the EPM view after selecting a chain [ID_34282]

<!-- MR 10.2.0 [CU7] - FR 10.2.10 -->

When you had selected a chain at the bottom of the EPM feed, in some cases, the overlay would unexpectedly close when the mouse pointer moved away from the EPM view.

#### Problem with SLElement when multiple foreign keys were being resolved [ID_34294]

<!-- MR 10.1.0 [CU19]/10.2.0 [CU7] - FR 10.2.10 -->

In some rare cases, an error could occur in SLElement when multiple foreign keys were being resolved.

#### Web apps: Loader bar of table component would incorrectly be refreshing each time a new page was loaded [ID_34303]

<!-- MR 10.2.0 [CU7] - FR 10.2.10 -->

While query pages were being retrieved via GQI, each time a new page was loaded, the loader bar at the top of a table component would incorrectly be refreshing.

#### SLDMS could incorrectly forget in-memory element information [ID_34363]

<!-- MR 10.2.0 [CU7] - FR 10.2.10 [CU0] -->

In some cases, SLDMS could incorrectly forget in-memory element information, causing certain element actions to fail.

#### Microsoft SQL Server: Query with offset, limit and where clause would return an incorrect result set [ID_34413]

<!-- MR 10.1.0 [CU19]/10.2.0 [CU7] - FR 10.2.10 [CU0] -->

When, on a system with a Microsoft SQL Server database, a query with an offset, a limit and a where clause was executed, the where clause would incorrectly be dropped. As a result, an incorrect result set would be returned.

Example of a query with an offset, a limit and a where clause:

``` SQL
select * from elementdata_162 where ieid = 5 limit 10,10
```
