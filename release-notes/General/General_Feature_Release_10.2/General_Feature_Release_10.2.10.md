---
uid: General_Feature_Release_10.2.10
---

# General Feature Release 10.2.10

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.2.10](xref:Cube_Feature_Release_10.2.10).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

#### DataMiner Taskbar Utility: Enhanced installation of app packages [ID_33969]

<!-- MR 10.1.0 [CU19]/10.2.0 [CU7] - FR 10.2.10 -->

Using the DataMiner Taskbar Utility, it is now possible to install all possible types of app packages. To install an app, you can either double-click the .dmapp file or right-click the Taskbar Utility icon, click *Upgrade* and select the app from the list.

Also, the *SLAppPackageInstaller.txt* log file will now keep track of all actions performed and issues encountered during the installation of an app.

> [!NOTE]
> After you have launched an upgrade, the upgrade process displayed in DataMiner Taskbar Utility may lag behind and DataMiner Taskbar Utility may use a considerable amount of memory. This is a known issue. See [Taskbar Utility performance issue while Agents are being upgraded](xref:KI_Taskbar_Utility_performance_issue_while_agents_are_being_upgraded).
>
> To prevent his issue, stay on the upgrade summary tab until the upgrade has finished, and then close DataMiner Taskbar Utility to have the memory cleared. Note also that this issue is related to the Taskbar Utility only and does not affect the upgrade process.

#### Dashboards / Low-Code Apps: Parameter table component brought in line with Table component [ID_34132]

<!-- MR 10.3.0 - FR 10.2.10 -->

The *Parameter table* component of dashboards and low-code apps has now been adjusted to be more like that generic *Table* component. In addition to improving consistency between these components, this also makes the *Parameter table* component more user-friendly:

- The horizontal scrollbar is now permanently displayed, while previously you had to scroll all the way to the bottom of the table to see it.
- The table will load more easily, improving performance of the dashboard or app especially with large tables.

Moreover, the additional features of the *Table* component will now also be available for the *Parameter table* component:

- Grouping on one or multiple columns.
- Sorting based on multiple columns.
- Filtering on multiple columns via the column header context menu.
- Filtering using the search box below the table.
- Resizing columns.
- Dragging and dropping columns to change the column order.

> [!NOTE]
> This change does not affect the *Parameter table* component as viewed on mobile devices.

#### Dashboards app / Low-Code Apps: Conditional coloring layout configuration now uses numeric filter instead of numeric slider [ID_34174]

<!-- MR 10.3.0 - FR 10.2.10 -->
<!-- Part of this RN is still in soft launch and consequently has not been documented yet -->

In the conditional coloring layout setting for Table and Node edge components, the numeric slider control has been replaced with a numeric filter. This has the following advantages:

- Full control over the boundaries. You can indicate whether the start and end should be in- or excluded.
- Possibility to not have a start or end boundary.
- More consistent with the free text filter.
- Easier to define a precise filter.

#### Dashboards app / Low-Code Apps: 'Return no rows when feed is empty' option replaced by a triple-state option [ID_34280]

<!-- MR 10.3.0 - FR 10.2.10 -->

Up to now, when configuring the filter of a GQI data feed, you could enable the *Return no rows when feed is empty* option to indicate that, when the feed was empty, you wanted an empty table to be returned instead of the entire table.

Now, this option has been replaced by a triple-state option. You can now indicate that, when the feed is empty, you want

- to have an empty table returned,
- to have the entire table returned, or
- to have the table filtered on empty values.

## Other features

#### Clearing an incident now clears any clearable base alarms it contains [ID_34112]

<!-- MR 10.3.0 - FR 10.2.10 -->

If an incident (also known as an alarm group) is cleared manually, any clearable base alarms of that incident will now also be cleared. This way, this behavior is consistent with the standard behavior for Correlation alarms.

#### GQI: columnInfo object of data source columns of type 'discrete' will now contain the possible values [ID_34179]

<!-- MR 10.3.0 - FR 10.2.10 -->

For each of the following GQI data source columns of type "discrete", the possible values will now be available in their columnInfo object:

