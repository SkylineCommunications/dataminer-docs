---
uid: General_Main_Release_10.3.0_CU6
---

# General Main Release 10.3.0 CU6 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### NATS: Enhanced (re)configuration [ID_35246]

Automatic NATS (re)configuration has been enhanced.

- When the routes of the local NATS server contain the virtual IP address of a Failover setup/node, a NATS restart will be triggered.

- When a DataMiner Agent is added or removed from the DMS, NATS will be reconfigured automatically.

- When a DataMiner Agent cannot be reached, has an incorrect configuration or is in an incorrect state, a NATS reconfiguration will be suggested in Cube via an alarm. To trigger a reconfiguration, users with *Change IP settings* permission can then right-click the alarm, select *Actions > Reconfigure NATS*, and confirm the operation.

  If no errors occur during the reconfiguration, the alarm will disappear from the Alarm Console. If, on the other hand, errors do occur, they will be displayed in a popup window and the alarm will not disappear.

All logging related to a NATS reconfiguration will be added to the *SLNATSCustodian.txt* log file.

#### DataMiner upgrade: New upgrade action added that will clean up default ListView column configuration data [ID_36475]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

During a DataMiner upgrade, from now on, all default ListView column configuration data left on the server will automatically be cleaned up if no more than one Cube client has taken a copy of that data.

#### Cassandra Cluster: Trend tables will no longer be sharded [ID_36551]

<!-- MR 10.3.0 [CU6] - FR 10.3.9 -->

On a Cassandra Cluster database, from now on, the trend tables will no longer be sharded. This will enhance overall performance when requesting trend data, especially on systems on which real-time trend data is stored for longer than a day.

#### SLDataGateway: Enhanced performance of the Elasticsearch health monitoring logic [ID_36554]

<!-- MR 10.3.0 [CU6] - FR 10.3.9 -->

Because of a number of enhancements, overall performance of the Elasticsearch health monitoring logic has increased.

#### SLLogCollector will now also collect the scheduled tasks configured in Microsoft Task Scheduler [ID_36645]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

SLLogCollector will now also collect the scheduled tasks configured in Microsoft Task Scheduler.

#### Automation: DLL references on script libraries will also be loaded when an Automation script does not need to be recompiled [ID_36730]

<!-- MR 10.3.0 [CU6] - FR 10.3.9 -->

Up to now, when the SLAutomation service was started, the DLL references defined on an Automation script library would only be taken into account when that library needed to be recompiled. As a result, Automation scripts that relied on a script library could fail due to missing references.

From now on, when the SLAutomation service is started, the DLL references on an Automation script library will also be loaded when that library does not need to be recompiled.

#### DataMiner upgrade: Presence of Visual C++ 2010 redistributable will no longer be checked [ID_36745]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

During a DataMiner upgrade, from now on, the presence of the Visual C++ 2010 redistributable will no longer be checked.

#### SLWatchdog: Additional logging & retry mechanism for restarts [ID_36839]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

When SLWatchdog starts, restarts or stops DataMiner, extra information will now be logged to help pinpoint certain issues that may arise:

- the SLDataMiner process ID,
- the output of the batch scripts that are being executed while DataMiner is (re)starting,
- etc.

Also, if DataMiner did not start up correctly for some reason, a retry will now be attempted in that same startup routine.

In the `C:\Skyline DataMiner\Tools` folder, you can also find the following new startup scripts:

- *DataMiner Start DataMiner And SLNet.bat*
- *DataMiner Start DataMiner.bat*

#### Renaming objects: DMA will throw a more clearer error message in case the name already exists [ID_36845]

<!-- MR 10.3.0 [CU6] - FR 10.3.9 -->

When an attempt is made to rename an object, the DataMiner Agent will now throw the following error message when the name already exists:

```txt
The name is already used by another object in the DMS.
```

Also, certain false positive errors that used to occur when renaming objects will no longer be logged in *SLErrors.txt*, and a NATS exception that is generated when a message needs to be sent from SLNet to SLDataGateway, SLHelper or SLAnalytics has now been converted to a *DataMinerException* to avoid DataMiner/client disconnects due to `message not marked as serializable` errors.

