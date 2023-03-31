---
uid: General_Main_Release_10.2.0_CU3
---

# General Main Release 10.2.0 CU3

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### DataMiner Cube - Resources app: Function instance name can now be updated \[ID_32811\]

When updating a resource in the Resources app, it is now possible to change the function instance name, i.e. the name of the DVE element linked to a function resource.

> [!NOTE]
>
> - It is recommended to modify DVE names via the resource instead of via the main DVE element.
> - Names of DVE elements can also be modified in *General Parameters \> Resource Info \> DVE Table*.

#### DataMiner Taskbar Utility: Deprecated launch options for System Display and Cube removed \[ID_32877\]

In the DataMiner Taskbar Utility, the following options have been removed:

- Launching System Display by double-clicking while pressing the SHIFT key.
- Opening the locally installed DataMiner Cube in Microsoft Internet Explorer by double-clicking.

> [!NOTE]
> The following option has been kept:
>
> - Opening Windows file explorer in the C:\\Skyline DataMiner\\ folder by double-clicking while pressing the CTRL key.

#### Enhanced performance when starting up elements \[ID_33023\]

Because of a number of enhancements, overall performance has increased when starting up elements, especially elements containing large amounts of data.

#### DataMiner Cube & legacy Reporter app: Alarm state change graphs now differentiate between masked state and unknown state \[ID_33082\]

From now on, the alarm state change graphs (pie chart and time line) in the legacy Reporter app and the alarm state change pie chart on the REPORTS page of an element card in Cube will differentiate between masked state and unknown state.

Also, in the legacy Reporter app, the default colors have now been aligned with the default DataMiner alarm colors.

#### SLMessageBroker log files are now split per process and limited to 3 MB \[ID_33126\]

The SLMessagebroker log files are now split per process and limited to 3 MB.

These log files are stored in C:\\Skyline DataMiner\\Logging\\SLMessageBroker and are named SLMessageBroker\_\[processname\].txt. When a file exceeds the 3-MB limit, it is renamed to SLMessageBroker\_\[processname\]\_1.txt and a new file is created named SLMessageBroker\_\[processname\]\_2.txt.

> [!NOTE]
> These log files will not be deleted when the DataMiner Agent is upgraded.

#### Visual Overview: Enhanced performance when creating element shapes \[ID_33140\]

Because of a number of enhancements, overall performance has increased when creating element shapes.

#### Monitoring app now also takes into account Param.Message tags \[ID_33162\]

In a protocol.xml file, for every write parameter, you can specify a message to be displayed when users change that parameter on the UI.

Up to now, this *Param.Message* tag was only taken into account by DataMiner Cube. From now on, the Monitoring app will also take it into account.

#### SLDMS process is now large address aware \[ID_33234\]

SLDMS, which is a 32-bit process, will now be started with the /LARGEADDRESSAWARE flag. This way, it will be able to access up to 4GB of memory.

#### Enhanced performance when processing a large number of objects with links to other objects \[ID_33271\]

Because of a number of enhancements, overall performance has increased when processing (e.g. exporting) a large number of objects with links to other objects.

#### IPC channel port names will now always be unique \[ID_33274\]

IPC channel port names will now always be unique.

#### DataMiner Cube - System Center: 'Automatic incident tracking' feature will now be enabled by default \[ID_33286\]

In *System Center \> System settings \> Analytics config*, the *Automatic incident tracking* feature will now be enabled by default.

- If you upgrade from a DataMiner version older than 10.0.11, a new *Automatic incident tracking* section will be added to the *Analytics config* tab, and its *Enabled* setting will by default be set to “True”.
- If you upgrade from DataMiner version 10.0.11 until 10.1.11, the *Automatic incident tracking* section will now by default have its *Enabled* setting set to “True”. Up to now, it would by default be set to “False”.
- If you upgrade from DataMiner version 10.1.12 or newer, the *Automatic incident tracking* section, of which the *Enabled* setting was by default already set to “True”, will now even be set to “True” when it had been manually set to “False” earlier.

> [!NOTE]
> After the upgrade, all settings related to *Automatic incident tracking* will be reset to their default values. Any manual change made to any of these settings prior to the upgrade will be lost.

#### DataMiner Cube: Independent client updates \[ID_33360\]

When you connect DataMiner Cube to a DataMiner Agent with main release version 10.2.0 CU3 (or newer) or feature release version 10.2.6 (or newer), from now on, it will automatically update to the most recent version. This will allow you to use the latest Cube features as soon as they are released without having to wait for a DMA upgrade.

##### Client configuration

If you do not want to wait for the next automatic Cube update, in the start window of the Cube desktop app, click the cogwheel icon in the bottom-right corner, and select *Check for updates*. If a new Cube version is available, it will be downloaded. When the download has finished, a *Restart now* button will appear. Click it to start using the new version.