| Data source              | Columns |
|--------------------------|---------|
| AlarmAdapter             | Alarm severity<br>Alarm type<br>Alarm status<br>Alarm source<br>Alarm user status |
| BookingAdapter           | Booking status |
| ChangePointAdapter       | Change type<br>Alarm severity |
| DCFInterfaceAdapter      | Interface type |
| LiteElementInfoAdapter   | Element state |
| TicketingAdapter         | All (custom) enum columns |
| DOMInstanceAdapter       | State<br>All custom enum fields |
| ParameterTableAdapter    | All parameters of type "discrete" |
| PaProcessAdapter         | PaProcess state<br>PaProcess activity<br>PaProcess start event type |
| PaTokenAdapter           | PaToken status<br>PaToken error state<br>PaToken sub process type<br>PaToken type |
| PatternOccurrenceAdapter | Pattern type |

#### GQI - EPM feed: Linking 'System Name' and 'System Type' to the query [ID_34222]

<!-- MR 10.3.0 - FR 10.2.10 -->

Using an EPM feed, it is now possible to link *System Name* and *System Type* to the GQI query you are building.

#### Dashboards / Low-Code Apps: Checkboxes to select discrete values in column filter Table component [ID_34234]

<!-- MR 10.3.0 - FR 10.2.9 -->

When you configure a column filter for a Table component in a dashboard or low-code app, you can now select checkboxes to filter on discrete values.

#### GQI: Using GQI query columns to filter a 'State' component [ID_34235]

<!-- MR 10.3.0 - FR 10.2.10 -->

It is now possible to use GQI query columns to filter a *State* component.

#### GQI: Query columns of type 'string' can now be filtered using 'Equals' and 'NotEquals' [ID_34246]

<!-- MR 10.3.0 - FR 10.2.10 -->

Query columns of type "string" can now be filtered using *Equals* and *NotEquals*.

## Changes

### Enhancements

#### External authentication using SAML: Extended logging [ID_33622]

<!-- MR 10.3.0 - FR 10.2.10 -->

When authenticating users using SAML, the following additional debug information will now be logged in the *SLSaml.txt* file:

- Whether Just-In-Time provisioning (JIT) is enabled.
- Which group claims are being used.

#### SLLogCollector now also collects SLAnalytics configuration files [ID_34106]

<!-- MR 10.3.0 - FR 10.2.10 -->

Several SLAnalytics configuration files will now also be collected by the SLLogCollector tool. These will be placed in the *Logs/Skyline DataMiner/Analytics* and *Logs/Skyline DataMiner/Configuration* folders of the archive created by SLLogCollector.

#### Enhanced performance when an SNMP element using multi-threaded timers is polling multiple sources simultaneously [ID_34143]

<!-- MR 10.1.0 [CU19]/10.2.0 [CU7] - FR 10.2.10 -->

Because of a number of enhancements, overall performance has increased when an SNMP element using multi-threaded timers is polling multiple sources simultaneously.

#### Edge WebView2 now preferred when SAML authentication is used [ID_34162]

<!-- MR 10.2.0 [CU7] - FR 10.2.10 -->

When SAML authentication is used, Cube will now try to use the Edge WebView2 browser engine instead of CefSharp. It will only fall back to using CefSharp if WebView2 is not available.

This will prevent the following possible issues:

- The CefSharp browser engine version used by Cube is not updated frequently and therefore not always trusted by certain SAML identity provider websites, such as Microsoft Azure. This can cause a lengthy authentication procedure, even if the browser cache is enabled.
- The CefSharp browser engine needs to be downloaded from the DMA before a first authentication (on a new device). However, this is currently not supported for HTTPS-only setups.

#### Dashboards app / Low-Code Apps: Conditional coloring layout filter configuration now shows discrete column values [ID_34182]

<!-- MR 10.3.0 - FR 10.2.10 -->
<!-- Part of this RN is still in soft launch and consequently has not been documented yet -->

In the conditional coloring layout setting for Table and Node edge components, discrete column values will now be displayed to make it easier to configure a filter.

#### SLReset will no longer remove VersionHistory.txt and the HTTPS configuration [ID_34194]

<!-- MR 10.2.0 [CU9] - FR 10.2.10 -->

From now on, the factory reset tool *SLReset.exe* will no longer remove the following items:

- the *VersionHistory.txt* file
- the HTTPS configuration stored in the *MaintenanceSettings.xml* file.

#### DataMiner upgrade: AnalyticsDropUnusedCassandraTables upgrade action will explicitly be triggered [ID_34197]

<!-- MR 10.3.0 (not added) - FR 10.2.10 -->

