---
uid: Cube_Feature_Release_10.5.2
---

# DataMiner Cube Feature Release 10.5.2

This Feature Release of the DataMiner Cube client application contains the same new features, enhancements, and fixes as DataMiner Cube Main Release 10.4.0 [CU11].

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.5.2](xref:General_Feature_Release_10.5.2).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.5.2](xref:Web_apps_Feature_Release_10.5.2).

## New features

#### Sidebar: Community menu now contains a link to the DataMiner feedback form [ID 41605]

<!-- MR 10.4.0 [CU11] / 10.5.0 [CU0] - FR 10.5.2 -->

When you click the *Community* button at the bottom of DataMiner Cube's sidebar, you can now select *Feedback* to open a [form](https://aka.dataminer.services/feedback-cube) in which you can provide us with valuable information that will help us improve our software.

## Changes

### Enhancements

#### Data Display: Clearer message will now be shown while an element is being swarmed [ID 41538]

<!-- MR 10.4.0 [CU11] / 10.5.0 [CU0] - FR 10.5.2 -->

While an element was being swarmed, up to now, Cube would show the following message:

`xxxx is currently switching`

From now on, it will show the following message instead:

`xxx is currently swarming`

#### DataMiner Cube desktop app: Enhanced performance when starting up [ID 41532]

<!-- MR 10.4.0 [CU11] / 10.5.0 [CU0] - FR 10.5.2 -->

Because of a number of enhancements, overall performance of the DataMiner Cube desktop app has improved, especially at startup.

#### Swarming: UI enhancements [ID 41589]

<!-- MR 10.4.0 [CU11] / 10.5.0 [CU0] - FR 10.5.2 -->

A number of enhancements have been made to the *Element Swarming* window:

- When you had selected a number of elements in the *Element Swarming* window, and then created or deleted an element in either the same client or another client, up to now, the element selection in the *Element Swarming* window would incorrectly be cleared.

- Up to now, when you closed the *Element Swarming* window while a swarming operation was in progress and then opened it again, the progress bar would no longer get updated.

- From now on, the progress bar will show a percentage without decimals.

#### Visual Overview: Enhanced performance when loading inline visual overviews [ID 41590]

<!-- MR 10.4.0 [CU11] / 10.5.0 [CU0] - FR 10.5.2 -->

Because of a number of enhancements, overall performance has increased when loading inline visual overviews.

#### Data Display: Table layout changes will now be saved automatically [ID 41608]

<!-- MR 10.4.0 [CU11] / 10.5.0 [CU0] - FR 10.5.2 -->

Up to now, when you rearranged the columns of a table, you had to right-click in the table header and select *Columns > Save layout* to save the changes you made. From now on, when you rearrange the columns of a table, the changes will be saved automatically.

#### About box: Enhancements made to 'License' tab [ID 41654]

<!-- MR 10.4.0 [CU11] / 10.5.0 [CU0] - FR 10.5.2 -->

A number of enhancements have been made with regard to the listing of license information in the *License* tab of the *About* box.

#### Security enhancements [ID 41655]

<!-- 41655: MR 10.4.0 [CU11] / 10.5.0 [CU0] - FR 10.5.2 -->

A number of security enhancements have been made.

#### Visual Overview: Enhanced performance [ID 41668]

<!-- MR 10.4.0 [CU11] / 10.5.0 [CU0] - FR 10.5.2 -->

Because of a number of enhancements, overall performance of visual overviews has increased, especially when a large number of cards have been opened.

#### Automation app: Enhanced drag-and-drop of scripts between folders [ID 41678]

<!-- MR 10.4.0 [CU11] / 10.5.0 [CU0] - FR 10.5.2 -->

A number of enhancements have been made with regard to dragging and dropping automation scripts between folders.

For example, up to now, when you dragged a script from one folder to another after having selected another script first, in some cases, the script you had selected first would incorrect be moved to the other folder.

#### Swarming: Pressing CTRL+a now selects all elements [ID 41688]

<!-- MR 10.4.0 [CU11] / 10.5.0 [CU0] - FR 10.5.2 -->

In the *Element Swarming* window, it is now possible to select all elements by pressing CTRL+a.

#### Visual Overview - ListView component: Enhancements with regard to element or service property subscriptions [ID 41754]

<!-- MR 10.4.0 [CU11] / 10.5.0 [CU0] - FR 10.5.2 -->

A number of enhancements have been made to the *ListView* component with regard to element and service property subscriptions.

### Fixes

#### Visual Overview: Children shapes would be displayed twice [ID 41160]

<!-- MR 10.4.0 [CU11] / 10.5.0 [CU0] - FR 10.5.2 -->

When *Children* shapes were being loaded, in some cases, some shapes would incorrectly already be updated while loading was still in progress. As a result, some shapes would be displayed twice.

#### DataMiner Cube desktop app: Problem when starting an older version on a client on which a newer version has already been used [ID 41461]

<!-- MR 10.4.0 [CU11] / 10.5.0 [CU0] - FR 10.5.2 -->

When you started an older version of the DataMiner Cube desktop app on a client on which you had previously started a newer version of that same app, up to now, in some cases, the older version could update the desktop app configuration file, making it unusable for the newer version of the app.

From now on, when a newer version of the DataMiner Cube desktop app is found on a client, older versions of that same app will no longer be allowed to update the desktop app configuration file.

#### Alarm Console: Problem when an alarm tab and an AlarmSummary shape were being loaded simultaneously [ID 41484]

