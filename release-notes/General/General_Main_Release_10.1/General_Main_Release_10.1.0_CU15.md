---
uid: General_Main_Release_10.1.0_CU15
---

# General Main Release 10.1.0 CU15

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Security enhancements \[ID_33014\]

A number of security enhancements have been made.

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

#### Monitoring app now also takes into account Param.Message tags \[ID_33162\]

In a protocol.xml file, for every write parameter, you can specify a message to be displayed when users change that parameter on the UI.

Up to now, this *Param.Message* tag was only taken into account by DataMiner Cube. From now on, the Monitoring app will also take it into account.

#### SLDMS process is now large address aware \[ID_33234\]

SLDMS, which is a 32-bit process, will now be started with the /LARGEADDRESSAWARE flag. This way, it will be able to access up to 4GB of memory.

#### Enhanced performance when processing a large number of objects with links to other objects \[ID_33271\]

Because of a number of enhancements, overall performance has increased when processing (e.g. exporting) a large number of objects with links to other objects.

#### IPC channel port names will now always be unique \[ID_33274\]

IPC channel port names will now always be unique.

### Fixes

#### QActionHelper DLL file could incorrectly be loaded twice \[ID_32647\]

In some rare cases, protocols could incorrectly load the QActionHelper DLL file twice.

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

#### SNMP polling: Group with multiple tables of which some had the 'partialSNMP' option enabled would get re-polled indefinitely \[ID_33197\]

When a group that contained multiple tables of which some had the partialSNMP option enabled was polled, in some cases, that same group would incorrectly get re-polled indefinitely.

#### Interactive Automation scripts: Slider linked to a numeric text box would incorrectly keep following the mouse pointer \[ID_33204\]

In interactive Automation scripts, in some cases, the slider linked to a numeric text box would incorrectly keep following the mouse pointer, even after the mouse button had been released.

#### Port 0 would incorrectly be used for serial communication when a dynamic IP parameter did not contain an IP port \[ID_33235\]

When a dynamic IP parameter was set to a value that contained only an IP address instead of an IP address and a IP port, then port 0 would incorrectly be used for serial communication.

From now on, when no IP port is specified, the last port set will be used. And if no port has been set yet, then the port configured in the element wizard will be used.

#### Problem when trying to retrieve base parameter values after changing the production version of a protocol based on a base protocol \[ID_33288\]

After changing the production version of a protocol based on a so-called base protocol, it would no longer be possible to retrieve values from any of the base parameters (i.e. parameters of the base protocol).

#### BREAKING CHANGE: Problem when filtering a table with a foreign key relation to a remote table using a filter that contained a value from the remote table \[ID_33294\]

When a table with a foreign key relation to a remote table was filtered using a filter that contained a value from the remote table, up to now, all rows would incorrectly be returned when the remote table was empty. From now on, when the remote table is empty, no rows will be returned.

#### DataMiner Cube - Trending: Problem when zooming out on a trend graph \[ID_33298\]

When you zoomed out on a trend graph with a large number of data points, in some cases, the UI would become unresponsive.

#### Problem with SLDataMiner when a DMA started up while another DMA in the DMS was registering the SLAs \[ID_33303\]

When a DataMiner Agent started up while another DataMiner Agent in the DMS was registering the SLAs, in some cases, an error could occur in the SLDataMiner process.