#### NATS firewall rule profiles set to 'All" during DataMiner upgrades [ID_36914]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

During a DataMiner upgrade, from now on, the *InstallNATS* upgrade action will set all existing NATS firewall rule profiles to "All".

#### SLLogCollector: Easier selection of processes after selecting 'Include memory dump' [ID_36982]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

When configuring the *SLLogCollector* tool, you can select the *Include memory dump* option, and then indicate for which process(es) memory dumps should be collected and when these should be collected. Up to now, to select a process, you had to select a checkbox. From now on, you will be able to select a process by clicking any cell in the row representing the process.

### Fixes

#### Problem due to incorrect NATS reconfiguration [ID_35246]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

When, for example in a three-node DMS configuration composed of a Failover pair and another, separate DMA, one of the agents in the Failover setup went offline, after 5 minutes, the separate non-Failover agent would incorrectly shift to a two-node DMS configuration. From now on, the non-Failover agent will keep the three-node DMS configuration if one of the Failover agents goes offline.

#### Cassandra: Table data that should not expire had a TTL value set [ID_35263]

<!-- MR 10.3.0 [CU6] - FR 10.3.9 -->

Up to now, in a Cassandra Cluster or a Cassandra Standalone database, certain table data that should not expire would incorrectly have a TTL value set when inserted. As a result, that data would automatically get deleted when the TTL value reached 0.

The following mechanisms have now been implemented:

- The affected table data will no longer have any TTL value configured when inserted. Moreover, as a safety measure, all Cassandra tables will now also have a `default_time_to_live` setting. This value will provide the default TTL value in case no value for the TTL is passed when inserting data.

- When existing data with an incorrect TTL value set is retrieved from the database, its TTL value will automatically be removed to prevent it from being deleted.

#### SLDataGateway: Memory leak when migrating average trend data from MySQL to Cassandra Cluster [ID_36367]

<!-- MR 10.3.0 [CU6] - FR 10.3.9 -->

SLDataGateway would leak memory when migrating average trend data from MySQL to Cassandra Cluster.

#### Problem when an SNMP connection was assigned to a separate thread [ID_36441]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

When, in a protocol, an SNMP connection was assigned to a separate thread, in most cases, the polling would get stuck because the main protocol thread would get notified of the response rather than the thread that was assigned to the SNMP connection.

From now on, a poll group will default to connection 0 rather than -1. As a result, when a separate thread is created for the main connection (i.e. the connection with ID 0), the groups for that connection will no longer need to have `connection="0"` specified.

Also, the following issues have been fixed:

- Potential memory leaks and SLProtocol errors related to SNMP and additional protocol threads. For example, up to now, stopping an element while a forced group was being executed could cause an error to occur in SLProtocol.

- Up to now, assigning the same connection ID to multiple thread elements could result in undefined behavior. From now on, connection IDs will be assigned according to what occurs first.

> [!NOTE]
> Known issue: Currently, the action to stop the current group is only capable of stopping the group on the main thread. It is not yet possible to specify a particular thread on which to stop a group.

#### Failover: Problems when running BPA tests [ID_36445]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

When the backup agent was active, certain BPA tests would incorrectly return the following error:

`This BPA does not apply for this Agent: cannot run on Offline Failover Agents`

Also, certain managers in SLNet (e.g. BPA Manager) would not properly initialize if the following Failover settings were configured in the *SLDMS.xml* file:

- `State="Offline"`
- `StateBeforeShutDown="Online"`

#### SNMPv3 credentials would not get deleted when an SNMPv3 element was deleted [ID_36573]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

When an SNMPv3 element was deleted, its SNMPv3 credentials would incorrectly not get deleted. Also, when users were deleted, their DCP credentials would not get deleted.

#### NT Notify type NT_ADD_VIEW could be executed with an invalid parent view ID [ID_36739]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