<!-- MR 10.4.0 [CU11] / 10.5.0 [CU0] - FR 10.5.2 -->

When, in the Alarm Console, an alarm tab was being loaded while, at the same time, a Visio shape containing a data field of type *AlarmSummary* was being loaded, in some cases, an exception could be thrown.

#### Protocols & templates: Problem when an update was received from the DMA while you were navigating through the app [ID 41494]

<!-- MR 10.4.0 [CU11] / 10.5.0 [CU0] - FR 10.5.2 -->

When, in the *Protocols & templates* app, you had selected a protocol, a protocol version and a template in order to check the list of assigned elements, up to now, other items could incorrectly get selected when an update unrelated to any of the items you selected was received from the DataMiner Agent to which you were connected.

#### Parameter-specific template editor would not load the correct template data for a non-table parameter of a DVE child element [ID 41510]

<!-- MR 10.4.0 [CU11] / 10.5.0 [CU0] - FR 10.5.2 -->

When you opened a parameter-specific alarm, trend or information template editor for a non-table parameter in a DVE child element (which is a table parameter in the DVE parent element), up to now, the template data would not get loaded correctly.

#### Visual Overview: Problem with counter showing the number of masked alarms when an AlarmSummary shape was linked to all alarms [ID 41513]

<!-- MR 10.4.0 [CU11] / 10.5.0 [CU0] - FR 10.5.2 -->

When you had linked an *AlarmSummary* shape to all alarms (i.e. active alarms, masked alarms and information events) by adding a data field of type *AlarmSummary* set to "all", the counter showing the number of masked alarms in the shape text (i.e. "#Masked") would show an incorrect number of alarms.

#### DataMiner Cube desktop app: First instance would incorrectly open in system tray mode instead of windowed mode [ID 41532]

<!-- MR 10.4.0 [CU11] / 10.5.0 [CU0] - FR 10.5.2 -->

When you opened a first instance of the DataMiner Cube desktop app on a client computer, up to now, it would incorrectly open in system tray mode. From now on, it will open in windowed mode instead.

#### Alarm Console: Linked alarm tab could have incorrect alarm counters when a correlation alarm was cleared [ID 41547]

<!-- MR 10.4.0 [CU11] / 10.5.0 [CU0] - FR 10.5.2 -->

When, in a linked alarm tab, a correlation rule and its base alarms all matched the linked object, the alarm counters of that alarm tab would be incorrect when the correlation alarm was cleared while (some of) the base alarms remained active.

#### DataMiner Cube desktop app would not open when started from the DataMiner Taskbar Utility [ID 41556]

<!-- MR 10.4.0 [CU11] / 10.5.0 [CU0] - FR 10.5.2 -->

When you tried to open the DataMiner Cube desktop app from the DataMiner Taskbar Utility by selecting *Launch > DataMiner Cube*, the DataMiner Cube icon would appear in the system tray, but the app would incorrectly not be started.

#### Alarm Console: Cleared base alarm would incorrectly not be removed from an incident alarm [ID 41562]

<!-- MR 10.4.0 [CU11] / 10.5.0 [CU0] - FR 10.5.2 -->

When one of the base alarms of an incident alarm got cleared, in some cases, the incident alarm would incorrectly still show the cleared alarm as a base alarm.

#### DataMiner Cube desktop app: Problem when closing the app while configuration files were being updated [ID 41576]

<!-- MR 10.4.0 [CU11] / 10.5.0 [CU0] - FR 10.5.2 -->

When the DataMiner Cube desktop app was closed while its configuration files were being updated, in some cases, these files could get corrupted.

#### Correlation: Problem when correlation rules were updated in bulk [ID 41644]

<!-- MR 10.4.0 [CU11] / 10.5.0 [CU0] - FR 10.5.2 -->

When a number of correlation rules were updated in bulk, in some cases, some would either be skipped or not processed correctly.

#### Data Display: Thresholds shown in 'Templates' tab would be incorrect when the alarm template was part of a template group [ID 41645]

<!-- MR 10.4.0 [CU11] / 10.5.0 [CU0] - FR 10.5.2 -->

When, in Data Display, you double-clicked a parameter and then opened the *Templates* tab, the parameter thresholds would be incorrect when the alarm template was part of a template group.

#### Visual Overview - Children shape: Scale of automatically generated shapes would incorrectly be set to 0 [ID 41710]

<!-- MR 10.4.0 [CU11] / 10.5.0 [CU0] - FR 10.5.2 -->

In some cases, the scale of automatically generated shapes would incorrectly be set to 0, causing those shapes to not be visible.

#### Memory leak when logging out of DataMiner Cube [ID 41712]

<!-- MR 10.4.0 [CU11] / 10.5.0 [CU0] - FR 10.5.2 -->

When you logged out of DataMiner Cube, up to now, certain event handlers would leak memory.

#### Problem when trying to uninstall DataMinerCube.exe [ID 41802]

<!-- MR 10.4.0 [CU11] / 10.5.0 [CU0] - FR 10.5.2 -->

When you tried to uninstall the *DataMinerCube.exe* file from a client computer via *Control Panel\Programs\Programs and Features*, an error would occur, causing both the *DataMinerCube.exe* file and an associated scheduled task to not get removed.

#### Alarm Console: Alarms generated during the last week of 2024 would not be grouped correctly [ID 41830]

<!-- MR 10.4.0 [CU11] / 10.5.0 [CU0] - FR 10.5.2 -->

In the Alarm Console, alarms generated during the last week of 2024 (i.e. week 53) would not be grouped correctly.
