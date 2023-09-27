---
uid: General_Main_Release_10.0.0_CU12
---

# General Main Release 10.0.0 CU12

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### SLDMS: Enhanced processing of DMS_SECURITY_NO_FORWARD messages \[ID_28796\]

Due to a number of enhancements, the way in which SLDMS processes DMS_SECURITY_NO_FORWARD messages has been optimized.

#### DataMiner Cube - Visual Overview: Unselecting a table row with the SingleSelection option enabled will now also clear the session variable \[ID_28848\]

In situations involving a table with columns that have a SelectionSetVar option configured and an embedded table control in Visual Overview with a SingleSelection option specified in its ParameterControlOptions data field, up to now, the session variable would not be updated when the selection was cleared.

From now on, the session variable will be cleared when you click the selected table row while holding down the CTRL key.

#### DataMiner Cube: SurveyorSearchText session variable will now be cleared when the advanced search tab is closed \[ID_28851\]

With the SurveyorSearchText session variable, you can configure a shape to display the most recently used search entry in the Surveyor, or to trigger a search in the Surveyor with a particular search entry.

From now on, this session variable will be cleared when the advanced search tab is closed.

#### Size of C:\\Skyline DataMiner\\Logging\\MiniDump folder limited to 1 GB or 100 files \[ID_28879\]

The size of the C:\\Skyline DataMiner\\Logging\\MiniDump folder is now limited to 1 GB or 100 files (whichever is larger).

When a new ZIP file is created when the folder size is at its limit, the oldest ZIP file(s) in the folder will automatically be deleted.

#### SLNet connections for BPA tests will no longer be logged in SLClient.txt \[ID_28890\]

From now on, by default, SLNet connections set up for BPA tests will no longer be logged in SLClient.txt.

#### Cassandra: Logging will now include health status transitions and failed queries \[ID_28913\]

Cassandra health status transitions and failed queries will now also be logged in the SLDBConnection.txt log file.

#### Sidebar: New help button to open DataMiner Dojo menu \[ID_28990\]

At the bottom of the sidebar, you can now click a help button that will open a menu containing links to the following pages on DataMiner Dojo:

| Menu command    | Page on DataMiner Dojo                                      |
|-----------------|-------------------------------------------------------------|
| Blog            | <https://community.dataminer.services/blog/>                |
| Questions       | <https://community.dataminer.services/questions/>           |
| Learning        | <https://community.dataminer.services/learning/>            |
| Resources       | <https://community.dataminer.services/documentation/>       |
| Suggest feature | <https://community.dataminer.services/feature-suggestions>  |

#### DataMiner Cube - Alarm Console: Enhanced performance when updating the source values of a Correlation base alarm \[ID_29020\]

Due to a number of enhancements, overall performance has increased when updating the source values of a Correlation base alarm.

#### Failover: Enhanced version check during synchronization \[ID_29077\]

When two agents in a Failover setup synchronize, their DataMiner versions are compared to make sure those versions are compatible. A number of enhancements have now been made to this version check.

### Fixes

#### Problem when multiple network interfaces shared the same MAC address \[ID_27971\]

When multiple network interfaces shared the same MAC address, in some cases, DataMiner would not be able to correctly detect those interfaces.

#### Service & Resource Management: Exported protocol would show incorrect parameters after a new function file had been activated \[ID_28290\]

When a new function file was activated, which updated parameters for a particular function, in some cases, the exported protocol would incorrectly show the old parameters.

#### DataMiner Cube: Problem when navigating using breadcrumbs \[ID_28468\]

In some cases, the overall element state of a partially included element would incorrectly be visible in the breadcrumbs. Also, users would incorrectly be able to open the full element via the breadcrumbs, even when they did not have full access to that element.

And when they used the breadcrumbs to navigate to the element via the service child, the element would incorrectly be opened instead of the service.

#### Alarm templates: Problem when calculating the transition from one week to the next \[ID_28477\]

In some cases, an error could occur when, in the alarm template schedule, the transition from one week to the next was calculated.

#### Timetrace data would become incorrect when an element had been dynamically included in or excluded from a service \[ID_28777\]

When an element had dynamically been included in or excluded from a service while active alarms were present, in some cases, the alarm count for the service in timetrace would start to show an incorrect value.

Also, when an element was excluded from a service while it had active alarms, in some cases, SLDataGateway would incorrectly consider the alarm reference to have an impact on the service. When the alarm was cleared while the element was excluded, it would never be removed from the service alarm impact list. As a result, that list could keep growing, which would eventually lead to an overall decrease of the alarm handling performance.

#### DataMiner Cube: Element name and icon would be incorrectly be visible in the alarm card and the alarm details when you did not have explicit access to the element \[ID_28778\]

In some cases, alarms for an element that is partially included in a service would be visible in the Alarm Console even when you did not have explicit access to that element. Also, when you opened the alarm card or the alarm details of one of those alarms, the element icon, alarm state and name would be displayed.

From now on, this will no longer the case when you do not have access to the element itself. Also, you will no longer be able to an element card of an element to which you do not have explicit access.

#### DataMiner Cube - Trend templates: Problem with 'Allow offload database configuration' setting \[ID_28794\]

When, in a trend template, you changed the Allow offload database configuration setting, in some cases, the setting would not be applied correctly.

#### Problem when launching Automation scripts when switching elements in a redundancy group that contained DELT elements \[ID_28832\]

When Automation scripts were launched when switching elements in a redundancy group of which either the primary or backup elements were DELT elements, in some cases, it would not be possible to pass \<Any Primary> or \<Any backup> as dummies.