Up to now, when an `NT_ADD_VIEW` call was executed with `parentViewID` set to a non-existing view ID, the newly added view would not be visible in the Surveyor. Hence, there was no way of correcting the situation using the UI. Cube logging would include a warning that a `parentViewID` cannot be resolved.

Validation has now been added to `NT_ADD_VIEW`. When a request enters to create a view with an invalid parent view ID, the view will not be created. Also, views with an invalid parent view ID will now be placed directly under the root view. This will allow you to drag the view to its correct location, updating its parent view ID to a valid ID in the process. An error will also be logged and the *View Recursion* BPA test will report the view in question.

#### SLAnalytics - Behavioral anomaly detection: Problem when processing a behavioral change point [ID_36755]

<!-- MR 10.3.0 [CU6] - FR 10.3.9 -->

In some cases, an `index out of bounds` error could occur when processing a behavioral change point.

#### Problem with SLScripting when resolving assemblies [ID_36843]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

In some cases, an error could occur in SLScripting when it was resolving DLL files for a QAction or an Automation Script.

#### Problem with SLProtocol when the system locale was set to Japanese [ID_36854]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

On the system locale was set to Japanese, an error could occur in SLProtocol when a QAction tried to read a parameter value containing raw bytes.

#### Cassandra Cluster: Not all data would get offloaded when the database went down [ID_36865]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

When a Cassandra Cluster database went down, not all data would get offloaded.

#### Polling an SNMP table with MultipleGetNext could incorrectly produce two result sets [ID_36867]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

When an SNMP table was polled with *MultipleGetNext* and the response was not processed within 10 minutes, in some rare cases, an error could occur in SLSNMPManager, causing the table to be polled a second time as the result of a retry. This meant that, in such a case, one poll action would produce two result sets.

#### Elements would not be created on remote agents when importing elements from a CSV file [ID_36873]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

When you imported elements from a CSV file, new elements would only be created on the local agent, not on any of the remote agents, i.e. the agents other than the one the Cube client was connected to. Existing elements would be updated correctly on the local agents as well as on all remote agents.

#### Incorrect error message was thrown when NATS credentials could not be retrieved from a remote DMA [ID_36906]

<!-- MR 10.3.0 [CU6] - FR 10.3.9 -->

In some cases, when *NATSCustodian* was trying to set up a new configuration, some nodes could get an error with the following incorrect message:

`Failed to copy credentials from <ip> - corrupt zip file.`

From now on, an error containing the actual reason will be thrown instead. See the following example.

```txt
Failed to copy credentials from <ip> - TraceData: (amount = 1)
      - ErrorData: (amount = 1)
          - Reason: ModuleNotInitialized
```

#### A DataMiner Agent with a single-node Cassandra and an Elasticsearch would not start up when Elasticsearch was down [ID_36930]

<!-- MR 10.3.0 [CU6] - FR 10.3.9 -->

When a DataMiner Agent had its own single-node Cassandra database as well as its own Elasticsearch database, DataMiner would not start up when Elasticsearch was down. From now on, it will start up, but a full DataMiner restart will be required for all modules depending on Elasticsearch to work properly.

#### Elements would no longer be able to generate alarms and information events after having been migrated [ID_36951]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

When an element had been migrated from one DataMiner Agent to another, it would no longer be able to generate alarms and information events.

> [!IMPORTANT]
> The element protocol must pass the DataMiner ID of the element instead of the DataMiner ID of the DataMiner Agent.

#### Dynamic IP setting for a serial connection would cause incorrect SSH errors to be logged [ID_37016]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

When, for a particular parameter, the `options` attribute of the `<Type>` element was set to "dynamic ip" for a serial connection, the following incorrect entry would be added to the element's log file:

`An error occurred when applying SSH connection settings from parameters. Not implemented (hr = 0x80004001)`

Moreover, when additional logging was activated for SLPort, an `Attempted to set SSH options on a non-SSH connection` error would be added to the same log file, followed by an unreadable value (representing the IP address), which could even cause a fatal error to occur in SLPort.
