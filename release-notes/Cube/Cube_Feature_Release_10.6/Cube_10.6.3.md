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

### Fixes

#### Alarm Console: Recursive loop in nested correlated alarms could cause Cube to stop working [ID 44378]

<!-- MR 10.5.0 [CU12] / 10.6.0 [CU0] - FR 10.6.3 -->

Up to now, a recursive loop in nested correlation alarms could cause DataMiner Cube to stop working unexpectedly.

From now on, when a recursive loop is detected in nested correlation alarms, an entry will be added to the Cube logging and DataMiner Cube will continue to work.

#### CRL freeze message could cause asynchronous calls in the background thread to get blocked [ID 44408]

<!-- MR 10.5.0 [CU12] / 10.6.0 [CU0] - FR 10.6.3 -->

When Cube experiences a CRL freeze, a message box will appear, explaining what can be done to prevent this.

Up to now, this message box, which is created in the background thread, could cause asynchronous calls in that thread to get blocked. From now on, although it will still be created in the background thread, it will no longer cause any asynchronous calls to get blocked.