#### Element log file would not be properly restarted on element restart \[ID_28841\]

In some cases, the element log file would not be properly restarted on element restart.

#### SLNet cache would throw exceptions when receiving NULL data \[ID_28859\]

In some cases, the SLNet cache would thrown exceptions when receiving NULL data. In DataMiner, those exceptions would then appear as alarms of type error.

From now on, the SLNet cache will ignore any NULL data it receives.

#### Problem with SLAutomation when an interactive Automation script was communicating with a client app \[ID_28862\]

When an interactive Automation script was communicating with the client app, in some cases, an error could occur in SLAutomation.

#### DataMiner Cube - Interactive Automation scripts: Multiple 'Continue' messages would be sent to the DataMiner Agent \[ID_28872\]

When an interactive Automation script was running, DataMiner Cube would incorrectly send multiple identical “Continue” messages to the DataMiner Agent. In some cases, this would cause an error in SLAutomation.

#### DataMiner Cube - Visual Overview: Problem when pressing CTRL+TAB while an item inside a Visio page had the focus \[ID_28876\]

When you pressed CTRL+TAB while an item inside a Visio page had the focus, in some cases, an exception could be thrown.

#### Legacy Reporter: Service definition image in the 'Booking Details' report would exceed the width of the report \[ID_28886\]

In the legacy Reporter, the service definition image in the “Booking Details” report would exceed the width of the report. That image has now been assigned a maximum width.

#### Problem in SLElement when recalculating alarm statuses while retrieving view data \[ID_28892\]

In some cases, an error could occur in SLElement when recalculating the alarm status for virtual function impact changes while retrieving view data.

#### Failover: Problem with failing heartbeats when agents were unreachable \[ID_28900\]

When checking Failover agent connectivity through heartbeats, failures could be registered even when the heartbeats succeeded. In some cases, this could lead to “Failing Heartbeat Path” notices being toggled indefinitely.

#### Problem when a cell in a table included in a virtual function was invalidated while the state of the service that included the virtual function was being changed \[ID_28911\]

In some cases, an error could occur when a cell in a table that was included in a virtual function was invalidated while the state of the service that included the virtual function was being changed.

#### DataMiner Cube: Scheduler permissions would not include the timeline \[ID_28944\]

Up to now, the user permissions that control access to the Scheduler app would incorrectly not control access to the timeline view.

The following table lists the timeline actions users will now be allowed to perform when they have been granted a particular Scheduler user permission.

| User permission                 | Action a user is allowed to perform              |
|---------------------------------|--------------------------------------------------|
| Modules \> Scheduler \> Add     | Drop events on the timeline.                     |
| Modules \> Scheduler \> Delete  | Delete events on the timeline.                   |
| Modules \> Scheduler \> Edit    | Edit or move events on the timeline.             |
| Modules \> Scheduler \> Execute | Manually start or stop an event on the timeline. |

#### Service & Resource Management: Problem with GetEligibleResources calls \[ID_28960\]

In some cases, a GetEligibleResources call could incorrectly return resources that were not available due to a concurrency overflow.

Also, in some cases, a GetEligibleResources call would not return resources that were available because the system would incorrectly think no more capacity was available.

#### DataMiner Cube: A 'debug.log' file would incorrectly be created when initializing the CefSharp library \[ID_28963\]

In some cases, a “debug.log” file would incorrectly be created in the %LocalAppData%\\Skyline\\DataMiner\\DataMinerCube folder when the CefSharp library was initialized.

#### Problem with overall performance of SLNet connections \[ID_28976\]

In some cases, the overall performance of connections between SLNet and DataMiner clients would decrease.

#### DataMiner Cube - Alarm Console: Problem when using the history slider on systems with a Cassandra database \[ID_28982\]

When, on a system using a Cassandra database, you moved the history slider, in some cases, the HistoryAlarmRequest that was sent would contain an incorrectly converted timestamp.

#### DataMiner Cube - Alarm Console: Problem when some entries in an alarm tree matched an alarm filter while other entries did not \[ID_29011\]

When, in the same alarm tree, some entries matched an alarm filter while other entries did not, in some cases, that alarm would incorrectly not be shown.

#### Updating an element via a CSV export/import would not work properly when that element had an empty port type value \[ID_29052\]

When an element had an empty port type value, in some cases, trying to edit that element by exporting its data to a CSV file and then importing the updated CSV file would not work as expected.

#### Problem when assigning an alarm template group to a DVE element \[ID_29063\]

When you assigned an alarm template group to a DVE element, no alarms would be generated.

#### ProtocolThread run-time error could occur when an element with a serial connection was paused \[ID_29083\]

In some cases, a ProtocolThread run-time error could occur when an element with a serial connection was paused.

#### Memory leak in SLXml when registered objects were removed \[ID_29091\]

In some cases, the SLXml process could leak memory when registered objects were removed.

#### DataMiner Cube - Alarm Console: Incorrect alarm count when loading a history tab with an element filter while some alarms in the time range were still active \[ID_29106\]

When you loaded a history tab with an element filter while some of the alarms in the selected time range were still active, in some cases, the tab header would show an incorrect alarm count.

#### Failover: LDAP notification setting would incorrectly be ignored when synchronizing DataMiner.xml \[ID_29117\]

In a Failover setup, in some cases, the notification attribute of the LDAP element would incorrectly be ignored when synchronizing the DataMiner.xml file between the two Failover agents.

#### SLAutomation: Problem when clearing the internal parameter cache \[ID_29165\]

In some cases, an error could occur in SLAutomation when its internal parameter cache was being cleared.