In DataMiner versions from 10.2.8 onwards, during a DataMiner upgrade, the *AnalyticsDropUnusedCassandraTables* upgrade action would fail, unless the [workaround for this issue](xref:KI_RTE_with_SLAnalytics_when_upgrading) had been implemented. During the upgrade to the next DataMiner version, this upgrade action will explicitly be triggered to make sure all unused Cassandra tables get removed.

#### Improved performance of Resources module [ID_34205]

<!-- MR 10.3.0 - FR 10.2.10 -->

Because of enhancements to the way resources are processed and stored, the Resources module will now initialize more quickly.

In addition, performance has improved when a resource or resource pool is added or updated.

#### Improved performance of SLDataGateway process [ID_34206]

<!-- MR 10.2.0 [CU8] - FR 10.2.10 -->

Because of improved internal logic, the performance of the SLDataGateway process has improved.

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

In the user settings (*user icon > Settings*), from now on, you will only be able to configure themes when you have permission to edit dashboards.s

#### Low-Code Apps: Header bar enhancements [ID_34264]

<!-- MR 10.2.0 [CU7] - FR 10.2.10 -->

A number of small enhancements have been made to the header bar of low-code apps:

- Button text now supports both upper case and lower case.
- Buttons no longer have lines between them.

#### Enhanced performance when starting up elements on systems using a MySQL or Microsoft SQL Server database [ID_34265]

<!-- MR 10.1.0 [CU19]/10.2.0 [CU7] - FR 10.2.10 -->

Because of a number of enhancements, overall performance has increased when starting up elements on systems using a MySQL or Microsoft SQL Server database, especially elements containing large amounts of data.

#### GQI table column names will no longer include table names [ID_34302]

<!-- MR 10.3.0 - FR 10.2.10 -->

When a GQI table column inherits its name from a parameter of which the name includes the table name (between brackets), that table name will now be trimmed from the column name.

#### Low-Code Apps: 'fetch data' action is now available in all visualizations that can use query data [ID_34308]

<!-- MR 10.3.0 - FR 10.2.10 -->
<!-- Not added to 10.3.0 -->

The *fetch data* action is now available in all visualizations that can use query data.

#### Newtonsoft.Json DLL updated to version 13.0.1 [ID_34558]

<!-- MR 10.1.0 [CU19]/10.2.0 [CU7] - FR 10.2.10 -->

Due to a high-severity vulnerability, the Newtonsoft.Json DLL file located in the `C:\Skyline DataMiner\ProtocolScripts` folder has been updated to version 13.0.1.

