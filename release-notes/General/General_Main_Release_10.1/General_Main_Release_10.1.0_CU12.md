---
uid: General_Main_Release_10.1.0_CU12
---

# General Main Release 10.1.0 CU12

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Security enhancements \[ID_32125\]

A number of security enhancements have been made.

#### SLElement: Enhanced performance when working with tables using the 'naming' or 'namingformat' option \[ID_30973\]

Due to a number of enhancements, overall performance of SLElement has increased, especially when working with tables using the “naming” or “namingformat” option.

#### OpenSSL libraries updated to version 1.1.1l \[ID_31977\]

The OpenSSL libraries in DataMiner have been updated to the latest version (v1.1.1l).

#### SLElement: Enhanced performance when processing partially included services \[ID_32080\]

Due to a number of enhancements, overall performance of SLElement has increased when processing partially included services.

#### SLElement: Enhanced performance when processing alarms \[ID_32111\]

Due to a number of enhancements, overall performance of SLElement has increased when processing alarms.

#### SLElement: Enhanced performance when working with DCF interfaces \[ID_32126\] \[ID_32127\]

Due to a number of enhancements, overall performance of SLElement has increased when working with DCF interfaces.

#### Enhanced performance when connecting to a system with a large number of LDAP users \[ID_32146\]

Due to a number of enhancements, overall performance has increased when connecting to a system with a large number of LDAP users.

#### Logging at element startup has been optimized \[ID_32172\]

Logging at element startup has been optimized.

#### Enhanced smart-serial client throughput \[ID_32219\]

Due to a number of enhancements, the overall throughput of smart-serial clients has increased.

#### SNMPAgent: Enhanced error handling \[ID_32276\]

A number of enhancements have been made to the SLSNMPAgent process, especially with regard to error handling.

#### DataMiner Cube - System Center: Enhanced performance when opening the Users/Groups section \[ID_32307\]

Due to a number of enhancements, overall performance has increased when opening the Users/Groups section of System Center.

#### Web Services API: Web socket interface will now handle incoming messages asynchronously \[ID_32390\]

Up to now, when clients sent messages to the web socket interface of the Web Services API, those message were handled synchronously. From now on, the web socket interface will handle all incoming messages asynchronously.

#### DataMiner Cube: Skyline Black theme now features improved support for function icons \[ID_32430\]

The Skyline Black theme now features improved support for function icons.

### Fixes

#### Cassandra: Incorrect health status \[ID_29502\]

In some cases, the Cassandra health status was incorrect.

#### DataMiner Cube: When opening an email report, certain parameters would not be loaded correctly \[ID_31969\]

When you created an email report in Scheduler, Automation or Correlation, and then added a number of parameters to it, in some rare cases, some of those parameters would not be loaded correctly when you reopened Scheduler, Automation or Correlation.

#### DataMiner Cube: Trend graph of a parameter updated via history sets would be drawn incorrectly \[ID_31994\] \[ID_32001\]

Up to now, the trend graph of a parameter updated via history sets would be drawn incorrectly. From now on, for history set parameters, the line indicating parameter updates will no longer be drawn up to the current time. Instead, it will be drawn up to the time of the last parameter update.

#### SoftLaunchOptions.xml would be parsed incorrectly \[ID_32019\]

In some cases, the contents of the SoftlaunchOptions.xml file would be parsed incorrectly.

#### Failover: MigrationManager and ProfileManager exceptions could be thrown when setting up a Failover system without an ElasticSearch database \[ID_32163\]

When a Failover system was set up without an ElasticSearch database, in some cases, BaseProfileManager and MigrationManager exceptions could appear in the Alarm Console.

#### Service & Resource Management: A GetResources call with a filter applied could return different results depending on the software license \[ID_32168\]

A GetResources call with a filter applied could return different results depending on the software licenses found on the system (Resource Manager license but no IDP License, or vice versa).

#### Problem when stopping or removing elements belonging to an enhanced service \[ID_32175\]

In some cases, an error could occur in SLProtocol when stopping or removing elements belonging to an enhanced service.

#### Parent EPM item unmasked while still containing masked sub-items \[ID_32179\]

When a specific EPM item was masked for a period of time and then got unmasked, it could occur that its parent EPM item was also unmasked even though it still contained other masked EPM sub-items.

Now an EPM item can only be unmasked if all underlying items are unmasked. When an EPM sub-item cannot be unmasked for some reason, this will be logged in the SLNet logging. In addition, when you mask an EPM item and some of its sub-items cannot be masked, only the sub-items that were masked will be considered to be masked together with the EPM item, and the failures will be logged in the SLNet logging.

#### Problem with SLAnalytics due to a stack overflow exception \[ID_32190\]

In some cases, an error could occur in the SLAnalytics process due to a stack overflow exception.

#### DataMiner Cube - Alarm Console: 'Audible alert' option was not saved correctly when an alarm tab was added to a workspace \[ID_32191\]

When you undocked an alarm tab in which the “audible alert” option was selected, and then saved the workspace, the “audible alert” option would not be saved correctly.

#### DataMiner Cube: Certain shortcut menu items would not be displayed when the UI language was set to a language other than English \[ID_32196\]

In some cases, certain shortcut menu items would not be displayed when the UI language was set to a language other than English.

#### SLLogCollector would not start up when SLWatchDog2.txt or SLElementsInProtocol.txt were missing \[ID_32205\]

At startup, the SLLogCollector tool checks for issues by reading the SLWatchDog2.txt and SLElementInProtocol.txt log files. Up to now, it would not start up when it was unable to find those files. From now on, when SLLogCollector does not find the above-mentioned log files, it will notify the user but start up correctly.

#### DataMiner Cube - Alarm Console: Making an alarm tab show history alarms instead of active alarms would cause the name of the alarm tab to be updated incorrectly \[ID_32215\]

