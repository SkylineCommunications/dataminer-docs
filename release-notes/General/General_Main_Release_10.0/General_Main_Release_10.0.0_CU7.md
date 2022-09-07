---
uid: General_Main_Release_10.0.0_CU7
---

# General Main Release 10.0.0 CU7

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Monitoring app: Card header, sidebar and menu available on mobile devices \[ID_25156\]

When you open a card on a mobile device, you will now see a card header instead of the app header, and you will be able to open a card sidebar just like on a desktop device.

Also, the card menu is now accessible through a hamburger button in the top-right corner.

#### Logging: More information stored in errorlog.txt file when an error occurs in SLProtocol \[ID_26630\]

When an error occurs in SLProtocol, from now on, more information about that error will be stored in the errorlog.txt log file.

#### BPA Framework: BPA tests can now take corrective actions \[ID_27222\]

BPA tests can now be configured to take corrective actions when issues are detected.

When creating a BPA test capable of taking corrective actions, developers have to do the following:

1. Implement a class that inherits the BpaCorrectiveTest class.

1. Create an implementation of the Verify() method that will return

   - True when no issues were detected, and
   - False when issues were detected.

1. Create an implementation of the CorrectiveAction() method that will return

   - True when the corrective action was performed successfully, and
   - False when issues prevented the action from being performed.

A BPA test that was set to take corrected actions will run the Verify() method, which will run the CorrectiveAction() method in case of failure, and will then run the Verify() method again.

> [!NOTE]
>
> - The result returned by a test will tell whether corrective actions were taken and whether they were successful.
> - By default, no corrective actions will be taken in any of the tests that are run, unless requested in the beginning of the test run.

#### DataMiner Cube - Router Control: Enhanced configuration of input/output filters of custom matrices \[ID_27253\]

A number of enhancements have been made with regard to the configuration of input and output filters of custom matrices.

#### Scope of BPA test should now always be specified \[ID_27276\]

Before running a BPA test, the scope of the test should now always be specified using the *bpaRunmode* setting:

| If you specify...      | then...                                           |
|------------------------|---------------------------------------------------|
| BpaRunMode.ClusterOnly | the test(s) will be run on all agents in the DMS. |
| BpaRunMode.LocalOnly   | the test(s) will be run on the local agent only.  |

#### Service & Resource Management - Profile parameters: Default value of 'IsOptional' field has changed from 'Undefined' to 'Yes' \[ID_27286\]

Up to now, the *IsOptional* field of a profile parameter was by default set to “Undefined”. From now on, this field will by default be set to “Yes”.

#### Only the most recent synchronization file will now be kept in the 'C:\\Skyline DataMiner\\system cache\\sync' folder \[ID_27323\]

To prevent too many synchronization files from getting stored in the “C:\\Skyline DataMiner\\system cache” folder, from now on, only the most recent file will be kept in the “C:\\Skyline DataMiner\\system cache\\sync” subfolder.

Whenever a file is added to this folder, all files older than a day will automatically be deleted.

#### StandAloneBpaExecutor now has to be run with administrative privileges \[ID_27379\]

From now on, the StandAloneBpaExecutor executable has to be run with administrative privileges. When the executable is run, a UAC box will now appear, asking for administrative access.

#### DataMiner Cube - Visual Overview: EPM card Visual pages now only displayed when page-level properties 'Chain' and 'Field' both match \[ID_27392\]

In an EPM environment, you can assign Visual Overview pages to chains and fields by setting the page-level *Chain* and *Field* properties.

Up to now, all Visual pages of an EPM card with a matching *Field* property were displayed, regardless of their *Chain* property. From now on, a Visual page will only be displayed if its *Chain* property is set to either a valid chain or “\*”.

> [!NOTE]
> Setting the *Chain* property of a Visio page to “\*” will display that page on all chains of the CPE Manager.

#### More detailed information in exception message when a BPA test fails to load due to dependencies not being able to load \[ID_27403\]

When a BPA test fails to load due to one or more dependencies not being able to load, from now on, more detailed information will be provided in the exception message.

#### BPA tests can now be run from a Windows command line \[ID_27420\]

BPA tests can now be run from a Windows command line.

Syntax:

```txt
BpaExec.exe -options -- tests
```

Example:

```txt
BpaExec.exe -option1 value -option2 value --<PathToTest1> <PathToTest2>
```

Supported options:

| Use... | or...               | in order to...                                             |
|--------|---------------------|------------------------------------------------------------|
| -u     | -username           | specify the user name of the SLNet user.                   |
| -p     | -password           | specify the password of the SLNet user.                    |
| -c     | -corrective-actions | allow the test(s) to take corrective actions if necessary. |
| -h     | -help               | display information on how to use this command.            |