For more information on the vulnerability, see [Improper Handling of Exceptional Conditions in Newtonsoft.Json](https://github.com/advisories/GHSA-5crp-9r3c-p9vr).

### Fixes

#### Service & Resource Management: New IgnoreCanceledReservations and IgnorePastReservation properties not linked to existing corresponding properties [ID_34080]

<!-- MR 10.3.0 (not added) - FR 10.2.10 -->

In DataMiner 10.2.7, the *IgnoreCanceledReservations* and *IgnorePastReservation* properties were introduced in the *ResourceDeleteOptions* of the ResourceManagerHelper. However, these were not yet linked to the existing *IgnoreCanceledReservations* and *IgnorePastReservations* properties in the *SetResourceMessage*, which could potentially cause issues in case the old properties were set to true and the new ones remained set to false. These properties will now be synced so that they always have the same value.

#### Error during Analytics upgrade action [ID_34082]

<!-- MR 10.3.0 - FR 10.2.10 -->

In some rare cases, an error could occur during the Analytics upgrade action when upgrading a DataMiner System with a Cassandra database per cluster.

#### Service & Resource Management: Files in C:\Skyline DataMiner\ResourceManager would not be locked properly when being read or updated during a midnight synchronization [ID_34104]

<!-- MR 10.1.0 [CU19]/10.2.0 [CU7] - FR 10.2.10 -->

Up to now, the files stored in the `C:\Skyline DataMiner\ResourceManager` folder would not be locked properly when being read or updated during a midnight synchronization. File locking has now been improved.

#### Web apps - DOM: Sections inherited from a base behavior definition would not be shown [ID_34125]

<!-- MR 10.2.0 [CU7] - FR 10.2.10 -->

When a DOM definition using an extended behavior definition was assigned to a form component, any sections inherited from the base behavior definition would not be shown.

#### SLNet could throw an OutOfMemoryException due to a memory leak [ID_34126]

<!-- MR 10.1.0 [CU19]/10.2.0 [CU7] - FR 10.2.10 -->

In some cases, SLNet could throw an OutOfMemoryException due to a memory leak.

#### Dashboards app: Incorrect user validation in 'User access' section of 'Settings' tab [ID_34138]

<!-- MR 10.2.0 [CU7] - FR 10.2.10 -->

When editing a dashboard, you can go to *Settings > User access* and specify the users and/or user groups that are allowed to view or edit the dashboard in question. When you did not have permission to change security settings, the users and user groups you entered would not be validated correctly.

#### Dashboards app / Low-Code Apps: Changes to the feed could incorrectly influence the time window of a state timeline component [ID_34148]

<!-- MR 10.3.0 - FR 10.2.10 -->

In some cases, changes to the feed linked to a state timeline component could reset the time window. From now on, linking a query filter to the timeline will no longer influence the time window. The filter will be applied and the current time window will be preserved.

Also, because of a number of enhancements, overall performance has increased when linking a query filter to a state timeline component.

#### Cassandra cluster: No trending information shown for parameters of which the value had not changed for 10 days or more [ID_34149]

<!-- MR 10.2.0 [CU7] - FR 10.2.10 -->

On a system with a Cassandra cluster, no trending information would be shown for parameters of which the value had not changed for 10 days or more.

#### Automation: Invalid script changes would incorrectly be saved [ID_34150]

<!-- MR 10.2.0 [CU7] - FR 10.2.10 -->

When, in the *Automation* app, you made an invalid change in a script, closed the app and clicked *Yes* to confirm the changes, up to now, the invalid changes you made would incorrectly be saved. If the invalid change was an invalid script name change, then the script would even be deleted. From now on, it will only be possible to save valid changes.

#### Scheduled alarm templates would incorrectly not be updated when the system time changed [ID_34154]

<!-- MR 10.1.0 [CU19]/10.2.0 [CU7] - FR 10.2.10 -->

When the system time changed because of e.g. a clock resynchronization or a switch to or from daylight-saving time, up to now, the start time and end time of scheduled alarm templates would incorrectly not get updated.

#### GQI: 'Bookings' data source incorrectly contained two 'Last modified at' columns [ID_34170]

<!-- MR 10.2.0 [CU7] - FR 10.2.10 -->

The GQI data source "Bookings" did not contain a *Last modified by* column and contained two different *Last modified at* columns (one with timestamps adjusted to the timezone and another with unadjusted timestamps). The *Last modified at* column containing unadjusted timestamps has now been replaced by a *Last modified by* column.

Also, the *Created at* and *Last modified at* columns will no longer be selected by default.

#### Web apps: Long text strings without spaces displayed in read-only boxes were clipped instead of wrapped [ID_34193]

<!-- MR 10.1.0 [CU19]/10.2.0 [CU7] - FR 10.2.10 -->

In web apps (e.g. Jobs), long text strings without spaces displayed in read-only boxes would be clipped. From now on, those strings will be wrapped so that all text is visible.

#### Failover: Certain correlation rules would no longer work after a Failover switch [ID_34204]

<!-- MR 10.1.0 [CU19]/10.2.0 [CU7] - FR 10.2.10 -->

After a Failover switch, in some cases, certain correlation rules would no longer work.

#### Dashboards app: Problem when trying to access a shared dashboard created in a previous version [ID_34210]

<!-- MR 10.2.0 [CU7] - FR 10.2.10 -->

When you tried to access a shared dashboard created in a previous version, the migration of the dashboard could get stuck because the Web API was unable to write the current Dashboards app version to the `C:\Skyline DataMiner\WebPages\dashboard\appversion.json` file.

#### Web apps: App would incorrectly log in again after the user had logged out [ID_34227]

<!-- MR 10.1.0 [CU19]/10.2.0 [CU7] - FR 10.2.10 -->

After a user had logged out of a web app, in some cases, that app would incorrectly continue to send out network requests and try to automatically log itself in again.

#### Low-Code Apps: Feed selection lost when navigating between pages [ID_34231]

<!-- MR 10.3.0 - FR 10.2.10 -->
<!-- Not added to 10.3.0 -->

Up to now, in low-code apps, feeds would incorrectly not keep the selected values when the page or panel was closed and subsequently reopened. From now on, feeds that - when used in the Dashboards app - allow you to set default values via the URL, will - when used in low-code apps - keep the selected values when the page or panel was closed and subsequently reopened.

#### Run-time error in SLProtocol when a group was launched while a poll group with option 'PartialSNMP' was waiting for incoming SNMP data [ID_34233]

<!-- MR 10.1.0 [CU19]/10.2.0 [CU7] - FR 10.2.10 -->

When, on one thread, a group other than a poll group was launched while, on another thread, a poll group with option "partialSNMP" was waiting for incoming SNMP data, in some cases, a run-time error could occur in SLProtocol.

#### Dashboards app Low-Code Apps: GQI table error not cleared between sessions [ID_34243]

<!-- MR 10.3.0 - FR 10.2.10 -->
<!-- Not added to 10.3.0 -->

When a new GQI session was started, in some rare cases, an error that occurred in the previous session would incorrectly be displayed.

#### Problem with SLProtocol when performing a 'replace data' action [ID_34255]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU19]/10.2.0 [CU7] - FR 10.2.10 -->

In some cases, an error could occur in SLProtocol when performing a 'replace data' action that had to replace multiple bytes.

#### Low-Code Apps: Header bar font color would incorrectly not be aligned with the theme color of the app [ID_34267]

<!-- MR 10.2.0 [CU7] - FR 10.2.10 -->

In some cases, the header bar font color would incorrectly not be aligned with the theme color of the app.

#### Web apps - Query builder: Hovering over an arrow to change the column order in the select node would select an incorrect arrow [ID_34268]

<!-- MR 10.2.0 [CU7] - FR 10.2.10 -->

In the select node of the query builder, you can change the column order by clicking up and down arrows. Up to now, when you hovered over one of those arrows, in some cases, the incorrect arrow would be selected.

#### Dashboards app / Low-Code Apps: Column filters in generic filter component incorrectly marked as incapable [ID_34273]

<!-- MR 10.3.0 - FR 10.2.10 -->

In the generic filter component, in some cases, column filters would be incorrectly marked as incapable when the filter assistance option was enabled.

#### Dashboards app - Time range feed: Delete icons of custom quick pick buttons would incorrectly be displayed on top of the time range feed overlay [ID_34278]

<!-- MR 10.1.0 [CU19]/10.2.0 [CU7] - FR 10.2.10 -->

In some cases, the delete icons of custom quick pick buttons would incorrectly be displayed on top of the time range feed overlay.

#### Low-Code Apps: Selector feeds would incorrectly not be displayed in the edit sidebar [ID_34281]

<!-- MR 10.3.0 - FR 10.2.10 -->
<!-- Not added to 10.3.0 -->

In some cases, the selector feeds would incorrectly not be displayed in the edit sidebar under the *Feeds* data source section.

#### Web apps - EPM feed: Overlay would unexpectedly close when the mouse pointer moved away from the EPM view after selecting a chain [ID_34282]

<!-- MR 10.2.0 [CU7] - FR 10.2.10 -->

When you had selected a chain at the bottom of the EPM feed, in some cases, the overlay would unexpectedly close when the mouse pointer moved away from the EPM view.

#### Problem with SLElement when multiple foreign keys were being resolved [ID_34294]

<!-- MR 10.1.0 [CU19]/10.2.0 [CU7] - FR 10.2.10 -->

In some rare cases, an error could occur in SLElement when multiple foreign keys were being resolved.

#### Low-Code Apps: Problem when using the "query rows" data source [ID_34298]

<!-- MR 10.3.0 - FR 10.2.10 -->
<!-- Not added to 10.3.0 -->

In some cases, an exception could be thrown when using the "query rows" data source.

#### Low-Code Apps: Panels could flicker while being loaded [ID_34301]

<!-- MR 10.3.0 - FR 10.2.10 -->
<!-- Not added to 10.3.0 -->

In some cases, panels could flicker while being loaded.

#### Web apps: Loader bar of table component would incorrectly be refreshing each time a new page was loaded [ID_34303]

<!-- MR 10.2.0 [CU7] - FR 10.2.10 -->

While query pages were being retrieved via GQI, each time a new page was loaded, the loader bar at the top of a table component would incorrectly be refreshing.

#### Dashboards app / Low-Code Apps: Query column filters would not be applied correctly to table components [ID_34305]

<!-- MR 10.3.0 - FR 10.2.10 -->

when a dashboard, a low-code app page or low-code app panel was initialized, in some cases, query column filters would not be applied correctly to table components on that dashboard, page or panel.

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
