---
uid: General_Main_Release_10.0.0_CU9
---

# General Main Release 10.0.0 CU9

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Cassandra: User will now be notified when restoring a database backup has failed \[ID_27441\]

When restoring a Cassandra database backup has failed, from now on, the user will be notified and the restore operation will not be marked as complete.

#### DataMiner Cube - Visual Overview: More filter options when configuring an alarm timeline \[ID_27632\]

When, in Visual Overview, you right-click an alarm timeline with an alarm filter and select Show alarms in a new tab page, the alarms matching the filter will be loaded.

Up to now, it was only possible to filter on alarm properties. Now, you can also filter on severity (e.g. Severity:Critical), element (e.g. Element:49/1), etc.

#### DataMiner Cube: Enhanced performance when opening the Reports page of a view card \[ID_27937\]

Due to a number of enhancements, overall performance has increased when opening the Reports page of a view card, especially when that page shows a large amount of elements with heatlines (e.g. the root view).

#### Web Service API v1: New GetDataMinerClusterName method \[ID_27951\]

The GetDataMinerClusterName method can now be used to retrieve the name of the DataMiner System a DMA is part of.

#### BPA test framework only allows to upload and execute BPA tests that have been digitally signed by Skyline \[ID_27979\]

From now on, the BPA test framework will only allow to upload and execute BPA tests that have been digitally signed by Skyline.

#### SLUpgrade: New option to forcefully kill processes \[ID_27983\]

Up to now, in some cases, attempting to disable a service during a DataMiner upgrade could fail.

Now, when a service has the ACTION_KILL flag added to its service info, it will forcefully be terminated when a clean stop and/or disabling fails.

#### DataMiner Cube - System Center: Refresh button in Logging section \[ID_27986\]

In the Logging section of System Center, you can now click Refresh to reload the log entries.

#### BPA test results now include error impact and list of corrective actions \[ID_28018\]

A BPA test result now contains the following additional fields:

| Field            | Description                                        |
|------------------|----------------------------------------------------|
| Impact           | The impact of the error.                           |
| CorrectiveAction | The actions users could take to correct the error. |

#### BPA tests: Maximum DataMiner version now specifies the last compatible version instead of the first incompatible version \[ID_28108\]

When creating a BPA test, it is possible to indicate the most recent DataMiner version on which the test will work.

From now on, when a DataMiner Agent is upgraded to a version above the one specified in the MaxVersion setting of a test, that test will no longer be executed. Also, you will not be able to upload a BPA test to a DataMiner Agent with a version above the one specified in the MaxVersion setting.

#### BPA tests can now be set to automatically run at specific intervals \[ID_28126\]

BPA tests can now be set to automatically run at specific intervals.

#### Table updates: Threshold columns will now be processed before non-prioritized columns \[ID_28139\]

When a table row is updated, the cells are handled according to the column's perceived priority unless overwritten. The processing order of columns has now been extended so that columns that are part of a threshold option (*Protocol.Params.Param.Alarm@Options*) within the same table definition get processed before columns that are part of a property definition and any other columns. This results in the following column processing order:

1. Primary key (index)
2. Display column
3. Foreign key columns
4. Columns part of the naming or namingformat definition
5. Columns part of a conditional monitoring definition
6. Columns part of a threshold definition (NEW)
7. Columns part of a property definition

Any other columns are processed in the order defined in the table parameter

#### DataMiner Cube - Protocols & Templates: More information will now be returned to the user when a protocol upload fails \[ID_28183\]

When you are uploading a protocol in the *Protocols & Templates* app, a message box will appear when the upload operation has failed. This message box will now contain more detailed information about why the operation failed.

#### SLAutomation will now automatically compile new libraries at startup \[ID_28218\]

When, on startup, SLAutomation detects any new Automation scripts that contain libraries that need to be compiled, from now on, it will automatically compile them.

#### SRM: Additional logging added to SLDBConnection.txt when retrieving service definitions from the servicedeftrace table \[ID_28245\]

Additional information will now be logged in the SLDBConnection.txt log file when service definitions are being retrieved from the servicedeftrace table with a time-based filter.

This information will include the filter that was used as well as the number of valid, outdated and deleted service definitions that were found.

As soon as the read request is made, outdated and deleted service definitions will be deleted in the background. When this delete operation finishes and each time a deletion fails, an entry will be added to the log.

### Fixes

#### SLDataGateway would append inaccurate query timestamps to Cassandra statements \[ID_27534\]

In some cases, SLDataGateway would append inaccurate query timestamps to Cassandra statements.