#### Enhanced performance when applying, updating or removing alarm templates \[ID_27450\]

Due to a number of enhancements, overall performance has increased when applying, updating or removing alarm templates.

#### StandAloneBpaExecutor can now be used to view previously saved BPA test results \[ID_27451\]

When you saved the results of a BPA test to a JSON file, you can now load that file back into the StandAloneBpaExecutor to review the test result. To do so, go to the *Load results* tab, select the file, and click *Load*.

#### DataMiner Cube - System Center: BPA folder will now also be included when taking a full backup or a configuration backup \[ID_27456\]

From now on, the C:\\Skyline DataMiner\\BPA folder will also be included when you take one of the following predefined backups:

- Full backup
- Full backup without database
- Configuration backup
- Configuration backup without database

#### BPA test results now contain an 'Outcome' property \[ID_27476\]

The IBpaTestResult interface now contains an additional property named “Outcome”. This property can have the following values:

- BpaOutcome.NoIssues
- BpaOutcome.IssuesDetected
- BpaOutcome.Warning

#### Enhanced performance when saving alarm templates with conditional monitoring \[ID_27493\]

Due to a number of enhancements, overall performance has increased when updating alarm templates with conditional monitoring.

#### Support for running BPA tests across a cluster \[ID_27577\]

When interfacing with a DataMiner Agent and its installed BPA tests using the *BpaManagerHelper* object, you can now request the execution of one or more BPA tests across the cluster.

#### Client application licensing removed \[ID_27595\]

The client application licensing feature has now been removed. This means that if accepted credentials are provided, you can now connect to DataMiner with any client application, even if it is not approved by Skyline.

#### DataMiner Cube - Element properties: Dependency between options \[ID_27597\]\[ID_27725\]

When you add a custom property to an element, you can select a number of options.

From now on, it will only be possible to select *Update alarms on value changed* after selecting *Make this property available for alarm filtering*.

> [!NOTE]
> When an element property, service property or view property is created, the *Update alarm on value* changed option will by default be cleared. However, when an alarm property is created, this option will by default be selected.

#### DataMiner Cube - Data Display: Enhanced scrollbar behavior in tables \[ID_27653\]

In Data Display, a number of enhancements have been made with regard to scrollbar behavior in tables.

#### Standard BPA tests will now be included in DataMiner upgrade packages \[ID_27716\]

DataMiner upgrade packages will now by default place a collection of standard BPA tests in the C:\\Skyline DataMiner\\BPA folder.

### Fixes

#### DataMiner Cube - Visual Overview: Problem with highlighting of grouped shapes when zooming in or out \[ID_22365\]

When the ShapeGrouping feature was used, in some cases, grouped shapes were highlighted incorrectly when you zoomed in or out.

#### Ticketing app: Problem when filtering on ticket fields of type GenericEnumEntry \[ID_24689\]

In some cases, it would no longer be possible to filter on ticket fields of type GenericEnumEntry.

#### DMS Alerter: Settings window too small to fit all settings \[ID_27017\]

When, in DMS Alerter, you opened the settings window, in some cases, the window could be too small to fit all settings.

#### Problem with the precision of decimal values \[ID_27136\]

Up to now, when SLElement received a value from SLProtocol, in some cases, the raw value would get rounded to the number of decimals specified in the protocol’s *Display.Decimal* element. In cases where the *Display.Decimal* element defined less decimals than the *Interprete.Decimals* element, the level of precision would drop and would lead to rounding errors.

From now on, values will always be saved to the database with the precision specified in the *Interprete.Decimals* element. Also, that same precision will be taken by raw values sent to client applications.

#### DataMiner Cube: Missing focus icon for correlated alarm \[ID_27168\]

If you expanded a correlated alarm in the Alarm Console in order to see the base alarms and then toggled the *Correlation tracking* option, it could occur that the focus icon was missing for the correlated alarm.

#### Problem when renaming a parent DVE element \[ID_27312\]

When a parent DVE element was renamed multiple times in rapid succession, in some cases, the child DVE elements would not inherit the new element name.

#### DataMiner restart not triggered after process generated crashdump \[ID_27321\]

In some cases, after a DataMiner process had generated a crashdump, it could occur that no DataMiner restart was triggered even though this should have been the case.

#### DataMiner Cube - Visual Overview: DCF interfaces linked to a table entry would lose that link when updated \[ID_27353\]

