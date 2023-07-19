---
uid: General_Main_Release_10.3.0_CU6
---

# General Main Release 10.3.0 CU6 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### DataMiner upgrade: New upgrade action added that will clean up default ListView column configuration data [ID_36475]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

During a DataMiner upgrade, from now on, all default ListView column configuration data left on the server will automatically be cleaned up if no more than one Cube client has taken a copy of that data.

#### Cassandra Cluster: Trend tables will no longer be sharded [ID_36551]

<!-- MR 10.3.0 [CU6] - FR 10.3.9 -->

On a Cassandra Cluster database, from now on, the trend tables will no longer be sharded. This will enhance overall performance when requesting trend data, especially on systems on which real-time trend data is stored for longer than a day.

#### SLLogCollector will now also collect the scheduled tasks configured in Microsoft Task Scheduler [ID_36645]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

SLLogCollector will now also collect the scheduled tasks configured in Microsoft Task Scheduler.

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

### Fixes

#### Cassandra: Table data that should not expire had a TTL value set [ID_35263]

<!-- MR 10.3.0 [CU6] - FR 10.3.9 -->

Up to now, in a Cassandra Cluster or a Cassandra Standalone database, certain table data that should not expire would incorrectly have a TTL value set when inserted. As a result, that data would automatically get deleted when the TTL value reached 0.

The following mechanisms have now been implemented:

- The affected table data will no longer have any TTL value configured when inserted. Moreover, as a safety measure, all Cassandra tables will now also have a `default_time_to_live` setting. This value will provide the default TTL value in case no value for the TTL is passed when inserting data.

- When existing data with an incorrect TTL value set is retrieved from the database, its TTL value will automatically be removed to prevent it from being deleted.

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

#### Polling an SNMP table with MultipleGetNext could incorrectly produce two result sets [ID_36867]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

When an SNMP table was polled with *MultipleGetNext* and the response was not processed within 10 minutes, in some rare cases, an error could occur in SLSNMPManager, causing the table to be polled a second time as the result of a retry. This meant that, in such a case, one poll action would produce two result sets.

#### Elements would not be created on remote agents when importing elements from a CSV file [ID_36873]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

When you imported elements from a CSV file, new elements would only be created on the local agent, not on any of the remote agents, i.e. the agents other than the one the Cube client was connected to. Existing elements would be updated correctly on the local agents as well as on all remote agents.

#### A DataMiner Agent with a single-node Cassandra and an Elasticsearch would not start up when Elasticsearch was down [ID_36930]

<!-- MR 10.3.0 [CU6] - FR 10.3.9 -->

When a DataMiner Agent had its own single-node Cassandra database as well as its own Elasticsearch database, DataMiner would not start up when Elasticsearch was down. From now on, it will start up, but a full DataMiner restart will be required for all modules depending on Elasticsearch to work properly.
