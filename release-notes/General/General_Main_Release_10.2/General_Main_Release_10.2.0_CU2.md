---
uid: General_Main_Release_10.2.0_CU2
---

# General Main Release 10.2.0 CU2

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Security enhancements \[ID_32849\] \[ID_32954\] \[ID_32992\] \[ID_33014\] \[ID_33052\]

A number of security enhancements have been made.

#### Dashboards app - GQI: GQI filter can now be linked to query rows \[ID_32552\]

In a filter node of a dashboard query, you can now choose to filter by query rows from a feed. To do so, select the *Use feeds* option, select the feed, select the type *Query rows*, and then select the appropriate column of the table containing the rows. Note that only the columns compatible with the type of column you are filtering will be available for selection.

#### Enhanced performance with regard to the processing of system performance indicators \[ID_32574\]

Because of a number of enhancements, overall performance has increased with regard to the processing of system performance indicators.

#### Dashboards app: Improved loading indicator for bar and pie chart with GQI data \[ID_32806\]

The loading indicator when GQI data are loaded for a bar or pie chart component has been improved to be more in line with the usual dashboard style. Instead of a spinner, now a loading bar is shown at the top of the component.

#### Dashboards app: Live sharing no longer requires users to have permission to edit the dashboards they are sharing \[ID_32812\]

Up to now, when users wanted to share a dashboard, they also needed to have permission to edit the dashboard in question. From now on, users who want to share a dashboard will no longer need permission to edit that dashboard.

> [!NOTE]
> When you do not have *General \> Live sharing \> UI available* permission, you will not see anything related to live sharing. So, make sure to always use this permission in conjunction with the Share permission.

#### Dashboards app - GQI: Enhanced visualization of queries \[ID_32823\]

A number of enhancements have been made with regard to the visualization of GQI queries. For example, raw values (e.g. column IDs, GUIDs, etc.) will be translated to display values when possible.

#### Cassandra Cluster Migrator tool: Increased write timeout \[ID_32829\]

When it is migrating data, basically, the Cassandra Cluster Migrator tool reads a page of data from the original database (Cassandra or SQL) and then writes that page to the target database (Cassandra Cluster or Elasticsearch). The timeout for the write operations has now been increased from 2 minutes to 30 minutes.

#### Dashboards app - GQI: Queries must now all have a unique name \[ID_32836\]

From now on, when you create, update or import a GQI query, a unique query name will be mandatory. Up to now, query names were optional.