DCF interfaces that are linked to a table entry can retrieve data from that table via their Parameters property. However, up to now, when an interface was updated, in some cases, it would lose that link. As a result, this could lead to problems in Visual Overview when, for example, the ID of the linked table entry was stored in session variables.

#### BPA tests would fail when being run with administrative privileges \[ID_27382\]

When being run with administrative privileges, BPA tests that accessed SLNet would throw a “To log in as Administrator, please log on explicitly” error unless you manually specified the user name and password on the Settings page.

From now on, when a BPA test is launched, a popup window will appear, asking you to enter the Administrator password.

#### Multiple RTEs in same process not logged correctly \[ID_27387\]

When multiple RTEs occurred in the same process, it could occur that this was not correctly reported in the logging. Reporting of RTEs has now been improved to prevent this. Error alarms will now also get updates when a new thread encounters an RTE or has an RTE resolved.

#### DataMiner upgrade: SNMP service would incorrectly always be stopped \[ID_27400\]

When you launched a DataMiner upgrade, up to now, the SNMP service would incorrectly always be stopped, even when you had cleared the Stop SNMP option.

#### Problem with SLDataMiner due to locking issue in the alarm level linking module \[ID_27418\]

In some cases, an error could occur in SLDataMiner due to a locking issue in the alarm level linking module.

#### Protocol-level TTL settings would incorrectly not be taken into account when parsing real-time trend data \[ID_27421\]

In some cases, protocol-level TTL settings would incorrectly not be taken into account when parsing real-time trend data.

#### DataMiner Cube: Duplicated excluded column parameter entry in alarm template could not be edited \[ID_27423\]

If a column parameter entry that was set to *Excluded* was duplicated in an alarm template, it could occur that it was not possible to edit the duplicated entry.

#### DataMiner Cube would no longer receive data updates from the DataMiner Agent it was connected to \[ID_27434\]

In some cases, DataMiner Cube would no longer receive data updates from the DataMiner Agent it was connected to.

#### DataMiner Cube - Visual Overview: Problem when closing Microsoft Visio while a shape was selected in Cube \[ID_27442\]

When, after opening a Visio file in Microsoft Visio, you closed Microsoft Visio while, in DataMiner Cube, a shape of that same file was selected, in some cases, an error could occur in DataMiner Cube.

#### Web Services API v1 - GetAlarms: Problem when filtering on RootAlarmID \[ID_27445\]

When alarms were retrieved using the GetAlarms method with a filter on RootAlarmID, in some cases, the following SOAP error would be returned:

```txt
System.InvalidOperationException: The specified type was not recognized: name='DMAAlarmFilterRootID'.
```

#### Problems with enhanced services \[ID_27465\]

A number of problems with regard to enhanced services have been fixed:

- When an enhanced service was renamed, in some cases, all open alarms associated with that service would incorrectly disappear.

- After an enhanced service had been reloaded, in some cases, element state changes would no longer be forwarded to that enhanced service.

#### Service & Resource Management: A daylight saving time change would incorrectly cause booking durations to get changed \[ID_27468\]

When a daylight saving time change occurred while a booking was active, in some cases, the duration of that booking would incorrectly get changed.

#### Service & Resource Management: Error that appeared when trying to deactivate or delete a function file in use would contain an incorrect file name \[ID_27470\]

Up to now, when you tried to deactivate or delete a function file used by ReservationInstances, ReservationDefinitions, ServiceDefinitions or ServiceProfileDefinitions, the returned error would contain an incorrect file name.

From now on, the error will contain the correct file name, i.e. the name of the file that cannot be deactivated or deleted because it is in use.

#### DataMiner Cube - Bookings app: Bookings list would not get updated when a booking was deleted \[ID_27482\]

In the Bookings app, the bookings are shown both in the list at the top and the timeline at the bottom. Up to now, when a booking was deleted, in some cases, it would disappear from the timeline but incorrectly remain visible in the list.

#### DataMiner Cube - Alarm Console: Problem when opening an alarm card or switching between alarm cards on a system with a large number of alarm properties \[ID_27483\]

On a system with a large amount of alarm properties, in some cases, an error could occur when you either opened a new alarm card or switched between two open alarm cards.

#### Problem with SLDataGateway \[ID_27498\]

In some cases, the SLDataGateway process would start using an excessive amount of CPU resources, especially in Service & Resource Management environments.

#### DataMiner Cube - Protocols & Templates app: Incorrect warning message when deactivating or deleting a functions file \[ID_27518\]

If you deactivated or deleted a functions file in the Protocols & Templates app, in some cases, an incorrect warning message would be displayed.

#### Mobile apps: Date picker controls would show an incorrect month when the day was greater than or equal to 30 (or 29 in case of a leap year) \[ID_27522\]

