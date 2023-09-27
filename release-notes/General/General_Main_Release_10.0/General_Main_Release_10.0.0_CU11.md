---
uid: General_Main_Release_10.0.0_CU11
---

# General Main Release 10.0.0 CU11

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Elasticsearch: Dynamic templating now enabled by default on customdata \[ID_28047\]

From now on, in an Elasticsearch database, dynamic templating will be enabled by default on customdata. As a result, when new fields are added to a customdata object, those fields will now always be searchable.

#### System Center - Agents: BPA test management \[ID_28516\]

In the *Agents* section of *System Center*, the new *BPA* tab now allows you to view and run the Best Practices Analyzer (BPA) tests available on your DataMiner System.

This growing list of tests will allow you to check hardware and software requirements in order to guarantee an optimal and smooth DataMiner operation.

#### DataMiner Cube - Alarm Console: Enhanced performance when loading alarms into a sliding window \[ID_28537\]

Due to a number of enhancements, overall performance has increased when loading alarms into a sliding window, especially on systems with large alarm trees.

#### BPA tests can now indicate execute conditions \[ID_28576\]

The BPA interface has been extended with an ExecutionConditions property.

This way, BPA test writers can expose one or more conditions that need to be fulfilled before the BPA can be run. If the conditions are not met, the BPA will return “NoIssues” with the reason “This BPA does not apply for this DataMiner Agent”.

#### BPA tests will now be executed by helper processes \[ID_28613\]

Up to now, BPA tests were executed from within the SLNet process. They will now be executed by helper processes instead.

#### BPA tests will now also be forwarded to offline agents \[ID_28658\]

Up to now, when a BPA test could not be run on an offline agent, it would not be forwarded to that agent. Now, BPA tests will be forwarded to all agents, and clients will be notified when an offline agent is not capable of running a test.

#### When the same BPA test is uploaded again, it will be updated \[ID_28668\]

Up to now, when a BPA test was uploaded, no check would be performed to determine whether it was already present on the system.

From now on, when a BPA test is uploaded, a check will be performed:

- If a BPA test is found with the same name under the same DLL, the test will be updated, but the GUID and the schedule will be left unchanged.
- If a BPA test is found with the same name under a different DLL, an error will be thrown.

#### Enhanced performance when a large number of Cube clients are connected to the same DMA \[ID_28695\]

Due to a number of enhancements, overall performance has increased when a large number of Cube clients are connected to the same DataMiner Agent.

#### DataMiner Cube - SNMP forwarding: Setting the code page to be used \[ID_28745\]

When configuring an SNMP manager in DataMiner Cube, it is now possible to set the code page to be used.

Default code page: UTF-8

#### Last test results can now be retrieved for any type of BPA test \[ID_28759\]

Previously, it was only possible to retrieve the last results of scheduled BPA tests that had run in the background. From now on, it is possible to retrieve the last results of any type of BPA test, scheduled or non-scheduled.

#### 'Register DataMiner as Service32.bat' removed from the C:\\Skyline DataMiner\\Tools folder \[ID_28808\]

The “Register DataMiner as Service32.bat” file has been deprecated. It has been removed from the C:\\Skyline DataMiner\\Tools folder.

### Fixes

#### Problem when performing a DataMiner upgrade \[ID_28350\]

In some cases, an error could occur during a DataMiner upgrade.

#### DataMiner Cube - Automation: Not possible to save a script after modifying an if/then block \[ID_28532\]

When, in an Automation scripts, you had changed the actions in an if/then block, in some cases, the *Save script* button would incorrectly not get activated. As a result, you were not able to save the modified script.

#### DataMiner Cube - Scheduler app: Problem when editing a script event in the timeline \[ID_28542\]

When editing a script event in the timeline of the Scheduler app, in some cases, an incorrect parameter would be passed to the DataMiner Agent, causing the Stop parameter on the scheduled action to get the value START instead of STOP.

#### Dashboards app: Problems when moving dashboards \[ID_28543\]

