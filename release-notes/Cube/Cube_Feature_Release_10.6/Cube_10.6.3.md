---
uid: Cube_Feature_Release_10.6.3
---

# DataMiner Cube Feature Release 10.6.3 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

This Feature Release of the DataMiner Cube client application contains the same new features, enhancements, and fixes as DataMiner Cube Main Release 10.5.0 [CU12].

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.6.3](xref:General_Feature_Release_10.6.3).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.6.3](xref:Web_apps_Feature_Release_10.6.3).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

#### Trending: Enhanced performance when loading trend graphs [ID 44239]

<!-- MR 10.5.0 [CU12] / 10.6.0 [CU0] - FR 10.6.3 -->

Because of the introduction of a parameter cache, overall performance has increased when loading trend graphs.

When you start DataMiner Cube, you can disable this parameter cache by using the URL argument `EnableClientParameterCache=false`.

#### Scheduler module: A message box will now appear whenever an error occurs [ID 44334]

<!-- MR 10.5.0 [CU12] / 10.6.0 [CU0] - FR 10.6.3 -->

Up to now, the Scheduler module would not provide any feedback when an error occurred while retrieving, creating, updating, or deleting scheduled tasks. Although these errors were logged in the Cube logging, the user would not get any notification.

From now on, whenever an error occurs while you are interacting with the Scheduler module, a message box will appear, notifying that something went wrong.

#### Scheduler module: Enhanced performance when opening the module [ID 44414]

<!-- MR 10.5.0 [CU12] / 10.6.0 [CU0] - FR 10.6.3 -->

Because of a number of enhancements, especially to the way in which script information of scheduled tasks is loaded, overall performance has increased when opening the Scheduler module.

#### Automation: Viewing the log file of a script will only be possible when a script has a log file [ID 44439]

<!-- MR 10.5.0 [CU12] / 10.6.0 [CU0] - FR 10.6.3 -->

When, in System Center, you viewed automation script logging, up to now, all scripts would be listed. This could cause users to try to view non-existing logs. For example, automation scripts that only contain library blocks do not have a dedicated log file.

From now on, when Cube is connected to a DataMiner Agent running DataMiner main release 10.7.0 or feature release 10.6.2 (or above), only automation scripts that contain at least one executable C# block will allow user to view their log file.

This change applies to the following ways to access a log file:

- Clicking the *View Log* button in the script editor.
- Right-clicking a script and selecting the *View Log* menu option.
- Viewing the Automation log page in System Center.

#### System Center - Logging: Scripting entry removed from DataMiner tab [ID 44467]

<!-- MR 10.5.0 [CU12] / 10.6.0 [CU0] - FR 10.6.3 -->

When, in *System Center*, you open the *Logging* section, and click the *DataMiner* tab, you can select a particular log file from the list.

Up to now, this log file list contained a *Scripting* entry. However, as no *SLScripting.txt* log file exists, this entry has now been removed.

#### Connection type will always be set to gRPC when connecting to a DMA that is connected to dataminer.services [ID 44547]

<!-- MR 10.5.0 [CU12] / 10.6.0 [CU0] - FR 10.6.3 -->

When Cube connects to a DMA that is connected to dataminer.services (i.e. a DMA of which the hostname ends with ".dataminer.services"), the connection will always be of type gRPC, whatever the connection type that is specified in the Cube settings.

#### Initialization exceptions thrown by the Microsoft Edge browser engine will now be added to the Cube logging [ID 44549]

<!-- MR 10.5.0 [CU12] / 10.6.0 [CU0] - FR 10.6.3 -->

From now on, all initialization exceptions thrown by the Microsoft Edge (WebView2) browser engine will be added to the Cube logging. This will make it easier to investigate any issues that might occur.

#### System Center - Search & Indexing: Migrating booking data from Cassandra Single to indexing database is no longer supported [ID 44550]

<!-- MR 10.5.0 [CU12] / 10.6.0 [CU0] - FR 10.6.3 -->

From now on, it will no longer be possible to migrate booking data from a Cassandra database per DMA to an indexing database.

Up to now, in DataMiner Cube, the *Migrate booking data to Indexing Engine*, found in *System Center > Search & Indexing*, allowed you to migrate older booking data (i.e. from prior to DataMiner 10.0) stored in a Cassandra database per DMA to the indexing database. From now on, when Cube is connected to a DMA running DataMiner 10.6.0 [CU0]/10.6.3 or newer, this option will no longer be available.

#### Microsoft Edge (WebView2) browser engine can now also be installed on a per user basis [ID 44580]

<!-- MR 10.5.0 [CU12] / 10.6.0 [CU0] - FR 10.6.3 -->

On systems running the Windows Server OS, the Microsoft Edge (WebView2) browser engine is not installed by default. On these systems, it has to be installed manually. Up to now, it would only be possible to install it system wide. From now on, it will also be possible to install it on a per user basis. However, a system-wide installation is recommended.

- A warning will now be added to the Cube logging when Cube has detected that the Microsoft Edge browser engine was installed on a per user basis rather than system wide. The message will indicate that system-wide installation is strongly recommended.

- An SPI log entry named *WebView2Source* will now be added to provide more information on how the Microsoft Edge browser engine was installed.

  This log entry will contain the following data:

  - IsInstalled (*True* or *False*)
  - Installation type (*Undefined*, *System wide*, *Per user*, or *Fixed version*)
  - Version number
  - Location (i.e. the local path to the browser engine folder)