In mobile apps (e.g. Jobs), in some cases, date picker controls would show an incorrect month when the day was 30 or 31 (or 29, 30 or 31 in case of a leap year).

#### DataMiner Cube - Alarm templates: Problem when editing alarm levels of a matrix parameter from the Alarm Console \[ID_27535\]

In some cases, it was no longer possible to edit the alarm levels of a matrix parameter from the Alarm Console.

#### Problem when a direct view table of an element retrieved data from that same element \[ID_27548\]

In some cases, an error could occur when a direct view table belonging to a particular element was retrieving data from that same element.

#### DataMiner Cube: About window would incorrectly show launcher tool version instead of Cube client version when Cube was opened using the launcher tool \[ID_27552\]

When you opened DataMiner Cube using the launcher tool, in some cases, the *About* window would no longer display Cube’s client version. It would show the launcher tool version instead.

From now on, the *About* window will show both the Cube client version and the launcher tool version.

#### Alarms for numeric or discrete parameters not read out correctly from MySQL local database \[ID_27585\]

In systems with a MySQL local database, it could occur that alarms for numeric or discrete parameters were not read out correctly from the database when an element restart occurred or an alarm history query was launched.

#### Services containing remote elements would no longer get recalculated when the agent hosting the remote elements was disconnected \[ID_27589\]

In some cases, locally hosted services containing elements hosted on another DataMiner Agent (i.e. remote elements) would no longer get recalculated when the connection with the that other agent was lost.

#### Not possible to delete ticketing resolver \[ID_27603\]

In some cases, it could occur that a ticketing resolver could not be deleted.

#### DataMiner Cube: Columns in EPM data pages would be ordered incorrectly when using custom parameter positioning \[ID_27622\]

By default, an EPM card displaying row data as single parameters will automatically position those parameters unless custom positioning is applied on at least one of the columns (using the “CPEIntegration\_” prefix).

In some cases, when parameters were positioned automatically, the columns would not be ordered correctly. They would incorrectly be ordered according to the column definition order instead of the order defined in the options.

#### Minor issues in BPA framework \[ID_27625\]

The following minor issues could occur in the BPA framework:

- In some cases, it could occur that BPA tests were not updated correctly if BpaManager.BPAs.Update was used. The BPA info was not stored.

- BpaManager did not always include trace data on exceptions, causing BpaManagerHelper not to throw ManagerStoreExceptions.

#### DataMiner Cube - Alarm Console: Problem with alarm hyperlinks when the first character of the parameter name is hash character \[ID_27641\]

When you right-clicked an alarm associated with a parameter of which the name started with a “#” character and then clicked an alarm hyperlink that ran an Automation script that used that parameter name as input, in some cases, an error could occur.

#### DataMiner Cube: Clicking a pinned or recently opened custom element app would incorrectly cause another app to open \[ID_27642\]

When the *Activities* tab of the navigation pane listed multiple custom element apps of the same type (either pinned or not), in some cases, clicking one of those apps would incorrectly cause another app to open.

#### SLLogCollector: Generated packages would have incorrect file names \[ID_27677\]

In some cases, SLLogCollector would fail to include the ID and name of the DataMiner Agent in the file name of the packages it generated.

#### DataMiner Cube - Protocols & Templates: Monitoring conditions would not get reapplied after switching alarm templates \[ID_27696\]

When you switched from an alarm template with conditions that were not used to an alarm template with identical conditions that were used, in some rare cases, conditional monitoring would incorrectly not get reapplied for the parameters using those conditions.

#### On DMAs with a MySQL database, alarms based on parameters of type 'analog' or 'progress' would have an incorrect display value after an element restart \[ID_27715\]

On DataMiner Agents using a MySQL database, in some cases, alarms based on parameters with measurement type “analog” or “progress” would have an incorrect display value after an element restart.

#### DataMiner Cube - Settings: Default workspace settings would incorrectly be displayed as text boxes instead of selection boxes \[ID_27718\]

In the User \> Cube sides section of the Settings window, when no custom workspaces had been created, the “default workspace” settings would incorrectly be displayed as text boxes instead of selection boxes.

#### Problem with SLLogCollector tool \[ID_27769\]

If a user had never used SLLogCollector before, it could occur that this tool failed to include memory dumps in packages generated for this user.

In addition, in some cases, SLLogCollector failed to include the contents of the *System Cache\\Info* folder in a memory dump.

#### DataMiner - Visual Overview: Embedded alarm timeline would not show its summary timeline \[ID_27889\]

In some cases, an embedded alarm timeline component would not show its summary timeline.
