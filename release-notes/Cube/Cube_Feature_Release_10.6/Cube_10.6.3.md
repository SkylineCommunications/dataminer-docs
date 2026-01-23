---
uid: Cube_Feature_Release_10.6.3
---

# DataMiner Cube Feature Release 10.6.3 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

This Feature Release of the DataMiner Cube client application contains the same new features, enhancements, and fixes as DataMiner Cube Main Release 10.5.0 [CU12].

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.6.2](xref:General_Feature_Release_10.6.2).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.6.2](xref:Web_apps_Feature_Release_10.6.2).

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

#### Automation: Viewing the log file of a script will only be possible when a script has a log file [ID 44439]

<!-- MR 10.5.0 [CU12] / 10.6.0 [CU0] - FR 10.6.3 -->

When, in System Center, you viewed Automation script logging, up to now, all scripts would be listed. This could cause users to try to view non-existing logs. For example, Automation scripts that only contain library blocks do not have a dedicated log file.

From now on, when Cube is connected to a DataMiner Agent running DataMiner main release 10.7.0 or feature release 10.6.2 (or above), only Automation scripts that contain at least one executable C# block will allow user to view their log file.

This change applies to the following ways to access a log file:

- Clicking the *View Log* button in the script editor.
- Right-clicking a script and selecting the *View Log* menu option.
- Viewing the Automation log page in System Center.

#### System Center - Logging: Scripting entry removed from DataMiner tab [ID 44467]

<!-- MR 10.5.0 [CU12] / 10.6.0 [CU0] - FR 10.6.3 -->

When, in *System Center*, you open the *Logging* section, and click the *DataMiner* tab, you can select a particular log file from the list.

Up to now, this log file list contained a *Scripting* entry. However, as no *SLScripting.txt* log file exists, this entry has now been removed.

#### Enhanced performance when loading alarm properties into filtered alarm tabs or when loading alarm data into AlarmSummary shapes [ID 44536]

<!-- MR 10.5.0 [CU12] / 10.6.0 [CU0] - FR 10.6.3 -->

Because of a number of enhancements, overall performance has increased when loading alarm properties into filtered alarm tabs or when loading alarm data into AlarmSummary shapes.

### Fixes

#### Visual Overview: UI could become unresponsive when parameter subscriptions occurred for conditions with parameter-based criteria [ID 44365]

<!-- MR 10.5.0 [CU12] / 10.6.0 [CU0] - FR 10.6.3 -->

Up to now, when conditions contained parameter-based criteria, the parameter subscriptions would occur in the UI thread. In some cases, this would cause the UI to become unresponsive. From now on, these parameter subscriptions will occur in a background thread instead.

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