- The NuGet package *Microsoft.Web.WebView2* has been upgraded to version 1.0.3650.58.

#### Visual Overview: Support for table-based matrices [ID 44601]

<!-- MR 10.5.0 [CU12] / 10.6.0 [CU0] - FR 10.6.3 -->

Up to now, when you linked shapes to inputs and outputs of a table-based matrix, these inputs and outputs would not be displayed correctly.

From now on, it will be possible to link shapes to inputs and outputs of table-based matrices. The inputs and outputs will be displayed correctly, and it will be possible to alter the connections via the context menu. In the context menu, the outputs and inputs will be shown in the same order as the rows in the table.

Also, the alarm colors shown in visual overviews will be identical to those in table-based matrices displayed in Data Display. The connection between an input and an output will have the alarm color of the corresponding output row.

> [!NOTE]
> In visual overviews used in web apps, as from version 10.6.0/10.6.3, the connections and alarm colors of table-based matrices will also be displayed correctly, but it will not be possible to alter connections using the context menu.
> Visual overviews used in web apps will not support table-based matrices in version 10.5.0 CU12.

#### Spectrum analysis: Enhancements with regard to selecting arguments in spectrum monitor scripts [ID 44650]

<!-- MR 10.5.0 [CU12] / 10.6.0 [CU0] - FR 10.6.3 -->

A number of enhancements have been made with regard to selecting arguments in spectrum monitor scripts:

- The default range of number values has increased from 11 billion to 1 quadrillion.

  This will make it possible to configure values greater than 100 MHz.

- The sleep value (in milliseconds) can no longer be negative, and is limited to 10 seconds.

- A unit has now been added to the *Create frequency reference*, *Create amplitude reference*, and *Sleep* labels.
  
  | Label | Unit |
  |-------|------|
  | Create frequency reference | Hz |
  | Create amplitude reference | dB |
  | Sleep | ms |

### Fixes

#### Alarm Console: Recursive loop in nested correlated alarms could cause Cube to stop working [ID 44378]

<!-- MR 10.5.0 [CU12] / 10.6.0 [CU0] - FR 10.6.3 -->

Up to now, a recursive loop in nested correlation alarms could cause DataMiner Cube to stop working unexpectedly.

From now on, when a recursive loop is detected in nested correlation alarms, an entry will be added to the Cube logging and DataMiner Cube will continue to work.

#### CRL freeze message could cause asynchronous calls in the background thread to get blocked [ID 44408]

<!-- MR 10.5.0 [CU12] / 10.6.0 [CU0] - FR 10.6.3 -->

When Cube experiences a CRL freeze, a message box will appear, explaining what can be done to prevent this.

Up to now, this message box, which is created in the background thread, could cause asynchronous calls in that thread to get blocked. From now on, although it will still be created in the background thread, it will no longer cause any asynchronous calls to get blocked.

#### Alarm Console: Problem when updating an incident alarm [ID 44425]

<!-- MR 10.5.0 [CU12] / 10.6.0 [CU0] - FR 10.6.3 -->

As the severity of an incident alarm is the highest severity found among its source alarms, that severity has to be recalculated each time the incident alarm is updated. Up to now, when an incident alarm was updated, in some rare cases, exceptions could be thrown.

#### Visual Overview - AlarmSummary: Correlated alarm would incorrectly not be removed from the summary when the element state changed [ID 44480]

<!-- MR 10.5.0 [CU12] / 10.6.0 [CU0] - FR 10.6.3 -->

When an *AlarmSummary* shape was linked to an object (e.g. an element, a service, or a view), and that object contained a correlated alarm, up to now, that correlated alarm would not be removed from the summary when the element associated with the correlated alarm had its status set to "Paused", "Stopped", or "Deleted".

From now on, correlated alarms will be removed from the summary when the status of the elements associated with those correlated alarms changes.

#### System Center - Logging: Selecting 'Alarm Level Forwarding' in the DataMiner tab would open an incorrect log file [ID 44548]

<!-- MR 10.5.0 [CU12] / 10.6.0 [CU0] - FR 10.6.3 -->

When, in *System Center*, you open the *Logging* section, and click the *DataMiner* tab, you can select a particular log file from the list.

Up to now, when you clicked the *Alarm Level Forwarding* entry, the *SLAlarmLevelLinking.txt* log file would incorrectly be opened instead of the *SLAlarmForwarding.txt* log file.

#### Alarm Console: Correlation base alarms would incorrectly be displayed next to the correlated alarm [ID 44610]

<!-- MR 10.5.0 [CU12] / 10.6.0 [CU0] - FR 10.6.3 -->

In the Alarm Console, in some cases, correlation base alarms would incorrectly be displayed next to the correlated alarm in the same alarm tab.

#### Alarm Console: Severity of an alarm group would incorrectly be changed when an action was performed on it [ID 44630]

<!-- MR 10.5.0 [CU12] / 10.6.0 [CU0] - FR 10.6.3 -->

When you acknowledged an alarm on an alarm group (or performed any other action on it), up to now, the severity of the alarm group would incorrectly always be set to that of the source alarm with the highest severity. From now on, when an action is performed on an alarm group, its severity will no longer be changed.