Two update tracks are available. Click the cogwheel icon in the bottom-right corner, and select *Settings*. If you open the Cube update track setting, you can select one of the following tracks:

| Track                     | Description                                                                                            |
|---------------------------|--------------------------------------------------------------------------------------------------------|
| Release                   | Use the latest released DataMiner Cube version, so you can enjoy all the latest and greatest features. |
| Release (delayed 2 weeks) | Wait to use the latest released DataMiner Cube version until 2 weeks after the release date.           |

If you want to use a specific Cube version to connect to a particular agent or cluster, then right-click an agent or cluster in the start window, and select a specific Cube version.

##### Server configuration

When connected to a particular DataMiner System, users with *Manage client versions* permission can go to *System Center \> System settings \> Manage client versions*, and select one of the following Cube update modes:

- Allow automatic updates
- Force the matching release version (i.e. force users to always use the Cube version that was shipped with the DMA upgrade package)
- Force a specific version (i.e. force users to always use a particular Cube version)

By default, the setting chosen here will apply to all agents in the DMS, including Failover setups. However, it is possible (but not recommended) to configure the Cube update mode per agent.

### Fixes

#### QActionHelper DLL file could incorrectly be loaded twice \[ID_32647\]

In some rare cases, protocols could incorrectly load the QActionHelper DLL file twice.

#### DataMiner Cube - ListView component: Time zone would not be taken into account when setting the default time range interval \[ID_33011\]

When the client and the server did not have the same time zone, in some cases, the default time range interval of a ListView component could be set incorrectly. As a result, filtering by date/time could yield incorrect results.

From now on, the default time range of a ListView component will take into account the DataMiner time in UTC and the server time zone.

#### Hysteresis timer would incorrectly restart when a base line got updated \[ID_33015\]

When a base line got updated while a hysteresis timer was running on a table cell, in some cases, that timer would incorrectly restart.

#### Dashboards app - Node edge graph component: Node would not get positioned correctly by default \[ID_33068\]

Up to now, when the edges were unidirectional, the nodes would not get positioned correctly by default.

#### DataMiner Cube - Resources app: No update notifications would get broadcast within a client session when a resource was deleted from the cache \[ID_33070\]

When a resource was deleted from the cache of a Cube client, in some cases, no update notifications would get broadcast within the same client session.

#### Ticketing app: Problem when using the filter box \[ID_33079\]

When you entered a search string in the filter box, all tickets would incorrectly be returned.

#### DataMiner Cube - Automation: Problem when validating an Automation script \[ID_33084\]

When, in the Automation app, you validated an Automation script that either contained an empty line in the DLL references or had a DLL reference removed, in some cases, an “Empty path name is not legal” error could be thrown.

#### DataMiner Cube: REPORTS page of a masked element would incorrectly indicate that the element was in alarm instead of masked \[ID_33087\]

When you masked an alarm as well as its associated element, in DataMiner Cube, the REPORTS page of the element in question would incorrectly indicate that the element was in alarm instead of masked.

#### Business Intelligence: Problem with SLProtocol when an SLA or an element in a service tracked by an SLA was being (re)started \[ID_33098\]

In some cases, an error could occur in SLProtocol when an SLA or an element in a service tracked by an SLA was being (re)started.

Also, additional logging has been added to help debug and track SLA issues.

#### SLElement: Display key cache would not get properly cleaned up when a row was deleted \[ID_33114\]

In some cases, the display key cache of SLElement would not get properly cleaned up when a row was deleted. This could cause memory leaks when a protocol added or removed a large amount of rows.

#### DataMiner Cube - Visual Overview: Bitmap images would be missing when opening a cached version of a VDX file \[ID_33116\]

When a Visio file of type VDX contained bitmap images, in some cases, those images would be missing when you opened a cached version of that file.

#### DataMiner Agent would not start up when the computer name contained special characters \[ID_33137\]

In some cases, a DataMiner Agent would fail to start up when the computer name contained special characters (e.g. “ü”).

#### Dashboards app - GQI: Problem when a feed used by a query was changed while the query table was being sorted \[ID_33168\]

When a feed used by a GQI query was changed while the query table was being sorted, in some cases, the UI could become unresponsive.

#### Web apps - GQI: Column references could not be created for columns of which the name contained underscore characters \[ID_33169\]

In some cases, column references could not be created for columns of which the name contained underscore characters.

#### Web apps - GQI: Problem when retrieving ticket fields of type 'drop-down list' \[ID_33177\]

When ticket fields of type “drop-down list” were retrieved using a GQI query, in some cases, those fields would incorrectly not contain any values.

#### Visual Overview: Problems with SelectedServiceDefinition session variable and with commands for ServiceManager component \[ID_33188\]