#### Failover: An agent taken out of a Failover setup would incorrectly keep on trying to connect to the database of the other agent \[ID_27803\]

When a DataMiner Agent was taken out of a Failover setup, in some cases, it would incorrectly keep on trying to connect to the database of the other agent.

#### DataMiner Cube: System Center could incorrectly display negative trend values \[ID_27825\]

In some cases, System Center could incorrectly display negative trend values.

#### Problem when using smart IP header on UDP \[ID_27957\]

When the smartIpHeader communication option was used in a smart serial protocol and multiple clients were sending UDP datagram packets to the smart serial server socket, it could occur that the first package of the second sender would not be processed until a second package arrived.

#### DataMiner Cube: Redundancy groups using software redundancy would not trigger when the switching logic contained elements that were neither primary nor backup element \[ID_28041\]

Redundancy groups making use of software redundancy would incorrectly not trigger when the switching logic contained elements that were neither primary nor backup element.

#### Service & Resource Management: Problem when setting function resource states \[ID_28050\]

In some cases, an error could occur when setting function resource states. As a result, ReservationInstances would no longer be created.

#### DataMiner Cube - Visual Overview: Zoom buttons would disappear when switching to full-screen mode and back in an embedded trend graph \[ID_28065\]

When, in an embedded trend graph, you switched to full-screen mode and back, in some cases, the “Zoom to last X” buttons would disappear.

#### Problem when retrieving composite instances using the 'partialSNMP' option \[ID_28087\]

When retrieving composite instances using the SNMP polling option “partialSNMP”, in some cases, only the first set of the table would be polled correctly. Other rows would either be empty or not polled at all.

#### Visual Overview: SetVar shape with tooltip would not work on a mobile device \[ID_28129\]

When a SetVar shape had its SetVarOptions data field set to “Control=Shape” and contained a legacy tooltip configuration (e.g. ‘\<MyVar>:\<MyValue>:\<MyToolTip>’), in some cases, the variable would not be updated when you clicked the control on a mobile device.

#### DataMiner Cube - Element connections app: Problem with 'Include element state' checkbox \[ID_28188\]

In the *Element connections* app, in some cases, the value of the *Include element state* checkbox would be saved incorrectly.

#### DataMiner Cube - System Center/Backup: 'Use one network path for all Agents' setting would be saved correctly but displayed incorrectly \[ID_28192\]

In the Backup section of System Center, it is possible to specify that a backup has to be stored on a network path. In some cases, when you specified one shared network path for all DataMiner Agents, this would be saved correctly, but displayed incorrectly in the user interface.

#### DataMiner Cube: Impossible to remove a trend template or an alarm template via the right-click menu of an element when the UI language was not set to English \[ID_28198\]

When DataMiner Cube was set to a language other than English, in some cases, it would not be possible to remove an alarm template or a trend template via the right-click menu of an element.

#### SLUpgrade would incorrectly disregard changes made to the SLNet.exe.config file \[ID_28228\]

In some cases, the SLUpgrade process would disregard changes that were made to the SLNet.exe.config file.

#### Failover: Incorrect error message would appear after configuring a Failover setup \[ID_28241\]

In some cases, a cluster name mismatch error would incorrectly appear immediately after configuring a Failover setup.

#### Vendor name would incorrectly disappear from protocol signatures \[ID_28246\]

When a DVE protocol was signed, or when a signed protocol was promoted to production protocol, in some cases, the vendor name would disappear from the signature.

#### Client applications would incorrectly receive table updates multiple times \[ID_28250\]

When data was updated in a table, in some cases, client applications would incorrectly receive those updates multiple times.

#### DataMiner Cube: No pop-up messages when users logged in again after logging out \[ID_28306\]

When users logged in again after having logged out, in some cases, popup messages would no longer appear.

#### SLWatchDog2.txt: Total number of processes of which at least one thread has a run-time error was incorrectly replaced by total number of threads with a run-time error \[ID_28360\]

Each time a run-time error occurs, an entry is added to the SLWatchDog2.txt log file, showing the total number of processes of which at least one thread has a run-time error.

However, in some cases, that log entry would incorrectly show the total number of threads with a run-time error instead.

#### HTML5 apps: Problem when entering numeric values \[ID_28374\]

When a numeric value was updated in the UI, in some cases, the old value would incorrectly re-appear after the new value had been validated.

#### Problem with SLDataMiner when loading protocols \[ID_28447\]

In some cases, an error could occur in the SLDataMiner process when loading protocols.