When, in the Dashboards app, you moved a dashboard to the currently active folder, in some cases, an error could occur when you tried to open the dashboard that was moved.

Also, when you manually entered the location to which a dashboard had to be moved, in some cases, that location would incorrectly not be saved when you pressed the ENTER key once. Only when you pressed the ENTER key a second time would the location be saved.

#### DMS Alerter: Settings window too small to fit all settings \[ID_28550\]

When, in DMS Alerter, you opened the settings window, in some cases, the window could be too small to fit all settings.

#### DataMiner Cube: Problem when opening the Protocols & Templates app \[ID_28551\]

In some cases, an exception could be thrown when you opened the Protocols & Templates app.

#### Dashboards app - Bar chart component: Problem when selecting a time span without alarms \[ID_28569\]

When, while configuring a bar chart component that showed data from a view, you specified a time span during which no alarms had occurred, in some cases, an error could be thrown.

Now, an empty chart will be shown instead.

#### Service & Resource Management: ReservationInstance was incorrectly marked as interrupted when created with a start time before the Resource Manager was initialized \[ID_28571\]

When a ReservationInstance was created with a start time in the past, before the Resource Manager was initialized, that ReservationInstance would incorrectly be marked as interrupted.

#### DataMiner Cube: Heatlines displayed in the Alarm Console or in Reports pages of cards would incorrectly be gray \[ID_28579\]

In some cases, element and parameter heatlines displayed either in the Alarm Console or in Reports pages of cards would incorrectly be gray.

#### Service & Resource Management: DecimalQuantity property of CapacityUsageParameterValue incorrectly saved without decimals \[ID_28582\]

When the DecimalQuantity property of the CapacityUsageParameterValue of a Profile-Instance was specified, in some cases, the decimals would be lost was the ProfileInstance was saved in the Elasticsearch database.

#### Problem when adding data to an Elastic logger table \[ID_28587\]

Up to now, when data was added to an Elasticsearch logger table, in some cases, an attempt would incorrectly also be made to add the same data to a non-existing Cassandra logger table.

#### Failover: Offline agent would not be informed of changes made to BPA test configurations \[ID_28624\]

In a Failover setup, up to now, the offline agent would not be aware of any changes made to the configuration of a BPA test. From now on, the BPAManager will correctly inform that agent of all changes made to BPA test configurations.

#### Problem when compiling QActions when 'System.xxxx' and 'Microsoft.xxx' DLL files could not be found in the Windows System Assemblies folders \[ID_28653\]

When a QAction was defined with dllImport=”System.xxxxx.dll” or dllImport=”Microsoft.xxxx.dll”, in some cases, the QAction would fail to compile when the referenced DLL file could not be found in the Windows System Assemblies folders.

Also, the compilation error would not be added to the log file.

#### DataMiner Cube - Alarm Console: Memory usage would increase when a correlated alarm was cleared \[ID_28667\]

When a correlated alarm was cleared, overall memory usage would temporarily increase, which, in some rare cases, could lead to an “out of memory” exception.

#### Problem with SLSpectrum when a client disconnected \[ID_28669\]

In some cases, an error could occur in the SLSpectrum process when a client disconnected.

#### Correlation: Correlation rules would incorrectly be triggered by empty alarms \[ID_28680\]

In some cases, correlation rules would incorrectly be triggered by empty alarms, causing emails to be sent with unresolved placeholders.

#### Problem in SLDataMiner if Protocol.xml.lnk file linked to unavailable path \[ID_28715\]

A problem could occur in the SLDataMiner process if a protocol production version Protocol.xml.lnk file linked to a path that could not be reached.

#### DataMiner Cube: Incorrect parameter information would be displayed in a card after it had been changed via an NT_UPDATE_DESCRIPTION_XML notify call in the protocol \[ID_28716\]

When, in DataMiner Cube, you opened a card, in some cases, parameter information like range, step size and description could be incorrect when that information had been changed via an NT_UPDATE_DESCRIPTION_XML notify call in the protocol.