The following issues could occur in Visual Overview:

- When a service definition was selected, it could occur that the *SelectedServiceDefinition* session variable was not updated.

- When the *Commands* shape data field was used, it could occur that setting commands on page or card level was not possible.

#### SNMP polling: Group with multiple tables of which some had the 'partialSNMP' option enabled would get re-polled indefinitely \[ID_33197\]

When a group that contained multiple tables of which some had the partialSNMP option enabled was polled, in some cases, that same group would incorrectly get re-polled indefinitely.

#### DataMiner Cube: Problem when logging in \[ID_32233\]

When you logged in to DataMiner Cube, in some cases, the loading process would no longer be shown. Also, a “Timeout while retrieving connection settings” error could be thrown.

#### Port 0 would incorrectly be used for serial communication when a dynamic IP parameter did not contain an IP port \[ID_33235\]

When a dynamic IP parameter was set to a value that contained only an IP address instead of an IP address and a IP port, then port 0 would incorrectly be used for serial communication.

From now on, when no IP port is specified, the last port set will be used. And if no port has been set yet, then the port configured in the element wizard will be used.

#### Application framework: Pages could not be loaded when previewing a draft version of an application that had not yet been published \[ID_33241\]

When previewing a draft version of an application, in some cases, pages could not be loaded when there was no published version yet.

#### Application framework: 'This panel' option not available when configuring a 'close a panel' action \[ID_33243\]

When configuring a “close a panel” action, in some cases, the “This panel” option would incorrectly not be available. From now on, this option will always be available and selected by default.

#### Application framework: Application would incorrectly open in edit mode after logging in \[ID_33254\]

When you logged out of an application and then logged back in again, in some cases, the application would incorrectly switch to edit mode.

#### PDF reports generated from a dashboard could no longer be uploaded to a shared folder \[ID_33256\]

When a PDF report was generated from a dashboard, in some cases, it would not be possible to upload that report to a shared folder.

#### Application framework: Table row action buttons would incorrectly always be displayed on the first column of a table \[ID_33258\]

Up to now, table row action buttons would incorrectly always be displayed on the first column of a table. As a result, those buttons would disappear when e.g. a filter was applied that caused the first column to be hidden. From now on, table row action buttons will instead always be displayed on the first visible column of a table.

#### Application framework: An 'http://' prefix would incorrectly be added to any URL that did not start with 'http://' \[ID_33262\]

Up to now, the application framework would incorrectly add an “http://” prefix to any URL that did not start with “http://”. From now on, all URLs will be validated first. Only if the URL is invalid (e.g. “skyline.be”) will an “http://” prefix be added.

#### Problem when trying to retrieve base parameter values after changing the production version of a protocol based on a base protocol \[ID_33288\]

After changing the production version of a protocol based on a so-called base protocol, it would no longer be possible to retrieve values from any of the base parameters (i.e. parameters of the base protocol).

#### Application framework: Minor issues fixed \[ID_33291\]

A number of minor issues have been fixed in the DataMiner Application Framework.

#### BREAKING CHANGE: Problem when filtering a table with a foreign key relation to a remote table using a filter that contained a value from the remote table \[ID_33294\]

When a table with a foreign key relation to a remote table was filtered using a filter that contained a value from the remote table, up to now, all rows would incorrectly be returned when the remote table was empty. From now on, when the remote table is empty, no rows will be returned.

#### DataMiner Cube - Trending: Problem when zooming out on a trend graph \[ID_33298\]

When you zoomed out on a trend graph with a large number of data points, in some cases, the UI would become unresponsive.

#### Problem with SLDataMiner when a DMA started up while another DMA in the DMS was registering the SLAs \[ID_33303\]

When a DataMiner Agent started up while another DataMiner Agent in the DMS was registering the SLAs, in some cases, an error could occur in the SLDataMiner process.

#### Filtering issue when requesting bookings from 2 different time ranges \[ID_33312\]

When bookings were requested from the server, and a filter was used to first retrieve bookings from the distant future and then from the near future, it could occur that the latter could not be retrieved because of a problem with the filtering.

#### Application framework: Table rows sorted incorrect after refetching the table data \[ID_33323\]

When a table component refetched the table data, in some cases, the table rows would not be sorted correctly.

#### Remote direct views would no longer work when the DirectViewRemoteDataUpdates soft-launch option was disabled \[ID_33326\]

Remote direct views would no longer work when the DirectViewRemoteDataUpdates soft-launch option was disabled.

#### Web apps - Data table component: Query placeholders would incorrectly be displayed as values when the GQI query did not return any rows \[ID_33372\]

When a GQI query did not return any rows, the data table component would incorrectly display the query placeholders as values. From now on, when a GQI query does not return any rows, the data table component will display a message, saying that no data is available.