- When you create a new query, the system will suggest “New query” as default name. If that name already exists, then a counter will be added (e.g. “New query (1)”, “New query (2)”, etc.

- When you import a query that has no name, the system will suggest “Imported query” as default name. If that name already exists, then a counter will be added (e.g. “Imported query (1)”, “Imported query (2)”, etc.

#### DataMiner upgrade packages: Obsolete upgrade/downgrade actions removed \[ID_32861\]

Obsolete upgrade and downgrade actions for DataMiner versions older than DataMiner 9.6 have now been removed from the DataMiner upgrade packages.

#### Dashboards app - GQI: Node placeholders now have a clearer name \[ID_32866\]

In the GQI query builder, the node placeholders now have a clearer name. For example, the name of the first node has been changed from “Filter” to “Select data source” and all subsequent nodes will now be named “Select operator”.

#### Web Services API: Enhanced handling of errors thrown when processing asynchronous requests \[ID_32933\]

A number of enhancements have been made with regard to the handling of errors thrown when processing asynchronous requests.

#### DataMiner upgrade packages: New prerequisite check that verifies whether the ports used by DataMiner can be reached in between DataMiner Agents \[ID_32944\]

From now on, upgrade packages will perform a prerequisite check that verifies whether the ports used by DataMiner can be reached in between DataMiner Agents. This will prevent situations where a DataMiner System becomes non-functional after an upgrade that uses more or different ports.

Ports currently checked:

- 4222: NATS
- 6222: NATS (only checked when you are not upgrading a standalone agent, a standalone Failover pair or a two-node agent cluster)
- 9090: NAS

If this check fails, you will need to execute the VerifyClusterPorts.dmupgrade package ([download](https://community.dataminer.services/download/verifyclusterports-dmupgrade/)). VerifyClusterPorts.dmupgrade will run the same tests as the DataMiner upgrade package, but it will make sure that temporary listening ports are open for the required ports and a temporary local firewall rule is configured. This way, if a firewall or other configuration issue is causing the problem, this will become clear. If no failing ports are reported when you run this package, the regular upgrade package will use this stored result to continue with the upgrade.

#### Enhanced setup of serial connections with SSL/TLS enabled \[ID_32969\]

A number of enhancements have been made with regard to the setup of serial connections with SSL/TLS enabled.

### Fixes

#### Elasticsearch: Casing will now be ignored when sorting fields of type string \[ID_32437\]

From now on, Elasticsearch will ignore casing when sorting fields of type string.

#### DataMiner web apps: Filter issue when using arrow keys in drop-down box \[ID_31472\]

In the DataMiner web apps (e.g. the Dashboards app), when you opened a drop-down box that already had a value selected and used the arrow keys to navigate through the values, the current value was applied as a filter, while this should not occur.

#### Alarm templates: Miscellaneous fixes \[ID_32462\]

A number of issues have been fixed with regard to alarm templates.

- When you updated an alarm template that contained a table parameter with at least two filters, only the last of those filters was calculated.
- When, in an alarm template, you disabled the smart baselines for a table parameter with a filter and then re-enable it, the smart baselines for that table parameter would no longer be calculated.

Also, a number of enhancements have been made with regard to the calculation of smart baselines.

#### Cassandra Cluster Migrator tool would incorrectly not allow multiple IP addresses in the 'Cassandra IP(s)' field \[ID_32554\]

When configuring the Cassandra settings in the Cassandra Cluster Migrator tool, it would incorrectly not be possible to specify multiple IP addresses in the *Cassandra IP(s)* field.

#### DataMiner Cube: Pop-up window asking for new password disappeared after a while \[ID_32623\]

When an administrator enables the “User must change password at next login” setting for a particular local DataMiner user, the next time that user tries to log in to DataMiner Cube, a pop-up window will appear, asking to enter a new password. In some cases, that pop-up window could disappear after a while, even though no new password had been specified.

#### Problem when migrating a Failover system to a Cassandra cluster \[ID_32672\]

When the Cassandra Cluster Migrator tool was used to transform a Failover system consisting of DMAs with separate SQL or Cassandra databases into a Failover system consisting of DMAs that are all connected to a shared Cassandra and Elasticsearch cluster, in some cases, the migration process would incorrectly be initiated on the offline DMA instead of the online DMA. When that happened, the data written during the migration process would not be written to the destination Cassandra Cluster database.

#### Service & Resource Management: GetEligibleResources would ignore the time range passed to it \[ID_32763\]

Up to now, when GetEligibleResources was called, the eligible resources would incorrectly be calculated based on the time range of the ReservationInstance to be ignored. From now on, when the context passed to GetEligibleResources includes a time range, the time range of the ReservationInstance will be ignored.

#### DataMiner Cube: Problem when opening the Ticketing app \[ID_32775\]

Up to now, in some cases, the Cube UI could become unresponsive when you opened the Ticketing app.

#### DataMiner Cube - Visual Overview: SET command linked to a shape would not be executed when the page was displayed in a VdxPage window of type 'Popup' \[ID_32780\]

When a page that was displayed in a VdxPage window of type “Popup” contained a shape linked to a SET command, clicking that shape would incorrectly not execute the SET command.

#### Problems with embedded dashboards components \[ID_32782\]

When a GQI component was embedded in a Visio drawing or a web page, in some cases, that component would not be rendered correctly. Also, in some cases, embedded dashboard components would not be able to retrieve data from the database.

#### DataMiner Cube - Resources app: No resources or resource pools would be loaded when opening the Resources app \[ID_32790\]

When you opened the Resources app, in some cases, no resources or resource pools would be loaded.

#### Dashboards app - GQI: GUIDs of DOM reference fields would be displayed incorrectly \[ID_32807\]

Up to now, the GUIDs of the following types of DOM reference fields would be displayed incorrectly:

- Reservations (i.e. bookings)
- Service definitions
- DOM instances
- Resources

#### Dashboards app: Problem when sorting a table component populated by means of a GQI query \[ID_32814\]

When you sorted a table component populated by means of a GQI query, in some cases, the sorting would be incorrect.

#### Processes would not get registered correctly when a DataMiner upgrade included a reboot \[ID_32818\]

When a DataMiner upgrade included a reboot (either explicitly requested, or e.g. after installing Microsoft .NET 4.8), in some cases, services would not get registered correctly, especially when the new DataMiner version included services that did not previously exist.

#### Dashboards app: Problem when sharing a dashboard with a node edge component \[ID_32822\]

When viewing a shared dashboard with a node edge component that had its nodes configured to use either analytical or alarm colors, the node edge component could not be rendered.

#### Problem with SLDMS hosting agent cache \[ID_32827\]

In some rare cases, the SLDMS hosting agent cache could get corrupted. As a result, it would no longer contain the correct data when processing element updates.

#### Dashboards app: Query name reset when query is edited \[ID_32832\]

In some cases, when the content of a query in a dashboard was changed, it could occur that the name of the query was reset to a previous value.

#### Dashboards app: Display value that was used to refer to an unnamed query would incorrectly contain HTML tags \[ID_32833\]

When a query had not been assigned a name, up to now, the display value that was used to refer to that unnamed query would incorrectly contain HTML tags. From now on, the name “(query)” will be used to refer to an unnamed query.

#### Exception logged in SLNet.txt during startup \[ID_32835\]

Since DataMiner 10.2.0 \[CU0\] and DataMiner 10.2.2, the following exception could be generated in the SLNet.txt log file during DataMiner startup:

```txt
2022-03-09 12:34:38.962|5|Config.Init|Error reading MaintenanceSettings.xml: System.Exception: Re-entrant Facade.Initialize detected. Do not access Facade.Instance directly or indirectly from the Facade constructor. ---> System.Exception: at System.Environment.GetStackTrace(Exception e, Boolean needFileInfo)
   at System.Environment.get_StackTrace()
   at Skyline.DataMiner.Net.Facade.get_Instance()
   at Skyline.DataMiner.Net.Config.Init()
   at Skyline.DataMiner.Net.Config.get_Instance()
   at Skyline.DataMiner.Net.Facade..ctor()
   at Skyline.DataMiner.Net.Facade.get_Instance()
   at Skyline.DataMiner.Net.SLNetService.<OnStartInner>b__10_0()
   at System.Threading.Tasks.Task.Execute()
   at System.Threading.ExecutionContext.RunInternal(ExecutionContext executionContext, ContextCallback callback, Object state, Boolean preserveSyncCtx)
   at System.Threading.ExecutionContext.Run(ExecutionContext executionContext, ContextCallback callback, Object state, Boolean preserveSyncCtx)
   at System.Threading.Tasks.Task.ExecuteWithThreadLocal(Task& currentTaskSlot)
   at System.Threading.Tasks.Task.ExecuteEntry(Boolean bPreventDoubleExecution)
   at System.Threading.ThreadPoolWorkQueue.Dispatch()
   --- End of inner exception stack trace ---
   at Skyline.DataMiner.Net.Facade.get_Instance()
   at Skyline.DataMiner.Net.Config.Init()
```

#### NAS: Incorrect default settings in nas.config file \[ID_32840\]

The default settings in the nas.config file would be incorrect.

#### SLNet would incorrectly log XmlSerializer exceptions \[ID_32859\]

Up to now, SLNet would incorrectly log the following exception each time it was thrown:

```txt
SLNet tried to load DataMinerInstallerCommunication.XmlSerializers
```

#### Dashboards app - GQI: Problem when exporting table data to CSV \[ID_32865\]

When you exported GQI data from a table component to a CSV file, up to now, only the currently loaded page would get exported. From now on, all data in the table will be exported.

> [!NOTE]
> While the export operation is progress, an “exporting to CSV” notification will be shown in the bottom-right corner of the screen.

#### Memory leak in SLElement \[ID_32885\]

In some cases, a problem with subscriptions on views with remote data would cause SLElement to leak memory, which could eventually lead to run-time errors in the parameter thread.

#### Filtered tables could incorrectly receive updates for rows that did not match the applied filter \[ID_32915\]

In some cases, a filtered table could incorrectly receive updates for rows that did not match the applied filter. On EPM setups, this would cause performance issues and run-time errors.

#### DataMiner Cube - Alarm Console: Focus icon would not be displayed when a new alarm was added to an alarm group \[ID_32931\]

When an alarm was added to an alarm group while that group was expanded, the focus icon would incorrectly not be displayed.

#### Online SLA window would not get properly closed \[ID_32946\]

In some cases, an online SLA window would not get properly closed.

#### Memory leak in SLSpiHost \[ID_32970\]

In some cases, the SLSpiHost process could leak memory.

#### DataMiner Cube - Alarm Console: Incident alarms were incorrectly shown twice \[ID_32981\]

When, upon opening DataMiner Cube, the Alarm Console had an active alarms tab page with “Automatic incident tracking” enabled, in some cases, the incident alarms would incorrectly be shown twice.

#### DataMiner Cube: No longer possible to move DVE elements to another view \[ID_32984\]

In some cases, it would incorrectly no longer be possible to move DVE elements to another view.

#### NATS issue could cause a DataMiner Agent to not start up correctly \[ID_33026\]

In some cases, a NATS issue could cause a DataMiner Agent to not start up correctly.

#### Dashboards app - GQI: Problem while creating or updating a query when users did not have permission to view objects retrieved by a data source \[ID_33029\]

When users were creating or modifying a GQI query, in some cases, an exception could be thrown when those users did not have permission to view objects retrieved by a data source.

#### Problem when starting up SLNet \[ID_33033\]

In some cases, the following error would be logged in SLNet.txt with XYZ being the word “AUTHORITY” in a language other than English:

```txt
Connection did not authenticate. Computer: COMPUTERNAME Application: SLDataGateway User: NT-XYZ\SYSTEM
```

The problem would occur on systems installed in a language other than English and was caused by code looking for the NT-AUTHORITY\\SYSTEM user, which on these systems, was named differently.

#### Problem with SLLog when a log file was closed \[ID_33191\]

In some cases, an error could occur in the SLLog process when a log file was closed.

#### DataMiner Cube - Visual Overview: Spectrum shape would incorrectly show a grid instead of text \[ID_33192\]

When a shape was linked to a spectrum parameter with an ID between 50,000 and 60,000, in some cases, the shape would incorrectly show a grid instead of text.

#### Interactive Automation scripts: Slider linked to a numeric text box would incorrectly keep following the mouse pointer \[ID_33204\]

In interactive Automation scripts, in some cases, the slider linked to a numeric text box would incorrectly keep following the mouse pointer, even after the mouse button had been released.