#### DataMiner Cube: Problem when opening an alarm card \[ID_28738\]

When, in DataMiner Cube, you opened an alarm card, in some cases, an exception could be thrown when the alarm duration was being calculated.

#### DM Cube Scheduler: Problem when updating scheduler events \[ID_28748\]

When, in the Scheduler app, you made changes to an event, in some cases, although those changes would be saved correctly, they would immediately seem to get reverted in the UI. Only after closing the app and re-opening it again would you see the updated event in the UI.

#### DataMiner Cube: Problem when logging in due to invalid user image data received from the domain controller \[ID_28749\]

When logging in to Cube, in some cases, an error could occur when invalid user image data was received from the domain controller.

#### DataMiner Cube - Alarm templates: Numeric baseline values would get parsed incorrectly \[ID_28750\]

When, in DataMiner Cube, you changed the baseline value of a numeric parameter, in some cases, that baseline value would get parsed incorrectly.

#### Domain groups and the users in those groups would be removed when the Active Directory server was unreachable \[ID_28758\]

When the domain server was not available, DataMiner would incorrectly remove all of the imported domain groups as well as the users in those groups.

#### Remote connections would incorrectly get removed from the local cache of a DMA when it lost its connection to another DMA \[ID_28760\]

When a DMA temporarily lost its connection to another DMA, in some cases, remote connections of other DMAs would incorrectly also get removed from its local cache.

#### DataMiner Cube - Visual Overview: An authentication popup would incorrectly appear when a browser shape with the UseChrome option set linked to a web page on the DMA \[ID_28782\]

When, in a visual overview, an embedded browser shape with the UseChrome option set linked to a web page on the DataMiner Agent, in some cases, an authentication popup would incorrectly appear.

#### Problems caused by DMS.xml containing multiple addresses referring to the same DataMiner Agent \[ID_28793\]

When a DMS.xml file contained multiple addresses referring to the same DataMiner Agent, up to now, this could lead to various problems, one of them being disconnects/reconnects of type “XXXX state has changed from XXX to XXXXX” in DataMiner Cube.

#### Invalid 'Failed to read out schedules: XML response was not in the correct format.' errors added to SLErrors.txt log file \[ID_28795\]

In some cases, a “Failed to read out schedules: XML response was not in the correct format.” error message would be added to the SLErrors.txt log file for every alarm template on the system that did not have a schedule defined.

#### Problem when a client using special SLNet connections tried to forward a request to another DataMiner Agent \[ID_28801\]

When clients using special SLNet connections tried to forward a request to another DataMiner Agent in the DataMiner System, in some cases, a “Not a DataMiner user: DOMAINNAME\\SYSTEM” exception would be thrown.

#### Start time and end time in metadata of BPA test result would be incorrect \[ID_28805\]

In the metadata of a BPA test result, you can find the start time and end time of the test. In some cases, both would incorrectly have the same timestamp and the end time would be returned in local time instead of UTC.

#### SyncInfo agent IP address file would incorrectly be updated with the current timestamp on DMA startup \[ID_28809\]

At DataMiner startup, the IP address entries in the C:\\Skyline DataMiner\\Files\\SyncInfo\\{DO_NOT_REMOVE_DC5A2A6C-4583-493C-A9CD-7AEBBF905D1E}.xml file would incorrectly be updated with the current timestamp. In some cases, this could cause IP addresses to re-appear in DMS.xml files across the DMS after starting up a stopped DataMiner Agent that still had those IP addresses listed as active.

#### Problem with SLDataMiner when loading protocols \[ID_28833\]

In some cases, an error could occur in the SLDataMiner process when loading protocols.

#### DataMiner Cube: Properties window would resize when switching to a tab that contained a custom property with a long name \[ID_28873\]

When you switched tabs in the Properties window, in some cases, the window would resize when the selected tab contained a custom property with a long name.
