---
uid: General_Main_Release_10.4.0_CU10
---

# General Main Release 10.4.0 CU10 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Breaking changes

#### Automation: Locking behavior of Automation script actions has been enhanced [ID 41195]

<!-- MR 10.4.0 [CU10] - FR 10.5.1 -->

A number of enhancements have been made with regard to the locking behavior of certain Automation script actions. This should significantly reduce the chances of scripts influencing each other and slowing each other down.

Breaking changes:

| <div style="width: 150px;">Actions</div> | Breaking change |
|---|---|
| Generate Information<br>Log<br>Send Notification<br>Send Report | Text that supports the `[dummy<id>]` placeholder will display the old element name if it was updated during the execution of a script or it will still display the element name even if the element was deleted in the meantime. |
| Set State | The action will fail with a different error. Previously, when an element would be removed during the execution of a script, it would state "No valid protocol mapping found". Now, it will depend on the state, but should be "Failed to change element state...". |
| Set Template | The action will fail with a different error. Previously, when an element would be removed during the execution of a script, it would state "No valid protocol mapping found". Now, it will depend on the state, but should be "Failed to set template...". |

### Enhancements

#### Cassandra Cluster Migrator tool: Enhancements [ID 41099]

<!-- MR 10.4.0 [CU10]/10.5.0 [CU0] - FR 10.5.1 -->

A number of enhancements have been made to the Cassandra Cluster Migrator tool (*SLCCMigrator.exe*):

- The initialization of a single agent has been disabled in favor of the global initialization, unless not all agents could be initialized.
- Connection details will now only be requested once, unless not all agents could not be initialized.
- The migration can now only be started when all agents have successfully been initialized.

#### DxMs upgraded [ID 41297]

<!-- MR 10.4.0 [CU10]/10.5.0 [CU0] - FR 10.5.1 -->

The following DataMiner Extension Modules (DxMs), which are included in the DataMiner upgrade package, have been upgraded to the indicated versions:

- DataMiner ArtifactDeployer: version 1.8.1
- DataMiner CoreGateway: version 2.14.11
- DataMiner FieldControl: version 2.11.1
- DataMiner Orchestrator: version 1.7.1
- DataMiner SupportAssistant: version 1.7.1

For detailed information about the changes included in those versions, refer to the [dataminer.services change log](xref:DCP_change_log).

### Fixes

#### Memory leaks when an element that was used in an alarm level link configuration was restarted [ID 40997]

<!-- MR 10.4.0 [CU10]/10.5.0 [CU0] - FR 10.5.1 -->

When an element that was used in an alarm level link configuration was restarted, in some cases, both SLElement and SLProtocol could leak memory, as would SLDataMiner when the alarm level links were pushed to locked elements.

For more information on the `<AlarmLevelLinks>` element, see [How to aggregate alarm severities](xref:How_to_aggregate_alarm_severities)

#### SLElement: Incorrect alarm linking [ID 41057]

<!-- MR 10.4.0 [CU10]/10.5.0 [CU0] - FR 10.5.1 -->

In some cases, new alarm events could incorrectly get linked to previously closed external events or information events on the same element.

#### SLElement would leak memory when filtering a recursive table or a directview/view table that had to be sorted [ID 41058]

<!-- MR 10.4.0 [CU10]/10.5.0 [CU0] - FR 10.5.1 -->

When SLElement had to process a table filter request, it would leak memory in the following cases:

- When the table had a foreign key to itself.
- When a directview or view table with a number of non-initialized columns had to be sorted.

#### SLElement would leak memory when SLNet needed to be notified of baseline changes [ID 41088]

<!-- MR 10.4.0 [CU10]/10.5.0 [CU0] - FR 10.5.1 -->

When a baseline changed and SLNet needed to be notified of the new values, SLElement would leak memory.

#### LDAP/ActiveDirectory domain users would no longer be able to log in [ID 41143]

<!-- MR 10.4.0 [CU10]/10.5.0 [CU0] - FR 10.5.1 -->

Since DataMiner 10.4.0 [CU4]/10.4.7, in some cases, LDAP/ActiveDirectory domain users would no longer be able to log in. When such a user tried to log in, the following entry would be added to the SLNet.txt log file:

`Authentication Step Failure: Not a DataMiner user: CONTOSA\user`

This issue would only occur on LDAP servers where `CN=CONTOSA,CN=Partitions,CN=Configuration,DC=contosa,DC=com` does not have a `nETBIOSName` attribute, for example when accessing the GlobalCatalog of a forest.

After having upgraded to a DataMiner version that contains this fix, you can do the following:

- Wait up to an hour for the next LDAP synchronization to occur, or
- Manually trigger the "Skyline DataMiner LDAP Resync" task in Windows Task Scheduler.

All users should then be able to log in again.

#### STaaS: Excessive number of duplicate entries added to the SLErrors.txt log file in case of connection problems [ID 41192]

<!-- MR 10.4.0 [CU10]/10.5.0 [CU0] - FR 10.5.1 -->

On STaaS systems, in case of connection problems, a large number of the following errors would be added to the *SLErrors.txt* log file:

- *The remote name could not be resolved.*
- *Unable to connect to the remote server.*

From now on, in case of connection problems, the generation of *SLErrors.txt* log file entries will be throttled in order to reduce the number of duplicate entries.

#### Protocols: Problems when polling SNMP tables using GetNext [ID 41235]

<!-- MR 10.4.0 [CU10]/10.5.0 [CU0] - FR 10.5.1 -->

A number of problems that occurred when polling SNMP tables using *GetNext* have been fixed:

- When an entire SNMP table was polled using *GetNext* messages, and not all rows had values with the same syntax (e.g. 1.2.3 vs 4.5.6.7), in some cases, cells would be empty or would be shifted to another row. The SLSNMPManager process could even disappear. From now on, all table cell values will be displayed correctly.

- Up to now, an SNMP table would be polled until the returned OID result went out of scope. For example, when only 3 columns were defined in the table parameter, and the SNMP table contained 20 columns, all 20 columns would be polled, even though the data in the remaining 17 columns was not needed. From now on, as soon as the columns defined in the table parameter are polled, polling will stop and the result will be filled in.

- Up to now, only the rows with a value in the first column would be added to the table. From now on, when the table parameter has the `instance` option defined, rows of which the first column on the right of the instance column is empty will also be added to the table.