When you created an “active alarms” tab for a certain object (element, service or view) by dropping that object onto the Alarm Console, and then made the tab show history alarms instead of active alarms, the automatically generated tab name was incorrectly set to “Alarms of the last 0 hours” instead of “\~Last hour (up till X)”.

#### DataMiner Cube - Alarm Console: Not possible to change the 'automatic incident tracking' option in an alarm tab that was enforced by group settings \[ID_32218\]

In an alarm tab that was enforced by group settings, up to now, it would not be possible to change the “automatic incident tracking” option.

#### Problem with SLPort when stopping an element with a serial or smart-serial connection \[ID_32221\]

In some cases, an error could occur in SLPort when an element with a serial or smart-serial connection was stopped.

#### DataMiner Cube: Aggregation rule values were displayed with too many decimals \[ID_32235\]

In some cases, aggregation rule values were displayed with too many decimals.

#### Problem with SLXml at DataMiner startup \[ID_32255\]

At DataMiner startup, in some rare cases, an error could occur in the SLXml process.

#### DataMiner Cube - Alarm Console: Alarm status no longer updated when alarms were grouped by service \[ID_32294\]

When, in an alarm tab, the alarms were grouped by service, in some cases, the status of alarms that affected at least two services for which no alarms existed at the moment the alarms were grouped would no longer be updated.

#### Service & Resource Management: SRM operations could fail due to connection issues between agents \[ID_32296\]

In some cases, SRM operations like creating or updating bookings and creating or updating resources could fail due to connection issues between the different agents.

#### Incorrect service impact alarms after disabling and enabling a virtual function \[ID_32359\]

When a virtual function was disabled and then enabled again, in some cases, the alarms that affected the function would incorrectly affect a deleted service.

#### DataMiner Cube - Visual overview: Problems with path highlighting \[ID_32364\]

The following issues with regard to connection highlighting have been fixed:

- In some cases, paths of connectors without a matching DCF connection would no longer be highlighted. Only shapes and lines that were linked directly would be highlighted.

- Clicking a non-linked shape that was part of a path would no longer cause that path to be highlighted.

    > [!NOTE]
    > If a non-linked shape in a path has shape text and you want it to be highlighted when clicked, then make sure to add a shape data field of type Enabled to it to and set that field to “False”. This will disable the “copy text” command in the shape’s shortcut menu command and make sure the shape can be highlighted.

#### Problem when retrieving trend data in the Monitoring app \[ID_32366\]

In some cases, it was no longer possible to retrieve trend data in the Monitoring app due to a parsing problem in GetParameterResponseMessage and GetAlarmStateResponseMessage.

#### DataMiner Cube - Visual Overview: DCF connectivity not loaded when opening a Visio page embedded in another Visio page \[ID_32377\]

Up to now, when a Visio page was opened, the DCF connectivity would incorrectly not be loaded when that Visio page was embedded in another Visio page.

#### DataMiner Cube - Alarm Console: Newly created private alarm filter would not be automatically selected in the filter selection box \[ID_32401\]

When, in the Alarm Console, you created a new private alarm filter, in some cases, that new filter would not automatically be selected after saving it. The filter selection box would incorrectly show “\<Click to select>” instead of the name of the newly created filter.

#### Spectrum Analysis: Presets not saved/loaded correctly in spectrum card launched from spectrum thumbnail \[ID_32404\]

When a spectrum element card is launched from a spectrum thumbnail in Visual Overview, it is displayed in buffer mode. Up to now, in this buffer mode, markers, reference lines, and thresholds were not taken into account when presets were saved or loaded. These will now be included. Note that the initial preset content checkboxes will be different in this buffer mode compared to the regular spectrum analyzer mode.

#### SLAnalytics: Automatic incident tracking would not start up when an alarm was cleared during the startup routine \[ID_32408\]

In some cases, automatic incident tracking would not start up when an alarm was cleared during the startup routine.

#### SLAnalytics: Problem with alarm grouping when alarms were generated while automatic incident tracking was starting up \[ID_32410\]

When alarms were generated while automatic incident tracking was starting up, in some cases, an alarm could internally be duplicated, leading to incorrect alarm groups (e.g. groups containing only a single alarm).

#### DataMiner Cube - Alarm Console: Problem with 'new alarms' counter when alarms were grouped by service \[ID_32427\]

When, in an alarm tab in which the alarms were grouped by service, an alarm affecting at least two services was cleared, then the “new alarms” counter in the tab header would show an incorrect number of alarms.

#### Alerter: Sound files not loaded correctly \[ID_32431\]

In some cases, the sound files configured in Alerter could not be loaded correctly to the client, so that these no longer worked.

#### A large number of CRequest::Request errors would be logged when elements were stopped \[ID_32444\]

When elements were stopped, in some cases, a large number of CRequest::Request errors would be logged.

#### Not possible to create element with invalid XML character in name \[ID_32455\]

In some cases, it was no longer possible to create elements with an invalid XML character in the element name, even if that character was supported in Cube (e.g. “&”).

#### DataMiner Cube: Problem when accessing an information template, a trend template or an alarm template from within the Alarm Console \[ID_32457\]

In the Alarm Console, you can right-click an alarm and select *Change \> Information*, *Change \> Trending* or *Change \> Alarm range* to access the information template, the trend template or the alarm template for the parameter associated with the alarm. In some rare cases, you could only do so once. When you tried to access an information template, a trend template or an alarm template a second time by right-clicking *Change \> Information*, *Change \> Trending* or *Change \> Alarm range*, a blank window would incorrectly appear.

#### Pinned state of alarm tab cards not included in workspace \[ID_32471\]

When a workspace was saved, the pinned state of alarm tab cards was not included.
