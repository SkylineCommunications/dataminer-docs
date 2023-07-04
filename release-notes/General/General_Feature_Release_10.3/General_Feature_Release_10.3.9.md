---
uid: General_Feature_Release_10.3.9
---

# General Feature Release 10.3.9 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!IMPORTANT]
> When downgrading from DataMiner Feature Release version 10.3.8 (or higher) to DataMiner Feature Release version 10.3.4, 10.3.5, 10.3.6 or 10.3.7, an extra manual step has to be performed. For more information, see [Downgrading a DMS](xref:MOP_Downgrading_a_DMS).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.3.9](xref:Cube_Feature_Release_10.3.9).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.3.9](xref:Web_apps_Feature_Release_10.3.9).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

*No highlights have been selected for this release yet*

## Other features

*No features have been added to this release yet.*

## Changes

### Enhancements

#### Security enhancements [ID_36319]

<!-- 36319: MR 10.4.0 - FR 10.3.9 -->

A number of security enhancements have been made.

#### DataMiner upgrade: New upgrade action added that will clean up default ListView column configuration data [ID_36475]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

During a DataMiner upgrade, from now on, all default ListView column configuration data left on the server will automatically be cleaned up if no more than one Cube client has taken a copy of that data.

#### Cassandra Cleaner can now also be used to clean the 'infotrace' table [ID_36592]

<!-- MR 10.4.0 - FR 10.3.9 -->

Up to now, the *Cassandra Cleaner* tool could only be used to remove data from the *timetrace* table. From now on, it can also be used to remove data from the *infotrace* table.

1. In the *db.yaml* file, set `table.name` to "infotrace".

   By default, `table.name` is set to "timetrace".

1. Specify a time range by setting the `delete.start.time` and `delete.end.time` fields.

  > [!CAUTION]
  > All infotrace data between the `delete.start.time` and `delete.end.time` timestamps will be deleted, so be careful.

1. Run the following command: `clean -l`

   > [!NOTE]
   > The *infotrace* table can only be cleaned using the `clean -l` command.

For more information, see [Cassandra Cleaner](xref:Cassandra_Cleaner).

#### SLLogCollector will now also collect the scheduled tasks configured in Microsoft Task Scheduler [ID_36645]

SLLogCollector will now also collect the scheduled tasks configured in Microsoft Task Scheduler.

#### SLProtocol is now a 64-bit process by default [ID_36725]

SLProtocol is now a 64-bit process by default.

However, if necessary, it can still be run as a 32-bit process. For more information, see [Activating SLProtocol as a 32-bit process](xref:Activating_SLProtocol_as_a_32_Bit_Process).

#### DataMiner upgrade: Presence of Visual C++ 2010 redistributable will no longer be checked [ID_36745]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

During a DataMiner upgrade, from now on, the presence of the Visual C++ 2010 redistributable will no longer be checked.

#### DataMiner installation/upgrade: Updated DataMiner Extension Modules [ID_36799]

<!-- MR 10.4.0 - FR 10.3.9 -->

When you install or upgrade a DataMiner Agent, a number of DataMiner Extension Modules (DxMs) will automatically be installed (if not present yet). The following modules have now been updated:

- DataMiner CoreGateway (version 2.13.0)
- DataMiner SupportAssistant (version 1.4.0)

> [!NOTE]
> For detailed information on the changes included in the different versions of these DxMs, refer to the [dataminer.services change log](xref:DCP_change_log).

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
